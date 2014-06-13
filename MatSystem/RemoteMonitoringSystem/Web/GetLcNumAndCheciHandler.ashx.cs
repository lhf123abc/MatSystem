using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;  

namespace web
{
    /// <summary>
    /// GetLcNumAndCheciHandler 的摘要说明
    /// </summary>
    public class GetLcNumAndCheciHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest (HttpContext context) {
            context.Response.ContentType = "text/plain";
            var lcnum = context.Request.QueryString["lcnum"];
            //var checi = context.Request.QueryString["checi"];
            context.Session["lcnum"] = lcnum;
            //context.Session["lcnum"] = checi;
            context.Response.Write("Hello World");
        }
     
        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}