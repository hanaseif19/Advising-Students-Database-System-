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

namespace Advising_System
{
    public partial class GradPlan_Courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

			if (Session["userID"] == null)
            {
                Response.Redirect("LoginStudent.aspx");
            }

            if (int.TryParse(Session["userID"].ToString(), out int studentID))
            {
                DataTable resultTable = GetStudentViewGP(studentID);
                DisplayResultInTable(resultTable);
            }
            else
            {
                Response.Write("Boo");
            }
        }

        private DataTable GetStudentViewGP(int studentID)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand func = new SqlCommand("SELECT * FROM FN_StudentViewGP(@studentID)", conn))
            {
                func.Parameters.AddWithValue("@studentID", studentID);
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
            gradTable.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333");
            gradTable.CellPadding = 4;
            gradTable.HorizontalAlign = HorizontalAlign.Center;
            gradTable.CssClass = "auto-style3";

            gradTable.Rows.Add(CreateHeaderRow(resultTable));
            foreach (DataRow row in resultTable.Rows)
            {
                gradTable.Rows.Add(CreateRow(row, resultTable.Columns));
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

   