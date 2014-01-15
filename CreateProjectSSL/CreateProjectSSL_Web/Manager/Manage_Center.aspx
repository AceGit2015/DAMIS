<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage_Center.aspx.cs" Inherits="Manager_Manage_Center" %>

<%@ Register Src="~/ConfigCol/Index.ascx" TagName="header" TagPrefix="headerControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <headerControl:header ID="header1" runat="server" />
    <script type="text/javascript">
        function openNewDiv(div_id, yjid, daid) {
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
            document.getElementById("HiddenFieldda").value = daid;
            document.getElementById("HiddenFieldyj").value = yjid;
        }
        function colseNewDiv(div_id) {
            var newDiv = document.getElementById(div_id);
            newDiv.style.display = "none";
            document.body.removeChild(document.getElementById("mask"));
        }
        function openNewDiv_js(div_id, jsid, daid) {
            var newMask = document.createElement("div");
            newMask.id = "mask";
            newMask.style.position = "absolute";
            newMask.style.zIndex = "1";
            newMask.style.width = "100%";
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
            document.getElementById("HiddenFieldjs").value = jsid;
            document.getElementById("HiddenFieldjsda").value = daid;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable"  >
            <tr>
                <th colspan="2" align="left"  class="navigation">
                    用户基本信息
                </th>
            </tr>
            <tr>
                <td width="25%" align="right">
                    用户名称：
                </td>
                <td width="75%">
                    <asp:Label ID="lbusername" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="25%" align="right">
                    联系电话：
                </td>
                <td width="75%">
                    <asp:Label ID="lblxdh" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    电子邮箱：
                </td>
                <td>
                    <asp:Label ID="lbdzyx" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    组织机构：
                </td>
                <td>
                    <asp:Label ID="lbzzjg" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    所属单位：
                </td>
                <td>
                    <asp:Label ID="lbssdw" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable"  <%=GetStyle %>>
            <tr>
                <th align="left"  class="navigation">
                    <span class="pljs"><a id="A4" title="批量接收" runat="server" onserverclick="btnCheckSave_Click" class="button green">批量接收</a>&nbsp;&nbsp;&nbsp;&nbsp;</span>最新档案移交信息
                </th>
            </tr>
            <tr>
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tb_data">
                        <tr>
                            <th width="60">
                                <input type="checkbox" id="CheckAllinfor" style="cursor: pointer;" />选择
                            </th>
                            <th width="60" align="center">
                                序号
                            </th>
                            <th width="160" align="center">
                                执法档案名称
                            </th>
                            <th width="160" align="center">
                                案卷卷别类型
                            </th>
                            <th width="120" align="center">
                                移交人
                            </th>
                            <th width="120" align="center">
                                移交单位
                            </th>
                            <th width="120" align="center">
                                移交日期
                            </th>
                            <th width="80">
                                操作
                            </th>
                        </tr>
                        <asp:Repeater ID="rptList" runat="server" OnPreRender="rptList_PreRender" OnItemCommand="LinkButtonALL_Command" OnItemDataBound="RadGrid1_ItemDataBound">
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
                                        <%#Eval("FileEnterName")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("FileClassName")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("TransferPeople")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("TransferUnit")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("TransferDate")%>
                                    </td>
                                    <td align="center">
                                        <asp:HiddenField ID="HiddenField1" runat="server"  Value='<%#Eval("sjzt") %>' />
                                        <span style="color: Blue;">
                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="接收" CommandName="FileTransfer"
                                                OnCommand="LinkButtonALL_Command" CommandArgument='<%# Eval("ID")+","+Eval("FileEnterID") %>'  Visible="false"> </asp:LinkButton></span>
                                        <asp:Label ID="Label1" runat="server" Text="|"></asp:Label> <span style="color: Blue;">
                                            <%--<asp:LinkButton ID="LinkButton2" OnClientClick="openNewDiv_js('div_js')" runat="server" Text="拒收" CommandName="FileTransferJS"
                                                OnCommand="LinkButtonALL_Command" CommandArgument='<%# Eval("ID") %>' Visible="false"></asp:LinkButton>--%><%#Eval("sjzt").ToString() == "0" ? "<a onclick=\"openNewDiv_js('div_js','" + Eval("ID") + "','" + Eval("FileEnterID") + "')\">拒收 </a>" : ""%>
                                            <%#Eval("sjzt").ToString() == "0" ? "" : "<a onclick=\"openNewDiv('theDiv','" + Eval("ID") + "','" + Eval("FileEnterID") + "')\">归档 </a>"%></span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <div style="line-height: 30px; height: 30px; margin-right: 10px; margin-top: 2px;">
                        <%--实现分页技术--%>
                        <div class="right">
                            <Peter:Pager ID="Pager1" runat="server" OnPageIndexChanging="Pager1_PageIndexChanging" />
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="HiddenFieldda" runat="server" />
    <asp:HiddenField ID="HiddenFieldyj" runat="server" />
    <div id="theDiv" style="display: none;">
        <div style="text-align: right;">
            <img style="cursor: pointer;" alt="关闭" src="../Images/closeicon.gif" onclick="colseNewDiv('theDiv')" /></div>
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
    <asp:HiddenField ID="HiddenFieldjs" runat="server" />
    <asp:HiddenField ID="HiddenFieldjsda" runat="server" />
    <div id="div_js" style="display: none;">
        <div style="text-align: right;">
            <img style="cursor: pointer;" alt="关闭" src="../Images/closeicon.gif" onclick="colseNewDiv('div_js')" /></div>
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td align="right" style="width: 40%; height: 30px; line-height: 30px;">
                    拒收原由：
                </td>
                <td align="left" style="width: 60%; height: 30px; line-height: 50px;" colspan="2">
                    <asp:TextBox ID="txt_jsyy" runat="server" Width="300px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 10px; line-height: 10px;" colspan="3">
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 40%; height: 30px; line-height: 30px;">
                    <asp:Button ID="Button1" runat="server" Text="确定" class="button green" OnClick="btnCheckSavejs_Click" />
                </td>
                <td align="left" style="width: 10%; height: 30px; line-height: 30px;">
                </td>
                <td align="left" style="width: 50%; height: 30px; line-height: 30px;">
                    <input id="button2" type="button" value="取消" class="button green" onclick="colseNewDiv('div_js');" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
