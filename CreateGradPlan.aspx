<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateGradPlan.aspx.cs" Inherits="WebApplication2.CreateGradPlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
                                      <link rel="stylesheet" type="text/css" href="style1.css"/> 

</head>
<body class="y">
    <form id="form1" runat="server">
                <header>
    <h1>Create Graduation Plan </h1>
</header>
        <p>
            Enter the following data:
        </p>
        Semester code:
        <asp:TextBox ID="semcode" runat="server"></asp:TextBox>
        <p>
            Expected Graduation Date:&nbsp;
            <asp:TextBox ID="graddate" runat="server"></asp:TextBox>
        </p>
        Semester Credit Hours<asp:TextBox ID="credithours" runat="server"></asp:TextBox>
        <p>
            Student ID
            <asp:TextBox ID="sid" runat="server"></asp:TextBox>
<%--        </p>
        Advisor ID<asp:TextBox ID="aid" runat="server"></asp:TextBox>
&nbsp;<p>--%>
            <p>&nbsp;</p> 
        <asp:Button ID="createplan" CssClass="button" runat="server" OnClick="createbutton" Text="Create" />
        </p>

    </form>
</body>
</html>
