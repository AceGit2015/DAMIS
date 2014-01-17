<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserListList.aspx.cs" Inherits="Manager_Sys_UserList_UserListList" %>

<%@ Register Src="~/ConfigCol/Manager.ascx" TagName="header" TagPrefix="headerControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>执法档案-用户管理</title>
    <headerControl:header ID="header" runat="server" />
</head>
<body style="padding: 5px;">
    <form id="form1" runat="server">
    <div class="navigation">
        <b>您当前的位置：系统设置 &gt; 用户列表</b>
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
                    &nbsp;&nbsp; 用户状态：
                    <asp:DropDownList ID="fuserState" runat="server" AutoPostBack="True" CssClass="txtbottomstyle"
                        Width="80">
                        <asp:ListItem Selected="True" Value="-1">所有</asp:ListItem>
                        <asp:ListItem Value="0">正常</asp:ListItem>
                        <asp:ListItem Value="1">禁用</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp; <a id="btnQuery" title="查 询" runat="server" onserverclick="btnQuery_Click"
                        class="button green"></span>查 询</a>
                </td>
                <td align="right">
                    <a title="新 增" href="UserListEdit.aspx" rel="right" class="button green"><span class="icon-botton">
                    </span>新 增</a> <a id="A5" title="删 除" onclick="return delChecked()" runat="server"
                        onserverclick="lbtnDel_Click" rel="right" class="button green"><span class="icon-botton">
                        </span>删 除</a>
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
                            <input type="checkbox" id="CheckAllinfor" runat="server" style="cursor: pointer;" />选择
                        </th>
                        <th width="120">
                            序号
                        </th>
                        <th width="120">
                            用户名
                        </th>
                        <th width="120">
                            电话
                        </th>
                        <th width="160">
                            邮件
                        </th>
                        <th width="160">
                            最后一次登录时间
                        </th>
                        <th width="80">
                            组织机构
                        </th>
                        <th width="80">
                            用户状态
                        </th>
                        <th width="120" align="center">
                            操作
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" />
                        <asp:Label ID="lb_id" runat="server" Text='<%#Eval("ID")%>' Visible="False"></asp:Label>
                    </td>
                    <td align="center">
                        <%#Eval("RowNum")%>
                    </td>
                    <td align="left">
                        <%#Eval("userName")%>
                    </td>
                    <td align="center">
                        <%#Eval("userTel")%>
                    </td>
                    <td align="center">
                        <%#Eval("userMail")%>
                    </td>
                    <td align="center">
                        <%#Eval("userLastLogin")%>
                    </td>
                    <td align="center">
                        <%#Eval("userPost")%>
                    </td>
                    <td align="center">
                        <%#Eval("userState").ToString() == "0" ? "<img title=\"正常\" width='14' height='13' src=\"../../../Images/correct.gif\" />" : "<img title=\"禁用\" width='14' height='13' src=\"../../../Images/disable.gif\" />"%>
                    </td>
                    <td align="center">
                        <span><a href="UserListEdit.aspx?flag=1&id=<%#Eval("ID") %>">查看</a>|</span> <span><a
                            href="UserListEdit.aspx?id=<%#Eval("ID") %>">编辑</a>|</span> <span>
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
