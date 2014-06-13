using System;
using System.Collections.Generic;
using System.Web;

namespace Maticsoft.Model
{
    [Serializable]
    public class TrainStatusInfo
    {
      
        private DateTime lastLingedDate;
        private int generatorStatusValue = 0;
        private int alarmValue;

        public int AlarmValue
        {
            get
            {
                return alarmValue;
            }
            set
            {
                alarmValue = value;
            }
        }

        public bool Status3G
        {
            get
            {

                return DateTime.Now.Subtract(lastLingedDate).TotalSeconds<8;
               
            }
        }

        public DateTime LastLoginedDate
        {
            set
            {
                 lastLingedDate = value;
               
            }
        }

        public bool StatusGenerator1//0位
        {
            get
            {
                 return (generatorStatusValue & 1) > 0;
            }
            set
            {
                    if (value)
                    {
                        generatorStatusValue|=1;
                    }
                    else
                    {
                        generatorStatusValue &= (~1);
                    }
            }
        }

        public bool StatusGenerator2
        {
            get
            {

                    return (generatorStatusValue & (1<<1)) > 0;
            }
            set
            {

                    if (value)
                    {
                        generatorStatusValue |= (1<<1);
                    }
                    else
                    {
                        generatorStatusValue &= (~(1<<1));
                    }
            }

        }

        public bool StatusGenerator3
        {
            get
            {
                    return (generatorStatusValue & (1<<2)) > 0;
            }
            set
            {
                    if (value)
                    {
                        generatorStatusValue |= (1<<2);
                    }
                    else
                    {
                        generatorStatusValue &= (~(1<<2));
                    }
            }
        }
        

    }
}