<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileTransferEdit.aspx.cs"
    Inherits="Manager_DocumentInfor_FileTransfer_FileTransferEdit" %>

<%@ Register Src="~/ConfigCol/Manager.ascx" TagName="header" TagPrefix="headerControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>执法档案-档案移交</title>
    <headerControl:header ID="header" runat="server" />
    <script language="javascript" type="text/javascript" src="../../../Js/DatePicker/WdatePicker.js"></script>
</head>
<body style="padding: 5px;">
    <form id="form1" runat="server">
    <div>
        <div class="navigation">
            <span class="back"><a href="FileTransferList.aspx">返回列表</a></span><b>您当前的位置： 档案操作 > 档案移交 &gt;档案移交操作</b>
        </div>
        <div style="padding-bottom: 10px;">
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
            <tr>
                <td width="140" align="right">
                    消防行政许可档案：
                </td>
                <td>
                    <asp:Label ID="Xfxzxkda" runat="server" Text="10"></asp:Label>
                </td>
                <td width="120" align="right">
                    消防监督检查档案：
                </td>
                <td>
                    <asp:Label ID="Xfjdjcda" runat="server" Text="10"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="120" align="right">
                    消防安全重点单位档案：
                </td>
                <td>
                    <asp:Label ID="Xfaqzddwda" runat="server" Text="10"></asp:Label>
                </td>
                <td width="120" align="right">
                    重大火灾隐患档案：
                </td>
                <td>
                    <asp:Label ID="Zdhzyhda" runat="server" Text="10"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="120" align="right">
                    火灾事故调查档案：
                </td>
                <td>
                    <asp:Label ID="Hzsgdcda" runat="server" Text="10"></asp:Label>
                </td>
                <td width="120" align="right">
                    消防行政处罚档案：
                </td>
                <td>
                    <asp:Label ID="Xfxzcfda" runat="server" Text="10"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="120" align="right">
                    消防行政强制档案：
                </td>
                <td>
                    <asp:Label ID="Xfxzqzda" runat="server" Text="10"></asp:Label>
                </td>
                <td width="120" align="right">
                    消防执法救济档案：
                </td>
                <td>
                    <asp:Label ID="Xfzfjjda" runat="server" Text="10"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="120" align="right">
                    消防刑事档案：
                </td>
                <td>
                    <asp:Label ID="Xfxsda" runat="server" Text="10"></asp:Label>
                </td>
                <td width="120" align="right">
                    
                </td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td style="height:10px;">
                
                </td>
            </tr>
            <tr>
                <td width="120" align="right">
                    移交人：
                </td>
               <td width="200" align="left">
                    <asp:TextBox ID="txtTransferPeople" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                </td>
                <td width="120" align="right">
                    接收人：
                </td>
                <td>
                    <asp:TextBox ID="txtAcceptPeople" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="120" align="right">
                    批准人：
                </td>
                <td>
                    <asp:TextBox ID="txtApproverPeople" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                </td>
                <td width="120" align="right">
                    单位：
                </td>
                <td>
                    <asp:DropDownList ID="txtApproverUnit" runat="server" CssClass="txtbottomstyle">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="120" align="right">
                    移交日期：
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtTransferDate" runat="server" CssClass="txtbottomstyle" onclick="WdatePicker();"
                        ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="120" align="right">
                    备注信息：
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtRemark" runat="server" CssClass="txtbottomstylemore" Height="100"
                        Width="500" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div style="margin-top: 10px; text-align: center; width:60%" >
            <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="submit" OnClick="btnSave_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="Reset" runat="server" Text="重置" CssClass="submit" OnClick="Reset_Click" />
        </div>
    </div>
    </form>
</body>
</html>
