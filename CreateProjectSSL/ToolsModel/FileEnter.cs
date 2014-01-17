/******************************************************************************
 * 
 * Filename:  FileEnter.cs
 * Description:   执法档案录入表Model实体层字段
 * Author :  liangjw
 * Created Mark:  2013-10-28 7:38:03
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
    /// 执法档案录入表
    /// </summary>
    [Serializable]
    public partial class FileEnter
    {
        public FileEnter()
        { }
        #region Model
        private int _id;
        private string _filefondsno;
        private int _fileclassid;
        private int? _filedirectoryid;
        private string _filesnum;
        private string _filesname;
        private string _enterpeople;
        private DateTime? _enterdate = DateTime.Now;
        private int? _savedeadlineid;
        private string _buildads;
        private string _buildcheckt;
        private string _buildfilingt;
        private string _buildarea;
        private int? _buildalicense = 0;
        private string _checkads;
        private string _checknature;
        private int? _checkresult = 0;
        private string _complainads;
        private int? _complainresult = 0;
        private string _firenature;
        private string _firearea;
        private string _fireestateloss;
        private int? _firehpeople;
        private int? _firedpeople;
        private string _masssportsads;
        private int? _masssportsresult = 0;
        private string _punishtypeid;
        private decimal? _punishfinepay;
        private string _punishparts;
        private string _tempclose;
        private int? _tempday = 0;
        private string _forcerunads;
        private string _forcepunish;
        private string _applyreviewpeople;
        private string _countrypayads;
        private string _penaldocsex;
        private string _penaldocbirthday;
        private string _penaldocnation;
        private string _penaldocads;
        private string _penaldoccrimeads;
        private string _penaldocresult;
        private int? _enforcementid;
        private string _enforcementname;
        private string _enforcementpeople;
        private string _enforcementpeople2;
        private string _enforcementdate;
        private string _enforcementdate2;
        private string _buildunitname;
        private string _builditemname;
        private string _checkunitname;
        private string _checkitemname;
        private string _complainpeople;
        private string _complainnpeople;
        private string _compainn;
        private string _masssportspeople;
        private string _masssportname;
        private string _fireads;
        private string _fireunitname;
        private string _firedatetime;
        private string _firen;
        private string _punishmain;
        private string _punishwhy;
        private string _tempuintname;
        private string _tempn;
        private string _tempdx;
        private string _forceunitname;
        private string _forcen;
        private string _applyfy;
        private string _countrymain;
        private string _penalname;
        private string _penalzn;
        private string _enteCountyId;
        private string _enteUserName;
        private string _tmp_Data;
        private string _FileLibraryID;
        private string _FileLibraryName;
        private int _sjlx;
        private string _FileLibraryData;
        private string _Ghmj;
        private string _Ccss;
        private string _Srs;
        private string _Wrs;
        private string _BuildAdsArea;
        private string _CheckAdsArea;
        private string _ComplainAdsArea;
        private string _MassSportsAdsArea;
        private string _PunishAdsArea;
        private string _TempCloseArea;
        private string _ForceRunAdsArea;
        private string _ApplyFYArea;
        private string _CountryPayAdsArea;
        private string _PenalDocAdsArea;
        private string _PenalDocCrimeAdsArea;
        private string _CheckNaturefc;
        private string _NumStatic;
        private string _FileTransferDate;
        private string _ReceiptTime;
        private string _Columns;
        private string _Cupboard;
        private string _Frame;

        #region
        /// <summary>
        /// 编号
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 执法档案全宗号
        /// </summary>
        public string FileFondsNo
        {
            set { _filefondsno = value; }
            get { return _filefondsno; }
        }
        /// <summary>
        /// 案卷类别编号
        /// </summary>
        public int FileClassID
        {
            set { _fileclassid = value; }
            get { return _fileclassid; }
        }
        /// <summary>
        /// 档案目录编号
        /// </summary>
        public int? FileDirectoryID
        {
            set { _filedirectoryid = value; }
            get { return _filedirectoryid; }
        }
        /// <summary>
        /// 执法档案案卷号
        /// </summary>
        public string FilesNum
        {
            set { _filesnum = value; }
            get { return _filesnum; }
        }
        /// <summary>
        /// 执法档案名称
        /// </summary>
        public string FilesName
        {
            set { _filesname = value; }
            get { return _filesname; }
        }
        /// <summary>
        /// 录入人
        /// </summary>
        public string EnterPeople
        {
            set { _enterpeople = value; }
            get { return _enterpeople; }
        }
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime? EnterDate
        {
            set { _enterdate = value; }
            get { return _enterdate; }
        }
        /// <summary>
        /// 执法档案保存时间编号
        /// </summary>
        public int? SaveDeadlineID
        {
            set { _savedeadlineid = value; }
            get { return _savedeadlineid; }
        }
        /// <summary>
        /// 建设工程地址
        /// </summary>
        public string BuildAds
        {
            set { _buildads = value; }
            get { return _buildads; }
        }
        /// <summary>
        /// 建设工程的类型[需审核范围]
        /// </summary>
        public string BuildCheckT
        {
            set { _buildcheckt = value; }
            get { return _buildcheckt; }
        }
        /// <summary>
        /// 建设工程的类型[需备案范围]
        /// </summary>
        public string BuildFilingT
        {
            set { _buildfilingt = value; }
            get { return _buildfilingt; }
        }
        /// <summary>
        /// 建设占地面积、总面积
        /// </summary>
        public string BuildArea
        {
            set { _buildarea = value; }
            get { return _buildarea; }
        }
        /// <summary>
        /// 建设行政许可[0许可/1不许可]
        /// </summary>
        public int? BuildALicense
        {
            set { _buildalicense = value; }
            get { return _buildalicense; }
        }
        /// <summary>
        /// 检查地址
        /// </summary>
        public string CheckAds
        {
            set { _checkads = value; }
            get { return _checkads; }
        }
        /// <summary>
        /// 检查性质
        /// </summary>
        public string CheckNature
        {
            set { _checknature = value; }
            get { return _checknature; }
        }
        /// <summary>
        /// 检查结果[0合或/1不合格]
        /// </summary>
        public int? CheckResult
        {
            set { _checkresult = value; }
            get { return _checkresult; }
        }
        /// <summary>
        /// 投诉建设工程地址
        /// </summary>
        public string ComplainAds
        {
            set { _complainads = value; }
            get { return _complainads; }
        }
        /// <summary>
        /// 投诉核查结果[0合格/1不合格]
        /// </summary>
        public int? ComplainResult
        {
            set { _complainresult = value; }
            get { return _complainresult; }
        }
        /// <summary>
        /// 火灾燃烧物质
        /// </summary>
        public string FireNature
        {
            set { _firenature = value; }
            get { return _firenature; }
        }
        /// <summary>
        /// 火灾过火面积
        /// </summary>
        public string FireArea
        {
            set { _firearea = value; }
            get { return _firearea; }
        }
        /// <summary>
        /// 火灾财产损失
        /// </summary>
        public string FireEstateLoss
        {
            set { _fireestateloss = value; }
            get { return _fireestateloss; }
        }
        /// <summary>
        /// 火灾伤人数
        /// </summary>
        public int? FireHPeople
        {
            set { _firehpeople = value; }
            get { return _firehpeople; }
        }
        /// <summary>
        /// 火灾死人数
        /// </summary>
        public int? FireDPeople
        {
            set { _firedpeople = value; }
            get { return _firedpeople; }
        }
        /// <summary>
        /// 群众活动举办地址
        /// </summary>
        public string MassSportsAds
        {
            set { _masssportsads = value; }
            get { return _masssportsads; }
        }
        /// <summary>
        /// 检查情况[0合格/1不合格]
        /// </summary>
        public int? MassSportsResult
        {
            set { _masssportsresult = value; }
            get { return _masssportsresult; }
        }
        /// <summary>
        /// 行政处罚类型
        /// </summary>
        public string PunishTypeID
        {
            set { _punishtypeid = value; }
            get { return _punishtypeid; }
        }
        /// <summary>
        /// 罚款金额
        /// </summary>
        public decimal? PunishFinePay
        {
            set { _punishfinepay = value; }
            get { return _punishfinepay; }
        }
        /// <summary>
        /// 违法人
        /// </summary>
        public string PunishParts
        {
            set { _punishparts = value; }
            get { return _punishparts; }
        }
        /// <summary>
        /// 临时查封场所地址
        /// </summary>
        public string TempClose
        {
            set { _tempclose = value; }
            get { return _tempclose; }
        }
        /// <summary>
        /// 临时查封天数
        /// </summary>
        public int? TempDay
        {
            set { _tempday = value; }
            get { return _tempday; }
        }
        /// <summary>
        /// 强制执行对象地址
        /// </summary>
        public string ForceRunAds
        {
            set { _forcerunads = value; }
            get { return _forcerunads; }
        }
        /// <summary>
        /// 强制执行的行政处罚编号
        /// </summary>
        public string ForcePunish
        {
            set { _forcepunish = value; }
            get { return _forcepunish; }
        }
        /// <summary>
        /// 诉讼人（单位）地址
        /// </summary>
        public string ApplyReviewPeople
        {
            set { _applyreviewpeople = value; }
            get { return _applyreviewpeople; }
        }
        /// <summary>
        /// 申请国家赔偿人（单位）地址
        /// </summary>
        public string CountryPayAds
        {
            set { _countrypayads = value; }
            get { return _countrypayads; }
        }
        /// <summary>
        /// 嫌疑人性别[男和女]
        /// </summary>
        public string PenalDocSex
        {
            set { _penaldocsex = value; }
            get { return _penaldocsex; }
        }
        /// <summary>
        /// 出生年份
        /// </summary>
        public string PenalDocBirthday
        {
            set { _penaldocbirthday = value; }
            get { return _penaldocbirthday; }
        }
        /// <summary>
        /// 民族
        /// </summary>
        public string PenalDocNation
        {
            set { _penaldocnation = value; }
            get { return _penaldocnation; }
        }
        /// <summary>
        /// 嫌疑人地址
        /// </summary>
        public string PenalDocAds
        {
            set { _penaldocads = value; }
            get { return _penaldocads; }
        }
        /// <summary>
        /// 案发地址
        /// </summary>
        public string PenalDocCrimeAds
        {
            set { _penaldoccrimeads = value; }
            get { return _penaldoccrimeads; }
        }
        /// <summary>
        /// 案件危害后果
        /// </summary>
        public string PenalDocResult
        {
            set { _penaldocresult = value; }
            get { return _penaldocresult; }
        }
        /// <summary>
        /// 承办单位编号
        /// </summary>
        public int? EnforcementID
        {
            set { _enforcementid = value; }
            get { return _enforcementid; }
        }
        /// <summary>
        /// 执法档案承办单位名称
        /// </summary>
        public string EnforcementName
        {
            set { _enforcementname = value; }
            get { return _enforcementname; }
        }
        /// <summary>
        /// 承办人主办人
        /// </summary>
        public string EnforcementPeople
        {
            set { _enforcementpeople = value; }
            get { return _enforcementpeople; }
        }
        /// <summary>
        /// 承办人协办人
        /// </summary>
        public string EnforcementPeople2
        {
            set { _enforcementpeople2 = value; }
            get { return _enforcementpeople2; }
        }
        /// <summary>
        /// 执法档案起时间
        /// </summary>
        public string EnforcementDate
        {
            set { _enforcementdate = value; }
            get { return _enforcementdate; }
        }
        /// <summary>
        /// 执法档案止时间
        /// </summary>
        public string EnforcementDate2
        {
            set { _enforcementdate2 = value; }
            get { return _enforcementdate2; }
        }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string BuildUnitName
        {
            set { _buildunitname = value; }
            get { return _buildunitname; }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string BuildItemName
        {
            set { _builditemname = value; }
            get { return _builditemname; }
        }
        /// <summary>
        /// 检查单位名称
        /// </summary>
        public string CheckUnitName
        {
            set { _checkunitname = value; }
            get { return _checkunitname; }
        }
        /// <summary>
        /// 验收工程单位
        /// </summary>
        public string CheckItemName
        {
            set { _checkitemname = value; }
            get { return _checkitemname; }
        }
        /// <summary>
        /// 举报人
        /// </summary>
        public string ComplainPeople
        {
            set { _complainpeople = value; }
            get { return _complainpeople; }
        }
        /// <summary>
        /// 被举报人
        /// </summary>
        public string ComplainNPeople
        {
            set { _complainnpeople = value; }
            get { return _complainnpeople; }
        }
        /// <summary>
        /// 举报的行为
        /// </summary>
        public string CompainN
        {
            set { _compainn = value; }
            get { return _compainn; }
        }
        /// <summary>
        /// 举办人
        /// </summary>
        public string MassSportsPeople
        {
            set { _masssportspeople = value; }
            get { return _masssportspeople; }
        }
        /// <summary>
        /// 活动名称
        /// </summary>
        public string MassSportName
        {
            set { _masssportname = value; }
            get { return _masssportname; }
        }
        /// <summary>
        /// 火灾的地址
        /// </summary>
        public string FireAds
        {
            set { _fireads = value; }
            get { return _fireads; }
        }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string FireUnitName
        {
            set { _fireunitname = value; }
            get { return _fireunitname; }
        }
        /// <summary>
        /// 时间
        /// </summary>
        public string FireDateTime
        {
            set { _firedatetime = value; }
            get { return _firedatetime; }
        }
        /// <summary>
        /// 火灾性质
        /// </summary>
        public string FireN
        {
            set { _firen = value; }
            get { return _firen; }
        }
        /// <summary>
        /// 违法主体
        /// </summary>
        public string PunishMain
        {
            set { _punishmain = value; }
            get { return _punishmain; }
        }
        /// <summary>
        /// 处罚案由
        /// </summary>
        public string PunishWhy
        {
            set { _punishwhy = value; }
            get { return _punishwhy; }
        }
        /// <summary>
        /// 查封单位名称
        /// </summary>
        public string TempUintName
        {
            set { _tempuintname = value; }
            get { return _tempuintname; }
        }
        /// <summary>
        /// 行为
        /// </summary>
        public string TempN
        {
            set { _tempn = value; }
            get { return _tempn; }
        }
        /// <summary>
        /// 定性
        /// </summary>
        public string TempDX
        {
            set { _tempdx = value; }
            get { return _tempdx; }
        }
        /// <summary>
        /// 执行单位名称
        /// </summary>
        public string ForceUnitName
        {
            set { _forceunitname = value; }
            get { return _forceunitname; }
        }
        /// <summary>
        /// 行为
        /// </summary>
        public string ForceN
        {
            set { _forcen = value; }
            get { return _forcen; }
        }
        /// <summary>
        /// 申请复议
        /// </summary>
        public string ApplyFY
        {
            set { _applyfy = value; }
            get { return _applyfy; }
        }
        /// <summary>
        /// 国家申请主体
        /// </summary>
        public string CountryMain
        {
            set { _countrymain = value; }
            get { return _countrymain; }
        }
        /// <summary>
        /// 嫌疑人姓名
        /// </summary>
        public string PenalName
        {
            set { _penalname = value; }
            get { return _penalname; }
        }
        /// <summary>
        /// 嫌疑人罪名
        /// </summary>
        public string PenalZN
        {
            set { _penalzn = value; }
            get { return _penalzn; }
        }
        /// <summary>
        /// 操作人区县代码
        /// </summary>
        public string EnteCountyId
        {
            set { _enteCountyId = value; }
            get { return _enteCountyId; }
        }
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string EnteUserName
        {
            set { _enteUserName = value; }
            get { return _enteUserName; }
        }
        /// <summary>
        /// 临时执法时间
        /// </summary>
        public string tmp_Data
        {
            set { _tmp_Data = value; }
            get { return _tmp_Data; }
        }
        /// <summary>
        /// 档案库ID
        /// </summary>
        public string FileLibraryID
        {
            set { _FileLibraryID = value; }
            get { return _FileLibraryID; }
        }
        /// <summary>
        /// 档案库名称
        /// </summary>
        public string FileLibraryName
        {
            set { _FileLibraryName = value; }
            get { return _FileLibraryName; }
        }
        /// <summary>
        /// 数据类型 0默认正常[1已销毁, 2已借阅, 3已移交]
        /// </summary>
        public int SJLX
        {
            set { _sjlx = value; }
            get { return _sjlx; }
        }
        /// <summary>
        /// 归档时间
        /// </summary>
        public string FileLibraryData
        {
            set { _FileLibraryData = value; }
            get { return _FileLibraryData; }
        }

        /// <summary>
        /// 过火面积
        /// </summary>
        public string Ghmj
        {
            set { _Ghmj = value; }
            get { return _Ghmj; }
        }

        /// <summary>
        /// 财产损失
        /// </summary>
        public string Ccss
        {
            set { _Ccss = value; }
            get { return _Ccss; }
        }

        /// <summary>
        /// 伤人数
        /// </summary>
        public string Srs
        {
            set { _Srs = value; }
            get { return _Srs; }
        }

        /// <summary>
        /// 亡人数
        /// </summary>
        public string Wrs
        {
            set { _Wrs = value; }
            get { return _Wrs; }
        }
        

        /// <summary>
        /// 建设工程地址
        /// </summary>
        public string BuildAdsArea
        {
            set { _BuildAdsArea = value; }
            get { return _BuildAdsArea; }
        }

        /// <summary>
        /// 检查地址
        /// </summary>
        public string CheckAdsArea
        {
            set { _CheckAdsArea = value; }
            get { return _CheckAdsArea; }
        }

        /// <summary>
        /// 举报建设工程地址
        /// </summary>
        public string ComplainAdsArea
        {
            set { _ComplainAdsArea = value; }
            get { return _ComplainAdsArea; }
        }

        /// <summary>
        /// 活动举办地址
        /// </summary>
        public string MassSportsAdsArea
        {
            set { _MassSportsAdsArea = value; }
            get { return _MassSportsAdsArea; }
        }

        /// <summary>
        /// 违法人（单位）地址
        /// </summary>
        public string PunishAdsArea
        {
            set { _PunishAdsArea = value; }
            get { return _PunishAdsArea; }
        }

        /// <summary>
        /// 临时查封场所地址
        /// </summary>
        public string TempCloseArea
        {
            set { _TempCloseArea = value; }
            get { return _TempCloseArea; }
        }

        /// <summary>
        /// 强制执行对象地址
        /// </summary>
        public string ForceRunAdsArea
        {
            set { _ForceRunAdsArea = value; }
            get { return _ForceRunAdsArea; }
        }

        /// <summary>
        /// 申请复议、诉讼人（单位）地址
        /// </summary>
        public string ApplyFYArea
        {
            set { _ApplyFYArea = value; }
            get { return _ApplyFYArea; }
        }

        /// <summary>
        /// 申请国家赔偿人（单位）地址
        /// </summary>
        public string CountryPayAdsArea
        {
            set { _CountryPayAdsArea = value; }
            get { return _CountryPayAdsArea; }
        }

        /// <summary>
        /// 嫌疑人地址
        /// </summary>
        public string PenalDocAdsArea
        {
            set { _PenalDocAdsArea = value; }
            get { return _PenalDocAdsArea; }
        }

        /// <summary>
        /// 案发地址
        /// </summary>
        public string PenalDocCrimeAdsArea
        {
            set { _PenalDocCrimeAdsArea = value; }
            get { return _PenalDocCrimeAdsArea; }
        }

        /// <summary>
        /// 检查性质是否复查
        /// </summary>
        public string CheckNaturefc
        {
            set { _CheckNaturefc = value; }
            get { return _CheckNaturefc; }
        }

        /// <summary>
        /// 临时字段
        /// </summary>
        public string NumStatic
        {
            set { _NumStatic = value; }
            get { return _NumStatic; }
        }

        /// <summary>
        /// 移交时间
        /// </summary>
        public string FileTransferDate
        {
            set { _FileTransferDate = value; }
            get { return _FileTransferDate; }
        }
        #endregion

        /// <summary>
        /// 接受时间
        /// </summary>
        public string ReceiptTime
        {
            set { _ReceiptTime = value; }
            get { return _ReceiptTime; }
        }

        /// <summary>
        /// 排架号[列]
        /// </summary>
        public string Columns
        {
            set { _Columns = value; }
            get { return _Columns; }
        }

        /// <summary>
        /// 排架号[柜]
        /// </summary>
        public string Cupboard
        {
            set { _Cupboard = value; }
            get { return _Cupboard; }
        }

        /// <summary>
        /// 排架号[架]
        /// </summary>
        public string Frame
        {
            set { _Frame = value; }
            get { return _Frame; }
        }

        #endregion Model

    }
}

