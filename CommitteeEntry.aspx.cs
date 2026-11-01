using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The18th.Exceptions;

namespace The18th
{
    public partial class CommitteeEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //HttpCookie cookie = Request.Cookies["MemberCookieInfo"];
            //string memberAccountNumber = cookie["Number"];

            //ViewState.Add("ExistingMemberNum", memberAccountNumber);

            //memberNumberLabel.Text = memberAccountNumber;



        }

        protected void submitButton_Click(object sender, EventArgs e)
        {

            memberNumberLabel.Text = ViewState["ExistingMemberNum"].ToString();

            //Fist and only place id and account number set
            The18th.Areas.Committee.CommitteeDTOs.CommitteeDto mySetUp = new The18th.Areas.Committee.CommitteeDTOs.CommitteeDto();
            mySetUp.CommitteeID = Guid.NewGuid();
            mySetUp.AccountNumber = createAccountNumber();
            //mySetUp.CommitteeImage = "";
            mySetUp.CommitteeType = comDropDownList.SelectedValue;
            mySetUp.PublicAdminType = publicDropDownList.SelectedValue;
            mySetUp.Education = educationDropDownList.SelectedValue;
            mySetUp.FirstName = firstNameTextBox.Text;
            mySetUp.LastName = lastNameTextBox.Text;
            mySetUp.ScreenName = screenNameTextBox.Text;
            mySetUp.Country = countryDropDownList.SelectedValue;
            mySetUp.Location = locationDropDownList.SelectedValue;
            mySetUp.Email = emailTextBox.Text;
            mySetUp.CommitteeStartDate = DateTime.Parse(txtStartDate.Text);
            mySetUp.CommissionSetToExpire = DateTime.Parse(txtEndDate.Text);
            mySetUp.Message = "";

            The18th.Areas.Committee.CommitteeDTOs.CommitteeDto myCommittee = new The18th.Areas.Committee.CommitteeDTOs.CommitteeDto();
            myCommittee.CommitteeID = mySetUp.CommitteeID;
            myCommittee.AccountNumber = mySetUp.AccountNumber;
            myCommittee.CommitteeType = mySetUp.CommitteeType;
            myCommittee.PublicAdminType = mySetUp.PublicAdminType;
            myCommittee.Education = mySetUp.Education;
            myCommittee.FirstName = mySetUp.FirstName;
            myCommittee.LastName = mySetUp.LastName;
            myCommittee.ScreenName = mySetUp.ScreenName;
            myCommittee.Country = mySetUp.Country;
            myCommittee.Location = mySetUp.Location;
            myCommittee.Email = mySetUp.Email;
            myCommittee.CommitteeStartDate = mySetUp.CommitteeStartDate;
            myCommittee.CommissionSetToExpire = mySetUp.CommissionSetToExpire;
            myCommittee.Message = mySetUp.Message;

            try
            {


                if (myCommittee.FirstName.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (myCommittee.LastName.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (myCommittee.Location == "Select Location...")
                    throw new RequiredException("please complete all required fields");

                if (myCommittee.Location.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (myCommittee.Email.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");


                //
                The18th.Areas.Meek.Data.RunUpAdminRepository.AddCommittee(myCommittee);

            }


            catch (NoAccountFoundException ex)
            {

                string message = ex.MessageError;

                Response.Redirect("~/NoAccountFound.aspx");
            }

            catch (RequiredException ex)
            {

                string message = ex.MessageError;

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


            //First start of double up

            ////////Cookie Start
            HttpCookie cookie = new HttpCookie("CommitteeCookieInfo");
            cookie["comAcctNumber"] = mySetUp.AccountNumber;
            Response.Cookies.Add(cookie);
            /////////Cookie End

            Response.Redirect("~/ComPhotoEntry.aspx?comType=" + myCommittee.CommitteeType
            + "&firstName=" + myCommittee.FirstName
            + "&lastName=" + myCommittee.LastName
            + "&location=" + myCommittee.Location
            + "&email=" + myCommittee.Email
            );



        }


        //Not Implemented
        private string createAccountNumber()
        {

            Random random = new Random();
            random.Next(59864343, 87395235);

            int myCom = random.Next();

            int comSeed = int.Parse(myCom.ToString());

            var comAccountNumber = String.Format("{0: 00000000}", comSeed);

            ViewState.Add("VENSeed", comAccountNumber);

            return (comAccountNumber);
        }


        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");

        }



    }
}