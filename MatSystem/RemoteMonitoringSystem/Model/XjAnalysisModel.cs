using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Model
{
  public class XjAnalysisModel
	{
        public string lcNumber
        { get; set; }
        public int AllCheckTime
        { get; set; }
        public int CheckTimes
        { get; set; }
        public int NoCheckTimes
        { get; set; }
        public int CheckLateTimes
        { get; set; }
        public double CheckFrequency
        { get; set; }
        public double CheckLateFrequency
        { get; set; }
	}
}
