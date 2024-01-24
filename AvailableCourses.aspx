<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AvailableCourses.aspx.cs" Inherits="WebApplication2.AvailableCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style1.css"/> 
</head>
<body class ="y">
    <form id="form1" runat="server">
        <div><br /><br />
            <label for="DropDownListSemesters">Select a Semester</label>
            <asp:DropDownList ID="DropDownListSemesters" runat="server" OnSelectedIndexChanged="View" AutoPostBack="true"></asp:DropDownList>
            <asp:Label ID="errorMessage" runat="server" Text=""></asp:Label>
            
          <asp:GridView ID="AvailableCourses1" runat="server"
            AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">  
    <Columns>  
        <asp:BoundField DataField="course_id" HeaderText="CourseID" />  
        <asp:BoundField DataField="name" HeaderText="CourseName" />  
    </Columns>  
<EmptyDataTemplate>No Avaialble Courses</EmptyDataTemplate>  
            
       </asp:GridView>
        </div>
    </form>
</body>
</html>
