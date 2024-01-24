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
    public partial class UpdateGradDate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int? advisorID = Session["AdvisorId"] as int?;
            if (!advisorID.HasValue)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [Obsolete]
        protected void update_Click(object sender, EventArgs e)
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


                int studentID;
                if (!int.TryParse(sid.Text, out studentID) || !StudentExists(advisorID.Value, studentID))
                {
                    Response.Write("Please enter a valid student ID.");
                    return;
                }
                DateTime graduationDate;

                if (!DateTime.TryParse(graddate.Text, out graduationDate))
                {
                    Response.Write("Please enter a valid graduation date.");
                    return;
                }

                SqlCommand procupdategp = new SqlCommand("Procedures_AdvisorUpdateGP", conn);
                procupdategp.CommandType = CommandType.StoredProcedure;
                procupdategp.Parameters.Add("@expected_grad_date", graduationDate);
                procupdategp.Parameters.Add("@studentid", studentID);


                conn.Open();
                procupdategp.ExecuteNonQuery();
                Response.Write("Success");
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        private bool StudentExists(int advisorId, int studentId)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand checkIfExists = new SqlCommand("SELECT COUNT(*) FROM Student WHERE advisor_id = @advisorId AND student_id = @studentId", conn);
            checkIfExists.Parameters.AddWithValue("@advisorId", advisorId);
            checkIfExists.Parameters.AddWithValue("@studentId", studentId);

            conn.Open();
            int count = (int)checkIfExists.ExecuteScalar();
            conn.Close();

            return count > 0;
        }
    }
}