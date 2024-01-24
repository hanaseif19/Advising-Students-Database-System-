<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginStudent.aspx.cs" Inherits="WebApplication2.LoginStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
             <link rel="stylesheet" type="text/css" href="style1.css"/>

</head>
<body class="y">
    <form id="form1" runat="server">
        <div>
            Please Log in
            <br />
            &nbsp;&nbsp;Username<br />
            &nbsp;<asp:TextBox ID="username" runat="server"  inputmode ="numeric" ></asp:TextBox>
        </div>
        &nbsp;&nbsp;Password<br />
&nbsp;<input id="password1"  runat="server" type="password"  maxlength="40" />
        <br /><br /><br />
        <asp:Label runat="server" ID="process" Text=""></asp:Label>
        <br /><br />
       &nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="loginB" runat="server" OnClick="Button1_Click" Text="Login" />
        <br /> <br /> 
        Do not have an account? Go and Register
        &nbsp;&nbsp;
        <asp:Button ID="registerB" runat="server" Text="Register" onclick="goRegister"/>
       
    
    </form>
</body>
</html>