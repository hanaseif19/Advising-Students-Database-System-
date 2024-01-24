using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class ChooseInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userId"] != null && int.TryParse(Session["userId"].ToString(), out int studentID))
                {
                    LoadInstructorsAssignedCoursesTable();
                    LoadCourses();
                }
                else
                {
                   Response.Redirect("LoginStudent.aspx");
                }
            }
        }

        private void LoadInstructorsAssignedCoursesTable()
        {
                string connectionString = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
                string sqlQuery = "SELECT * FROM Instructors_AssignedCourses";
                DataTable resultTable = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection))
                {
                    connection.Open();
                    adapter.Fill(resultTable);
                }
                TableCourseIns(resultTable);
        }
        private void LoadCourses()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            string sqlQuery = "SELECT SIC.course_id, C.name from Student_Instructor_course_take SIC INNER JOIN Course C ON C.course_id = SIC.course_id AND SIC.instructor_id IS NULL";
            DataTable resultTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection))
            {
                connection.Open();
                adapter.Fill(resultTable);
            }
            CourseTable(resultTable);
        }
        private void TableCourseIns(DataTable resultTable)
        {
            courseins.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333");
            courseins.CellPadding = 4;
            courseins.HorizontalAlign = HorizontalAlign.Center;
            courseins.CssClass = "auto-style3";
            courseins.Rows.Add(CreateHeaderRow(resultTable));
            foreach (DataRow row in resultTable.Rows)
            {
                courseins.Rows.Add(CreateRow(row, resultTable.Columns));
            }
        }
        private void CourseTable(DataTable resultTable)
        {
            coursetable.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333");
            coursetable.CellPadding = 4;
            coursetable.HorizontalAlign = HorizontalAlign.Center;
            coursetable.CssClass = "auto-style3";
            coursetable.Rows.Add(CreateHeaderRow(resultTable));
            foreach (DataRow row in resultTable.Rows)
            {
                coursetable.Rows.Add(CreateRow(row, resultTable.Columns));
            }
        }

        private TableRow CreateRow(DataRow dataRow, DataColumnCollection columns)
        {
            TableRow row = new TableRow { BackColor = System.Drawing.ColorTranslator.FromHtml("#D5D8DC") };
            foreach (DataColumn column in columns)
            {
                TableCell cell = new TableCell { Text = dataRow[column].ToString()};
                row.Cells.Add(cell);
            }
            return row;
        }
        private TableHeaderRow CreateHeaderRow(DataTable resultTable)
        {
            TableHeaderRow row = new TableHeaderRow() { BackColor = System.Drawing.ColorTranslator.FromHtml("#566573"), ForeColor = System.Drawing.Color.White };
            foreach (DataColumn column in resultTable.Columns)
            {
                TableHeaderCell cell = new TableHeaderCell { Text = column.ColumnName };
                row.Cells.Add(cell);
            }
            return row;
        }


        protected void btnChooseInstructor_Click(object sender, EventArgs e)
        {
            int selectedInstructorID, selectedCourseID, studentID;
            string currentSemester;

            if (int.TryParse(txtInstructorID.Text, out selectedInstructorID) &&
                int.TryParse(txtCourseID.Text, out selectedCourseID) &&
                Session["userId"] != null &&
                int.TryParse(Session["userId"].ToString(), out studentID))
            {
                currentSemester = txtCurrentSemester.Text;
                if (!ValidCourseIns(connectionString, selectedInstructorID, selectedCourseID)||
                    !(int.TryParse(txtInstructorID.Text, out selectedInstructorID)) ||
                    !(int.TryParse(txtCourseID.Text, out selectedCourseID)))
                {
                    LoadInstructorsAssignedCoursesTable();
                    message.Text = "Instructor is not associated with the selected course.";
                    return;
                }
                ChooseInstructorForCourse(studentID, selectedInstructorID, selectedCourseID, currentSemester);
                LoadInstructorsAssignedCoursesTable();
                LoadCourses();
            }
            else
            {
                LoadInstructorsAssignedCoursesTable();
                LoadCourses();
                message.Text = "Invalid input. Please enter valid numbers for Instructor ID, Course ID, and Student ID.";
            }
        }

        private string connectionString = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();

        private void ChooseInstructorForCourse(int studentID, int selectedInstructorID, int selectedCourseID, string currentSemester)
        {

                string connectionString = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("Procedures_Chooseinstructor", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@instrucorID", selectedInstructorID);
                    cmd.Parameters.AddWithValue("@CourseID", selectedCourseID);
                    cmd.Parameters.AddWithValue("@current_semester_code", currentSemester);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        message.Text = "Instructor chosen successfully.";
                    }
                    else
                    {
                        message.Text = "Error choosing instructor.";
                    }
                }
        }
        private bool ValidCourseIns(string connectionString, int instructorID, int courseID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "SELECT COUNT(*) FROM Instructor_Course WHERE instructor_id = @instructorID AND course_id = @courseID";
                cmd.Parameters.AddWithValue("@instructorID", instructorID);
                cmd.Parameters.AddWithValue("@courseID", courseID);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

    }
}