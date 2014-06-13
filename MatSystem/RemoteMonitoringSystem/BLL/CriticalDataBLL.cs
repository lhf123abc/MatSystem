using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
using System.Text;
namespace Maticsoft.BLL
{
	/// <summary>
	/// CriticalData
	/// </summary>
	public partial class CriticalData
	{
		private readonly Maticsoft.DAL.CriticalData dal=new Maticsoft.DAL.CriticalData();
		public CriticalData()
		{}
        //#region  BasicMethod

        ///// <summary>
        ///// 得到最大ID
        ///// </summary>
        //public int GetMaxId()
        //{
        //    return dal.GetMaxId();
        //}

        ///// <summary>
        ///// 是否存在该记录
        ///// </summary>
        //public bool Exists(int id)
        //{
        //    return dal.Exists(id);
        //}

        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        //public int  Add(Maticsoft.Model.CriticalData model)
        //{
        //    return dal.Add(model);
        //}

        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public bool Update(Maticsoft.Model.CriticalData model)
        //{
        //    return dal.Update(model);
        //}

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool Delete(int id)
        //{
			
        //    return dal.Delete(id);
        //}
        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool DeleteList(string idlist )
        //{
        //    return dal.DeleteList(idlist );
        //}

        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public Maticsoft.Model.CriticalData GetModel(int id)
        //{
			
        //    return dal.GetModel(id);
        //}

        ///// <summary>
        ///// 得到一个对象实体，从缓存中
        ///// </summary>
        //public Maticsoft.Model.CriticalData GetModelByCache(int id)
        //{
			
        //    string CacheKey = "CriticalDataModel-" + id;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(id);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (Maticsoft.Model.CriticalData)objModel;
        //}

        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public DataSet GetList(string strWhere)
        //{
        //    return dal.GetList(strWhere);
        //}
        ///// <summary>
        ///// 获得前几行数据
        ///// </summary>
        //public DataSet GetList(int Top,string strWhere,string filedOrder)
        //{
        //    return dal.GetList(Top,strWhere,filedOrder);
        //}
        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public List<Maticsoft.Model.CriticalData> GetModelList(string strWhere)
        //{
        //    DataSet ds = dal.GetList(strWhere);
        //    return DataTableToList(ds.Tables[0]);
        //}
        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public List<Maticsoft.Model.CriticalData> DataTableToList(DataTable dt)
        //{
        //    List<Maticsoft.Model.CriticalData> modelList = new List<Maticsoft.Model.CriticalData>();
        //    int rowsCount = dt.Rows.Count;
        //    if (rowsCount > 0)
        //    {
        //        Maticsoft.Model.CriticalData model;
        //        for (int n = 0; n < rowsCount; n++)
        //        {
        //            model = dal.DataRowToModel(dt.Rows[n]);
        //            if (model != null)
        //            {
        //                modelList.Add(model);
        //            }
        //        }
        //    }
        //    return modelList;
        //}

        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public DataSet GetAllList()
        //{
        //    return GetList("");
        //}

        ///// <summary>
        ///// 分页获取数据列表
        ///// </summary>
        //public int GetRecordCount(string strWhere)
        //{
        //    return dal.GetRecordCount(strWhere);
        //}
        ///// <summary>
        ///// 分页获取数据列表
        ///// </summary>
        //public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        //{
        //    return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
        //}
        ///// <summary>
        ///// 分页获取数据列表
        ///// </summary>
        ////public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        ////{
        //    //return dal.GetList(PageSize,PageIndex,strWhere);
        ////}

        //#endregion  BasicMethod
		#region  ExtensionMethod
        public string GetSearchDataTable(string lcnum, string start, string end, int pageindex, int pagesize, out int pagecount)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = dal.GetSearchDataTable(lcnum, start, end, pageindex, pagesize, out pagecount);

            if (dt.Rows.Count > 0)
            {
                sb.Append("<table class='distable'>");
                sb.Append("<thead><tr><td>ID</td><td>车号</td><td>电机号</td><td>油压</td><td>水温</td><td>频率</td><td>转速</td><td>电压</td><td>电流</td><td>电机功率</td><td>功率因数</td><td>油压</td><td>报警</td><td>日期</td></tr></thead>");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("<tr>");

                    sb.Append("<td>" + dt.Rows[i][0].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][1].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][2].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][3].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][4].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][5].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][6].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][7].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][8].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][9].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][10].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][11].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][12].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][13].ToString() + "</td>");
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                sb.Append("&&" + pagecount.ToString("f2"));

            }

            return sb.ToString();
        }
        /// <summary>
        /// 关键数据入库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddCritialData( Model.CriticalData model)
        {
            if (dal.AddCritialData(model)>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 存储过程分页
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="pageindex"></param>
        /// <param name="lcnum"></param>
        /// <returns></returns>
        public string GetPartPageByProcedure(string lcnum, string start, string end, int pageindex, int pagesize, out int pagecount)
        {
            int rowCount = dal.GetPageCountByProcedure("lcNum='" + lcnum + "' and dateTime between '" + start + "' and '" + end + "'");
            pagecount = (rowCount - 1) / pagesize + 1;

             DataTable dt= dal.GetPartPageByProcedure("CriticalData", "*", "dateTime", pagesize, pageindex, 0, 0, "lcNum='" + lcnum + "' and dateTime between '" + start + "' and '" + end + "'");
             StringBuilder sb = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                sb.Append("<table class='distable'>");
                sb.Append("<thead><tr><td>ID</td><td>车号</td><td>电机号</td><td>油压</td><td>水温</td><td>频率</td><td>转速</td><td>电压</td><td>电流</td><td>电机功率</td><td>功率因数</td><td>油压</td><td>报警</td><td>日期</td></tr></thead>");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("<tr>");

                    sb.Append("<td>" + dt.Rows[i][0].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][1].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][2].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][3].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][4].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][5].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][6].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][7].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][8].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][9].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][10].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][11].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][12].ToString() + "</td>");
                    sb.Append("<td>" + dt.Rows[i][13].ToString() + "</td>");
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                sb.Append("&&" + pagecount.ToString());

            }

            return sb.ToString();
        }
		#endregion  ExtensionMethod
	}
}

