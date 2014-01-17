using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ToolsCommon;
using ToolsDal;
public partial class Manager_DocumentInfor_FileEnter_FileEnterEdit : BasePage
{

    //实例化对象
    FileDirectoryDal filedal = new FileDirectoryDal();
    SaveDeadlineDal savedal = new SaveDeadlineDal();
    PunishTypeDal pusdal = new PunishTypeDal();
    FileEnterDal fedal = new FileEnterDal();
    FileClassDal fcdal = new FileClassDal();
    OrganizerDal ordal = new OrganizerDal();
    FileLibraryDal fldal = new FileLibraryDal();   //档案库名称
    AreaDal ardal = new AreaDal();    //行政区
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.fStarttime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.BindDataList();
            this.GetValue();

        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    private void BindDataList()
    {
        //执法案卷类别名称
        DataTable dtSource = Utility.GetFileClassTree(); //获取数据信息

        if (AccessDataSet.HasDataTable(dtSource))
        {
            rptList.DataSource = dtSource;
            rptList.DataBind();
        }
        //执法档案目录号
        DataTable dtfile = filedal.GetDataTable("");
        if (AccessDataSet.HasDataTable(dtfile))
        {
            FileDirectoryID.DataSource = dtfile;
            this.FileDirectoryID.DataTextField = "FileDirName";
            this.FileDirectoryID.DataValueField = "ID";
            this.FileDirectoryID.DataBind();
            this.FileDirectoryID.Items.Insert(0, new ListItem("--请选择--", ""));
        }
        //执法档案保管期限
        DataTable dtS = savedal.GetDataTable("");
        if (AccessDataSet.HasDataTable(dtS))
        {
            SaveDeadlineID.DataSource = dtS;
            this.SaveDeadlineID.DataTextField = "YearName";
            this.SaveDeadlineID.DataValueField = "ID";
            this.SaveDeadlineID.DataBind();
            this.SaveDeadlineID.Items.Insert(0, new ListItem("--请选择--", ""));
        }
        //执法档案处罚类型
        DataTable dtwy = pusdal.GetDataTable("");
        if (AccessDataSet.HasDataTable(dtwy))
        {
            rxwhy.DataSource = dtwy;
            rxwhy.DataBind();
        }
        //执法档案承办单位
        DataTable dtor = ordal.GetDataTable("");
        if (AccessDataSet.HasDataTable(dtor))
        {
            this.drop_EnforcementName.DataSource = dtor;
            this.drop_EnforcementName.DataTextField = "OrganizerName";
            this.drop_EnforcementName.DataValueField = "ID";
            this.drop_EnforcementName.DataBind();
            this.drop_EnforcementName.Items.Insert(0, new ListItem("--请选择--", ""));
        }
        this.drop_EnforcementName.SelectedValue = LoginUser.OrganizerId;
        this.drop_EnforcementName.Enabled = false;
        //执法档案库室
        DataTable dtfl = fldal.GetDataTable(" and qxdm='" + LoginUser.CountyId + "'");
        if (AccessDataSet.HasDataTable(dtfl))
        {
            this.drop_FileLibraryName.DataSource = dtfl;
            this.drop_FileLibraryName.DataTextField = "FileLibraryName";
            this.drop_FileLibraryName.DataValueField = "ID";
            this.drop_FileLibraryName.DataBind();
            this.drop_FileLibraryName.Items.Insert(0, new ListItem("--请选择--", ""));
        }

        //民族信息
        DataTable dtmz = PublicQuery.GetDataMZTable();
        if (AccessDataSet.HasDataTable(dtmz))
        {
            this.PenalDocNation.DataSource = dtmz;
            this.PenalDocNation.DataTextField = "MzName";
            this.PenalDocNation.DataValueField = "MzId";
            this.PenalDocNation.DataBind();
        }

        //行政区名称
        #region 行政区名称
        DataTable dtxzq = ardal.GetDataTable("");
        //建设工程地址
        if (AccessDataSet.HasDataTable(dtxzq))
        {
            this.BuildAdsArea.DataSource = dtxzq;
            this.BuildAdsArea.DataTextField = "Name";
            this.BuildAdsArea.DataValueField = "ID";
            this.BuildAdsArea.DataBind();
            this.BuildAdsArea.Items.Insert(0, new ListItem("--请选择--", ""));
        }
        //检查地址
        if (AccessDataSet.HasDataTable(dtxzq))
        {
            this.CheckAdsArea.DataSource = dtxzq;
            this.CheckAdsArea.DataTextField = "Name";
            this.CheckAdsArea.DataValueField = "ID";
            this.CheckAdsArea.DataBind();
            this.CheckAdsArea.Items.Insert(0, new ListItem("--请选择--", ""));
        }
        //举报建设工程地址
        if (AccessDataSet.HasDataTable(dtxzq))
        {
            this.ComplainAdsArea.DataSource = dtxzq;
            this.ComplainAdsArea.DataTextField = "Name";
            this.ComplainAdsArea.DataValueField = "ID";
            this.ComplainAdsArea.DataBind();
            this.ComplainAdsArea.Items.Insert(0, new ListItem("--请选择--", ""));
        }
        //活动举办地址
        if (AccessDataSet.HasDataTable(dtxzq))
        {
            this.MassSportsAdsArea.DataSource = dtxzq;
            this.MassSportsAdsArea.DataTextField = "Name";
            this.MassSportsAdsArea.DataValueField = "ID";
            this.MassSportsAdsArea.DataBind();
            this.MassSportsAdsArea.Items.Insert(0, new ListItem("--请选择--", ""));
        }
        //违法人（单位）地址
        if (AccessDataSet.HasDataTable(dtxzq))
        {
            this.PunishAdsArea.DataSource = dtxzq;
            this.PunishAdsArea.DataTextField = "Name";
            this.PunishAdsArea.DataValueField = "ID";
            this.PunishAdsArea.DataBind();
            this.PunishAdsArea.Items.Insert(0, new ListItem("--请选择--", ""));
        }
        //临时查封场所地址
        if (AccessDataSet.HasDataTable(dtxzq))
        {
            this.TempCloseArea.DataSource = dtxzq;
            this.TempCloseArea.DataTextField = "Name";
            this.TempCloseArea.DataValueField = "ID";
            this.TempCloseArea.DataBind();
            this.TempCloseArea.Items.Insert(0, new ListItem("--请选择--", ""));
        }
        //强制执行对象地址
        if (AccessDataSet.HasDataTable(dtxzq))
        {
            this.ForceRunAdsArea.DataSource = dtxzq;
            this.ForceRunAdsArea.DataTextField = "Name";
            this.ForceRunAdsArea.DataValueField = "ID";
            this.ForceRunAdsArea.DataBind();
            this.ForceRunAdsArea.Items.Insert(0, new ListItem("--请选择--", ""));
        }
        //申请复议、诉讼人（单位）地址
        if (AccessDataSet.HasDataTable(dtxzq))
        {
            this.ApplyFYArea.DataSource = dtxzq;
            this.ApplyFYArea.DataTextField = "Name";
            this.ApplyFYArea.DataValueField = "ID";
            this.ApplyFYArea.DataBind();
            this.ApplyFYArea.Items.Insert(0, new ListItem("--请选择--", ""));
        }
        //申请国家赔偿人（单位）地址
        if (AccessDataSet.HasDataTable(dtxzq))
        {
            this.CountryPayAdsArea.DataSource = dtxzq;
            this.CountryPayAdsArea.DataTextField = "Name";
            this.CountryPayAdsArea.DataValueField = "ID";
            this.CountryPayAdsArea.DataBind();
            this.CountryPayAdsArea.Items.Insert(0, new ListItem("--请选择--", ""));
        }
        //嫌疑人地址
        if (AccessDataSet.HasDataTable(dtxzq))
        {
            this.PenalDocAdsArea.DataSource = dtxzq;
            this.PenalDocAdsArea.DataTextField = "Name";
            this.PenalDocAdsArea.DataValueField = "ID";
            this.PenalDocAdsArea.DataBind();
            this.PenalDocAdsArea.Items.Insert(0, new ListItem("--请选择--", ""));
        }
        //案发地址
        if (AccessDataSet.HasDataTable(dtxzq))
        {
            this.PenalDocCrimeAdsArea.DataSource = dtxzq;
            this.PenalDocCrimeAdsArea.DataTextField = "Name";
            this.PenalDocCrimeAdsArea.DataValueField = "ID";
            this.PenalDocCrimeAdsArea.DataBind();
            this.PenalDocCrimeAdsArea.Items.Insert(0, new ListItem("--请选择--", ""));
        }
        #endregion

        //如果没有录入人默认显示当前用户名
        this.txtEnterPeople.Text = LoginUser.GetUserName;
    }
    private void GetValue()
    {
        DataRow dr = fedal.GetRow(this.GetRequestInt("id")); //获取传递的参数，编辑时ID主键
        if (dr != null)
        {
            //执法档案库室
            drop_FileLibraryName.Items.Clear();
            DataTable dtfl = null;
            if (LoginUser.CountyId=="420100")
            {
                dtfl = fldal.GetDataTable(" ");
            }
            else
            {
                dtfl = fldal.GetDataTable(" and qxdm='" + LoginUser.CountyId + "'");
            }
            if (AccessDataSet.HasDataTable(dtfl))
            {
                this.drop_FileLibraryName.DataSource = dtfl;
                this.drop_FileLibraryName.DataTextField = "FileLibraryName";
                this.drop_FileLibraryName.DataValueField = "ID";
                this.drop_FileLibraryName.DataBind();
                this.drop_FileLibraryName.Items.Insert(0, new ListItem("--请选择--", ""));
            }
            this.FileFondsNo.Text = dr["FileFondsNo"].ToStr();
            this.FilesNum.Text = dr["FilesNum"].ToStr();
            this.FileDirectoryID.SelectedValue = dr["FileDirectoryID"].ToStr();
            this.SaveDeadlineID.SelectedValue = dr["SaveDeadlineID"].ToStr();
            this.BuildAds.Text = dr["BuildAds"].ToStr();
            this.BuildCheckT.Text = dr["BuildCheckT"].ToStr();
            this.BuildFilingT.Text = dr["BuildFilingT"].ToStr();
            this.BuildArea.Text = dr["BuildArea"].ToStr();
            this.buildingHeight.Text = dr["buildingHeight"].ToStr();
            this.BuildALicense.Text = dr["BuildALicense"].ToStr();
            this.CheckAds.Text = dr["CheckAds"].ToStr();
            this.CheckNature.Text = dr["CheckNature"].ToStr();
            this.CheckResult.Text = dr["CheckResult"].ToStr();
            this.ComplainAds.Text = dr["ComplainAds"].ToStr();
            this.ComplainResult.Text = dr["ComplainResult"].ToStr();
            this.FireNature.Text = dr["FireNature"].ToStr();
            this.FireArea.Text = dr["FireArea"].ToStr();
            this.FireEstateLoss.Text = dr["FireEstateLoss"].ToStr();
            this.FireHPeople.Text = dr["FireHPeople"].ToStr();
            this.FireDPeople.Text = dr["FireDPeople"].ToStr();
            this.MassSportsAds.Text = dr["MassSportsAds"].ToStr();
            this.MassSportsResult.Text = dr["MassSportsResult"].ToStr();
            string ptypeID = dr["PunishTypeID"].ToStr();
            if (ptypeID.IndexOf('0') != -1) this.PunishTypeID0.Checked = true;
            if (ptypeID.IndexOf('1') != -1) this.PunishTypeID1.Checked = true;
            if (ptypeID.IndexOf('2') != -1) this.PunishTypeID2.Checked = true;
            if (ptypeID.IndexOf('3') != -1) this.PunishTypeID3.Checked = true;
            if (ptypeID.IndexOf('4') != -1) this.PunishTypeID4.Checked = true;
            //this.PunishTypeID.Text = dr["PunishTypeID"].ToStr();
            this.PunishFinePay.Text = dr["PunishFinePay"].ToStr();
            this.PunishParts.Text = dr["PunishParts"].ToStr();
            this.TempClose.Text = dr["TempClose"].ToStr();
            this.TempDay.Text = dr["TempDay"].ToStr();
            this.ForceRunAds.Text = dr["ForceRunAds"].ToStr();
            this.ForcePunish.Text = dr["ForcePunish"].ToStr();
            this.ApplyReviewPeople.Text = dr["ApplyReviewPeople"].ToStr();
            this.CountryPayAds.Text = dr["CountryPayAds"].ToStr();
            this.PenalDocSex.Text = dr["PenalDocSex"].ToStr();
            this.PenalDocBirthday.Text = dr["PenalDocBirthday"].ToStr();
            this.PenalDocNation.Text = dr["PenalDocNation"].ToStr();
            this.PenalDocAds.Text = dr["PenalDocAds"].ToStr();
            this.PenalDocCrimeAds.Text = dr["PenalDocCrimeAds"].ToStr();
            //this.PenalDocResult.Text = dr["PenalDocResult"].ToStr(); //案件危害后果
            this.BuildUnitName.Text = dr["BuildUnitName"].ToStr();
            this.BuildItemName.Text = dr["BuildItemName"].ToStr();
            this.CheckUnitName.Text = dr["CheckUnitName"].ToStr();
            this.ComplainPeople.Text = dr["ComplainPeople"].ToStr();
            this.ComplainNPeople.Text = dr["ComplainNPeople"].ToStr();
            this.CompainN.Text = dr["CompainN"].ToStr();
            this.MassSportsPeople.Text = dr["MassSportsPeople"].ToStr();
            this.MassSportName.Text = dr["MassSportName"].ToStr();
            this.FireAds.Text = dr["FireAds"].ToStr();
            this.FireUnitName.Text = dr["FireUnitName"].ToStr();
            this.FireDateTime.Text = dr["FireDateTime"].ToStr();
            this.FireN.Text = dr["FireN"].ToStr();
            this.PunishMain.Text = dr["PunishMain"].ToStr();
            this.TempUintName.Text = dr["TempUintName"].ToStr();
            this.TempN.Text = dr["TempN"].ToStr();
            this.TempDX.Text = dr["TempDX"].ToStr();
            this.ForceUnitName.Text = dr["ForceUnitName"].ToStr();
            this.ForceN.Text = dr["ForceN"].ToStr();
            this.ApplyFY.Text = dr["ApplyFY"].ToStr();
            this.CountryMain.Text = dr["CountryMain"].ToStr();
            this.PenalName.Text = dr["PenalName"].ToStr();
            this.PenalZN.Text = dr["PenalZN"].ToStr();
            this.ApplyNContent.Text = dr["ApplyNContent"].ToStr();
            this.PunishAds.Text = dr["PunishAds"].ToStr();
            this.ApplyMain.Text = dr["ApplyMain"].ToStr();
            //修改后的代码
            this.drop_EnforcementName.SelectedValue = dr["EnforcementID"].ToStr();
            this.txt_EnforcementPeople.Text = dr["EnforcementPeople"].ToStr();
            this.txt_EnforcementPeople2.Text = dr["EnforcementPeople2"].ToStr();
            this.txt_EnforcementDate.Text = dr["EnforcementDate"].ToStr();
            this.txt_EnforcementDate2.Text = dr["EnforcementDate2"].ToStr();
            this.txtEnterPeople.Text = dr["EnterPeople"].ToStr();
            this.fStarttime.Text = Convert.ToDateTime(dr["EnterDate"]).ToString("yyyy-MM-dd"); //录入时间自动生成
            this.drop_FileLibraryName.SelectedValue = dr["FileLibraryID"].ToStr();
            this.PicDocumentNo1.Text = dr["PicDocumentNo"].ToStr();
            this.PicDicL1.Text = dr["PicDicL"].ToStr();
            this.EngDroping1.Text = dr["EngDroping"].ToStr();

            this.PicDocumentNo2.Text = dr["PicDocumentNo"].ToStr();
            this.PicDicL2.Text = dr["PicDicL"].ToStr();
            this.EngDroping2.Text = dr["EngDroping"].ToStr();
            this.YesUnit.Text = dr["YesUnit"].ToStr();
            this.CheckItemName.Text = dr["CheckItemName"].ToStr();

            this.txt_ghmj.Text = dr["Ghmj"].ToStr();
            this.txt_ccss.Text = dr["Ccss"].ToStr();
            this.txt_srs.Text = dr["Srs"].ToStr();
            this.txt_wrs.Text = dr["Wrs"].ToStr();

            //2013-12-30 行政区
            this.BuildAdsArea.SelectedValue = dr["BuildAdsArea"].ToStr();
            this.CheckAdsArea.SelectedValue = dr["CheckAdsArea"].ToStr();
            this.ComplainAdsArea.SelectedValue = dr["ComplainAdsArea"].ToStr();
            this.MassSportsAdsArea.SelectedValue = dr["MassSportsAdsArea"].ToStr();
            this.PunishAdsArea.SelectedValue = dr["PunishAdsArea"].ToStr();
            this.TempCloseArea.SelectedValue = dr["TempCloseArea"].ToStr();
            this.ForceRunAdsArea.SelectedValue = dr["ForceRunAdsArea"].ToStr();
            this.ApplyFYArea.SelectedValue = dr["ApplyFYArea"].ToStr();
            this.CountryPayAdsArea.SelectedValue = dr["CountryPayAdsArea"].ToStr();
            this.PenalDocAdsArea.SelectedValue = dr["PenalDocAdsArea"].ToStr();
            this.PenalDocCrimeAdsArea.SelectedValue = dr["PenalDocCrimeAdsArea"].ToStr();

            //2013-12-31 排架号
            this.Columns.Text = dr["Columns"].ToStr();   //列
            this.Cupboard.Text = dr["Cupboard"].ToStr(); //柜
            this.Frame.Text = dr["Frame"].ToStr();       //架

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int fid = ((Label)rptList.Items[i].FindControl("FileClassID")).Text.ToInt32();

                if (fid == dr["FileClassID"].ToInt32())
                {
                    DataRow drFc = fcdal.GetRow(fid);
                    int intype = 0;
                    if (drFc != null)
                        intype = drFc["Intype"].ToInt32();

                    CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cl1_000");
                    cb.Checked = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "script", "check(0," + intype + ",0,0);", true);
                }
            }

