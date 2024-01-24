<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="WebApplication2.AdminDashboard" %>
<%@ Register Src="~/WebUserControl1.ascx"TagName="MyButton" TagPrefix="uc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 433px;
        }
     body {
         margin: 0;
         font-family: Arial, sans-serif;
         background-color: #e6e6fa;
     }
     .sidenav {
         height: 100%;
         width: 250px;
         position: fixed;
         z-index: 1;
         top: 0;
         left: 0;
         background-color:black;
         padding-top: 20px;
     }

     .sidenav a {
         padding: 8px 8px 8px 32px;
         text-decoration: none;
         font-size: 18px;
         color: lavender;
         display: block;
         cursor: pointer;
     }

     .sidenav a:hover {
         color: grey
     }

     .content {
         margin-left: 250px;
         padding: 16px;
     }
 
    </style>
</head>
<body style="height: 549px">
    <form id="form1" runat="server">
        <div>
             <uc:MyButton runat="server" ID="ucMyButton" />
<div class="sidenav">
        <asp:LinkButton ID="advisors1" runat="server" Text="all advisors" OnClick="advisors_Click" />
        <asp:LinkButton ID="students1" runat="server" Text="all Students"  OnClick="students_Click" />
        <asp:LinkButton ID="requests1" runat="server" Text="all pending requests"  OnClick="requests_Click" />
        <asp:LinkButton ID="Button12" runat="server" Text="add new semester" OnClick="Button1_Click" />
        <asp:LinkButton ID="Button22" runat="server" Text="add new course"  OnClick="Button2_Click" />
        
        <asp:LinkButton ID="Button33" runat="server" Text="link instructor to course"  OnClick="Button3_Click" />
        
        <asp:LinkButton ID="Button44" runat="server" Text="link student to advisor"  OnClick="Button4_Click" />
       
        <asp:LinkButton ID="Button55" runat="server" Text="link student to course"  OnClick="Button5_Click" />
        
        <asp:LinkButton ID="Button66" runat="server" Text="view instructors and their courses"  OnClick="Button6_Click" />
       
        <asp:LinkButton ID="Button77" runat="server" Text="view semesters"  OnClick="Button7_Click" />
        
        <asp:LinkButton ID="Button88" runat="server" Text="More Options"  OnClick="Button8_Click" />
            </div>
            </div>
    </form>
</body>
</html>
