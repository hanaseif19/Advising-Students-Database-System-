using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Username_TextChanged(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {
            // Hardcoded admin credentials
            string hardcodedAdminUsername = "admin";
            string hardcodedAdminPassword = "password";

            // Check if entered username matches the hardcoded admin username
            if (string.Equals(Username.Text, hardcodedAdminUsername, StringComparison.OrdinalIgnoreCase))
            {
                // Check if entered password matches the hardcoded admin password
                if (string.Equals(Password.Text, hardcodedAdminPassword))
                {
                    // Valid admin credentials, redirect to the admin dashboard or another page
                    Response.Redirect("~/AdminDashboard.aspx");
                }
                else
                {
                    DisplayErrorMessage("Invalid password. Please try again.");
                }
            }
            else
            {
                DisplayErrorMessage("Invalid username. Please try again.");
            }
            
        }
        private void DisplayErrorMessage(string errorMessage)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", $"alert('{errorMessage}');", true);
        }


    }
}