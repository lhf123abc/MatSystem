using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tab_user
	/// </summary>
	public partial class tab_user
	{
		public tab_user()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "tab_user"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tab_user");
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
		public int Add(Maticsoft.Model.tab_user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tab_user(");
			strSql.Append("username,nicname,password,quanxian,registertime)");
			strSql.Append(" values (");
			strSql.Append("@username,@nicname,@password,@quanxian,@registertime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@nicname", SqlDbType.NVarChar,50),
					new SqlParameter("@password", SqlDbType.NVarChar,100),
					new SqlParameter("@quanxian", SqlDbType.NVarChar,50),
					new SqlParameter("@registertime", SqlDbType.DateTime)};
			parameters[0].Value = model.username;
			parameters[1].Value = model.nicname;
			parameters[2].Value = model.password;
			parameters[3].Value = model.quanxian;
			parameters[4].Value = model.registertime;

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
		public bool Update(Maticsoft.Model.tab_user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tab_user set ");
			strSql.Append("username=@username,");
			strSql.Append("nicname=@nicname,");
			strSql.Append("password=@password,");
			strSql.Append("quanxian=@quanxian,");
			strSql.Append("registertime=@registertime");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@nicname", SqlDbType.NVarChar,50),
					new SqlParameter("@password", SqlDbType.NVarChar,100),
					new SqlParameter("@quanxian", SqlDbType.NVarChar,50),
					new SqlParameter("@registertime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.username;
			parameters[1].Value = model.nicname;
			parameters[2].Value = model.password;
			parameters[3].Value = model.quanxian;
			parameters[4].Value = model.registertime;
			parameters[5].Value = model.id;

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
			strSql.Append("delete from tab_user ");
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
			strSql.Append("delete from tab_user ");
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
		public Maticsoft.Model.tab_user GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,username,nicname,password,quanxian,registertime from tab_user ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Maticsoft.Model.tab_user model=new Maticsoft.Model.tab_user();
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
		public Maticsoft.Model.tab_user DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tab_user model=new Maticsoft.Model.tab_user();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["username"]!=null)
				{
					model.username=row["username"].ToString();
				}
				if(row["nicname"]!=null)
				{
					model.nicname=row["nicname"].ToString();
				}
				if(row["password"]!=null)
				{
					model.password=row["password"].ToString();
				}
				if(row["quanxian"]!=null)
				{
					model.quanxian=row["quanxian"].ToString();
				}
				if(row["registertime"]!=null && row["registertime"].ToString()!="")
				{
					model.registertime=DateTime.Parse(row["registertime"].ToString());
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
			strSql.Append("select id,username,nicname,password,quanxian,registertime ");
			strSql.Append(" FROM tab_user ");
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
			strSql.Append(" id,username,nicname,password,quanxian,registertime ");
			strSql.Append(" FROM tab_user ");
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
			strSql.Append("select count(1) FROM tab_user ");
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
			strSql.Append(")AS Row, T.*  from tab_user T ");
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
			parameters[0].Value = "tab_user";
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

