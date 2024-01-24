<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="linkStudentCourse.aspx.cs" Inherits="WebApplication2.linkStudentCourse" %>
<%@ Register Src="~/WebUserControl2.ascx"TagName="MyBar" TagPrefix="bar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
                                 <link rel="stylesheet" type="text/css" href="style1.css"/>

</head>
<body class="y">
    <form id="form1" runat="server">
        <div>
                         <bar:MyBar runat="server" />

            Link a student to a course with a specific instructor.<br />
            <br />
            Course ID:<br />
            <asp:TextBox ID="TextBoxCourseID" runat="server"></asp:TextBox>
            <br />
            Instructor ID:<br />
            <asp:TextBox ID="TextBoxInstID" runat="server"></asp:TextBox>
            <br />
            Student ID:<br />
            <asp:TextBox ID="TextBoxStdID" runat="server"></asp:TextBox>
            <br />
            Semester Code:<br />
            <asp:TextBox ID="TextBoxSemCode" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="link3" CssClass="button" runat="server" Text="Link" OnClick="link3_Click" />
        </div>
    </form>
</body>
</html>
