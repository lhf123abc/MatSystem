using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tab_systemrecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tab_systemrecord
	{
		public tab_systemrecord()
		{}
		#region Model
		private int _id;
		private string _lcnumber;
		private DateTime? _systemstarttime;
		private DateTime? _systemshutdowntime;
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
		public string lcNumber
		{
			set{ _lcnumber=value;}
			get{return _lcnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? systemstarttime
		{
			set{ _systemstarttime=value;}
			get{return _systemstarttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? systemshutdowntime
		{
			set{ _systemshutdowntime=value;}
			get{return _systemshutdowntime;}
		}
		#endregion Model

	}
}

