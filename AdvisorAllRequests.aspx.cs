
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
    public partial class AdvisorAllRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
                SqlConnection conn = new SqlConnection(connStr);


                int? advisorID = Session["AdvisorId"] as int?;
                if (!advisorID.HasValue)
                {
                    Response.Redirect("Login.aspx");
                }


                SqlCommand fngetrequestsall = new SqlCommand("SELECT * from dbo.FN_Advisors_Requests(@advisor_id)", conn);
                fngetrequestsall.Parameters.Add(new SqlParameter("@advisor_id", SqlDbType.Int)).Value = advisorID;

                conn.Open();
                SqlDataReader reader = fngetrequestsall.ExecuteReader();
                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    requestGridView.DataSource = dt;
                    requestGridView.DataBind();
                }
                else
                {
                    Response.Write("There are no requests.");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);

            }
        }




        protected void requestGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Respond")
            {
                int requestId = Convert.ToInt32(e.CommandArgument) + 1;
                string currentSemCode = GetCurrSemCode();

                string requestType = GetRequestType(requestId);


                if (requestType == "credit")
                {
                    ApproveRejectCreditRequest(requestId, currentSemCode, e.CommandName);
                }
                else
                {
                    if (requestType == "course")
                        ApproveRejectCourseRequest(requestId, currentSemCode, e.CommandName);
                }

                // Refresh the GridView or perform any additional actions as needed
                Page_Load(sender, e);
            }


        }

        private string GetRequestType(int requestId)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();

                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand cmd = new SqlCommand("SELECT type FROM Request WHERE request_id = @requestId", conn);
                cmd.Parameters.AddWithValue("@requestId", requestId);

                conn.Open();
                string result = (string)cmd.ExecuteScalar();
                //Response.Write(result);

                if (result != null)
                {
                    return result;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                // Handle the exception (log, display an error message, etc.)
                Response.Write($"Error: {ex.Message}");
            }

            // Return a default value or handle the case when the type is not found
            return "Unknown";
        }

        private void ApproveRejectCreditRequest(int requestId, string currentSemCode, string action)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand("Procedures_AdvisorApproveRejectCHRequest", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@requestID", requestId);
                        cmd.Parameters.AddWithValue("@current_sem_code", currentSemCode);


                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, display an error message, etc.)
                Response.Write($"Error: {ex.Message}");
            }
        }

        private void ApproveRejectCourseRequest(int requestId, string currentSemCode, string action)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand("Procedures_AdvisorApproveRejectCourseRequest", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@requestID", requestId);
                        cmd.Parameters.AddWithValue("@current_semester_code", currentSemCode);


                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, display an error message, etc.)
                Response.Write($"Error: {ex.Message}");
            }
        }
        private string GetCurrSemCode()
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand getCurrentSemester = new SqlCommand("SELECT semester_code FROM Semester WHERE @currentDate BETWEEN start_date AND end_date", conn);

                    // Assuming currentDate is the current date in your application
                    DateTime currentDate = DateTime.Now;

                    getCurrentSemester.Parameters.Add("@currentDate", SqlDbType.Date).Value = currentDate;

                    conn.Open();
                    object result = getCurrentSemester.ExecuteScalar();

                    // Check if a semester code was found for the current date
                    if (result != null)
                    {
                        return result.ToString();
                    }
                    else
                    {
                        // Handle the case when no matching semester is found
                        return "No Current Semester";
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Log or handle the SQL exception
                return "Error retrieving current semester";
            }
            catch (Exception ex)
            {
                // Log or handle the general exception
                return "An error occurred: " + ex.Message;
            }
        }

    }
}