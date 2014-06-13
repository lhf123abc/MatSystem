using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tab_displayComm:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tab_displayComm
	{
		public tab_displayComm()
		{}
		#region Model
		private int _id;
		private string _lcnumber;
		private int? _djnumber;
		private string _oil_mass;
		private bool _fire_alarm;
		private bool _up_oil_place;
		private bool _up_water_place;
		private bool _battery_voltage;
		private bool _alarm;
		private bool _alarm_voice;
		private string _oil_press;
		private string _water_temp;
		private string _frequency;
		private string _motor_speed;
		private string _voltage;
		private string _current;
		private string _motor_power;
		private string _power_factor;
		private bool _oil_leak;
		private bool _okalarm;
		private bool _noalarm;
		private bool _ncalarm;
		private DateTime? _recordtime;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string lcNumber
		{
			set{ _lcnumber=value;}
			get{return _lcnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? djNumber
		{
			set{ _djnumber=value;}
			get{return _djnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string oil_mass
		{
			set{ _oil_mass=value;}
			get{return _oil_mass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool fire_alarm
		{
			set{ _fire_alarm=value;}
			get{return _fire_alarm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool up_oil_place
		{
			set{ _up_oil_place=value;}
			get{return _up_oil_place;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool up_water_place
		{
			set{ _up_water_place=value;}
			get{return _up_water_place;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool battery_voltage
		{
			set{ _battery_voltage=value;}
			get{return _battery_voltage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool alarm
		{
			set{ _alarm=value;}
			get{return _alarm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool alarm_voice
		{
			set{ _alarm_voice=value;}
			get{return _alarm_voice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string oil_press
		{
			set{ _oil_press=value;}
			get{return _oil_press;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string water_temp
		{
			set{ _water_temp=value;}
			get{return _water_temp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string frequency
		{
			set{ _frequency=value;}
			get{return _frequency;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string motor_speed
		{
			set{ _motor_speed=value;}
			get{return _motor_speed;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string voltage
		{
			set{ _voltage=value;}
			get{return _voltage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string current
		{
			set{ _current=value;}
			get{return _current;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string motor_power
		{
			set{ _motor_power=value;}
			get{return _motor_power;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string power_factor
		{
			set{ _power_factor=value;}
			get{return _power_factor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool oil_leak
		{
			set{ _oil_leak=value;}
			get{return _oil_leak;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool OKAlarm
		{
			set{ _okalarm=value;}
			get{return _okalarm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool NOAlarm
		{
			set{ _noalarm=value;}
			get{return _noalarm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool NCAlarm
		{
			set{ _ncalarm=value;}
			get{return _ncalarm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? recordtime
		{
			set{ _recordtime=value;}
			get{return _recordtime;}
		}
		#endregion Model

	}
}

