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
   
    public partial class FetchStdDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();


                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();


                    string quest = " SELECT * FROM view_Students ";
                    using (SqlCommand cmd = new SqlCommand(quest, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            GridViewStudent.DataSource = reader;
                            GridViewStudent.DataBind();
                        }
                    }

                    conn.Close();
                }
            }
        
        
        protected void getback(object sender, EventArgs e)
        {
            Response.Redirect("Button_Options.aspx");
        }
    }
}