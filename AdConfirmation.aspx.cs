using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class AdConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Current End..2.3.2023
            string _adTypeTotal = Request.QueryString["adTypeTotal"];
                     
            ViewState.Add("ExistingAdTypeTotal", _adTypeTotal);


            string _adType = Request.QueryString["adType"];

            ViewState.Add("ExistingAdType", _adType);

            HttpCookie mygeneralAdcookie = Request.Cookies["GeneralAdInfo"];
            string companyName = mygeneralAdcookie["companyName"];
            string phone = mygeneralAdcookie["phone"];
            string email = mygeneralAdcookie["email"];
            string account = mygeneralAdcookie["account"];

            HttpCookie ante2Cookie = Request.Cookies["AnteUp2"];
            string campTotal = ante2Cookie["campTotal"];
            string bannerElection = ante2Cookie["bannerElection"];
            string deposit = ante2Cookie["deposit"];
            string campSchedule = ante2Cookie["campSchedule"];

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {

            adTypeLabel.Text = ViewState["ExistingAdTypeTotal"].ToString();

            adTotalLabel.Text = ViewState["ExistingAdType"].ToString();
                      
            HttpCookie mygeneralAdcookie = Request.Cookies["GeneralAdInfo"];
            string companyName = mygeneralAdcookie["companyName"];
            string phone = mygeneralAdcookie["phone"];
            string email = mygeneralAdcookie["email"];
            string account = mygeneralAdcookie["account"];

            HttpCookie ante2Cookie = Request.Cookies["AnteUp2"];
            string campTotal = ante2Cookie["campTotal"];
            string bannerElection = ante2Cookie["bannerElection"];
            string deposit = ante2Cookie["deposit"];
            string campSchedule = ante2Cookie["campSchedule"];
                      
            The18th.Areas.Ads.AdDTOs.AdvertisementDto doneAd = new The18th.Areas.Ads.AdDTOs.AdvertisementDto();
            doneAd.AdvertisementID = Guid.NewGuid();
            doneAd.AccountNumber = account;
            doneAd.CompanyName = companyName;
            doneAd.Phone = phone;
            doneAd.Email = email;
            doneAd.CampaignType = "Not Sent In";
            doneAd.CampaignSchedule = campSchedule;
            doneAd.AdType = adTypeLabel.Text;
            doneAd.TargetLocation = "Not Sent In";
            //doneAd.BannerDesign = "Reset";
            doneAd.DesignBanner = bannerElection;
            //check
            doneAd.CampaignTotal = double.Parse(campTotal);

            sendAdvertisementEmail(doneAd);

            Response.Redirect("~/Default.aspx");

        }


        public static void sendAdvertisementEmail(The18th.Areas.Ads.AdDTOs.AdvertisementDto myAd)
        {

            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            string ourCompanyInfo = "\n \n Advertisement info is... \n";

            string companyName = myAd.CompanyName;

            string phone = myAd.Phone;

            string email = myAd.Email;

            //string from = "Avatar Growers";

            //////////////////////////our email

            string body = String.Format("Client:" + " " + companyName + " " + "has created a " + " " + myAd.AdType + " " + "Ad to set " + myAd.CampaignSchedule + " " + "Please take immediate action to review the clients Banner." + "\n <br />");

            string ourSubjectinformation = String.Format("Advertisement with Avatar Growers");

            string step1 = String.Format("1. Contact the client via phone:" + phone + " " + "and Email:" + " " + email + " " + "to verify the clients contact information. An ad cannot be approved or scheduled without verbal contact." + "\n <br />");

            string step2 = String.Format("2. Check the clients \"Banner Election\" on the platform. If banner election is yes, verify the banner meets quality standards and other submission guidlines." + "\n <br />");

            string step3 = String.Format("3. Check payment or initiate billing and follow \"Ad Submission Procedure\" to start ad." + "\n <br />");

            string step4 = String.Format("4. If banner election is Yes, Check payment or initiate billing and assign design to available designer on platform." + "\n <br />");

            //string signatureImage = String.Format("<img src=" + "\"https://the18thstorage.blob.core.windows.net/the18thcontainer/myFavIcon.png\"" + "/>");

            string signatureImage = String.Format("<img src=" + "\"https://the18thstorage.blob.core.windows.net/the18thcontainer/emailAg.png\"" + "height:60px; width:60px; />" + "\n <br />");

            string signature = String.Format(" \n \n AvatarGrowers,\n <br /> Advertisement Team,\n <br /> avatargrowers.com, \n <br /> onefarmads@gmail.com, \n \n <br /> Problems with advertisement please call 806-805-4249");

            //MailMessage myMessage = new MailMessage("avatargrowers@gmail.com", "avatargrowers@gmail.com");
            MailMessage myMessage = new MailMessage("onefarmads@gmail.com", "avatargrowers@gmail.com");
            myMessage.IsBodyHtml = true;
            myMessage.Subject = ourSubjectinformation;
            myMessage.Body = body + " \n " + step1 + " \n " +
                                        step2 + "\n \n" +
                                        step3 + "\n \n" +
                                        step4 + "\n \n" +
                                        "This client requires banner design:" + myAd.DesignBanner + "\n \n" +
                                        "Campaign Total:$" + myAd.CampaignTotal + ".00" + " \n \n <br />" +
                                        signatureImage + "\n \n \n <br />" +
                                        signature;

            ///////////////////////Customer Email
            //2
            string accountInfo = "\n Your" + " " + myAd.AdType + " " + "ad campaign total is:$" + myAd.CampaignTotal + ".00" + "Your ad campaign is pending." + "\n";

            var customerEmail = "";

            var clientStep1 = String.Format("\n Your account Number is:" + " " + myAd.AccountNumber + " " + " Please note and save your account number." + "\n");

            var clientStep2 = String.Format("\n You will recieve notification when your ad is ready for your approval \n");

            var clientStep3 = String.Format("\n Once you recieve notification that your designs are ready please sign in to the platform to approve your ad and start your campaign \n");

            customerEmail = email;
            //1
            string customerbody = String.Format("\n \n \n Thank you for starting an advertisement! \n");

            string subjectinformation = String.Format("Advertisement with Avatar Growers");

            string customerSignature = String.Format(" \n \n AvatarGrowers,\n Advertisement Team,\n avatargrowers.com, \n onefarmads@gmail.com, \n \n Problems with advertisement please call 806-805-4249");


            MailMessage customerMessage = new MailMessage(customerEmail, customerEmail);

            customerMessage.Subject = subjectinformation;
            customerMessage.Body = customerbody + " \n " + accountInfo + " \n " +
                                   clientStep1 + " \n " +
                                   clientStep2 + " \n " +
                                   clientStep3 + " \n " +
                                   customerSignature;

            ////////////////////////Customer Email End

            SmtpClient smptClient = new SmtpClient("smtp.gmail.com", 25);


            smptClient.Credentials = new System.Net.NetworkCredential()
            {

                UserName = "onefarmads@gmail.com",
                Password = "xfmtmeurxbfnnlqi"
                //UserName = "avatargrowers@gmail.com",
                //Password = "wchvcbhcqitzswjb"

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




    }
}