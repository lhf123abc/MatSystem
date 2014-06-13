using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// CriticalData:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CriticalData
	{
		public CriticalData()
		{}
		#region Model
		private int _id;
		private string _lcnum;
		private int _generatorid;
		private decimal _oilpress;
		private decimal _watertemp;
		private decimal _frequency;
		private decimal _motorspeed;
		private decimal _voltage;
		private decimal _current;
		private decimal _motorpower;
		private decimal _powerfactor;
		private decimal _oilmass;
		private int _alarmvalue;
		private DateTime _datetime;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string lcNum
		{
			set{ _lcnum=value;}
			get{return _lcnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int generatorId
		{
			set{ _generatorid=value;}
			get{return _generatorid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal oilPress
		{
			set{ _oilpress=value;}
			get{return _oilpress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal waterTemp
		{
			set{ _watertemp=value;}
			get{return _watertemp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal frequency
		{
			set{ _frequency=value;}
			get{return _frequency;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal motorSpeed
		{
			set{ _motorspeed=value;}
			get{return _motorspeed;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal voltage
		{
			set{ _voltage=value;}
			get{return _voltage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal current
		{
			set{ _current=value;}
			get{return _current;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal motorPower
		{
			set{ _motorpower=value;}
			get{return _motorpower;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal powerFactor
		{
			set{ _powerfactor=value;}
			get{return _powerfactor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal oilMass
		{
			set{ _oilmass=value;}
			get{return _oilmass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int alarmValue
		{
			set{ _alarmvalue=value;}
			get{return _alarmvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime dateTime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		#endregion Model

	}
}

