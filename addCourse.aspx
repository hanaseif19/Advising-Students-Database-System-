<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addCourse.aspx.cs" Inherits="WebApplication2.addCourse" %>
<!-- <%@ Register Src="~/WebUserControl1.ascx"TagName="MyButton" TagPrefix="uc" %> !-->
<%@ Register Src="~/WebUserControl2.ascx"TagName="MyBar" TagPrefix="bar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
                  <link rel="stylesheet" type="text/css" href="style1.css"/>

    
</head>

<body class="y">
    <form id="form1" runat="server">
         <bar:MyBar runat="server"/>
        <div>
             Add a new Course
            <br />
            <br />
            Major:<br />
             <asp:TextBox ID="majortetxboxID" runat="server"></asp:TextBox>
            <br />
            Semester:<br />
             <asp:TextBox ID="semestertextboxID" runat="server"></asp:TextBox>
            <br />
            Credit Hours:<br />
             <asp:TextBox ID="ch" runat="server"></asp:TextBox>
            <br />
            Name:<br />
             <asp:TextBox ID="coursename" runat="server"></asp:TextBox>
            <br />
            Offered:<br />
             <asp:TextBox ID="offeredtextboxID" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="addcoursebutton" CssClass="button" runat="server" Text="add course" OnClick="addcoursebutton_Click" />
        </div>
    </form>
</body>
</html>
