using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class UpdateStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getStudents();
            }
        }

        protected void getStudents()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();


            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();


                string quest = "SELECT student_id, f_name,l_name,financial_status FROM Student";
                using (SqlCommand cmd = new SqlCommand(quest, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        GridViewStudents.DataSource = reader;
                        GridViewStudents.DataBind();
                    }
                }

                conn.Close();
            }
        }
        protected void GridViewStudent_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "UpdateStatus")
            {
               
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                int student_id = Convert.ToInt32(GridViewStudents.DataKeys[rowIndex].Value);
                usermsg.Text = "Successfully updated Status of Student with id=" + student_id.ToString();
                usermsg.ForeColor = System.Drawing.Color.Green;
                usermsg.Font.Bold = true;
                updatestatusfn(student_id);

                getStudents();
            }
        }

        protected void updatestatusfn(int student_id)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            try
            {

                SqlCommand proc = new SqlCommand("[Procedure_AdminUpdateStudentStatus]", conn)
                { CommandType = CommandType.StoredProcedure };
                proc.Parameters.Add(new SqlParameter("@student_id", student_id));

                conn.Open();
                proc.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exception)
            {
                Response.Write("Error Occured, Recheck info and try again");
                Response.Write(exception.Message);
            }


        }

        protected void getback(object sender, EventArgs e)
        {
            Response.Redirect("Button_Options.aspx");
        }
    }
}