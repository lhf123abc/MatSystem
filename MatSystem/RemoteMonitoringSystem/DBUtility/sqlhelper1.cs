using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Maticsoft.DBUtility
{
    public static class SqlHelper1
    {
        static readonly string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
       //public static readonly string lcNumber = ConfigurationManager.AppSettings["lcNumber"].ToString();
       //public static readonly string checi = ConfigurationManager.AppSettings["checi"].ToString();

        public static int ExequteNonQuery(string sql, System.Data.CommandType type, params SqlParameter[] parms)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = type;
                
                if (parms != null)
                {
                    cmd.Parameters.AddRange(parms);
                }
                conn.Open();
                int r = cmd.ExecuteNonQuery();
                return r;
            }
        }
        public static object ExecuteSclare(string sql, System.Data.CommandType type, params SqlParameter[] parms)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = type;
                    if (parms != null)
                    {
                        cmd.Parameters.AddRange(parms);
                    }
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
        public static SqlDataReader ExecuteReader(string sql, System.Data.CommandType type, params SqlParameter[] parms)
        {
            SqlConnection conn = new SqlConnection(constr);
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = type;
                    if (parms != null)
                     {
                        cmd.Parameters.AddRange(parms);
                     }
                    conn.Open();
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
            catch
            {
                if (conn != null)
                {
                    conn.Close();
                }
                throw;
            }
        }
        public static DataTable ExecuteTable(string sql, System.Data.CommandType type, params SqlParameter[] parms)
        {
            try
            {

                using (SqlDataAdapter ada = new SqlDataAdapter(sql, constr))
                {
                    if (parms != null)
                    {
                        ada.SelectCommand.CommandType= type;
                        ada.SelectCommand.Parameters.AddRange(parms);
                    }
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    return dt;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
