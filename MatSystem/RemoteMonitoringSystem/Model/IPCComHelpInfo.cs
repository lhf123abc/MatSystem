using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Model
{
	public struct IPCComHelpInfo
	{
        private string serialNum;
        private string ipStr;
        public string SerialNum
        {
            get
            {
                return serialNum;
            }
        }
        public string IPStr
        {
            get
            {
                return ipStr;
            }
        }

        public IPCComHelpInfo(string serialNum, string ipStr)
        {
            this.serialNum = serialNum;
            this.ipStr = ipStr;
        }
	}
}
