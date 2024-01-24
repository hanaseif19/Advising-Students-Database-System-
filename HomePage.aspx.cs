using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginStudent.aspx");
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void btnAdvisor_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }
    }
}