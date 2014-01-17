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

public partial class Manager_Sys_LogList_LogListList : BasePage
{
    ToolsModel.LogList model = new ToolsModel.LogList();
    ToolsDal.LogListDal dal = new LogListDal();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Pager1.PageIndex = 0; //默认为0
            BindDaSource();
        }
    }
    //页面加载绑定数据源
    private void BindDaSource()
    {
        //获取查询条件
        model.username = this.GetRequestStr("fuserName");
        model.tmp_Data = this.GetRequestStr("fStarttime") + '|' + this.GetRequestStr("fEndtime");//开始时间和结束时间

        //实现分页，调用分页类
        Pager1.PageSize = TSQLServer.PageSize.ToInt32(); //默认显示数据信息条数
        PeterPages fenye1 = dal.GetSearch(model, this.Pager1.PageIndex + 1, Pager1.PageSize);
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
            int id = Convert.ToInt32(((Label)rptList.Items[i].FindControl("lb_id")).Text);
            CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
            if (cb.Checked)
            {
                ids += "," + id;
            }
        }

        dal.DeleteAllIn(ids);
        //Alert("批量删除成功", "LogListList.aspx");
        new MessageBox(Page).ShowAndJump("批量删除成功!", "LogListList.aspx");
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
                //Alert("删除成功", "LogListList.aspx");
                new MessageBox(Page).ShowAndJump("删除成功!", "LogListList.aspx");
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
}