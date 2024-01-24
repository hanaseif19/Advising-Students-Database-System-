<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registeration</title>
                 <link rel="stylesheet" type="text/css" href="style1.css"/>

</head>
<body class="y">
    <form id="form1" runat="server">
             <div>
            First name:
            <asp:TextBox ID="fname" runat="server" required MaxLength="40"></asp:TextBox>
            Last name:
            <asp:TextBox ID="lname" runat="server" required MaxLength="40"></asp:TextBox>
            <div/><br />
                 <div>
            Password:&nbsp;&nbsp;
            <asp:TextBox ID="newPass" runat="server" required MaxLength="40"></asp:TextBox>
           Faculty:&nbsp;&nbsp; &nbsp;&nbsp;
          <asp:TextBox ID="faculty1" runat="server" required MaxLength="40"></asp:TextBox>
    <div/>
<div><br />
            E-mail:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="email1" runat="server" required pattern="[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" title="Please enter a correct mail in the format of anything@example.com" MaxLength="40"></asp:TextBox>
    <div/>
<div><br />
            Major:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="major1" runat="server" required MaxLength="40"></asp:TextBox>
            &nbsp;&nbsp;
            Semester:
         <asp:DropDownList ID="Semester1" runat="server">
             
         </asp:DropDownList>
        </div>
    <br />
    <br />
    <div>
        <asp:Label runat="server" ID="registerError" Text=""></asp:Label>
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="registerB4" runat="server" Text="Register" OnClick="addStudent" /><div/>
        <b />
          <asp:Label runat="server" ID="success" Text=""></asp:Label>
    </form>
</body>
</html>
