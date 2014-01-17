<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserUpdatePwd.aspx.cs" Inherits="Manager_Sys_UserList_UserUpdatePwd" %>

<%@ Register Src="~/ConfigCol/Manager.ascx" TagName="header" TagPrefix="headerControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改密码</title>
    <headerControl:header ID="header" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="navigation">
            <b>您当前的位置：系统设置&gt;修改密码</b>
        </div>
        <div style="padding-bottom: 10px;">
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
            <tr>
                <td width="25%" align="right">
                    原 密 码：
                </td>
                <td>
                    <asp:TextBox ID="txtysmm" runat="server" CssClass="txtbottomstyle" TextMode="Password"
                        Width="150px">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="25%" align="right">
                    新 密 码：
                </td>
                <td>
                    <asp:TextBox ID="txtxmm" runat="server" CssClass="txtbottomstyle" TextMode="Password"
                        Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="25%" align="right">
                    确认新密码：
                </td>
                <td>
                    <asp:TextBox ID="txtzsyc" runat="server" CssClass="txtbottomstyle" TextMode="Password"
                        Width="150px">
                    </asp:TextBox>
                </td>
            </tr>
        </table>
        <div style="margin-top: 10px; text-align: center;">
         <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="submit"  OnClick="btnSave_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="Reset" runat="server" Text="重置" CssClass="submit"  OnClick="Reset_Click" />
        </div>
    </div>
    </form>
</body>
</html>
