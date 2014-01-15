<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DocumentList.aspx.cs" Inherits="Manager_Statistic_DocumentList" %>

<%@ Register Src="~/ConfigCol/header.ascx" TagName="header" TagPrefix="headerControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>执法档案-查询及统计</title>
    <headerControl:header ID="header" runat="server" />
    <script src="../../hightchart/highcharts.js" language="javascript" type="text/javascript"></script>
    <script src="../../hightchart/modules/exporting.js" language="javascript" type="text/javascript"></script>
    <script src="../../Js/FReport.js" language="javascript" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="navigation">
        <b>您当前的位置：首页 &gt; 查询及统计 &gt; 列表信息</b>
    </div>
    <div style="margin-left: 10px; margin-top: 10px; margin-bottom: 10px;">
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td align="left">
                    <img src="../../Images/search.jpg" width="16" height="16" border="0" align="middle" />
                    案卷类别：
                    <asp:DropDownList ID="fFileName" CssClass="txtbottomstyle" runat="server" AutoPostBack="True"
                        Width="180" OnSelectedIndexChanged="fFileName_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <table width="100%" border="1" cellspacing="1" id="tabs" cellpadding="1" class="tb_data"
        style="font-size: 12px;">
        <tr>
            <%=thTitle%>
        </tr>
        <tr>
            <%=thValue%>
        </tr>
    </table>
    <div style="height: 25px; line-height: 25px;">
    </div>
    <div id="container" style="min-width: 400px; width: 98%; height: 400px; margin: 0 auto">
    </div>
    </form>
</body>
</html>
