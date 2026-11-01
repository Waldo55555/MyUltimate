using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class AdminBannerReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //HttpCookie myAdcookie = Request.Cookies["AdvertisementInfo"];
            //string adType = myAdcookie["adType"];
            //string target = myAdcookie["target"];
            //string campType = myAdcookie["campType"];
            //string schedule = myAdcookie["schedule"];

            //HttpCookie mygeneralAdcookie = Request.Cookies["GeneralAdInfo"];
            //string companyName = mygeneralAdcookie["companyName"];
            //string phone = mygeneralAdcookie["phone"];
            //string email = mygeneralAdcookie["email"];

            //companyLabel.Text = companyName;
            //phoneLabel.Text = phone;
            //emailLabel.Text = email;

            string cs = ConfigurationManager.ConnectionStrings["OneStateData"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand("spGetBannerByCampaignNumber", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter()
                {
                    ParameterName = "@CampaignNumber",
                    Value = Request.QueryString["campNumber"]
                };
                cmd.Parameters.Add(paramId);

                con.Open();
                byte[] bytes = (byte[])cmd.ExecuteScalar();
                //con.Close();

                string strBase64 = Convert.ToBase64String(bytes);

                vendorImage.ImageUrl = "data:Image/png;base64," + strBase64;

            }

            //string simplePhotoNumber = Request.QueryString["Id"];

            //ViewState.Add("ExistingSimpleId", simplePhotoNumber);

            //simplePhotoLabel.Text = simplePhotoNumber;

            string simplePhotoNumber = Request.QueryString["CampaignNumber"];

            ViewState.Add("ExistingSimpleId", simplePhotoNumber);

            simplePhotoLabel.Text = simplePhotoNumber;


        }

        protected void savePhotoButton_Click(object sender, EventArgs e)
        {

            //HttpCookie myAdcookie = Request.Cookies["AdvertisementInfo"];
            //string adType = myAdcookie["adType"];
            //string target = myAdcookie["target"];
            //string campType = myAdcookie["campType"];
            //string schedule = myAdcookie["schedule"];

            //HttpCookie mygeneralAdcookie = Request.Cookies["GeneralAdInfo"];
            //string companyName = mygeneralAdcookie["companyName"];
            //string phone = mygeneralAdcookie["phone"];
            //string email = mygeneralAdcookie["email"];


            ////The18th.Areas.Ads.AdDTOs.AdvertisementDto myOtherCamp = new The18th.Areas.Ads.AdDTOs.AdvertisementDto();
            ////myOtherCamp.CompanyName = companyName;

            //The18th.Areas.Ads.AdDTOs.AdvertisementDto myOtherAd = new The18th.Areas.Ads.AdDTOs.AdvertisementDto();
            //myOtherAd.AdvertisementID = Guid.Empty;
            //myOtherAd.CompanyName = companyName;

            //var pulledCampInfo = The18th.Areas.Ads.Data.AdManager.GetAAdvertisement(myOtherAd);

            ////var pulledPhoto = The18th.Areas.Ads.Data.AdManager.GetABannerPhoto(campaignNumber);

            ////var pulledCampaign = The18th.Areas.Ads.Data.AdManager.GetACampaign(myOtherCamp);

            //The18th.Areas.Ads.AdDTOs.AdvertisementDto clientAd = new The18th.Areas.Ads.AdDTOs.AdvertisementDto();
            //clientAd.AdvertisementID = Guid.NewGuid();
            ////clientAd.AccountNumber = accountNumber;
            //clientAd.CompanyName = companyName;
            //clientAd.Phone = phone;
            //clientAd.Email = email;
            //clientAd.CampaignType = campType;
            //clientAd.CampaignSchedule = schedule;
            //clientAd.AdType = adType;
            //clientAd.TargetLocation = target;
            //clientAd.BannerDesign = true;
            //clientAd.CampaignTotal = 9.99;
            //clientAd.AdStatus = "Pending";
            //clientAd.Deposit = 0.00;
            //clientAd.EstimatedTotal = 9.99;
            //clientAd.Tax = 8.25;

            //try
            //{

            //    //if (clientAd.AccountNumber.Trim().Length == 0)
            //    //    throw new NotImplementedException("Sorry Something is missing");

            //    //The18th.Areas.Ads.Data.AdManager.InsertAd(clientAd);

            //    The18th.Areas.Ads.Data.AdManager.InsertAdvertisement(clientAd);


            //}

            //catch (Exception ex)
            //{

            //    string message = "";

            //    message = ex.Message;

            //}

            ////Response.Redirect("~/AdEntry.aspx?companyName=" + companyName);

            Response.Redirect("~/AdminAdConfirmation.aspx");




        }


        /////////////////////////////////////Helper Methods

        public static void sendAdvertisementEmail(The18th.Areas.Ads.AdDTOs.AdvertisementDto myAd)
        {


            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;


            string ourCompanyInfo = "\n \n Advertisement info is... \n";

            string companyName = myAd.CompanyName;

            string phone = myAd.Phone;

            string email = myAd.Email;

            //////////////////////////our email

            string body = String.Format("\n \n A new advertisement has just been created.");

            string information = String.Format("A advertisement has been created with OneFarm");

            string signature = String.Format(" \n \n OneFarm Admin Team,\n Advertisements,\n the18th.org, \n onefarmads@gmail.com, \n \n Problems with advertisement please call 806-805-4249");


            MailMessage myMessage = new MailMessage("onefarmads@gmail.com", "onefarmads@gmail.com");

            myMessage.Subject = information;
            myMessage.Body = body + " \n " + ourCompanyInfo + " \n " +
                                        "Company Name :" + companyName + "\n \n" +
                                        "Phone :" + phone + " \n \n" +
                                        "Customer Email :" + email + " \n \n" +
                                        signature;

            ///////////////////////Customer Email

            string customerAccountInfo = "\n Your ad has been started.";

            var customerEmail = "";

            customerEmail = email;

            string customerbody = String.Format("\n \n \n Thank you for starting a advertisement! \n");

            string customerinformation = String.Format("Advertisement with OneFarm");

            string customerSignature = String.Format(" \n \n OneFarm Admin Team,\n Advertisements,\n the18th.org, \n onefarmads@gmail.com, \n \n Problems with advertisement please call 806-805-4249");


            MailMessage customerMessage = new MailMessage(customerEmail, customerEmail);

            customerMessage.Subject = customerinformation;
            customerMessage.Body = customerbody + " \n " + customerAccountInfo + " \n " +
                                   customerSignature;

            ////////////////////////Customer Email End

            SmtpClient smptClient = new SmtpClient("smtp.gmail.com", 25);


            smptClient.Credentials = new System.Net.NetworkCredential()
            {

                UserName = "onefarmads@gmail.com",
                Password = "xfmtmeurxbfnnlqi"

            };

            smptClient.EnableSsl = true;
            smptClient.Send(myMessage);


            try
            {

                smptClient.Send(myMessage);

                smptClient.Send(customerMessage);
            }


            catch (Exception ex)
            {

                string message = ex.Message;

            }


        }



    }
}