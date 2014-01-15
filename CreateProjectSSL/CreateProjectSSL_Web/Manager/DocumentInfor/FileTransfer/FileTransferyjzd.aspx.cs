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
using System.Collections;

public partial class Manager_DocumentInfor_FileEnter_FileTransferyjzd : BasePage
{
    //定义对象实例化
    FileEnterDal dal = new FileEnterDal();
    FileLibraryDal fldal = new FileLibraryDal();   //档案库名称
    FileClassDal fileclass = new FileClassDal();
    FileTransferDal tfdal = new FileTransferDal();
    ToolsModel.FileEnter model = new ToolsModel.FileEnter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Pager1.PageIndex = 0; //默认为0
            this.BindDaSource();
            BindDataQA();
        }
    }

    public void BindDataQA()
    {
        DataTable execDt = fileclass.GetDataTable(" and parentFileID <> 0");
        fFileName.DataSource = execDt;
        this.fFileName.DataTextField = "FileName";
        this.fFileName.DataValueField = "id";
        this.fFileName.DataBind();
        this.fFileName.Items.Insert(0, new ListItem("-请选择-", "0"));
    }


    private void BindDaSource()
    {
        //获取查询条件
        model.FilesName = this.GetRequestStr("ftxtFilesName");
        model.FilesNum = this.GetRequestStr("txtFilesNum");
        model.EnterPeople = this.GetRequestStr("txtEnterPeople");
        model.FileClassID = this.GetRequestInt("fFileName");
        model.NumStatic = this.drop_time.SelectedItem.Value;
        model.tmp_Data = this.GetRequestStr("fStarttime") + '|' + this.GetRequestStr("fEndtime");//开始时间和结束时间
        model.SJLX = -1;
        //实现分页，调用分页类
        Pager1.PageSize = TSQLServer.PageSize.ToInt32(); //默认显示数据信息条数
        PeterPages fenye1 = dal.GetSearch(model, this.Pager1.PageIndex + 1, Pager1.PageSize, LoginUser.CountyId);
        this.rptyjzdList.DataSource = fenye1.Ds;
        rptyjzdList.DataBind();
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
    //批量移交支队
    protected void lbtnFileTransfer_Click(object sender, EventArgs e)
    {
        string ids = "0";
        for (int i = 0; i < rptyjzdList.Items.Count; i++)
        {
            int id = ((Label)rptyjzdList.Items[i].FindControl("lb_id")).Text.ToInt32();
            CheckBox cb = (CheckBox)rptyjzdList.Items[i].FindControl("cb_id");
            if (cb.Checked)
            {
                ids += "," + id;
            }
        }

        DataTable dttf = dal.GetDataTableyjzd(" and id in (" + ids + ") ");
        ArrayList alsql = new ArrayList();
        Boolean flag = false;
        if (AccessDataSet.HasDataTable(dttf))
        {

            foreach (DataRow item in dttf.Rows)
            {
                string sqlStr = "";  //添加移交记录
                sqlStr = " insert into FileTransfer(FileEnterID,FileClassID,FileClassName,FileEnterName,TransferPeople,TransferUnit,AcceptSzqxdm,TransferDate,OperateTime,Remark,UserID,Username,sjzt,SZQXDM,Yjlx) values ('" + item["id"].ToString() + "','" + item["FileClassID"].ToString() + "','" + item["FName"].ToString() + "','" + item["FilesName"].ToString() + "','" + LoginUser.GetUserName + "','" + LoginUser.OrganizerName + "','420100','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','','" + LoginUser.GetUserId + "','" + LoginUser.GetUserName + "',0,'" + LoginUser.CountyId + "',1) ";
                alsql.Add(sqlStr);
                string strupdate = ""; //更新移交时间
                strupdate = " update FileEnter set  FileTransferDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',sjlx=3 where id='" + item["id"].ToString() + "' ";
                alsql.Add(strupdate);
            }
            flag = TSQLServer.execTriggerAll(alsql);
        }
        if (flag==true)
        {
            new MessageBox(Page).ShowAndJump("批量移交支队成功!", "FileTransferyjzd.aspx");
            //操作日志
            LogListDal.Insert(DateTime.Now, "案卷档案[" + ids + "]批量移交支队", LoginUser.GetUserId, LoginUser.GetUserName);
        }
        else
        {
            new MessageBox(Page).ShowAndJump("批量移交支队失败!", "FileTransferyjzd.aspx");
        }
        this.BindDaSource();
    }

    //单个移交支队
    protected void rptyjzdList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label cb_id = (Label)e.Item.FindControl("lb_id");

        switch (e.CommandName.ToLower())
        {
            case "transfer":
                DataRow drdg = dal.GetRow(cb_id.Text);
                if (drdg != null)
                {
                    ArrayList alsql = new ArrayList();
                    string sqlStr = "";  //添加移交记录
                    sqlStr = " insert into FileTransfer(FileEnterID,FileClassID,FileClassName,FileEnterName,TransferPeople,TransferUnit,AcceptSzqxdm,TransferDate,OperateTime,Remark,UserID,Username,sjzt,SZQXDM,Yjlx) values ('" + drdg["id"].ToString() + "','" + drdg["FileClassID"].ToString() + "','" + drdg["FName"].ToString() + "','" + drdg["FilesName"].ToString() + "','" + LoginUser.GetUserName + "','" + LoginUser.OrganizerName + "','420100','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','','" + LoginUser.GetUserId + "','" + LoginUser.GetUserName + "',0,'" + LoginUser.CountyId + "',1) ";
                    alsql.Add(sqlStr);
                    string strupdate = ""; //更新移交时间
                    strupdate = " update FileEnter set  FileTransferDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',sjlx=3 where id='" + drdg["id"].ToString() + "' ";
                    alsql.Add(strupdate);
                    Boolean flag= TSQLServer.execTriggerAll(alsql);
                    if (flag==true)
                    {
                        new MessageBox(Page).ShowAndJump("执法档案" + drdg["FilesName"].ToString() + "移交支队成功!", "FileTransferyjzd.aspx");
                        //操作日志
                        LogListDal.Insert(DateTime.Now, "执法档案" + drdg["id"].ToString() + "+" + drdg["FilesName"].ToString() + "移交支队", LoginUser.GetUserId, LoginUser.GetUserName);
                    }
                    else
                    {
                        new MessageBox(Page).ShowAndJump("执法档案" + drdg["FilesName"].ToString() + "移交支队失败!", "FileTransferyjzd.aspx");
                    }
                }
                else
                {
                    new MessageBox(Page).ShowAndJump("执法档案" + drdg["FilesName"].ToString() + "移交支队失败!", "FileTransferyjzd.aspx");
                }

                this.BindDaSource();
                break;
        }
    }


    #region 删除时，注册注册到客户端JavaScript数组
    protected void rptyjzdList_PreRender(object sender, EventArgs e)
    {
        prerepater(rptyjzdList, this);
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