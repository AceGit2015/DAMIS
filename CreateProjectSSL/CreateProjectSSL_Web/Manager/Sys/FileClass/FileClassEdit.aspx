<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileClassEdit.aspx.cs" Inherits="Manager_Sys_FileClass_FileClassEdit" %>

<%@ Register Src="~/ConfigCol/Manager.ascx" TagName="header" TagPrefix="headerControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>执法档案-案卷类别管理</title>
    <headerControl:header ID="header" runat="server" />
</head>
<body style="padding: 5px;">
    <form id="form1" runat="server">
    <div>
        <div class="navigation">
            <span class="back"><a href="FileClassList.aspx">返回列表</a></span><b>您当前的位置：案卷类别管理&gt;增加</b>
        </div>
        <div style="padding-bottom: 10px;">
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
            <tr>
                <td width="25%" align="right">
                    案卷类别名称：
                </td>
                <td>
                    <asp:TextBox ID="txtFileName" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
                                <tr>
                                    <td width="25%" align="right">
                                        上级案卷名称：
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drop_parentFileName" runat="server" CssClass="txtbottomstyle"
                                            AutoPostBack="True" Height="25px" OnSelectedIndexChanged="drop_parentFileName_SelectedIndexChanged"
                                            Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" align="right">
                                        案卷类别代号：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFileCode" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <div style="margin-top: 10px; text-align: center;">
            <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="submit" OnClick="btnSave_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="Reset" runat="server" Text="重置" CssClass="submit" OnClick="Reset_Click" />
        </div>
        
    </div>
    </form>
</body>
</html>
