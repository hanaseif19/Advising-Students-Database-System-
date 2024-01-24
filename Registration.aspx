<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebApplication2.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
         <link rel="stylesheet" type="text/css" href="style1.css"/>

</head >
<body class="y">
    <form id="form1" runat="server">
                        <header>
    <h1>Register </h1>
</header>
        <div>
        <div>
<br />
            <br />
            Name:&nbsp;
            <asp:TextBox ID="advisorName" runat="server"></asp:TextBox>
            <br />
            <br />
            Password:
            <asp:TextBox ID="advisorPass" runat="server" ></asp:TextBox>
            <br />
            <br />
            Email:
            <asp:TextBox ID="advisorEmail" runat="server"></asp:TextBox>
            <br />
            <br />
            Office:
            <asp:TextBox ID="advisorOffice" runat="server"></asp:TextBox>
            <br />
            <br />
        </div>
        <p>
            <asp:Button ID="advisorButton" CssClass="button" runat="server" Text="Register"  OnClick="AdvisorRegistration" />
        </p>
   Already Registered? 
          <asp:Button ID="Button2" CssClass="buttonsmall" runat="server" Text="Login"  OnClick="Loginclick" />

    </form>
</body>
</html>