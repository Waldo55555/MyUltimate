using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class ProviderConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //2
            HttpCookie cookie = Request.Cookies["AdminCookieInfo"];
            string adminNumberCookie = cookie["adminNumber"];

            ViewState.Add("ExistingAdminNum", adminNumberCookie);

            var myProfNumber = adminNumberCookie.Trim();


            //check
            string firstName = Request.QueryString["firstName"];

            ViewState.Add("ExistingFirstName", firstName);


        }

        protected void completeButton_Click(object sender, EventArgs e)
        {

            //Response.Redirect("~/Default.aspx");

            Response.Redirect("/Meek/RunUp/RunUpAdmin");



        }

        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");

        }


    }
}