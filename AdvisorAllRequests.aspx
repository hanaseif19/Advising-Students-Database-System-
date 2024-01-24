<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvisorAllRequests.aspx.cs" Inherits="WebApplication2.AdvisorAllRequests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href="style1.css"/>

</head>
<body class="y">
    <form id="form1" runat="server">
                <header>
    <h1>All Requests </h1>
</header>

       <asp:GridView ID="requestGridView" runat="server" AutoGenerateColumns="False" EnableViewState="true" OnRowCommand="requestGridView_RowCommand">
    <Columns>
        <asp:BoundField DataField="request_id" HeaderText="Request ID" SortExpression="request_id" />
        <asp:BoundField DataField="type" HeaderText="Type" SortExpression="type" />
        <asp:BoundField DataField="comment" HeaderText="Comment" SortExpression="comment" />
        <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
        <asp:BoundField DataField="credit_hours" HeaderText="Credit Hours" SortExpression="credit_hours" />
        <asp:BoundField DataField="course_id" HeaderText="Course ID" SortExpression="course_id" />
        <asp:BoundField DataField="student_id" HeaderText="Student ID" SortExpression="student_id" />
        <asp:ButtonField ButtonType="Button" CommandName="Respond" HeaderText="Approve" Text="Respond" />
    </Columns>
</asp:GridView>

    </form>
</body>
</html>