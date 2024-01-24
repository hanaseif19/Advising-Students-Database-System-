using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace WebApplication2
{

	public partial class AvailableCourses : System.Web.UI.Page
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
		protected void View(object sender, EventArgs e)
		{
			string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
			SqlConnection conn = new SqlConnection(connStr);
			try { 
			SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.FN_SemsterAvailableCourses(@semstercode)", conn);
			cmd.Parameters.Add(new SqlParameter("@semstercode", SqlDbType.VarChar)).Value = DropDownListSemesters.SelectedValue;
			conn.Open();

			
			using (SqlDataReader reader = cmd.ExecuteReader())
			{
				AvailableCourses1.DataSource = reader;
				AvailableCourses1.DataBind();
			}
			conn.Close();
		}
		catch(Exception ex)
		{
			Response.Write(ex.Message);
			errorMessage.Text = "Please Select a Semester ";
		}
			

			

		}
	}
}
