using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class linkStudentCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void link3_Click(object sender, EventArgs e)
        {
            string connString = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection connec = new SqlConnection(connString);

            if (string.IsNullOrWhiteSpace(TextBoxCourseID.Text) || string.IsNullOrWhiteSpace(TextBoxInstID.Text)|| string.IsNullOrWhiteSpace(TextBoxStdID.Text)|| string.IsNullOrWhiteSpace(TextBoxSemCode.Text))
            {
                DisplayErrorMessage("All fields are required.");
                return;
            }

            int courseId = Convert.ToInt32(TextBoxCourseID.Text);
            int InstructorId = Convert.ToInt32(TextBoxInstID.Text);
            int StudentId = Convert.ToInt32(TextBoxStdID.Text);
            string semCode = TextBoxSemCode.Text;

            if (!IdExists(connec, "Course", "course_id", courseId))
            {
                DisplayErrorMessage("Invalid Course ID. Please enter a valid Course ID.");
                return;
            }
            if (!IdExists(connec, "Instructor", "instructor_id", InstructorId))
            {
                DisplayErrorMessage("Invalid Instructor ID. Please enter a valid Instructor ID.");
                return;
            }
            if (!IdExists(connec, "Student", "student_id", StudentId))
            {
                DisplayErrorMessage("Invalid Student ID. Please enter a valid Student ID.");
                return;
            }
            if (!SemCodeExists(connec, semCode))
            {
                DisplayErrorMessage("Invalid Semester code. Please enter a valid Semester code.");
                return;
            }


            SqlCommand command = new SqlCommand("Procedures_AdminLinkStudent", connec);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@cours_id", SqlDbType.Int) { Value = courseId });
            command.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.Int) { Value = InstructorId });
            command.Parameters.Add(new SqlParameter("@studentID", SqlDbType.Int) { Value = StudentId });
            command.Parameters.Add(new SqlParameter("@semester_code", SqlDbType.VarChar, 40) { Value = semCode });


            // Open the connection
            connec.Open();

            // Execute the stored procedure
            command.ExecuteNonQuery();
            string successMessage = "link successful";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SuccessAlert", $"alert('{successMessage}');", true);

            connec.Close();
        }
        private void DisplayErrorMessage(string errorMessage)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", $"alert('{errorMessage}');", true);
        }

        private bool IdExists(SqlConnection connection, string tableName, string columnName, int id)
        {
            using (SqlCommand command = new SqlCommand($"SELECT 1 FROM {tableName} WHERE {columnName} = @id", connection))
            {
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                object result = command.ExecuteScalar();

                connection.Close();

                return result != null;
            }
        }
        private bool SemCodeExists(SqlConnection connection, string semCode)
        {
            using (SqlCommand command = new SqlCommand("SELECT 1 FROM Semester WHERE semester_code= @semCode", connection))
            {
                command.Parameters.AddWithValue("@semCode", semCode);

                connection.Open();
                object result = command.ExecuteScalar();
                connection.Close();

                return result != null;
            }
        }
    }
}