<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Manager_Index" %>

<%@ Register Src="~/ConfigCol/Index.ascx" TagName="header" TagPrefix="headerControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>执法档案-主界面</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <headerControl:header ID="header1" runat="server" />
</head>
<frameset rows="86,*,25" frameborder="NO" border="0" framespacing="0">
	<frame src="Manage_Top.aspx" noresize="noresize" frameborder="NO" name="topFrame" scrolling="no" marginwidth="0" marginheight="0" target="tops" />
  <frameset cols="147,*"  rows="*" id="BottomFrame">
	<frame src="Manage_Left.aspx" name="leftFrame" noresize="noresize" marginwidth="0" marginheight="0" frameborder="NO" scrolling="auto" target="lefts" />
	<frame src="Manage_center.aspx" name="sysMain" marginwidth="0" marginheight="0" frameborder="0" scrolling="auto" target="_self" />
  </frameset>
     <frame src="Manage_Bottom.aspx" name="BottomFrame" noresize="noresize" marginwidth="0" marginheight="0" frameborder="0" scrolling="no" target="bottoms" />
<noframes>
  <body></body>
    </noframes>
</html>
