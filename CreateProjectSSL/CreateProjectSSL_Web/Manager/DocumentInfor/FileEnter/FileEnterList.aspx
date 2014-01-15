<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileEnterList.aspx.cs" Inherits="Manager_DocumentInfor_FileEnter_FileEnterList" %>

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
    <script type="text/javascript">
        function openNewDiv(div_id) {

            var newMask = document.createElement("div");
            newMask.id = "mask";
            newMask.style.position = "absolute";
            newMask.style.zIndex = "1";
            newMask.style.width = "100%";
            // document.body.scrollWidth +
            //newMask.style.height = document.body.scrollHeight + "px"; 
            newMask.style.height = "540px";
            newMask.style.top = "0px";
            newMask.style.left = "0px";
            newMask.style.background = "#000";
            newMask.style.filter = "alpha(opacity=40)";
            newMask.style.opacity = "0.40";
            document.body.appendChild(newMask);

            var newDiv = document.getElementById(div_id);
            newDiv.style.display = "block";
            newDiv.style.position = "absolute";
            newDiv.style.zIndex = "2";
            newDiv.style.width = "400px";
            newDiv.style.height = "120px";
            newDiv.style.top = "100px";
            newDiv.style.left = "400px"; // 屏幕居中   
            newDiv.style.background = "#EFEFEF";
            newDiv.style.border = "1px solid #000";
            newDiv.style.padding = "5px";
        }
        function colseNewDiv(div_id) {
            var newDiv = document.getElementById(div_id);
            newDiv.style.display = "none";
            document.body.removeChild(document.getElementById("mask"));
        }
    </script>
