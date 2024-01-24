using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;


namespace WebApplication1
{
    public partial class RequestCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.OptionalAndRequired(@StudentID ,@current_semester_code)", conn);
                cmd.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.NVarChar, 10)).Value = Session["userId"];
                cmd.Parameters.Add(new SqlParameter("@current_semester_code", SqlDbType.NVarChar, 10)).Value = DropDownListSemesters.SelectedValue;
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    DropDownListCourses.DataSource = dataTable;
                    DropDownListCourses.DataTextField = "name";
                    DropDownListCourses.DataValueField = "course_id";
                    DropDownListCourses.DataBind();
                }
                conn.Close();
                DropDownListCourses.Items.Insert(0, new ListItem("Select a course", ""));
            
        }

        protected void sendRequest(object sender, EventArgs e) {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.Procedures_StudentSendingCourseRequest", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@courseID", SqlDbType.Int);
                cmd.Parameters.Add("@StudentID", SqlDbType.Int);
                cmd.Parameters.Add("@type", SqlDbType.VarChar);
                cmd.Parameters.Add("@comment", SqlDbType.VarChar);
                cmd.Parameters["@courseID"].Value = DropDownListCourses.SelectedItem.Value;
                cmd.Parameters["@StudentID"].Value = Session["userId"];
                cmd.Parameters["@type"].Value = "course";
                string s = commentOnreq.Text;
                cmd.Parameters["@comment"].Value = s;
                cmd.ExecuteNonQuery();
                conn.Close();
                requestError.Text = "The Request is Done Successfully";
            }
            catch (Exception) {
				requestError.Text = "You Must Select a Course";
			}

		}
    }
}
	
