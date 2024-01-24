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
    public partial class linkInstructorCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Link1_Click(object sender, EventArgs e)
        {
            string connString = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection connec = new SqlConnection(connString);

            if (string.IsNullOrWhiteSpace(cID.Text) || string.IsNullOrWhiteSpace(iID.Text) || string.IsNullOrWhiteSpace(sID.Text))
            {
                DisplayErrorMessage("All IDs are required. Please enter valid IDs.");
                return;
            }

            int courseId = Convert.ToInt32(cID.Text);
            int instructorId = Convert.ToInt32(iID.Text);
            int slotId = Convert.ToInt32(sID.Text);

            if (!IdExists(connec, "Course", "course_id", courseId))
            {
                DisplayErrorMessage("Invalid Course ID. Please enter a valid Course ID.");
                return;
            }
            if (!IdExists(connec, "Instructor", "instructor_id", instructorId))
            {
                DisplayErrorMessage("Invalid Instructor ID. Please enter a valid Instructor ID.");
                return;
            }
            if (!IdExists(connec, "Slot", "slot_id", slotId))
            {
                DisplayErrorMessage("Invalid Slot ID. Please enter a valid Slot ID.");
                return;
            }
            

            SqlCommand command = new SqlCommand("Procedures_AdminLinkInstructor", connec);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@cours_id", SqlDbType.Int) { Value = courseId });
            command.Parameters.Add(new SqlParameter("@instructor_id", SqlDbType.Int) { Value = instructorId });
            command.Parameters.Add(new SqlParameter("@slot_id", SqlDbType.Int) { Value = slotId });

            
            connec.Open();

            command.ExecuteNonQuery();
            string successMessage = "link successful";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SuccessAlert", $"alert('{successMessage}');", true);

            connec.Close();
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
        private  void DisplayErrorMessage(string errorMessage)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", $"alert('{errorMessage}');", true);
        }

    }
}