using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class ContactInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void addNewPhone(object sender, EventArgs e) {
			try
			{
				string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
				SqlConnection conn = new SqlConnection(connStr);
				SqlCommand addPhone = new SqlCommand("dbo.[Procedures_StudentaddMobile]", conn);
				String phNum = phoneNumber.Text;
				addPhone.CommandType = CommandType.StoredProcedure;
				addPhone.Parameters.Add("@StudentID", SqlDbType.Int).Value = Session["userId"];
				addPhone.Parameters.Add("@mobile_number", SqlDbType.VarChar, 40).Value = phNum;
				
				conn.Open();
				
				addPhone.ExecuteNonQuery();
				conn.Close();
				
				addNewSucces.Text = "Phone Number is Added Successfully!";
			}
			catch (Exception) {
				
				addNewSucces.Text = "Already Exist";
			}
		}
	}
}