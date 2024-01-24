<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoursesPrerequisites.aspx.cs" Inherits="WebApplication1.CoursesPrerequisites" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" type="text/css" href="style1.css"/> 

</head>
<body class="y">
    <form id="form1" runat="server">
         <div>
             <asp:Table id="coursepreq" runat="server"
             CellPadding="10" 
             GridLines="Both"
             HorizontalAlign="Center">
             </asp:Table>
  </div>
    </form>
</body>
</html>
