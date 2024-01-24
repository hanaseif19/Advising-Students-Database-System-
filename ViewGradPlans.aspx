<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewGradPlans.aspx.cs" Inherits="WebApplication2.ViewGradPlans" %>
<%@ Register Src="~/part2.ascx"TagName="MyBar2" TagPrefix="bar2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
                   <link rel="stylesheet" type="text/css" href="style1.css"/> 

</head>
<body class="y">
    <form id="form1" runat="server">
           <div>
                          <bar2:MyBar2 runat="server"/>

<asp:Table id="gradplans" runat="server"
                  CellPadding="10" 
               GridLines="Both"
    width="200px"
               HorizontalAlign="Center">
       </asp:Table>        
       
   </div>
     <div>&nbsp;</div>
     <div>&nbsp;</div>
     <div>&nbsp;</div>
     <div>&nbsp;</div>
  <div>
      <asp:Button ID="Back" CssClass="buttonsmall buttonBack" runat="server" Text="Back" OnClick="getback" />
  </div>
    </form>
</body>
</html>
