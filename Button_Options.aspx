
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Button_Options.aspx.cs" Inherits="WebApplication2.Button_Options" %>
<%@ Register Src="~/part2.ascx"TagName="MyBar2" TagPrefix="bar2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
               <bar2:MyBar2 runat="server"/>     
    </form>
</body>
</html>

