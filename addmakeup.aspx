<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addmakeup.aspx.cs" Inherits="WebApplication2.addmakeup" %>
<%@ Register Src="~/part2.ascx"TagName="MyBar2" TagPrefix="bar2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>
        body {
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
            margin: 0;
            background-color:#c8eacd;
        }

         
    </style>
                      <link rel="stylesheet" type="text/css" href="style1.css"/>

</head>
<body class="y">
    <form id="form1" runat="server">
         <bar2:MyBar2 runat="server"/>
        <h1>Adding Makeup</h1>

        <div>
            <label>Exam Date:</label>
            <asp:TextBox ID="ExamDate" runat="server" CssClass="form-control" placeholder="Enter exam date"></asp:TextBox>
        </div>

        <div>&nbsp;</div> <!-- space -->

        <div>
            <label>Course ID:</label>
            <asp:TextBox ID="CourseID" runat="server" CssClass="form-control" placeholder="Enter course ID"></asp:TextBox>
        </div>

        <div>&nbsp;</div>

        <div>
            <asp:Label runat="server">Makeup Type:</asp:Label>
        </div>

        <div>
            <asp:RadioButton ID="makeup1" runat="server" Text="First Makeup" GroupName="makeup" />
            <asp:RadioButton ID="makeup2" runat="server" Text="Second Makeup" GroupName="makeup" />
        </div>

        <div>&nbsp;</div>

        <div>
            <asp:Button ID="submitmakeup" CssClass="button" runat="server" Text="Submit" OnClick="addexamclick"></asp:Button>
        </div>

        <div>&nbsp;</div>
        <div>&nbsp;</div>

        <div>
            <asp:Label ID="usermsg" runat="server" Text="                                                                                                      "></asp:Label>
            <div>&nbsp;</div>
        </div>

        <div>
            <asp:Button ID="Back"  align="bottom-left" CssClass="buttonsmall buttonBack" runat="server" Text="Back" OnClick="getback" />
        </div>
    </form>
</body>

</html>
