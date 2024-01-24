using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics.Eventing.Reader;

namespace WebApplication2
{
    public partial class IssueInstallments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void clickissueinst(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int payid;
            try
            {

                if (string.IsNullOrWhiteSpace(paymentid.Text))
                {
                    usermsg2.Text = "Payment ID should not be null or empty";
                    usermsg2.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else 
                if (!(int.TryParse(paymentid.Text, out payid)))

                {
                    usermsg2.Text = "Payment ID should be an Integer, Try again";
                    usermsg2.ForeColor = System.Drawing.Color.Red;
                 //   Response.Write("hi");
                    return;
                }
             else if (! (ExistsPayment(payid,conn)))
                {
                    usermsg2.Text = "Payment ID doesnt exist";
                    usermsg2.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    //Response.Write("youre in else");
                    SqlCommand proc = new SqlCommand("[Procedures_AdminIssueInstallment]", conn)
                    { CommandType = CommandType.StoredProcedure };
                    proc.Parameters.Add(new SqlParameter("@payment_id", payid));
                    conn.Open();
                   // Response.Write("youre in else2");

                    proc.ExecuteNonQuery();
                    //Response.Write("youre in else3");

                    conn.Close();
                    usermsg2.Text = "Submitted successfully";
                   // Response.Write("hi"+ ExistsPayment(payid,conn));
                    usermsg2.ForeColor = System.Drawing.Color.Green;
                }
            }

            catch (SqlException exc)
            {
                if (exc.Number == 547)

                {
                    Response.Write("YOURE IN 547");
                    usermsg2.Text = "This Payment ID doesn't exist";
                    usermsg2.ForeColor = System.Drawing.Color.Red;
                }
                else if (exc.Number==2627)
                {
                    usermsg2.Text = "Installments for this payment were already inserted";
                    usermsg2.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception exception)
            {
                usermsg2.Font.Bold = true;
                usermsg2.ForeColor = System.Drawing.Color.Red;
                usermsg2.Text = "Error Occurred. Recheck info and try again.";

            }
        }
        private bool ExistsPayment(int paymentId, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Payment WHERE Payment.payment_id = @paymentId", connection);

            command.Parameters.AddWithValue("@paymentId", paymentId); // Fix: Use the correct parameter name
            connection.Open();
            int count = (int)command.ExecuteScalar();
            connection.Close();
            return count > 0;
        }


        protected void getback(object sender, EventArgs e)
        {
            Response.Redirect("Button_Options.aspx");
        }
    }
}