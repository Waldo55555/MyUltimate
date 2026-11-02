using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class AdminBannerEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                resultMessageLabel.Visible = false;

                viewHyperLink.Visible = false;

            }


            HttpCookie myAdcookie = Request.Cookies["AdminAdInfo"];
            string accountNumber = myAdcookie["accountNum"];
            string company = myAdcookie["company"];

            string _companyName = Request.QueryString["companyName"];
            string _phone = Request.QueryString["phone"];
            string _email = Request.QueryString["email"];

            ViewState.Add("ExistingCompanyName", _companyName);
            ViewState.Add("ExistingPhone", _phone);
            ViewState.Add("ExistingEmail", _email);

            companyLabel.Text = _companyName;
            phoneLabel.Text = _phone;
            emailLabel.Text = _email;



        }

        protected void uploadButton_Click(object sender, EventArgs e)
        {

            HttpCookie myAdcookie = Request.Cookies["AdminAdInfo"];
            string accountNumber = myAdcookie["accountNum"];
            string company = myAdcookie["company"];


            //New
            companyLabel.Text = ViewState["ExistingCompanyName"].ToString();
            var fromExistingCompany = companyLabel.Text;

            phoneLabel.Text = ViewState["ExistingPhone"].ToString();
            var fromExistingPhone = phoneLabel.Text;

            emailLabel.Text = ViewState["ExistingEmail"].ToString();
            var fromExistingEmail = emailLabel.Text;


            HttpPostedFile postedFile = photoFileUpload.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);
            int fileSize = postedFile.ContentLength;

            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".jpeg" || fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".heic" || fileExtension.ToLower() == ".heif" || fileExtension.ToLower() == ".bmp")
            {

                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                The18th.Areas.Ads.AdDTOs.SlideDto mySlide = new The18th.Areas.Ads.AdDTOs.SlideDto();
                mySlide.SlideID = Guid.NewGuid();
                mySlide.AccountNumber = accountNumber;
                mySlide.CompanyName = companyLabel.Text;
                mySlide.FileName = "https://the18thstorage.blob.core.windows.net/slides/" + bytes;
                mySlide.ImageData = bytes;

                try
                {

                    The18th.Areas.Ads.Data.AdManager.InsertSlide(mySlide);

                }

                catch (Exception ex)
                {
                    string message = "";

                    message = ex.Message;

                }

            }

            //Paypal.....here

            Response.Redirect("~/AdminAdConfirmation.aspx?companyName=" + companyLabel.Text
             + "&phone=" + phoneLabel.Text
             + "&email=" + emailLabel.Text
            );



        }

        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");


        }

    }
}