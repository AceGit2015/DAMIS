<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage_Left.aspx.cs" Inherits="Manager_Manage_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>执法档案-数据列表</title>
    <link href="../Css/MainStyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function confirm2() {
            if (confirm("确认退出系统吗？")) {
                document.getElementById('<%=LinkButton1.ClientID%>').click();
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" valign="top">
                <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr style="height: 100%;">
                        <td width="147" align="left" valign="top" class="rightborder">
                            <%=StrMeun %>
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
