using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class BannerEditConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie myAdcookie = Request.Cookies["AdvertisementInfo"];
            string adType = myAdcookie["adType"];
            string bannerElection = myAdcookie["bannerElection"];
            string schedule = myAdcookie["schedule"];
            string campTotal = myAdcookie["campTotal"];
            string account = myAdcookie["account"];

        }

        protected void returnButton_Click(object sender, EventArgs e)
        {

            HttpCookie myAdcookie = Request.Cookies["AdvertisementInfo"];
            string adType = myAdcookie["adType"];
            string bannerElection = myAdcookie["bannerElection"];
            string schedule = myAdcookie["schedule"];
            string campTotal = myAdcookie["campTotal"];
            string account = myAdcookie["account"];

            //Main Project...should continue to Ad Confirmation after edit
            Response.Redirect("~/AdConfirmation.aspx");


        }



    }
}