<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="linkStudentAdvisor.aspx.cs" Inherits="WebApplication2.linkStudentAdvisor" %>
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
                                                 


            Link a student to an advisor.<br />
            <br />
            Student ID:<br />
            <asp:TextBox ID="stdID" runat="server"></asp:TextBox>
            <br />
            Advisor ID:<br />
            <asp:TextBox ID="advID" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Link2" CssClass="button" runat="server" Text="Link" OnClick="Link2_Click" />
        </div>
    </form>
</body>
</html>
