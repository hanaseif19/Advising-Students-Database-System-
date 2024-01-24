<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPayment.aspx.cs" Inherits="WebApplication2.ViewPayment" %>
<%@ Register Src="~/part2.ascx"TagName="MyBar2" TagPrefix="bar2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title></title>
    
              <link rel="stylesheet" type="text/css" href="style1.css"/> 



</head>
<body class="y">
  <form id="form1" runat="server">
                   <bar2:MyBar2 runat="server" />

    <div class="tablediv">
 <asp:Table id="studentpayment" runat="server"
                   CellPadding="10" 
                GridLines="Both"
                width="100px"
                HorizontalAlign="Center"
      style="margin-left: 50px;">
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
