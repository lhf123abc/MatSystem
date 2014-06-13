﻿/**  版本信息模板在安装目录下，可自行修改。
* trainInfo.cs
*
* 功 能： N/A
* 类 名： trainInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/5/7 8:46:41   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:trainInfo
    /// </summary>
    public partial class trainInfo
    {
        public trainInfo()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string seriaNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from trainInfo");
            strSql.Append(" where seriaNum=@seriaNum ");
            SqlParameter[] parameters = {
					new SqlParameter("@seriaNum", SqlDbType.NChar,10)			};
            parameters[0].Value = seriaNum;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.trainInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into trainInfo(");
            strSql.Append("seriaNum,train,route,dhip)");
            strSql.Append(" values (");
            strSql.Append("@seriaNum,@train,@route,@dhip)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@seriaNum", SqlDbType.NChar,10),
					new SqlParameter("@train", SqlDbType.NChar,10),
					new SqlParameter("@route", SqlDbType.NVarChar,50),
					new SqlParameter("@dhip", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.seriaNum;
            parameters[1].Value = model.train;
            parameters[2].Value = model.route;
            parameters[3].Value = model.dhip;

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
        public bool Update(Maticsoft.Model.trainInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update trainInfo set ");
            strSql.Append("train=@train,");
            strSql.Append("route=@route,");
            strSql.Append("dhip=@dhip,");
            strSql.Append("seriaNum=@seriaNum");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@train", SqlDbType.NChar,10),
					new SqlParameter("@route", SqlDbType.NVarChar,50),
					new SqlParameter("@dhip", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@seriaNum", SqlDbType.NChar,10)};
            parameters[0].Value = model.train;
            parameters[1].Value = model.route;
            parameters[2].Value = model.dhip;
            parameters[3].Value = model.id;
            parameters[4].Value = model.seriaNum;

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
            strSql.Append("delete from trainInfo ");
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string seriaNum)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from trainInfo ");
            strSql.Append(" where seriaNum=@seriaNum ");
            SqlParameter[] parameters = {
					new SqlParameter("@seriaNum", SqlDbType.NChar,10)			};
            parameters[0].Value = seriaNum;

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
            strSql.Append("delete from trainInfo ");
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
        public Maticsoft.Model.trainInfo GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,seriaNum,train,route,dhip from trainInfo ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Maticsoft.Model.trainInfo model = new Maticsoft.Model.trainInfo();
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
        public Maticsoft.Model.trainInfo DataRowToModel(DataRow row)
        {
            Maticsoft.Model.trainInfo model = new Maticsoft.Model.trainInfo();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["seriaNum"] != null)
                {
                    model.seriaNum = row["seriaNum"].ToString();
                }
                if (row["train"] != null)
                {
                    model.train = row["train"].ToString();
                }
                if (row["route"] != null)
                {
                    model.route = row["route"].ToString();
                }
                if (row["dhip"] != null)
                {
                    model.dhip = row["dhip"].ToString();
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
            strSql.Append("select id,seriaNum,train,route,dhip ");
            strSql.Append(" FROM trainInfo ");
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
            strSql.Append(" id,seriaNum,train,route,dhip ");
            strSql.Append(" FROM trainInfo ");
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
            strSql.Append("select count(1) FROM trainInfo ");
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
            strSql.Append(")AS Row, T.*  from trainInfo T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }


        ////<summary>
        ////分页获取数据列表
        ////</summary>
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
            parameters[0].Value = "trainInfo";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 获取车号list
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public List<string> GetLcNumberList(string keyword,string strwhere)
        {
            List<string> list = new List<string>();
            string sql="select * from trainInfo "+ (strwhere==""?"":" where @strwhere");
            SqlParameter[] parms=new  SqlParameter[]{ new SqlParameter("@strwhere",SqlDbType.NVarChar)};
            
            
            parms[0].Value=strwhere;
            SqlDataReader dr= DBUtility.SqlHelper1.ExecuteReader(sql,CommandType.Text,parms);

                while (dr.Read())
                {
                    list.Add(dr[keyword].ToString().Trim());
                }

            dr.Close();
            return list;
        }
        #endregion  ExtensionMethod
    }
}

