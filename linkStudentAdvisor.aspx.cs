using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class linkStudentAdvisor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Link2_Click(object sender, EventArgs e)
        {
            string connString = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection connec = new SqlConnection(connString);

            if (string.IsNullOrWhiteSpace(stdID.Text) || string.IsNullOrWhiteSpace(advID.Text))
            {
                DisplayErrorMessage("All IDs are required. Please enter valid IDs.");
                return;
            }

            int studentId = Convert.ToInt32(stdID.Text);
            int advisorId = Convert.ToInt32(advID.Text);

            if (!IdExists(connec, "Student", "student_id", studentId))
            {
                DisplayErrorMessage("Invalid Student ID. Please enter a valid Student ID.");
                return;
            }
            if (!IdExists(connec, "Advisor", "advisor_id", advisorId))
            {
                DisplayErrorMessage("Invalid Advisor ID. Please enter a valid Advisor ID.");
                return;
            }


            SqlCommand command = new SqlCommand("Procedures_AdminLinkStudentToAdvisor", connec);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@studentID", SqlDbType.Int) { Value = studentId });
            command.Parameters.Add(new SqlParameter("@advisorID", SqlDbType.Int) { Value = advisorId });
            

            // Open the connection
            connec.Open();

            // Execute the stored procedure
            command.ExecuteNonQuery();
            string successMessage = "link successful";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SuccessAlert", $"alert('{successMessage}');", true);

            connec.Close();
        }

        private void DisplayErrorMessage(string errorMessage)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", $"alert('{errorMessage}');", true);
        }

        private bool IdExists(SqlConnection connection, string tableName, string columnName, int id)
        {
            using (SqlCommand command = new SqlCommand($"SELECT 1 FROM {tableName} WHERE {columnName} = @id", connection))
            {
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                object result = command.ExecuteScalar();

                connection.Close();

                return result != null;
            }
        }
    }
}