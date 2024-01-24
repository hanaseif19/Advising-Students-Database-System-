<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addSemester.aspx.cs" Inherits="WebApplication2.addSemester" %>
<%@ Register Src="~/WebUserControl2.ascx"TagName="MyBar" TagPrefix="bar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
                    <link rel="stylesheet" type="text/css" href="style1.css"/>

</head>
<body class="y">
    <form id="form1" runat="server">
                <header>
    <h1>Add a new semester </h1>
</header>
         <bar:MyBar runat="server"/>
        <div>
                         

            <br />
            <br />
            Semester Code:<br />
            <asp:TextBox ID="semCode" runat="server"></asp:TextBox>
            
            <br />
            Semester Start Date:<br />
            <asp:TextBox ID="start" runat="server"></asp:TextBox>
            
            <br />
            Semester End Date:<br />
            <asp:TextBox ID="end" runat="server"></asp:TextBox>
            
            <br />
            
            <br />
            <asp:Button Cssclass="button" ID="AddSem" runat="server" Text="add semester" OnClick="AddSem_Click" />
        </div>
    </form>
</body>
</html>
