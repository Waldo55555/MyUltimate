using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The18th.Exceptions;

namespace The18th
{
    public partial class BannerPhotoEntryReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie ante2Cookie = Request.Cookies["AnteUp2"];
            string campTotal = ante2Cookie["campTotal"];
            string bannerElection = ante2Cookie["bannerElection"];
            string deposit = ante2Cookie["deposit"];
            string campSchedule = ante2Cookie["campSchedule"];

            HttpCookie mygeneralAdcookie = Request.Cookies["GeneralAdInfo"];
            string companyName = mygeneralAdcookie["companyName"];
            string phone = mygeneralAdcookie["phone"];
            string email = mygeneralAdcookie["email"];
            string account = mygeneralAdcookie["account"];
                    
            companyLabel.Text = companyName;
            phoneLabel.Text = phone;
            emailLabel.Text = email;

            string cs = ConfigurationManager.ConnectionStrings["OneStateData"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand("spGetBannerById", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter()
                {
                    ParameterName = "@PhotoId",
                    Value = Request.QueryString["Id"]
                };
                cmd.Parameters.Add(paramId);

                con.Open();
                byte[] bytes = (byte[])cmd.ExecuteScalar();
                //con.Close();

                string strBase64 = Convert.ToBase64String(bytes);

                vendorImage.ImageUrl = "data:Image/png;base64," + strBase64;

            }

            string simplePhotoNumber = Request.QueryString["Id"];

            ViewState.Add("ExistingSimpleId", simplePhotoNumber);

            simplePhotoLabel.Text = simplePhotoNumber;


        }

        protected void savePhotoButton_Click(object sender, EventArgs e)
        {

            HttpCookie mygeneralAdcookie = Request.Cookies["GeneralAdInfo"];
            string companyName = mygeneralAdcookie["companyName"];
            string phone = mygeneralAdcookie["phone"];
            string email = mygeneralAdcookie["email"];
            string account = mygeneralAdcookie["account"];

            The18th.Areas.Ads.AdDTOs.AdvertisementDto myOtherAd = new The18th.Areas.Ads.AdDTOs.AdvertisementDto();
            myOtherAd.AdvertisementID = Guid.Empty;
            myOtherAd.CompanyName = companyName;

            //should be pulling by id and company name
            //var pulledPhoto = The18th.Areas.Ads.Data.AdManager.GetABannerPhoto(campaignNumber);

            The18th.Areas.Ads.AdDTOs.AdvertisementDto clientAd = new The18th.Areas.Ads.AdDTOs.AdvertisementDto();
            clientAd.AdvertisementID = Guid.NewGuid();
            clientAd.AccountNumber = account;
            clientAd.CompanyName = companyName;
            clientAd.Phone = phone;
            clientAd.Email = email;
            clientAd.CampaignType = "Not Sent In";
            //clientAd.CampaignSchedule = schedule;
            //clientAd.AdType = adType;
            clientAd.TargetLocation = "Not Sent In";
          ////clientAd.BannerDesign = true;
            //clientAd.DesignBanner = bannerElection;
            //clientAd.CampaignTotal = double.Parse(campTotal);
            clientAd.AdStatus = "Pending";
            clientAd.Deposit = 0.00;
            //check
            //clientAd.EstimatedTotal = double.Parse(campTotal);
            clientAd.Tax = 8.25;

            //if (bannerElection == "Yes")
            //{
            //    clientAd.BannerDesign = true;
            //}

            //if (bannerElection == "No")
            //{
            //    clientAd.BannerDesign = false;

            //}

            //try
            //{

            //    //if (clientAd.AccountNumber.Trim().Length == 0)
            //    //    throw new NotImplementedException("Sorry Something is missing");

            //    The18th.Areas.Ads.Data.AdManager.InsertAdvertisement(clientAd);


            //}

            //catch (RequiredException ex)
            //{

            //    string message = ex.MessageError;

            //    exceptionLabel.Text = message;

            //    return;

            //}


            //catch (Exception ex)
            //{

            //    string message = "";

            //    message = ex.Message;

            //}

            //Payment First
            //Response.Redirect("~/AdCheckOut.aspx");

            //Response.Redirect("~/AdConfirmation.aspx");

            //Response.Redirect("~/AdConfirmation.aspx?companyName=" + clientAd.CompanyName
            //        + "&phone=" + clientAd.Phone
            //        + "&email=" + clientAd.Email
            //       );

            Response.Redirect("~/AdTypeEntry.aspx");

        }

        protected void editButton_Click(object sender, EventArgs e)
        {

            //Already have banner at this point

            HttpCookie mygeneralAdcookie = Request.Cookies["GeneralAdInfo"];
            string companyName = mygeneralAdcookie["companyName"];
            string phone = mygeneralAdcookie["phone"];
            string email = mygeneralAdcookie["email"];
            string account = mygeneralAdcookie["account"];

            Response.Redirect("/BannerPhotoEdit.aspx?campaignNumber=" + account);



        }




    }
}