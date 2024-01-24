using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions; 


namespace WebApplication2
{
    public partial class addCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addcoursebutton_Click(object sender, EventArgs e)
        {
            string connString = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection connec = new SqlConnection(connString);

            // Get input values
            string major = majortetxboxID.Text;
            int semester; //Convert.ToInt32(semestertextboxID.Text);
            int creditHours; //= Convert.ToInt32(ch.Text);
            string courseName = coursename.Text;
            bool isOffered; //= Convert.ToBoolean(offeredtextboxID.Text);

            if (string.IsNullOrWhiteSpace(major) || string.IsNullOrWhiteSpace(courseName))
            {
                //HANDLE EPMTY
                string errorMessage = "Please fill in all the required fields.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", $"alert('{errorMessage}');", true);
                return;
            }
            if (!int.TryParse(semestertextboxID.Text, out semester))
            {
                //handle semester
                string errorMessage = "Invalid semester. Please enter a valid number.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", $"alert('{errorMessage}');", true);
                return;
            }
           if (!(Regex.IsMatch(majortetxboxID.Text, "^[a-zA-Z]+$")))
            {
                //handle semester
                string errorMessage = "Invalid major. Please enter a valid major name.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", $"alert('{errorMessage}');", true);
                return;
            }
            if (!int.TryParse(ch.Text, out creditHours))
            {
                //handle credit hours
                string errorMessage = "Invalid credit hours. Please enter a valid number.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", $"alert('{errorMessage}');", true);
                return;
            }
            if (!bool.TryParse(offeredtextboxID.Text, out isOffered))
            {
                //handle offered status
                string errorMessage = "Invalid offered status. Please enter true or false.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", $"alert('{errorMessage}');", true);
                return;
            }



            // Call the stored procedure
            SqlCommand command = new SqlCommand("Procedures_AdminAddingCourse", connec);
            command.CommandType = CommandType.StoredProcedure;

            // Add parameters
            command.Parameters.Add(new SqlParameter("@major", SqlDbType.VarChar, 20) { Value = major });
            command.Parameters.Add(new SqlParameter("@semester", SqlDbType.Int) { Value = semester });
            command.Parameters.Add(new SqlParameter("@credit_hours", SqlDbType.Int) { Value = creditHours });
            command.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 30) { Value = courseName });
            command.Parameters.Add(new SqlParameter("@is_offered", SqlDbType.Bit) { Value = isOffered });



            // Open the connection
            connec.Open();

            // Execute the stored procedure
            command.ExecuteNonQuery();

            string successMessage = "Course added successfully";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SuccessAlert", $"alert('{successMessage}');", true);

            connec.Close();

        }
    }
}