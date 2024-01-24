<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateStatus.aspx.cs" Inherits="WebApplication2.UpdateStatus" %>
<%@ Register Src="~/part2.ascx"TagName="MyBar2" TagPrefix="bar2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
                       <link rel="stylesheet" type="text/css" href="style1.css"/> 

    <style>
        body {
            text-align: center;
        }

        #form1 {
            display: inline-block;
            text-align: left;
        }
    </style>
</head>
<body class="y">
    <form id="form1" runat="server" >
        <div>
                         <bar2:MyBar2 runat="server" />

                        <asp:GridView ID="GridViewStudents" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewStudent_RowCommand" DataKeyNames="student_id">
    <Columns>
        <asp:BoundField DataField="student_id" HeaderText="Student ID" />
        <asp:BoundField DataField="f_name" HeaderText="First Name"  />
        <asp:BoundField DataField="l_name" HeaderText="Last Name"  />
        <asp:BoundField DataField="financial_status" HeaderText="Financial Status"  />
        <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <asp:Button ID="btnUpdate" CssClass="buttonsmall" runat="server" Text="Update Status" CommandName="UpdateStatus" CommandArgument='<%# Container.DataItemIndex %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
        </div>
                   <div>&nbsp;</div>
            <div>&nbsp;</div>
            <asp:Label ID="usermsg" runat="server" ></asp:Label>
             <div>&nbsp;</div>
 <div>&nbsp;</div>
        <div>
    <asp:Button ID="Back" CssClass="buttonsmall buttonBack" runat="server" Text="Back" OnClick="getback" />
</div>
    </form>
</body>
</html>
