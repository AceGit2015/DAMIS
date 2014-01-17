/******************************************************************************
 * 
 * Filename:  Organizer.cs
 * Description:   承办单位表Model实体层字段
 * Author :  liangjw
 * Created Mark:  2013-10-28 7:38:22
 * E-mail： liangjw0504@163.com
 * Version:    V1.0.0.0
 * Company: ：Create Family Wealth © Copyright 2011 - 2013.All Rights Reserved.
 * Remark: 无
 * Update Author:   无
 * Update Description: 无
 * Update Mark : 无
 * 
*******************************************************************************/
using System;
namespace ToolsModel
{
	/// <summary>
	/// 承办单位表
	/// </summary>
	[Serializable]
	public partial class Organizer
	{
		public Organizer()
		{}
		#region Model
		private int _id;
        private string _organizername;
        private string _UserID;
        private string _Username;
        private string _OperateTime;
		/// <summary>
        /// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 承办单位名称
		/// </summary>
		public string OrganizerName
		{
			set{ _organizername=value;}
			get{return _organizername;}
        }
        /// <summary>
        /// 操作人ID
        /// </summary>
        public string UserID
        {
            set { _UserID = value; }
            get { return _UserID; }
        }
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string Username
        {
            set { _Username = value; }
            get { return _Username; }
        }
        /// <summary>
        /// 操作日期
        /// </summary>
        public string OperateTime
        {
            set { _OperateTime = value; }
            get { return _OperateTime; }
        }
		#endregion Model

	}
}

