using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL
{
    public class _XJdal
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model._XJmodel model)
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
            parameters[0].Value = model.lcNumber;
            parameters[1].Value = model.getRecord;
            parameters[2].Value = model.getBjtime;
            parameters[3].Value = model.getRecordTime;
            parameters[4].Value = model.getWorker;
            parameters[5].Value = model.getContent;

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
    }
}
