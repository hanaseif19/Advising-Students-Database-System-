<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="WebApplication2.WebUserControl1" %>



<style>
   .button-container {
    position: absolute;
    top: 0;
    right: 0;
    /*background-color: #7851a9;*/
    color: #ffffff;
    padding: 10px 20px;
    /*border: none;*/
    cursor: pointer;
    width: 90px;
    height: 40px;
    font-size: 15px;
    border-radius: 5px; 
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1); 
    transition: background-color 0.3s; 
    text-align:center;
    align-items: center;
      justify-content: center;
       border: 2px solid #6930c3; 
    border-radius: 5px;
    background-color: #6a0572; 
     font-weight: bold;

}

.button-container:hover {
    background-color: #64418b; 
}

.buttonBack{
      position: absolute;
            bottom: 0;
            left: 202px;
}



    
</style>

<asp:Button ID="LogOut" runat="server" Text="Logout" OnClick="LogOutClick" CssClass="button-container" />
