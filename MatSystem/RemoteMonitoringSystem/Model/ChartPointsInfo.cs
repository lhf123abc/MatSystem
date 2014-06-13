using System;
using System.Collections.Generic;
using System.Web;

namespace Maticsoft.Model
{
    public class ChartPointsInfo
    {
        public int GeneratorId
        {
            get;
            set;
        }
        public List<float> WaterTempPoints
        {
            get;
            set;
        }

        public List<float> OilPressPoints
        {
            get;
            set;
        }

        
    }
}