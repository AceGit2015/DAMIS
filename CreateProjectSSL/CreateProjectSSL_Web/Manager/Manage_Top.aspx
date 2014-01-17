<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage_Top.aspx.cs" Inherits="Manager_Manage_Top" %>

<%@ Register Src="~/ConfigCol/Index.ascx" TagName="header" TagPrefix="headerControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <headerControl:header ID="header" runat="server" />
    <script language="javascript" type="text/javascript">
<!--
        //获得当前时间,刻度为一千分一秒
        var initializationTime = (new Date()).getTime();
        function showLeftTime() {
            var now = new Date();
            var year = now.getFullYear();
            var month = now.getMonth();
            var day = now.getDate();
            var hours = now.getHours();
            var minutes = now.getMinutes();
            var seconds = now.getSeconds();
            document.all.show.innerHTML = "" + year + "年" + (month+1) + "月" + day + "日 " + hours + ":" + minutes + ":" + seconds + "";
            //一秒刷新一次显示时间
            var timeID = setTimeout(showLeftTime, 1000);
        }
        //-->
        function confirm2() {
            if (confirm("确认退出系统吗？")) {
                document.getElementById('<%=LinkButton1.ClientID%>').click();
            }
        }
    </script>
</head>
<body onload="showLeftTime()">
    <form id="form1" runat="server">
    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td height="81">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="81" align="left" valign="top" background="../Images/topbg.jpg">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="55">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="55" height="55" background="../Images/mainlogo.png">
                                                </td>
                                                <td>
                                                    <font style="font-style: italic; font-size: 24px;"> </font>
                                                    <font style="font-size: 24px;"><span >消防执法档案管理系统</span></font>
                                                </td>
                                                <td>
                                                    <table border="0" align="right" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="70" height="55" align="center" valign="top">
                                                                <a href="Manage_Center.aspx" target="sysMain">
                                                                    <img src="../Images/topmenu1.png" width="70" height="55" border="0" />
                                                                </a>
                                                            </td>
                                                            <td width="70" height="55" align="center" valign="top">
                                                                <a href="DocumentInfor/FileEnter/FileEnterEdit.aspx" target="sysMain">
                                                                    <img src="../Images/topmenu2.png" width="70" height="55" border="0" />
                                                                </a>
                                                            </td>
                                                            <td width="70" height="55" align="center" valign="top">
                                                                <a href="Statistic/DocumentList.aspx" target="sysMain">
                                                                    <img src="../Images/topmenu3.png" width="70" height="55" border="0" />
                                                                </a>
                                                            </td>
                                                            <td width="70" height="55" align="center" valign="top">
                                                                <a href="Sys/UserList/UserUpdatePwd.aspx" target="sysMain">
                                                                    <img src="../Images/topmenu4.png" width="70" height="55" border="0" />
                                                                </a>
                                                            </td>
                                                            <td width="70" height="55" align="center" valign="top">
                                                                <a href="javascript:void(0)" onclick="window.open('../Helper/SSL档案管理系统(操作手册).pdf')"
                                                                    target="sysMain">
                                                                    <img src="../Images/help.png" width="70" height="55" border="0" />
                                                                </a>
                                                            </td>
                                                            <td width="70" height="55" align="center" valign="top">
                                                                <a href="javascript:void(0)" onclick="confirm2()">
                                                                    <img src="../Images/topmenu5.png" width="70" height="55" border="0" /></a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="whitefonts">
                                                    <img src="../Images/user.png" />
                                                    所属单位：<%=EnforcementName%> 当前用户：<%=UserName %> 
                                                </td>
                                                <td width="260" class="whitefonts">
                                                    系统时间：
                                                    <label id="show">
                                                    </label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="1">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div style="display: none;">
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">退出系统</asp:LinkButton>
    </div>
    </form>
</body>
</html>
