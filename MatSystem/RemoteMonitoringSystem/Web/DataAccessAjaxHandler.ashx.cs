using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;

namespace web
{
    /// <summary>
    /// DataAccessAjaxHandler 的摘要说明
    /// </summary>
    public class DataAccessAjaxHandler : IHttpHandler
    {
        public int totalpage;
        public void ProcessRequest(HttpContext context)
        {
            
            context.Response.ContentType = "text/plain";
            Maticsoft.BLL.CriticalData bl = new Maticsoft.BLL.CriticalData();
            if (context.Request.QueryString["type"]=="0")
            {
              
            string lcnumber = context.Request.QueryString["droplcnumber"];
            string startdate = context.Request["starttime"].Trim();
            string enddate = context.Request["endtime"].Trim();
            context.Response.Write(bl.GetPartPageByProcedure(lcnumber, startdate, enddate, 1, 10, out totalpage));
            }
            else
            {
                string lcnumber = context.Request.QueryString["droplcnumber"];
                string startdate = context.Request["starttime"];
                string enddate = context.Request["endtime"];
                int currentpage = Convert.ToInt32(context.Request["currentpage"]);
                context.Response.Write(bl.GetPartPageByProcedure(lcnumber, startdate, enddate, currentpage, 10, out totalpage));
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