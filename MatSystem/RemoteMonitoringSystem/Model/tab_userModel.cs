using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tab_user:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tab_user
	{
		public tab_user()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _nicname;
		private string _password;
		private string _quanxian;
		private DateTime? _registertime;
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
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nicname
		{
			set{ _nicname=value;}
			get{return _nicname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string quanxian
		{
			set{ _quanxian=value;}
			get{return _quanxian;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? registertime
		{
			set{ _registertime=value;}
			get{return _registertime;}
		}
		#endregion Model

	}
}

