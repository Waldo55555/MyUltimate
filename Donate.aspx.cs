using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The18th.Exceptions;

namespace The18th
{
    public partial class Donate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string placement = "Donation";

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

        protected void donateButton_Click(object sender, EventArgs e)
        {

            The18th.Areas.Donations.DonationDTOs.DonateDto don = new The18th.Areas.Donations.DonationDTOs.DonateDto();
            don.DonateID = Guid.NewGuid();
            don.DonorNumber = createADonorNumber();
            don.FirstName = firstNameTextBox.Text;
            don.Phone = phoneTextBox.Text;
            don.Email = emailTextBox.Text;
            don.DonationType = donationTypeDropDownList.SelectedValue;
            don.DonationAmount = donAmountDropDownList.SelectedValue;
            don.Amount = 0.00;
            don.DonationDate = DateTime.Now;


            try
            {

                if (don.FirstName.Trim().Length == 0)
                    throw new Exceptions.RequiredException("please complete all required fields");

                if (don.Phone.Trim().Length == 0)
                    throw new Exceptions.RequiredException("please complete all required fields");

                if (don.Email.Trim().Length == 0)
                    throw new Exceptions.RequiredException("please complete all required fields");

                if (don.DonationType == "Select Donation Type...")
                    throw new Exceptions.RequiredException("please complete all required fields");

                if (don.DonationAmount == "Select Donation Amount...")
                    throw new Exceptions.RequiredException("please complete all required fields");


                if (don.DonationAmount == "5.00")
                {

                    don.Amount = double.Parse(don.DonationAmount);

                }

                else if (don.DonationAmount == "10.00")
                {

                    don.Amount = double.Parse(don.DonationAmount);

                }

                else if (don.DonationAmount == "15.00")
                {

                    don.Amount = double.Parse(don.DonationAmount);

                }

                else if (don.DonationAmount == "20.00")
                {

                    don.Amount = double.Parse(don.DonationAmount);

                }

                else if (don.DonationAmount == "25.00")
                {

                    don.Amount = double.Parse(don.DonationAmount);

                }

                else if (don.DonationAmount == "50.00")
                {

                    don.Amount = double.Parse(don.DonationAmount);

                }


                else if (don.DonationAmount == "100.00")
                {

                    don.Amount = double.Parse(don.DonationAmount);

                }


                The18th.Areas.Donations.Data.DonationManager.AddDonation(don);

            }

            catch (RequiredException ex)
            {
                string message = ex.MessageError;

                return;
            }

            catch (NullReferenceException ex)
            {
                string message = ex.Message;
            }

            catch (Exception ex)
            {
                string message = "";

                message = ex.Message;

                return;

            }

            //After Payment
            //Response.Redirect("~/DonationConfirmation.aspx");


            Response.Redirect("~/OneState/OneState/Donation?total=" + don.Amount);


            //Response.Redirect("~/Donate10.aspx?donNumber=" + don.DonorNumber
            //  + "&firstName=" + don.FirstName
            //  + "&phone=" + don.Phone
            //  + "&email=" + don.Email
            //  + "&donType=" + don.DonationType
            //  + "&donAmount=" + "10.00"
            //  + "&donDate=" + don.DonationDate
            //  );



        }

        //new 8-1-23
        public static void sendYahooMessageEmail(The18th.Areas.Donations.DonationDTOs.DonateDto completeDon)
        {


            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;


            string ourCompanyInfo = "\n \nDonation info is... \n";

            string firstName = completeDon.FirstName;

            string phone = completeDon.Phone;

            string email = completeDon.Email;

            string donorNumber = completeDon.DonorNumber;

            string donationDate = completeDon.DonationDate.ToShortDateString();

            //////////////////////////our email

            string body = String.Format("\n \n A new donation has just been created.");

            string information = String.Format("A donation has been created with OneFarm");

            string signature = String.Format(" \n \n OneFarm Admin Team,\n Donations,\n the18th.org, \n pledgethe18th@yahoo.com, \n \n Problems with donations please call 806-805-4249");

            MailMessage myMessage = new MailMessage("pledgethe18th@yahoo.com", "pledgethe18th@yahoo.com");

            myMessage.Subject = information;
            myMessage.Body = body + " \n " + ourCompanyInfo + " \n " +
                                        "Donors Name :" + firstName + "\n \n" +
                                        "Phone :" + phone + " \n \n" +
                                        "Donors Email :" + email + " \n \n" +
                                        "Donor Number :" + donorNumber + " \n \n" +
                                        "Donation Date :" + donationDate + " \n " +
                                        signature;


            ///////////////////////Donors Email

            string customerAccountInfo = "\n Your donation has been created.";

            var customerEmail = "";

            customerEmail = email;

            string customerbody = String.Format("\n \n \n Thank you for contributing! \n");

            string customerinformation = String.Format("Donation with OneFarm");

            string customerSignature = String.Format(" \n \n OneFarm Admin Team,\n Donations,\n the18th.org, \n pledgethe18th@yahoo.com, \n \n Problems with donations please call 806-805-4249");



            MailMessage customerMessage = new MailMessage(customerEmail, customerEmail);

            customerMessage.Subject = customerinformation;
            customerMessage.Body = customerbody + " \n " + customerAccountInfo + " \n " +
                                        "Please make note of your donor number :" + donorNumber + " \n \n" +
                                        "Donation Date :" + donationDate + " \n " +
                                        customerSignature;


            ////////////////////////Customer Email End



            SmtpClient smptClient = new SmtpClient("smtp.mail.yahoo.com", 465);


            smptClient.Credentials = new System.Net.NetworkCredential()
            {

                UserName = "pledgethe18th@yahoo.com",
                Password = "getSomethingDone"

            };

            smptClient.EnableSsl = true;
            smptClient.Send(myMessage);


            try
            {

                smptClient.Send(myMessage);

                smptClient.Send(customerMessage);
            }


            catch (Exception ex)
            {

                string message = ex.Message;

            }


        }


        //ff////////////////////////////////////////////////////////////////////////////
        protected void Timer1_Tick(object sender, EventArgs e)
        {

            string placement = "Donation";

            SlideAd(placement);
        }

        ////Original....1, 6
        //private void SlideAd()
        //{
        //    Random _rand = new Random();
        //    int i = _rand.Next(1, 4);

        //    Image1.ImageUrl = "~/SlideAdsPics/" + i.ToString() + ".jpg";
        //}


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


        private string createADonorNumber()
        {

            Random random = new Random();
            random.Next(59864343, 87395235);

            int myDonNum = random.Next();

            int donorNumber = int.Parse(myDonNum.ToString());

            var myDonationNumber = String.Format("{0: 00000000}", donorNumber);

            return (myDonationNumber);
        }



        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");


        }


    }
}