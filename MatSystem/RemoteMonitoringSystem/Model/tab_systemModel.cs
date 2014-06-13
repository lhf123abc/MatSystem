using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tab_system:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tab_system
	{
		public tab_system()
		{}
		#region Model
		private int _id;
		private string _lcnumber;
		private string _startplace;
		private string _endplace;
		private DateTime? _dangbanstarttime;
		private DateTime? _dangbanendtime;
		private string _baojingjiange;
		private string _xunjianjiange;
		private string _xjname;
		private string _bcontent;
		private DateTime? _recordtime;
		private string _checi;
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
		public string startplace
		{
			set{ _startplace=value;}
			get{return _startplace;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string endplace
		{
			set{ _endplace=value;}
			get{return _endplace;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dangbanStartTime
		{
			set{ _dangbanstarttime=value;}
			get{return _dangbanstarttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dangbanEndTime
		{
			set{ _dangbanendtime=value;}
			get{return _dangbanendtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string baojingjiange
		{
			set{ _baojingjiange=value;}
			get{return _baojingjiange;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xunjianjiange
		{
			set{ _xunjianjiange=value;}
			get{return _xunjianjiange;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string xjName
		{
			set{ _xjname=value;}
			get{return _xjname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Bcontent
		{
			set{ _bcontent=value;}
			get{return _bcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? recordtime
		{
			set{ _recordtime=value;}
			get{return _recordtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string checi
		{
			set{ _checi=value;}
			get{return _checi;}
		}
		#endregion Model

	}
}

