using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:CriticalData
    /// </summary>
    public partial class CriticalData
    {
        public CriticalData()
        { }
        //#region  BasicMethod

        ///// <summary>
        ///// 得到最大ID
        ///// </summary>
        //public int GetMaxId()
        //{
        //return DbHelperSQL.GetMaxID("id", "CriticalData"); 
        //}

        ///// <summary>
        ///// 是否存在该记录
        ///// </summary>
        //public bool Exists(int id)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select count(1) from CriticalData");
        //    strSql.Append(" where id=@id");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@id", SqlDbType.Int,4)
        //    };
        //    parameters[0].Value = id;

        //    return DbHelperSQL.Exists(strSql.ToString(),parameters);
        //}


        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        //public int Add(Maticsoft.Model.CriticalData model)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("insert into CriticalData(");
        //    strSql.Append("lcNum,generatorId,oilPress,waterTemp,frequency,motorSpeed,voltage,current,motorPower,powerFactor,oilMass,alarmValue,dateTime)");
        //    strSql.Append(" values (");
        //    strSql.Append("@lcNum,@generatorId,@oilPress,@waterTemp,@frequency,@motorSpeed,@voltage,@current,@motorPower,@powerFactor,@oilMass,@alarmValue,@dateTime)");
        //    strSql.Append(";select @@IDENTITY");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@lcNum", SqlDbType.NChar,20),
        //            new SqlParameter("@generatorId", SqlDbType.Int,4),
        //            new SqlParameter("@oilPress", SqlDbType.Float,8),
        //            new SqlParameter("@waterTemp", SqlDbType.Float,8),
        //            new SqlParameter("@frequency", SqlDbType.Float,8),
        //            new SqlParameter("@motorSpeed", SqlDbType.Float,8),
        //            new SqlParameter("@voltage", SqlDbType.Float,8),
        //            new SqlParameter("@current", SqlDbType.Float,8),
        //            new SqlParameter("@motorPower", SqlDbType.Float,8),
        //            new SqlParameter("@powerFactor", SqlDbType.Float,8),
        //            new SqlParameter("@oilMass", SqlDbType.Float,8),
        //            new SqlParameter("@alarmValue", SqlDbType.Int,4),
        //            new SqlParameter("@dateTime", SqlDbType.DateTime)};
        //    parameters[0].Value = model.lcNum;
        //    parameters[1].Value = model.generatorId;
        //    parameters[2].Value = model.oilPress;
        //    parameters[3].Value = model.waterTemp;
        //    parameters[4].Value = model.frequency;
        //    parameters[5].Value = model.motorSpeed;
        //    parameters[6].Value = model.voltage;
        //    parameters[7].Value = model.current;
        //    parameters[8].Value = model.motorPower;
        //    parameters[9].Value = model.powerFactor;
        //    parameters[10].Value = model.oilMass;
        //    parameters[11].Value = model.alarmValue;
        //    parameters[12].Value = model.dateTime;

        //    object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(obj);
        //    }
        //}
        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public bool Update(Maticsoft.Model.CriticalData model)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("update CriticalData set ");
        //    strSql.Append("lcNum=@lcNum,");
        //    strSql.Append("generatorId=@generatorId,");
        //    strSql.Append("oilPress=@oilPress,");
        //    strSql.Append("waterTemp=@waterTemp,");
        //    strSql.Append("frequency=@frequency,");
        //    strSql.Append("motorSpeed=@motorSpeed,");
        //    strSql.Append("voltage=@voltage,");
        //    strSql.Append("current=@current,");
        //    strSql.Append("motorPower=@motorPower,");
        //    strSql.Append("powerFactor=@powerFactor,");
        //    strSql.Append("oilMass=@oilMass,");
        //    strSql.Append("alarmValue=@alarmValue,");
        //    strSql.Append("dateTime=@dateTime");
        //    strSql.Append(" where id=@id");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@lcNum", SqlDbType.NChar,20),
        //            new SqlParameter("@generatorId", SqlDbType.Int,4),
        //            new SqlParameter("@oilPress", SqlDbType.Float,8),
        //            new SqlParameter("@waterTemp", SqlDbType.Float,8),
        //            new SqlParameter("@frequency", SqlDbType.Float,8),
        //            new SqlParameter("@motorSpeed", SqlDbType.Float,8),
        //            new SqlParameter("@voltage", SqlDbType.Float,8),
        //            new SqlParameter("@current", SqlDbType.Float,8),
        //            new SqlParameter("@motorPower", SqlDbType.Float,8),
        //            new SqlParameter("@powerFactor", SqlDbType.Float,8),
        //            new SqlParameter("@oilMass", SqlDbType.Float,8),
        //            new SqlParameter("@alarmValue", SqlDbType.Int,4),
        //            new SqlParameter("@dateTime", SqlDbType.DateTime),
        //            new SqlParameter("@id", SqlDbType.Int,4)};
        //    parameters[0].Value = model.lcNum;
        //    parameters[1].Value = model.generatorId;
        //    parameters[2].Value = model.oilPress;
        //    parameters[3].Value = model.waterTemp;
        //    parameters[4].Value = model.frequency;
        //    parameters[5].Value = model.motorSpeed;
        //    parameters[6].Value = model.voltage;
        //    parameters[7].Value = model.current;
        //    parameters[8].Value = model.motorPower;
        //    parameters[9].Value = model.powerFactor;
        //    parameters[10].Value = model.oilMass;
        //    parameters[11].Value = model.alarmValue;
        //    parameters[12].Value = model.dateTime;
        //    parameters[13].Value = model.id;

        //    int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool Delete(int id)
        //{

        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("delete from CriticalData ");
        //    strSql.Append(" where id=@id");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@id", SqlDbType.Int,4)
        //    };
        //    parameters[0].Value = id;

        //    int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        ///// <summary>
        ///// 批量删除数据
        ///// </summary>
        //public bool DeleteList(string idlist )
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("delete from CriticalData ");
        //    strSql.Append(" where id in ("+idlist + ")  ");
        //    int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public Maticsoft.Model.CriticalData GetModel(int id)
        //{

        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select  top 1 id,lcNum,generatorId,oilPress,waterTemp,frequency,motorSpeed,voltage,current,motorPower,powerFactor,oilMass,alarmValue,dateTime from CriticalData ");
        //    strSql.Append(" where id=@id");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@id", SqlDbType.Int,4)
        //    };
        //    parameters[0].Value = id;

        //    Maticsoft.Model.CriticalData model=new Maticsoft.Model.CriticalData();
        //    DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
        //    if(ds.Tables[0].Rows.Count>0)
        //    {
        //        return DataRowToModel(ds.Tables[0].Rows[0]);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}


        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public Maticsoft.Model.CriticalData DataRowToModel(DataRow row)
        //{
        //    Maticsoft.Model.CriticalData model=new Maticsoft.Model.CriticalData();
        //    if (row != null)
        //    {
        //        if(row["id"]!=null && row["id"].ToString()!="")
        //        {
        //            model.id=int.Parse(row["id"].ToString());
        //        }
        //        if(row["lcNum"]!=null)
        //        {
        //            model.lcNum=row["lcNum"].ToString();
        //        }
        //        if(row["generatorId"]!=null && row["generatorId"].ToString()!="")
        //        {
        //            model.generatorId=int.Parse(row["generatorId"].ToString());
        //        }
        //        if(row["oilPress"]!=null && row["oilPress"].ToString()!="")
        //        {
        //            model.oilPress=decimal.Parse(row["oilPress"].ToString());
        //        }
        //        if(row["waterTemp"]!=null && row["waterTemp"].ToString()!="")
        //        {
        //            model.waterTemp=decimal.Parse(row["waterTemp"].ToString());
        //        }
        //        if(row["frequency"]!=null && row["frequency"].ToString()!="")
        //        {
        //            model.frequency=decimal.Parse(row["frequency"].ToString());
        //        }
        //        if(row["motorSpeed"]!=null && row["motorSpeed"].ToString()!="")
        //        {
        //            model.motorSpeed=decimal.Parse(row["motorSpeed"].ToString());
        //        }
        //        if(row["voltage"]!=null && row["voltage"].ToString()!="")
        //        {
        //            model.voltage=decimal.Parse(row["voltage"].ToString());
        //        }
        //        if(row["current"]!=null && row["current"].ToString()!="")
        //        {
        //            model.current=decimal.Parse(row["current"].ToString());
        //        }
        //        if(row["motorPower"]!=null && row["motorPower"].ToString()!="")
        //        {
        //            model.motorPower=decimal.Parse(row["motorPower"].ToString());
        //        }
        //        if(row["powerFactor"]!=null && row["powerFactor"].ToString()!="")
        //        {
        //            model.powerFactor=decimal.Parse(row["powerFactor"].ToString());
        //        }
        //        if(row["oilMass"]!=null && row["oilMass"].ToString()!="")
        //        {
        //            model.oilMass=decimal.Parse(row["oilMass"].ToString());
        //        }
        //        if(row["alarmValue"]!=null && row["alarmValue"].ToString()!="")
        //        {
        //            model.alarmValue=int.Parse(row["alarmValue"].ToString());
        //        }
        //        if(row["dateTime"]!=null && row["dateTime"].ToString()!="")
        //        {
        //            model.dateTime=DateTime.Parse(row["dateTime"].ToString());
        //        }
        //    }
        //    return model;
        //}

        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public DataSet GetList(string strWhere)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select id,lcNum,generatorId,oilPress,waterTemp,frequency,motorSpeed,voltage,current,motorPower,powerFactor,oilMass,alarmValue,dateTime ");
        //    strSql.Append(" FROM CriticalData ");
        //    if(strWhere.Trim()!="")
        //    {
        //        strSql.Append(" where "+strWhere);
        //    }
        //    return DbHelperSQL.Query(strSql.ToString());
        //}

        ///// <summary>
        ///// 获得前几行数据
        ///// </summary>
        //public DataSet GetList(int Top,string strWhere,string filedOrder)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select ");
        //    if(Top>0)
        //    {
        //        strSql.Append(" top "+Top.ToString());
        //    }
        //    strSql.Append(" id,lcNum,generatorId,oilPress,waterTemp,frequency,motorSpeed,voltage,current,motorPower,powerFactor,oilMass,alarmValue,dateTime ");
        //    strSql.Append(" FROM CriticalData ");
        //    if(strWhere.Trim()!="")
        //    {
        //        strSql.Append(" where "+strWhere);
        //    }
        //    strSql.Append(" order by " + filedOrder);
        //    return DbHelperSQL.Query(strSql.ToString());
        //}

        ///// <summary>
        ///// 获取记录总数
        ///// </summary>
        //public int GetRecordCount(string strWhere)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select count(1) FROM CriticalData ");
        //    if(strWhere.Trim()!="")
        //    {
        //        strSql.Append(" where "+strWhere);
        //    }
        //    object obj = DbHelperSQL.GetSingle(strSql.ToString());
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(obj);
        //    }
        //}
        ///// <summary>
        ///// 分页获取数据列表
        ///// </summary>
        //public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("SELECT * FROM ( ");
        //    strSql.Append(" SELECT ROW_NUMBER() OVER (");
        //    if (!string.IsNullOrEmpty(orderby.Trim()))
        //    {
        //        strSql.Append("order by T." + orderby );
        //    }
        //    else
        //    {
        //        strSql.Append("order by T.id desc");
        //    }
        //    strSql.Append(")AS Row, T.*  from CriticalData T ");
        //    if (!string.IsNullOrEmpty(strWhere.Trim()))
        //    {
        //        strSql.Append(" WHERE " + strWhere);
        //    }
        //    strSql.Append(" ) TT");
        //    strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
        //    return DbHelperSQL.Query(strSql.ToString());
        //}

        ///*
        ///// <summary>
        ///// 分页获取数据列表
        ///// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@tblName", SqlDbType.VarChar, 255),
        //            new SqlParameter("@fldName", SqlDbType.VarChar, 255),
        //            new SqlParameter("@PageSize", SqlDbType.Int),
        //            new SqlParameter("@PageIndex", SqlDbType.Int),
        //            new SqlParameter("@IsReCount", SqlDbType.Bit),
        //            new SqlParameter("@OrderType", SqlDbType.Bit),
        //            new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
        //            };
        //    parameters[0].Value = "CriticalData";
        //    parameters[1].Value = "id";
        //    parameters[2].Value = PageSize;
        //    parameters[3].Value = PageIndex;
        //    parameters[4].Value = 0;
        //    parameters[5].Value = 0;
        //    parameters[6].Value = strWhere;	
        //    return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        //}*/

        //#endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 根据条件查询关键数据
        /// </summary>
        /// <param name="lcnum"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="pagecount"></param>
        /// <returns></returns>
        public DataTable GetSearchDataTable(string lcnum, string start, string end, int pageindex, int pagesize, out int pagecount)
        {
            string sql = "select top (@pagesize) * from CriticalData where id not in (select top (@pagespan) id from CriticalData where lcNum=@lcnum and dateTime between @start and @end order by id desc) and lcNum=@lcnum and dateTime between @start and @end order by id desc";
            string sql2 = "select count(*) from CriticalData where lcNum=@lcnum and dateTime between @start and @end";
            SqlParameter[] parms = new SqlParameter[] { new SqlParameter("@lcnum", SqlDbType.NVarChar), new SqlParameter("@end", SqlDbType.NVarChar), new SqlParameter("@start", SqlDbType.NVarChar), new SqlParameter("@pagesize", SqlDbType.Int), new SqlParameter("@pagespan", SqlDbType.Int) };
            parms[0].Value = lcnum;
            parms[1].Value = end;
            parms[2].Value = start;
            parms[3].Value = pagesize;
            parms[4].Value = pagesize * (pageindex - 1);
            SqlParameter[] parms1 = new SqlParameter[] { new SqlParameter("@lcnum", SqlDbType.NVarChar), new SqlParameter("@end", SqlDbType.NVarChar), new SqlParameter("@start", SqlDbType.NVarChar) };
            parms1[0].Value = lcnum;
            parms1[1].Value = end;
            parms1[2].Value = start;
            int a = (int)DBUtility.SqlHelper1.ExecuteSclare(sql2, CommandType.Text, parms1);
            pagecount = a / pagesize + (a % pagesize > 0 ? 1 : 0);
            return DBUtility.SqlHelper1.ExecuteTable(sql, CommandType.Text, parms);
        }
        /// <summary>
        /// 关键数据入库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddCritialData(Model.CriticalData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CriticalData(");
            strSql.Append("lcNum,generatorId,oilPress,waterTemp,frequency,motorSpeed,voltage,[current],motorPower,powerFactor,oilMass,alarmValue,dateTime)");
            strSql.Append(" values (");
            strSql.Append("@lcNum,@generatorId,@oilPress,@waterTemp,@frequency,@motorSpeed,@voltage,@current,@motorPower,@powerFactor,@oilMass,@alarmValue,@dateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@lcNum", SqlDbType.NChar,20),
                        new SqlParameter("@generatorId", SqlDbType.Int,4),
                        new SqlParameter("@oilPress", SqlDbType.Float,8),
                        new SqlParameter("@waterTemp", SqlDbType.Float,8),
                        new SqlParameter("@frequency", SqlDbType.Float,8),
                        new SqlParameter("@motorSpeed", SqlDbType.Float,8),
                        new SqlParameter("@voltage", SqlDbType.Float,8),
                        new SqlParameter("@current", SqlDbType.Float,8),
                        new SqlParameter("@motorPower", SqlDbType.Float,8),
                        new SqlParameter("@powerFactor", SqlDbType.Float,8),
                        new SqlParameter("@oilMass", SqlDbType.Float,8),
                        new SqlParameter("@alarmValue", SqlDbType.Int,4),
                        new SqlParameter("@dateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.LcNum;
            parameters[1].Value = model.GeneratorId;
            parameters[2].Value = model.OilPress;
            parameters[3].Value = model.WaterTemp;
            parameters[4].Value = model.Frequency;
            parameters[5].Value = model.MotorSpeed;
            parameters[6].Value = model.Voltage;
            parameters[7].Value = model._Current;
            parameters[8].Value = model.MotorPower;
            parameters[9].Value = model.PowerFactor;
            parameters[10].Value = model.OilMass;
            parameters[11].Value = model.AlarmValue;
            parameters[12].Value = model.Date;

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
            parms[0].Value = "CriticalData";
            parms[1].Value = "";
            parms[2].Value = "";
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

