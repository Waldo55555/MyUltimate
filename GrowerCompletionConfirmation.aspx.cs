using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class GrowerCompletionConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie cookie = Request.Cookies["GrowerCookieInfo"];
            string growerNumberCookie = cookie["growerNumber"];
            string growerNameCookie = cookie["growerName"];

            var growerNumber = growerNumberCookie.Trim();

            ViewState.Add("ExistingGrowerNum", growerNumber);

            growerNumberLabel.Text = growerNumber;


        }

        protected void growerDashButton_Click(object sender, EventArgs e)
        {

            //Response.Redirect("~/Default.aspx");

            Response.Redirect("/Growers/GrowerAdmin/GrowerSignIn");

        }





    }
}