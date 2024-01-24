using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace WebApplication2
{
    public partial class addSemester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddSem_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection connection = new SqlConnection(connStr);

            // Get input values
            //DateTime startDate = Convert.ToDateTime(start.Text);
            //DateTime endDate = Convert.ToDateTime(end.Text);
            string semesterCode = (semCode.Text).ToUpper();
            DateTime startDate, endDate;


            //validation
            string semesterCodePattern = @"^(W\d{2}|S\d{2}|S\d{2}R[12])$"; //w then 2 digits or s then 2 digits then R (1 or 2) etc..
            if (!System.Text.RegularExpressions.Regex.IsMatch(semesterCode, semesterCodePattern))
            {
                //invalid semester code
                string errorMessage = "Invalid semester code. Please enter a valid code (W23, S23R1, S23R2, etc.).";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", $"alert('{errorMessage}');", true);
                return;
            }
            if (!DateTime.TryParse(start.Text, out startDate) || !DateTime.TryParse(end.Text, out endDate))
            {
                //invalid date 
                string errorMessage = "Invalid date. Please enter a valid date.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", $"alert('{errorMessage}');", true);
                return;
            }
            if (endDate < startDate)
            {
                //end date cant be before start date
                string errorMessage = "End date cannot be before the start date. Please enter a valid date range.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", $"alert('{errorMessage}');", true);
                return;
            }

            //call the stored proc
            SqlCommand command = new SqlCommand("AdminAddingSemester", connection);
            command.CommandType = CommandType.StoredProcedure;

            //parameters
            command.Parameters.Add(new SqlParameter("@semester_code", SqlDbType.VarChar, 40) { Value = semesterCode });
            command.Parameters.Add(new SqlParameter("@start_date", SqlDbType.Date) { Value = startDate });
            command.Parameters.Add(new SqlParameter("@end_date", SqlDbType.Date) { Value = endDate });

            //ppen connection
            connection.Open();

            //execute the stored proc
            command.ExecuteNonQuery();

            //display success message
            string successMessage = "Semester added successfully";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SuccessAlert", $"alert('{successMessage}');", true);


            connection.Close();
            
        
        }
    }
}