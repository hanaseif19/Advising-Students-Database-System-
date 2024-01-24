using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Xml.Linq;

namespace WebApplication2
{
    public partial class AdvisorPendingRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int? id = Session["AdvisorId"] as int?;
            if (!id.HasValue)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                //int id = Int16.Parse(advisorid.Text);


                SqlCommand procpendingreq = new SqlCommand("Procedures_AdvisorViewPendingRequests", conn);
                procpendingreq.CommandType = CommandType.StoredProcedure;
                procpendingreq.Parameters.Add("@Advisor_ID", id);

                conn.Open();
                SqlDataReader reader = procpendingreq.ExecuteReader();
                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    requestGridView.DataSource = dt;
                    requestGridView.DataBind();
                }
                else
                {
                    // Handle case when there are no rows in the result set
                    Response.Write("There are no pending requests.");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);

            }
        }

    


       
    }
}