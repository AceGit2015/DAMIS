﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileClassList.aspx.cs" Inherits="Manager_Sys_FileClass_FileClassList" %>

<%@ Register Src="~/ConfigCol/Manager.ascx" TagName="header" TagPrefix="headerControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>案卷类别</title>
    <headerControl:header ID="header" runat="server" />
</head>
<body style="padding: 5px;">
    <form id="form1" runat="server">
    <div class="navigation">
        <%--<span class="add"><a href="FileClassEdit.aspx">&nbsp;&nbsp;增加案卷类别</a></span>--%><b>您当前的位置：案卷类别
            &gt; 列表信息</b>
    </div>
    <%--实现查询条件筛选--%>
    <div style="margin-left: 10px; margin-top: 10px; margin-bottom: 10px;">
        <table cellpadding="0" cellspacing="0" border="0" width="98%">
            <tr>
                <td align="left">
                    <img src="../../../Images/search.jpg" width="16" height="16" border="0" align="middle" />
                    案卷类别代码 ：
                    <asp:TextBox ID="txtFileCode" CssClass="txtbottomstyle" runat="server">
                    </asp:TextBox>
                     &nbsp;&nbsp
                    案卷类别名称：
                    <asp:TextBox ID="txtFileName" CssClass="txtbottomstyle" runat="server">
                    </asp:TextBox>
                    &nbsp;&nbsp; <a id="btnQuery" title="查 询" runat="server" onserverclick="btnQuery_Click"
                        class="button green"></span>查 询</a>
                </td>
                <td align="right">
                    <a title="新 增" href="FileClassEdit.aspx" rel="right" class="button green"><span class="icon-botton">
                    </span>新 增</a> <a id="A5" title="删 除" onclick="return delChecked()" runat="server"
                        onserverclick="lbtnDel_Click" rel="right" class="button green"><span class="icon-botton">
                        </span>删 除</a>
                    <%--<a id="A1" title="导 出" runat="server" onserverclick="ToOrInExcel"
                            rel="right" class="button green"><span class="icon-botton"></span>导 出</a>--%>
                </td>
            </tr>
        </table>
    </div>
    <div style="margin-left: 10px;">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tb_data">
            <tr>
                <th width="50">
                    <input type="checkbox" id="CheckAllinfor" runat="server" style="cursor: pointer;" />选择
                </th>
                <th width="120" align="center">
                    序号
                </th>
                <th align="center">
                    案卷类别名称
                </th>
                <th width="180" align="center">
                    案卷类别代码
                </th>
                <th width="220" align="center">
                    案卷类别上级名称
                </th>
                <th width="120" align="center">
                    操作
                </th>
            </tr>
            <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand" OnPreRender="rptList_PreRender">
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" />
                            <asp:Label ID="lb_id" runat="server" Text='<%#Eval("ID")%>' Visible="False"></asp:Label>
                        </td>
                        <td align="center">
                            <%#Eval("RowNum")%>
                        </td>
                        <td align="center">
                            <%#Eval("FileName")%>
                        </td>
                        <td align="center">
                            <%#Eval("FileCode")%>
                        </td>
                        <td align="center">
                            <%#sjmc(Eval("parentFileID").ToString())%>
                        </td>
                        <td align="center">
                            <span><a href="FileClassEdit.aspx?flag=1&id=<%#Eval("ID") %>">查看</a></span>| <span><a
                                href="FileClassEdit.aspx?id=<%#Eval("ID") %>">编辑</a></span>| <span>
                                    <asp:LinkButton ID="lbDel" CommandName="Del" runat="server" OnClientClick="return confirm( '确定要删除吗？ ')">删除</asp:LinkButton></span>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
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
