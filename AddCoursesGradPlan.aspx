<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCoursesGradPlan.aspx.cs" Inherits="WebApplication2.AddCoursesGradPlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
                              <link rel="stylesheet" type="text/css" href="style1.css"/> 

</head>
<body class="y">
    <form id="form1" runat="server">
                <header>
    <h1>Add Course to Graduation Plan </h1>
</header>
        <div>
            Student Id:
            <asp:TextBox ID="studentid" runat="server"></asp:TextBox>
            <br />
            Semester Code:
            <asp:TextBox ID="semestercode" runat="server"></asp:TextBox>
            <br />
            Course Name:<asp:TextBox ID="coursename" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="addcoursebutton" CssClass="button" runat="server" Text="Add Course" OnClick="addcoursebutton_Click" />
    </form>
</body>
</html>
 
