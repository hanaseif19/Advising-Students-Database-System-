<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="Please log in"></asp:Label>
        </div>
        <div class="">
            <asp:Label runat="server" text="username"></asp:Label>&nbsp;</div>
        <div class="">
            <asp:TextBox runat="server" ID="username" ></asp:TextBox>&nbsp;</div>
        <div class="">
            <asp:Label runat="server" Text="password"></asp:Label>&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">
            <asp:TextBox runat="server" ID="password"></asp:TextBox>&nbsp;</div>
        <div class="">
            <asp:Button runat="server" id="signin" Text="Log In" OnClick="login"></asp:Button>&nbsp;

        </div>
        <div class="">&nbsp;</div>
        <div>&nbsp;</div>
        <div>&nbsp;</div>
        <div>&nbsp;</div>
        
       
       
    </form>
</body>
</html>
