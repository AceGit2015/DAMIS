using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToolsCommon;
using ToolsDal;
using System.Data;

public partial class Manager_DocumentInfor_FileDestroy_FileDestroyEdit : System.Web.UI.Page
{
    //定义对象实例化
    FileDestroyDal dal = new FileDestroyDal();
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
        //执法档案目录号
        DataTable dtfile = Utility.GetFileClassTree();
        if (AccessDataSet.HasDataTable(dtfile))
        {

            this.txtFileClassID.Items.Clear();
            this.txtFileClassID.Items.Insert(0, new ListItem("--请选择--", ""));
            foreach (DataRow dr in dtfile.Rows)
            {
                string Id = dr["ID"].ToStr();
                string name = dr["FileName"].ToStr();
                //增加数据集合
                this.txtFileClassID.Items.Add(new ListItem(Utility.GetStr(dr["lv"].ToStr()) + name, Id));
                if (this.GetRequestInt("ID") > 0)
                {
                    this.txtFileClassID.Items.FindByValue(Id).Selected = true;
                }
            }
        }
        
        //批准人单位
        DataTable dtor2 = ordal.GetDataTable("");
        if (AccessDataSet.HasDataTable(dtor2))
        {
            this.txtApproverUnit.DataSource = dtor2;
            this.txtApproverUnit.DataTextField = "OrganizerName";
            this.txtApproverUnit.DataValueField = "OrganizerName";
            this.txtApproverUnit.DataBind();
            this.txtApproverUnit.Items.Insert(0, new ListItem("--请选择--", ""));
        }

        //监督人单位
        DataTable dtor = ordal.GetDataTable("");
        if (AccessDataSet.HasDataTable(dtor))
        {
            this.txtSuperviseUnit.DataSource = dtor;
            this.txtSuperviseUnit.DataTextField = "OrganizerName";
            this.txtSuperviseUnit.DataValueField = "OrganizerName";
            this.txtSuperviseUnit.DataBind();
            this.txtSuperviseUnit.Items.Insert(0, new ListItem("--请选择--", ""));
        }
        this.txtSuperviseUnit.SelectedValue = LoginUser.OrganizerName;

