<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorDetails.aspx.cs" Inherits="WebApplication2.InstructorDetails" %>
<%@ Register Src="~/WebUserControl2.ascx"TagName="MyBar" TagPrefix="bar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
          <link rel="stylesheet" type="text/css" href="style1.css"/>
</head>
<body class="y">
    <form id="form1" runat="server">
         <bar:MyBar runat="server"  />
        <div>
                        

            details of instructors along with their assigned courses.<br />
            <asp:GridView ID="GridView5" runat="server" DataSourceID="SqlDataSourceinstructors" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="instructor_id" HeaderText="instructor_id" SortExpression="instructor_id" />
                    <asp:BoundField DataField="Instructor" HeaderText="Instructor" SortExpression="Instructor" />
                    <asp:BoundField DataField="course_id" HeaderText="course_id" SortExpression="course_id" />
                    <asp:BoundField DataField="Course" HeaderText="Course" SortExpression="Course" />
                </Columns>
            </asp:GridView>
                      <asp:SqlDataSource ID="SqlDataSourceinstructors" runat="server" ConnectionString="Server=(localdb)\MSSQLLocalDB;Initial Catalog=Advising_System2;Integrated Security=True;"
                SelectCommand="select * from Instructors_AssignedCourses" ></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
