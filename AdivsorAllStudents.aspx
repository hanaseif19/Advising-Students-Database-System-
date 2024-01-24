<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdivsorAllStudents.aspx.cs" Inherits="WebApplication2.AdivsorAllStudents" %>
<%@ Register Src="~/advisornav.ascx"TagName="MyBar3" TagPrefix="bar3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
             <link rel="stylesheet" type="text/css" href="style1.css"/>

</head>
<body class="y">
    <form id="form1" runat="server">
                <header>
    <h1>All Students </h1>
</header>
                 
       <%-- <div>
           Advisor Id :  <asp:TextBox ID="advisorid"  runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="showstudents" OnClick="getstudents_Click" runat="server" Text="View Students" />--%>
        <bar3:MyBar3 runat="server"/>

         <asp:GridView ID="studentGridView" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="student_id" HeaderText="Student ID" SortExpression="student_id" />
                    <asp:BoundField DataField="f_name" HeaderText="First Name" SortExpression="f_name" />
                    <asp:BoundField DataField="l_name" HeaderText="Last Name" SortExpression="l_name" />
                    <asp:BoundField DataField="password" HeaderText="Password" SortExpression="password" />
                    <asp:BoundField DataField="gpa" HeaderText="GPA" SortExpression="gpa" />
                    <asp:BoundField DataField="faculty" HeaderText="Faculty" SortExpression="faculty" />
                    <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                    <asp:BoundField DataField="major" HeaderText="Major" SortExpression="major" />
                    <asp:BoundField DataField="financial_status" HeaderText="Financial Status" SortExpression="financial_status" />
                    <asp:BoundField DataField="semester" HeaderText="Semester" SortExpression="semester" />
                    <asp:BoundField DataField="acquired_hours" HeaderText="Acquired Hours" SortExpression="acquired_hours" />
                    <asp:BoundField DataField="assigned_hours" HeaderText="Assigned Hours" SortExpression="assigned_hours" />
                </Columns>
            </asp:GridView>
    </form>
</body>
</html>
