using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Courses_Exams : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateCourseExamTable();
            }
        }

        private void PopulateCourseExamTable()
        {
            DataTable resultTable = GetCourses_MakeupExams();
            DisplayResultInTable(resultTable);
        }

        private DataTable GetCourses_MakeupExams()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Courses_MakeupExams", conn))
            {
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable resultTable = new DataTable();
                    adapter.Fill(resultTable);
                    return resultTable;
                }
            }
        }

        private void DisplayResultInTable(DataTable resultTable)
        {
            courseExamTable.Rows.Clear();
            courseExamTable.Rows.Add(CreateHeaderRow(resultTable));
            foreach (DataRow row in resultTable.Rows)
            {
                courseExamTable.Rows.Add(CreateRow(row, resultTable.Columns));
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
