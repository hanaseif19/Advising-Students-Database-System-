<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SlotsCourseInstructor.aspx.cs" Inherits="WebApplication1.SlotsCourseInstructor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" type="text/css" href="style1.css"/> 

</head>
<body class="y">
    <form id="form1" runat="server">
        <div>
            <label for="txtCourseID">Course ID:</label>
            <asp:TextBox ID="txtCourseID" runat="server" CssClass="textbox"></asp:TextBox>
            <br />
            <label for="txtInstructorID">Instructor ID:</label>
            <asp:TextBox ID="txtInstructorID" runat="server" CssClass="textbox"></asp:TextBox>
            <br />
            <asp:Button ID="btnViewSlots" runat="server" Text="View Slots" OnClick="btnViewSlots_Click" />
            <br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            <br />
            <asp:Table id="slotTable" runat="server"
                CellPadding="10" 
                GridLines="Both"
                HorizontalAlign="Center">
            </asp:Table>
        </div>
    </form>
</body>
</html>
