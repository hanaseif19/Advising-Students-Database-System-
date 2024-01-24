<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvisorDeleteCourse.aspx.cs" Inherits="WebApplication2.AdvisorDeleteCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
                                  <link rel="stylesheet" type="text/css" href="style1.css"/> 

</head>
<body class="y">
    <form id="form1" runat="server">
                <header>
    <h1>Delete Course From Graduation Plan </h1>
</header>
        <div>
            Student Id:
            <asp:TextBox ID="sid" runat="server"></asp:TextBox>
            <br />
            Semester Code:
            <asp:TextBox ID="semcode" runat="server"></asp:TextBox>
            <br />
            Course Id:
            <asp:TextBox ID="cid" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="deleteButton" CssClass="button" runat="server" Text="Delete Course" OnClick="deleteButton_Click" />
    </form>
</body>
</html>
