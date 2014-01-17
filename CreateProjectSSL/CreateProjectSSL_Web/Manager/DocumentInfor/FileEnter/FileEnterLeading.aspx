<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileEnterLeading.aspx.cs"
    Inherits="Manager_DocumentInfor_FileEnter_FileEnterLeading" %>

<%@ Register Src="~/ConfigCol/Manager.ascx" TagName="header" TagPrefix="headerControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>执法档案-档案录入</title>
    <headerControl:header ID="header" runat="server" />
    <script language="javascript" type="text/javascript" src="../../../Js/DatePicker/WdatePicker.js"></script>
</head>
<body style="padding: 5px;">
    <form id="form1" runat="server">
    <div class="navigation">
        <b>您当前的位置：首页 &gt; 档案导入 &gt; 列表信息</b>
    </div>
    <div style="margin-left: 10px; margin-top: 10px;">
        <table cellpadding="0" cellspacing="0" border="0" width="98%">
            <tr>
                <td align="left">
                    数据模板选择：
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="300px" />&nbsp;
                    <asp:DropDownList ID="fileclassID" runat="server" CssClass="txtbottomstyle">
                        <asp:ListItem Selected="True" Value="11">建审</asp:ListItem>
                        <asp:ListItem Value="12">验收</asp:ListItem>
                        <asp:ListItem Value="13">开业</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a id="A3" title="导 入"
                        runat="server" onserverclick="btn_Ok_Click" class="button green">导 入</a>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div style="font-size:14px;">
         &nbsp;&nbsp;&nbsp;&nbsp;注：Excel文件的sheet名需与以上选择项名称一致！
    </div>
    </form>
</body>
</html>
