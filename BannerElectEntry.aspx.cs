using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The18th.Exceptions;

namespace The18th
{
    public partial class BannerElectEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie mygeneralAdcookie = Request.Cookies["GeneralAdInfo"];
            string companyName = mygeneralAdcookie["companyName"];
            string phone = mygeneralAdcookie["phone"];
            string email = mygeneralAdcookie["email"];
            string account = mygeneralAdcookie["account"];

            HttpCookie myAntecookie = Request.Cookies["AnteUp"];
            string campTotal = myAntecookie["campTotal"];
            string campSchedule = myAntecookie["campSchedule"];
                    
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


        }

        protected void submitButton_Click(object sender, EventArgs e)
        {

            HttpCookie mygeneralAdcookie = Request.Cookies["GeneralAdInfo"];
            string companyName = mygeneralAdcookie["companyName"];
            string phone = mygeneralAdcookie["phone"];
            string email = mygeneralAdcookie["email"];
            string account = mygeneralAdcookie["account"];

            HttpCookie myAntecookie = Request.Cookies["AnteUp"];
            string campTotal = myAntecookie["campTotal"];
            string campSchedule = myAntecookie["campSchedule"];


            try
            {

                The18th.Areas.Ads.AdDTOs.BannerElectDto ban = new The18th.Areas.Ads.AdDTOs.BannerElectDto();
                ban.AccountNumber = account;
                ban.BannerDesign = designCheckBox.Checked;
                ban.DesignBanner = "No Data";
                ban.Deposit = 0.00;
                ban.EstimatedTotal = 0.00;
                ban.Tax = 0.00;

                //if (finalAd.CompanyName.Trim().Length == 0)
                //    throw new Exceptions.RequiredException("please complete all required fields");

                if (ban.BannerDesign == true)
                {
                    double bannerCost = 149.00;

                    string bannerElection = "Yes";

                    The18th.Areas.Ads.AdDTOs.BannerElectDto ban2 = new The18th.Areas.Ads.AdDTOs.BannerElectDto();
                    ban2.AccountNumber = account;
                    ban2.BannerDesign = designCheckBox.Checked;
                    ban2.DesignBanner = "Yes";
                    ban2.Deposit = 99.00;
                    ban2.EstimatedTotal = bannerCost;
                    ban2.Tax = 0.00;

                    if (Page.IsValid)
                    {


                        ////////Cookie Start
                        HttpCookie ante2Cookie = new HttpCookie("AnteUp2");
                        ante2Cookie["bannerElection"] = ban.EstimatedTotal.ToString();
                        ante2Cookie["deposit"] = ban.Deposit.ToString();
                        ante2Cookie["campTotal"] = campTotal.ToString();
                        ante2Cookie["campSchedule"] = campSchedule;
                        Response.Cookies.Add(ante2Cookie);
                        /////////Cookie End

                        The18th.Areas.Ads.Data.AdManager.InsertBannerElect(ban2);

                        Response.Redirect("~/BannerPhotoSubmission.aspx");


                    }


                    else
                    {

                        //exceptionLabel.Text = "Please Correct Problems!";
                        //exceptionLabel.ForeColor = System.Drawing.Color.Red;

                    }


                }


                else if (ban.BannerDesign == false)
                {
                    double bannerCost = 0.00;

                    string bannerElection = "No";


                    The18th.Areas.Ads.AdDTOs.BannerElectDto ban3 = new The18th.Areas.Ads.AdDTOs.BannerElectDto();
                    ban3.AccountNumber = account;
                    ban3.BannerDesign = designCheckBox.Checked;
                    ban3.DesignBanner = "";
                    ban3.Deposit = 00.00;
                    ban3.EstimatedTotal = 00.00;
                    ban3.Tax = 0.00;

                    if (Page.IsValid)
                    {


                        ////////Cookie Start
                        HttpCookie ante2Cookie = new HttpCookie("AnteUp2");
                        ante2Cookie["bannerElection"] = ban.EstimatedTotal.ToString();
                        ante2Cookie["deposit"] = ban.Deposit.ToString();
                        ante2Cookie["campTotal"] = campTotal.ToString();
                        ante2Cookie["campSchedule"] = campSchedule;
                        Response.Cookies.Add(ante2Cookie);
                        /////////Cookie End


                        The18th.Areas.Ads.Data.AdManager.InsertBannerElect(ban3);

                        Response.Redirect("~/AdTypeEntry.aspx");
                    }

                    else
                    {

                        //exceptionLabel.Text = "Please Correct Problems!";
                        //exceptionLabel.ForeColor = System.Drawing.Color.Red;

                    }
                                                           


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