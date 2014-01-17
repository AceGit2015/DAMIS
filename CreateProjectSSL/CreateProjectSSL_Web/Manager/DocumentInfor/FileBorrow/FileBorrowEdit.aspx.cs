using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToolsCommon;
using ToolsDal;
using System.Data;

public partial class Manager_DocumentInfor_FileBorrow_FileBorrowEdit : BasePage
{
    //定义对象实例化
    FileBorrowDal dal = new FileBorrowDal();
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
        //借阅人单位
        DataTable dtor = ordal.GetDataTable("");
        if (AccessDataSet.HasDataTable(dtor))
        {
            this.txtBorrowUnit.DataSource = dtor;
            this.txtBorrowUnit.DataTextField = "OrganizerName";
            this.txtBorrowUnit.DataValueField = "OrganizerName";
            this.txtBorrowUnit.DataBind();
            this.txtBorrowUnit.Items.Insert(0, new ListItem("--请选择--", ""));
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
        this.txtApproverUnit.SelectedValue = LoginUser.OrganizerName;

        this.txtApproverPeople.Text = LoginUser.GetUserName;
        this.txtHandlePeople.Text = LoginUser.GetUserName;
    }




    //取值
    public void GetValue()
    {
        DataRow dr = dal.GetRow(this.GetRequestInt("id")); //获取传递的参数，编辑时ID主键
        if (dr != null)
        {
            this.txtFileClassID.SelectedValue = dr["FileClassID"].ToStr();
            this.txtFileEnterName.Text = dr["FileEnterName"].ToStr();
            this.txtBorrowPeople.Text = dr["BorrowPeople"].ToStr();
            this.txtBorrowUnit.SelectedValue = dr["BorrowUnit"].ToStr();
            this.txtBorrowDate.Text = dr["BorrowDate"].ToStr();
            this.txtReturnDate.Text = dr["ReturnDate"].ToStr();
            this.txtApproverPeople.Text = dr["ApproverPeople"].ToStr();
            this.txtApproverUnit.SelectedValue = dr["ApproverUnit"].ToStr();
            this.txtHandlePeople.Text = dr["HandlePeople"].ToStr();
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
        string BorrowPeople = this.GetRequestStr("txtBorrowPeople");
        string BorrowUnit = this.GetRequestStr("txtBorrowUnit");
        string ApproverPeople = this.GetRequestStr("txtApproverPeople");
        string ApproverUnit = this.GetRequestStr("txtApproverUnit");
        string HandlePeople = this.GetRequestStr("txtHandlePeople");
        string BorrowDate = this.GetRequestStr("txtBorrowDate");
        string ReturnDate = this.GetRequestStr("txtReturnDate");//归还时间--暂不需要
        //string OperateTime = this.GetRequestStr("txtAddTime");
        string Remark = this.GetRequestStr("txtRemark");
        int id = this.GetRequestInt("id");

        int line = 0;  //定义增加受影响的行数

        #region 判断输入信息
        if (FileClassID.ToString()=="0")
        {
            new MessageBox(this.Page).Show("请选择案卷类型名称！");
            return;
        }
        if (FileEnterName == "")
        {
            new MessageBox(this.Page).Show("请输入案卷名称！");
            return;
        }
        if (BorrowPeople=="")
        {
            new MessageBox(this.Page).Show("请输入借阅人姓名！");
            return;
        }
        if (BorrowUnit == "")
        {
            new MessageBox(this.Page).Show("请选择借阅人承办单位！");
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
        if (HandlePeople == "")
        {
            new MessageBox(this.Page).Show("请输入经办人姓名！");
            return;
        }
        if (BorrowDate == "")
        {
            new MessageBox(this.Page).Show("请选择借阅时间！");
            return;
        }
        #endregion

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
                            BorrowPeople,
                            BorrowUnit,
                            ApproverPeople,
                            ApproverUnit,
                            HandlePeople,
                            BorrowDate,
                            ReturnDate,//归还时间--暂不需要
                            DateTime.Now.ToString(),
                            Remark,LoginUser.GetUserId,LoginUser.GetUserName,LoginUser.CountyId, id);
            if (line > 0)
            {
                if (ReturnDate == "")
                {
                    fedal.UpdateFileEnterSLLX("", 2, FileClassID.ToString(), FileEnterName);
                }
                else
                {
                    fedal.UpdateFileEnterSLLX("", 0, FileClassID.ToString(), FileEnterName);
                }
                new MessageBox(Page).ShowAndJump("编辑成功!", "FileBorrowList.aspx");
                //操作日志
                LogListDal.Insert(DateTime.Now, "档案借阅编辑成功", LoginUser.GetUserId, LoginUser.GetUserName);
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
                            BorrowPeople,
                            BorrowUnit,
                            ApproverPeople,
                            ApproverUnit,
                            HandlePeople,
                            BorrowDate,
                            ReturnDate,//归还时间--暂不需要
                            DateTime.Now.ToString(),
                            Remark, LoginUser.GetUserId, LoginUser.GetUserName, LoginUser.CountyId);
            if (line > 0)
            {
                if (ReturnDate=="")
                {
                    fedal.UpdateFileEnterSLLX("", 2, FileClassID.ToString(), FileEnterName);
                }
                else
                {
                    fedal.UpdateFileEnterSLLX("", 0, FileClassID.ToString(), FileEnterName);
                }
                new MessageBox(Page).ShowAndJump("增加成功!", "FileBorrowList.aspx");
                //操作日志
                LogListDal.Insert(DateTime.Now, "档案借阅增加成功", LoginUser.GetUserId, LoginUser.GetUserName);
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
