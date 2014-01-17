<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogListList.aspx.cs" Inherits="Manager_Sys_LogList_LogListList" %>

<%@ Register Src="~/ConfigCol/Manager.ascx" TagName="header" TagPrefix="headerControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>执法档案-用户管理</title>
    <headerControl:header ID="header" runat="server" />
    <script language="javascript" type="text/javascript" src="../../../Js/DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript">
        //验证开始日期和结束日期 2013-11-20
        $(function () {
            $("#btnQuery").click(function () {
                //判断开始时间和结束时间
                var strStartTime = $("#fStarttime").val();
                var endTime = $("#fEndtime").val();
                var startNum = parseInt(strStartTime.replace(/-/g, ''), 10);
                var endNum = parseInt(endTime.replace(/-/g, ''), 10);
                if (startNum > endNum) {
                    alert("结束时间不能在开始时间之前！");
                    $("#fEndtime").focus();
                    return false;
                }
            });
        });
    </script>
</head>
<body style="padding: 5px;">
    <form id="form1" runat="server">
    <div class="navigation">
        <b>您当前的位置：基本信息 &gt; 列表信息</b>
    </div>
    <%--实现查询条件筛选--%>
    <div style="margin-left: 10px; margin-top: 10px; margin-bottom: 10px;">
        <table cellpadding="0" cellspacing="0" border="0" width="98%">
            <tr>
                <td align="left">
                    <img src="../../../Images/search.jpg" width="16" height="16" border="0" align="absmiddle" />
                    用户名称：
                    <asp:TextBox ID="fuserName" CssClass="txtbottomstyle" runat="server">
                    </asp:TextBox>
                    开始日期：
                    <asp:TextBox ID="fStarttime" runat="server" onclick="WdatePicker()" CssClass="txtbottomstyle"></asp:TextBox>
                    至
                    <asp:TextBox ID="fEndtime" runat="server" onclick="WdatePicker()" CssClass="txtbottomstyle"></asp:TextBox>
                    &nbsp;&nbsp; &nbsp;&nbsp;<a id="btnQuery" title="查 询" runat="server" onserverclick="btnQuery_Click"
                        class="button green">查 询</a>
                </td>
                <td align="right">
                    <a id="A5" title="删 除" onclick="return delChecked()" runat="server" onserverclick="lbtnDel_Click"
                        rel="right" class="button green"><span class="icon-botton"></span>删 除</a>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand" OnPreRender="rptList_PreRender">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tb_data">
                    <tr>
                        <th width="50">
                            <input type="checkbox" id="CheckAllinfor" style="cursor: pointer;" />选择
                        </th>
                        <th width="120">
                            序号
                        </th>
                        <th width="160">
                            发生时间
                        </th>
                        <th width="240">
                            发生详情
                        </th>
                        <th width="140">
                            IP
                        </th>
                        <th width="100">
                            用户名称
                        </th>
                        <th width="40" style="display: none;">
                            操作
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" />
                        <asp:Label ID="lb_id" runat="server" Text='<%#Eval("id")%>' Visible="False"></asp:Label>
                    </td>
                    <td align="center">
                        <%#Eval("RowNum")%>
                    </td>
                    <td align="center">
                        <%#Eval("LogTime")%>
                    </td>
                    <td align="center">
                        <%#Eval("LogDetail")%>
                    </td>
                    <td align="center">
                        <%#Eval("LogIP")%>
                    </td>
                    <td align="center">
                        <%#Eval("username")%>
                    </td>
                    <td align="center" style="display: none;">
                        <asp:LinkButton ID="lbDel" CommandName="Del" runat="server" OnClientClick="return confirm( '确定要删除吗？ ')">删除</asp:LinkButton></span>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:HiddenField ID="hidInfo" runat="server" />
        <div style="line-height: 30px; height: 30px;">
            <%--实现分页技术--%>
            <div class="right">
                <Peter:Pager ID="Pager1" runat="server" OnPageIndexChanging="Pager1_PageIndexChanging" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
