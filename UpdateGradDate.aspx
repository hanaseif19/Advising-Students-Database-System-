<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateGradDate.aspx.cs" Inherits="WebApplication2.UpdateGradDate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Graduation Date</title>
                                          <link rel="stylesheet" type="text/css" href="style1.css"/> 

</head>
<body class="y">

    <form id="form1" runat="server">
        <header>
    <h1>Update Graduation Date </h1>
</header>

        <div>
            Student ID:
            <asp:TextBox ID="sid" runat="server"></asp:TextBox>
            <br />
            Expected Graduation Date:
            <asp:TextBox ID="graddate" runat="server"></asp:TextBox>
        </div>
        <div>&nbsp;</div>
        <asp:Button ID="update" CssClass="button" runat="server" Text="Update" OnClick="update_Click" />
    </form>
</body>
</html>
