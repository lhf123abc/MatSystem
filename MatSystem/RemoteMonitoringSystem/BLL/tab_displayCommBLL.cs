using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
using System.Text;
namespace Maticsoft.BLL
{
	/// <summary>
	/// tab_displayComm
	/// </summary>
	public partial class tab_displayComm
	{
		private readonly Maticsoft.DAL.tab_displayComm dal=new Maticsoft.DAL.tab_displayComm();
		public tab_displayComm()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Maticsoft.Model.tab_displayComm model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.tab_displayComm model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.tab_displayComm GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.tab_displayComm GetModelByCache(int ID)
		{
			
			string CacheKey = "tab_displayCommModel-" + ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.tab_displayComm)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.tab_displayComm> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.tab_displayComm> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.tab_displayComm> modelList = new List<Maticsoft.Model.tab_displayComm>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.tab_displayComm model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
         ///<summary>
         ///分页获取数据列表
         ///</summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //    return dal.GetList(PageSize,PageIndex,strWhere);
        //}

		#endregion  BasicMethod
		#region  ExtensionMethod
         public string GetSearchDataTable(string lcnum, string start, string end, int pageindex, int pagesize, out int pagecount)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = dal.GetSearchDataTable(lcnum, start, end, pageindex, pagesize,out pagecount);
             
            if (dt.Rows.Count>0)
            {
                sb.Append("<table class='distable' id=\"tt\">");
                for (int i = 0; i < dt.Rows.Count; i++)
                {sb.Append("<tr>");
           
                   sb.Append("<td>"+dt.Rows[i][0].ToString()+"</td>");
                    sb.Append("<td>"+dt.Rows[i][1].ToString()+"</td>");
                    sb.Append("<td>"+dt.Rows[i][2].ToString()+"</td>");
                    sb.Append("<td>"+dt.Rows[i][3].ToString()+"</td>");
                    sb.Append("<td>"+dt.Rows[i][4].ToString()+"</td>");
                    sb.Append("<td>"+dt.Rows[i][5].ToString()+"</td>");
                    sb.Append("<td>"+dt.Rows[i][6].ToString()+"</td>");
                   sb.Append("<td>"+ dt.Rows[i][7].ToString()+"</td>");
                    sb.Append("<td>"+dt.Rows[i][8].ToString()+"</td>");
                   sb.Append("<td>"+ dt.Rows[i][9].ToString()+"</td>");
                   sb.Append("<td>"+ dt.Rows[i][10].ToString()+"</td>");
                    sb.Append("<td>"+dt.Rows[i][11].ToString()+"</td>");
                    sb.Append("<td>"+dt.Rows[i][12].ToString()+"</td>");
                   sb.Append("<td>"+ dt.Rows[i][13].ToString()+"</td>");
                   sb.Append("<td>"+ dt.Rows[i][14].ToString()+"</td>");
                   sb.Append("<td>"+ dt.Rows[i][15].ToString()+"</td>");
                   sb.Append("<td>"+ dt.Rows[i][16].ToString()+"</td>");
                  sb.Append("<td>"+  dt.Rows[i][17].ToString()+"</td>");
                   sb.Append("<td>"+ dt.Rows[i][18].ToString()+"</td>");
                   sb.Append("<td>"+ dt.Rows[i][19].ToString()+"</td>");
                   sb.Append("<td>" + dt.Rows[i][20].ToString() + "</td>");
                   sb.Append("<td>" + dt.Rows[i][21].ToString() + "</td>");
                   sb.Append("<td>" + dt.Rows[i][22].ToString() + "</td>");
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

