/******************************************************************************
 * 
 * Filename:  FileDirectory.cs
 * Description:   档案目录表Model实体层字段
 * Author :  liangjw
 * Created Mark:  2013-10-28 7:38:56
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
	/// 档案目录表
	/// </summary>
	[Serializable]
	public partial class FileDirectory
	{
		public FileDirectory()
		{}
		#region Model
		private int _id;
        private string _filedirname;
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
		/// 档案目录号名称
		/// </summary>
		public string FileDirName
		{
			set{ _filedirname=value;}
			get{return _filedirname;}
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

