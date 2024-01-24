<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="WebApplication2.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

        <link rel="stylesheet" type="text/css" href="style1.css"/>

    <title></title>
           
</head>
<body class="y">
    <form id="form1" runat="server">
        <div>
           <div class="textmiddle"> Please Log In </div> <br />
            Username:<br />
            <asp:TextBox ID="Username" runat="server" OnTextChanged="Username_TextChanged" Height="33px" Width="203px"></asp:TextBox>
            <br />
            <br />
            Password:<br />
            <asp:TextBox ID="Password" textmode="password" runat="server" Height="34px" Width="202px"></asp:TextBox>
            <br />
            <br />
            <asp:button  ID="Login" runat="server" Text="Login" OnClick="login" Height="41px" Width="82px" CssClass="button"/>
            <br />
           
    <div>&nbsp;</div>
        </div>
    </form>
</body>
</html>
