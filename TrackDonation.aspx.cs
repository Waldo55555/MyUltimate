using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class TrackDonation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            //HttpCookie cookie = Request.Cookies["SteeringCookieInfo"];
            //string steeringNumberCookie = cookie["SteeringNumber"];



        }

        protected void searchButton_Click(object sender, EventArgs e)
        {

            var myDonorNumber = donorNumberTextBox.Text;

            The18th.Areas.Donations.DonationDTOs.DonateDto myDonation = new The18th.Areas.Donations.DonationDTOs.DonateDto();
            myDonation.DonorNumber = myDonorNumber.Trim();

            if (myDonation.DonorNumber == myDonorNumber)
            {

                Response.Redirect("Donations/Donations/TrackHome?donorNumber=" + myDonation.DonorNumber);

            }

            else if (string.IsNullOrEmpty(myDonorNumber))
            {

                errorLabel.Text = "Please re-enter the donor number";

                errorLabel.Visible = true;

            }

            else

            errorLabel.Text = "Please re-enter the donor number";

            errorLabel.Visible = true;


        }




    }
}