using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The18th.Exceptions;

namespace The18th
{
    public partial class CampaignTypeEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie mygeneralAdcookie = Request.Cookies["GeneralAdInfo"];
            string companyName = mygeneralAdcookie["companyName"];
            string phone = mygeneralAdcookie["phone"];
            string email = mygeneralAdcookie["email"];
            string account = mygeneralAdcookie["account"];


            string placement = "Advertisements";

            SlideAd(placement);

            try
            {

                if (Page.IsPostBack == false)
                {

                    //userCountLabel.Text = Application.Get("userCount").ToString();

                }

            }

            catch (Exception ex)
            {

                string message = "Nothing Here";

                message = ex.Message;

            }


            //if (!Page.IsPostBack)
            //{

            //    campaignMessageLabel.Visible = false;
            //    campaignTotalLabel.Visible = false;

            //}


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

                The18th.Areas.Ads.AdDTOs.CampaignTypeDto campType = new The18th.Areas.Ads.AdDTOs.CampaignTypeDto();
                campType.AccountNumber = account;
                campType.CampaignType = campaignTypeDropDownList.SelectedValue;
                campType.CampaignSchedule = scheduleTypeDropDownList.SelectedValue;
                campType.CampaignTotal = 0.0;

                if (campaignTypeDropDownList.SelectedValue == "Aggressive")
                {
                    campType.CampaignSchedule = "Daily";
                    campType.CampaignTotal = 139.99;

                    //double scheduleCost = 20.00;

                    //The18th.Service.AdService myTotal = new The18th.Service.AdService();
                    //var calculatedTotal = myTotal.CalculateTotal(bannerCost, scheduleCost);

                    //campType.CampaignTotal = calculatedTotal;

                }

                if (campaignTypeDropDownList.SelectedValue == "Light")
                {
                    campType.CampaignSchedule = "Weekly";
                    campType.CampaignTotal = 99.99;

                    //double scheduleCost = 10.00;

                    //The18th.Service.AdService myTotal = new The18th.Service.AdService();
                    //var calculatedTotal = myTotal.CalculateTotal(bannerCost, scheduleCost);

                    //campType.CampaignTotal = calculatedTotal;


                }
                               
                ///////////////////////////////////////////////////////////////////////////////            
               
               

                if (campType.CampaignType == "Select Campaign...")
                    throw new Exceptions.RequiredException("please complete all required fields");

                if (campType.CampaignSchedule == "Select Campaign Schedule...")
                    throw new Exceptions.RequiredException("please complete all required fields");

                 
                    campType.Deposit = 0.00;
                    campType.EstimatedTotal = campType.CampaignTotal;
                    campType.Tax = 8.25;


                if (Page.IsValid)
                {

                    ////////Cookie Start......First Ante Up
                    HttpCookie anteCookie = new HttpCookie("AnteUp");
                    anteCookie["campTotal"] = campType.CampaignTotal.ToString();
                    anteCookie["campSchedule"] = campType.CampaignSchedule;
                    Response.Cookies.Add(anteCookie);
                    /////////Cookie End

                    The18th.Areas.Ads.Data.AdManager.InsertCampaignType(campType);

                    Response.Redirect("~/BannerElectEntry.aspx");
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


        //ff////////////////////////////////////////////////////////////////////////////
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            string placement = "Advertisements";

            SlideAd(placement);
        }

        //Original....1, 6
        //private void SlideAd()
        //{
        //    Random _rand = new Random();
        //    int i = _rand.Next(1, 4);

        //    Image1.ImageUrl = "~/SlideAdsPics/" + i.ToString() + ".jpg";
        //}

        private void SlideAd(string placement)
        {
            Random rnd = new Random();
            string[] banners = new string[5];
            banners[0] = "1.jpg";
            banners[1] = "2.jpg";
            banners[2] = "3.jpg";
            banners[3] = "4.jpg";
            banners[4] = "5.jpg";
            // Generate random indexes for banners.
            int mIndex = rnd.Next(banners.Length);

            Image1.ImageUrl = "https://the18thstorage.blob.core.windows.net/slides/" + banners[mIndex].ToString();

        }

        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");


        }



    }
}