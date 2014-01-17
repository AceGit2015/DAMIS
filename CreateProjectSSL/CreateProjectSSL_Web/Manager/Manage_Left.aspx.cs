using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ToolsCommon;

public partial class Manager_Manage_Left : BasePage
{
    #region
    /// <summary>
    /// 所在区县代码
    /// </summary>
    public string strSzqxdm
    {
        get
        {
            if (ViewState["VS_strSzqxdm"] == null)
            {
                return "";//空参数转化的对应默认值
            }
            return (string)ViewState["VS_strSzqxdm"];

        }
        set
        {
            ViewState["VS_strSzqxdm"] = value;
        }
    }

    public string StrMeun
    {
        get
        {
            if (ViewState["VS_strmrun"] == null)
            {
                return "";//空参数转化的对应默认值
            }
            return (String)ViewState["VS_strmrun"];
        }
        set
        {
            ViewState["VS_strmrun"] = value;
        }
    }
    #endregion

    public string UserName = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            strSzqxdm = LoginUser.CountyId;
            UserQX();
            if (Session["GetUserName"] == null)
                Response.Write("<script>window.parent.location.href='../Login.aspx';</script>");
            else
                UserName = LoginUser.GetUserName;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session.Clear();
        Response.Write("<script>window.parent.location.href='../Login.aspx';</script>");
    }

    protected void UserQX()
    {
        if (strSzqxdm == "420100")
        {
            StrMeun += @"<div id=""leftMenu_1"" style=""display: block;"">
                                <table width=""143"" height=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                                    <tr>
                                        <td class=""lefttitle"" >
                                              <img src=""../Images/t1.png"" /> 档案管理
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align=""left"" valign=""top"" class=""leftmenu"">
                                              <a href=""DocumentInfor/FileEnter/FileEnterList.aspx"" target=""sysMain"">档案录入</a>
                                              <a href=""DocumentInfor/FileEnter/FileEnterLeading.aspx"" target=""sysMain"">档案导入</a>
                                              <a href=""DocumentInfor/FileBorrow/FileBorrowList.aspx"" target=""sysMain"">档案借阅</a>
                                              <a href=""DocumentInfor/FileDestroy/FileDestroyList.aspx"" target=""sysMain"">档案销毁</a>
                                              <a href=""DocumentInfor/FileTransfer/FileTransferList.aspx"" target=""sysMain"">档案移交</a>
                                              <a href=""DocumentInfor/FileTransfer/FileTransferyjzdList.aspx"" target=""sysMain"">移交支队记录</a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id=""leftMenu_2"" style=""display: block;"">
                                <table width=""143"" height=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                                    <tr>
                                        <td class=""lefttitle"">
                                              <img src=""../Images/t2.png"" /> 统计分析
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align=""left"" valign=""top"" class=""leftmenu"">
                                               <a href=""Statistic/DocumentList.aspx"" target=""sysMain"">案卷统计</a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id=""leftMenu_3"" style=""display: block;"">
                                <table width=""143"" height=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                                    <tr>
                                        <td class=""lefttitle"" >
                                             <img src=""../Images/t3.png"" /> 基本信息
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align=""left"" valign=""top"" class=""leftmenu"">
                                            <a href=""Sys/FileDirectory/FileDirectoryList.aspx"" target=""sysMain"">档案目录</a>
                                            <a href=""Sys/FileClass/FileClassList.aspx"" target=""sysMain"">案卷类别</a>
                                            <a href=""Sys/Organizer/OrganizerList.aspx"" target=""sysMain"">承办单位</a> 
                                            <a href=""Sys/PunishType/PunishTypeList.aspx"" target=""sysMain"">处罚类型</a>
                                            <a href=""Sys/SaveDeadline/SaveDeadlineList.aspx"" target=""sysMain"">保管期限</a>
                                            <a href=""Sys/FileLibrary/FileLibraryList.aspx"" target=""sysMain"">档案库室</a>
                                            <a href=""Sys/Area/AreaList.aspx"" target=""sysMain"">行政区</a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id=""leftMenu_4"" style=""display: block;"">
                                <table width=""143"" height=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                                    <tr valign=""center"">
                                        <td class=""lefttitle"" >
                                             <img src=""../Images/t4.png""  /> 系统管理
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align=""left"" valign=""top"" class=""leftmenu"">
                                            <a href=""Sys/UserList/UserListList.aspx"" target=""sysMain"">用户信息</a>
                                            <a href=""Sys/UserList/UserUpdatePwd.aspx"" target=""sysMain"">修改密码</a> 
                                            <a href=""javascript:void(0)""   onclick=""confirm2()""  target=""sysMain"">退出系统</a>
                                        </td>
                                    </tr>
                                </table>
                            </div>";
        }
        else if (strSzqxdm == "420000")
        {

            StrMeun += @"<div id=""leftMenu_1"" style=""display: block;"">
                                <table width=""143"" height=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                                    <tr>
                                        <td class=""lefttitle"">
                                            <img src=""../Images/t1.png""  /> 档案管理
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align=""left"" valign=""top"" class=""leftmenu"">
                                              <a href=""DocumentInfor/FileEnter/FileEnterDelete.aspx"" target=""sysMain"">档案删除</a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id=""leftMenu_2"" style=""display: block;"">
                                <table width=""143"" height=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                                    <tr>
                                        <td class=""lefttitle"">
                                           <img src=""../Images/t2.png""  /> 统计分析
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align=""left"" valign=""top"" class=""leftmenu"">
                                           <a href=""Statistic/DocumentList.aspx"" target=""sysMain"">案卷统计</a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id=""leftMenu_4"" style=""display: block;"">
                                <table width=""143"" height=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                                    <tr>
                                        <td class=""lefttitle"">
                                              <img src=""../Images/t4.png"" />系统管理
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align=""left"" valign=""top"" class=""leftmenu"">
                                            <a href=""Sys/UserList/UserUpdatePwd.aspx"" target=""sysMain"">修改密码</a> 
                                            <a href=""javascript:void(0)""   onclick=""confirm2()""  target=""sysMain"">退出系统</a>
                                        </td>
                                    </tr>
                                </table>
                            </div>";
        }
        else
        {


            StrMeun += @"<div id=""leftMenu_1"" style=""display: block;"">
                                <table width=""143"" height=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                                    <tr>
                                        <td class=""lefttitle"">
                                            <img src=""../Images/t1.png""  /> 档案管理
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align=""left"" valign=""top"" class=""leftmenu"">
                                              <a href=""DocumentInfor/FileEnter/FileEnterList.aspx"" target=""sysMain"">档案录入</a>
                                              <a href=""DocumentInfor/FileEnter/FileEnterLeading.aspx"" target=""sysMain"">档案导入</a>
                                              <a href=""DocumentInfor/FileBorrow/FileBorrowList.aspx"" target=""sysMain"">档案借阅</a>
                                              <a href=""DocumentInfor/FileDestroy/FileDestroyList.aspx"" target=""sysMain"">档案销毁</a>
                                              <a href=""DocumentInfor/FileTransfer/FileTransferList.aspx"" target=""sysMain"">档案移交</a>
                                              <a href=""DocumentInfor/FileTransfer/FileTransferyjzd.aspx"" target=""sysMain"">移交支队</a>
                                              <a href=""DocumentInfor/FileTransfer/FileTransferyjzdList.aspx"" target=""sysMain"">移交支队记录</a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id=""leftMenu_2"" style=""display: block;"">
                                <table width=""143"" height=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                                    <tr>
                                        <td class=""lefttitle"">
                                           <img src=""../Images/t2.png""  /> 统计分析
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align=""left"" valign=""top"" class=""leftmenu"">
                                           <a href=""Statistic/DocumentList.aspx"" target=""sysMain"">案卷统计</a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id=""leftMenu_3"" style=""display: block;"">
                                <table width=""143"" height=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                                    <tr>
                                        <td class=""lefttitle"">
                                             <img src=""../Images/t3.png"" /> 基本信息
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align=""left"" valign=""top"" class=""leftmenu"">
                                            <a href=""Sys/FileLibrary/FileLibraryList.aspx"" target=""sysMain"">档案库室</a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id=""leftMenu_4"" style=""display: block;"">
                                <table width=""143"" height=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                                    <tr>
                                        <td class=""lefttitle"">
                                              <img src=""../Images/t4.png"" />系统管理
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align=""left"" valign=""top"" class=""leftmenu"">
                                            <a href=""Sys/UserList/UserUpdatePwd.aspx"" target=""sysMain"">修改密码</a> 
                                            <a href=""javascript:void(0)""   onclick=""confirm2()""  target=""sysMain"">退出系统</a>
                                        </td>
                                    </tr>
                                </table>
                            </div>";

        }
    }
}