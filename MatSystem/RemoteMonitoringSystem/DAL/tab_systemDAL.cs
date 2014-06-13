using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tab_system
	/// </summary>
	public partial class tab_system
	{
		public tab_system()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tab_system"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tab_system");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.tab_system model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tab_system(");
			strSql.Append("lcNumber,startplace,endplace,dangbanStartTime,dangbanEndTime,baojingjiange,xunjianjiange,xjName,Bcontent,recordtime,checi)");
			strSql.Append(" values (");
			strSql.Append("@lcNumber,@startplace,@endplace,@dangbanStartTime,@dangbanEndTime,@baojingjiange,@xunjianjiange,@xjName,@Bcontent,@recordtime,@checi)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@lcNumber", SqlDbType.NVarChar,40),
					new SqlParameter("@startplace", SqlDbType.NVarChar,50),
					new SqlParameter("@endplace", SqlDbType.NVarChar,50),
					new SqlParameter("@dangbanStartTime", SqlDbType.DateTime),
					new SqlParameter("@dangbanEndTime", SqlDbType.DateTime),
					new SqlParameter("@baojingjiange", SqlDbType.NVarChar,50),
					new SqlParameter("@xunjianjiange", SqlDbType.NVarChar,50),
					new SqlParameter("@xjName", SqlDbType.NVarChar,50),
					new SqlParameter("@Bcontent", SqlDbType.NVarChar,450),
					new SqlParameter("@recordtime", SqlDbType.DateTime),
					new SqlParameter("@checi", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.lcNumber;
			parameters[1].Value = model.startplace;
			parameters[2].Value = model.endplace;
			parameters[3].Value = model.dangbanStartTime;
			parameters[4].Value = model.dangbanEndTime;
			parameters[5].Value = model.baojingjiange;
			parameters[6].Value = model.xunjianjiange;
			parameters[7].Value = model.xjName;
			parameters[8].Value = model.Bcontent;
			parameters[9].Value = model.recordtime;
			parameters[10].Value = model.checi;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.tab_system model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tab_system set ");
			strSql.Append("lcNumber=@lcNumber,");
			strSql.Append("startplace=@startplace,");
			strSql.Append("endplace=@endplace,");
			strSql.Append("dangbanStartTime=@dangbanStartTime,");
			strSql.Append("dangbanEndTime=@dangbanEndTime,");
			strSql.Append("baojingjiange=@baojingjiange,");
			strSql.Append("xunjianjiange=@xunjianjiange,");
			strSql.Append("xjName=@xjName,");
			strSql.Append("Bcontent=@Bcontent,");
			strSql.Append("recordtime=@recordtime,");
			strSql.Append("checi=@checi");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@lcNumber", SqlDbType.NVarChar,40),
					new SqlParameter("@startplace", SqlDbType.NVarChar,50),
					new SqlParameter("@endplace", SqlDbType.NVarChar,50),
					new SqlParameter("@dangbanStartTime", SqlDbType.DateTime),
					new SqlParameter("@dangbanEndTime", SqlDbType.DateTime),
					new SqlParameter("@baojingjiange", SqlDbType.NVarChar,50),
					new SqlParameter("@xunjianjiange", SqlDbType.NVarChar,50),
					new SqlParameter("@xjName", SqlDbType.NVarChar,50),
					new SqlParameter("@Bcontent", SqlDbType.NVarChar,450),
					new SqlParameter("@recordtime", SqlDbType.DateTime),
					new SqlParameter("@checi", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.lcNumber;
			parameters[1].Value = model.startplace;
			parameters[2].Value = model.endplace;
			parameters[3].Value = model.dangbanStartTime;
			parameters[4].Value = model.dangbanEndTime;
			parameters[5].Value = model.baojingjiange;
			parameters[6].Value = model.xunjianjiange;
			parameters[7].Value = model.xjName;
			parameters[8].Value = model.Bcontent;
			parameters[9].Value = model.recordtime;
			parameters[10].Value = model.checi;
			parameters[11].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tab_system ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tab_system ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.tab_system GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,lcNumber,startplace,endplace,dangbanStartTime,dangbanEndTime,baojingjiange,xunjianjiange,xjName,Bcontent,recordtime,checi from tab_system ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Maticsoft.Model.tab_system model=new Maticsoft.Model.tab_system();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.tab_system DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tab_system model=new Maticsoft.Model.tab_system();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["lcNumber"]!=null)
				{
					model.lcNumber=row["lcNumber"].ToString();
				}
				if(row["startplace"]!=null)
				{
					model.startplace=row["startplace"].ToString();
				}
				if(row["endplace"]!=null)
				{
					model.endplace=row["endplace"].ToString();
				}
				if(row["dangbanStartTime"]!=null && row["dangbanStartTime"].ToString()!="")
				{
					model.dangbanStartTime=DateTime.Parse(row["dangbanStartTime"].ToString());
				}
				if(row["dangbanEndTime"]!=null && row["dangbanEndTime"].ToString()!="")
				{
					model.dangbanEndTime=DateTime.Parse(row["dangbanEndTime"].ToString());
				}
				if(row["baojingjiange"]!=null)
				{
					model.baojingjiange=row["baojingjiange"].ToString();
				}
				if(row["xunjianjiange"]!=null)
				{
					model.xunjianjiange=row["xunjianjiange"].ToString();
				}
				if(row["xjName"]!=null)
				{
					model.xjName=row["xjName"].ToString();
				}
				if(row["Bcontent"]!=null)
				{
					model.Bcontent=row["Bcontent"].ToString();
				}
				if(row["recordtime"]!=null && row["recordtime"].ToString()!="")
				{
					model.recordtime=DateTime.Parse(row["recordtime"].ToString());
				}
				if(row["checi"]!=null)
				{
					model.checi=row["checi"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,lcNumber,startplace,endplace,dangbanStartTime,dangbanEndTime,baojingjiange,xunjianjiange,xjName,Bcontent,recordtime,checi ");
			strSql.Append(" FROM tab_system ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,lcNumber,startplace,endplace,dangbanStartTime,dangbanEndTime,baojingjiange,xunjianjiange,xjName,Bcontent,recordtime,checi ");
			strSql.Append(" FROM tab_system ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tab_system ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from tab_system T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tab_system";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

