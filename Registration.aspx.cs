using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Text.RegularExpressions;

namespace WebApplication2
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [Obsolete]
        protected void AdvisorRegistration(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                string name = advisorName.Text;
                string pass = advisorPass.Text;
                string email = advisorEmail.Text;
                string office = advisorOffice.Text;


                SqlCommand registrationproc = new SqlCommand("Procedures_AdvisorRegistration", conn);
                registrationproc.CommandType = CommandType.StoredProcedure;
                registrationproc.Parameters.Add("@advisor_name", name);
                registrationproc.Parameters.Add("@password", pass);
                registrationproc.Parameters.Add("@email", email);
                registrationproc.Parameters.Add("@office", office);

                SqlParameter id = registrationproc.Parameters.Add("@Advisor_id", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;

                

                    if (name.Length == 0) {
                        Response.Write("Please enter your name ");
                        return;
                    }
                    if (pass.Length == 0)
                    {
                        Response.Write("Please enter your password ");
                        return;
                    }
                    if (email.Length == 0)
                    {
                        Response.Write("Please enter your email ");
                        return;
                    }

                    if (office.Length == 0)
                    {
                        Response.Write("Please enter your office ");
                        return;
                    }
                    
                        
                    if (!(Regex.IsMatch(name, "^[a-zA-Z]+$")))
                    {
                        Response.Write("Please enter a valid name");
                        return;
                    }
                conn.Open();
                registrationproc.ExecuteNonQuery();
                int advisorId = Convert.ToInt32(id.Value);
                Response.Write("Your id is " + advisorId);

                Response.Write("<script>window.setTimeout(function(){ window.location.href = 'login.aspx'; }, 2000);</script>");



                conn.Close();



            }
            catch (Exception ex)
            {
                Response.Write("An error occurred: " + ex.Message);
            }




        }

        protected void Logincllick(object sender, EventArgs e)
        {

        }

        protected void Loginclick(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}