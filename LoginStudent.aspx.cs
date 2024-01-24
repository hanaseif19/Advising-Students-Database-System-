using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace WebApplication2
{
    public partial class LoginStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void goRegister(object sender, EventArgs e)
        {

            Response.Redirect("Register.aspx");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                int id = Int32.Parse(username.Text);
                SqlCommand checkExist = new SqlCommand("Select count(*) from Student where student_id = @id ", conn);
                checkExist.Parameters.AddWithValue("@id", id);
                conn.Open();
                int count = (int)checkExist.ExecuteScalar();
                conn.Close();
                if (count == 0)
                {
                    process.Text = "There is No Such a Student";
                }
                else
                {

                    String pass = password1.Value;
                    using (SqlCommand loginproc = new SqlCommand("FN_StudentLogin", conn))
                    {
                        loginproc.CommandType = CommandType.StoredProcedure;
                        loginproc.Parameters.Add("@Student_id", SqlDbType.Int).Value = id;
                        loginproc.Parameters.Add("@password", SqlDbType.VarChar, 40).Value = pass;

                        SqlParameter success = loginproc.Parameters.Add("@RETURN_VALUE", SqlDbType.Bit);
                        success.Direction = ParameterDirection.ReturnValue;
                        conn.Open();
                        loginproc.ExecuteScalar();
                        bool loginsuccess = (bool)success.Value;
                        conn.Close();
                        if (loginsuccess)
                        {
                            Session["userId"] = id;
                            Session["password"] = pass;
                            process.Text = "Login successful";
                            Response.Redirect("studentPortal.aspx");
                        }
                        else
                        {


                            SqlCommand checkStatus = new SqlCommand("Select financial_status from Student where student_id=@id", conn);
                            checkStatus.Parameters.AddWithValue("@id", id);
                            conn.Open();
                            object status = checkStatus.ExecuteScalar();
                            conn.Close();
                            if (status != DBNull.Value && status != null)
                            {
                                bool state = (bool)status;
                                if (!state)
                                {
                                    process.Text = "You have a Payment Issue";

                                }

                                else
                                {

                                    process.Text = "Username or Password is Not Correct";
                                }
                            }
                            else
                            {
                                Session["userId"] = id;
                                Session["password"] = pass;
                                process.Text = "Login successful";
                                Response.Redirect("studentPortal.aspx");
                            }


                        }
                    }
                }
            }
            catch (FormatException E)
            {
                Response.Write(E.Message);
                process.Text = "Id Must be an Integer";
            }
            catch (Exception)
            {
                process.Text = "Enter Valid UserName or Password";
            }



        }



    }
}