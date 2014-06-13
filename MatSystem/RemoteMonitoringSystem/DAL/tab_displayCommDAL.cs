using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tab_displayComm
	/// </summary>
	public partial class tab_displayComm
	{
		public tab_displayComm()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "tab_displayComm"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tab_displayComm");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.tab_displayComm model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tab_displayComm(");
			strSql.Append("lcNumber,djNumber,oil_mass,fire_alarm,up_oil_place,up_water_place,battery_voltage,alarm,alarm_voice,oil_press,water_temp,frequency,motor_speed,voltage,current,motor_power,power_factor,oil_leak,OKAlarm,NOAlarm,NCAlarm,recordtime)");
			strSql.Append(" values (");
			strSql.Append("@lcNumber,@djNumber,@oil_mass,@fire_alarm,@up_oil_place,@up_water_place,@battery_voltage,@alarm,@alarm_voice,@oil_press,@water_temp,@frequency,@motor_speed,@voltage,@current,@motor_power,@power_factor,@oil_leak,@OKAlarm,@NOAlarm,@NCAlarm,@recordtime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@lcNumber", SqlDbType.NChar,10),
					new SqlParameter("@djNumber", SqlDbType.Int,4),
					new SqlParameter("@oil_mass", SqlDbType.NChar,10),
					new SqlParameter("@fire_alarm", SqlDbType.Bit,1),
					new SqlParameter("@up_oil_place", SqlDbType.Bit,1),
					new SqlParameter("@up_water_place", SqlDbType.Bit,1),
					new SqlParameter("@battery_voltage", SqlDbType.Bit,1),
					new SqlParameter("@alarm", SqlDbType.Bit,1),
					new SqlParameter("@alarm_voice", SqlDbType.Bit,1),
					new SqlParameter("@oil_press", SqlDbType.NChar,10),
					new SqlParameter("@water_temp", SqlDbType.NChar,10),
					new SqlParameter("@frequency", SqlDbType.NChar,10),
					new SqlParameter("@motor_speed", SqlDbType.NChar,10),
					new SqlParameter("@voltage", SqlDbType.NChar,10),
					new SqlParameter("@current", SqlDbType.NChar,10),
					new SqlParameter("@motor_power", SqlDbType.NChar,10),
					new SqlParameter("@power_factor", SqlDbType.NChar,10),
					new SqlParameter("@oil_leak", SqlDbType.Bit,1),
					new SqlParameter("@OKAlarm", SqlDbType.Bit,1),
					new SqlParameter("@NOAlarm", SqlDbType.Bit,1),
					new SqlParameter("@NCAlarm", SqlDbType.Bit,1),
					new SqlParameter("@recordtime", SqlDbType.DateTime)};
			parameters[0].Value = model.lcNumber;
			parameters[1].Value = model.djNumber;
			parameters[2].Value = model.oil_mass;
			parameters[3].Value = model.fire_alarm;
			parameters[4].Value = model.up_oil_place;
			parameters[5].Value = model.up_water_place;
			parameters[6].Value = model.battery_voltage;
			parameters[7].Value = model.alarm;
			parameters[8].Value = model.alarm_voice;
			parameters[9].Value = model.oil_press;
			parameters[10].Value = model.water_temp;
			parameters[11].Value = model.frequency;
			parameters[12].Value = model.motor_speed;
			parameters[13].Value = model.voltage;
			parameters[14].Value = model.current;
			parameters[15].Value = model.motor_power;
			parameters[16].Value = model.power_factor;
			parameters[17].Value = model.oil_leak;
			parameters[18].Value = model.OKAlarm;
			parameters[19].Value = model.NOAlarm;
			parameters[20].Value = model.NCAlarm;
			parameters[21].Value = model.recordtime;

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
		public bool Update(Maticsoft.Model.tab_displayComm model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tab_displayComm set ");
			strSql.Append("lcNumber=@lcNumber,");
			strSql.Append("djNumber=@djNumber,");
			strSql.Append("oil_mass=@oil_mass,");
			strSql.Append("fire_alarm=@fire_alarm,");
			strSql.Append("up_oil_place=@up_oil_place,");
			strSql.Append("up_water_place=@up_water_place,");
			strSql.Append("battery_voltage=@battery_voltage,");
			strSql.Append("alarm=@alarm,");
			strSql.Append("alarm_voice=@alarm_voice,");
			strSql.Append("oil_press=@oil_press,");
			strSql.Append("water_temp=@water_temp,");
			strSql.Append("frequency=@frequency,");
			strSql.Append("motor_speed=@motor_speed,");
			strSql.Append("voltage=@voltage,");
			strSql.Append("current=@current,");
			strSql.Append("motor_power=@motor_power,");
			strSql.Append("power_factor=@power_factor,");
			strSql.Append("oil_leak=@oil_leak,");
			strSql.Append("OKAlarm=@OKAlarm,");
			strSql.Append("NOAlarm=@NOAlarm,");
			strSql.Append("NCAlarm=@NCAlarm,");
			strSql.Append("recordtime=@recordtime");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@lcNumber", SqlDbType.NChar,10),
					new SqlParameter("@djNumber", SqlDbType.Int,4),
					new SqlParameter("@oil_mass", SqlDbType.NChar,10),
					new SqlParameter("@fire_alarm", SqlDbType.Bit,1),
					new SqlParameter("@up_oil_place", SqlDbType.Bit,1),
					new SqlParameter("@up_water_place", SqlDbType.Bit,1),
					new SqlParameter("@battery_voltage", SqlDbType.Bit,1),
					new SqlParameter("@alarm", SqlDbType.Bit,1),
					new SqlParameter("@alarm_voice", SqlDbType.Bit,1),
					new SqlParameter("@oil_press", SqlDbType.NChar,10),
					new SqlParameter("@water_temp", SqlDbType.NChar,10),
					new SqlParameter("@frequency", SqlDbType.NChar,10),
					new SqlParameter("@motor_speed", SqlDbType.NChar,10),
					new SqlParameter("@voltage", SqlDbType.NChar,10),
					new SqlParameter("@current", SqlDbType.NChar,10),
					new SqlParameter("@motor_power", SqlDbType.NChar,10),
					new SqlParameter("@power_factor", SqlDbType.NChar,10),
					new SqlParameter("@oil_leak", SqlDbType.Bit,1),
					new SqlParameter("@OKAlarm", SqlDbType.Bit,1),
					new SqlParameter("@NOAlarm", SqlDbType.Bit,1),
					new SqlParameter("@NCAlarm", SqlDbType.Bit,1),
					new SqlParameter("@recordtime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.lcNumber;
			parameters[1].Value = model.djNumber;
			parameters[2].Value = model.oil_mass;
			parameters[3].Value = model.fire_alarm;
			parameters[4].Value = model.up_oil_place;
			parameters[5].Value = model.up_water_place;
			parameters[6].Value = model.battery_voltage;
			parameters[7].Value = model.alarm;
			parameters[8].Value = model.alarm_voice;
			parameters[9].Value = model.oil_press;
			parameters[10].Value = model.water_temp;
			parameters[11].Value = model.frequency;
			parameters[12].Value = model.motor_speed;
			parameters[13].Value = model.voltage;
			parameters[14].Value = model.current;
			parameters[15].Value = model.motor_power;
			parameters[16].Value = model.power_factor;
			parameters[17].Value = model.oil_leak;
			parameters[18].Value = model.OKAlarm;
			parameters[19].Value = model.NOAlarm;
			parameters[20].Value = model.NCAlarm;
			parameters[21].Value = model.recordtime;
			parameters[22].Value = model.ID;

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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tab_displayComm ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tab_displayComm ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public Maticsoft.Model.tab_displayComm GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,lcNumber,djNumber,oil_mass,fire_alarm,up_oil_place,up_water_place,battery_voltage,alarm,alarm_voice,oil_press,water_temp,frequency,motor_speed,voltage,current,motor_power,power_factor,oil_leak,OKAlarm,NOAlarm,NCAlarm,recordtime from tab_displayComm ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.tab_displayComm model=new Maticsoft.Model.tab_displayComm();
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
		public Maticsoft.Model.tab_displayComm DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tab_displayComm model=new Maticsoft.Model.tab_displayComm();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["lcNumber"]!=null)
				{
					model.lcNumber=row["lcNumber"].ToString();
				}
				if(row["djNumber"]!=null && row["djNumber"].ToString()!="")
				{
					model.djNumber=int.Parse(row["djNumber"].ToString());
				}
				if(row["oil_mass"]!=null)
				{
					model.oil_mass=row["oil_mass"].ToString();
				}
				if(row["fire_alarm"]!=null && row["fire_alarm"].ToString()!="")
				{
					if((row["fire_alarm"].ToString()=="1")||(row["fire_alarm"].ToString().ToLower()=="true"))
					{
						model.fire_alarm=true;
					}
					else
					{
						model.fire_alarm=false;
					}
				}
				if(row["up_oil_place"]!=null && row["up_oil_place"].ToString()!="")
				{
					if((row["up_oil_place"].ToString()=="1")||(row["up_oil_place"].ToString().ToLower()=="true"))
					{
						model.up_oil_place=true;
					}
					else
					{
						model.up_oil_place=false;
					}
				}
				if(row["up_water_place"]!=null && row["up_water_place"].ToString()!="")
				{
					if((row["up_water_place"].ToString()=="1")||(row["up_water_place"].ToString().ToLower()=="true"))
					{
						model.up_water_place=true;
					}
					else
					{
						model.up_water_place=false;
					}
				}
				if(row["battery_voltage"]!=null && row["battery_voltage"].ToString()!="")
				{
					if((row["battery_voltage"].ToString()=="1")||(row["battery_voltage"].ToString().ToLower()=="true"))
					{
						model.battery_voltage=true;
					}
					else
					{
						model.battery_voltage=false;
					}
				}
				if(row["alarm"]!=null && row["alarm"].ToString()!="")
				{
					if((row["alarm"].ToString()=="1")||(row["alarm"].ToString().ToLower()=="true"))
					{
						model.alarm=true;
					}
					else
					{
						model.alarm=false;
					}
				}
				if(row["alarm_voice"]!=null && row["alarm_voice"].ToString()!="")
				{
					if((row["alarm_voice"].ToString()=="1")||(row["alarm_voice"].ToString().ToLower()=="true"))
					{
						model.alarm_voice=true;
					}
					else
					{
						model.alarm_voice=false;
					}
				}
				if(row["oil_press"]!=null)
				{
					model.oil_press=row["oil_press"].ToString();
				}
				if(row["water_temp"]!=null)
				{
					model.water_temp=row["water_temp"].ToString();
				}
				if(row["frequency"]!=null)
				{
					model.frequency=row["frequency"].ToString();
				}
				if(row["motor_speed"]!=null)
				{
					model.motor_speed=row["motor_speed"].ToString();
				}
				if(row["voltage"]!=null)
				{
					model.voltage=row["voltage"].ToString();
				}
				if(row["current"]!=null)
				{
					model.current=row["current"].ToString();
				}
				if(row["motor_power"]!=null)
				{
					model.motor_power=row["motor_power"].ToString();
				}
				if(row["power_factor"]!=null)
				{
					model.power_factor=row["power_factor"].ToString();
				}
				if(row["oil_leak"]!=null && row["oil_leak"].ToString()!="")
				{
					if((row["oil_leak"].ToString()=="1")||(row["oil_leak"].ToString().ToLower()=="true"))
					{
						model.oil_leak=true;
					}
					else
					{
						model.oil_leak=false;
					}
				}
				if(row["OKAlarm"]!=null && row["OKAlarm"].ToString()!="")
				{
					if((row["OKAlarm"].ToString()=="1")||(row["OKAlarm"].ToString().ToLower()=="true"))
					{
						model.OKAlarm=true;
					}
					else
					{
						model.OKAlarm=false;
					}
				}
				if(row["NOAlarm"]!=null && row["NOAlarm"].ToString()!="")
				{
					if((row["NOAlarm"].ToString()=="1")||(row["NOAlarm"].ToString().ToLower()=="true"))
					{
						model.NOAlarm=true;
					}
					else
					{
						model.NOAlarm=false;
					}
				}
				if(row["NCAlarm"]!=null && row["NCAlarm"].ToString()!="")
				{
					if((row["NCAlarm"].ToString()=="1")||(row["NCAlarm"].ToString().ToLower()=="true"))
					{
						model.NCAlarm=true;
					}
					else
					{
						model.NCAlarm=false;
					}
				}
				if(row["recordtime"]!=null && row["recordtime"].ToString()!="")
				{
					model.recordtime=DateTime.Parse(row["recordtime"].ToString());
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
			strSql.Append("select ID,lcNumber,djNumber,oil_mass,fire_alarm,up_oil_place,up_water_place,battery_voltage,alarm,alarm_voice,oil_press,water_temp,frequency,motor_speed,voltage,current,motor_power,power_factor,oil_leak,OKAlarm,NOAlarm,NCAlarm,recordtime ");
			strSql.Append(" FROM tab_displayComm ");
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
			strSql.Append(" ID,lcNumber,djNumber,oil_mass,fire_alarm,up_oil_place,up_water_place,battery_voltage,alarm,alarm_voice,oil_press,water_temp,frequency,motor_speed,voltage,current,motor_power,power_factor,oil_leak,OKAlarm,NOAlarm,NCAlarm,recordtime ");
			strSql.Append(" FROM tab_displayComm ");
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
			strSql.Append("select count(1) FROM tab_displayComm ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from tab_displayComm T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

	
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
        //    parameters[0].Value = "tab_displayComm";
        //    parameters[1].Value = "ID";
        //    parameters[2].Value = PageSize;
        //    parameters[3].Value = PageIndex;
        //    parameters[4].Value = 0;
        //    parameters[5].Value = 0;
        //    parameters[6].Value = strWhere;	
        //    return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        //}

		#endregion  BasicMethod
		#region  ExtensionMethod

        //public List<Maticsoft.Model.tab_displayComm> GetSearchModelList(string lcnum, string start, string end, out int pagecount)
        //{
        //    List<Maticsoft.Model.tab_displayComm> list = new List<Model.tab_displayComm>();
        //    string sql = "select * from tab_displayComm where lcNumber=@lcnum and recordtime between @start and @end";
        //    SqlParameter[] parms = new SqlParameter[] { new SqlParameter("@lcnum", SqlDbType.NVarChar), new SqlParameter("@end", SqlDbType.NVarChar), new SqlParameter("@start", SqlDbType.NVarChar) };
        //    parms[0].Value = lcnum;
        //    parms[1].Value = end;
        //    parms[2].Value = start;
        //    SqlDataReader dr = DBUtility.SqlHelper1.ExecuteReader(sql, CommandType.Text, parms);
        //    Model.tab_displayComm model;
        //    if (dr.HasRows)
        //    {
                
        //        while (dr.Read())
        //        {
        //            model = new Model.tab_displayComm();
        //            model.ID = dr.GetInt32(0);
        //            model.lcNumber = dr.GetString(1);
        //            model
        //        }

        //    }
        //    dr.Close();
        //}

        public DataTable GetSearchDataTable(string lcnum, string start, string end,int pageindex,int pagesize, out int pagecount)
        {
            string sql = "select top (@pagesize) * from tab_displayComm where id not in (select top (@pagespan) id from tab_displayComm order by id desc) and lcNumber=@lcnum and recordtime between @start and @end order by id desc";
            string sql2 = "select count(*) from tab_displayComm where lcNumber=@lcnum and recordtime between @start and @end";
            SqlParameter[] parms = new SqlParameter[] { new SqlParameter("@lcnum", SqlDbType.NVarChar), new SqlParameter("@end", SqlDbType.NVarChar), new SqlParameter("@start", SqlDbType.NVarChar), new SqlParameter("@pagesize", SqlDbType.Int), new SqlParameter("@pagespan", SqlDbType.Int) };
            parms[0].Value = lcnum;
            parms[1].Value = end;
            parms[2].Value = start;
            parms[3].Value = pagesize;
            parms[4].Value = pagesize*(pageindex-1);
            SqlParameter[] parms1 = new SqlParameter[] { new SqlParameter("@lcnum", SqlDbType.NVarChar), new SqlParameter("@end", SqlDbType.NVarChar), new SqlParameter("@start", SqlDbType.NVarChar) };
            parms1[0].Value = lcnum;
            parms1[1].Value = end;
            parms1[2].Value = start;
            int a = (int)DBUtility.SqlHelper1.ExecuteSclare(sql2, CommandType.Text, parms1);
            pagecount = a / pagesize + (a % pagesize > 0 ? 1 : 0);
            return DBUtility.SqlHelper1.ExecuteTable(sql, CommandType.Text, parms);
        }
		#endregion  ExtensionMethod
	}
}

