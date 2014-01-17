<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PunishTypeEdit.aspx.cs" Inherits="Manager_Sys_PunishType_PunishTypeEdit" %>

<%@ Register Src="~/ConfigCol/Manager.ascx" TagName="header" TagPrefix="headerControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>执法档案-处罚类型</title>
    <headerControl:header ID="header" runat="server" />
    <style type="text/css">
        .txtbottomstyle
        {
        }
    </style>
</head>
<body style="padding: 5px;">
    <form id="form1" runat="server">
    <div>
        <div class="navigation">
            <span class="back"><a href="PunishTypeList.aspx">返回列表</a></span><b>您当前的位置： 处罚类型 &gt;增加</b>
        </div>
        <div style="padding-bottom: 10px;">
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
            <tr>
                <td width="25%" align="right">
                    处罚类型名称：
                </td>
                <td>
                    <asp:TextBox ID="txtPunishTypeName" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="25%" align="right">
                    档案类别：
                </td>
                <td>
                    <asp:DropDownList ID="drop_FileClassName" runat="server" CssClass="txtbottomstyle" Height="25px" Width="180px">
                    </asp:DropDownList>
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
