using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class WelcomeMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ////Up for deletion
            //string _memNumber = Request.QueryString["trueBill38*67NofollowUpTo67$"].Trim();

            //2
            HttpCookie accountCookie = Request.Cookies["AccountCookieInfo"];
            string memberAccountNumber = accountCookie["accountNumber"];

            ViewState.Add("ExistingAccountNum", memberAccountNumber);

            loginLabel.Text = memberAccountNumber;

            SlideAd();


            try
            {

                if (Page.IsPostBack == false)
                {
                    userCountLabel.Text = Application.Get("userCount").ToString();
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
            SlideAd();
        }

        //Original....1, 6
        private void SlideAd()
        {
            Random _rand = new Random();
            int i = _rand.Next(1, 4);

            Image1.ImageUrl = "~/SlideAdsPics/" + i.ToString() + ".jpg";
        }

    }
}