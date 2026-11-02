using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class AdminAdConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Current End..2.3.2023

            HttpCookie myAdcookie = Request.Cookies["AdminAdInfo"];
            string accountNumber = myAdcookie["accountNum"];
            string company = myAdcookie["company"];




        }

        protected void finishedButton_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Default.aspx");

        }



    }
}