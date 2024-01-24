<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OptionalCourses.aspx.cs" Inherits="WebApplication1.OptionalCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
                 <link rel="stylesheet" type="text/css" href="style1.css"/>

</head>
<body class="y">
    <form id="form1" runat="server">
        <div>          <label for="DropDownListSemesters">Select a Semester</label>
<asp:DropDownList ID="DropDownListSemesters" runat="server" OnSelectedIndexChanged="showCourses" AutoPostBack="True"></asp:DropDownList>
<asp:Label ID="errorMessage" runat="server" Text=""></asp:Label>

                   <asp:GridView ID="OptionalCourses1" runat="server"
            AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">  
<Columns>  
    <asp:BoundField DataField="CourseID" HeaderText="CourseID" />  
    <asp:BoundField DataField="CourseName" HeaderText="CourseName" />  
</Columns>  
<EmptyDataTemplate>No Optional Courses</EmptyDataTemplate>  
            
       </asp:GridView>
        </div>
    </form>
</body>
</html>
