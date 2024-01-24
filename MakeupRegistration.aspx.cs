using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class RegisterFirstMakeup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userId"] != null && int.TryParse(Session["userId"].ToString(), out int studentID))
                {
                    LoadMakeupExams();
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            int studentID;
            LoadMakeupExams();
            if (int.TryParse(txtCourseID.Text, out int courseID) &&
              Session["userId"] != null &&
                int.TryParse(Session["userId"].ToString(), out studentID) &&
                !(string.IsNullOrEmpty(txtCurrentSemester.Text)))
            {
                if (rbFirstMakeup.Checked)
                {
                    Procedures_StudentRegisterFirstMakeup(studentID, courseID, txtCurrentSemester.Text);
                }

                else if (rbSecondMakeup.Checked)
                {
                    Procedures_StudentRegisterSecondMakeup(studentID, courseID, txtCurrentSemester.Text);
                }
                else
                {
                    message.Text = "Please select a makeup option";
                }

            }
            else
            {

                //Response.Write(int.TryParse(txtCourseID.Text, out bla));
                //Response.Write(Session["StudentID"]);
                //Response.Write(!string.IsNullOrEmpty(txtCurrentSemester.Text));
                message.Text = "Please enter valid values for Student ID, Course ID, and Current Semester.";
            }
        }

        private void Procedures_StudentRegisterFirstMakeup(int studentID, int courseID, string studentCurrSem)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
                if (!HasStudentTakenMakeupExam(connStr, studentID, courseID) && FailedNormalExam(studentID, courseID))
                {
                    using (SqlConnection conn = new SqlConnection(connStr))
                    using (SqlCommand cmd = new SqlCommand("Procedures_StudentRegisterFirstMakeup", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StudentID", studentID);
                        cmd.Parameters.AddWithValue("@courseID", courseID);
                        cmd.Parameters.AddWithValue("@studentCurr_sem", studentCurrSem);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message.Text = ("First Makeup registration is successful");
                        }
                        else
                        {

                            message.Text = ("First Makeup registration is unsuccessful");
                        }
                    }
                }
                else
                {

                    message.Text = ("First Makeup registration is unsuccessful");
                }
            }
            catch (Exception ex)
            {
                message.Text = ($"Error executing stored procedure: {ex.Message}");
            }
        }

        private bool HasStudentTakenMakeupExam(string connectionString, int studentID, int courseID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "SELECT COUNT(*) FROM Exam_Student WHERE student_id = @StudentID AND course_id = @CourseID";
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                cmd.Parameters.AddWithValue("@CourseID", courseID);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                // If count is greater than 0 then the student has taken a makeup exam
                //Response.Write(count.ToString());
                return count > 0;
            }
        }

        private DataTable GetFailedNormalExams(int studentID, int courseID, string semesterCode)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Student_Instructor_Course_take WHERE student_id = @StudentID AND course_id = @CourseID AND exam_type = 'Normal' AND (grade = 'F' or grade ='FF') AND semester_code = @SemesterCode", conn))
            {
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                cmd.Parameters.AddWithValue("@CourseID", courseID);
                cmd.Parameters.AddWithValue("@SemesterCode", semesterCode);
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable resultTable = new DataTable();
                    adapter.Fill(resultTable);
                    return resultTable;
                }
            }
        }
        private void LoadMakeupExams()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            string sqlQuery = "SELECT * FROM Makeup_Exam";
            DataTable resultTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection))
            {
                connection.Open();
                adapter.Fill(resultTable);
            }
            MakeupExamsTable(resultTable);
        }

        private void MakeupExamsTable(DataTable resultTable)
        {
            makeupexams.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333");
            makeupexams.CellPadding = 4;
            makeupexams.HorizontalAlign = HorizontalAlign.Center;
            makeupexams.CssClass = "auto-style3";
            makeupexams.Rows.Add(CreateHeaderRow(resultTable));
            foreach (DataRow row in resultTable.Rows)
            {
                makeupexams.Rows.Add(CreateRow(row, resultTable.Columns));
            }
        }
        private TableRow CreateRow(DataRow dataRow, DataColumnCollection columns)
        {
            TableRow row = new TableRow { BackColor = System.Drawing.ColorTranslator.FromHtml("#D5D8DC") };
            foreach (DataColumn column in columns)
            {
                TableCell cell = new TableCell { Text = dataRow[column].ToString() };
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
        private bool FailedNormalExam(int studentID, int courseID)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();

                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT COUNT(*) FROM Student_Instructor_Course_take WHERE student_id = @StudentID AND course_id = @CourseID AND exam_type = 'Normal' AND (grade = 'F' or grade ='FF')";
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@CourseID", courseID);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    //Response.Write(count.ToString() + "2");
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking if the student failed the course: {ex.Message}");
                return false;
            }
        }
        private void Procedures_StudentRegisterSecondMakeup(int studentID, int courseID, string studentCurrSem)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            if (IsStudentEligibleForSecondMakeup(connStr, studentID, courseID))
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("Procedures_StudentRegisterSecondMakeup", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@courseID", courseID);
                    cmd.Parameters.AddWithValue("@studentCurr_sem", studentCurrSem);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        message.Text = "Registration for the second makeup exam is successful";
                    }
                    else
                    {
                        message.Text = "Registration for the second makeup exam is unsuccessful";
                    }
                }
            }
            else
            {
                message.Text = "Registration for the second makeup exam is unsuccessful";
            }
        }

        private bool IsStudentEligibleForSecondMakeup(string connectionString, int studentID, int courseID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "SELECT dbo.FN_StudentCheckSMEligibility(@CourseID, @StudentID)";
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                cmd.Parameters.AddWithValue("@CourseID", courseID);
                conn.Open();
                return (bool)cmd.ExecuteScalar();
            }
        }

    }
}

