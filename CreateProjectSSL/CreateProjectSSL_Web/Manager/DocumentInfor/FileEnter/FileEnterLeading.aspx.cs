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

public partial class Manager_DocumentInfor_FileEnter_FileEnterLeading : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {

        }
    }

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
        string getSheetName = "建审";
        if (fileclassID == 12)
            getSheetName = "验收";
        if (fileclassID == 13)
            getSheetName = "开业";

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
            if (dtS.Rows[i][1].ToString() != "")
            {
                
                sqlStr += @" if  not exists(select * from [FileEnter] where FileClassID= " + fileclassID + " and FilesNum = '" + dtS.Rows[i][1] + "' and PicDocumentNo= '" + dtS.Rows[i][0] + "') ";
                string[] fileName;
                string BuildUnitName = string.Empty;
                string BuildItemName = string.Empty;
                switch (fileclassID)
                {
                        
                    case 11:  //大队建审
                        fileName = dtS.Rows[i][2].ToStr().Split(new string[] { "+" }, StringSplitOptions.RemoveEmptyEntries);
                        if (fileName.Length==1)
                        {
                            BuildUnitName = fileName[0];
                            BuildItemName = "";
                        }
                        else if (fileName.Length > 1)
                        {
                            BuildUnitName = fileName[0];
                            BuildItemName = fileName[1];
                        }
                        sqlStr += @" begin  insert into [FileEnter](FilesName,PicDocumentNo,FilesNum,FileaddName,BuildAds,BuildUnitName,BuildArea,buildingHeight,BuildALicense,PicDicL,EngDroping,BuildItemName,
                                     EnteCountyId,EnteUserName,EnforcementID,EnforcementName,FileClassID,SaveDeadlineID,FileDirectoryID,DepartmentDataTime,EnterPeople,YesUnit)
                                     values('" + dtS.Rows[i][2].ToStr().Replace("+", "") + "','" + dtS.Rows[i][0].ToStr() + "','" + dtS.Rows[i][1].ToStr() + "','" + dtS.Rows[i][2].ToStr().Replace("+", "") + "','" + dtS.Rows[i][3].ToStr() + "', '"+ BuildUnitName + "', '" + dtS.Rows[i][5].ToStr() + "','" + dtS.Rows[i][6].ToStr() + "','" + (dtS.Rows[i][7].ToStr() == "合格" ? 0 : 1) + "','"
                                               + dtS.Rows[i][8].ToStr() + "','" + dtS.Rows[i][9].ToStr() + "','"+ BuildItemName
                                               + "','" + LoginUser.CountyId + "','" + LoginUser.GetUserName + "','" + LoginUser.OrganizerId + "','" + LoginUser.OrganizerName + "'," + fileclassID + ",1,1,'" + DateTime.Now + "','" + LoginUser.GetUserName + "','" + dtS.Rows[i][4].ToStr() + "') end ";
                        break;
                    case 12:  //大队验收
                        fileName = dtS.Rows[i][3].ToStr().Split(new string[] { "+" }, StringSplitOptions.RemoveEmptyEntries);
                        if (fileName.Length==1)
                        {
                            BuildUnitName = fileName[0];
                            BuildItemName = "";
                        }
                        else if (fileName.Length > 1)
                        {
                            BuildUnitName = fileName[0];
                            BuildItemName = fileName[1];
                        }
                        sqlStr += @" begin  insert into [FileEnter](FilesName,PicDocumentNo,FilesNum,FileaddName,BuildAds,BuildUnitName,BuildArea,buildingHeight,PicDicL,BuildALicense,EngDroping,BuildItemName,
                                     EnteCountyId,EnteUserName,EnforcementID,EnforcementName,FileClassID,SaveDeadlineID,FileDirectoryID,DepartmentDataTime,EnterPeople,YesUnit,CheckItemName)
                                     values('" + dtS.Rows[i][3].ToStr().Replace("+", "") + "','" + dtS.Rows[i][0].ToStr() + "','" + dtS.Rows[i][1].ToStr() + "','" + dtS.Rows[i][3].ToStr().Replace("+", "") + "','" + dtS.Rows[i][5].ToStr() + "', '"
                                            + BuildUnitName + "', '" + dtS.Rows[i][6].ToStr() + "','" + dtS.Rows[i][7].ToStr() + "','" + dtS.Rows[i][9].ToStr() + "','"
                                            + (dtS.Rows[i][8].ToStr() == "合格" ? 0 : 1) + "','" + dtS.Rows[i][10].ToStr() + "','"
                                            + BuildItemName
                                            + "','" + LoginUser.CountyId + "','" + LoginUser.GetUserName + "','" + LoginUser.OrganizerId + "','" + LoginUser.OrganizerName + "'," + fileclassID + ",1,1,'" + DateTime.Now + "','" + LoginUser.GetUserName + "','" + dtS.Rows[i][4].ToStr() + "','" + dtS.Rows[i][2].ToStr() + "') end ";
                        break;
                    case 13:  //大队开业
                        sqlStr += @" begin  insert into [FileEnter](FilesName,PicDocumentNo,FilesNum,FileaddName,CheckAds,CheckResult,PicDicL,EngDroping,CheckUnitName,
                                     EnteCountyId,EnteUserName,EnforcementID,EnforcementName,FileClassID,SaveDeadlineID,FileDirectoryID,DepartmentDataTime,EnterPeople)
                                     values('" + dtS.Rows[i][2].ToStr() + "','" + dtS.Rows[i][0].ToStr() + "','" + dtS.Rows[i][1].ToStr() + "','" + dtS.Rows[i][2].ToStr() + "','" + dtS.Rows[i][3].ToStr() + "', '"
                                            + (dtS.Rows[i][4].ToStr() == "合格" ? 0 : 1) + "','" + dtS.Rows[i][5].ToStr() + "','" + dtS.Rows[i][6].ToStr() + "','"
                                            + dtS.Rows[i][2].ToStr()
                                            + "','" + LoginUser.CountyId + "','" + LoginUser.GetUserName + "','" + LoginUser.OrganizerId + "','" + LoginUser.OrganizerName + "'," + fileclassID + ",1,1,'" + DateTime.Now + "','" + LoginUser.GetUserName + "') end ";
                        break;
                }

            }
        }
        #endregion


        int count = 0;  //定义受影响的行数
        try
        {
            count = TSQLServer.execTrigger(sqlStr);
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
}