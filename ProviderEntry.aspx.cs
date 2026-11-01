using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The18th.Exceptions;

namespace The18th
{
    public partial class ProviderEntry : System.Web.UI.Page
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
            The18th.Areas.Directory.DirectoryDTOs.ServicePartnerDto mySetUp = new The18th.Areas.Directory.DirectoryDTOs.ServicePartnerDto();
            mySetUp.ServicePartnerID = Guid.NewGuid();
            mySetUp.ListNumber = createProviderNumber();
            mySetUp.ServiceImage = "/MarketImages/procpic.jpg";
            mySetUp.ServiceType = serviceTypeDropDownList.SelectedValue;
            mySetUp.ServiceDescription = descriptionTextBox.Text;
            mySetUp.CompanyName = companyNameTextBox.Text;
            mySetUp.RepresentativeName = representativeTextBox.Text;
            mySetUp.Location = locationDropDownList.SelectedValue;
            mySetUp.Phone = phoneTextBox.Text;
            mySetUp.Email = emailTextBox.Text;
            mySetUp.Facebook = facebookTextBox.Text;
            mySetUp.Twitter = twitterTextBox.Text;
            mySetUp.WebAddress = webTextBox.Text;


            The18th.Areas.Directory.DirectoryDTOs.ServicePartnerDto myAww = new The18th.Areas.Directory.DirectoryDTOs.ServicePartnerDto();
            myAww.ServicePartnerID = mySetUp.ServicePartnerID;
            myAww.ListNumber = mySetUp.ListNumber;
            myAww.ServiceImage = mySetUp.ServiceImage;
            myAww.ServiceType = mySetUp.ServiceType;
            myAww.ServiceDescription = mySetUp.ServiceDescription;
            myAww.CompanyName = mySetUp.CompanyName;
            myAww.RepresentativeName = mySetUp.RepresentativeName;
            myAww.Location = mySetUp.Location;
            myAww.Phone = mySetUp.Phone;
            myAww.Email = mySetUp.Email;
            myAww.Facebook = mySetUp.Facebook;
            myAww.Twitter = mySetUp.Twitter;
            myAww.WebAddress = mySetUp.WebAddress;


            try
            {


                if (myAww.CompanyName.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (myAww.RepresentativeName.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (myAww.Location == "Select Location...")
                    throw new RequiredException("please complete all required fields");

                if (myAww.Location.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (myAww.Phone.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (myAww.Email.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");


                //
                The18th.Areas.Directory.Data.ServicePartnerManager.InsertAProvider(myAww);

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



            Response.Redirect("~/ProviderConfirmation.aspx?firstName=" + myAww.CompanyName);


            //Continue through here if we are allowing provider photo
            //Response.Redirect("~/ProvPhotoEntry.aspx?servType=" + myAww.ServiceType
            //+ "&firstName=" + myAww.CompanyName
            //+ "&lastName=" + myAww.RepresentativeName
            //+ "&location=" + myAww.Location
            //+ "&phone=" + myAww.Phone
            //+ "&email=" + myAww.Email
            //);


        }



        ////Not Implemented
        private string createProviderNumber()
        {

            Random random = new Random();
            random.Next(59864343, 87395235);

            int myProv = random.Next();

            int provSeed = int.Parse(myProv.ToString());

            var myProvNumber = String.Format("{0: 00000000}", provSeed);

            ViewState.Add("VENSeed", myProvNumber);

            return (myProvNumber);
        }


        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");

        }




    }
}