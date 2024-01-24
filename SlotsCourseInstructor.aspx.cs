using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SlotsCourseInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null)
            {
                Response.Redirect("LoginStudent.aspx");
            }
        }
        protected void btnViewSlots_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCourseID.Text, out int courseID) && int.TryParse(txtInstructorID.Text, out int instructorID))
            {
                DataTable resultTable = GetStudentViewSlots(courseID, instructorID);

                if (resultTable.Rows.Count > 0)
                {
                    DisplayResultInTable(resultTable);
                    lblMessage.Visible = false;
                }
                else
                {
                    lblMessage.Text = "Invalid Course ID and Instructor ID";
                    lblMessage.Visible = true;
                }
            }
            else
            {
                Response.Write("Invalid course ID or instructor ID.");
            }
        }
        private DataTable GetStudentViewSlots(int courseID, int instructorID)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand func = new SqlCommand("SELECT * FROM FN_StudentViewSlot(@CourseID, @InstructorID)", conn))
            {
                func.Parameters.AddWithValue("@CourseID", courseID);
                func.Parameters.AddWithValue("@InstructorID", instructorID);
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(func))
                {
                    DataTable resultTable = new DataTable();
                    adapter.Fill(resultTable);
                    return resultTable;
                }
            }
        }
        private void DisplayResultInTable(DataTable resultTable)
        {
            slotTable.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333");
            slotTable.CellPadding = 4;
            slotTable.HorizontalAlign = HorizontalAlign.Center;
            slotTable.CssClass = "auto-style3";

            slotTable.Rows.Add(CreateHeaderRow(resultTable));
            foreach (DataRow row in resultTable.Rows)
            {
                slotTable.Rows.Add(CreateRow(row, resultTable.Columns));
            }
        }
        private TableRow CreateRow(DataRow dataRow, DataColumnCollection columns)
        {
            TableRow row = new TableRow { BackColor = System.Drawing.ColorTranslator.FromHtml("#E3EAEB") };
            foreach (DataColumn column in columns)
            {
                TableCell cell = new TableCell { Text = dataRow[column].ToString() };
                row.Cells.Add(cell);
            }
            return row;
        }
        private TableHeaderRow CreateHeaderRow(DataTable resultTable)
        {
            TableHeaderRow row = new TableHeaderRow() { BackColor = System.Drawing.ColorTranslator.FromHtml("#1C5E55"), ForeColor = System.Drawing.Color.White };
            foreach (DataColumn column in resultTable.Columns)
            {
                TableHeaderCell cell = new TableHeaderCell { Text = column.ColumnName };
                row.Cells.Add(cell);
            }
            return row;
        }

    }
}

