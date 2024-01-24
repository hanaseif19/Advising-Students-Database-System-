using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class AdivsorAllStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int? id = Session["AdvisorId"] as int?;
            if ( !id.HasValue)
            {
                Response.Redirect("Login.aspx");
            }
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                //int id = Int16.Parse(advisorid.Text);


                SqlCommand allstudents = new SqlCommand("SELECT * FROM Student WHERE advisor_id = @advisor_id", conn);
                allstudents.Parameters.Add(new SqlParameter("@advisor_id", SqlDbType.Int)).Value = id;
                conn.Open();
                SqlDataReader reader = allstudents.ExecuteReader();
                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    studentGridView.DataSource = dt;
                    studentGridView.DataBind();
                }
                else
                {
                    Response.Write("No data found.");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);

            }
        }

    //    protected void getstudents_Click(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            string connStr = WebConfigurationManager.ConnectionStrings["AdvisingSystem"].ToString();
    //            SqlConnection conn = new SqlConnection(connStr);

    //            int id = Int16.Parse(advisorid.Text);


    //            SqlCommand allstudents = new SqlCommand("SELECT * FROM view_Students WHERE advisor_id = @advisor_id", conn);
    //            allstudents.Parameters.Add(new SqlParameter("@advisor_id", SqlDbType.Int)).Value = id;
    //            conn.Open();
    //            SqlDataReader reader = allstudents.ExecuteReader();
    //            if (reader.HasRows)
    //            {
    //                DataTable dt = new DataTable();
    //                dt.Load(reader);

    //                studentGridView.DataSource = dt;
    //                studentGridView.DataBind();
    //            }
    //            else
    //            {
    //                Response.Write("No data found.");
    //            }

    //            conn.Close();
    //        }
    //        catch (Exception ex)
    //        {
    //            Response.Write("Error: " + ex.Message);

    //        }
    //    }
    }
}