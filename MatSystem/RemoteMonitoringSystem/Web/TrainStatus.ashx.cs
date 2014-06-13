using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Concurrent;
using System.Text;
using Maticsoft.Model;
using System.IO;

namespace web
{
    /// <summary>
    /// TrainStatus 的摘要说明
    /// </summary>
    public class TrainStatus : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)//
        {
            context.Response.ContentType = "text/plain";
            string opCode = context.Request.QueryString["opCode"];//opcode 1写0读 2表示报道
            if (opCode == "2")
            {
                string serialNum = context.Request.QueryString["sN"];
                UpdateLoginedTime(context, serialNum);
               // File.AppendAllText(@"D:\我的文档\Desktop\123.txt", DateTime.Now.ToString() +":"+ serialNum+"Login\r\n");
            }
            else
                if (opCode == "1")
                {
                    string serialNum = context.Request.QueryString["sN"];
                    //电机状态
                    string gsStr = context.Request.QueryString["gS"];
                    //报警值
                    string alarmValue = context.Request.QueryString["A"];
                    //更新火车状态信息
                    UpdateTrainInfoStatus(context, gsStr, alarmValue, serialNum);
                }
                else
                    if (opCode == "0")
                    {
                        //返回当前在线的工控机
                        if (context.Application["statusInfo"] != null)
                        {
                            //禁用浏览器缓存
                            context.Response.CacheControl = "no-cache";
                            context.Response.Cache.SetNoStore();
                            ConcurrentDictionary<string, TrainStatusInfo> statusDictionary = context.Application["statusInfo"] as ConcurrentDictionary<string, TrainStatusInfo>;
                           // ConcurrentDictionary<string, TrainStatusInfo> statusDictionary = CreatTestDictionary();
                            StringBuilder jsonBuilder = GetStatusJsonStr(statusDictionary);
                            context.Response.Write(jsonBuilder.ToString());

                        }
                    }
            // context.Response.Write("Hello World");
        }
        /// <summary>
        /// 获取当前在线火车的各种状态信息，返回json
        /// </summary>
        /// <param name="statusDictionary"></param>
        /// <returns></returns>
        
        private static StringBuilder GetStatusJsonStr(ConcurrentDictionary<string, TrainStatusInfo> statusDictionary)
        {
            StringBuilder jsonBuilder = new StringBuilder(48);
            lock (statusDictionary)
            {
                jsonBuilder.Append("[");
                foreach (string key in statusDictionary.Keys)
                {
                    TrainStatusInfo tsInfo = statusDictionary[key];
                    if (!tsInfo.Status3G)
                    {
                        continue;
                    }
                    lock (tsInfo)
                    {
                        jsonBuilder.Append("{\"serialNum\":\"").Append(key).Append("\",\"status3G\":\"").Append(tsInfo.Status3G).Append("\",\"gs1\":\"");
                        jsonBuilder.Append(tsInfo.StatusGenerator1).Append("\",\"gs2\":\"").Append(tsInfo.StatusGenerator2).Append("\",\"gs3\":\"");
                        jsonBuilder.Append(tsInfo.StatusGenerator3).Append("\",\"alarmValue\":\"").Append(tsInfo.AlarmValue).Append("\"},");
                    }
                }
                if (jsonBuilder.Length > 1)
                {
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                }

                jsonBuilder.Append("]");
            }
            return jsonBuilder;
        }

        //更新最后登录时间
        private static void UpdateLoginedTime(HttpContext context, string serialNum)
        {
            if (context.Application["statusInfo"] != null)
            {
                ConcurrentDictionary<string, TrainStatusInfo> statusDictionary = context.Application["statusInfo"] as ConcurrentDictionary<string, TrainStatusInfo>;

                if (statusDictionary.ContainsKey(serialNum))
                {
                    TrainStatusInfo tsInfo = statusDictionary[serialNum];
                    lock (tsInfo)
                    {

                        tsInfo.LastLoginedDate = DateTime.Now;

                    }
                }
                else
                {

                    statusDictionary[serialNum] = new TrainStatusInfo
                    {
                        LastLoginedDate = DateTime.Now,
                    };


                }
            }
        }

        //更新火车状态信息
        private static void UpdateTrainInfoStatus(HttpContext context, string gsStr, string alarmValue, string serialNum)
        {
            if (context.Application["statusInfo"] != null)
            {
                ConcurrentDictionary<string, TrainStatusInfo> statusDictionary = context.Application["statusInfo"] as ConcurrentDictionary<string, TrainStatusInfo>;

                if (statusDictionary.ContainsKey(serialNum))
                {
                    TrainStatusInfo tsInfo = statusDictionary[serialNum];
                    lock (tsInfo)
                    {
                        if (!String.IsNullOrEmpty(gsStr))
                        {
                            tsInfo.StatusGenerator1 = gsStr[0] == '1';
                            tsInfo.StatusGenerator2 = gsStr[1] == '1';
                            tsInfo.StatusGenerator3 = gsStr[2] == '1';
                        }
                        tsInfo.LastLoginedDate = DateTime.Now;
                        if (!String.IsNullOrEmpty(alarmValue))
                        {
                            int av = 0;
                            int.TryParse(alarmValue, out av);
                            tsInfo.AlarmValue = av;
                        }
                    }
                }
                else
                {
                    int av = 0;
                    int.TryParse(alarmValue,out av);
                    TrainStatusInfo statusInfo = new TrainStatusInfo
                         {
                             LastLoginedDate = DateTime.Now,
                             AlarmValue = av
                         };
                    if(!String.IsNullOrEmpty(gsStr))
                    {
                        statusInfo.StatusGenerator1 = gsStr[0] == '1';
                        statusInfo.StatusGenerator2 = gsStr[1] == '1';
                        statusInfo.StatusGenerator3 = gsStr[2] == '1';
                    }
                    statusDictionary[serialNum] = statusInfo;

                }

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