            for (int i = 0; i < rxwhy.Items.Count; i++)
            {
                int fid = ((Label)rxwhy.Items[i].FindControl("PunishWhy")).Text.ToInt32();

                if (fid == dr["PunishWhy"].ToInt32())
                {
                    DataRow drFc2 = fcdal.GetRow(fid);
                    int intype2 = 0;
                    if (drFc2 != null)
                        intype2 = drFc2["id"].ToInt32();

                    CheckBox cb2 = (CheckBox)rxwhy.Items[i].FindControl("ckb6");
                    cb2.Checked = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "script", "check(0,'cc1'," + intype2 + ",1);", true);
                }
            }

            if (dr["CheckNaturefc"].ToInt32() == 1)
            {
                this.CheckNaturefc.Checked = true;
            }

            if (this.GetRequestInt("flag") == 1)  //如果是查看则禁用掉所有文本框
                Utility.initControl(Page, "");
        }
    }

    #region 保存档案管理录入
    /// <summary>
    /// 保存档案管理录入
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int FileClassID = 0;
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int fid = ((Label)rptList.Items[i].FindControl("FileClassID")).Text.ToInt32();
            CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cl1_000");
            if (cb.Checked)
                FileClassID = fid;
        }

        int FileDirectoryID = this.GetRequestInt("FileDirectoryID");
        int SaveDeadlineID = this.GetRequestInt("SaveDeadlineID");
        //获取界面数值赋值给model对象    
        string FileFondsNo = this.GetRequestStr("FileFondsNo"); //"QZH-" + DateTime.Now.ToStr("yyyyMMddhhmmss") + "01";
        string FilesNum = this.GetRequestStr("FilesNum");
        string EnterPeople = this.GetRequestStr("txtEnterPeople");  //档案录入人
        DateTime EnterDate = Convert.ToDateTime(this.GetRequestStr("fStarttime")); //档案录入时间自动生成
        string BuildAds = this.GetRequestStr("BuildAds");
        string BuildCheckT = this.GetRequestStr("BuildCheckT");
        string BuildFilingT = this.GetRequestStr("BuildFilingT");
        string BuildArea = this.GetRequestStr("BuildArea");
        int BuildALicense = this.GetRequestInt("BuildALicense");
        string CheckAds = this.GetRequestStr("CheckAds");
        string CheckNature = this.GetRequestStr("CheckNature");
        int CheckResult = this.GetRequestInt("CheckResult");
        string ComplainAds = this.GetRequestStr("ComplainAds");
        int ComplainResult = this.GetRequestInt("ComplainResult");
        string FireNature = this.GetRequestStr("FireNature");
        string FireArea = this.GetRequestStr("FireArea");
        string FireEstateLoss = this.GetRequestStr("FireEstateLoss");
        int FireHPeople = this.GetRequestInt("FireHPeople");
        int FireDPeople = this.GetRequestInt("FireDPeople");
        string MassSportsAds = this.GetRequestStr("MassSportsAds");
        int MassSportsResult = this.GetRequestInt("MassSportsResult");
        //string PunishTypeID = this.GetRequestStr("PunishTypeID");
        string PunishTypeID = "|";
        if (PunishTypeID0.Checked == true) PunishTypeID += "0|";
        if (PunishTypeID1.Checked == true) PunishTypeID += "1|";
        if (PunishTypeID2.Checked == true) PunishTypeID += "2|";
        if (PunishTypeID3.Checked == true) PunishTypeID += "3|";
        if (PunishTypeID4.Checked == true) PunishTypeID += "4|";
        double PunishFinePay = this.GetRequestDouble("PunishFinePay");
        string PunishParts = this.GetRequestStr("PunishParts");
        string TempClose = this.GetRequestStr("TempClose");
        int TempDay = this.GetRequestInt("TempDay");
        string ForceRunAds = this.GetRequestStr("ForceRunAds");
        string ForcePunish = this.GetRequestStr("ForcePunish");
        string ApplyReviewPeople = this.GetRequestStr("ApplyReviewPeople");
        string CountryPayAds = this.GetRequestStr("CountryPayAds");
        string PenalDocSex = this.GetRequestStr("PenalDocSex");
        string PenalDocBirthday = this.GetRequestStr("PenalDocBirthday");
        string PenalDocNation = this.GetRequestStr("PenalDocNation");
        string PenalDocAds = this.GetRequestStr("PenalDocAds");
        string PenalDocCrimeAds = this.GetRequestStr("PenalDocCrimeAds");

        int EnforcementID = Convert.ToInt32(this.drop_EnforcementName.SelectedItem.Value);
        string EnforcementName = this.drop_EnforcementName.SelectedItem.Text;
        string EnforcementPeople = this.GetRequestStr("txt_EnforcementPeople");
        string EnforcementPeople2 = this.GetRequestStr("txt_EnforcementPeople2");
        string EnforcementDate = this.GetRequestStr("txt_EnforcementDate");
        string EnforcementDate2 = this.GetRequestStr("txt_EnforcementDate2");
        string BuildUnitName = this.GetRequestStr("BuildUnitName");
        string BuildItemName = this.GetRequestStr("BuildItemName");
        string CheckUnitName = this.GetRequestStr("CheckUnitName");
        string ComplainPeople = this.GetRequestStr("ComplainPeople");
        string ComplainNPeople = this.GetRequestStr("ComplainNPeople");
        string CompainN = this.GetRequestStr("CompainN");
        string MassSportsPeople = this.GetRequestStr("MassSportsPeople");
        string MassSportName = this.GetRequestStr("MassSportName");
        string FireAds = this.GetRequestStr("FireAds");
        string FireUnitName = this.GetRequestStr("FireUnitName");
        string FireDateTime = this.GetRequestStr("FireDateTime");
        string FireN = this.GetRequestStr("FireN");
        string PunishMain = this.GetRequestStr("PunishMain");
        string PunishWhy = string.Empty; //= this.GetRequestStr("PunishWhy");

        for (int i = 0; i < rxwhy.Items.Count; i++)
        {
            string fid2 = ((Label)rxwhy.Items[i].FindControl("PunishWhy")).Text;
            CheckBox cb2 = (CheckBox)rxwhy.Items[i].FindControl("ckb6");
            if (cb2.Checked)
                PunishWhy = fid2;
        }

        string TempUintName = this.GetRequestStr("TempUintName");
        string TempN = this.GetRequestStr("TempN");
        string TempDX = this.GetRequestStr("TempDX");
        string ForceUnitName = this.GetRequestStr("ForceUnitName");
        string ForceN = this.GetRequestStr("ForceN");
        string ApplyFY = this.GetRequestStr("ApplyFY");
        string CountryMain = this.GetRequestStr("CountryMain");
        string PenalName = this.GetRequestStr("PenalName");
        string PenalZN = this.GetRequestStr("PenalZN");
        string ApplyNContent = this.GetRequestStr("ApplyNContent");
        string PunishAds = this.GetRequestStr("PunishAds");
        string ApplyMain = this.GetRequestStr("ApplyMain");
        string YesUnit = this.GetRequestStr("YesUnit");
        string buildingHeight = this.GetRequestStr("buildingHeight");
        string CheckItemName = this.GetRequestStr("CheckItemName");
        //修改
        string Ghmj = this.GetRequestStr("txt_ghmj");  //过火面积
        string Ccss = this.GetRequestStr("txt_ccss");  //财产损失
        string Srs = this.GetRequestStr("txt_srs");    //伤人数
        string Wrs = this.GetRequestStr("txt_wrs");    //亡人数
        string PenalDocResult = Ghmj + "," + Ccss + "," + Srs + "," + Wrs;   //案件危害后果

        //    if (this.PicDocumentNo1.Text!="")
        //{
        //     string PicDocumentNo
        //}
        DataRow drFc = fcdal.GetRow(FileClassID);
        string FileClassName = string.Empty;
        if (drFc != null)
        {
            FileClassName = drFc["FileName"].ToStr();
        }
        string PicDocumentNo = string.Empty;
        string PicDicL = string.Empty;
        string EngDroping = string.Empty;
        if (FileClassName == "开业(使用)前检查卷")
        {
            PicDocumentNo = this.GetRequestStr("PicDocumentNo2");
            PicDicL = this.GetRequestStr("PicDicL2");
            EngDroping = this.GetRequestStr("EngDroping2");
        }
        else
        {
            PicDocumentNo = this.GetRequestStr("PicDocumentNo1");
            PicDicL = this.GetRequestStr("PicDicL1");
            EngDroping = this.GetRequestStr("EngDroping1");
        }

        string FileLibraryID = "";
        string FileLibraryName = string.Empty;
        string FileLibraryData = String.Empty;
        if (this.drop_FileLibraryName.SelectedIndex != -1 && this.drop_FileLibraryName.SelectedItem.Value!="")
        {
            FileLibraryID = this.drop_FileLibraryName.SelectedItem.Value;
            FileLibraryName = this.drop_FileLibraryName.SelectedItem.Text;
            FileLibraryData = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        //2013-12-30 行政区
        #region 行政区
        string BuildAdsArea = this.BuildAdsArea.SelectedItem.Value;
        string CheckAdsArea = this.CheckAdsArea.SelectedItem.Value;
        string ComplainAdsArea = this.ComplainAdsArea.SelectedItem.Value;
        string MassSportsAdsArea = this.MassSportsAdsArea.SelectedItem.Value;
        string PunishAdsArea = this.PunishAdsArea.SelectedItem.Value;
        string TempCloseArea = this.TempCloseArea.SelectedItem.Value;
        string ForceRunAdsArea = this.ForceRunAdsArea.SelectedItem.Value;
        string ApplyFYArea = this.ApplyFYArea.SelectedItem.Value;
        string CountryPayAdsArea = this.CountryPayAdsArea.SelectedItem.Value;
        string PenalDocAdsArea = this.PenalDocAdsArea.SelectedItem.Value;
        string PenalDocCrimeAdsArea = this.PenalDocCrimeAdsArea.SelectedItem.Value;
        #endregion
        //2013-12-31 排架号
        string Columns = this.GetRequestStr("Columns");    //列
        string Cupboard = this.GetRequestStr("Cupboard");  //柜
        string Frame = this.GetRequestStr("Frame");        //架

        string CheckNaturefc = "0";
        if (this.CheckNaturefc.Checked == true)
        {
            CheckNaturefc = "1";
        }

        #region 执法档案名称
        string zfdnmc = string.Empty;
        //------------------------1--------------------
        if (BuildUnitName != "")
        {
            zfdnmc = BuildUnitName + BuildItemName;
        }
        //------------------------2--------------------
        if (CheckUnitName != "")
        {
            zfdnmc = CheckUnitName;
        }
        //------------------------3--------------------
        if (ComplainPeople != "")
        {
            zfdnmc = ComplainPeople + "举报" + ComplainNPeople + CompainN;
        }
        //------------------------4--------------------
        if (MassSportsPeople != "")
        {
            zfdnmc = MassSportsPeople + MassSportName;
        }
        //------------------------5--------------------
        if (FireAds != "")
        {
            zfdnmc = FireAds + MassSportName + FireUnitName + "'" + Convert.ToDateTime(FireDateTime).ToString("MM") + "." + Convert.ToDateTime(FireDateTime).ToString("dd") + "'" + this.FireN.SelectedItem.Text;
        }
        //------------------------6--------------------
        if (PunishMain != "")
        {
            zfdnmc = PunishMain + PunishWhy;
        }
        //------------------------7--------------------
        if (TempUintName != "")
        {
            zfdnmc = TempUintName + TempN + TempDX;
        }
        //------------------------8--------------------
        if (ForceUnitName != "")
        {
            zfdnmc = ForceUnitName + ForceN;
        }
        //------------------------9--------------------
        if (ApplyMain != "")
        {
            zfdnmc = ApplyMain + ApplyNContent;
        }
        //------------------------10--------------------
        if (CountryMain != "")
        {
            zfdnmc = CountryMain;
        }
        //------------------------11--------------------
        if (PenalName != "")
        {
            zfdnmc = PenalName + PenalZN;
        }
        string FilesName = zfdnmc;
        #endregion

        int id = this.GetRequestInt("id");
        int line = 0;//增加编辑受影响的行数
        if (id > 0)
        {
            line = fedal.Update(
                            FileFondsNo,
                            FileClassID,
                            FileDirectoryID,
                            FilesNum,
                            FilesName,
                            EnterPeople,
                            EnterDate,
                            SaveDeadlineID,
                            BuildAds,
                            BuildCheckT,
                            BuildFilingT,
                            BuildArea,
                            BuildALicense,
                            CheckAds,
                            CheckNature,
                            CheckResult,
                            ComplainAds,
                            ComplainResult,
                            FireNature,
                            FireArea,
                            FireEstateLoss,
                            FireHPeople,
                            FireDPeople,
                            MassSportsAds,
                            MassSportsResult,
                            PunishTypeID,
                            PunishFinePay,
                            PunishParts,
                            TempClose,
                            TempDay,
                            ForceRunAds,
                            ForcePunish,
                            ApplyReviewPeople,
                            CountryPayAds,
                            PenalDocSex,
                            PenalDocBirthday,
                            PenalDocNation,
                            PenalDocAds,
                            PenalDocCrimeAds,
                            PenalDocResult,
                            EnforcementID,
                            EnforcementName,
                            EnforcementPeople,
                            EnforcementPeople2,
                            EnforcementDate,
                            EnforcementDate2,
                            BuildUnitName,
                            BuildItemName,
                            CheckUnitName,
                            CheckItemName,
                            ComplainPeople,
                            ComplainNPeople,
                            CompainN,
                            MassSportsPeople,
                            MassSportName,
                            FireAds,
                            FireUnitName,
                            FireDateTime,
                            FireN,
                            PunishMain,
                            PunishWhy,
                            TempUintName,
                            TempN,
                            TempDX,
                            ForceUnitName,
                            ForceN,
                            ApplyFY,
                            CountryMain,
                            PenalName,
                            PenalZN,
                            ApplyNContent,
                            PunishAds,
                            ApplyMain,
                            LoginUser.GetUserName,
                            LoginUser.CountyId,
                            FileLibraryID,
                            FileLibraryName,
                            YesUnit,
                            PicDocumentNo,
                            PicDicL,
                            EngDroping,
                            buildingHeight,
                            FileLibraryData,
                            Ghmj,
                            Ccss,
                            Srs,
                            Wrs,
                            BuildAdsArea,
                            CheckAdsArea,
                            ComplainAdsArea,
                            MassSportsAdsArea,
                            PunishAdsArea,
                            TempCloseArea,
                            ForceRunAdsArea,
                            ApplyFYArea,
                            CountryPayAdsArea,
                            PenalDocAdsArea,
                            PenalDocCrimeAdsArea,
                            CheckNaturefc,
                            Columns,
                            Cupboard,
                            Frame,
                            id);

            if (line > 0)
            {
                new MessageBox(Page).ShowAndJump("编辑成功!", "FileEnterList.aspx");
                //操作日志
                LogListDal.Insert(DateTime.Now, "档案管理编辑成功", LoginUser.GetUserId, LoginUser.GetUserName);
            }
            else
                new MessageBox(this.Page).Show("编辑失败！");
        }
        else  //增加
        {
            line = fedal.Insert(
                             FileFondsNo,
                             FileClassID,
                             FileDirectoryID,
                             FilesNum,
                             FilesName,
                             EnterPeople,
                             EnterDate,
                             SaveDeadlineID,
                             BuildAds,
                             BuildCheckT,
                             BuildFilingT,
                             BuildArea,
                             BuildALicense,
                             CheckAds,
                             CheckNature,
                             CheckResult,
                             ComplainAds,
                             ComplainResult,
                             FireNature,
                             FireArea,
                             FireEstateLoss,
                             FireHPeople,
                             FireDPeople,
                             MassSportsAds,
                             MassSportsResult,
                             PunishTypeID,
                             PunishFinePay,
                             PunishParts,
                             TempClose,
                             TempDay,
                             ForceRunAds,
                             ForcePunish,
                             ApplyReviewPeople,
                             CountryPayAds,
                             PenalDocSex,
                             PenalDocBirthday,
                             PenalDocNation,
                             PenalDocAds,
                             PenalDocCrimeAds,
                             PenalDocResult,
                             EnforcementID,
                             EnforcementName,
                             EnforcementPeople,
                             EnforcementPeople2,
                             EnforcementDate,
                             EnforcementDate2,
                             BuildUnitName,
                             BuildItemName,
                             CheckUnitName,
                             CheckItemName,
                             ComplainPeople,
                             ComplainNPeople,
                             CompainN,
                             MassSportsPeople,
                             MassSportName,
                             FireAds,
                             FireUnitName,
                             FireDateTime,
                             FireN,
                             PunishMain,
                             PunishWhy,
                             TempUintName,
                             TempN,
                             TempDX,
                             ForceUnitName,
                             ForceN,
                             ApplyFY,
                             CountryMain,
                             PenalName,
                             PenalZN,
                             ApplyNContent,
                             PunishAds,
                             ApplyMain,
                             LoginUser.GetUserName,
                             LoginUser.CountyId,
                             FileLibraryID,
                            FileLibraryName,
                            YesUnit,
                            PicDocumentNo,
                            PicDicL,
                            EngDroping,
                            buildingHeight,
                            FileLibraryData,
                            Ghmj,
                            Ccss,
                            Srs,
                            Wrs,
                            BuildAdsArea,
                            CheckAdsArea,
                            ComplainAdsArea,
                            MassSportsAdsArea,
                            PunishAdsArea,
                            TempCloseArea,
                            ForceRunAdsArea,
                            ApplyFYArea,
                            CountryPayAdsArea,
                            PenalDocAdsArea,
                            PenalDocCrimeAdsArea,
                            CheckNaturefc,
                            Columns,
                            Cupboard,
                            Frame);
            if (line > 0)
            {
                new MessageBox(Page).ShowAndJump("增加成功!", "FileEnterList.aspx");
                //操作日志
                LogListDal.Insert(DateTime.Now, "档案管理录入成功", LoginUser.GetUserId, LoginUser.GetUserName);
            }
            else
                new MessageBox(this.Page).Show("增加失败！");
        }
    }
    #endregion


}