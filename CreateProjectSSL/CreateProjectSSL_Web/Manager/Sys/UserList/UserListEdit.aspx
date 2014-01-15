<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserListEdit.aspx.cs" Inherits="Manager_Sys_UserList_UserListEdit" %>

<%@ Register Src="~/ConfigCol/Manager.ascx" TagName="header" TagPrefix="headerControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>执法档案-用户管理</title>
    <headerControl:header ID="header" runat="server" />
</head>
<body style="padding: 5px;">
    <form id="form1" runat="server">
    <div>
        <div class="navigation">
            <span class="back"><a  href="UserListList.aspx">返回列表</a></span><b>您当前的位置：系统设置&gt;增加用户</b>
        </div>
        <div style="padding-bottom: 10px;">
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
            <tr>
                <td width="25%" align="right">
                    用户名：
                </td>
                <td>
                    <asp:TextBox ID="txtuserName" runat="server" CssClass="txtbottomstyle">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="25%" align="right">
                    密码：
                </td>
                <td>
                    <asp:TextBox ID="txtpassWord" runat="server" CssClass="txtbottomstyle" TextMode="Password"
                        Width="160px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="25%" align="right">
                    真实姓名：
                </td>
                <td>
                    <asp:TextBox ID="txtuserRealName" runat="server" CssClass="txtbottomstyle">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="25%" align="right">
                    电话：
                </td>
                <td>
                    <asp:TextBox ID="txtuserTel" runat="server" CssClass="txtbottomstyle">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="25%" align="right">
                    用户状态：
                </td>
                <td>
                    <asp:RadioButtonList ID="txtuserState" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Selected="True" Value="0">正常</asp:ListItem>
                        <asp:ListItem Value="1">锁定</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td width="25%" align="right">
                    邮件：
                </td>
                <td>
                    <asp:TextBox ID="txtuserMail" runat="server" CssClass="txtbottomstyle">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="25%" align="right">
                    组织机构：
                </td>
                <td>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="txtuserPost" runat="server" CssClass="txtbottomstyle" Height="24px"
                                Width="140px" AutoPostBack="True" OnSelectedIndexChanged="txtuserPost_SelectedIndexChanged">
                                <asp:ListItem Value="支队">支队</asp:ListItem>
                                <asp:ListItem Value="大队">大队</asp:ListItem>
                                <asp:ListItem Value="超级用户">超级用户</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="drop_qxdm" runat="server" CssClass="txtbottomstyle" Height="24px"
                                Width="134px">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
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
