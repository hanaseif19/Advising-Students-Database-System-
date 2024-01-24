using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication1
{
    public partial class Register : System.Web.UI.Page
    {
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				
				Semester1.Items.Insert(0, new ListItem("Select a Semester", ""));
				Semester1.Items.Insert(1, new ListItem("1", "1")); 
				Semester1.Items.Insert(2, new ListItem("2", "2"));
				Semester1.Items.Insert(3, new ListItem("3", "3"));
				Semester1.Items.Insert(4, new ListItem("4", "4"));
				Semester1.Items.Insert(5, new ListItem("5", "5"));
				Semester1.Items.Insert(6, new ListItem("6", "6"));
				Semester1.Items.Insert(7, new ListItem("7", "7"));
				Semester1.Items.Insert(8, new ListItem("8", "8"));
				Semester1.Items.Insert(9, new ListItem("9", "9"));
				Semester1.Items.Insert(10, new ListItem("10", "10"));
				Semester1.Items.Insert(11, new ListItem("11", "11"));
				Semester1.Items.Insert(12, new ListItem("12", "12"));
				
			}

		}
        protected void addStudent(object sender, EventArgs e) {
			//try
			//{
				if (Semester1.SelectedItem != null && !string.IsNullOrEmpty(Semester1.SelectedItem.Value))
				{
					String firstName = fname.Text;
					String lastName = lname.Text;
					String newPassword = newPass.Text;
					String faculty = faculty1.Text;
					String email = email1.Text;
					String major = major1.Text;
					int semesterN = Int32.Parse(Semester1.SelectedValue);
					string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
					SqlConnection conn = new SqlConnection(connStr);
				   SqlCommand registration = new SqlCommand("dbo.Procedures_StudentRegistration", conn);
						registration.CommandType = CommandType.StoredProcedure;
						registration.Parameters.Add("@first_name", SqlDbType.VarChar).Value = firstName;
						registration.Parameters.Add("@last_name", SqlDbType.VarChar).Value = lastName;
						registration.Parameters.Add("@password", SqlDbType.VarChar).Value = newPassword;
						registration.Parameters.Add("@faculty", SqlDbType.VarChar).Value = faculty;
						registration.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
						registration.Parameters.Add("@major", SqlDbType.VarChar).Value = major;
						registration.Parameters.Add("@Semester", SqlDbType.Int).Value = semesterN;
				        
				        SqlParameter studentId = registration.Parameters.Add("@Student_id", SqlDbType.Int);
				        studentId.Direction = ParameterDirection.Output;
				conn.Open();
				registration.ExecuteNonQuery();
				int studentID = Convert.ToInt32(studentId.Value);	
				       
				        
						conn.Close();
						registerError.Text = "Registered Successfully";
						success.Text = "Welcome! your ID is " + studentID;

					

				}
				else
				{
					registerError.Text = "Please choose a Semester";
				}
			//}
			//catch (Exception) {
			
			//	registerError.Text = "Unsuccessfull Registration";
			//}
		}

	}
}