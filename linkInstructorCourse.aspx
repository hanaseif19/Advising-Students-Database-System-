<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="linkInstructorCourse.aspx.cs" Inherits="WebApplication2.linkInstructorCourse" %>
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

            Link instructor to a course in a specific slot<br />
            <br />
            CourseID:<br />
            <asp:TextBox ID="cID" runat="server"></asp:TextBox>
            <br />
            InstructorID:<br />
            <asp:TextBox ID="iID" runat="server"></asp:TextBox>
            <br />
            SlotID:<br />
            <asp:TextBox ID="sID" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Link1" CssClass="button" runat="server" Text="Link" OnClick="Link1_Click" />
        </div>
    </form>
</body>
</html>
