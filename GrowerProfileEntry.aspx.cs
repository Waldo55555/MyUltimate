using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class GrowerProfileEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //member Info comes in here

            ////////2nd Level
            HttpCookie memberCookie = Request.Cookies["MemberCookieInfo"];
            string membershipNumber = memberCookie["memberNumber"];
            string accountNumber = memberCookie["accountNumber"];

            ViewState.Add("ExistingAccountNum", accountNumber);

            var memNumber = accountNumber.Trim();


            //try
            //{

            //    if (string.IsNullOrEmpty(memNumber))
            //        throw new BadNavigationException("Sorry....You Are In The Wrong Place.");

            //}


            //catch (BadNavigationException ex)
            //{

            //    string message = ex.Message;

            //    exceptionLabel.Text = message;

            //    Server.TransferRequest("/Default.aspx");

            //    return;

            //}
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {

            resultLabel.Text = ViewState["ExistingAccountNum"].ToString();



            //To Auto Populate Name,Phone,Email
            The18th.Areas.MemberShip.MemberShipDTOs.MembershipDto currencyMembership = new The18th.Areas.MemberShip.MemberShipDTOs.MembershipDto();
            currencyMembership.AccountNumber = resultLabel.Text;

            var pulledMembership = The18th.Areas.MemberShip.Data.MembershipManager.GetMembershipByAccountNumber(currencyMembership.AccountNumber);


            The18th.Areas.Growers.GrowersDTOs.GrowerProfileDto myGrower = new The18th.Areas.Growers.GrowersDTOs.GrowerProfileDto();
            myGrower.GrowerNumber = createGrowerNumber().Trim();
            myGrower.GrowerType = farmTypeDropDownList.SelectedValue;
            //myGrower.GrowerName = farmNameTextBox.Text;
            //myGrower.GrowerPhone = phoneTextBox.Text;
            //myGrower.GrowerEmail = emailTextBox.Text;
            //Autopopulated
            myGrower.GrowerName = pulledMembership.ScreenName;
            myGrower.GrowerPhone = pulledMembership.Phone;
            myGrower.GrowerEmail = pulledMembership.Email;
            myGrower.Representative = representativeDropDownList.SelectedValue;


            ///////////Format Phone
            double phone = double.Parse(myGrower.GrowerPhone);
            var fullPhone = String.Format("{0: (000)-000-0000}", phone);
            myGrower.GrowerPhone = fullPhone.Trim();
            /////////////Format Phone End

            The18th.Areas.Meek.Data.RunUpAdminManager.AddGrowerProfile(myGrower);

            ////3rd level of three level authentication start
            ////////Cookie Start
            HttpCookie cookie = new HttpCookie("GrowerCookieInfo");
            cookie["growerNumber"] = myGrower.GrowerNumber;
            cookie["growerName"] = myGrower.GrowerName;
            cookie["growerType"] = myGrower.GrowerType;
            //Use Once
            cookie["accountNumber"] = resultLabel.Text;
            Response.Cookies.Add(cookie);
            /////////Cookie End

            //Watch account number
            Response.Redirect("~/GrowerLocationEntry.aspx");



        }


        public The18th.Areas.Growers.GrowersDTOs.GrowerProfileDto formatPhone(The18th.Areas.Growers.GrowersDTOs.GrowerProfileDto set)
        {

            The18th.Areas.Growers.GrowersDTOs.GrowerProfileDto createPhone = new The18th.Areas.Growers.GrowersDTOs.GrowerProfileDto();
            createPhone.GrowerPhone = set.GrowerPhone;

            var fullPhone = String.Format("{0: (000)-000-0000}", createPhone.GrowerPhone);

            The18th.Areas.Growers.GrowersDTOs.GrowerProfileDto completePhone = new The18th.Areas.Growers.GrowersDTOs.GrowerProfileDto();
            completePhone.GrowerPhone = fullPhone;

            return (completePhone);
        }


        private string createGrowerNumber()
        {

            Random random = new Random();
            random.Next(59864343, 87395235);

            int mySeed = random.Next();

            int farmSeed = int.Parse(mySeed.ToString());

            var myFarmNumber = String.Format("{0: 00000000}", farmSeed);

            ViewState.Add("FARMSeed", myFarmNumber);


            return (myFarmNumber);
        }

        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");


        }


    }
}