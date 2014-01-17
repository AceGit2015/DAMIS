<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileEnterEdit.aspx.cs" Inherits="Manager_DocumentInfor_FileEnter_FileEnterEdit" %>

<%@ Register Src="~/ConfigCol/Manager.ascx" TagName="header" TagPrefix="headerControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>执法档案-档案录入</title>
    <headerControl:header ID="header" runat="server" />
    <script language="javascript" src="../../../Js/FileEnterEdit.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../Js/DatePicker/WdatePicker.js"></script>
</head>
<body style="padding: 5px;">
    <form id="form1" runat="server">
    <div>
        <div class="navigation">
            <span class="back"><a href="FileEnterList.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 档案录入
                &gt;档案操作</b>
        </div>
        <div style="padding-bottom: 10px;">
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
            <tr>
                <td width="140" align="right">
                    排架号：
                </td>
                <td colspan="6">
                    <asp:TextBox ID="Columns" runat="server" CssClass="txtbottomstyle" Width="80px"></asp:TextBox>列&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="Cupboard" runat="server" CssClass="txtbottomstyle" Width="80px"></asp:TextBox>柜&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="Frame" runat="server" CssClass="txtbottomstyle" Width="80px"></asp:TextBox>架&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td width="140" align="right">
                    执法档案全宗号：
                </td>
                <td>
                    <asp:TextBox ID="FileFondsNo" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                </td>
                <td width="140" align="right">
                    执法档案案卷号：
                </td>
                <td colspan="4">
                    <asp:TextBox ID="FilesNum" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="160" align="right">
                    执法档案目录号：
                </td>
                <td>
                    <asp:DropDownList ID="FileDirectoryID" runat="server" CssClass="txtbottomstyle">
                    </asp:DropDownList>
                </td>
                <td width="160" align="right">
                    执法档案保管期限：
                </td>
                <td>
                    <asp:DropDownList ID="SaveDeadlineID" runat="server" CssClass="txtbottomstyle">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="140" align="right">
                    执法案卷类别名称：
                </td>
                <td colspan="6">
                    <div style="width: 98%; height: 240px; overflow: auto; border: solid 1px #808080;">
                        <table>
                            <asp:Repeater ID="rptList" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%#ToolsCommon.Utility.GetStr(Eval("lv").ToString())%>
                                            <asp:CheckBox ID="cl1_000" runat="server" CssClass="cl0" onclick='check(this,"cl0",-1,0)'
                                                mtype='<%#Eval("Intype")%>' mid='<%#Eval("ID")%>' />
                                            <%#Eval("FileName")%>
                                            <asp:Label ID="FileClassID" runat="server" Text='<%#Eval("ID")%>' Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td width="140" align="right">
                    执法档案名称：
                    <br />
                    <br />
                    (案卷标题)：
                </td>
                <td colspan="6">
                    <div style="width: 98%; height: 140px; overflow: auto; border: solid 1px #808080;">
                        <%--  1.--%>
                        <table class="cx1" style="display: none;">
                            <tr>
                                <td>
                                    建设单位名称：
                                    <asp:TextBox ID="BuildUnitName" runat="server" CssClass="txtbottomstyle" Width="500px"></asp:TextBox>
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    项目名称：
                                    <asp:TextBox ID="BuildItemName" runat="server" CssClass="txtbottomstyle" Width="300px"></asp:TextBox>
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                        <%--2.--%>
                        <table class="cx2" style="display: none;">
                            <tr>
                                <td>
                                    检查单位（场所）名称：
                                    <asp:TextBox ID="CheckUnitName" runat="server" CssClass="txtbottomstyle" Width="500px"></asp:TextBox>
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                        <%-- 3.--%>
                        <table class="cx3" style="display: none;">
                            <tr>
                                <td>
                                    举报人：
                                    <asp:TextBox ID="ComplainPeople" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    被举报人：
                                    <asp:TextBox ID="ComplainNPeople" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    举报的行为：
                                    <asp:TextBox ID="CompainN" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <%--  4.--%>
                        <table class="cx4" style="display: none;">
                            <tr>
                                <td>
                                    举办人：
                                    <asp:TextBox ID="MassSportsPeople" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    活动名称：
                                    <asp:TextBox ID="MassSportName" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <%-- 5.--%>
                        <table class="cx5" style="display: none;">
                            <tr>
                                <td>
                                    火灾地址：
                                    <asp:TextBox ID="FireAds" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    单位名称：
                                    <asp:TextBox ID="FireUnitName" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    发生日期：
                                    <asp:TextBox ID="FireDateTime" runat="server" onclick="WdatePicker();" ReadOnly="true"
                                        CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    火灾性质：
                                    <asp:RadioButtonList ID="FireN" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                                        Width="360px" RepeatColumns="4">
                                        <asp:ListItem Selected="True" Value="0">一般火灾</asp:ListItem>
                                        <asp:ListItem Value="1">较大火灾</asp:ListItem>
                                        <asp:ListItem Value="3">重大火灾</asp:ListItem>
                                        <asp:ListItem Value="4">特别重大火灾</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                        <%--  6.--%>
                        <table class="cx6" style="display: none;">
                            <tr>
                                <td>
                                    违法主体：
                                    <asp:TextBox ID="PunishMain" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td style="display:none;">
                                    处罚案由 ：
                                </td>
                                <td colspan="4" style="width: 400px;display:none;">
                                    <div style="width: 120%; height: 120px; overflow: auto; border: solid 1px #808080;">
                                        <table style="width: 98%">
                                            <asp:Repeater ID="rxwhy" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <%--<input type="checkbox" onclick='check(this,"cc1","<%#Eval("FileClassID")%>")' class="cl4" /><%#Eval("PunishTypeName")%>--%>
                                                            <asp:CheckBox ID="ckb6" runat="server" CssClass="c14" onclick='check(this,"cc1",2,1)' />
                                                            <%#Eval("PunishTypeName")%>
                                                            <asp:Label ID="PunishWhy" runat="server" Text='<%#Eval("ID")%>' Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <%-- 7.--%>
                        <table class="cx7" style="display: none;">
                            <tr>
                                <td>
                                    查封单位名称：
                                    <asp:TextBox ID="TempUintName" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    行为：
                                    <asp:TextBox ID="TempN" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    定性：
                                    <asp:TextBox ID="TempDX" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <%-- 8.--%>
                        <table class="cx8" style="display: none;">
                            <tr>
                                <td>
                                    执法单位名称：
                                    <asp:TextBox ID="ForceUnitName" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    行为：
                                    <asp:TextBox ID="ForceN" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <%-- 9.--%>
                        <table class="cx9" style="display: none;">
                            <tr>
                                <td>
                                    申请主体：
                                    <asp:TextBox ID="ApplyMain" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    不服内容：
                                    <asp:TextBox ID="ApplyNContent" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <%--  10--%>
                        <table class="cx10" style="display: none;">
                            <tr>
                                <td>
                                    国家申请主体：
                                    <asp:TextBox ID="CountryMain" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <%-- 11.--%>
                        <table class="cx11" style="display: none;">
                            <tr>
                                <td>
                                    嫌疑人姓名：
                                    <asp:TextBox ID="PenalName" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    罪名：
                                    <asp:RadioButtonList ID="PenalZN" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                                        Width="200px" RepeatColumns="3">
                                        <asp:ListItem Selected="True" Value="0">失火罪</asp:ListItem>
                                        <asp:ListItem Value="1">火灾责任事故罪</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td width="140" align="right">
                    录入的其他要素：
                </td>
                <td colspan="5">
                    <div style="width: 98%; height: 130px; overflow: auto; border: solid 1px #808080;">
                        <%--1.--%>
                        <table class="cx1" style="display: none;">
                            <tr>
                                <td>
                                    建设工程单位：
                                    <asp:TextBox ID="YesUnit" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    建设工程地址：
                                    <asp:DropDownList ID="BuildAdsArea" runat="server" CssClass="txtbottomstyle" Width="150px">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="BuildAds" runat="server" CssClass="txtbottomstyle" Width="200px"></asp:TextBox>
                                </td>
                                <td>
                                    总面积：
                                    <asp:TextBox ID="BuildArea" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    建筑高度：
                                    <asp:TextBox ID="buildingHeight" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    工程类型[审核]：
                                    <asp:TextBox ID="BuildCheckT" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    工程类型[备案]：
                                    <asp:TextBox ID="BuildFilingT" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="cx12">
                                <td>
                                    图纸档号：
                                    <asp:TextBox ID="PicDocumentNo1" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    案卷入盒信息：
                                    <asp:TextBox ID="PicDicL1" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    图纸盒数：
                                    <asp:TextBox ID="EngDroping1" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    行政许可结果：
                                    <asp:RadioButtonList ID="BuildALicense" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="150px" RepeatColumns="3">
                                        <asp:ListItem Selected="True" Value="0">许可</asp:ListItem>
                                        <asp:ListItem Value="1">不许可</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    工程名称：
                                    <asp:TextBox ID="CheckItemName" runat="server" CssClass="txtbottomstyle" Width="180"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <%--2.--%>
                        <table class="cx2" style="display: none;">
                            <tr>
                                <td>
                                    检查性质：
                                    <asp:TextBox ID="CheckNature" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                    <asp:CheckBox ID="CheckNaturefc" runat="server" Text="复查" />
                                </td>
                                <td>
                                    检查结果：
                                    <asp:RadioButtonList ID="CheckResult" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="200px" RepeatColumns="3">
                                        <asp:ListItem Selected="True" Value="0">合格</asp:ListItem>
                                        <asp:ListItem Value="1">不合格</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    检查地址：
                                    <asp:DropDownList ID="CheckAdsArea" runat="server" CssClass="txtbottomstyle" Width="150px">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="CheckAds" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="cx12">
                                <td>
                                    图纸档号：
                                    <asp:TextBox ID="PicDocumentNo2" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    案卷入盒信息：
                                    <asp:TextBox ID="PicDicL2" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    图纸盒数：
                                    <asp:TextBox ID="EngDroping2" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <%-- 3.--%>
                        <table class="cx3" style="display: none;">
                            <tr>
                                <td>
                                    建设工程地址：
                                    <asp:DropDownList ID="ComplainAdsArea" runat="server" CssClass="txtbottomstyle" Width="150px">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="ComplainAds" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    检查结果：
                                    <asp:RadioButtonList ID="ComplainResult" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="200px" RepeatColumns="3">
                                        <asp:ListItem Selected="True" Value="0">属实</asp:ListItem>
                                        <asp:ListItem Value="1">不属实</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                        <%--  4.--%>
                        <table class="cx4" style="display: none;">
                            <tr>
                                <td>
                                    活动举办地址：
                                    <asp:DropDownList ID="MassSportsAdsArea" runat="server" CssClass="txtbottomstyle"
                                        Width="150px">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="MassSportsAds" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    检查情况：
                                    <asp:RadioButtonList ID="MassSportsResult" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="200px" RepeatColumns="3">
                                        <asp:ListItem Selected="True" Value="0">合格</asp:ListItem>
                                        <asp:ListItem Value="1">不合格</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                        <%-- 5.--%>
                        <table class="cx5" style="display: none;">
                            <tr>
                                <td>
                                    火灾燃烧物质：
                                    <asp:TextBox ID="FireNature" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    火灾过火面积：
                                    <asp:TextBox ID="FireArea" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    火灾财产损失：
                                    <asp:TextBox ID="FireEstateLoss" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    火灾伤人数：
                                    <asp:TextBox ID="FireHPeople" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    火灾亡人数：
                                    <asp:TextBox ID="FireDPeople" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <%--  6.--%>
                        <table class="cx6" style="display: none;">
                            <tr>
                                <td>
                                    行政处罚类型：
                                    <asp:CheckBox ID="PunishTypeID0" name="PunishTypeID"  runat="server" />
                                    警告
                                    <asp:CheckBox ID="PunishTypeID1" name="PunishTypeID" runat="server" />
                                    罚款
                                    <asp:CheckBox ID="PunishTypeID2" name="PunishTypeID" runat="server" />
                                    三停
                                    <asp:CheckBox ID="PunishTypeID3" name="PunishTypeID" runat="server" />
                                    行政拘留
                                    <asp:CheckBox ID="PunishTypeID4" name="PunishTypeID" runat="server" />
                                    吊销证照
                                </td>
                                <td>
                                    罚款金额：
                                    <asp:TextBox ID="PunishFinePay" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    违法人：
                                    <asp:TextBox ID="PunishParts" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    违法人（单位）地址：
                                    <asp:DropDownList ID="PunishAdsArea" runat="server" CssClass="txtbottomstyle" Width="150px">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="PunishAds" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <%-- 7.--%>
                        <table class="cx7" style="display: none;">
                            <tr>
                                <td>
                                    临时查封场所地址：
                                    <asp:DropDownList ID="TempCloseArea" runat="server" CssClass="txtbottomstyle" Width="150px">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="TempClose" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    临时查封天数：
                                    <asp:TextBox ID="TempDay" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <%-- 8.--%>
                        <table class="cx8" style="display: none;">
                            <tr>
                                <td>
                                    强制执行对象地址：
                                    <asp:DropDownList ID="ForceRunAdsArea" runat="server" CssClass="txtbottomstyle" Width="150px">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="ForceRunAds" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    行政处罚：
                                    <asp:TextBox ID="ForcePunish" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <%-- 9.--%>
                        <table class="cx9" style="display: none;">
                            <tr>
                                <td>
                                    申请复议、诉讼人（单位）地址：
                                    <asp:DropDownList ID="ApplyFYArea" runat="server" CssClass="txtbottomstyle" Width="150px">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="ApplyFY" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td style="display: none;">
                                    诉讼人（单位）地址：
                                    <asp:TextBox ID="ApplyReviewPeople" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <%--  10--%>
                        <table class="cx10" style="display: none;">
                            <tr>
                                <td>
                                    申请国家赔偿人（单位）地址：
                                    <asp:DropDownList ID="CountryPayAdsArea" runat="server" CssClass="txtbottomstyle"
                                        Width="150px">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="CountryPayAds" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <%-- 11.--%>
                        <table class="cx11" style="display: none;">
                            <tr>
                                <td>
                                    性别：
                                    <%-- <asp:TextBox ID="PenalDocSex" runat="server" CssClass="txtbottomstyle"></asp:TextBox>--%>
                                    <asp:DropDownList ID="PenalDocSex" runat="server" CssClass="txtbottomstyle" Width="100px">
                                        <asp:ListItem Value="男">男</asp:ListItem>
                                        <asp:ListItem Value="女">女</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    出生年份：
                                    <asp:TextBox ID="PenalDocBirthday" onclick='WdatePicker()' runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    民族：
                                    <%--<asp:TextBox ID="PenalDocNation" runat="server" CssClass="txtbottomstyle"></asp:TextBox>--%>
                                    <asp:DropDownList ID="PenalDocNation" runat="server" CssClass="txtbottomstyle" Width="100px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    嫌疑人地址：
                                    <asp:DropDownList ID="PenalDocAdsArea" runat="server" CssClass="txtbottomstyle" Width="150px">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="PenalDocAds" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td colspan="2">
                                    案发地址：
                                    <asp:DropDownList ID="PenalDocCrimeAdsArea" runat="server" CssClass="txtbottomstyle"
                                        Width="150px">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="PenalDocCrimeAds" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    案件危害后果---->
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    过火面积：<asp:TextBox ID="txt_ghmj" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    财产损失：<asp:TextBox ID="txt_ccss" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    伤人数：<asp:TextBox ID="txt_srs" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                                <td>
                                    亡人数：<asp:TextBox ID="txt_wrs" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td width="140" align="right">
                    执法档案承办单位：
                </td>
                <td>
                    <asp:DropDownList ID="drop_EnforcementName" runat="server" CssClass="txtbottomstyle">
                    </asp:DropDownList>
                </td>
                <td width="140" align="right">
                    执法档案库室：
                </td>
                <td colspan="4">
                    <asp:DropDownList ID="drop_FileLibraryName" runat="server" CssClass="txtbottomstyle">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="140" align="right">
                    执法档案承办人(主办)：
                </td>
                <td>
                    <asp:TextBox ID="txt_EnforcementPeople" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                </td>
                <td width="140" align="right">
                    执法档案承办人(协办)：
                </td>
                <td colspan="4">
                    <asp:TextBox ID="txt_EnforcementPeople2" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="140" align="right">
                    执法档案时间：
                </td>
                <td colspan="6">
                    <asp:TextBox ID="txt_EnforcementDate" runat="server" onclick='WdatePicker()' ReadOnly="true"
                        CssClass="txtbottomstyle"></asp:TextBox>
                    &nbsp;&nbsp;----&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txt_EnforcementDate2" runat="server" onclick='WdatePicker()' ReadOnly="true"
                        CssClass="txtbottomstyle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="140" align="right">
                    档案录入人：
                </td>
                <td>
                    <asp:TextBox ID="txtEnterPeople" runat="server" CssClass="txtbottomstyle"></asp:TextBox>
                </td>
                <td width="140" align="right" style="display: none;">
                    档案录入时间：
                </td>
                <td colspan="4" style="display: none;">
                    <asp:TextBox ID="fStarttime" runat="server" onclick='WdatePicker()' ReadOnly="true"
                        CssClass="txtbottomstyle"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div style="margin-top: 10px; text-align: center;">
            <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="submit" OnClick="btnSave_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="Reset" runat="server" Text="重置" CssClass="submit" />
        </div>
    </div>
    </form>
</body>
</html>
