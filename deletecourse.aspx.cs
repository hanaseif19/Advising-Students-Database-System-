using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class deletecourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCourses();
            }
        }
        protected void LoadCourses()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                
                string quest = "SELECT course_id, name, major, credit_hours FROM Course";
                using (SqlCommand cmd = new SqlCommand(quest, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                      
                        GridViewCourses.DataSource = reader;
                        GridViewCourses.DataBind();
                    }
                }

                conn.Close();
            }
        }
        protected void GridViewCourses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "DeleteCourse")
            {
                // Get the course_id from the clicked row
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                int course_id = Convert.ToInt32(GridViewCourses.DataKeys[rowIndex].Value);
                usermsg.Text= "Successfully deleted course with id="+ course_id.ToString();
                usermsg.ForeColor=System.Drawing.Color.Green;
                usermsg.Font.Bold = true;


                Deletecourse(course_id);

                LoadCourses();
            }
        }
        
            protected  void Deletecourse(int course_id)
            {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            try
            {
                
                SqlCommand proc = new SqlCommand("[Procedures_AdminDeleteCourse]", conn)
                { CommandType = CommandType.StoredProcedure };
                proc.Parameters.Add(new SqlParameter("courseID", course_id));
                
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