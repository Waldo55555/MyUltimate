using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The18th.Exceptions;

namespace The18th
{
    public partial class MembershipEntry2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //only 1st level should come in here.
            //First Point of Entry to MembershipAPI

            string myInvitationNumber = Request.QueryString["accountNumber"];

            var inviteNumber = myInvitationNumber.Trim();

            ViewState.Add("ExistingAccountNum", inviteNumber);

            if (!IsPostBack)
            {

                MembershipMultiView.ActiveViewIndex = 0;
 
            }


        }


        protected void phoneButton_Click(object sender, EventArgs e)
        {

            MembershipMultiView.ActiveViewIndex = 1;

        }
        protected void screenNameButton_Click(object sender, EventArgs e)
        {

            MembershipMultiView.ActiveViewIndex = 2;

        }

        protected void memberTypeButton_Click(object sender, EventArgs e)
        {

            MembershipMultiView.ActiveViewIndex = 3;
        }

        protected void faceButton_Click(object sender, EventArgs e)
        {
            MembershipMultiView.ActiveViewIndex = 4;
        }

        protected void firstNameButton_Click(object sender, EventArgs e)
        {
            MembershipMultiView.ActiveViewIndex = 5;
        }

        protected void lastNameButton_Click(object sender, EventArgs e)
        {
            MembershipMultiView.ActiveViewIndex = 6;
        }

        protected void emailButton_Click(object sender, EventArgs e)
        {
            MembershipMultiView.ActiveViewIndex = 7;
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {

            //MembershipMultiView.ActiveViewIndex = 8;

            //Remove to allow anonymous access....................................................
            resultLabel.Text = ViewState["ExistingAccountNum"].ToString();

            //Fist and only place id and account number set
            The18th.Areas.MemberShip.MemberShipDTOs.MembershipDto mySetUp = new The18th.Areas.MemberShip.MemberShipDTOs.MembershipDto();
            mySetUp.MembershipID = Guid.NewGuid();
            mySetUp.AccountNumber = resultLabel.Text.Trim();
            //Implement
            mySetUp.MembershipNumber = createMembershipNumber().Trim();
            mySetUp.CooperativeNumber = "Not Used";
            mySetUp.MemberImage = "No Data";
            mySetUp.ImageData = new byte[0];
            mySetUp.County = "Not Used";
            mySetUp.ScreenName = screenNameTextBox.Text;
            mySetUp.MemberType = memberTypeDropDownList.SelectedValue;
            mySetUp.CropFocus = "Pending";
            mySetUp.MemberFocus = "Home Gardening";
            //mySetUp.FanbaseUrl = fanbaseTextBox.Text;
            //mySetUp.TwitterUrl = twitterTextBox.Text;
            //mySetUp.InstagramUrl = instaTextBox.Text;
            mySetUp.FirstName = firstNameTextBox.Text;
            mySetUp.LastName = lastNameTextBox.Text;
            mySetUp.Phone = americanPhoneTextBox.Text;
            mySetUp.Email = emailTextBox.Text;
            mySetUp.EmailCheck = "";
            mySetUp.MemberStatus = The18th.Enums.MemberStatus.Pending.ToString();
            mySetUp.CreationDate = DateTime.Now.AddMinutes(1);
            mySetUp.MembershipStartDate = DateTime.Now.AddMinutes(1);
            mySetUp.MembershipEndDate = DateTime.Now.AddDays(120);
            mySetUp.CreationDate = DateTime.Now.AddMinutes(1);
            mySetUp.FavoriteVendorCount = 0;


            //Append Here
            StringBuilder sb = new StringBuilder();
            sb.Append("https://www.fanbase.app/@"); 
            sb.Append(fanbaseTextBox.Text);

            mySetUp.FanbaseUrl = sb.ToString();



            try
            {


                if (mySetUp.FirstName.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (mySetUp.LastName.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (mySetUp.Phone.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (mySetUp.Email.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");
                //New Work
                if (mySetUp.ScreenName.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (mySetUp.MemberType == "Select Member Type...")
                    throw new Exceptions.RequiredException("please complete all required fields");

                //if (mySetUp.FanbaseUrl == "Select Group...")
                //    throw new Exceptions.RequiredException("please complete all required fields");


                ////First Entry of Member Cookie

                ////2 second level of three level authentication
                //////////Cookie Start
                HttpCookie cookie = new HttpCookie("MemberCookieInfo");
                cookie["memberNumber"] = mySetUp.MembershipNumber;
                cookie["accountNumber"] = resultLabel.Text;
                Response.Cookies.Add(cookie);
                ///////////Cookie End

                if (Page.IsValid)
                {

                    The18th.Areas.MemberShip.Data.MembershipManager.AddMembership(mySetUp);

                    Response.Redirect("~/ProfilePhoto.aspx?accountNumber=" + mySetUp.AccountNumber

                    );
                }

                else
                {
                    return;
                }

            }


            catch (NoAccountFoundException ex)
            {

                string message = ex.MessageError;

                Response.Redirect("~/NoAccountFound.aspx");
            }


            //catch (FormatException ex)
            //{

            //    string message = ex.Message;

            //    exceptionLabel.Text = "Please Correct Following Errors";

            //    phoneErrorLabel.Text = message;

            //    return;

            //}

            catch (RequiredException ex)
            {
                string message = ex.MessageError;

                exceptionLabel.Text = message;

                return;

            }

            catch (NotCompleteException ex)
            {
                string message = ex.Message;

                exceptionLabel.Text = message;

                return;

            }

            catch (System.NullReferenceException ex)
            {
                string message = ex.Message;

                Response.Redirect("~/RequiredError.aspx");
            }

            catch (Exception ex)
            {
                string message = "";
                message = ex.Message;

            }


        }

        private string createMembershipNumber()
        {
            Random random = new Random();
            random.Next(59864343, 87395235);

            int myMem = random.Next();

            int memSeed = int.Parse(myMem.ToString());

            var myMemberNumber = String.Format("{0: 00000000}", memSeed);

            string memberPrefix = "ma".Trim();
            StringBuilder build = new StringBuilder();
            build.Append(memberPrefix);
            build.Append(myMemberNumber);

            ViewState.Add("MEMSeed", build.ToString().Trim());

            return (build.ToString().Trim());

        }


        //First Entry of Page Level Error Reporting
        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");

        }



    }
}