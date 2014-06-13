using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tab_systemrecord
	/// </summary>
	public partial class tab_systemrecord
	{
		public tab_systemrecord()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.tab_systemrecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tab_systemrecord(");
			strSql.Append("id,lcNumber,systemstarttime,systemshutdowntime)");
			strSql.Append(" values (");
			strSql.Append("@id,@lcNumber,@systemstarttime,@systemshutdowntime)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@lcNumber", SqlDbType.NVarChar,20),
					new SqlParameter("@systemstarttime", SqlDbType.DateTime),
					new SqlParameter("@systemshutdowntime", SqlDbType.DateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.lcNumber;
			parameters[2].Value = model.systemstarttime;
			parameters[3].Value = model.systemshutdowntime;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.tab_systemrecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tab_systemrecord set ");
			strSql.Append("id=@id,");
			strSql.Append("lcNumber=@lcNumber,");
			strSql.Append("systemstarttime=@systemstarttime,");
			strSql.Append("systemshutdowntime=@systemshutdowntime");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@lcNumber", SqlDbType.NVarChar,20),
					new SqlParameter("@systemstarttime", SqlDbType.DateTime),
					new SqlParameter("@systemshutdowntime", SqlDbType.DateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.lcNumber;
			parameters[2].Value = model.systemstarttime;
			parameters[3].Value = model.systemshutdowntime;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tab_systemrecord ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.tab_systemrecord GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,lcNumber,systemstarttime,systemshutdowntime from tab_systemrecord ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Maticsoft.Model.tab_systemrecord model=new Maticsoft.Model.tab_systemrecord();
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
		public Maticsoft.Model.tab_systemrecord DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tab_systemrecord model=new Maticsoft.Model.tab_systemrecord();
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
				if(row["systemstarttime"]!=null && row["systemstarttime"].ToString()!="")
				{
					model.systemstarttime=DateTime.Parse(row["systemstarttime"].ToString());
				}
				if(row["systemshutdowntime"]!=null && row["systemshutdowntime"].ToString()!="")
				{
					model.systemshutdowntime=DateTime.Parse(row["systemshutdowntime"].ToString());
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
			strSql.Append("select id,lcNumber,systemstarttime,systemshutdowntime ");
			strSql.Append(" FROM tab_systemrecord ");
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
			strSql.Append(" id,lcNumber,systemstarttime,systemshutdowntime ");
			strSql.Append(" FROM tab_systemrecord ");
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
			strSql.Append("select count(1) FROM tab_systemrecord ");
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
			strSql.Append(")AS Row, T.*  from tab_systemrecord T ");
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
			parameters[0].Value = "tab_systemrecord";
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

