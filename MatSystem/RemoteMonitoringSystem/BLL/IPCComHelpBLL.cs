using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.BLL
{
	public partial class IPCComHelpBLL
	{
        public static Maticsoft.DAL.IPCComHelpInfo dal = new DAL.IPCComHelpInfo();
        public List<Maticsoft.Model.IPCComHelpInfo> GetAllIPCComHelpInfo()
        {
            return dal.GetAllIPCComHelpInfo();
        }
	}
}
