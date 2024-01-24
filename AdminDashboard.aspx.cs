using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void advisors_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/viewAdvisors.aspx");
        }

        protected void students_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/viewStudents.aspx");

        }

        protected void requests_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/viewPendingRequests.aspx");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/addSemester.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/addCourse.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/linkInstructorCourse.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/linkStudentAdvisor.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/linkStudentCourse.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InstructorDetails.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/viewSemesters.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("Button_Options.aspx");
        }
    }
}