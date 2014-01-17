using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToolsCommon;
using ToolsDal;
using ToolsHelper;
using System.IO;
using System.Data;

public partial class Manager_DocumentInfor_FileEnter_FileEnterDelete : BasePage
{
    //定义对象实例化
    FileEnterDal dal = new FileEnterDal();
    FileLibraryDal fldal = new FileLibraryDal();   //档案库名称
    FileClassDal fileclass = new FileClassDal();
    ToolsModel.FileEnter model = new ToolsModel.FileEnter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Pager1.PageIndex = 0; //默认为0
            this.BindDaSource();
        }
    }



    private void BindDaSource()
    {
        //获取查询条件
        model.FilesName = this.GetRequestStr("ftxtFilesName");
        model.EnterPeople = this.GetRequestStr("txtEnterPeople");
        model.tmp_Data = this.GetRequestStr("fStarttime") + '|' + this.GetRequestStr("fEndtime");//开始时间和结束时间
        //实现分页，调用分页类
        Pager1.PageSize = TSQLServer.PageSize.ToInt32(); //默认显示数据信息条数
        PeterPages fenye1 = dal.GetSearchDelete(model, this.Pager1.PageIndex + 1, Pager1.PageSize, LoginUser.CountyId);
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


    protected void btnQuery_Click(object sender, EventArgs e)
    {
        BindDaSource();
    }
    //批量删除
    protected void lbtnDel_Click(object sender, EventArgs e)
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

         dal.DeleteAllIn(ids);
        //dal.DeleteAllInUpdate("8", ids);
         new MessageBox(Page).ShowAndJump("批量删除成功!", "FileEnterDelete.aspx");
        //操作日志
         LogListDal.Insert(DateTime.Now, "案卷档" + ids + "案删除", LoginUser.GetUserId, LoginUser.GetUserName);
        this.BindDaSource();
    }

    //单个删除
    protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label cb_id = (Label)e.Item.FindControl("lb_id");

        switch (e.CommandName.ToLower())
        {
            case "del":
                dal.Delete(cb_id.Text);
                //dal.DeleteUpdate("8", cb_id.Text);
                //Alert("删除成功", "FileClassList.aspx");
                new MessageBox(Page).ShowAndJump("删除成功!", "FileEnterDelete.aspx");
                //操作日志
                LogListDal.Insert(DateTime.Now, "案卷档" + cb_id.Text + "案删除", LoginUser.GetUserId, LoginUser.GetUserName);
                this.BindDaSource();
                break;
        }
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

    

    protected void txtDocStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Pager1.PageIndex = 0; //默认为0
        BindDaSource();
    }

    //是否归档
    protected string dasfgd(string strwhere)
    {
        string returnstr = string.Empty;
        if (strwhere == "")
        {
            returnstr = "未归档";
        }
        else if (strwhere == "0")
        {
            returnstr = "未归档";
        }
        else
        {
            returnstr = "已归档";
        }
        return returnstr;
    }

    protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        LinkButton LinkButtonjies = (LinkButton)e.Item.FindControl("lbDel");
        LinkButton lbedit = (LinkButton)e.Item.FindControl("lbedit");
        HiddenField HF = (HiddenField)e.Item.FindControl("HiddenField1");
        Label lb_sfgd = (Label)e.Item.FindControl("lb_sfgd");
        CheckBox cbx = (CheckBox)e.Item.FindControl("cb_id");

        if (lb_sfgd.Text == "已归档")
        {
            LinkButtonjies.Visible = false;
            cbx.Visible = false;
        }
        else
        {
            LinkButtonjies.Visible = true;
            cbx.Visible = true;
        }
    }
    //所属区域
    protected string ssqy(string strwhere)
    {
        string returnstr = string.Empty;
        returnstr = dal.GetDWMCDataTable(strwhere).Rows[0]["qxmc"].ToString();
        return returnstr;
    }

    protected string danganzt(string strwhere1, string strwhere2, string zt)
    {
        string returnstr = string.Empty;
        if (strwhere1.IndexOf("*") != -1)
        {
            returnstr = "已遗失";
        }
        else if (strwhere2.IndexOf("*") != -1)
        {
            returnstr = "已遗失";
        }
        else
        {
            returnstr = zt;
        }
        return returnstr;
    }

}