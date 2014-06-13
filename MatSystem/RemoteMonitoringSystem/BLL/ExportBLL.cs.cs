using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Maticsoft.BLL
{
	public class ExportBLL
	{
        private static readonly Maticsoft.DAL.CriticalData cdDAL = new Maticsoft.DAL.CriticalData();
        private static readonly Maticsoft.DAL.InspectionRecords irDAL = new Maticsoft.DAL.InspectionRecords();
        private static readonly string[] cdTh = new string[] {"ID","车号","电机号","油位","水温","频率","发动机转速","电压","电流","发电机功率","功率因素","油压","报警值","采集时间" };
        private static readonly string[] irTh = new string[] { "车号","巡检状态","计划时间","实检时间","巡检人","备注"};
        private string tempPath =null;// @"I:\20140516\MatSystem\RemoteMonitoringSystem\Web\ExportTemp";//在配置文件中设置相对路径
        public ExportBLL(string path)
        {
            this.tempPath=path;
        }
        public string ExportExcelByCriticalData(string lcNum,string title,string dateStart,string endStart,int pageNum,int pageSize,out int pageCount)
        {
            DataTable dt = null;
            //数据库中获取
            pageCount = 0;
            HSSFWorkbook hssfWorkbook = new HSSFWorkbook();
            HSSFSheet hssfSheet = (NPOI.HSSF.UserModel.HSSFSheet)hssfWorkbook.CreateSheet("sheet1");
            ICellStyle cellStyle = hssfWorkbook.CreateCellStyle();
            cellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            IRow rowHead = hssfSheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                rowHead.CreateCell(i, CellType.String);
            }
            rowHead.GetCell(0).SetCellValue(title);
            rowHead.RowStyle=cellStyle;
            hssfSheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dt.Columns.Count - 1));
            IRow rowTh = hssfSheet.CreateRow(1);
            for (int i = 0; i < cdTh.Length; i++)
            {
                rowTh.CreateCell(i, CellType.String).SetCellValue(cdTh[i]);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row = hssfSheet.CreateRow(i + 2);
                row.CreateCell(0, CellType.Numeric).SetCellValue((int)dt.Rows[i][0]);
                row.CreateCell(1, CellType.String).SetCellValue((string)dt.Rows[i][1]);
                row.CreateCell(2, CellType.Numeric).SetCellValue((int)dt.Rows[i][2]);
                for (int j = 3; j < dt.Columns.Count-2; j++)
                {
                    row.CreateCell(j, CellType.Numeric).SetCellValue((float)dt.Rows[i][j]);
                }
                row.CreateCell(dt.Columns.Count - 2, CellType.Numeric).SetCellValue((int)dt.Rows[i][dt.Columns.Count - 2]);
                row.CreateCell(dt.Columns.Count - 1, CellType.String).SetCellValue(((DateTime)dt.Rows[i][dt.Columns.Count - 1]).ToString());
            }
            string fileName = title + DateTime.Now.ToString() + ".xls";
            string fullName = tempPath + "\\" +fileName;
            using (FileStream fs = new FileStream(fullName, FileMode.Create))
            {
                hssfWorkbook.Write(fs);
            }
            return fileName;
            
        }


        public string ExportPdfByCriticalData(string lcNum, string title, string dateStart, string endStart, int pageNum, int pageSize)
        {
            DataTable dt = null;
            //数据库查询
            int pageTotal;
            Document doc = new Document();
            string fileName=title + DateTime.Now.ToString() + ".pdf";
            string fullName = tempPath + "\\" +fileName ;
            using (FileStream fs = new FileStream(fullName, FileMode.Create))
            {
                PdfWriter pdfWriter = PdfWriter.GetInstance(doc, fs);
                doc.Open();
                doc.AddTitle(title);
                doc.AddSubject(DateTime.Now.ToShortDateString());
                Paragraph p = new Paragraph(title);
                p.Alignment = 1;
                doc.Add(p);
                doc.Add(new Paragraph(""));
                PdfPTable pTable = new PdfPTable(dt.Columns.Count);
                for (int i = 0; i < cdTh.Length; i++)
                {
                    pTable.AddCell(cdTh[i]);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        pTable.AddCell(dt.Rows[i][j].ToString());
                    }
                }
                return fileName;
            }
           
        }

        public string ExportExcelByInspectionRecords(string serialNum,string title,string startDate,string endDate,int pageNum,int pageSize)
        {
            int pageTotal;
            DataTable dt = irDAL.GetXJDataByPage(serialNum, startDate, endDate, pageNum, pageSize, out pageTotal);
            HSSFWorkbook hssfWorkbook = new HSSFWorkbook();
            HSSFSheet hssfSheet = (NPOI.HSSF.UserModel.HSSFSheet)hssfWorkbook.CreateSheet("sheet1");
            ICellStyle cellStyle = hssfWorkbook.CreateCellStyle();
            cellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            IRow rowHead = hssfSheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                rowHead.CreateCell(i, CellType.String);
            }
            rowHead.GetCell(0).SetCellValue(title);
            rowHead.RowStyle = cellStyle;
            hssfSheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dt.Columns.Count - 2));
            IRow rowTh = hssfSheet.CreateRow(1);
            for (int i = 0; i < irTh.Length; i++)
            {
                rowTh.CreateCell(i, CellType.String).SetCellValue(irTh[i]);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row = hssfSheet.CreateRow(i + 2);
                for (int j = 0; j < dt.Columns.Count-1; j++)
                {
                    row.CreateCell(j, CellType.String).SetCellValue(dt.Rows[i][j + 1].ToString());
                }
            }
            string fileName=title + ".xls";
            string fullName = tempPath + "\\" + fileName;
            using (FileStream fs = new FileStream(fullName, FileMode.Create))
            {
                hssfWorkbook.Write(fs);
            }
            return fileName;
        }

        public string ExportPdfByByInspectionRecords(string serialNum, string title, string startDate, string endDate, int pageNum, int pageSize)
        {
            int pageTotal;
            DataTable dt = irDAL.GetXJDataByPage(serialNum, startDate, endDate, pageNum, pageSize, out pageTotal);
            Document doc = new Document();
            string fileName=title  + ".pdf";
            string fullName = tempPath + "\\" + fileName;
            using (FileStream fs = new FileStream(fullName, FileMode.OpenOrCreate))
            {
                PdfWriter pdfWriter = PdfWriter.GetInstance(doc, fs);
                doc.Open();
                doc.AddTitle(title);
                doc.AddSubject(DateTime.Now.ToShortDateString());
                Paragraph p = new Paragraph(title);
                p.Alignment = 1;
                doc.Add(p);
                doc.Add(new Paragraph(""));
                PdfPTable pTable = new PdfPTable(dt.Columns.Count-1);
                for (int i = 0; i < irTh.Length; i++)
                {
                    pTable.AddCell(irTh[i]);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count-1; j++)
                    {
                        pTable.AddCell(dt.Rows[i][j+1].ToString());
                    }
                }
                doc.Add(pTable);
                return fileName;
            }
        }



	}
}