</head>
<body style="padding: 5px;">
    <form id="form1" runat="server">
    <div class="navigation">
        <%--<span class="add"><a href="FileEnterEdit.aspx">&nbsp;&nbsp;增加档案录入</a></span>--%><b>您当前的位置：首页
            &gt; 档案录入 &gt; 列表信息</b>
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
                        <asp:ListItem Value="2">移交时间</asp:ListItem>
                        <asp:ListItem Value="3">接收时间</asp:ListItem>
                    </asp:DropDownList>
                    ：
                    <asp:TextBox ID="fStarttime" runat="server" onclick="WdatePicker()" CssClass="txtbottomstyle"></asp:TextBox>
                    至
                    <asp:TextBox ID="fEndtime" runat="server" onclick="WdatePicker()" CssClass="txtbottomstyle"></asp:TextBox>
                </td>
                <td align="right">
                    <a title="新 增" href="FileEnterEdit.aspx" rel="right" class="button green"><span class="icon-botton">
                    </span>新 增</a> <a id="A5" title="删 除" onclick="return delChecked()" runat="server"
                        onserverclick="lbtnDel_Click" rel="right" class="button green"><span class="icon-botton">
                        </span>删 除</a><asp:LinkButton ID="lbDelALL" CommandName="Del" 
                        class="button green" runat="server" 
                        OnClientClick="return confirm( '确定要删除所有信息吗？ ')" onclick="lbDelALL_Click">一键清理</asp:LinkButton>
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
                        查 询</a> <a id="A1" title="归 档" onclick="openNewDiv('theDiv')" class="button green">归
                            档</a> <a id="A4" title="保 存" runat="server" onserverclick="btnCheckSave_Click" class="button green">
                                保 存</a>
                </td>
            </tr>
           
            <tr style="display: none;">
                <td align="left">
                    数据选择模板：
                    <asp:FileUpload ID="FileUpload1" runat="server" />&nbsp;
                    <asp:DropDownList ID="fileclassID" runat="server" CssClass="txtbottomstyle">
                        <asp:ListItem Selected="True" Value="11">建审科</asp:ListItem>
                        <asp:ListItem Value="12">验收科</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a id="A3" title="导 入"
                        runat="server" onserverclick="btn_Ok_Click" class="button green">导 入</a>
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
                <th width="220" align="center" class="style1">
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
                <th width="90" align="center" class="style1" style="display: none;">
                    录入人
                </th>
                <th width="120" align="center" class="style1">
                    录入时间
                </th>
                <th width="60" align="center" class="style1" style="display: none;">
                    档案状态
                </th>
                <th width="60" align="center" class="style1" style="display: none;">
                    是否归档
                </th>
                <th width="110" align="center" class="style1">
                    归档日期
                </th>
                <th width="110" align="center" class="style1">
                    移交时间
                </th>
                <th width="110" align="center" class="style1">
                    接收时间
                </th>
                <th width="80" align="center" class="style1">
                    所属区域
                </th>
                <th width="140" align="center" class="style1">
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
                        <td align="center">
                            <asp:TextBox ID="txtColumns" Width="40" Text='<%#Eval("Columns")%>' runat="server"></asp:TextBox>列
                            <asp:TextBox ID="txtCupboard" Width="35" Text='<%#Eval("Cupboard")%>' runat="server"></asp:TextBox>柜
                            <asp:TextBox ID="txtFrame" Width="35" Text='<%#Eval("Frame")%>' runat="server"></asp:TextBox>架
                            <%-- <%#Eval("Columns")%>列<%#Eval("Cupboard")%>柜<%#Eval("Frame")%>架--%>
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
                        <td align="center" style="display: none;">
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
                        <td align="center">
                            <%# Eval("FileLibraryData", "{0:yyyy-MM-dd}") == "1900-01-01" ? "" : Eval("FileLibraryData", "{0:yyyy-MM-dd}")%>
                        </td>
                        <td align="center">
                            <%# Eval("FileTransferDate", "{0:yyyy-MM-dd}") == "1900-01-01" ? "" : Eval("FileTransferDate", "{0:yyyy-MM-dd}")%>
                        </td>
                        <td align="center">
                            <%# Eval("ReceiptTime", "{0:yyyy-MM-dd}") == "1900-01-01" ? "" : Eval("ReceiptTime", "{0:yyyy-MM-dd}")%>
                        </td>
                        <td align="center">
                            <%# ssqy(Eval("EnteCountyId").ToString().Trim())%>
                        </td>
                        <td align="center">
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("EnteCountyId") %>' />
                            <span><a href="FileEnterEdit.aspx?flag=1&id=<%#Eval("ID")%>">查看</a></span>
                            <asp:LinkButton ID="lbedit" CommandName="edit" runat="server" OnClientClick="return confirm( '确定要编辑吗？ ')">|编辑</asp:LinkButton>
                            <asp:LinkButton ID="lbDel" CommandName="Del" runat="server" OnClientClick="return confirm( '确定要删除吗？ ')">|删除</asp:LinkButton></span>
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
    <asp:HiddenField ID="HiddenFieldda" runat="server" />
    <asp:HiddenField ID="HiddenFieldyj" runat="server" />
    <div id="theDiv" style="display: none;">
        <div style="text-align: right;">
            <img style="cursor: pointer;" alt="关闭" src="../../../Images/closeicon.gif" onclick="colseNewDiv('theDiv')" /></div>
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td align="right" style="width: 40%; height: 30px; line-height: 30px;">
                    选择档案库室：
                </td>
                <td align="left" style="width: 60%; height: 30px; line-height: 30px;" colspan="2">
                    <asp:DropDownList ID="drop_FileLibraryName" runat="server" CssClass="txtbottomstyle">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 10px; line-height: 10px;" colspan="3">
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 40%; height: 30px; line-height: 30px;">
                    <asp:Button ID="Button5" runat="server" Text="确定" class="button green" OnClick="btnSave_Click" />
                </td>
                <td align="left" style="width: 10%; height: 30px; line-height: 30px;">
                </td>
                <td align="left" style="width: 50%; height: 30px; line-height: 30px;">
                    <input id="button3" type="button" value="取消" class="button green" onclick="colseNewDiv('theDiv');" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
