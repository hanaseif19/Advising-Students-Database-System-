<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakeupRegistration.aspx.cs" Inherits="WebApplication1.RegisterFirstMakeup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
    body {
        font-family: Arial, sans-serif;
        text-align: center;
        margin-top: 50px; /* Adjust the margin based on your design preference */
    }

    #formContainer {
        width: 500px; 
        margin: 0 auto; 
    }

    #formContainer input,
    #formContainer label,
    #formContainer button {
        display: block;
        margin-bottom: 5px;
        width: 100%; 
    }

    #message {
        font-size: 18px;
        font-weight: bold;
        color: #1C5E55;
        margin-top: 10px; 
    }
</style>

</head>
<body>
    <form id="form1" runat="server">
        <div id="formContainer">
            <h2>Courses and Makeup Exams:</h2>
            <asp:Table ID="makeupexams" runat="server"
                 CellPadding="10"
                 GridLines="Both"
                 HorizontalAlign="Left">
            </asp:Table>
            <asp:Label runat="server" Text="Enter Course ID"></asp:Label>
            <asp:TextBox ID="txtCourseID" runat="server" placeholder="Course ID"></asp:TextBox>
            <asp:Label runat="server" Text="Enter Student's Current Semester"></asp:Label>
            <asp:TextBox ID="txtCurrentSemester" runat="server" placeholder="Current Semester"></asp:TextBox>
            <asp:RadioButton ID="rbFirstMakeup" runat="server" Text="First Makeup" GroupName="MakeupOptions" />
            <asp:RadioButton ID="rbSecondMakeup" runat="server" Text="Second Makeup" GroupName="MakeupOptions" />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            <asp:Label ID="message" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
