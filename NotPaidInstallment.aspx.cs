using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class NotPaidInstallment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null)
            {
                Response.Redirect("LoginStudent.aspx");
            }

            if (int.TryParse(Session["userId"].ToString(), out int studentID))
            {
                DateTime upcomingInstallmentDate = GetUpcomingInstallmentDate(studentID);

                if (upcomingInstallmentDate == DateTime.MinValue)
                {
                    message.InnerHtml = "No upcoming unpaid installment found.";
                }
                else
                {
                    message.InnerHtml = $"Your Upcoming Unpaid Installment is due on: {upcomingInstallmentDate.ToShortDateString()}";
                }
            }
            else
            {
                Response.Write("Student ID is unavailable. Try again.");
            }
        }

        private DateTime GetUpcomingInstallmentDate(int studentID)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand func = new SqlCommand("SELECT dbo.FN_StudentUpcoming_installment(@studentID)", conn))
            {
                func.Parameters.AddWithValue("@studentID", studentID);
                conn.Open();

                try
                {
                    object result = func.ExecuteScalar();
                    if (result != null && DateTime.TryParse(result.ToString(), out DateTime upcomingInstallmentDate))
                    {
                        return upcomingInstallmentDate;
                    }
                    else
                    {
                        Exception ex = new Exception($"Unexpected result from the database. Result: {result}");
                        Console.WriteLine(ex.Message);
                        return DateTime.MinValue;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return DateTime.MinValue;
                }
            }
        }
    }
}