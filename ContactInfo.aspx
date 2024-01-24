<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactInfo.aspx.cs" Inherits="WebApplication2.ContactInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style1.css"/> 
</head>
<body class="y">
    <form id="form1" runat="server">
        <div>
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Add contact Info. <br />
            
            <asp:TextBox ID="phoneNumber" runat="server" MaxLength="40"></asp:TextBox>
            <br /><br />
            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" ID="addNewSucces" Text=""></asp:Label>
            <asp:Button ID="Add" runat="server" Text="Add" onclick ="addNewPhone"/>
            </div>
        
    </form>
</body>
</html>
