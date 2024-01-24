<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChooseInstructor.aspx.cs" Inherits="WebApplication2.ChooseInstructor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href="style1.css"/> 
    <style>
        .tables-container {
            display: flex;
            justify-content: center;
            gap: 20px;
        }
        .table-container {
            text-align: center;
        }
    </style>
</head>
<body class ="y">
    <form id="form1" runat="server">
        <div class="tables-container">
            <div class="table-container">
                <h2>Instructors Assigned to Courses</h2>
                <asp:Table ID="courseins" runat="server"
                    CellPadding="10"
                    GridLines="Both"
                    HorizontalAlign="Right">
                </asp:Table>
            </div>
            
            <div class="table-container">
                <h2>Choose an instructor for:</h2>
                <asp:Table ID="coursetable" runat="server"
                    CellPadding="10"
                    GridLines="Both"
                    HorizontalAlign="Left">
                </asp:Table>
            </div>
        </div>
        <br />
        <div>
            <asp:Label runat="server" Text="Enter Chosen Instructor ID"></asp:Label>
            <asp:TextBox ID="txtInstructorID" runat="server" placeholder="Instructor ID"></asp:TextBox>
            <asp:Label runat="server" Text="Enter Chosen Course ID"></asp:Label>
            <asp:TextBox ID="txtCourseID" runat="server" placeholder="Course ID"></asp:TextBox>
            <asp:Label runat="server" Text="Enter Student's Current Semester"></asp:Label>
            <asp:TextBox ID="txtCurrentSemester" runat="server" placeholder="Current Semester"></asp:TextBox>
        </div>
        
        <br />
        <asp:Button ID="btnChooseInstructor" runat="server" Text="Choose Instructor" OnClick="btnChooseInstructor_Click" />
        <asp:Label ID="message" runat="server"></asp:Label>
    </form>
</body>
</html>
