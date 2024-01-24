using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class advisornav : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void alladvising(object sender, EventArgs e)
        {
            Response.Redirect("AdivsorAllStudents.aspx");
        }
        protected void addcourses(object sender, EventArgs e)
        {
            Response.Redirect("AddCoursesGradPlan.aspx");
        }
        protected void updategraddate(object sender, EventArgs e)
        {
            Response.Redirect("UpdateGradDate.aspx");
        }
        protected void deletecourse(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorDeleteCourse.aspx");
        }
        protected void viewstudentsmajors(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorStudentsMajors.aspx");

        }
        protected void viewrequestsall(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorAllRequests.aspx");
        }
        protected void viewpendingrequests(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorPendingRequests.aspx");
        }


        protected void insertgradplan(object sender, EventArgs e)
        {
            Response.Redirect("CreateGradPlan.aspx");

        }
    }
}