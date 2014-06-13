/**  版本信息模板在安装目录下，可自行修改。
* trainInfo.cs
*
* 功 能： N/A
* 类 名： trainInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/30 13:54:04   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// trainInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class trainInfo
	{
		public trainInfo()
		{}
		#region Model
		private int _id;
		private string _serianum;
		private string _train;
		private string _route;
        private string _dhip;
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
		public string seriaNum
		{
			set{ _serianum=value;}
			get{return _serianum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string train
		{
			set{ _train=value;}
			get{return _train;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string route
		{
			set{ _route=value;}
			get{return _route;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string dhip
        {
            set { _dhip = value; }
            get { return _dhip; }
        }
		#endregion Model

	}
}

