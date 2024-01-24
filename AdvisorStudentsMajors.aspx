<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvisorStudentsMajors.aspx.cs" Inherits="WebApplication2.AdvisorStudentsMajors" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
                 <link rel="stylesheet" type="text/css" href="style1.css"/>
</head>
<body class="y">
    <form id="form1" runat="server">
                <header>
    <h1>View Students of Major </h1>
</header>

        Major
        <asp:TextBox ID="major" runat="server"></asp:TextBox>
        <p>
            <asp:Button Cssclass="button" ID ="studentsbutton" runat="server" Text="View Students" OnClick="studentsbutton_Click" />
        </p>
                <asp:GridView ID="resultGridView" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="Student_name" HeaderText="Student Name" SortExpression="Student_name" />
        <asp:BoundField DataField="major" HeaderText="Major" SortExpression="major" />
        <asp:BoundField DataField="Course_name" HeaderText="Course Name" SortExpression="Course_name" />
    </Columns>
</asp:GridView>
    </form>
</body>
</html>
