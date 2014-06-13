using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using System.Collections.Generic;
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:InspectionRecords
    /// </summary>
    public partial class InspectionRecords
    {
        public InspectionRecords()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "InspectionRecords");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from InspectionRecords");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.InspectionRecords model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into InspectionRecords(");
            strSql.Append("lcNum,status,planTime,recordTime,worker,remarks)");
            strSql.Append(" values (");
            strSql.Append("@lcNum,@status,@planTime,@recordTime,@worker,@remarks)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@lcNum", SqlDbType.NChar,20),
					new SqlParameter("@status", SqlDbType.NChar,10),
					new SqlParameter("@planTime", SqlDbType.DateTime),
					new SqlParameter("@recordTime", SqlDbType.DateTime),
					new SqlParameter("@worker", SqlDbType.NChar,20),
					new SqlParameter("@remarks", SqlDbType.NChar,30)};
            parameters[0].Value = model.lcNum;
            parameters[1].Value = model.status;
            parameters[2].Value = model.planTime;
            parameters[3].Value = model.recordTime;
            parameters[4].Value = model.worker;
            parameters[5].Value = model.remarks;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Maticsoft.Model.InspectionRecords model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update InspectionRecords set ");
            strSql.Append("lcNum=@lcNum,");
            strSql.Append("status=@status,");
            strSql.Append("planTime=@planTime,");
            strSql.Append("recordTime=@recordTime,");
            strSql.Append("worker=@worker,");
            strSql.Append("remarks=@remarks");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@lcNum", SqlDbType.NChar,20),
					new SqlParameter("@status", SqlDbType.NChar,10),
					new SqlParameter("@planTime", SqlDbType.DateTime),
					new SqlParameter("@recordTime", SqlDbType.DateTime),
					new SqlParameter("@worker", SqlDbType.NChar,20),
					new SqlParameter("@remarks", SqlDbType.NChar,30),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.lcNum;
            parameters[1].Value = model.status;
            parameters[2].Value = model.planTime;
            parameters[3].Value = model.recordTime;
            parameters[4].Value = model.worker;
            parameters[5].Value = model.remarks;
            parameters[6].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from InspectionRecords ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from InspectionRecords ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Maticsoft.Model.InspectionRecords GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,lcNum,status,planTime,recordTime,worker,remarks from InspectionRecords ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Maticsoft.Model.InspectionRecords model = new Maticsoft.Model.InspectionRecords();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public Maticsoft.Model.InspectionRecords DataRowToModel(DataRow row)
        {
            Maticsoft.Model.InspectionRecords model = new Maticsoft.Model.InspectionRecords();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["lcNum"] != null)
                {
                    model.lcNum = row["lcNum"].ToString();
                }
                if (row["status"] != null)
                {
                    model.status = row["status"].ToString();
                }
                if (row["planTime"] != null && row["planTime"].ToString() != "")
                {
                    model.planTime = DateTime.Parse(row["planTime"].ToString());
                }
                if (row["recordTime"] != null && row["recordTime"].ToString() != "")
                {
                    model.recordTime = DateTime.Parse(row["recordTime"].ToString());
                }
                if (row["worker"] != null)
                {
                    model.worker = row["worker"].ToString();
                }
                if (row["remarks"] != null)
                {
                    model.remarks = row["remarks"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,lcNum,status,planTime,recordTime,worker,remarks ");
            strSql.Append(" FROM InspectionRecords ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,lcNum,status,planTime,recordTime,worker,remarks ");
            strSql.Append(" FROM InspectionRecords ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM InspectionRecords ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from InspectionRecords T ");
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
            parameters[0].Value = "InspectionRecords";
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

        /// <summary>
        /// 查询所有车号巡检记录 分页
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="pagecount"></param>
        /// <returns></returns>
        public DataTable GetDataByPage(int page, int pagesize, out int pagecount)
        {
            string sql = "SELECT TOP " + pagesize.ToString() + "* FROM InspectionRecords WHERE id NOT IN  (SELECT TOP " + (page - 1).ToString() + " id  FROM InspectionRecords  ORDER BY id desc) ORDER BY ID desc";
            string sql1 = "select count(*) from InspectionRecords";
            SqlParameter[] parms = new SqlParameter[] { new SqlParameter("@page", SqlDbType.Int), new SqlParameter("@pagesize", SqlDbType.Int) };
            parms[0].Value = page;
            parms[1].Value = pagesize;

            int cout = (int)Maticsoft.DBUtility.SqlHelper1.ExecuteSclare(sql1, CommandType.Text);
            pagecount = cout % pagesize > 0 ? cout / pagesize : cout / pagesize + 1;
            return Maticsoft.DBUtility.SqlHelper1.ExecuteTable(sql, CommandType.Text, parms);
        }
        /// <summary>
        /// 根据车号时间段查询巡检信息
        /// </summary>
        /// <param name="lcnumber">车号</param>
        /// <param name="starttime">开始时间</param>
        /// <param name="endtime"></param>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="pagecount"></param>
        /// <returns></returns>
        public DataTable GetXJDataByPage(string lcnumber, string starttime, string endtime, int page, int pagesize, out int pagecount)
        {

            string sql = "SELECT TOP " + pagesize.ToString() + "* FROM InspectionRecords WHERE id NOT IN  (SELECT TOP " + ((page - 1) * 20).ToString() + " id  FROM InspectionRecords where lcNum='" + lcnumber + "' and planTime between '" + starttime + "' and '" + endtime + "'  ORDER BY id desc) and lcNum='" + lcnumber + "' and planTime between '" + starttime + "' and '" + endtime + "' ORDER BY ID desc";
            string sql1 = "select count(*) from InspectionRecords where lcNum='" + lcnumber + "' and planTime between '" + starttime + "' and '" + endtime + "'";
            SqlParameter[] parms = new SqlParameter[] { new SqlParameter("@lcnumber", SqlDbType.NVarChar), new SqlParameter("@starttime", SqlDbType.NVarChar), new SqlParameter("@endtime", SqlDbType.NVarChar), new SqlParameter("@page", SqlDbType.Int), new SqlParameter("@pagesize", SqlDbType.Int) };
            parms[0].Value = lcnumber;
            parms[1].Value = starttime;
            parms[2].Value = endtime;
            parms[3].Value = page;
            parms[4].Value = pagesize;
            int cout = (int)Maticsoft.DBUtility.SqlHelper1.ExecuteSclare(sql1, CommandType.Text);
            pagecount = cout % pagesize > 0 ? cout / pagesize : cout / pagesize + 1;
            return Maticsoft.DBUtility.SqlHelper1.ExecuteTable(sql, CommandType.Text, parms);
        }
        public Maticsoft.Model.XjAnalysisModel GetXjAnalysisModel(string lcnumber, string startime, string endtime)
        {
            string sqlalltimes = "select count(*) from InspectionRecords where planTime between @start and @end";
            string sqlchecktimes = "select count(*) from InspectionRecords where status='已检' and planTime  between @start and @end";
            string sqlchecklatetimes = "select count(*) from InspectionRecords where status='晚检' and planTime  between @start and @end";

            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@lcnmuber", SqlDbType.NVarChar), new SqlParameter("@start", SqlDbType.NVarChar), new SqlParameter("@end", SqlDbType.NVarChar) };
            param[0].Value = lcnumber;
            param[1].Value = startime;
            param[2].Value = endtime;
            SqlParameter[] param1 = new SqlParameter[] { new SqlParameter("@lcnmuber", SqlDbType.NVarChar), new SqlParameter("@start", SqlDbType.NVarChar), new SqlParameter("@end", SqlDbType.NVarChar) };
            param1[0].Value = lcnumber;
            param1[1].Value = startime;
            param1[2].Value = endtime;
            SqlParameter[] param2 = new SqlParameter[] { new SqlParameter("@lcnmuber", SqlDbType.NVarChar), new SqlParameter("@start", SqlDbType.NVarChar), new SqlParameter("@end", SqlDbType.NVarChar) };
            param2[0].Value = lcnumber;
            param2[1].Value = startime;
            param2[2].Value = endtime;
            Maticsoft.Model.XjAnalysisModel xj = new Model.XjAnalysisModel();

            xj.lcNumber = lcnumber;
            xj.AllCheckTime = (int)Maticsoft.DBUtility.SqlHelper1.ExecuteSclare(sqlalltimes, CommandType.Text, param);
            xj.CheckTimes = (int)Maticsoft.DBUtility.SqlHelper1.ExecuteSclare(sqlchecktimes, CommandType.Text, param1);
            xj.CheckLateTimes = (int)Maticsoft.DBUtility.SqlHelper1.ExecuteSclare(sqlchecklatetimes, CommandType.Text, param2);
            xj.CheckFrequency = xj.CheckTimes * 1.0 / xj.AllCheckTime;
            xj.CheckLateFrequency = xj.CheckLateTimes * 1.0 / xj.AllCheckTime;
            return xj;
        }
        /// <summary>
        /// 存储过程分页
        /// </summary>
        /// <param name="tablename">查询表名</param>
        /// <param name="kewword">要查询的关键字段用‘，’隔开</param>
        /// <param name="orderkey">排序依据字段</param>
        /// <param name="pagesize"></param>
        /// <param name="pageindex"></param>
        /// <param name="OrReturnCoutn">大于0返回count,这里不需要</param>
        /// <param name="orderType">大于0升序等于0降序</param>
        /// <param name="strwhere">查询条件 不加where</param>
        /// <returns></returns>
        public DataTable GetPartPageByProcedure(string tablename, string kewword, string orderkey, int pagesize, int pageindex, int OrReturnCoutn, int orderType, string strwhere)
        {
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@tblName", SqlDbType.NVarChar), 
                new SqlParameter("@strGetFields", SqlDbType.NVarChar),
                new SqlParameter("@fldName", SqlDbType.NVarChar),
                new SqlParameter("@PageSize", SqlDbType.Int),
                new SqlParameter("@PageIndex", SqlDbType.Int), 
                new SqlParameter("@doCount", SqlDbType.Int), 
                new SqlParameter("@OrderType", SqlDbType.Int), 
                new SqlParameter("@strWhere", SqlDbType.NVarChar)};
            parms[0].Value = tablename;
            parms[1].Value = kewword;
            parms[2].Value = orderkey;
            parms[3].Value = pagesize;
            parms[4].Value = pageindex;
            parms[5].Value = OrReturnCoutn;
            parms[6].Value = orderType;
            parms[7].Value = strwhere;
            return Maticsoft.DBUtility.SqlHelper1.ExecuteTable("pagination", CommandType.StoredProcedure, parms);
        }

        /// <summary>
        /// 按查询查询条数
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public int GetPageCountByProcedure(string strwhere)
        {
            SqlParameter[] parms = new SqlParameter[] {
                               new SqlParameter("@tblName", SqlDbType.NVarChar), 
                new SqlParameter("@strGetFields", SqlDbType.NVarChar),
                new SqlParameter("@fldName", SqlDbType.NVarChar),
                new SqlParameter("@PageSize", SqlDbType.Int),
                new SqlParameter("@PageIndex", SqlDbType.Int), 
                new SqlParameter("@doCount", SqlDbType.Int), 
                new SqlParameter("@OrderType", SqlDbType.Int), 
                new SqlParameter("@strWhere", SqlDbType.NVarChar)};
            parms[0].Value = "InspectionRecords";
            parms[1].Value = "id";
            parms[2].Value = "remarks";
            parms[3].Value = 20;
            parms[4].Value = 1;
            parms[5].Value = 1;
            parms[6].Value = 0;
            parms[7].Value = strwhere;
            return (int)Maticsoft.DBUtility.SqlHelper1.ExecuteSclare("pagination", CommandType.StoredProcedure, parms);

        }
        #endregion  ExtensionMethod
    }
}

