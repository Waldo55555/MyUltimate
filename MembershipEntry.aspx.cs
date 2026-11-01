using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The18th.Exceptions;

namespace The18th
{
    public partial class MembershipEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //only 1st level should come in here.
            //First Point of Entry to MembershipAPI

            //string passedAccountNumber = Request.QueryString["trueBill38*67NofollowUpTo67$"].Trim();

            //ViewState.Add("ExistingAccountNum", passedAccountNumber);

            //var memNumber = passedAccountNumber.Trim();


            //Tower Fix ....................................................
            //2
            HttpCookie accountCookie = Request.Cookies["AccountCookieInfo"];
            string accountNumber = accountCookie["accountNumber"];

            ViewState.Add("ExistingAccountNum", accountNumber);




            try
            {

                if (string.IsNullOrEmpty(accountNumber))
                    throw new BadNavigationException("Sorry....You Are In The Wrong Place.");

            }


            catch (BadNavigationException ex)
            {

                string message = ex.Message;

                exceptionLabel.Text = message;

                Server.TransferRequest("/Default.aspx");

                return;

            }

            //To be edited by enduser on member dash
            if (!Page.IsPostBack)
            {

                string cs = ConfigurationManager.ConnectionStrings["OneFarmData"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("Select CooperativeId, CooperativeNumber, CooperativeType, CooperativeName, Location, Region, NetworkStatus From tblCooperative", con);
                    con.Open();

                    coopDropDownList.DataSource = cmd.ExecuteReader();
                    //coopDropDownList.DataTextField = "CooperativeName";
                    //coopDropDownList.DataValueField = "CooperativeNumber";
                    coopDropDownList.DataBind();

                }


                americanPhoneTextBox.Visible = false;
                ghanaPhoneTextBox.Visible = false;

            }

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {

            resultLabel.Text = ViewState["ExistingAccountNum"].ToString();


            //Fist and only place id and account number set
            The18th.Areas.MemberShip.MemberShipDTOs.MembershipDto mySetUp = new The18th.Areas.MemberShip.MemberShipDTOs.MembershipDto();
            mySetUp.MembershipID = Guid.NewGuid();
            mySetUp.AccountNumber = resultLabel.Text.Trim();
            //Implement
            mySetUp.MembershipNumber = createMembershipNumber().Trim();
            mySetUp.CooperativeNumber = coopDropDownList.SelectedValue;
            ////Set for OneFarm Initially
            //mySetUp.CooperativeNumber = "1775124145";
            mySetUp.MemberImage = "No Data";
            mySetUp.ImageData = new byte[0];
            mySetUp.Country = countryDropDownList.SelectedValue;
            mySetUp.ScreenName = screenNameTextBox.Text;
            mySetUp.MemberType = memberTypeDropDownList.SelectedValue;
            mySetUp.CropFocus = "Pending";
            mySetUp.MemberFocus = "Home Gardening";
            mySetUp.FacebookUrl = facebookTextBox.Text;
            mySetUp.TwitterUrl = "Pending";
            mySetUp.InstagramUrl = "Pending";
            //mySetUp.TwitterUrl = twitterTextBox.Text;
            //mySetUp.InstagramUrl = instaTextBox.Text;
            mySetUp.FirstName = firstNameTextBox.Text;
            mySetUp.LastName = lastNameTextBox.Text;
            mySetUp.Email = emailTextBox.Text;
            mySetUp.EmailCheck = "";
            mySetUp.MemberStatus = The18th.Enums.MemberStatus.Pending.ToString();
            mySetUp.CreationDate = DateTime.Now.AddMinutes(1);
            mySetUp.MembershipStartDate = DateTime.Now.AddMinutes(1);
            mySetUp.MembershipEndDate = DateTime.Now.AddDays(120);
            mySetUp.CreationDate = DateTime.Now.AddMinutes(1);
            mySetUp.FavoriteVendorCount = 0;

            if (mySetUp.Country == "Ghana")
            {
                mySetUp.Phone = ghanaPhoneTextBox.Text;
            }

            else if (mySetUp.Country == "U.S")
            {
                mySetUp.Phone = americanPhoneTextBox.Text;
            }


            try
            {


                //if (myMemberInfo.FirstName.Trim().Length == 0)
                //    throw new RequiredException("please complete all required fields");

                //if (myMemberInfo.LastName.Trim().Length == 0)
                //    throw new RequiredException("please complete all required fields");

                //if (myMemberInfo.Address.Trim().Length == 0)
                //    throw new RequiredException("please complete all required fields");

                //if (myMemberInfo.Location == "Select Location...")
                //    throw new RequiredException("please complete all required fields");

                //if (myMemberInfo.Location.Trim().Length == 0)
                //    throw new RequiredException("please complete all required fields");

                //if (myMemberInfo.Zip.Trim().Length == 0)
                //    throw new RequiredException("please complete all required fields");

                //if (myMemberInfo.Phone.Trim().Length == 0)
                //    throw new RequiredException("please complete all required fields");

                //if (myMemberInfo.Email.Trim().Length == 0)
                //    throw new RequiredException("please complete all required fields");


                ////First Entry of Member Cookie

                ////2 second level of three level authentication
                //////////Cookie Start
                HttpCookie cookie = new HttpCookie("MemberCookieInfo");
                cookie["memberNumber"] = mySetUp.MembershipNumber;
                cookie["accountNumber"] = resultLabel.Text;
                Response.Cookies.Add(cookie);
                ///////////Cookie End



                The18th.Areas.MemberShip.Data.MembershipManager.AddMembership(mySetUp);

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


            Response.Redirect("~/ProfilePhoto.aspx");

        }

        protected void countryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (countryDropDownList.SelectedValue == "-1")
            {
                americanPhoneTextBox.Visible = false;
                ghanaPhoneTextBox.Visible = false;
            }

            else if (countryDropDownList.SelectedValue == "Ghana")
            {
                ghanaPhoneTextBox.Visible = true;
                americanPhoneTextBox.Visible = false;
            }

            else if (countryDropDownList.SelectedValue == "U.S")
            {
                americanPhoneTextBox.Visible = true;
                ghanaPhoneTextBox.Visible = false;
            }

            else
                return;


        }



        private string createMembershipNumber()
        {
            Random random = new Random();
            random.Next(59864343, 87395235);

            int myMem = random.Next();

            int memSeed = int.Parse(myMem.ToString());

            var myMemberNumber = String.Format("{0: 00000000}", memSeed);

            //New
            string memberPrefix = "ma".Trim();

            StringBuilder build = new StringBuilder();
            build.Append(memberPrefix);
            build.Append(myMemberNumber);

            //Original...up for deletion
            ////return (build.ToString().Trim());
            ////ViewState.Add("MEMSeed", myMemberNumber);
            ////return (myMemberNumber);

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