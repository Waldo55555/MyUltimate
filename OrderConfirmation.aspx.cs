using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    //Tghis was here originally
    //public partial class OderConfirmation : System.Web.UI.Page
    public partial class OrderConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Current End..4.3.2022
        }

        protected void finishedButton_Click(object sender, EventArgs e)
        {
            //This redirect to get to annonymous layout

            Response.Redirect("~/Default");

        }
    }
}