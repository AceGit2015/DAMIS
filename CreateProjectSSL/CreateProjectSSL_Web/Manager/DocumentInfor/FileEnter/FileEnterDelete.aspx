<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileEnterDelete.aspx.cs" Inherits="Manager_DocumentInfor_FileEnter_FileEnterDelete" %>

<%@ Register Src="~/ConfigCol/Manager.ascx" TagName="header" TagPrefix="headerControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>执法档案-档案删除</title>
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
        <%--<span class="add"><a href="FileEnterEdit.aspx">&nbsp;&nbsp;增加档案录入</a></span>--%><b>您当前的位置：档案管理
            &gt; 档案信息 &gt; 档案删除</b>
    </div>
    <%--实现查询条件筛选--%>
    <div style="margin-left: 10px; margin-top: 10px;">
        <table cellpadding="0" cellspacing="0" border="0" width="98%">
            <tr>
                <td align="left">
                    <img src="../../../Images/search.jpg" width="16" height="16" border="0" align="middle" />
                    档案名称：
                    <asp:TextBox ID="ftxtFilesName" CssClass="txtbottomstyle" runat="server">
                    </asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    录入时间
                    ：
                    <asp:TextBox ID="fStarttime" runat="server" onclick="WdatePicker()" CssClass="txtbottomstyle"></asp:TextBox>
                    至
                    <asp:TextBox ID="fEndtime" runat="server" onclick="WdatePicker()" CssClass="txtbottomstyle"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;录入人：
                    <asp:TextBox ID="txtEnterPeople" CssClass="txtbottomstyle" runat="server" Width="100">
                    </asp:TextBox>
                </td>
                <td align="right">
                    <a id="A5" title="删 除" onclick="return delChecked()" runat="server"
                        onserverclick="lbtnDel_Click" rel="right" class="button green"><span class="icon-botton">
                        </span>删 除</a>
                </td>
            </tr>
        </table>
    </div>
    <div style="height: 20px;">
    </div>
    <div style="margin-left: 0px;">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tb_data">
            <tr>
                <th width="60" class="style1">
                    <input type="checkbox" id="CheckAllinfor" style="cursor: pointer;" />选择
                </th>
                <th width="40">
                    序号
                </th>
                <th width="180" align="center" class="style1">
                    排架号
                </th>
                <th width="150" align="center" class="style1">
                    执法档案名称
                </th>
                <th width="130" align="center" class="style1">
                    案卷类别名称
                </th>
                <th width="120" align="center" class="style1">
                    执法案卷号
                </th>
                <th width="90" align="center" class="style1">
                    录入人
                </th>
                <th width="120" align="center" class="style1">
                    录入时间
                </th>
                <th width="110" align="center" class="style1" style="display: none;">
                    归档日期
                </th>
                <th width="80" align="center" class="style1">
                    所属区域
                </th>
                <th width="50" align="center" class="style1">
                    操作
                </th>
            </tr>
            <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand" OnPreRender="rptList_PreRender"
                OnItemDataBound="rptList_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" />
                            <asp:Label ID="lb_id" runat="server" Text='<%#Eval("ID")%>' Visible="False"></asp:Label>
                        </td>
                        <td align="center">
                            <%#Eval("RowNum")%>
                        </td>
                        <td align="right">
                             <%#Eval("Columns")%>&nbsp;列&nbsp;&nbsp;<%#Eval("Cupboard")%>&nbsp;柜&nbsp;&nbsp;<%#Eval("Frame")%>架
                        </td>
                        <td align="center">
                            <%#Eval("FilesName")%>
                        </td>
                        <td align="center">
                            <%#Eval("FName")%>
                        </td>
                        <td align="center">
                            <%#Eval("FilesNum")%>
                        </td>
                        <td align="center">
                            <%#Eval("EnterPeople")%>
                        </td>
                        <td align="center">
                            <%# Eval("EnterDate", "{0:yyyy-MM-dd}")%>
                        </td>
                        <td align="center" style="display: none;">
                            <%# danganzt(Eval("FilesNum").ToString().Trim(), Eval("PicDocumentNo").ToString().Trim(), Eval("DocStatus").ToString().Trim())%>
                        </td>
                        <td style="display: none;">
                            <asp:Label ID="lb_sfgd" runat="server" Text='<%# dasfgd(Eval("FileLibraryID").ToString().Trim())%>'></asp:Label>
                        </td>
                        <td align="center"  style="display: none;">
                            <%# Eval("FileLibraryData", "{0:yyyy-MM-dd}") == "1900-01-01" ? "" : Eval("FileLibraryData", "{0:yyyy-MM-dd}")%>
                        </td>
                        <td align="center">
                            <%# ssqy(Eval("EnteCountyId").ToString().Trim())%>
                        </td>
                        <td align="center">
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
