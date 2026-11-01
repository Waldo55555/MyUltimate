using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The18th.Exceptions;

namespace The18th
{
    public partial class AdTypeEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie mygeneralAdcookie = Request.Cookies["GeneralAdInfo"];
            string companyName = mygeneralAdcookie["companyName"];
            string phone = mygeneralAdcookie["phone"];
            string email = mygeneralAdcookie["email"];
            string account = mygeneralAdcookie["account"];

            HttpCookie ante2Cookie = Request.Cookies["AnteUp2"];
            string campTotal = ante2Cookie["campTotal"];
            string bannerElection = ante2Cookie["bannerElection"];
            string deposit = ante2Cookie["deposit"];
            string campSchedule = ante2Cookie["campSchedule"];

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


            if (!Page.IsPostBack)
            {

                campaignMessageLabel.Visible = false;
                campaignTotalLabel.Visible = false;

            }



        }

        protected void submitButton_Click(object sender, EventArgs e)
        {


            HttpCookie mygeneralAdcookie = Request.Cookies["GeneralAdInfo"];
            string companyName = mygeneralAdcookie["companyName"];
            string phone = mygeneralAdcookie["phone"];
            string email = mygeneralAdcookie["email"];
            string account = mygeneralAdcookie["account"];
                       

            try
            {

                The18th.Areas.Ads.AdDTOs.AdTypeDto adSpecs = new The18th.Areas.Ads.AdDTOs.AdTypeDto();
                adSpecs.AccountNumber = account;
                adSpecs.AdType = "";
                adSpecs.AdStatus = "Pending";
                adSpecs.Deposit = 0.00;
                adSpecs.EstimatedTotal = 0.00;
                adSpecs.Tax = 0.00;
                              

                if (adTypeDropDownList.SelectedValue == "Basic")
                {
                    adSpecs.AdType = "BasicAd";
                    adSpecs.EstimatedTotal = 99.99;
                    adSpecs.Deposit = 9.99;
                    adSpecs.Tax = 8.25;
                    adSpecs.AdStatus = "Pending";

                    //double scheduleCost = 20.00;

                    //The18th.Service.AdService myTotal = new The18th.Service.AdService();
                    //var calculatedTotal = myTotal.CalculateTotal(bannerCost, scheduleCost);

                    //finalAd.CampaignTotal = calculatedTotal;

                }

                if (adTypeDropDownList.SelectedValue == "Medium")
                {
                    adSpecs.AdType = "MediumAd";
                    adSpecs.EstimatedTotal = 139.99;
                    adSpecs.Deposit = 9.99;
                    adSpecs.Tax = 8.25;
                    adSpecs.AdStatus = "Pending";

                    //double scheduleCost = 20.00;

                    //The18th.Service.AdService myTotal = new The18th.Service.AdService();
                    //var calculatedTotal = myTotal.CalculateTotal(bannerCost, scheduleCost);

                    //finalAd.CampaignTotal = calculatedTotal;


                }

                if (adTypeDropDownList.SelectedValue == "Premium")
                {
                    adSpecs.AdType = "PremiumAd";
                    adSpecs.EstimatedTotal = 299.99;
                    adSpecs.Deposit = 9.99;
                    adSpecs.Tax = 8.25;
                    adSpecs.AdStatus = "Pending";

                    //double scheduleCost = 20.00;

                    //The18th.Service.AdService myTotal = new The18th.Service.AdService();
                    //var calculatedTotal = myTotal.CalculateTotal(bannerCost, scheduleCost);

                    //finalAd.CampaignTotal = calculatedTotal;

                }

                The18th.Areas.Ads.AdDTOs.AdTypeDto finalAd = new The18th.Areas.Ads.AdDTOs.AdTypeDto();
                finalAd.AdTypeID = Guid.NewGuid();
                finalAd.AccountNumber = account;
                finalAd.AdType = adSpecs.AdType;
                finalAd.EstimatedTotal = adSpecs.EstimatedTotal;
                finalAd.Deposit = adSpecs.Deposit;
                finalAd.Tax = adSpecs.Tax;
                finalAd.AdStatus = adSpecs.AdStatus;

                if (finalAd.AdType == "Select Ad Type...")
                    throw new Exceptions.RequiredException("please complete all required fields");


                //finalAd.CampaignTotal = finalAd.CampaignTotal;
                //finalAd.AdStatus = "Pending";
                //finalAd.Deposit = 0.00;
                //finalAd.EstimatedTotal = finalAd.CampaignTotal;
                //finalAd.Tax = 8.25;

                if (Page.IsValid)
                {

                   
                    HttpCookie ante2Cookie = Request.Cookies["AnteUp2"];
                    string campTotal = ante2Cookie["campTotal"];
                    string bannerElection = ante2Cookie["bannerElection"];
                    string deposit = ante2Cookie["deposit"];
                    string campSchedule = ante2Cookie["campSchedule"];


                    The18th.Areas.Ads.Data.AdManager.InsertAdType(finalAd);

                    Response.Redirect("~/AdConfirmation.aspx?adTypeTotal=" + adSpecs.EstimatedTotal
                        + "&adType=" + finalAd.AdType
                        );

                }

                else
                {

                    //exceptionLabel.Text = "Please Correct Problems!";
                    //exceptionLabel.ForeColor = System.Drawing.Color.Red;

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