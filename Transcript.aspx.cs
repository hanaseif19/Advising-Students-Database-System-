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
    public partial class Transcript : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand mycmd = new SqlCommand("SELECT * from Students_Courses_transcript", conn);
            conn.Open();
            SqlDataReader reader = mycmd.ExecuteReader();
            ViewPayment.FillTable(transcript, reader,columnNames);
            conn.Close();
        }

        private static string[] columnNames =
      {
             "StudentID",
    "FirstName",
    "LastName",
    "CourseID",
    "CourseName",
    "ExamType",
    "Grade",
    "SemesterCode"
        };
        protected void getback(object sender, EventArgs e)
        {
            Response.Redirect("Button_Options.aspx");
        }
    }
}