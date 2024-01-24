<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl2.ascx.cs" Inherits="WebApplication2.WebUserControl2" %>
<%@ Register Src="~/WebUserControl1.ascx"TagName="MyButton" TagPrefix="uc" %>
   
<style>
     body {
     margin: 0;
     font-family: Arial, sans-serif;
     background-color: #e6e6fa;
     text-align:left;
     
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
    text-align:left;
    
}

.sidenav a {
    padding: 8px 8px 8px 32px;
    text-decoration: none;
    text-align:left;
    font-size: 18px;
    color: lavender;
    display: block;
    cursor: pointer;
    text-align:left;
}

.sidenav a:hover {
    color: grey
}

.content {
    margin-left: 250px;
    padding: 16px;
}
</style>
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