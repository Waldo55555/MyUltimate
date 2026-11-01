using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The18th.Exceptions;

namespace The18th
{
    public partial class AdvertisementEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //string placement = "Advertisements";

            //SlideAd(placement);

            //try
            //{

            //    if (Page.IsPostBack == false)
            //    {

            //        //userCountLabel.Text = Application.Get("userCount").ToString();

            //    }

            //}

            //catch (Exception ex)
            //{

            //    string message = "Nothing Here";

            //    message = ex.Message;

            //}




            //if (!Page.IsPostBack)
            //{

            //    campaignMessageLabel.Visible = false;
            //    campaignTotalLabel.Visible = false;

            //}


        }

        protected void submitButton_Click(object sender, EventArgs e)
        {

            //if (Page.IsValid)
            //{


            try
            {

                The18th.Areas.Ads.AdDTOs.AdvertisementDto adSpecs = new The18th.Areas.Ads.AdDTOs.AdvertisementDto();
                adSpecs.AdType = "";
                adSpecs.CampaignTotal = 0.0;

                if (adTypeDropDownList.SelectedValue == "Basic")
                {
                    adSpecs.AdType = "BasicAd";
                    adSpecs.CampaignTotal = 99.99;

                }

                if (adTypeDropDownList.SelectedValue == "Medium")
                {
                    adSpecs.AdType = "MediumAd";
                    adSpecs.CampaignTotal = 139.99;
                }

                if (adTypeDropDownList.SelectedValue == "Premium")
                {
                    adSpecs.AdType = "PremiumAd";
                    adSpecs.CampaignTotal = 299.99;
                }

                The18th.Areas.Ads.AdDTOs.AdvertisementDto finalAd = new The18th.Areas.Ads.AdDTOs.AdvertisementDto();
                finalAd.AdvertisementID = Guid.NewGuid();
                finalAd.AccountNumber = createAdNumber();
                finalAd.CompanyName = companyNameTextBox.Text;
                finalAd.Phone = companyPhoneTextBox.Text;
                finalAd.Email = companyEmailTextBox.Text;
                finalAd.CampaignType = campaignTypeDropDownList.SelectedValue;
                finalAd.CampaignSchedule = scheduleTypeDropDownList.SelectedValue;
                finalAd.AdType = adSpecs.AdType;
                finalAd.TargetLocation = targetLocationDropDownList.SelectedValue;
                finalAd.BannerDesign = designCheckBox.Checked;


                if (finalAd.BannerDesign == true)
                {
                    double bannerCost = 149.00;

                    if (finalAd.CampaignSchedule == "Daily")
                    {
                        double scheduleCost = 20.00;

                        The18th.Service.AdService myTotal = new The18th.Service.AdService();
                        var calculatedTotal = myTotal.CalculateTotal(bannerCost, scheduleCost);

                        finalAd.CampaignTotal = calculatedTotal;

                    }

                    else if (finalAd.CampaignSchedule == "Weekly")
                    {
                        double scheduleCost = 10.00;

                        The18th.Service.AdService myTotal = new The18th.Service.AdService();
                        var calculatedTotal = myTotal.CalculateTotal(bannerCost, scheduleCost);

                        finalAd.CampaignTotal = calculatedTotal;

                    }

                    else if (finalAd.CampaignSchedule == "Monthly")
                    {
                        double scheduleCost = 5.00;

                        The18th.Service.AdService myTotal = new The18th.Service.AdService();
                        var calculatedTotal = myTotal.CalculateTotal(bannerCost, scheduleCost);

                        finalAd.CampaignTotal = calculatedTotal;

                    }


                }

                ///////////////////////////////////////////////////////////////////////////////            
                if (finalAd.BannerDesign == false)
                {
                    double bannerCost = 0.00;

                    if (finalAd.CampaignSchedule == "Daily")
                    {
                        double scheduleCost = 20.00;

                        The18th.Service.AdService myTotal = new The18th.Service.AdService();
                        var calculatedTotal = myTotal.CalculateTotal(bannerCost, scheduleCost);

                        finalAd.CampaignTotal = calculatedTotal;

                    }

                    else if (finalAd.CampaignSchedule == "Weekly")
                    {
                        double scheduleCost = 10.00;

                        The18th.Service.AdService myTotal = new The18th.Service.AdService();
                        var calculatedTotal = myTotal.CalculateTotal(bannerCost, scheduleCost);

                        finalAd.CampaignTotal = calculatedTotal;

                    }

                    else if (finalAd.CampaignSchedule == "Monthly")
                    {
                        double scheduleCost = 5.00;

                        The18th.Service.AdService myTotal = new The18th.Service.AdService();
                        var calculatedTotal = myTotal.CalculateTotal(bannerCost, scheduleCost);

                        finalAd.CampaignTotal = calculatedTotal;

                    }

                }


                if (finalAd.CompanyName.Trim().Length == 0)
                    throw new Exceptions.RequiredException("please complete all required fields");

                if (finalAd.Phone.Trim().Length == 0)
                    throw new Exceptions.RequiredException("please complete all required fields");

                if (finalAd.Email.Trim().Length == 0)
                    throw new Exceptions.RequiredException("please complete all required fields");

                if (finalAd.CampaignType == "Select Campaign...")
                    throw new Exceptions.RequiredException("please complete all required fields");

                if (finalAd.CampaignSchedule == "Select Campaign Schedule...")
                    throw new Exceptions.RequiredException("please complete all required fields");

                if (finalAd.AdType == "Select Ad Type...")
                    throw new Exceptions.RequiredException("please complete all required fields");

                if (finalAd.TargetLocation == "Select Target Location...")
                    throw new Exceptions.RequiredException("please complete all required fields");



                if (finalAd.BannerDesign == true)
                {

                    string bannerElection = "Yes";

                    ////////Cookie Start
                    HttpCookie adCookie = new HttpCookie("AdvertisementInfo");
                    adCookie["adType"] = finalAd.AdType;
                    adCookie["bannerElection"] = bannerElection;
                    adCookie["schedule"] = finalAd.CampaignSchedule;
                    adCookie["campTotal"] = finalAd.CampaignTotal.ToString();
                    adCookie["account"] = finalAd.AccountNumber;
                    Response.Cookies.Add(adCookie);
                    /////////Cookie End

                    Response.Redirect("~/BannerPhotoSubmission.aspx?companyName=" + finalAd.CompanyName
                       + "&phone=" + finalAd.Phone
                       + "&email=" + finalAd.Email
                      );

                }

                else if (finalAd.BannerDesign == false)
                {


                    string bannerElection = "No";


                    finalAd.CampaignTotal = finalAd.CampaignTotal;
                    finalAd.AdStatus = "Pending";
                    finalAd.Deposit = 0.00;
                    finalAd.EstimatedTotal = finalAd.CampaignTotal;
                    finalAd.Tax = 8.25;


                    ////////Cookie Start
                    HttpCookie adCookie = new HttpCookie("AdvertisementInfo");
                    adCookie["adType"] = finalAd.AdType;
                    adCookie["bannerElection"] = bannerElection;
                    adCookie["schedule"] = finalAd.CampaignSchedule;
                    adCookie["campTotal"] = finalAd.CampaignTotal.ToString();
                    adCookie["account"] = finalAd.AccountNumber;
                    Response.Cookies.Add(adCookie);
                    /////////Cookie End

                    ////////Cookie Start
                    HttpCookie genCookie = new HttpCookie("GeneralAdInfo");
                    genCookie["companyName"] = finalAd.CompanyName;
                    genCookie["phone"] = finalAd.Phone;
                    genCookie["email"] = finalAd.Email;
                    Response.Cookies.Add(genCookie);
                    /////////Cookie End

                    The18th.Areas.Ads.Data.AdManager.InsertAdvertisement(finalAd);

                    Response.Redirect("~/AdConfirmation.aspx");

                }


            }


            catch (RequiredException ex)
            {

                string message = ex.MessageError;

                exceptionLabel.Text = message;

                return;

            }


            catch (NullReferenceException ex)
            {
                string message = ex.Message;
            }

            catch (Exception ex)
            {
                string message = "";

                message = ex.Message;

                return;

            }

            //}


            //return;


        }

        protected void adTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (adTypeDropDownList.SelectedValue == "-1")
            {
                campaignMessageLabel.Visible = false;
                campaignTotalLabel.Visible = false;
            }

            else if (adTypeDropDownList.SelectedValue == "Basic")
            {

                campaignMessageLabel.Visible = true;
                campaignTotalLabel.Visible = true;
                campaignTotalLabel.Text = "99.99";

            }

            else if (adTypeDropDownList.SelectedValue == "Medium")
            {

                campaignMessageLabel.Visible = true;
                campaignTotalLabel.Visible = true;
                campaignTotalLabel.Text = "139.99";
            }

            else if (adTypeDropDownList.SelectedValue == "Premium")
            {

                campaignMessageLabel.Visible = true;
                campaignTotalLabel.Visible = true;
                campaignTotalLabel.Text = "299.99";
            }

            else
                return;




        }


        private string createAdNumber()
        {

            Random random = new Random();
            random.Next(59864343, 87395235);

            int myAd = random.Next();

            int adSeed = int.Parse(myAd.ToString());

            var myAdNumber = String.Format("{0: 00000000}", adSeed);

            ViewState.Add("ADSeed", myAdNumber);

            return (myAdNumber);
        }


        //ff////////////////////////////////////////////////////////////////////////////
        //protected void Timer1_Tick(object sender, EventArgs e)
        //{
        //    string placement = "Advertisements";

        //    SlideAd(placement);
        //}

        //////Original....1, 6
        //////private void SlideAd()
        //////{
        //////    Random _rand = new Random();
        //////    int i = _rand.Next(1, 4);

        //////    Image1.ImageUrl = "~/SlideAdsPics/" + i.ToString() + ".jpg";
        //////}

        ////private void SlideAd(string placement)
        ////{
        ////    Random rnd = new Random();
        ////    string[] banners = new string[5];
        ////    banners[0] = "1.jpg";
        ////    banners[1] = "2.jpg";
        ////    banners[2] = "3.jpg";
        ////    banners[3] = "4.jpg";
        ////    banners[4] = "5.jpg";
        ////    // Generate random indexes for banners.
        ////    int mIndex = rnd.Next(banners.Length);

        ////    Image1.ImageUrl = "https://the18thstorage.blob.core.windows.net/slides/" + banners[mIndex].ToString();

        ////}

        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");


        }






    }
}