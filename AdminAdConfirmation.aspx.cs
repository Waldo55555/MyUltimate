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

            HttpCookie myAdmincookie = Request.Cookies["AdminInfo"];
            string campaignNumber = myAdmincookie["campaignNumber"];
            string companyName = myAdmincookie["companyName"];
            string phone = myAdmincookie["phone"];
            string email = myAdmincookie["email"];

            //string companyName = Request.QueryString["companyName"];

            //string phone = Request.QueryString["phone"];

            //string email = Request.QueryString["email"];


            ViewState.Add("ExistingCompanyName", companyName);

            ViewState.Add("ExistingPhone", phone);

            ViewState.Add("ExistingEmail", email);



        }

        protected void finishedButton_Click(object sender, EventArgs e)
        {

            var companyName = ViewState["ExistingCompanyName"].ToString();

            var phone = ViewState["ExistingPhone"].ToString();

            var email = ViewState["ExistingEmail"].ToString();


            The18th.Areas.Ads.AdDTOs.AdvertisementDto doneAd = new The18th.Areas.Ads.AdDTOs.AdvertisementDto();
            doneAd.AdvertisementID = Guid.NewGuid();
            doneAd.CompanyName = companyName;
            doneAd.Phone = phone;
            doneAd.Email = email;


            Response.Redirect("~/Default.aspx");


        }



    }
}