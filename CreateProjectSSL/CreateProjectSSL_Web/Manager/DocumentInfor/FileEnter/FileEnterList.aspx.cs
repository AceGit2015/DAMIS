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

public partial class Manager_DocumentInfor_FileEnter_FileEnterList : BasePage
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
            BindDataQA();
            LoadData();
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
            //this.drop_FileLibraryName.Items.Insert(0, new ListItem("--请选择--", ""));
        }


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
        model.SJLX = this.GetRequestInt("txtDocStatus");
        //实现分页，调用分页类
        Pager1.PageSize = TSQLServer.PageSize.ToInt32(); //默认显示数据信息条数
        PeterPages fenye1 = dal.GetSearch(model, this.Pager1.PageIndex + 1, Pager1.PageSize, LoginUser.CountyId);
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
        LoadData();
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

        //dal.DeleteAllIn(ids);
        dal.DeleteAllInUpdate("8", ids);
        new MessageBox(Page).ShowAndJump("批量删除成功!", "FileEnterList.aspx");
        //操作日志
        LogListDal.Insert(DateTime.Now, "案卷档案删除", LoginUser.GetUserId, LoginUser.GetUserName);
        this.BindDaSource();
    }

    //单个删除
    protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label cb_id = (Label)e.Item.FindControl("lb_id");

        switch (e.CommandName.ToLower())
        {
            case "del":
                //dal.Delete(cb_id.Text);
                dal.DeleteUpdate("8", cb_id.Text);
                //Alert("删除成功", "FileClassList.aspx");
                new MessageBox(Page).ShowAndJump("删除成功!", "FileEnterList.aspx");
                //操作日志
                LogListDal.Insert(DateTime.Now, "案卷档案删除", LoginUser.GetUserId, LoginUser.GetUserName);
                this.BindDaSource();
                break;
            case "edit":
                Response.Redirect("FileEnterEdit.aspx?id=" + cb_id.Text + "");
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

    #region 导入数据信息
    /// <summary>
    /// 导入数据信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Ok_Click(object sender, EventArgs e)
    {
        var f = Request.Files["FileUpload1"];  //获取导入文件路径
        int fileclassID = this.GetRequestInt("fileclassID");
        if (f.FileName == "")
        {
            new MessageBox(this).Show("请选择导入数据模板!");
            return;
        }
        string getSheetName = "行政许可";
        if (fileclassID == 12)
            getSheetName = "验收";

        string path = Server.MapPath("~/tmp/" + Guid.NewGuid().ToString() + ".xls");
        f.SaveAs(path);
        FileInfo fi = new FileInfo(path);
        DataTable dtS; //存储Excel读取数据信息
        try
        {
            dtS = path.GetExcel(getSheetName).Tables[0];
        }
        catch
        {
            new MessageBox(this).Show("导入文件不是Excel文件或Excel文件版本不符!");
            return;
        }
        finally
        {
            try
            {
                fi.Delete();
            }
            catch { }
        }

        #region 读取excel表格中数据进行字符串拼接
        string sqlStr = "";  //定义ID变量
        for (int i = 1; i < dtS.Rows.Count; i++)
        {
            if (dtS.Rows[i][0].ToStrTrim() != "")
            {
                string fileName = dtS.Rows[i][4].ToStr();
                sqlStr += @" if  not exists(select * from [FileEnter] where FileClassID= " + fileclassID + " and FilesNum = '" + dtS.Rows[i][1] + "' and PicDocumentNo= '" + dtS.Rows[i][0] + "') ";
                sqlStr += @" begin  insert into [FileEnter](PicDocumentNo,FilesNum,DepartmentUnit,DepartmentDataTime,FilesName ,
                          BuildAds,BuildCheckT,YesUnit,BuildArea,buildingHeight,FormalApp,BuildALicense,BuildRemark,PicDicL,PicDicG,PicDicJ,AJDic,EnterPeople,FileClassID,FileDirectoryID,FileFondsNo,SaveDeadlineID,BuildUnitName,BuildItemName,EnteCountyId,EnteUserName,EnforcementID,EnforcementName)
                                 values('" + dtS.Rows[i][0].ToStr() + "','" + dtS.Rows[i][1].ToStr() + "','" + dtS.Rows[i][2].ToStr() + "','" + DateTime.Now + "','" + fileName
                                  + "', '" + dtS.Rows[i][5].ToStr() + "','" + dtS.Rows[i][6].ToStr() + "','" + dtS.Rows[i][7].ToStr() + "','" + dtS.Rows[i][8].ToStr()
                                  + "','" + dtS.Rows[i][9].ToStr() + "','" + dtS.Rows[i][10].ToStr() + "','" + (dtS.Rows[i][11].ToStr() == "同意" ? 0 : 1) + "','" + dtS.Rows[i][12].ToStr() + "','" + dtS.Rows[i][13].ToStr()
                                  + "','" + dtS.Rows[i][14].ToStr() + "','" + dtS.Rows[i][15].ToStr() + "','" + dtS.Rows[i][16].ToStr() + "',''," + fileclassID + ",1,'',1,'" + fileName + "','" + fileName + "','" + LoginUser.CountyId + "','" + LoginUser.GetUserName + "','" + LoginUser.OrganizerId + "','" + LoginUser.OrganizerName + "')  end ";
            }
        }
        #endregion


        int count = 0;  //定义受影响的行数
        try
        {
            count = TSQLServer.ExecuteNonQuery(sqlStr);
        }
        catch
        {
            new MessageBox(this).Show("导入数据的格式不正确!");
            return;
        }
        new MessageBox(Page).ShowAndJump("已经成功" + "导入" + (count > 0 ? count : 0) + "条数据！!", "FileEnterList.aspx");
        //操作日志
        LogListDal.Insert(DateTime.Now, "" + getSheetName + "导入数据", LoginUser.GetUserId, LoginUser.GetUserName);
    }
    #endregion

    protected void txtDocStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Pager1.PageIndex = 0; //默认为0
        BindDaSource();
    }
    //批量归档
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.drop_FileLibraryName.SelectedItem.Text == "")
        {
            new MessageBox(this.Page).Show("请选择档案库室！");
            return;
        }
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
        if (ids == "0")
        {
            new MessageBox(this.Page).Show("请选择需要归档的档案！");
            return;
        }
        //int line = dal.UpdateAllGD(this.drop_FileLibraryName.SelectedValue, this.drop_FileLibraryName.SelectedItem.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ids);

        DataTable dtgd = dal.GetDataTableyjzd(" and id in (" + ids + ")");

        if (AccessDataSet.HasDataTable(dtgd))
        {
            ArrayList alsql = new ArrayList();
            foreach (DataRow item in dtgd.Rows)
            {
                if (item["FileTransferSJLX"].ToString()=="1"&&item["FileTransferID"].ToString()!="")
                {
                    string sqlStr = "";  //移交记录归档
                    sqlStr = " update FileTransfer set  sjzt=3,Gdr='" + LoginUser.GetUserName + "',Gdsj='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where id='" + item["FileTransferID"] + "' ";
                    alsql.Add(sqlStr);
                    string strupdate = ""; //移交档案归档
                    strupdate = " update FileEnter set  FileLibraryID='" + this.drop_FileLibraryName.SelectedValue + "',FileLibraryName='" + this.drop_FileLibraryName.SelectedItem.Text + "',FileLibraryData='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',FileTransferSJLX=2  where id='" + item["ID"] + "' ";
                    alsql.Add(strupdate);
                }
                else
                {
                    string strupdate = ""; //移交档案归档
                    strupdate = " update FileEnter set  FileLibraryID='" + this.drop_FileLibraryName.SelectedValue + "',FileLibraryName='" + this.drop_FileLibraryName.SelectedItem.Text + "',FileLibraryData='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'  where id='" + item["ID"] + "' ";
                    alsql.Add(strupdate);
                }
            }
            Boolean flag = TSQLServer.execTriggerAll(alsql);
            if (flag == true)
            {
                new MessageBox(Page).ShowAndJump("执法档案批量归档成功!", "FileEnterList.aspx");
                //操作日志
                LogListDal.Insert(DateTime.Now, "归档执法档案" + ids + "批量归档", LoginUser.GetUserId, LoginUser.GetUserName);
            }
            else
            {
                new MessageBox(Page).ShowAndJump("执法档案批量归档失败!", "FileEnterList.aspx");
            }
        }
        else
        {
            new MessageBox(Page).ShowAndJump("执法档案批量归档失败!", "FileEnterList.aspx");
        }
        this.BindDaSource();
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
        //if (HF.Value == LoginUser.CountyId)
        //{
        //    LinkButtonjies.Visible = true;
        //    lbedit.Visible = true;
        //}
        //else
        //{
        //    LinkButtonjies.Visible = false;
        //    lbedit.Visible = false;
        //}
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

    /// <summary>
    /// 保存排架号
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCheckSave_Click(object sender, EventArgs e)
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();

        for (int i = 0; i < rptList.Items.Count; i++)
        {
            string id = ((Label)rptList.Items[i].FindControl("lb_id")).Text.ToStr();
            string txtColumns = ((TextBox)rptList.Items[i].FindControl("txtColumns")).Text.ToStr();
            string txtCupboard = ((TextBox)rptList.Items[i].FindControl("txtCupboard")).Text.ToStr();
            string txtFrame = ((TextBox)rptList.Items[i].FindControl("txtFrame")).Text.ToStr();

            string tmp = txtColumns + "|" + txtCupboard + "|" + txtFrame;
            dic.Add(id, tmp);
        }
        int line = dal.CheckSaveValue(dic);
        if (line > 0)
            new MessageBox(Page).ShowAndJump("保存成功!", "FileEnterList.aspx");
        else
            new MessageBox(this.Page).Show("保存失败！");

    }
    protected void lbDelALL_Click(object sender, EventArgs e)
    {
        int line =dal.DeleteAllInfor(LoginUser.CountyId);
        if (line > 0)
            new MessageBox(Page).ShowAndJump("清理完成!", "FileEnterList.aspx");
        else
            new MessageBox(this.Page).Show("清理失败！");
    }
}