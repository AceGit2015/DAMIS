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
public partial class Manager_Statistic_DocumentList : BasePage
{
    //定义对象实例化
    FileEnterDal dal = new FileEnterDal();
    FileClassDal fileclass = new FileClassDal();
    public string thTitle = "";
    public string thValue = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
            BindDaSource();
        }
    }


    public void BindData()
    {
        DataTable execDt = fileclass.GetDataTable(" and parentFileID = 0");
        fFileName.DataSource = execDt;
        this.fFileName.DataTextField = "FileName";
        this.fFileName.DataValueField = "id";
        this.fFileName.DataBind();
        this.fFileName.Items.Insert(0, new ListItem("-请选择-", "0"));
    }

    //页面加载绑定数据源
    private void BindDaSource()
    {
        //获取查询条件
        int FileClassID = this.GetRequestInt("fFileName");
        string EnteCountyId = LoginUser.CountyId;
        DataTable execDt = dal.GetDataTableProc("FileReport_Count", FileClassID,EnteCountyId, "FileReport_Count");

        for (int i = 1; i < execDt.Columns.Count; i++)
        {
            thTitle += " <th style='width: 240px; align='center'>" + execDt.Columns[i].ColumnName + "</th>";
            thValue += " <td style='width: 240px; align='center'> " + execDt.Rows[0][execDt.Columns[i].ColumnName] + "</td>";
        }
    }

    protected void fFileName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDaSource();
    }

}