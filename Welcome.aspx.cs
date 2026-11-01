using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //2
            HttpCookie accountCookie = Request.Cookies["AccountCookieInfo"];
            string memberAccountNumber = accountCookie["accountNumber"];

            ViewState.Add("ExistingAccountNum", memberAccountNumber);

            loginLabel.Text = memberAccountNumber;

            string placement = "WelcomePage";

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

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            string placement = "WelcomePage";

            SlideAd(placement);
        }


        //New....
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


    }
}