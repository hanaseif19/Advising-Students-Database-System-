using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace WebApplication2
{
    public partial class AddCoursesGradPlan : System.Web.UI.Page
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
        protected void addcoursebutton_Click(object sender, EventArgs e)
        {
            int? advisorID = Session["AdvisorId"] as int?;
            if (!advisorID.HasValue)
            {
                Response.Redirect("Login.aspx");
            }
           
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                string scode = semestercode.Text;

                string course_name = coursename.Text; 


                int studentID;
                if (!int.TryParse(studentid.Text, out studentID) || !StudentExists(advisorID.Value, studentID))
                {
                    Response.Write("Please enter a valid student ID.");
                    return;
                }
                string semesterCodePattern = @"^(W\d{2}|S\d{2}|S\d{2}R[12])$";

                if (!Regex.IsMatch(scode, semesterCodePattern))
                {
                    Response.Write("Please enter a valid semester");
                    return;
                }
                if(course_name.Length ==0 ){
                    Response.Write("Please enter a course.");
                    return;
                }
                if(!CourseExists(course_name, scode))
                {
                    Response.Write("The course you entered doesn't exist.");
                    return;
                }
                if (!CourseLinkedToSem( course_name,  scode))
                {
                    Response.Write("The course you entered isn't offered in this semester.");
                    return;
                }
                SqlCommand procaddcourses = new SqlCommand("Procedures_AdvisorAddCourseGP", conn);
                procaddcourses.CommandType = CommandType.StoredProcedure;
                //procaddcourses.Parameters.Add("@Semester_code", scode);
                //procaddcourses.Parameters.Add("@course_name", course_name);
                //procaddcourses.Parameters.Add("@student_id", studentid);
                procaddcourses.Parameters.Add("@Semester_code", SqlDbType.VarChar).Value = semestercode.Text;
                procaddcourses.Parameters.Add("@course_name", SqlDbType.VarChar).Value = coursename.Text;
                procaddcourses.Parameters.Add("@student_id", SqlDbType.Int).Value = studentID;

                conn.Open();
                procaddcourses.ExecuteNonQuery();
                Response.Write("Success");

                conn.Close();
            }
            catch (SqlException ex)
            {
                if(ex.Number == 2627)
                    Response.Write("This graduation plan already exists");
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

            SqlCommand checkIfExists = new SqlCommand("SELECT COUNT(*) FROM Graduation_Plan WHERE advisor_id = @advisorId AND student_id = @studentId", conn);
            checkIfExists.Parameters.AddWithValue("@advisorId", advisorId);
            checkIfExists.Parameters.AddWithValue("@studentId", studentId);

            conn.Open();
            int count = (int)checkIfExists.ExecuteScalar();
            conn.Close();

            return count > 0;
        }
        private bool CourseExists(string course_name, string semcode)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand existtest = new SqlCommand("SELECT COUNT(*) FROM Course WHERE name = @course_name", conn);
            existtest.Parameters.AddWithValue("@course_name", course_name);
      

            SqlCommand getCourseId = new SqlCommand("SELECT course_id FROM Course WHERE name = @course_name", conn);
            getCourseId.Parameters.AddWithValue("@course_name", course_name);

           


            conn.Open();
            int count = (int)existtest.ExecuteScalar();
            //int courseid = Convert.ToInt32(getCourseId.ExecuteScalar());

            //if (string.IsNullOrEmpty(courseid.ToString()))
            //{
            //    return false;
            //}
            //SqlCommand checkSemCourse = new SqlCommand("SELECT count(*) FROM Course_Semester WHERE course_id = @courseID AND semester_code = @semcode", conn);
            //checkSemCourse.Parameters.AddWithValue("@semcode", semcode);
            //checkSemCourse.Parameters.AddWithValue("@courseID", courseid);
            //int count2 = (int)checkSemCourse.ExecuteScalar();

            conn.Close();

            return count > 0;
            conn.Close();

        }

        private bool CourseLinkedToSem(string course_name, string semcode)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand getCourseId = new SqlCommand("SELECT course_id FROM Course WHERE name = @course_name", conn);
            getCourseId.Parameters.AddWithValue("@course_name", course_name);

            conn.Open();
            int courseid = Convert.ToInt32(getCourseId.ExecuteScalar());

            if (string.IsNullOrEmpty(courseid.ToString()))
            {
                return false;
            }
            SqlCommand checkSemCourse = new SqlCommand("SELECT count(*) FROM Course_Semester WHERE course_id = @courseID AND semester_code = @semcode", conn);
            checkSemCourse.Parameters.AddWithValue("@semcode", semcode);
            checkSemCourse.Parameters.AddWithValue("@courseID", courseid);
            int count2 = (int)checkSemCourse.ExecuteScalar();

            conn.Close();

            return count2 > 0;
            conn.Close();

        }



    }

}