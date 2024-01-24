<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="WebApplication2.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   

    <title>Welcome to Our Advising System</title>
     <link rel="stylesheet" type="text/css" href="style1.css"/>
</head>
<body class="y">
    <div class="homeform">
        
    <form id="form11" runat="server">
        <div>
            <h1>Welcome to Our Advising System</h1>
            <p>Please choose your role:</p>

            <asp:Button ID="btnStudent" runat="server" Text="Student" CssClass="button" OnClick="btnStudent_Click" />
            <asp:Button ID="btnAdvisor" runat="server" Text="Advisor" CssClass="button" OnClick="btnAdvisor_Click" />
            <asp:Button ID="btnAdmin" runat="server" Text="Admin" CssClass="button" OnClick="btnAdmin_Click" />
        </div>
    </form>
       </div>
</body>
</html>

