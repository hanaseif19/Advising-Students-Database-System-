<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewSemesters.aspx.cs" Inherits="WebApplication2.viewSemesters" %>
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
       
            semesters along with their offered courses
         <div>
            <asp:GridView ID="GridView4" runat="server" DataSourceID="SqlDataSourceSem" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="course_id" HeaderText="course_id" SortExpression="course_id" />
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="semester_code" HeaderText="semester_code" SortExpression="semester_code" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSourceSem" runat="server" ConnectionString="Server=(localdb)\MSSQLLocalDB;Initial Catalog=Advising_System2;Integrated Security=True;"
  SelectCommand="select * from Semster_offered_Courses" ></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
