<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="part2.ascx.cs" Inherits="WebApplication2.WebUserControl3" %>
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
    width: 200px;
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
    font-size: 15px;
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
            <asp:LinkButton ID="LinkButton1" runat="server" Text="Delete Course" OnClick="clickbutt1"  />
            <asp:LinkButton ID="LinkButton2" runat="server" Text="Delete a slot of a course not currently offered" OnClick="clickbutt2" />
            <asp:LinkButton ID="LinkButton3" runat="server" Text="Add Makeup Exam" OnClick="clickbutt3" />
            <asp:LinkButton ID="LinkButton4" runat="server" Text="View Payment Details" OnClick="clickbutt4" />
            <asp:LinkButton ID="LinkButton5" runat="server" Text="Issue Installments" OnClick="clickbutt5" />
            <asp:LinkButton ID="LinkButton6" runat="server" Text="Update Student Financial Status" OnClick="clickbutt6" />
            <asp:LinkButton ID="LinkButton7" runat="server" Text="View All Active Students" OnClick="clickbutt7" />
            <asp:LinkButton ID="LinkButton8" runat="server" Text="View All Grad Plans" OnClick="clickbutt8" />
            <asp:LinkButton ID="LinkButton9" runat="server" Text="View all Student Transcript Details" OnClick="clickbutt9" />
            <asp:LinkButton ID="LinkButton10" runat="server" Text="View Semester & Offered Courses" OnClick="clickbutt10" />
            <asp:LinkButton ID="LinkButton11" runat="server" Text="Back" OnClick="clickbutt11" />
        </div>
</div>