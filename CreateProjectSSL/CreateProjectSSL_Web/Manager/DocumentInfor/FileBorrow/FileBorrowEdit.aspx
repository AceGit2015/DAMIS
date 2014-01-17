<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileBorrowEdit.aspx.cs" Inherits="Manager_DocumentInfor_FileBorrow_FileBorrowEdit" %>

<%@ Register Src="~/ConfigCol/Manager.ascx" TagName="header" TagPrefix="headerControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>执法档案-档案借阅</title>
    <headerControl:header ID="header" runat="server" />
    <script language="javascript" type="text/javascript" src="../../../Js/DatePicker/WdatePicker.js"></script>
</head>
<body style="padding: 5px;">
    <form id="form1" runat="server">
    <div>
        <div class="navigation">
            <span class="back"><a href="FileBorrowList.aspx">返回列表</a></span><b>您当前的位置： 档案借阅 &gt;借阅操作</b>
        </div>
        <div style="padding-bottom: 10px;">
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
            <tr>
                <td width="120" align="right">
                    案卷类型：
                </td>
                <td>
                    <asp:DropDownList ID="txtFileClassID" runat="server" CssClass="txtbottomstyle" Height="24px">
                    </asp:DropDownList>
                </td>
                <td width="120" align="right">
                    案卷名称 ：
                </td>
                <td>
                    <asp:TextBox ID="txtFileEnterName" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="120" align="right">
                    借阅人：
                </td>
                <td>
                    <asp:TextBox ID="txtBorrowPeople" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                </td>
                <td width="120" align="right">
                    借阅人承办单位：
                </td>
                <td>
                    <asp:DropDownList ID="txtBorrowUnit" runat="server" CssClass="txtbottomstyle">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="120" align="right">
                    批准人：
                </td>
                <td>
                    <asp:TextBox ID="txtApproverPeople" CssClass="txtbottomstyle" runat="server"></asp:TextBox>
                </td>
                <td width="120" align="right">
                    批准人承办单位：
                </td>
                <td>
                    <asp:DropDownList ID="txtApproverUnit" runat="server" CssClass="txtbottomstyle">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="120" align="right">
                    经办人：
                </td>
                <td>
                    <asp:TextBox ID="txtHandlePeople" CssClass="txtbottomstyle" runat="server"></asp:TextBox>
                </td>
                <td width="120" align="right">
                    借出日期：
                </td>
                <td>
                    <asp:TextBox ID="txtBorrowDate" runat="server" CssClass="txtbottomstyle" onclick="WdatePicker();"
                        ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="120" align="right">
                    归还日期：
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtReturnDate" runat="server" CssClass="txtbottomstyle" onclick="WdatePicker();"
                        ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="120" align="right">
                    备注信息：
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtRemark" runat="server" CssClass="txtbottomstylemore" Height="60"
                        Width="560" TextMode="MultiLine"></asp:TextBox>
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
