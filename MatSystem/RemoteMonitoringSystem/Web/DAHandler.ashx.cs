using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace web
{
    /// <summary>
    /// DAHandler 的摘要说明
    /// </summary>
    public class DAHandler : IHttpHandler {
        private static Maticsoft.BLL.CriticalData cdBLL = new Maticsoft.BLL.CriticalData();
        private static Maticsoft.BLL._XJbll XJBLL = new Maticsoft.BLL._XJbll();

        public void ProcessRequest (HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string opCode=context.Request.QueryString["opCode"];//0 cd 1 ir
            string jsonStr=context.Request.QueryString["value"];
            jsonStr = jsonStr.Replace(" ", "+");
            //接收数据并入库 opCode 为0表示关键数据入库，为1 表示巡检记录入库
            if (opCode == "0")
            {
                List<Maticsoft.Model.CriticalData> cdList = JsonConvert.DeserializeObject<List<Maticsoft.Model.CriticalData>>(jsonStr);
                //List<Model.CriticalData> cdList = JsonConvert.DeserializeObject<List<Model.CriticalData>>(jsonStr);
                foreach (Maticsoft.Model.CriticalData cd in cdList)
                {
                    cdBLL.AddCritialData(cd);
                }
                context.Response.Write("1");
            }
            else
                if (opCode == "1")
                {
                    Maticsoft.Model._XJmodel xj = JsonConvert.DeserializeObject<Maticsoft.Model._XJmodel>(jsonStr);
                    //List<Model.CriticalData> cdList = JsonConvert.DeserializeObject<List<Model.CriticalData>>(jsonStr);
                    
                     XJBLL.Add_xjmodel(xj);
                     context.Response.Write("1");
                    
                }
            //context.Response.Write("Hello World");
        }
     
        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}