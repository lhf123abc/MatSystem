using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maticsoft.Model;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Web.UI.DataVisualization.Charting;
using System.Web.SessionState;
using System.Drawing;
using System.Web.UI;
using System.Text;
using Maticsoft.DBUtility;
using System.Text.RegularExpressions;
using System.IO;

namespace web
{
    /// <summary>
    /// CriticalDataHandler 的摘要说明
    /// </summary>
    public class RealTimeDataHandler : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)//opCode 1写 0读
        {
            context.Response.ContentType = "text/plain";
            //操作码
            string opCode = context.Request.QueryString["opCode"];
            //车号
            string serialNum = context.Request.QueryString["sN"];    
            ConcurrentDictionary<string, string> criticalDataDictionary = null;
            ConcurrentDictionary<string, TrainStatusInfo> statusInfoDictionary = null;
            ConcurrentDictionary<string, List<RequestInfo>> requestListDictionary = null;
            ConcurrentDictionary<string, List<ChartPointsInfo>> RDPointsDictionary = null;
            ConcurrentDictionary<string, string> IPCComIPDictionary = null;
            //获取相关字典
            GetGlobalInfo(context, ref criticalDataDictionary, ref statusInfoDictionary, ref requestListDictionary, ref RDPointsDictionary,ref IPCComIPDictionary);
            if (statusInfoDictionary == null)
            {
                return;
            }
            //opCode等于1 表示下位机发送的实时数据，0表示浏览器请求实时数据
            if (opCode == "1")
            {
                //更新实时数据
                UpdateRealData(context, serialNum, criticalDataDictionary,RDPointsDictionary);
                if (requestListDictionary!=null)
                {

                    List<RequestInfo> requestList = null;
                    if (requestListDictionary.ContainsKey(serialNum))
                    {
                        requestList=requestListDictionary[serialNum];
                    }
                    if (requestList != null)
                    {
                        lock (requestList)
                        {
                            //循环浏览器请求队列，如果超过60s没有请求实时数据，认为浏览器已离开，将其从请求列表中删除
                            for (int i = 0; i < requestList.Count; i++)
                            {
                                if (DateTime.Now.Subtract(requestList[i].LastRequestDate).TotalSeconds > 60)
                                {
                                    requestList.RemoveAt(i);
                                }
                            }
                        }
                        //如果请求列表count大于0,返回1给工控机程序表示需要继续发送，反之返回0，通知工控机停止发送
                        if (requestList.Count > 0)
                        {
                            context.Response.Write('1');//1表示有浏览器在访问
                        }
                        else
                        {
                            context.Response.Write('0');
                        }
                    }

                }
                
            }
            else
                if (opCode == "0")
                {
                    GetRealData(serialNum, context, statusInfoDictionary, requestListDictionary, criticalDataDictionary, RDPointsDictionary,IPCComIPDictionary);
                }
            // context.Response.Write("Hello World");
        }

        /// <summary>
        /// 将实时数据写入http 响应流
        /// </summary>
        /// <param name="serialNum">车号</param>
        /// <param name="context">当前请求HttpContext</param>
        /// <param name="statusInfoDictionary"></param>
        /// <param name="requestListDictionary"></param>
        /// <param name="criticalDataDictionary"></param>
        /// <param name="RDPointsDictionary"></param>
        /// <param name="IPCComIPDictionary"></param>
        private static void GetRealData(string serialNum, HttpContext context, ConcurrentDictionary<string, TrainStatusInfo> statusInfoDictionary, ConcurrentDictionary<string, List<RequestInfo>> requestListDictionary, ConcurrentDictionary<string, string> criticalDataDictionary, ConcurrentDictionary<string, List<ChartPointsInfo>> RDPointsDictionary, ConcurrentDictionary<string, string> IPCComIPDictionary)
        {
            if (statusInfoDictionary.ContainsKey(serialNum))
            {
                if (statusInfoDictionary[serialNum].Status3G)
                {
                    //禁用缓存
                    context.Response.ContentType = "text/plain";
                    context.Response.CacheControl = "no-cache";
                    context.Response.Cache.SetNoStore();
                    //更新请求列表
                    UpdateRequestList(serialNum, context, requestListDictionary);
                    string criticalDataStr = null;

                    if (criticalDataDictionary.ContainsKey(serialNum))
                    {
                        //取得当前关键数据json字符串
                        criticalDataStr = criticalDataDictionary[serialNum];
                      //  File.AppendAllText(@"D:\我的文档\Desktop\123.txt", DateTime.Now.ToString() + ":"+serialNum+"::"+criticalDataStr+"\r\n");
                    }

                    //判断是否需要发送指令到工控机
                    if (judge(criticalDataDictionary,serialNum))
                    {

                        if (IPCComIPDictionary.ContainsKey(serialNum))
                        {
                           // File.AppendAllText(@"D:\我的文档\Desktop\123.txt",DateTime.Now.ToString()+"sendCmd");
                            TcpHelper.SendMsg("Start", IPCComIPDictionary[serialNum]);
                            
                        }
                        else
                        {
                            context.Response.Write("该下位机还未上线！");
                        }
                        //发命令到下位机
                        //return;
                    }
                    List<ChartPointsInfo> points = null;
                    if (RDPointsDictionary.ContainsKey(serialNum))
                    {
                        //获取水温数据点，用于绘制折线图
                        points=RDPointsDictionary[serialNum];
                       // File.AppendAllText(@"D:\我的文档\Desktop\23.txt", DateTime.Now.ToString() + "point:"+points.Count);
                    }
                    if (points != null && criticalDataStr != null)
                    {
                        Chart chart1 = null;
                        Chart chart2 = null;
                        Chart chart3 = null;
                      //  File.AppendAllText(@"D:\我的文档\Desktop\23.txt", DateTime.Now.ToString() + "chat ready\r\n");
                       // Task task = new Task(() =>
                        //{
                        foreach (ChartPointsInfo cpi in points)
                        {
                           // File.AppendAllText(@"D:\我的文档\Desktop\23.txt", DateTime.Now.ToString() + "get Chart\r\n");
                            switch (cpi.GeneratorId)
                            {
                                case 1:
                                    chart1 = GetChart(cpi.WaterTempPoints);
                                    break;
                                case 2:
                                    chart2 = GetChart(cpi.WaterTempPoints);
                                    break;
                                case 3:
                                    chart3 = GetChart(cpi.WaterTempPoints);
                                    break;
                            }
                        }
                           
                      //  task.Start();
                        //string jsonStr = JsonConvert.SerializeObject(criticalDataList);
                       // task.Wait();
                        //获取当前请求的HtmlTextWriter,将图表生成到响应流中
                        HtmlTextWriter htw = context.Request.Browser.CreateHtmlTextWriter(context.Response.Output);
                        if (chart1 != null)
                        {
                            chart1.RenderControl(htw);
                        }
                        context.Response.Write("&&");
                        if (chart2 != null)
                        {
                            chart2.RenderControl(htw);
                        }
                        context.Response.Write("&&");
                        if (chart3 != null)
                        {
                            chart3.RenderControl(htw);
                        }
                        context.Response.Write("&&");
                        context.Response.Write(criticalDataStr);

                    }

                  
                }
                else
                {
                    //不在线
                }
            }

        } 

        //判断是否需要向工控机发送命令
        private static bool judge(ConcurrentDictionary<string, string> cdDictionary, string serialNum)
        {
          
            if (cdDictionary.ContainsKey(serialNum))
            {
                string jsonStr=cdDictionary[serialNum];
                Match m=Regex.Match(jsonStr, "(?<=\"Date\":\").*?(?=\")");
                DateTime dt = default(DateTime);
                DateTime.TryParse(m.Value, out dt);
                //File.AppendAllText(@"D:\我的文档\Desktop\123.txt", DateTime.Now.ToString() + ":"+serialNum+"::"+dt.ToString()+"\r\n");
                //最新实时数据与当前时间相比大于60s 认为工控机程序已经停止发送关键数据
                if (DateTime.Now.Subtract(dt).TotalSeconds > 60)
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
            return false;
        }

        //生成曲线图
        private static Chart GetChart(List<float> points)
        {
            
            Chart chart = new Chart();
            ChartArea area = new ChartArea("chartArea1");
            ChartArea area1 = new ChartArea("chartArea2");
            ChartArea area2 = new ChartArea("chartArea3");
            area.AxisX.Enabled = AxisEnabled.True;
            area.AxisY.Enabled = AxisEnabled.True;

            area.AxisX.Maximum = 10;
            area.AxisX.Minimum = 1;
            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Interval = 1;
            area.AxisX.MajorGrid.LineWidth = 1;
            area.AxisX.MajorGrid.Enabled = true;
            area.AxisX.MajorGrid.LineColor = Color.DimGray;
            area.AxisX.MinorGrid.Interval = 0.5;
            area.AxisX.MinorGrid.LineWidth = 1;
            area.AxisX.MinorGrid.Enabled = true;
            area.AxisX.MinorGrid.LineColor = Color.LightGray;
            area.AxisX.IntervalType = DateTimeIntervalType.Number;
            area.AxisY.Maximum = 65;
            area.AxisY.Minimum = 55; area.AxisY.Interval = 5;
            area.AxisY.MajorGrid.Enabled = true;
            area.AxisY.MajorGrid.LineColor = Color.DimGray;
            area.AxisY.MajorGrid.Interval = 5;
            area.AxisY.MajorGrid.LineWidth = 1;
            area.AxisY.MinorGrid.Interval = 0.5;
            area.AxisY.MinorGrid.LineWidth = 1;
            area.AxisY.MinorGrid.Enabled = true;
            area.AxisY.MinorGrid.LineColor = Color.LightGray;
            area.AxisY.IntervalType = DateTimeIntervalType.Number;
            chart.ChartAreas.Add(area);
            chart.Height = 200;
            chart.Width = 200;
            area.AlignmentOrientation = AreaAlignmentOrientations.Horizontal;
            Series ser = new Series();
            ser.ChartArea = "chartArea1";
            chart.Series.Add(ser);
            Legend legend = new Legend("default");
            legend.LegendStyle = LegendStyle.Row;
            legend.Alignment = StringAlignment.Center;
            legend.Docking = Docking.Bottom;
            ser.ChartType = SeriesChartType.Line;
            chart.Legends.Add(legend);
            ser.Legend = "default";
            ser.LegendText = "水温";
            for (int i = 0; i < points.Count; i++)
            {
                ser.Points.AddXY(i, points[i]);
            }

            return chart;
           
        }

        /// <summary>
        /// 更新对车号为serialNum的火车的实时关键数据的请求队列
        /// </summary>
        /// <param name="serialNum"></param>
        /// <param name="context"></param>
        /// <param name="requestListDictionary"></param>
        private static void UpdateRequestList(string serialNum, HttpContext context, ConcurrentDictionary<string, List<RequestInfo>> requestListDictionary)
        {

            if (requestListDictionary.ContainsKey(serialNum))
            {
                List<RequestInfo> requestList = requestListDictionary[serialNum];
                RequestInfo currentRequestInfo = null;
                lock (requestList)
                {
                    currentRequestInfo = requestList.SingleOrDefault<RequestInfo>((RequestInfo requestInfo) =>
                    {
                        return requestInfo.SessionId == context.Session.SessionID;
                    });
                    if (currentRequestInfo != null)
                    {
                        currentRequestInfo.LastRequestDate = DateTime.Now;
                    }
                    else
                    {
                        currentRequestInfo = new RequestInfo { SessionId = context.Session.SessionID, LastRequestDate = DateTime.Now };
                        requestList.Add(currentRequestInfo);
                    }
                }
            }
            else
            {
                lock (requestListDictionary)
                {
                    if (!requestListDictionary.ContainsKey(serialNum))
                    {
                        List<RequestInfo> clientList = new List<RequestInfo>(10);
                        clientList.Add(new RequestInfo { LastRequestDate = DateTime.Now, SessionId = context.Session.SessionID });
                        requestListDictionary[serialNum] = clientList;
                    }
                    else
                    {
                        List<RequestInfo> requestList = requestListDictionary[serialNum];
                        RequestInfo currentRequestInfo = null;
                        lock (requestList)
                        {
                            currentRequestInfo = requestList.SingleOrDefault<RequestInfo>((RequestInfo requestInfo) =>
                            {
                                return requestInfo.SessionId == context.Session.SessionID;
                            });
                            if (currentRequestInfo != null)
                            {
                                currentRequestInfo.LastRequestDate = DateTime.Now;
                            }
                            else
                            {
                                currentRequestInfo = new RequestInfo { SessionId = context.Session.SessionID, LastRequestDate = DateTime.Now };
                                requestList.Add(currentRequestInfo);
                            }
                        }
                    }
                }
            }
        }
        
        //更新实时数据
        private static void UpdateRealData(HttpContext context, string serialNum, ConcurrentDictionary<string,string> criticalDataDictionary, ConcurrentDictionary<string, List<ChartPointsInfo>> RDPointsDictionary)
        {
            string jsonStr = context.Request.QueryString["value"];
            jsonStr=jsonStr.Replace(' ', '+');
            //File.AppendAllText(@"D:\我的文档\Desktop\123.txt", DateTime.Now.ToString() + ":"+serialNum+"::"+jsonStr+"\r\n");
            MatchCollection generatorIdMc = Regex.Matches(jsonStr, "(?<=\"GeneratorId\":).*?(?=,\")");
            MatchCollection wtMc = Regex.Matches(jsonStr, "(?<=\"WaterTemp\":).*?(?=,\")");
            criticalDataDictionary[serialNum] = jsonStr;
            if (RDPointsDictionary.ContainsKey(serialNum))
            {
                List<ChartPointsInfo> pointsList = RDPointsDictionary[serialNum] as List<ChartPointsInfo>;
                for (int j = 0; j < generatorIdMc.Count; j++)
                {
                    int generatorId = 0;
                    int.TryParse(generatorIdMc[j].Value,out generatorId);
                    ChartPointsInfo point= pointsList.SingleOrDefault<ChartPointsInfo>((ChartPointsInfo cpi) => 
                    {
                        return cpi.GeneratorId == generatorId;
                    });
                    if (point == null)
                    {
                        point = new ChartPointsInfo { WaterTempPoints = new List<float>(10), OilPressPoints = new List<float>(10), GeneratorId = generatorId};
                        pointsList.Add(point);
                    }
                    lock (point)
                    {
                        if (point.WaterTempPoints.Count > 9)
                        {
                            point.WaterTempPoints.RemoveAt(0);
                        }
                        float waterTempPoint = 0;
                        float.TryParse(wtMc[j].Value, out waterTempPoint);
                        point.WaterTempPoints.Add(waterTempPoint);
                    }
                }
            }
            else
            {
                
                    List<ChartPointsInfo> pointsList= new List<ChartPointsInfo>(3);
                    for (int k = 0; k < generatorIdMc.Count; k++)
                    {
                        int generatorId = 0;
                        int.TryParse(generatorIdMc[k].Value,out generatorId);
                        float waterTempPoint = 0;
                        float.TryParse(wtMc[k].Value, out waterTempPoint);
                        ChartPointsInfo cPoint = new ChartPointsInfo { WaterTempPoints = new List<float>(10), OilPressPoints = new List<float>(10), GeneratorId = generatorId};
                        cPoint.WaterTempPoints.Add(waterTempPoint);
                    }
                    
                    RDPointsDictionary[serialNum] = pointsList;
            }
            

        }
        
        /// <summary>
        /// 将application类型，转化为具体的字典类型
        /// </summary>
        /// <param name="context"></param>
        /// <param name="criticalDataDictionary"></param>
        /// <param name="statusInfoDictionary"></param>
        /// <param name="requestListDictionary"></param>
        /// <param name="RDPointsDictionary"></param>
        /// <param name="IPCComHelpDictionary"></param>
        private static void GetGlobalInfo(HttpContext context, ref ConcurrentDictionary<string, string> criticalDataDictionary, ref ConcurrentDictionary<string, TrainStatusInfo> statusInfoDictionary, ref ConcurrentDictionary<string, List<RequestInfo>> requestListDictionary, ref  ConcurrentDictionary<string, List<ChartPointsInfo>> RDPointsDictionary,ref ConcurrentDictionary<string,string> IPCComHelpDictionary)
        {
            //实时数据
            if (context.Application["RD"] != null)
            {
                criticalDataDictionary = context.Application["RD"] as ConcurrentDictionary<string, string>;
               // criticalDataDictionary["998318"] = new CriticalData[] { new CriticalData("998318", 1, (float)12.5, (float)234.6, (float)1.0, (float)45.0, (float)56.0, (float)45.6, (float)23.7, (float)12.7, (float)56.4, 12, DateTime.Now) };
            }
            //else
            //{
            //    criticalDataDictionary = new ConcurrentDictionary<string, CriticalData[]>(10, 45);
            //    context.Application["RD"] = criticalDataDictionary;
            //}

            if (context.Application["statusInfo"] != null)
            {
                statusInfoDictionary = context.Application["statusInfo"] as ConcurrentDictionary<string, TrainStatusInfo>;
                //statusInfoDictionary["998318"] = new Maticsoft.TrainStatusInfo { IPStr = "192.168.20.32", LastLoginedDate = DateTime.Now, StatusGenerator1 = true, StatusGenerator2 = true, StatusGenerator3 = true };
            }
            if (context.Application["requestList"] != null)
            {
                requestListDictionary = context.Application["requestList"] as ConcurrentDictionary<string, List<RequestInfo>>;
            }
            if (context.Application["RDPoints"] != null)
            {
                RDPointsDictionary = context.Application["RDPoints"] as ConcurrentDictionary<string, List<ChartPointsInfo>>;
                //RDPointsDictionary["998318"] = new Maticsoft.ChartPointsInfo[]{ new Maticsoft.ChartPointsInfo { OilPressPoints = null, WaterTempPoints = new List<float>() {300,350,390,400,500 } }};
            }
            if (context.Application["IPCComHelp"] != null)
            {
                IPCComHelpDictionary = context.Application["IPCComHelp"] as ConcurrentDictionary<string, string>;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}