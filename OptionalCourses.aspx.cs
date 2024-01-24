using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class OptionalCourses : System.Web.UI.Page
    {
		protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack)
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand command = new SqlCommand("SELECT semester_code FROM Semester", conn);
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    DropDownListSemesters.DataSource = dataTable;
                    DropDownListSemesters.DataTextField = "semester_code";
                    DropDownListSemesters.DataValueField = "semester_code";
                    DropDownListSemesters.DataBind();
                }
                conn.Close();
                DropDownListSemesters.Items.Insert(0, new ListItem("Select a Semester", ""));

            }

        }
        protected void showCourses(object sender, EventArgs e)
        {
				string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();

				using (SqlConnection conn = new SqlConnection(connStr))
				{
					using (SqlCommand cmd = new SqlCommand("dbo.Procedures_ViewOptionalCourse", conn))
					{
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.Add("@StudentID", SqlDbType.Int);
						cmd.Parameters.Add("@current_semester_code", SqlDbType.NVarChar, 40);
						cmd.Parameters["@StudentID"].Value = Session["userId"];
					    cmd.Parameters["@current_semester_code"].Value = DropDownListSemesters.SelectedValue;
							
						DataTable custTable = new DataTable("OptionalCourses");
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
						dtaColumn.Unique = true;
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


						OptionalCourses1.DataSource = dtaSet.Tables["OptionalCourses"];
						OptionalCourses1.DataBind();

					}
				}
			//}
			//catch (Exception) { 

			//}

		}
	}
}