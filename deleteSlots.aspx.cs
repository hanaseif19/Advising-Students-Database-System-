using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Expressions;

namespace WebApplication2
{
    public partial class deleteSlots : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            putsemcodesinlist();
        }

        protected void deleteslotclick(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                string mycurrsem = ddlSemesters.SelectedValue;
                if (string.IsNullOrWhiteSpace(mycurrsem))
                {
                    usermsg.Text = "Choose a semestervalue"; usermsg.ForeColor = System.Drawing.Color.Green;
                    usermsg.Font.Bold = true;
                    usermsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    SqlCommand proc = new SqlCommand("[Procedures_AdminDeleteSlots]", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    proc.Parameters.Add(new SqlParameter("@current_semester", mycurrsem));
                    conn.Open();
                    proc.ExecuteNonQuery();
                    conn.Close();

                    usermsg.Text = "Successfully deleted courses not offered in " + mycurrsem;
                    usermsg.ForeColor = System.Drawing.Color.Green;
                    usermsg.Font.Bold = true;

                }
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
                usermsg.Text="Big error";
            }
        }
         protected void putsemcodesinlist()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            
               
                string query = "SELECT semester_code FROM Semester";


            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
               
                
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    ddlSemesters.DataSource = dataTable;
                    ddlSemesters.DataTextField = "semester_code"; 
                    ddlSemesters.DataValueField = "semester_code"; 
                    ddlSemesters.DataBind();
                }

        protected void getback(object sender, EventArgs e)
        {
            Response.Redirect("Button_Options.aspx");
        }
    }
}