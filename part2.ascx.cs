using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebUserControl3 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void clickbutt1(object sender, EventArgs e)
        {
            Response.Redirect("deletecourse.aspx");

        }

        protected void clickbutt2(object sender, EventArgs e)
        {
            Response.Redirect("deleteSlots.aspx");
        }






        protected void clickbutt3(object sender, EventArgs e)
        {
            Response.Redirect("addmakeup.aspx");
        }
        protected void clickbutt4(object sender, EventArgs e)
        {
            Response.Redirect("ViewPayment.aspx");
        }

        protected void clickbutt5(object sender, EventArgs e)
        {
            Response.Redirect("Issueinstallments.aspx");
        }

        protected void clickbutt6(object sender, EventArgs e)
        {
            Response.Redirect("UpdateStatus.aspx");
        }

        protected void clickbutt7(object sender, EventArgs e)
        {
            Response.Redirect("FetchStdDetails.aspx");
        }

        protected void clickbutt8(object sender, EventArgs e)
        {
            Response.Redirect("ViewGradPlans.aspx");
        }

        protected void clickbutt9(object sender, EventArgs e)
        {
            Response.Redirect("Transcript.aspx");
        }

        protected void clickbutt10(object sender, EventArgs e)
        {
            Response.Redirect("SemCourse.aspx");
        }
        protected void clickbutt11(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashBoard.aspx");
        }
    }
}