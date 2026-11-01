using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The18th.Exceptions;

namespace The18th
{
    public partial class TargetLocationEntry : System.Web.UI.Page
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

           
                The18th.Areas.Ads.AdDTOs.TargetLocationDto myTarget = new The18th.Areas.Ads.AdDTOs.TargetLocationDto();
                myTarget.TargetLocationID = Guid.NewGuid();
                myTarget.AccountNumber = account;
                myTarget.TargetLocation = targetLocationDropDownList.SelectedValue;
   
                ///////////////////////////////////////////////////////////////////////////////            
                              

                if (myTarget.TargetLocation == "Select Target Location...")
                    throw new Exceptions.RequiredException("please complete all required fields");


                if (Page.IsValid)
                {

                    The18th.Areas.Ads.Data.AdManager.InsertTargetLocation(myTarget);

                    Response.Redirect("~/CampaignTypeEntry.aspx");
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