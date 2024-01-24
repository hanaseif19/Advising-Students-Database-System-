<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestHours.aspx.cs" Inherits="WebApplication1.RequestHours" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
             <link rel="stylesheet" type="text/css" href="style1.css"/>

</head>
<body class="y">
    <form id="form1" runat="server">
        <div> <label for="creditHSelection">Select the Requested Credit Hours:</label>&nbsp;&nbsp;
     <br /> <br />
                        <asp:DropDownList id="DropDownListHours" runat="server"  InitialValue=""  ErrorMessage="Please Select the Required Credit Hours" Display="Dynamic" ></asp:DropDownList>
<asp:Label ID="LabelSelectedCourse" runat="server" Text=""></asp:Label>
            <div/>
            <br />
            <div>
            Any comments
            <br /><br />
           <asp:TextBox ID="commentCH" runat="server" MaxLength="40"></asp:TextBox>
            </div>
        </div>
        <asp:Label runat="server" ID="requestError" Text=""></asp:Label><br />
       &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Done" runat="server" Text="Request" onclick="sendCHReq"  />
    </form>
</body>
</html>
