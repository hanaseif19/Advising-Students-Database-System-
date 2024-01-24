<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.Login" %>
<asp:Literal ID="resultLiteral" runat="server" />


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
         <link rel="stylesheet" type="text/css" href="style1.css"/>

</head>
<body class="y">
    <form id="form1" runat="server">
                <header>
    <h1>Login </h1>
</header>
        <div>
            
            ID<br />
&nbsp;<asp:TextBox ID="username" runat="server"></asp:TextBox>
        </div>
        Password<br />
&nbsp;<asp:TextBox ID="password" runat="server"></asp:TextBox>
        <p>
        <asp:Button ID="Button1" CssClass="button" runat="server" OnClick="Button1_Click" Text="Login" />
        </p>
       

    </form>
</body>
</html>