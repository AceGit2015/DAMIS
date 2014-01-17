<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileTransferyjzd.aspx.cs" Inherits="Manager_DocumentInfor_FileEnter_FileTransferyjzd" %>

<%@ Register Src="~/ConfigCol/Manager.ascx" TagName="header" TagPrefix="headerControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>执法档案-档案录入</title>
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
            &gt; 移交支队 &gt; 移交支队操作</b>
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
                    <asp:DropDownList ID="drop_time" runat="server" CssClass="txtbottomstyle"  Width="80">
                        <asp:ListItem Value="0">录入时间</asp:ListItem>
                        <asp:ListItem Value="1">归档时间</asp:ListItem>
                    </asp:DropDownList>
                    ：
                    <asp:TextBox ID="fStarttime" runat="server" onclick="WdatePicker()" CssClass="txtbottomstyle"></asp:TextBox>
                    至
                    <asp:TextBox ID="fEndtime" runat="server" onclick="WdatePicker()" CssClass="txtbottomstyle"></asp:TextBox>
                </td>
                <td align="right">
                    
                </td>
            </tr>
            <tr style="height: 10px;">
                <td>
                </td>
            </tr>
            <tr>
                <td align="left">
                    执法档案案卷号：
                    <asp:TextBox ID="txtFilesNum" CssClass="txtbottomstyle" runat="server">
                    </asp:TextBox>
                    录入人：
                    <asp:TextBox ID="txtEnterPeople" CssClass="txtbottomstyle" runat="server" Width="100">
                    </asp:TextBox>
                    档案状态：
                    <asp:DropDownList ID="txtDocStatus" runat="server" CssClass="txtbottomstyle" AutoPostBack="True"
                        OnSelectedIndexChanged="txtDocStatus_SelectedIndexChanged" Width="80">
                        <asp:ListItem Value="0">全部</asp:ListItem>
                        <asp:ListItem Value="1">已销毁</asp:ListItem>
                        <asp:ListItem Value="2">已借阅</asp:ListItem>
                        <asp:ListItem Value="3">已遗失</asp:ListItem>
                    </asp:DropDownList>
                    案卷类别：
                    <asp:DropDownList ID="fFileName" CssClass="txtbottomstyle" runat="server" Width="180">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <a id="btnQuery" title="查 询" runat="server" onserverclick="btnQuery_Click" class="button green">
                        查 询</a> <a id="A5" title="移 交" onclick="return tfChecked()" runat="server"
                        onserverclick="lbtnFileTransfer_Click" rel="right" class="button green"><span class="icon-botton">
                        </span>移 交</a>
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
                <th width="50">
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
                <th width="80" align="center" class="style1" >
                    档案状态
                </th>
                <th width="80" align="center" class="style1">
                    是否归档
                </th>
                <th width="110" align="center" class="style1">
                    归档日期
                </th>
                <th width="80" align="center" class="style1">
                    所属区域
                </th>
                <th width="60" align="center" class="style1">
                    操作
                </th>
            </tr>
            <asp:Repeater ID="rptyjzdList" runat="server" OnItemCommand="rptyjzdList_ItemCommand" OnPreRender="rptyjzdList_PreRender">
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
                        <td align="center">
                            <%# danganzt(Eval("FilesNum").ToString().Trim(), Eval("PicDocumentNo").ToString().Trim(), Eval("DocStatus").ToString().Trim())%>
                        </td>
                        <td align="center">
                            <asp:Label ID="lb_sfgd" runat="server" Text='<%# dasfgd(Eval("FileLibraryID").ToString().Trim())%>'></asp:Label>
                        </td>
                        <td align="center">
                            <%# Eval("FileLibraryData", "{0:yyyy-MM-dd}") == "1900-01-01" ? "" : Eval("FileLibraryData", "{0:yyyy-MM-dd}")%>
                        </td>
                        <td align="center">
                            <%# ssqy(Eval("EnteCountyId").ToString().Trim())%>
                        </td>
                        <td align="center">
                            <span><asp:LinkButton ID="transfer" CommandName="transfer" runat="server" OnClientClick="return confirm( '确定要移交吗？ ')">移交</asp:LinkButton></span>
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
