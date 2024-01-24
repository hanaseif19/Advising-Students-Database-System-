<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MissingCourses.aspx.cs" Inherits="WebApplication1.MissingCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
             <link rel="stylesheet" type="text/css" href="style1.css"/>

</head>
<body class="y">
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="MissingCourses1" runat="server"
                AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">  
                    <Columns>  
                        <asp:BoundField DataField="CourseID" HeaderText="CourseID" />  
                        <asp:BoundField DataField="CourseName" HeaderText="CourseName" />  
                    </Columns>  
                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>  
                 
            </asp:GridView>
        </div>
    </form>
</body>
</html>
