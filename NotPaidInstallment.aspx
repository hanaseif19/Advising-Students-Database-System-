<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NotPaidInstallment.aspx.cs" Inherits="Advising_System.NotPaidInstallment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Title</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            text-align: center;
            margin-top: 50px; /* Adjust the margin based on your design preference */
        }

        #message {
            font-size: 18px;
            font-weight: bold;
            color: #1C5E55;
            margin-top: 20px; /* Adjust the margin based on your design preference */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Display the message directly in the HTML -->
            <div id="message" runat="server"></div>
        </div>
    </form>
</body>
</html>
