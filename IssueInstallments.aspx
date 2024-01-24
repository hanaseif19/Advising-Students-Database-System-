<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IssueInstallments.aspx.cs" Inherits="WebApplication2.IssueInstallments" %>
<%@ Register Src="~/part2.ascx"TagName="MyBar2" TagPrefix="bar2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
                          <link rel="stylesheet" type="text/css" href="style1.css"/> 

</head>
<body class="y">
    <form id="form1" runat="server" style="text-align: center;">
                     <bar2:MyBar2 runat="server" />

        <h1>
            Issue Installments 
        </h1>
        <div>
            <asp:Label ID="inslabel" runat="server" Text="Enter Payment ID" ></asp:Label>
            <asp:TextBox ID="paymentid" runat="server" placeholder="payment id "></asp:TextBox>
          
<div>&nbsp;</div>
<div>&nbsp;</div>
            <asp:Button CssClass="button" ID="submitissue" runat="server" Text="Submit" OnClick="clickissueinst"/>
        </div>


      <div>&nbsp;</div>
      <div>&nbsp;</div>
<div>
        <asp:Label ID="usermsg2" runat="server"></asp:Label>

    <div>&nbsp;</div>
</div>
        <div>
    <asp:Button ID="Back" CssClass="buttonsmall buttonBack" runat="server" Text="Back" OnClick="getback" />
</div>
        
        
    </form>
</body>
</html>
