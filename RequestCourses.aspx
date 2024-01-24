<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestCourses.aspx.cs" Inherits="WebApplication1.RequestCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
             <link rel="stylesheet" type="text/css" href="style1.css"/>

</head>
<body class="y">
    <form id="form1" runat="server">
        <br /><br /><br />
        <label for="DropDownListSemesters">Select a Semester</label>
<asp:DropDownList ID="DropDownListSemesters" runat="server" OnSelectedIndexChanged="showCourses" AutoPostBack="True"></asp:DropDownList>
<asp:Label ID="errorMessage" runat="server" Text=""></asp:Label>

        <div>&nbsp;&nbsp;<label for="creditHSelection">Select the Requested Course:</label>&nbsp;&nbsp;
            <asp:DropDownList id="DropDownListCourses" runat="server"  InitialValue=""  ErrorMessage="Please select a course" Display="Dynamic" ></asp:DropDownList>
<asp:Label ID="LabelSelectedCourse" runat="server" Text=""></asp:Label>
        </div>
        <br />
           <div>
           &nbsp;&nbsp;Any comments:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:TextBox ID="commentOnreq" runat="server"  maxlength="40"></asp:TextBox>
           
           </div>
        <div><br />
            <asp:Label runat="server" ID="requestError" Text=""></asp:Label><br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Done" runat="server" Text="Request" onClick="sendRequest" />
            </div>
    </form>
</body>
</html>
