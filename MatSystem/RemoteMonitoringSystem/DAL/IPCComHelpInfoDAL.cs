using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Maticsoft.DAL
{
	public partial class IPCComHelpInfo
	{
        private const string QUERY_ALL = "SELECT serialNum,IPCIP FROM ComHelpInfo";
        private const string UPDATE_PORT = "UPDATE ComHelpInfo SET IPCIP=@IPCIP WHERE serialNum=@serialNum";
        private const string ADD_COMHELPINFO = "INSERT INTO ComHelpInfo(serialNum,IPCIP) VALUES(@IPCIP,@serialNum)";

        public List<Maticsoft.Model.IPCComHelpInfo> GetAllIPCComHelpInfo()
        {
            List<Maticsoft.Model.IPCComHelpInfo> IPCComHelpList = new List<Model.IPCComHelpInfo>(45);
            using (SqlDataReader dr = DBUtility.SqlHelper1.ExecuteReader(QUERY_ALL, CommandType.Text))
            {
                while (dr.Read())
                {
                    IPCComHelpList.Add(new Maticsoft.Model.IPCComHelpInfo(dr.GetString(0).TrimEnd(),dr.GetString(1).TrimEnd()));
                }
            }
            return IPCComHelpList;
                
            
        }
	}
}
