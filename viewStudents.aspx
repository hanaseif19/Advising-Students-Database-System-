<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewStudents.aspx.cs" Inherits="WebApplication2.viewStudents" %>
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
                         <bar:MyBar runat="server"  />

            List of all students with their corresponding advisors in the system.</div>
        <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSourceStudents" AutoGenerateColumns="False" DataKeyNames="student_id,advisor_id">
            <Columns>
                <asp:BoundField DataField="student_id" HeaderText="student_id" InsertVisible="False" ReadOnly="True" SortExpression="student_id" />
                <asp:BoundField DataField="f_name" HeaderText="f_name" SortExpression="f_name" />
                <asp:BoundField DataField="l_name" HeaderText="l_name" SortExpression="l_name" />
                <asp:BoundField DataField="advisor_id" HeaderText="advisor_id" InsertVisible="False" ReadOnly="True" SortExpression="advisor_id" />
                <asp:BoundField DataField="advisor_name" HeaderText="advisor_name" SortExpression="advisor_name" />
            </Columns>
        </asp:GridView>
         <asp:SqlDataSource ID="SqlDataSourceStudents" runat="server" ConnectionString="Server=(localdb)\MSSQLLocalDB;Initial Catalog=Advising_System2;Integrated Security=True;"
           SelectCommand="AdminListStudentsWithAdvisors" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    </form>
</body>
</html>
