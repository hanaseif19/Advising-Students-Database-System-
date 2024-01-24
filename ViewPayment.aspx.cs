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
    public partial class ViewPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand mycmd = new SqlCommand("SELECT * FROM Student_Payment", conn);
            conn.Open();
            SqlDataReader reader = mycmd.ExecuteReader();

            
            FillTable(studentpayment, reader,columnNames);

            
            conn.Close();

        }
        static private string[] columnNames = {
    "Student ID",
    "First Name",
    "Last Name",
    "Payment ID",
    "Amount",
    "Start Date",
    "Deadline",
    "Num Ins",
    "Fund%",
    "Status",
    "SemCode"
};


        public static void FillTable(Table coursesTable, SqlDataReader reader,string[] cols)
        {
           
            coursesTable.Rows.Clear();

            TableRow headerRow = new TableRow();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                TableCell cell = new TableCell();
                cell.Text = "<b>" + cols[i] + "</b>";
                headerRow.Cells.Add(cell);
                cell.CssClass = "headerCell";
            }
            coursesTable.Rows.Add(headerRow);

            while (reader.Read())
            {
                TableRow row = new TableRow();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    TableCell cell = new TableCell();
                    cell.Text = reader[i].ToString();
                    cell.CssClass = "normalcells";
                    row.Cells.Add(cell);
                }

                coursesTable.Rows.Add(row);
            }

            
            reader.Close();
        }

        protected void getback(object sender, EventArgs e)
        {
            Response.Redirect("Button_Options.aspx");
        }
    }
}