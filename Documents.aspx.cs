using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class Documents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void retrieveImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DocRetrieval.aspx");
        }

        protected void submitImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DocSubmittal.aspx");
        }
    }
}