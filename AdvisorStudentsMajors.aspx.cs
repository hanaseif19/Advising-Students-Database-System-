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
    public partial class AdvisorStudentsMajors : System.Web.UI.Page
    {
        private bool CheckIfMajorExists(string major)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand checkIfExists = new SqlCommand("SELECT COUNT(*) FROM Student WHERE major = @major", conn);
            checkIfExists.Parameters.AddWithValue("@major", major);

            conn.Open();
            int count = (int)checkIfExists.ExecuteScalar();
            conn.Close();

            return count > 0;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int? advisorID = Session["AdvisorId"] as int?;
            if (!advisorID.HasValue)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [Obsolete]
        protected void studentsbutton_Click(object sender, EventArgs e)
        {
            int? advisorID = Session["AdvisorId"] as int?;
            if (!advisorID.HasValue)
            {
                Response.Redirect("Login.aspx");
            }
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                string majorr = major.Text;
                //int advisor_id = Int16.Parse(advisorid.Text);



                SqlCommand procviewstudents = new SqlCommand("[Procedures_AdvisorViewAssignedStudents]", conn);
                procviewstudents.CommandType = CommandType.StoredProcedure;
                procviewstudents.Parameters.Add("@major", majorr);
                procviewstudents.Parameters.Add("@AdvisorID", advisorID);
              
                if(majorr.Length== 0 )
                    Response.Write("Please enter a major");
                else if (!CheckIfMajorExists(majorr))
                    Response.Write("You don't have any student in that major. Please add another major. ");

                    conn.Open();
                SqlDataReader reader = procviewstudents.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                resultGridView.DataSource = dt;
                resultGridView.DataBind();

                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

    }
}