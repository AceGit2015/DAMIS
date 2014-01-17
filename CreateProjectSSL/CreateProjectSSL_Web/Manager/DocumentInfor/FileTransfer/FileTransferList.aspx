<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileTransferList.aspx.cs"
    Inherits="Manager_DocumentInfor_FileTransfer_FileTransferList" %>

<%@ Register Src="~/ConfigCol/Manager.ascx" TagName="header" TagPrefix="headerControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>执法档案-档案移交</title>
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
        <b>您当前的位置：档案操作 > 档案移交 &gt; 列表信息</b>
    </div>
    <%--实现查询条件筛选--%>
    <div style="margin-left: 10px; margin-top: 10px; margin-bottom: 10px;">
        <table cellpadding="0" cellspacing="0" border="0" width="98%">
            <tr>
                <td align="left">
                    <img src="../../../Images/search.jpg" width="16" height="16" border="0" align="middle" />
                    <%--案卷类型 ：
                    <asp:TextBox ID="fFileClassID" CssClass="txtbottomstyle" runat="server">
                    </asp:TextBox>
                    &nbsp;&nbsp; 案卷名称 ：
                    <asp:TextBox ID="fFileClassName" CssClass="txtbottomstyle" runat="server">
                    </asp:TextBox>
                    &nbsp;&nbsp; 接收状态 ：
                    <asp:DropDownList ID="txtDocStatus" runat="server" CssClass="txtbottomstyle" AutoPostBack="True"
                        OnSelectedIndexChanged="txtDocStatus_SelectedIndexChanged">
                        <asp:ListItem Value="0">全部</asp:ListItem>
                        <asp:ListItem Value="1">未接收</asp:ListItem>
                        <asp:ListItem Value="2">拒收</asp:ListItem>
                        <asp:ListItem Value="3">已接收</asp:ListItem>
                    </asp:DropDownList>--%>
                    移交时间：
                    <asp:TextBox ID="fStarttime" runat="server" onclick="WdatePicker()" CssClass="txtbottomstyle"></asp:TextBox>
                    至
                    <asp:TextBox ID="fEndtime" runat="server" onclick="WdatePicker()" CssClass="txtbottomstyle"></asp:TextBox>
                    <a id="btnQuery" title="查 询" runat="server" onserverclick="btnQuery_Click" class="button green">
                        查 询</a>
                </td>
                <td align="right">
                    <a title="新 增" href="FileTransferEdit.aspx" rel="right" class="button green"><span
                        class="icon-botton"></span>新 增</a>
                    <%--<a id="A5" title="删 除" onclick="return delChecked()"
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
                <%--<th width="160" align="center">
                    案卷类型
                </th>
                <th width="160" align="center">
                    案卷名称
                </th>--%>
                <th width="120" align="center">
                    移交人
                </th>
                <th width="120" align="center">
                    接收人
                </th>
                <%--<th width="120" align="center">
                    接收人单位
                </th>--%>
                <th width="120" align="center">
                    批准人
                </th>
                <th width="200">
                    单位
                </th>
                <th width="120" align="center">
                    移交日期
                </th>
                <th>
                   备注
                </th>
                <th width="60">
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
                        <%--<td align="center">
                            <%#Eval("FileClassName")%>
                        </td>
                        <td align="center">
                            <%#Eval("FileEnterName")%>
                        </td>--%>
                        <td align="center">
                            <%#Eval("TransferPeople")%>
                        </td>
                        <td align="center">
                            <%#Eval("AcceptPeople")%>
                        </td>
                        <%--<td align="center">
                            <%#Eval("AcceptUnit")%>
                        </td>--%>
                        <td align="center">
                            <%#Eval("ApproverPeople")%>
                        </td>
                        <td align="center">
                            <%#Eval("ApproverUnit")%>
                        </td>
                        <td align="center">
                             <%# Eval("TransferDate", "{0:yyyy-MM-dd}") == "1900-01-01" ? "" : Eval("TransferDate", "{0:yyyy-MM-dd}")%>
                        </td>
                        <td>
                            <%#Eval("Remark")%>
                        </td>
                        <td align="center">
                            <span><a href="FileTransferEdit.aspx?flag=1&id=<%#Eval("ID") %>">查看</a></span><%--| <span>
                                <a href="FileBorrowEdit.aspx?id=<%#Eval("ID") %>">编辑</a></span>| <span>--%>
                            <asp:LinkButton ID="lbDel" CommandName="Del" runat="server" OnClientClick="return confirm( '确定要删除吗？ ')"
                                Visible="false">删除</asp:LinkButton></span>
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
