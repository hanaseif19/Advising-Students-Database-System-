using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace WebApplication2
{
    public partial class AdvisorDeleteCourse : System.Web.UI.Page
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
        protected void deleteButton_Click(object sender, EventArgs e)
        {
            int? advisorID = Session["AdvisorId"] as int?;
            if (!advisorID.HasValue)
            {
                Response.Redirect("Login.aspx");
            }
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            
                string scode = semcode.Text;
                int courseid;
                int studentID;
            
                if (!int.TryParse(sid.Text, out studentID) || !StudentExists(advisorID.Value, studentID))
                {
                    Response.Write("Please enter a valid student ID.");
                    return;
                }
                if (studentID.ToString().Length == 0)
                {
                    Response.Write("Please enter the student ID.");
                    return;
                }

                string semesterCodePattern = @"^(W\d{2}|S\d{2}|S\d{2}R[12])$";
                
                if (scode.Length == 0)
                {
                    Response.Write("Please enter the semester code.");
                    return;
                }
                if (!Regex.IsMatch(scode, semesterCodePattern))
                {
                    Response.Write("Please enter a valid semester");
                    return;
                }
               

                if (!int.TryParse(cid.Text, out courseid) ||  !CourseExists( courseid, scode))
                {
                    Response.Write("Please enter a valid course");
                    return;
                }
            if (!CourseSemExists(courseid, scode))
            {
                Response.Write("Invalid course semester combination");
                return;
            }
            if (courseid.ToString().Length == 0)
            {
                Response.Write("Please enter the course ID.");
                return;
            }



            SqlCommand procdeletecourse = new SqlCommand("Procedures_AdvisorDeleteFromGP", conn);
            procdeletecourse.CommandType = CommandType.StoredProcedure;
            procdeletecourse.Parameters.Add("@sem_code", scode);
            procdeletecourse.Parameters.Add("@courseID", courseid);
            procdeletecourse.Parameters.Add("@studentID", studentID);

                
                conn.Open();
            procdeletecourse.ExecuteNonQuery();
                Response.Write("Success");
                conn.Close();
           
        }
        private bool StudentExists(int advisorId, int studentId)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand checkIfExists = new SqlCommand("SELECT COUNT(*) FROM Graduation_Plan WHERE advisor_id = @advisorId AND student_id = @studentId", conn);
            checkIfExists.Parameters.AddWithValue("@advisorId", advisorId);
            checkIfExists.Parameters.AddWithValue("@studentId", studentId);

            conn.Open();
            int count = (int)checkIfExists.ExecuteScalar();
            conn.Close();

            return count > 0;
        }

        private bool CourseExists(int courseid, string semcode)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand existtest = new SqlCommand("SELECT COUNT(*) FROM Course WHERE course_id = @courseID ", conn);
            existtest.Parameters.AddWithValue("@courseID", courseid);

            conn.Open();
            int count = (int)existtest.ExecuteScalar();

            conn.Close();

            return count > 0;
            conn.Close();

        }

        private bool CourseSemExists(int courseid, string semcode)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand existtest = new SqlCommand("SELECT COUNT(*) FROM GradPlan_Course WHERE course_id = @courseID AND semester_code =@semCode ", conn);
            existtest.Parameters.AddWithValue("@courseID", courseid);
            existtest.Parameters.AddWithValue("@semCode", semcode);
            

            conn.Open();
            int count = (int)existtest.ExecuteScalar();

            conn.Close();

            return count > 0;
            conn.Close();

        }
    }
}