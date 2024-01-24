using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class MissingCourses : System.Web.UI.Page
    {
        
			protected void Page_Load(object sender, EventArgs e)
			{
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("dbo.Procedures_ViewMS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StudentID", SqlDbType.Int);
            cmd.Parameters["@StudentID"].Value = Session["userId"];
            DataTable custTable = new DataTable("MissingCourses");
            DataColumn dtaColumn;
            dtaColumn = new DataColumn();
            dtaColumn.DataType = typeof(Int32);
            dtaColumn.ColumnName = "CourseID";
            dtaColumn.Caption = "CourseID";
            dtaColumn.ReadOnly = true;
            custTable.Columns.Add(dtaColumn);
            dtaColumn = new DataColumn();
            dtaColumn.DataType = typeof(String);
            dtaColumn.ColumnName = "CourseName";
            dtaColumn.Caption = "CourseName";
            dtaColumn.ReadOnly = true;
            custTable.Columns.Add(dtaColumn);
            DataSet dtaSet = new DataSet();
            dtaSet.Tables.Add(custTable);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    DataRow dtRow = custTable.NewRow();
                    dtRow["CourseID"] = (int)reader["course_id"];
                    dtRow["CourseName"] = (String)reader["name"];
                    custTable.Rows.Add(dtRow);
                }

                reader.Close();
            }

            conn.Close();


            MissingCourses1.DataSource = dtaSet.Tables["MissingCourses"];
            MissingCourses1.DataBind();




        }

	}
}