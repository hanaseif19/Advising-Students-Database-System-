using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;

namespace WebApplication2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int id;
                String pass = password.Text;


                if (!int.TryParse(username.Text, out id))
                {
                    Response.Write("Please enter a valid id.");
                    return;
                }
                if (id.ToString().Length == 0) { 
                    Response.Write("Please enter your id ");
                    return;
                }
                if (pass.Length == 0) {
                    Response.Write("Please enter your password ");
                    return; 
                }
                

                SqlCommand loginproc = new SqlCommand("SELECT dbo.FN_AdvisorLogin(@advisor_Id, @password)", conn);
                loginproc.Parameters.Add(new SqlParameter("@advisor_Id", SqlDbType.Int)).Value = id;
                loginproc.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 40)).Value = pass;
                conn.Open();
               
                bool success = (bool)loginproc.ExecuteScalar();
                 
                conn.Close();
                bool advisorExists = CheckIfAdvisorExists(id);
                if (Convert.ToBoolean(success) && id.ToString().Length != 0 && pass.Length != 0)
                {
                    Response.Write("Hello");
                    Session["AdvisorId"] = id;
                    Response.Redirect("AdvisorMainPage.aspx");
                }
                else
                {
                    if (id.ToString().Length == 0)
                        Response.Write("Please enter your id ");
                    if (pass.Length == 0)
                        Response.Write("Please enter your password ");

                    if (advisorExists)
                    {
                        if (pass.Length != 0)
                            Response.Write("Incorrect password");
                    }
                    else
                    {
                        Response.Write("There is no such account");
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write("An error occurred: " + ex.Message);
            }




        }
        private bool CheckIfAdvisorExists(int advisorId)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand checkIfExists = new SqlCommand("SELECT COUNT(*) FROM Advisor WHERE advisor_id = @advisorId", conn);
            checkIfExists.Parameters.AddWithValue("@advisorId", advisorId);

            conn.Open();
            int count = (int)checkIfExists.ExecuteScalar();
            conn.Close();

            return count > 0;
        }
    }
}