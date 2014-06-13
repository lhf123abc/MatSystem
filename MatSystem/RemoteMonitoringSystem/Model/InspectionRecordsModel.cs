using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// InspectionRecords:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class InspectionRecords
	{
		public InspectionRecords()
		{}
		#region Model
		private int _id;
		private string _lcnum;
		private string _status;
		private DateTime _plantime;
		private DateTime? _recordtime;
		private string _worker;
		private string _remarks;
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
		public string status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime planTime
		{
			set{ _plantime=value;}
			get{return _plantime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? recordTime
		{
			set{ _recordtime=value;}
			get{return _recordtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string worker
		{
			set{ _worker=value;}
			get{return _worker;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		#endregion Model

	}
}

