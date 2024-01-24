<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FetchStdDetails.aspx.cs" Inherits="WebApplication2.FetchStdDetails" %>
<%@ Register Src="~/WebUserControl1.ascx"TagName="MyButton" TagPrefix="uc" %>
<%@ Register Src="~/part2.ascx"TagName="MyBar2" TagPrefix="bar2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    


   <link rel="stylesheet" type="text/css" href="style1.css" /> 

</head>
<body class="y">
    <form id="form1" runat="server">
          
                            <bar2:MyBar2 runat="server"/>
<br />
              <asp:GridView ID="GridViewStudent"  runat="server" AutoGenerateColumns="False" CssClass="gridview" style="width: 30%;overflow-y: auto; margin-left: 250px;">
 
                  
    <Columns>
        <asp:BoundField DataField="student_id" HeaderText="Student ID" />
        <asp:BoundField DataField="f_name" HeaderText="First Name" />
        <asp:BoundField DataField="l_name" HeaderText="Last Name" />
        <asp:BoundField DataField="password" HeaderText="Password" />
        <asp:BoundField DataField="gpa" HeaderText="GPA" />
        <asp:BoundField DataField="faculty" HeaderText="Faculty" />
        <asp:BoundField DataField="email" HeaderText="Email" />
        <asp:BoundField DataField="major" HeaderText="Major" />
        <asp:BoundField DataField="financial_status" HeaderText="Financial Status" />
        <asp:BoundField DataField="semester" HeaderText="Sem" />
        <asp:BoundField DataField="acquired_hours" HeaderText="Acquired Hours" />
        <asp:BoundField DataField="assigned_hours" HeaderText="Assigned Hours" />
        <asp:BoundField DataField="advisor_id" HeaderText="Advisor ID" />
    </Columns>
</asp:GridView>

       

     <div>&nbsp;</div>
     <div>&nbsp;</div>
     <div>&nbsp;</div>
     <div>&nbsp;</div>
  <div>
      <asp:Button ID="Back" CssClass="buttonsmall buttonBack" runat="server" Text="Back" OnClick="getback" />
  </div>
    </form>
</body>
</html>
