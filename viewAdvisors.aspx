<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewAdvisors.aspx.cs" Inherits="WebApplication2.viewAdvisors" %>
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
                         <bar:MyBar runat="server" />

            list of all advisors</div>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSourceAdvisors" AutoGenerateColumns="False" DataKeyNames="advisor_id">
            <Columns>
                <asp:BoundField DataField="advisor_id" HeaderText="advisor_id" InsertVisible="False" ReadOnly="True" SortExpression="advisor_id" />
                <asp:BoundField DataField="advisor_name" HeaderText="advisor_name" SortExpression="advisor_name" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                <asp:BoundField DataField="office" HeaderText="office" SortExpression="office" />
                <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceAdvisors" runat="server" ConnectionString="Server=(localdb)\MSSQLLocalDB;Initial Catalog=Advising_System2;Integrated Security=True;"
            SelectCommand="SELECT * FROM Advisor" OnSelecting="SqlDataSourceAdvisors_Selecting"></asp:SqlDataSource>
    </form>
</body>
</html>
