<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileBorrowList.aspx.cs" Inherits="Manager_DocumentInfor_FileBorrow_FileBorrowList" %>

<%@ Register Src="~/ConfigCol/Manager.ascx" TagName="header" TagPrefix="headerControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>执法档案-档案借阅</title>
    <headerControl:header ID="header" runat="server" />
</head>
<body style="padding: 5px;">
    <form id="form1" runat="server">
    <div class="navigation">
        <b>您当前的位置：档案借阅 &gt; 列表信息</b>
    </div>
    <%--实现查询条件筛选--%>
    <div style="margin-left: 10px; margin-top: 10px; margin-bottom: 10px;">
        <table cellpadding="0" cellspacing="0" border="0" width="98%">
            <tr>
                <td align="left">
                    <img src="../../../Images/search.jpg" width="16" height="16" border="0" align="middle" />
                    案卷类型：
                    <asp:TextBox ID="fFileClassID" CssClass="txtbottomstyle" runat="server">
                    </asp:TextBox>
                    &nbsp;&nbsp; 案卷名称 ：
                    <asp:TextBox ID="fFileEnterName" CssClass="txtbottomstyle" runat="server">
                    </asp:TextBox>
                    &nbsp;&nbsp; 借阅状态 ：
                    <asp:DropDownList ID="txtDocStatus" runat="server" CssClass="txtbottomstyle" AutoPostBack="True"
                        OnSelectedIndexChanged="txtDocStatus_SelectedIndexChanged">
                        <asp:ListItem Value="0">全部</asp:ListItem>
                        <asp:ListItem Value="1">为归还</asp:ListItem>
                        <asp:ListItem Value="2">已归还</asp:ListItem>
                    </asp:DropDownList>
                    <a id="btnQuery" title="查 询" runat="server" onserverclick="btnQuery_Click" class="button green">
                        查 询</a>
                </td>
                <td align="right">
                    <a title="新 增" href="FileBorrowEdit.aspx" rel="right" class="button green"><span
                        class="icon-botton"></span>新 增</a> <%--<a id="A5" title="删 除" onclick="return delChecked()"
                            runat="server" onserverclick="lbtnDel_Click" rel="right" class="button green"><span
                                class="icon-botton"></span>删 除</a>--%>
                </td>
            </tr>
        </table>
    </div>
    <div style="margin-left: 10px;">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tb_data">
            <tr>
                <%--<th width="60">
                    <input type="checkbox" id="CheckAllinfor" style="cursor: pointer;" />选择
                </th>--%>
                <th width="60" align="center">
                    序号
                </th>
                <th width="160" align="center">
                    案卷类型
                </th>
                <th width="160" align="center">
                    案卷名称
                </th>
                <th width="120" align="center">
                    借阅人
                </th>
                <th width="160" align="center">
                    借阅人单位
                </th>
                <th width="120" align="center">
                    批准人
                </th>
                <th width="120" align="center">
                    经办人
                </th>
                <th width="120" align="center">
                    借出日期
                </th>
                <th width="120" align="center">
                    归还日期
                </th>
                <th width="80">
                   借阅状态
                </th>
                <th width="100">
                    操作
                </th>
            </tr>
            <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand" OnPreRender="rptList_PreRender">
                <ItemTemplate>
                    <tr>
                        <td align="center" style="display:none;">
                            <asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" />
                            <asp:Label ID="lb_id" runat="server" Text='<%#Eval("ID")%>' Visible="False"></asp:Label>
                        </td>
                        <td align="center">
                            <%#Eval("RowNum")%>
                        </td>
                        <td align="center">
                            <%#Eval("FileClassName")%>
                        </td>
                        <td align="center">
                            <%#Eval("FileEnterName")%>
                        </td>
                        <td align="center">
                            <%#Eval("BorrowPeople")%>
                        </td>
                        <td align="center">
                            <%#Eval("BorrowUnit")%>
                        </td>
                        <td align="center">
                            <%#Eval("ApproverPeople")%>
                        </td>
                        <td align="center">
                            <%#Eval("HandlePeople")%>
                        </td>
                        <td align="center">
                            <%#Eval("BorrowDate")%>
                        </td>
                        <td align="center">
                            <%#Eval("ReturnDate")%>
                        </td>
                        <td>
                           <%# Eval("ReturnDate").ToString() == "" ? "未归还" : "已归还"%>
                        </td>
                        <td align="center">
                            <span><a href="FileBorrowEdit.aspx?flag=1&id=<%#Eval("ID") %>">查看</a></span>
                                 <%#Eval("ReturnDate").ToString() == "" ? "<span><a href='FileBorrowEdit.aspx?id=" + Eval("ID") + "'> | 编辑</a></span>" : ""%>&nbsp;
                                    <asp:LinkButton ID="lbDel" CommandName="Del" runat="server" OnClientClick="return confirm( '确定要删除吗？ ')" Visible="false">删除</asp:LinkButton></span>
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
