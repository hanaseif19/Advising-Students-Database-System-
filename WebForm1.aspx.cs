using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Check if username is a valid integer
                    if (!int.TryParse(username.Text, out int id))
                    {
                        Response.Write("Invalid username. Please enter a valid integer.");
                        return;
                    }

                    String pass = password.Text;

                    using (SqlCommand loginproc = new SqlCommand("FN_StudentLogin", conn))
                    {
                        loginproc.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        loginproc.Parameters.Add(new SqlParameter("@Student_id", SqlDbType.Int)).Value = id;
                        loginproc.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 40)).Value = pass;

                        // Output parameter
                        SqlParameter success = loginproc.Parameters.Add("@RETURN_VALUE", SqlDbType.Bit);
                        success.Direction = ParameterDirection.ReturnValue;

                        conn.Open();
                        loginproc.ExecuteNonQuery();

                        // Check the return value
                        bool returnValue = (bool)success.Value;  // Use bool instead of int
                        if (returnValue)
                        {
                            Response.Write("HELLO");
                        }
                        else
                        {
                            Response.Write("Login unsuccessful");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred: " + ex.Message);
            }
        }




    }
}