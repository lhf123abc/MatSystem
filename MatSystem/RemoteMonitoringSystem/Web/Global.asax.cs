using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Maticsoft.Model;
using System.Collections.Concurrent;
using System.Configuration;

namespace web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
         //   string[] serialNumArray = (ConfigurationManager.AppSettings["serialNumList"]).Split(','); 
            if(Application["RD"]==null)
            {
                //存储实时数据
                Application["RD"] = new ConcurrentDictionary<string, string>(15, 45);
            }
            if (Application["statusInfo"] == null)
            {
                //储存火车状态信息
                Application["statusInfo"] = new ConcurrentDictionary<string, TrainStatusInfo>(15, 45);
            }
            if (Application["requestList"] == null)
            {
                //存储对相关火车关键数据的请求列表，键为车号
                Application["requestList"] = new ConcurrentDictionary<string, List<RequestInfo>>(15, 45);
            }
            if (Application["RDPoints"] == null)
            {
                //实时数据相关，用于绘制折线图
                Application["RDPoints"] = new ConcurrentDictionary<string,List<ChartPointsInfo>>(15, 45);
            }
            if (Application["IPCComHelp"] == null)
            {
                //保存下位机IP用于发送TCP信息
                ConcurrentDictionary<string, string> IPCComHelpDictionary = new ConcurrentDictionary<string, string>(15, 45);
                Maticsoft.BLL.IPCComHelpBLL bll=new Maticsoft.BLL.IPCComHelpBLL();
                List<Maticsoft.Model.IPCComHelpInfo> ComHelplist=bll.GetAllIPCComHelpInfo();
                for(int i=0;i<ComHelplist.Count;i++)
                {
                    IPCComHelpDictionary[ComHelplist[i].SerialNum]=ComHelplist[i].IPStr;
                }

                Application["IPCComHelp"] = IPCComHelpDictionary;
            }

            
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}