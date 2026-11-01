using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The18th.Exceptions;

namespace The18th
{
    public partial class ProfessionalEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            //only adminnumber comes in here

            //2
            HttpCookie cookie = Request.Cookies["AdminCookieInfo"];
            string adminNumberCookie = cookie["adminNumber"];

            ViewState.Add("ExistingAdminNum", adminNumberCookie);

            var adminNumber = adminNumberCookie.Trim();




        }

        protected void submitButton_Click(object sender, EventArgs e)
        {

            adminNumberLabel.Text = ViewState["ExistingAdminNum"].ToString();


            //Fist and only place id and account number set
            The18th.Areas.Directory.DirectoryDTOs.PreListingProfessionalDto mySetUp = new The18th.Areas.Directory.DirectoryDTOs.PreListingProfessionalDto();
            mySetUp.PreListingProfessionalID = Guid.NewGuid();
            mySetUp.ListNumber = createProfessionalNumber();
            mySetUp.ProfessionalImage = "/Images/avatar.gif";
            mySetUp.ProfessionalType = profDropDownList.SelectedValue;
            mySetUp.ServiceDescription = profDropDownList.SelectedValue;
            mySetUp.FirstName = firstNameTextBox.Text;
            mySetUp.LastName = lastNameTextBox.Text;
            mySetUp.Location = locationDropDownList.SelectedValue;
            mySetUp.Phone = phoneTextBox.Text;
            mySetUp.Email = emailTextBox.Text;
            mySetUp.Facebook = facebookTextBox.Text;
            mySetUp.Twitter = twitterTextBox.Text;
            mySetUp.Website = webTextBox.Text;


            The18th.Areas.Directory.DirectoryDTOs.PreListingProfessionalDto myProfessional = new The18th.Areas.Directory.DirectoryDTOs.PreListingProfessionalDto();
            myProfessional.PreListingProfessionalID = mySetUp.PreListingProfessionalID;
            myProfessional.ListNumber = mySetUp.ListNumber;
            myProfessional.ProfessionalImage = mySetUp.ProfessionalImage;
            myProfessional.ProfessionalType = mySetUp.ProfessionalType;
            myProfessional.ServiceDescription = mySetUp.ServiceDescription;
            myProfessional.FirstName = mySetUp.FirstName;
            myProfessional.LastName = mySetUp.LastName;
            myProfessional.Location = mySetUp.Location;
            myProfessional.Phone = mySetUp.Phone;
            myProfessional.Email = mySetUp.Email;
            myProfessional.Facebook = mySetUp.Facebook;
            myProfessional.Twitter = mySetUp.Twitter;
            myProfessional.Website = mySetUp.Website;


            try
            {


                if (myProfessional.FirstName.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (myProfessional.LastName.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (myProfessional.Location == "Select Location...")
                    throw new RequiredException("please complete all required fields");

                if (myProfessional.Location.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (myProfessional.Phone.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (myProfessional.Email.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");


                //
                The18th.Areas.Directory.Data.ProfessionalManager.InsertAProfessional(myProfessional);

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


            Response.Redirect("~/ProfessionalConfirmation.aspx?firstName=" + myProfessional.FirstName);


            //Continue through here if we are allowing provider photo
            //First start of double up
            //////////Cookie Start
            //HttpCookie cookie = new HttpCookie("ProfessionalCookieInfo");
            //cookie["profNumber"] = mySetUp.ProfessionalNumber;
            //cookie["adminEntryNumber"] = myProfessional.MembershipNumber;
            //Response.Cookies.Add(cookie);
            ///////////Cookie End

            //Response.Redirect("~/ProfPhotoEntry.aspx?profType=" + myProfessional.ProfessionalType
            //+ "&firstName=" + myProfessional.FirstName
            //+ "&lastName=" + myProfessional.LastName
            //+ "&location=" + myProfessional.Location
            //+ "&phone=" + myProfessional.Phone
            //+ "&email=" + myProfessional.Email
            //);



        }


        //Not Implemented
        private string createProfessionalNumber()
        {

            Random random = new Random();
            random.Next(59864343, 87395235);

            int myProf = random.Next();

            int profSeed = int.Parse(myProf.ToString());

            var myProfNumber = String.Format("{0: 00000000}", profSeed);

            ViewState.Add("VENSeed", myProfNumber);

            return (myProfNumber);
        }


        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");

        }



    }
}