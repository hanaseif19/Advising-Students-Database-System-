<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deleteSlots.aspx.cs" Inherits="WebApplication2.deleteSlots" %>
<%@ Register Src="~/part2.ascx"TagName="MyBar2" TagPrefix="bar2" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Slots </title>
                        <link rel="stylesheet" type="text/css" href="style1.css"/>
</head>
<body class="y">
    <form id="form1" runat="server" >
                       <bar2:MyBar2 runat="server"/>     

        <header>
            <h1>Delete Slots </h1>
        </header>

        <main>
            
            <div>

                <label for="ddlSemesters">Select Semester:</label>
                <asp:DropDownList ID="ddlSemesters" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                    <asp:ListItem Text="Select Semester" Value="" />
                </asp:DropDownList>

            </div>

            <div>
                <div>&nbsp;</div>
                <div>&nbsp;</div>
                <asp:Button ID="btnDeleteSlots" CssClass="button" runat="server" Text="Delete Slots" OnClick="deleteslotclick" />
            </div>

            <div>
                <div>&nbsp;</div>
                <div>&nbsp;</div>
                <asp:Label ID="usermsg" runat="server" ></asp:Label>
            </div>
        </main>
        <div>
    <asp:Button ID="Back" CssClass="buttonsmall buttonBack" runat="server" Text="Back" OnClick="getback" />
</div>
    </form>
</body>
</html>
