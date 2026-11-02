using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class AdInterest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                AdMultiView.ActiveViewIndex = 0;

            }
        }

        protected void companyNameButton_Click(object sender, EventArgs e)
        {
            AdMultiView.ActiveViewIndex = 1;
        }

        protected void contactPhoneButton_Click(object sender, EventArgs e)
        {
            AdMultiView.ActiveViewIndex = 2;
        }

        protected void contactEmailButton_Click(object sender, EventArgs e)
        {
            AdMultiView.ActiveViewIndex = 3;
        }

        protected void buttonFinishButton_Click(object sender, EventArgs e)
        {
            //AdMultiView.ActiveViewIndex = 1;

            if (selectRadioButton.Checked == true)
            {
                selectedDesignLabel.Text = selectRadioButton.Text;
            }
        }

        protected void completeButton_Click(object sender, EventArgs e)
        {
            ///////Profile Section
            The18th.Areas.Ads.AdDTOs.AdInterestDto myInterest = new The18th.Areas.Ads.AdDTOs.AdInterestDto();
            myInterest.AccountNumber = createAccountNumber().Trim();
            myInterest.CompanyName = companyNameTextBox.Text;
            myInterest.Phone = contactPhoneTextBox.Text;
            myInterest.Email = contactEmailTextBox.Text;
            myInterest.BannerDesign = false;
            myInterest.DesignBanner = "Pending";

            The18th.Areas.Ads.Data.AdManager.AddAdInterest(myInterest);


            Response.Redirect("~/AdInterestConfirmation.aspx?accountNumber=" + myInterest.AccountNumber
              + "&companyName=" + myInterest.CompanyName
              + "&phone=" + myInterest.Phone
              + "&email=" + myInterest.Email
              + "&designBanner=" + myInterest.DesignBanner

          );
        }


        private string createAccountNumber()
        {

            Random random = new Random();
            random.Next(59864343, 87395235);

            int mySeed = random.Next();

            int farmSeed = int.Parse(mySeed.ToString());

            var myAdAccountNumber = String.Format("{0: 00000000}", farmSeed);

            ViewState.Add("AdSeed", myAdAccountNumber);


            return (myAdAccountNumber);
        }

        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");


        }







    }
}