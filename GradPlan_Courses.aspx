<%@ Page Language="C#" CodeBehind="GradPlan_Courses.aspx.cs" Inherits="Advising_System.GradPlan_Courses" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Title</title>
                            <link rel="stylesheet" type="text/css" href="style1.css"/>

</head>
<body class="y">
    <form id="form1" runat="server">
        <div>
        <asp:Table id="gradTable" runat="server"
                   CellPadding="10" 
                   GridLines="Both"
                   HorizontalAlign="Center">
        </asp:Table>
        </div>
    </form>
</body>
</html>
