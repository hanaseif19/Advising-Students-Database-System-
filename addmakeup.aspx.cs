using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection.Emit;

namespace WebApplication2
{
    public partial class addmakeup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addexamclick(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string courseid = CourseID.Text;
            bool typefirst = makeup1.Checked;
            bool typesecond = makeup2.Checked;
            string selectedType = typefirst ? "First_makeup" : typesecond ? "Second_makeup" : "None";
            try
            {
                DateTime makeupdate;
                if (string.IsNullOrWhiteSpace(ExamDate.Text))
                {
                    usermsg.Font.Bold = true;
                    usermsg.ForeColor = System.Drawing.Color.Red;
                    usermsg.Text = "Exam date ID should not be null or empty";
                    return;
                }
                else 
                    if (!(DateTime.TryParse(ExamDate.Text, out makeupdate)))
                {
                    usermsg.Font.Bold = true;
                    usermsg.ForeColor = System.Drawing.Color.Red;
                    usermsg.Text = "Invalid date format,Please enter a valid date.";
                    return;
                }
                else  if (string.IsNullOrWhiteSpace(CourseID.Text))
                {
                    usermsg.Font.Bold = true;
                    usermsg.ForeColor = System.Drawing.Color.Red;
                    usermsg.Text = "Course ID should not be null or empty";
                    return;
                }
                else if (typefirst == false && typesecond == false)
                {
                    usermsg.Font.Bold = true;
                    usermsg.ForeColor = System.Drawing.Color.Red;
                    usermsg.Text = "You should choose an exam type";
                    return;
                }
                else
                { // if we go in here means the date entered has a correct date format 


                    SqlCommand proc = new SqlCommand("[Procedures_AdminAddExam]", conn)
                    { CommandType = CommandType.StoredProcedure };
                    proc.Parameters.Add(new SqlParameter("@Type", selectedType));
                    proc.Parameters.Add(new SqlParameter("@date", makeupdate));
                    proc.Parameters.Add(new SqlParameter("@CourseID", courseid));

                    // inputs of the procedure 
                    conn.Open();
                    proc.ExecuteNonQuery();
                    conn.Close();

                    usermsg.Text = "Successfully added";
                    usermsg.ForeColor = System.Drawing.Color.Green;
                    usermsg.Font.Bold = true;
                }
            }
            catch (SqlException sqlExc)
            {
                if (sqlExc.Number == 547) // this 547 is used when he violates fk constraint
                {
                    usermsg.Font.Bold = true;
                    usermsg.Text = "Entered CourseID does not exist.";
                    usermsg.ForeColor = System.Drawing.Color.Red;
                }

            }
            catch (Exception exception)
            {
                usermsg.Font.Bold = true;
                usermsg.ForeColor = System.Drawing.Color.Red;
                usermsg.Text = "Error Occurred. Recheck info and try again.";

            }
        }

        protected void getback(object sender, EventArgs e)
        {
            Response.Redirect("Button_Options.aspx");
        }
    }
}
