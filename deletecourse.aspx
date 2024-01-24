<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deletecourse.aspx.cs" Inherits="WebApplication2.deletecourse" %>
<%@ Register Src="~/part2.ascx"TagName="MyBar2" TagPrefix="bar2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
                      <link rel="stylesheet" type="text/css" href="style1.css"/> 

</head>
<body class="y">
    <form id="form1" runat="server">
                     <bar2:MyBar2 runat="server"  />
       
        <div>
            <asp:GridView ID="GridViewCourses" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewCourses_RowCommand" DataKeyNames="course_id">
    <Columns>
        <asp:BoundField DataField="course_id" HeaderText="Course ID" SortExpression="course_id" />
        <asp:BoundField DataField="name" HeaderText="Course Name" SortExpression="name" />
        <asp:BoundField DataField="major" HeaderText="Major" SortExpression="major" />
        <asp:BoundField DataField="credit_hours" HeaderText="Credit Hours" SortExpression="credit_hours" />
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:Button ID="btnDelete" CssClass="buttonsmall" runat="server" Text="Delete" CommandName="DeleteCourse" CommandArgument='<%# Container.DataItemIndex %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

        </div>
        <div>
            <div>&nbsp;</div>
            <div>&nbsp;</div>
            <asp:Label ID="usermsg" runat="server" ></asp:Label>
             <div>&nbsp;</div>
 <div>&nbsp;</div>
    <asp:Button ID="Back" CssClass="buttonsmall buttonBack" runat="server" Text="Back" OnClick="getback" />
</div>
    </form>
</body>
</html>
