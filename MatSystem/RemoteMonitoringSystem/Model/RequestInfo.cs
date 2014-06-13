using System;
using System.Collections.Generic;
using System.Web;

namespace Maticsoft.Model
{
    public class RequestInfo
    {
        private string sessionId;
        private DateTime lastRequestDate;

        public string SessionId
        {
            get
            {
                return sessionId;
            }
            set
            {
                sessionId = value;
            }
        }


        public DateTime LastRequestDate
        {
            get
            {
                 return lastRequestDate;
            }
            set
            {
                 lastRequestDate = DateTime.Now;
            }
        }

    }
}