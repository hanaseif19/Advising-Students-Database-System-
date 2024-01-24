using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace WebApplication2
{
    public partial class CreateGradPlan : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int? advisorID = Session["AdvisorId"] as int?;
            if (!advisorID.HasValue)
            {
                Response.Redirect("Login.aspx");
            }

        }

        [Obsolete]
        protected void createbutton(object sender, EventArgs e)
        {
            int? advisorID = Session["AdvisorId"] as int?;
            if (!advisorID.HasValue)
            {
                Response.Redirect("Login.aspx");
            }

            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string scode = semcode.Text;
                    DateTime graduationDate;

                    if (!DateTime.TryParse(graddate.Text, out graduationDate))
                    {
                        Response.Write("Please enter a valid graduation date.");
                        return;
                    }

                    int credit;
                    if (!int.TryParse(credithours.Text, out credit))
                    {
                        Response.Write("Please enter a valid credit hours.");
                        return;
                    }

                    int studentID;
                    if (!int.TryParse(sid.Text, out studentID) || !StudentExists(advisorID.Value, studentID))
                    {
                        Response.Write("Please enter a valid student ID.");
                        return;
                    }
                    string semesterCodePattern = @"^(W\d{2}|S\d{2}|S\d{2}R[12])$";

                    if (!Regex.IsMatch(scode, semesterCodePattern))
                    {
                        Response.Write("Please enter a valid semester");
                        return;
                    }
                    if(!enoughHours(advisorID.Value, studentID))
                    {
                        Response.Write("Student not eligible for a graduation plan. Has less than 157 hours.");
                        return; 
                    }


                    SqlCommand proccreategradplan = new SqlCommand("Procedures_AdvisorCreateGP", conn);
                    proccreategradplan.CommandType = CommandType.StoredProcedure;
                    proccreategradplan.Parameters.Add("@Semester_code", SqlDbType.VarChar).Value = scode;
                    proccreategradplan.Parameters.Add("@expected_graduation_date", SqlDbType.DateTime).Value = graduationDate;
                    proccreategradplan.Parameters.Add("@sem_credit_hours", SqlDbType.Int).Value = credit;
                    proccreategradplan.Parameters.Add("@student_id", SqlDbType.Int).Value = studentID;
                    proccreategradplan.Parameters.Add("@advisor_id", SqlDbType.Int).Value = advisorID;

                    conn.Open();
                    proccreategradplan.ExecuteNonQuery();
                    Response.Write("Success");
                }
            }
            catch (SqlException sqlEx)
            {
                Response.Write("SQL Error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred: " + ex.Message);
            }
        }
        private bool StudentExists(int advisorId, int studentId)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand checkIfExists = new SqlCommand("SELECT COUNT(*) FROM Student WHERE advisor_id = @advisorId AND student_id = @studentId", conn);
            checkIfExists.Parameters.AddWithValue("@advisorId", advisorId);
            checkIfExists.Parameters.AddWithValue("@studentId", studentId);

            conn.Open();
            int count = (int)checkIfExists.ExecuteScalar();
            conn.Close();

            return count > 0;
        }

        private bool enoughHours(int advisorId, int studentId)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand checkIfExists = new SqlCommand("SELECT COUNT(*) FROM Student WHERE acquired_hours >=157 AND student_id = @studentId", conn);
            checkIfExists.Parameters.AddWithValue("@advisorId", advisorId);
            checkIfExists.Parameters.AddWithValue("@studentId", studentId);

            conn.Open();
            int count = (int)checkIfExists.ExecuteScalar();
            conn.Close();

            return count > 0;
        }

    }
    }