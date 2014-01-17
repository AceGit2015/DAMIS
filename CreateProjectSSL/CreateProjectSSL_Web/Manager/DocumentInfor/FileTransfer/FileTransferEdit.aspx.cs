using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToolsCommon;
using ToolsDal;
using System.Data;


public partial class Manager_DocumentInfor_FileTransfer_FileTransferEdit : BasePage
{
    //定义对象实例化
    FileTransferDal dal = new FileTransferDal();
    OrganizerDal ordal = new OrganizerDal();
    FileClassDal dalclass = new FileClassDal();
    PublicQuery pdal = new PublicQuery();
    FileEnterDal fedal = new FileEnterDal();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDataList();
            //大于0为编辑否则为增加
            if (this.GetRequestInt("id") > 0)
                this.GetValue();

        }
    }

    private void BindDataList()
    {
        //接收人单位
        DataTable dtor = ordal.GetDataTable("");
        //批准人单位
        if (AccessDataSet.HasDataTable(dtor))
        {
            this.txtApproverUnit.DataSource = dtor;
            this.txtApproverUnit.DataTextField = "OrganizerName";
            this.txtApproverUnit.DataValueField = "OrganizerName";
            this.txtApproverUnit.DataBind();
            this.txtApproverUnit.Items.Insert(0, new ListItem("--请选择--", ""));
        }
        this.txtApproverUnit.SelectedValue = LoginUser.OrganizerName;

        this.txtTransferPeople.Text = LoginUser.GetUserName;
        this.txtApproverUnit.SelectedValue = LoginUser.CountyId;

        DataTable execDt = fedal.GetDataTableProcSUM(LoginUser.CountyId);
        if (AccessDataSet.HasDataTable(execDt))
        {
            this.Xfxzxkda.Text = execDt.Rows[0]["消防行政许可档案"].ToStr();
            this.Xfjdjcda.Text = execDt.Rows[0]["消防监督检查档案"].ToStr();
            this.Xfaqzddwda.Text = execDt.Rows[0]["消防安全重点单位档案"].ToStr();
            this.Zdhzyhda.Text = execDt.Rows[0]["重大火灾隐患档案"].ToStr();
            this.Hzsgdcda.Text = execDt.Rows[0]["火灾事故调查档案"].ToStr();
            this.Xfxzcfda.Text = execDt.Rows[0]["消防行政处罚档案"].ToStr();
            this.Xfxzqzda.Text = execDt.Rows[0]["消防行政强制档案"].ToStr();
            this.Xfzfjjda.Text = execDt.Rows[0]["消防执法救济档案"].ToStr();
            this.Xfxsda.Text = execDt.Rows[0]["消防刑事档案"].ToStr();
        }

    }




    //取值
    public void GetValue()
    {
        DataRow dr = dal.GetRow(this.GetRequestInt("id")); //获取传递的参数，编辑时ID主键
        if (dr != null)
        {
            //this.txtFileClassID.SelectedValue = dr["FileClassID"].ToStr();
            //this.txtFileEnterName.Text = dr["FileEnterName"].ToStr();
            this.txtTransferPeople.Text = dr["TransferPeople"].ToStr();
            //this.txtTransferUnit.SelectedValue = dr["TransferUnit"].ToStr();
            this.txtAcceptPeople.Text = dr["AcceptPeople"].ToStr();
            //this.txtUnit.SelectedValue = dr["AcceptSzqxdm"].ToStr();
            this.txtApproverPeople.Text = dr["ApproverPeople"].ToStr();
            this.txtApproverUnit.SelectedValue = dr["ApproverUnit"].ToStr();
            this.txtTransferDate.Text = dr["TransferDate"].ToStr();
            this.txtRemark.Text = dr["Remark"].ToStr();

            this.Xfxzxkda.Text = dr["Xfxzxkda"].ToStr();
            this.Xfjdjcda.Text = dr["Xfjdjcda"].ToStr();
            this.Xfaqzddwda.Text = dr["Xfaqzddwda"].ToStr();
            this.Zdhzyhda.Text = dr["Zdhzyhda"].ToStr();
            this.Hzsgdcda.Text = dr["Hzsgdcda"].ToStr();
            this.Xfxzcfda.Text = dr["Xfxzcfda"].ToStr();
            this.Xfxzqzda.Text = dr["Xfxzqzda"].ToStr();
            this.Xfzfjjda.Text = dr["Xfzfjjda"].ToStr();
            this.Xfxsda.Text = dr["Xfxsda"].ToStr();
            if (this.GetRequestInt("flag") == 1)  //如果是查看则禁用掉所有文本框
            {
                Utility.initControl(Page, "");
                this.btnSave.Enabled = false;
                this.Reset.Enabled = false;
            }
        }


    }

    /// <summary>
    /// 保存操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //获取界面数值赋值给model对象
        int FileClassID = this.GetRequestInt("txtFileClassID");
        string FileClassName = ""; //= this.txtFileClassID.SelectedItem.Text.Trim('-');
        string FileEnterName = this.GetRequestStr("txtFileEnterName");
        string TransferPeople = this.GetRequestStr("txtTransferPeople");
        string TransferUnit = ""; //= this.txtTransferUnit.SelectedValue;
        string AcceptPeople = this.GetRequestStr("txtAcceptPeople");
        string AcceptSzqxdm = ""; //= this.txtUnit.SelectedValue;
        string Unit = ""; //= this.txtUnit.SelectedItem.Text;
        string ApproverPeople = this.GetRequestStr("txtApproverPeople");
        string ApproverUnit = this.txtApproverUnit.SelectedValue;
        string TransferDate = this.GetRequestStr("txtTransferDate");
        string OperateTime = DateTime.Now.ToString();
        string Remark = this.GetRequestStr("txtRemark");

        #region 判断输入信息
        if (TransferPeople == "")
        {
            new MessageBox(this.Page).Show("请输入移交人姓名！");
            return;
        }
        if (AcceptPeople == "")
        {
            new MessageBox(this.Page).Show("请输入接收人姓名！");
            return;
        }
        if (ApproverPeople == "")
        {
            new MessageBox(this.Page).Show("请输入批准人姓名！");
            return;
        }
        if (ApproverUnit == "")
        {
            new MessageBox(this.Page).Show("请选择单位名称！");
            return;
        }
        if (TransferDate == "")
        {
            new MessageBox(this.Page).Show("请选择移交时间！");
            return;
        }
        #endregion


        int id = this.GetRequestInt("id");

        int line = 0;  //定义增加受影响的行数

        //判断该档案是否存在
        //DataTable dtfl = PublicQuery.GetDataDNJYTable(FileEnterName, FileClassID.ToString());
        //if (!AccessDataSet.HasDataTable(dtfl))
        //{
        //    new MessageBox(this.Page).Show("你案卷类型下不存在此案卷名称的案卷！");
        //    return;
        //}

        //if (this.GetRequestInt("id") > 0)
        //{
        //    line = dal.Update(
        //                    dtfl.Rows[0]["id"].ToString(),
        //                    FileClassID,
        //                    FileClassName,
        //                    FileEnterName,
        //                    TransferPeople,
        //                    TransferUnit,
        //                    AcceptPeople,
        //                    AcceptSzqxdm,
        //                    Unit,
        //                    ApproverPeople,
        //                    ApproverUnit,
        //                    TransferDate,
        //                    OperateTime,
        //                    Remark, 
        //                    LoginUser.GetUserId, 
        //                    LoginUser.GetUserName, 
        //                    2, 
        //                    LoginUser.CountyId, 
        //                    id);
        //    if (line > 0)
        //    {
        //        new MessageBox(Page).ShowAndJump("编辑成功!", "FileTransferList.aspx");
        //        //操作日志
        //        LogListDal.Insert(DateTime.Now, "档案移交编辑成功", LoginUser.GetUserId, LoginUser.GetUserName);
        //    }
        //    else
        //        new MessageBox(this.Page).Show("编辑失败！");
        //}
        //else
        //{
        line = dal.Insert(
                        -1,
                        FileClassID,
                        FileClassName,
                        FileEnterName,
                        TransferPeople,
                        TransferUnit,
                        AcceptPeople,
                        AcceptSzqxdm,
                        Unit,
                        ApproverPeople,
                        ApproverUnit,
                        TransferDate,
                        OperateTime,
                        Remark,
                        LoginUser.GetUserId,
                        LoginUser.GetUserName,
                        2,
                        "",
                        LoginUser.CountyId,
                        "",
                        "",
                        "",
                        0,
                        this.Xfxzxkda.Text,
                        this.Xfjdjcda.Text,
                        this.Xfaqzddwda.Text,
                        this.Zdhzyhda.Text,
                        this.Hzsgdcda.Text,
                        this.Xfxzcfda.Text,
                        this.Xfxzqzda.Text,
                        this.Xfzfjjda.Text,
                        this.Xfxsda.Text);
        if (line > 0)
        {
            new MessageBox(Page).ShowAndJump("" + LoginUser.GetUserName + "档案移交成功!", "FileTransferList.aspx");
            //操作日志
            LogListDal.Insert(DateTime.Now, "" + LoginUser.GetUserName + "档案移交成功", LoginUser.GetUserId, LoginUser.GetUserName);
        }
        else
            new MessageBox(this.Page).Show("" + LoginUser.GetUserName + "档案移交失败！");
        //}
    }

    /// <summary>
    /// 重置操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Reset_Click(object sender, EventArgs e)
    {
        //备注信息：在Utility类中存在一个initControl方法 ，其中
        //isClear是添加时候，清空数据信息，如果type参数为空数值则默认为查看状态，控件都全部禁用掉
        Utility.initControl(Page, "isClear");
    }

}