/******************************************************************************
 * 
 * Filename:  FileDestroy.cs
 * Description:  执法档案销毁表Model实体层字段
 * Author :  liangjw
 * Created Mark:  2013-11-28 5:24:18
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
	/// 执法档案销毁表
	/// </summary>
	[Serializable]
	public partial class FileDestroy
	{
		public FileDestroy()
		{}
		#region Model
		private int _id;
		private int? _fileclassid;
        private int? _FileEnterID;
        private string _FileClassName;
        private string _fileentername;
		private string _approverpeople;
        private string _ApproverUnit;
		private string _supervisepeople;
        private string _SuperviseUnit;
        private string _DestroyPeople;
		private string _destroydate;
		private string _destroyads;
        private string _OperateTime;
        private string _remark;
        private string _UserID;
        private string _Username;
        private string _SZQXDM;
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
		/// <summary>
		/// 执法档案录入名称
		/// </summary>
		public string FileEnterName
		{
            set { _fileentername = value; }
            get { return _fileentername; }
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
		/// 监督人
		/// </summary>
		public string SupervisePeople
		{
			set{ _supervisepeople=value;}
			get{return _supervisepeople;}
		}
        /// <summary>
        /// 监督人单位
        /// </summary>
        public string SuperviseUnit
        {
            set { _SuperviseUnit = value; }
            get { return _SuperviseUnit; }
        }
        /// <summary>
        /// 销毁人
        /// </summary>
        public string DestroyPeople
        {
            set { _DestroyPeople = value; }
            get { return _DestroyPeople; }
        }
		/// <summary>
		/// 销毁日期
		/// </summary>
		public string DestroyDate
		{
			set{ _destroydate=value;}
			get{return _destroydate;}
		}
		/// <summary>
		/// 销毁地点
		/// </summary>
		public string DestroyAds
		{
			set{ _destroyads=value;}
			get{return _destroyads;}
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
            set { _remark = value; }
            get { return _remark; }
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
		#endregion Model

	}
}