        //this.txtApproverPeople.Text = LoginUser.GetUserName;
        this.txtDestroyPeople.Text = LoginUser.GetUserName;
    }




    //取值
    public void GetValue()
    {
        DataRow dr = dal.GetRow(this.GetRequestInt("id")); //获取传递的参数，编辑时ID主键
        if (dr != null)
        {
            this.txtFileClassID.SelectedValue = dr["FileClassID"].ToStr();
            this.txtFileEnterName.Text = dr["FileEnterName"].ToStr();
            this.txtApproverPeople.Text = dr["ApproverPeople"].ToStr();
            this.txtApproverUnit.SelectedValue = dr["ApproverUnit"].ToStr();
            this.txtSupervisePeople.Text = dr["SupervisePeople"].ToStr();
            this.txtSuperviseUnit.SelectedValue = dr["SuperviseUnit"].ToStr();
            this.txtDestroyPeople.Text = dr["DestroyPeople"].ToStr();
            this.txtDestroyDate.Text = dr["DestroyDate"].ToStr();
            this.txtDestroyAds.Text = dr["DestroyAds"].ToStr();
            this.txtRemark.Text = dr["Remark"].ToStr();
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
        string FileClassName = this.txtFileClassID.SelectedItem.Text.Trim('-');
        string FileEnterName = this.GetRequestStr("txtFileEnterName");
        string ApproverPeople = this.GetRequestStr("txtApproverPeople");
        string ApproverUnit = this.GetRequestStr("txtApproverUnit");
        string SupervisePeople = this.GetRequestStr("txtSupervisePeople");
        string SuperviseUnit = this.GetRequestStr("txtSuperviseUnit");
        string DestroyPeople = this.GetRequestStr("txtDestroyPeople");
        string DestroyDate = this.GetRequestStr("txtDestroyDate");
        string DestroyAds = this.GetRequestStr("txtDestroyAds");//归还时间--暂不需要
        string Remark = this.GetRequestStr("txtRemark");
        int id = this.GetRequestInt("id");

        #region 判断输入信息
        if (FileClassID.ToString() == "0")
        {
            new MessageBox(this.Page).Show("请选择案卷类型名称！");
            return;
        }
        if (FileEnterName == "")
        {
            new MessageBox(this.Page).Show("请输入案卷名称！");
            return;
        }
        if (ApproverPeople == "")
        {
            new MessageBox(this.Page).Show("请输入批准人姓名！");
            return;
        }
        if (ApproverUnit == "")
        {
            new MessageBox(this.Page).Show("请选择批准人承办单位！");
            return;
        }
        if (SupervisePeople == "")
        {
            new MessageBox(this.Page).Show("请输入监督人姓名！");
            return;
        }
        if (SuperviseUnit == "")
        {
            new MessageBox(this.Page).Show("请选择监督人承办单位！");
            return;
        }
        if (DestroyPeople == "")
        {
            new MessageBox(this.Page).Show("请输入销毁人姓名！");
            return;
        }
        if (DestroyAds == "")
        {
            new MessageBox(this.Page).Show("请输入销毁地点！");
            return;
        }
        if (DestroyDate == "")
        {
            new MessageBox(this.Page).Show("请选择销毁时间！");
            return;
        }
        #endregion


        int line = 0;  //定义增加受影响的行数

        //判断该档案是否存在
        DataTable dtfl = PublicQuery.GetDataDNJYTable(FileEnterName, FileClassID.ToString());
        if (!AccessDataSet.HasDataTable(dtfl))
        {
            new MessageBox(this.Page).Show("你案卷类型下不存在此案卷名称的案卷！");
            return;
        }

        if (this.GetRequestInt("id") > 0)
        {
            line = dal.Update(
                            dtfl.Rows[0]["id"].ToString(),
                            FileClassID,
                            FileClassName,
                            FileEnterName,
                            ApproverPeople,
                            ApproverUnit,
                            SupervisePeople,
                            SuperviseUnit,
                            DestroyPeople,
                            DestroyDate,
                            DestroyAds,
                            DateTime.Now.ToString(),
                            Remark, LoginUser.GetUserId, LoginUser.GetUserName, LoginUser.CountyId, id);
            if (line > 0)
            {
                fedal.UpdateFileEnterSLLX("",1,FileClassID.ToString(), FileEnterName);
                new MessageBox(Page).ShowAndJump("编辑成功!", "FileDestroyList.aspx");
                //操作日志
                LogListDal.Insert(DateTime.Now, "档案销毁编辑成功", LoginUser.GetUserId, LoginUser.GetUserName);
            }
            else
                new MessageBox(this.Page).Show("编辑失败！");
        }
        else
        {
            line = dal.Insert(
                            dtfl.Rows[0]["id"].ToString(),
                            FileClassID,
                            FileClassName,
                            FileEnterName,
                            ApproverPeople,
                            ApproverUnit,
                            SupervisePeople,
                            SuperviseUnit,
                            DestroyPeople,
                            DestroyDate,
                            DestroyAds,
                            DateTime.Now.ToString(),
                            Remark, LoginUser.GetUserId, LoginUser.GetUserName, LoginUser.CountyId);
            if (line > 0)
            {
                fedal.UpdateFileEnterSLLX("",1,FileClassID.ToString(), FileEnterName);
                new MessageBox(Page).ShowAndJump("增加成功!", "FileDestroyList.aspx");
                //操作日志
                LogListDal.Insert(DateTime.Now, "档案销毁增加成功", LoginUser.GetUserId, LoginUser.GetUserName);
            }
            else
                new MessageBox(this.Page).Show("增加失败！");
        }
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