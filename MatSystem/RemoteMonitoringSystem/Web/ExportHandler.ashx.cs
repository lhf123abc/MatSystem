using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maticsoft.BLL;
using System.Web.SessionState;

namespace web
{
    /// <summary>
    /// ExportHandler 的摘要说明
    /// </summary>
    public class ExportHandler : IHttpHandler, IRequiresSessionState
    {
        private static readonly string relativePath = "";
        private const int pageSize = 20; 
        public void ProcessRequest (HttpContext context) {//opCode 0 cd导出excel 1 ir导出Excel 2cd pdf 3 ir pdf
            context.Response.ContentType = "text/plain";
            string phsicalPath=context.Server.MapPath(relativePath);
            ExportBLL exportBLL=new ExportBLL(phsicalPath);
            int pageCount;
            string opCode=context.Request.QueryString["opCode"];
            int pageNum=int.Parse(context.Request.QueryString["pN"]);
            string startDate=context.Request.QueryString["sD"];
            string endDate=context.Request.QueryString["eD"];
            string serialNum=context.Request.QueryString["sN"].Trim();

            string fileName = null;
            if (opCode == "0")
            {
                fileName=exportBLL.ExportExcelByCriticalData(serialNum, serialNum + "车关键数据"+ context.Session.SessionID, startDate, endDate, pageNum, pageSize, out pageCount);
            }
            else
                if (opCode == "1")
                {
                    fileName = exportBLL.ExportExcelByInspectionRecords(serialNum, serialNum + "车巡检记录", startDate, endDate, pageNum, pageSize);
                }
                else
                    if (opCode == "2")
                    {
                        fileName = exportBLL.ExportPdfByCriticalData(serialNum, serialNum + "车关键数据", startDate, endDate, pageNum, pageSize);
                    }
                    else
                        if(opCode=="3")
                        {
                            fileName = exportBLL.ExportPdfByByInspectionRecords(serialNum, serialNum + "车巡检记录", startDate, endDate, pageNum, pageSize);
                        }

            if(fileName!=null)
            {
                string path = relativePath + "/" + fileName;
                context.Response.Write(fileName);
            }
            else
            {
                context.Response.Write("javascript:alert('生成错误')");
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