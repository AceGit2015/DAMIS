using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToolsCommon;
using ToolsModel;
using ToolsDal;
using ToolsHelper;
using System.Data;
using System.Collections;

public partial class Manager_Manage_Center : BasePage
{
    protected string GetStyle
    {
        get
        {
            if (ViewState["VS_GetStyle"] == null)
            {
                return null;
            }
            return (String)ViewState["VS_GetStyle"];
        }
        set
        {
            ViewState["VS_GetStyle"] = value;
        }
    }

    //定义对象实例化
    UserListDal dal = new UserListDal();
    ToolsModel.UserList model = new ToolsModel.UserList();
    FileTransferDal daltf = new FileTransferDal();
    ToolsModel.FileTransfer modeltf = new ToolsModel.FileTransfer();
    FileLibraryDal fldal = new FileLibraryDal();   //档案库名称
    FileEnterDal fedal = new FileEnterDal(); //档案信息

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (LoginUser.CountyId=="420100")
            {
                GetStyle = " style=\"display:block;\" ";
            }
            else
            {
                GetStyle = " style=\"display:none;\" ";
            }
            DataTable dtinfor = dal.GetUserDataTable(" and us.id="+LoginUser.GetUserId+" "); //获取传递的参数，编辑时ID主键
            if (AccessDataSet.HasDataTable(dtinfor))
            {
                this.lbusername.Text = dtinfor.Rows[0]["userName"].ToString();
                this.lblxdh.Text = dtinfor.Rows[0]["userTel"].ToString();
                this.lbdzyx.Text = dtinfor.Rows[0]["userMail"].ToString();
                this.lbzzjg.Text = dtinfor.Rows[0]["userPost"].ToString();
                this.lbssdw.Text = dtinfor.Rows[0]["zzjg"].ToString();
                LoadData();
                BindDaSource();
            }
        }
    }

    protected void LoadData()
    {
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
    }

    //页面加载绑定数据源
    private void BindDaSource()
    {
        //获取查询条件
        //modeltf.FileClassID = this.GetRequestInt("fFileClassID");
        //modeltf.FileEnterName = this.GetRequestStr("fFileClassName");
        //实现分页，调用分页类
        Pager1.PageSize = TSQLServer.PageSize.ToInt32(); //默认显示数据信息条数
        PeterPages fenye1 = daltf.GetSearchgd(modeltf, this.Pager1.PageIndex + 1, Pager1.PageSize, " AcceptSzqxdm='"+LoginUser.CountyId+"' and (sjzt=0 or sjzt=2) and yjlx=1 ");
        this.rptList.DataSource = fenye1.Ds;
        rptList.DataBind();
        Pager1.RecordCount = fenye1.RecordCount;

    }

    /// <summary>
    /// 选择指定页数进行数据重新绑定
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Pager1_PageIndexChanging(object sender, Pager.NumericaArgs e)
    {
        this.Pager1.PageIndex = e.NewPageIndex;
        BindDaSource();
    }

    #region 删除时，注册注册到客户端JavaScript数组
    protected void rptList_PreRender(object sender, EventArgs e)
    {
        prerepater(rptList, this);
    }
    //这个是通用方法用于在公用类库中调用
    public static void prerepater(Repeater repeater, System.Web.UI.Page page)
    {
        ClientScriptManager cs = page.ClientScript;
        if (repeater.Items.Count > 0)
        {
            for (int i = 0; i < repeater.Items.Count; i++)
            {
                CheckBox cbx = (CheckBox)repeater.Items[i].FindControl("cb_id");
                //将相应的服务器控件的ClientId注册到客户端JavaScript数组
                cs.RegisterArrayDeclaration("cbxArray", String.Concat("'", cbx.ClientID, "'"));
            }
        }
        else
            cs.RegisterArrayDeclaration("cbxArray", String.Concat("'", "", "'"));
    }
    #endregion

    //档案归档
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.drop_FileLibraryName.SelectedItem.Text == "")
        {
            new MessageBox(this.Page).Show("请选择档案库室！");
            return;
        }

        ArrayList alsql = new ArrayList();
        string sqlStr = "";  //移交记录归档
        sqlStr = " update FileTransfer set  sjzt=3,Gdr='" + LoginUser.GetUserName + "',Gdsj='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where id='" + HiddenFieldyj.Value + "' ";
        alsql.Add(sqlStr);
        string strupdate = ""; //移交档案归档
        strupdate = " update FileEnter set  FileLibraryID='" + this.drop_FileLibraryName.SelectedValue + "',FileLibraryName='" + this.drop_FileLibraryName.SelectedItem.Text + "',FileLibraryData='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',FileTransferSJLX=2  where id='" + HiddenFieldda.Value + "' ";
        alsql.Add(strupdate);
        Boolean flag = TSQLServer.execTriggerAll(alsql);
        if (flag == true)
        {
            new MessageBox(Page).ShowAndJump("执法档案归档成功!", "Manage_Center.aspx");
            //操作日志
            LogListDal.Insert(DateTime.Now, "归档执法档案" + this.HiddenFieldda.Value + "", LoginUser.GetUserId, LoginUser.GetUserName);
        }
        else
        {
            new MessageBox(Page).ShowAndJump("执法档案归档失败!", "Manage_Center.aspx");
        }

    }
    protected void RadGrid1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        LinkButton LinkButtonjies = (LinkButton)e.Item.FindControl("LinkButton1");
        //LinkButton LinkButtonjus = (LinkButton)e.Item.FindControl("LinkButton2");
        HiddenField HF = (HiddenField)e.Item.FindControl("HiddenField1");
        Label Lb = (Label)e.Item.FindControl("Label1");
        CheckBox cbx = (CheckBox)e.Item.FindControl("cb_id");
        if (HF.Value=="0")
        {
            LinkButtonjies.Visible = true;
            //LinkButtonjus.Visible = true;
            Lb.Visible = true;
            cbx.Visible = true;
        }
        else
        {
            LinkButtonjies.Visible = false;
            //LinkButtonjus.Visible = false;
            Lb.Visible = false;
            cbx.Visible = false;
        }
    }


    //操作事件--接收档案
    protected void LinkButtonALL_Command(object sender, CommandEventArgs e)
    {
        string CommandName;
        string[] CurrentValueId;
        CurrentValueId = e.CommandArgument.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        CommandName = e.CommandName;
        //接收档案
        if (CommandName.ToString() == "FileTransfer")
        {
            DataRow drdg = fedal.GetRow(CurrentValueId[1]);
            if (drdg != null)
            {
                ArrayList alsql = new ArrayList();
                string sqlStr = "";  //接收移交记录
                sqlStr = " update FileTransfer set  sjzt=2,Jssj='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',AcceptPeople='" + LoginUser.GetUserName + "',AcceptUnit='" + LoginUser.OrganizerName + "' where id='" + CurrentValueId[0] + "' ";
                alsql.Add(sqlStr);
                string strupdate = ""; //接收更新档案状态
                strupdate = " update FileEnter set  ReceiptTime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',oldEnteCountyId='" + drdg["EnteCountyId"] + "',oldEnteUserName='" + drdg["EnteUserName"] + "',EnteCountyId='" + LoginUser.CountyId + "',EnteUserName='" + LoginUser.GetUserName + "',EnforcementID_new='" + LoginUser.OrganizerId + "',EnforcementName_new='" + LoginUser.OrganizerName + "',FileLibraryID_old='" + drdg["FileLibraryID"] + "',FileLibraryName_old='" + drdg["FileLibraryName"] + "',FileLibraryID='',FileLibraryName='',FileTransferSJLX=1,FileTransferID='" + CurrentValueId[0] + "'  where id='" + CurrentValueId[1] + "' ";
                alsql.Add(strupdate);
                Boolean flag = TSQLServer.execTriggerAll(alsql);
                if (flag == true)
                {
                    new MessageBox(Page).ShowAndJump("执法档案接收成功!", "Manage_Center.aspx");
                    //操作日志
                    LogListDal.Insert(DateTime.Now, "接收执法档案" + CurrentValueId[0] + "", LoginUser.GetUserId, LoginUser.GetUserName);
                }
                else
                {
                    new MessageBox(Page).ShowAndJump("执法档案接收失败!", "Manage_Center.aspx");
                }
            }
            else
            {
                new MessageBox(Page).ShowAndJump("执法档案接收失败!", "Manage_Center.aspx");
            }
        }
    }
    //批量接收
    protected void btnCheckSave_Click(object sender, EventArgs e)
    {
        string ids = "0";
        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = ((Label)rptList.Items[i].FindControl("lb_id")).Text.ToInt32();
            CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
            if (cb.Checked)
            {
                ids += "," + id;
            }
        }

        DataTable dttf = daltf.GetDataTable(" and id in (" + ids + ") ");
        ArrayList alsql = new ArrayList();
        Boolean flag = false;
        if (AccessDataSet.HasDataTable(dttf))
        {

            foreach (DataRow item in dttf.Rows)
            {
                string sqlStr = "";  //接收移交记录
                sqlStr = " update FileTransfer set  sjzt=2,Jssj='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',AcceptPeople='" + LoginUser.GetUserName + "',AcceptUnit='" + LoginUser.OrganizerName + "' where id='" + item["id"] + "' ";
                alsql.Add(sqlStr);
                string strupdate = ""; //接收更新档案状态
                DataRow drdg = fedal.GetRow(item["FileEnterID"]);
                if (drdg != null)
                {
                    strupdate = " update FileEnter set  ReceiptTime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',oldEnteCountyId='" + drdg["EnteCountyId"] + "',oldEnteUserName='" + drdg["EnteUserName"] + "',EnteCountyId='" + LoginUser.CountyId + "',EnteUserName='" + LoginUser.GetUserName + "',EnforcementID_new='" + LoginUser.OrganizerId + "',EnforcementName_new='" + LoginUser.OrganizerName + "',FileLibraryID_old='" + drdg["FileLibraryID"] + "',FileLibraryName_old='" + drdg["FileLibraryName"] + "',FileLibraryID='',FileLibraryName='',FileTransferSJLX=1,FileTransferID='" + item["id"] + "'  where id='" + item["FileEnterID"] + "' ";
                }
                alsql.Add(strupdate);
            }
            flag = TSQLServer.execTriggerAll(alsql);
        }
        if (flag == true)
        {
            new MessageBox(Page).ShowAndJump("批量移交支队成功!", "Manage_Center.aspx");
            //操作日志
            LogListDal.Insert(DateTime.Now, "案卷档案[" + ids + "]批量移交支队", LoginUser.GetUserId, LoginUser.GetUserName);
        }
        else
        {
            new MessageBox(Page).ShowAndJump("批量移交支队失败!", "Manage_Center.aspx");
        }
        this.BindDaSource();
    }
    //拒收
    protected void btnCheckSavejs_Click(object sender, EventArgs e)
    {
        ArrayList alsql = new ArrayList();
        string sqlStr = "";  //拒收移交记录
        sqlStr = " update FileTransfer set  sjzt=1,Jsyy='" + this.txt_jsyy.Text + "',AcceptPeople='" + LoginUser.GetUserId + "',AcceptUnit='" + LoginUser.OrganizerName + "' where id='" + this.HiddenFieldjs.Value + "' ";
        alsql.Add(sqlStr);
        string strupdate = ""; //拒收更新档案状态
        strupdate = " update FileEnter set  sjlx=0 where id='" + this.HiddenFieldjsda.Value + "' ";
        alsql.Add(strupdate);
        Boolean flag = TSQLServer.execTriggerAll(alsql);
        if (flag == true)
        {
            new MessageBox(Page).ShowAndJump("执法档案拒收成功!", "Manage_Center.aspx");
            //操作日志
            LogListDal.Insert(DateTime.Now, "拒收执法档案" + this.HiddenFieldjsda.Value + "", LoginUser.GetUserId, LoginUser.GetUserName);
        }
        else
        {
            new MessageBox(Page).ShowAndJump("执法档案拒收失败!", "Manage_Center.aspx");
        }
    }
}