<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewPendingRequests.aspx.cs" Inherits="WebApplication2.viewPendingRequests" %>
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
                         <bar:MyBar runat="server" ID="bar" />

            List of all pending requests</div>
        <asp:GridView ID="GridView3" runat="server" DataSourceID="SqlDataSourceRequests" AutoGenerateColumns="False" DataKeyNames="request_id">
            <Columns>
                <asp:BoundField DataField="request_id" HeaderText="request_id" InsertVisible="False" ReadOnly="True" SortExpression="request_id" />
                <asp:BoundField DataField="type" HeaderText="type" SortExpression="type" />
                <asp:BoundField DataField="comment" HeaderText="comment" SortExpression="comment" />
                <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                <asp:BoundField DataField="credit_hours" HeaderText="credit_hours" SortExpression="credit_hours" />
                <asp:BoundField DataField="course_id" HeaderText="course_id" SortExpression="course_id" />
                <asp:BoundField DataField="student_id" HeaderText="student_id" SortExpression="student_id" />
                <asp:BoundField DataField="advisor_id" HeaderText="advisor_id" SortExpression="advisor_id" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceRequests" runat="server" ConnectionString="Server=(localdb)\MSSQLLocalDB;Initial Catalog=Advising_System2;Integrated Security=True;"
          SelectCommand="select * from all_Pending_Requests" ></asp:SqlDataSource>
    </form>
</body>
</html>
