/******************************************************************************
 * 
 * Filename:  FileTransfer.cs
 * Description:  执法档案移交表Model实体层字段
 * Author :  liangjw
 * Created Mark:  2013-11-28 5:23:09
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
	/// 执法档案移交表
	/// </summary>
	[Serializable]
	public partial class FileTransfer
	{
		public FileTransfer()
		{}
		#region Model
		private int _id;
		private int? _fileclassid;
        private int? _FileEnterID;
        private string _FileClassName;
        private string _fileentername;
		private string _transferpeople;
        private string _TransferUnit;
		private string _acceptpeople;
        private string _acceptszqxdm;
        private string _acceptunit;
		private string _approverpeople;
        private string _ApproverUnit;
		private string _transferdate;
        private string _OperateTime;
		private string _remark;
        private string _UserID;
        private string _Username;
        private int _sjzt;
        private string _Jsyy;
        private string _SZQXDM;
        private string _Jssj;
        private string _Gdr;
        private string _Gdsj;
        private string _Yjlx;
        private int _lssjlx;
        private int _Xfxzxkda;
        private int _Xfjdjcda;
        private int _Xfaqzddwda;
        private int _Zdhzyhda;
        private int _Hzsgdcda;
        private int _Xfxzcfda;
        private int _Xfxzqzda;
        private int _Xfzfjjda;
        private int _Xfxsda;

        #region
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
		/// 移交人
		/// </summary>
		public string TransferPeople
		{
			set{ _transferpeople=value;}
			get{return _transferpeople;}
		}
        /// <summary>
        /// 移交人单位
        /// </summary>
        public string TransferUnit
        {
            set { _TransferUnit = value; }
            get { return _TransferUnit; }
        }
		/// <summary>
		/// 接收人
		/// </summary>
		public string AcceptPeople
		{
			set{ _acceptpeople=value;}
			get{return _acceptpeople;}
		}
        /// <summary>
        /// 接收人所在区县代码
        /// </summary>
        public string AcceptSzqxdm
        {
            set { _acceptszqxdm = value; }
            get { return _acceptszqxdm; }
        }
		/// <summary>
        /// 接收人单位
		/// </summary>
        public string AcceptUnit
		{
            set { _acceptunit = value; }
            get { return _acceptunit; }
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
		/// 移交日期
		/// </summary>
		public string TransferDate
		{
			set{ _transferdate=value;}
			get{return _transferdate;}
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
        /// 数据状态 0 未接收  1拒收 2已接受 3已归档
        /// </summary>
        public int SJZT
        {
            set { _sjzt = value; }
            get { return _sjzt; }
        }

        
        /// <summary>
        /// 拒收原由
        /// </summary>
        public string Jsyy
        {
            set { _Jsyy = value; }
            get { return _Jsyy; }
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
        /// 接收时间
        /// </summary>
        public string Jssj
        {
            set { _Jssj = value; }
            get { return _Jssj; }
        }

        /// <summary>
        /// 归档人
        /// </summary>
        public string Gdr
        {
            set { _Gdr = value; }
            get { return _Gdr; }
        }

        /// <summary>
        /// 归档时间
        /// </summary>
        public string Gdsj
        {
            set { _Gdsj = value; }
            get { return _Gdsj; }
        }

        /// <summary>
        /// 移交类型[0档案移交 1移交支队]
        /// </summary>
        public string Yjlx
        {
            set { _Yjlx = value; }
            get { return _Yjlx; }
        }

        /// <summary>
        /// 临时数据类型
        /// </summary>
        public int Lssjlx
        {
            set { _lssjlx = value; }
            get { return _lssjlx; }
        }
        #endregion

        /// <summary>
        /// 消防行政许可档案
        /// </summary>
        public int Xfxzxkda
        {
            set { _Xfxzxkda = value; }
            get { return _Xfxzxkda; }
        }

        /// <summary>
        /// 消防监督检查档案
        /// </summary>
        public int Xfjdjcda
        {
            set { _Xfjdjcda = value; }
            get { return _Xfjdjcda; }
        }

        /// <summary>
        /// 消防安全重点单位档案
        /// </summary>
        public int Xfaqzddwda
        {
            set { _Xfaqzddwda = value; }
            get { return _Xfaqzddwda; }
        }

        /// <summary>
        /// 重大火灾隐患档案
        /// </summary>
        public int Zdhzyhda
        {
            set { _Zdhzyhda = value; }
            get { return _Zdhzyhda; }
        }

        /// <summary>
        /// 火灾事故调查档案
        /// </summary>
        public int Hzsgdcda
        {
            set { _Hzsgdcda = value; }
            get { return _Hzsgdcda; }
        }

        /// <summary>
        /// 消防行政处罚档案
        /// </summary>
        public int Xfxzcfda
        {
            set { _Xfxzcfda = value; }
            get { return _Xfxzcfda; }
        }

        /// <summary>
        /// 消防行政强制档案
        /// </summary>
        public int Xfxzqzda
        {
            set { _Xfxzqzda = value; }
            get { return _Xfxzqzda; }
        }

        /// <summary>
        /// 消防执法救济档案
        /// </summary>
        public int Xfzfjjda
        {
            set { _Xfzfjjda = value; }
            get { return _Xfzfjjda; }
        }

        /// <summary>
        /// 消防刑事档案
        /// </summary>
        public int Xfxsda
        {
            set { _Xfxsda = value; }
            get { return _Xfxsda; }
        }

        #endregion Model

    }
}

