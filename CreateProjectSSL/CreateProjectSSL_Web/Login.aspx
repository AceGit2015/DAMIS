<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ Register Src="~/ConfigCol/Login.ascx" TagName="header" TagPrefix="headerControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SSL档案管理系统</title>
    <headerControl:header ID="header" runat="server" />
    <style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	background-color: #1D3647;
}
-->
</style>
    <script language="JavaScript" type="text/javascript">
        function GetFocus() {
            document.all.txtusername.focus(); //进入页面鼠标光标默认在txt_name里面
        }
    </script>
    <script language="javascript" type="text/javascript">
        function Body_OnKeyDown() {
            if ((window.event.keyCode == 13)) {
                document.getElementById("btnLogin").click();
            }
        }
    </script>
    <link href="Images/skin.css" rel="stylesheet" type="text/css" />
</head>
<body style="font-size: 14px;">
    <form id="form1" runat="server">
    <div>
        <table width="100%" height="166" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td height="42" valign="top">
                    <table width="100%" height="42" border="0" cellpadding="0" cellspacing="0" class="login_top_bg">
                        <tr>
                            <td width="1%" height="21">
                                &nbsp;
                            </td>
                            <td height="42">
                                &nbsp;
                            </td>
                            <td width="17%">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" height="532" border="0" cellpadding="0" cellspacing="0" class="login_bg">
                        <tr>
                            <td width="49%" align="right">
                                <table width="91%" height="532" border="0" cellpadding="0" cellspacing="0" class="login_bg2">
                                    <tr>
                                        <td height="138" valign="top">
                                            <table width="89%" height="427" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="149">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="122" style="width: 100%;" valign="top">
                                                        <img src="Images/logo.png" width="120" height="120" style="margin-right: 29%;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="198" align="right" valign="top">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td width="45%">
                                                                    &nbsp;
                                                                </td>
                                                                <td height="25" colspan="2" class="left_txt" align="left">
                                                                    <p>
                                                                        1- 档案录入方便、灵活、快捷...</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td height="25" colspan="2" class="left_txt" align="left">
                                                                    <p>
                                                                        2- EXCEL导入功能提高档案录入速度...</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td height="25" colspan="2" class="left_txt" align="left">
                                                                    <p>
                                                                        3- 强大的后台系统，管理内容易如反掌...</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td width="30%" height="40">
                                                                </td>
                                                                <td width="35%">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td width="50%" valign="bottom">
                                <table width="100%" height="59" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="4%">
                                            &nbsp;
                                        </td>
                                        <td width="96%" height="38">
                                            <span class="login_txt_bt">SSL档案管理系统V1.0</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td height="21">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0" id="table211" height="328">
                                                <tr>
                                                    <td height="164" colspan="2" align="middle">
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0" height="143" id="table212">
                                                            <tr>
                                                                <td width="13%" height="38" class="top_hui_text">
                                                                    <span class="login_txt">管理员：&nbsp;&nbsp; </span>
                                                                </td>
                                                                <td height="38" colspan="2" class="top_hui_text" align="left">
                                                                    <asp:TextBox ID="txtusername" runat="server" Style="width: 200px;">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="13%" height="35" class="top_hui_text">
                                                                    <span class="login_txt">&nbsp;密&nbsp;&nbsp;&nbsp;&nbsp;码： &nbsp;&nbsp; </span>
                                                                </td>
                                                                <td height="35" colspan="2" class="top_hui_text" align="left">
                                                                    <asp:TextBox ID="txtUserPwd" runat="server" Style="width: 200px;" TextMode="Password">
                                                                    </asp:TextBox>
                                                                    <img src="images/luck.gif" width="19" height="18">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="25">
                                                                    &nbsp;
                                                                </td>
                                                                <td width="15%" height="25">
                                                                    <asp:Button ID="btnLogin" runat="server" Text="登 陆" class="button green" OnClick="btnLogin_Click"
                                                                        Width="50px" Height="25px" />
                                                                </td>
                                                                <td width="67%" align="left">
                                                                    <a title="重 置" id="A2" runat="server" onserverclick="btnSet_Click" rel="right" class="button green">
                                                                        重 置</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="433" height="164" align="right" valign="bottom">
                                                        <img src="images/login-wel.gif" width="242" height="138">
                                                    </td>
                                                    <td width="57" align="right" valign="bottom">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="20">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="login-buttom-bg">
                        <tr>
                            <td align="center">
                                <span class="login-buttom-txt">&nbsp&nbsp;SSL档案管理系统&nbsp&nbsp;Copyright ©【 2013-<%=DateTime.Now.Year %>】All
                                    Rights</span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
