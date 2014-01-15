/******************************************************************************
 * 
 * Filename:  FileBorrow.cs
 * Description:  执法档案借阅表Model实体层字段
 * Author :  liangjw
 * Created Mark:  2013-11-28 7:37:56
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
	/// 执法档案借阅表
	/// </summary>
	[Serializable]
	public partial class FileBorrow
	{
		public FileBorrow()
		{}
		#region Model
		private int _id;
		private int? _fileclassid;
        private int? _FileEnterID;
        private string _FileClassName;
		private string _fileentername;
		private string _borrowpeople;
		private string _borrowunit;
		private string _approverpeople;
        private string _ApproverUnit;
		private string _handlepeople;
		private string _borrowdate;
		private string _returndate;
        private string _OperateTime;
		private string _remark;
        private string _UserID;
        private string _Username;
        private string _SZQXDM;
        private int _sjlx;    // 临时字段
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
        /// <summary>
        /// 案卷编号
        /// </summary>
        public int? FileEnterID
        {
            set { _FileEnterID = value; }
            get { return _FileEnterID; }
        }
		/// <summary>
		/// 案卷类别编号
		/// </summary>
		public int? FileClassID
		{
			set{ _fileclassid=value;}
			get{return _fileclassid;}
		}
        /// <summary>
        /// 案卷类别名称
        /// </summary>
        public string FileClassName
        {
            set { _FileClassName = value; }
            get { return _FileClassName; }
        }
        /// <summary>
        /// 执法档案录入名称
        /// </summary>
        public string FileEnterName
        {
            set { _fileentername = value; }
            get { return _fileentername; }
        }
		/// <summary>
		/// 借阅人
		/// </summary>
		public string BorrowPeople
		{
			set{ _borrowpeople=value;}
			get{return _borrowpeople;}
		}
		/// <summary>
		/// 借阅人单位
		/// </summary>
		public string BorrowUnit
		{
			set{ _borrowunit=value;}
			get{return _borrowunit;}
		}
		/// <summary>
		/// 批准人
		/// </summary>
		public string ApproverPeople
		{
			set{ _approverpeople=value;}
			get{return _approverpeople;}
		}
        /// <summary>
        /// 批准人单位
        /// </summary>
        public string ApproverUnit
        {
            set { _ApproverUnit = value; }
            get { return _ApproverUnit; }
        }
		/// <summary>
		/// 经办人
		/// </summary>
		public string HandlePeople
		{
			set{ _handlepeople=value;}
			get{return _handlepeople;}
		}
		/// <summary>
		/// 借出日期
		/// </summary>
		public string BorrowDate
		{
			set{ _borrowdate=value;}
			get{return _borrowdate;}
		}
		/// <summary>
		/// 归还日期
		/// </summary>
		public string ReturnDate
		{
			set{ _returndate=value;}
			get{return _returndate;}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
        public string OperateTime
		{
            set { _OperateTime = value; }
            get { return _OperateTime; }
		}
		/// <summary>
		/// 备注信息
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
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
        /// 所属区县代码
        /// </summary>
        public string SZQXDM
        {
            set { _SZQXDM = value; }
            get { return _SZQXDM; }
        }
        /// <summary>
        /// 数据类型 0默认全部[1未归还, 2已归还]
        /// </summary>
        public int SJLX
        {
            set { _sjlx = value; }
            get { return _sjlx; }
        }
		#endregion Model

	}
}

