using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class viewAdvisors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Bind data to GridView on the first load
                GridView1.DataBind();
            }
        }

        protected void SqlDataSourceAdvisors_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}