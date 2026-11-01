using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class BannerPhotoSubmission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                resultMessageLabel.Visible = false;

                viewHyperLink.Visible = false;

            }


            HttpCookie ante2Cookie = Request.Cookies["AnteUp2"];
            string campTotal = ante2Cookie["campTotal"];
            string bannerElection = ante2Cookie["bannerElection"];
            string deposit = ante2Cookie["deposit"];
            string campSchedule = ante2Cookie["campSchedule"];
           

            HttpCookie mygeneralAdcookie = Request.Cookies["GeneralAdInfo"];
            string companyName = mygeneralAdcookie["companyName"];
            string phone = mygeneralAdcookie["phone"];
            string email = mygeneralAdcookie["email"];
            string account = mygeneralAdcookie["account"];


            //new....testing
            var fullPhone = String.Format("{0: +233 (000)-000-0000}", phone);
            //new....testing end


            companyLabel.Text = companyName;
            //phoneLabel.Text = phone;
            phoneLabel.Text = fullPhone;
            emailLabel.Text = email;


        }

        protected void uploadButton_Click(object sender, EventArgs e)
        {

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

            //New
            //companyLabel.Text = ViewState["ExistingCompanyName"].ToString();
            //var fromExistingCompany = companyLabel.Text;

            //phoneLabel.Text = ViewState["ExistingPhone"].ToString();
            //var fromExistingPhone = phoneLabel.Text;

            //emailLabel.Text = ViewState["ExistingEmail"].ToString();
            //var fromExistingEmail = emailLabel.Text;

            companyLabel.Text = companyName;
            phoneLabel.Text = phone;
            emailLabel.Text = email;
          

            HttpPostedFile postedFile = photoFileUpload.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);
            int fileSize = postedFile.ContentLength;

            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".jpeg" || fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".heic" || fileExtension.ToLower() == ".heif" || fileExtension.ToLower() == ".bmp")
            {

                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                byte[] bytes = binaryReader.ReadBytes((int)stream.Length);


                //Check bytes if problem exist
                The18th.Areas.Ads.AdDTOs.BannerPhotoSubmissionDto myBannerPhoto = new The18th.Areas.Ads.AdDTOs.BannerPhotoSubmissionDto();
                //myBannerPhoto.PhotoID = 1;
                myBannerPhoto.BannerExtention = fileName;
                myBannerPhoto.CampaignNumber = account;
                myBannerPhoto.CompanyName = companyName;
                myBannerPhoto.Name = companyName;
                myBannerPhoto.BannerName = "Client Banner";
                myBannerPhoto.Frequency = "";
                myBannerPhoto.Size = fileSize;
                myBannerPhoto.ImageData = bytes;  


                string cs = ConfigurationManager.ConnectionStrings["OneStateData"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {

                    SqlCommand cmd = new SqlCommand("spInsertBannerPhoto", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramCampaignNumber = new SqlParameter()
                    {
                        ParameterName = "@CampaignNumber",
                        Value = myBannerPhoto.CampaignNumber
                    };
                    cmd.Parameters.Add(paramCampaignNumber);

                    SqlParameter paramBannerExtention = new SqlParameter()
                    {
                        ParameterName = "@BannerExtention",
                        Value = myBannerPhoto.BannerExtention
                    };
                    cmd.Parameters.Add(paramBannerExtention);

                    SqlParameter paramFrequency = new SqlParameter()
                    {
                        ParameterName = "@Frequency",
                        Value = myBannerPhoto.Frequency
                    };
                    cmd.Parameters.Add(paramFrequency);


                    SqlParameter paramCompanyName = new SqlParameter()
                    {
                        ParameterName = "@CompanyName",
                        Value = myBannerPhoto.CompanyName
                    };
                    cmd.Parameters.Add(paramCompanyName);


                    SqlParameter paramName = new SqlParameter()
                    {
                        ParameterName = "@Name",
                        Value = myBannerPhoto.Name
                    };
                    cmd.Parameters.Add(paramName);

                    SqlParameter paramBannerName = new SqlParameter()
                    {
                        ParameterName = "@BannerName",
                        Value = myBannerPhoto.BannerName
                    };
                    cmd.Parameters.Add(paramBannerName);


                    SqlParameter paramSize = new SqlParameter()
                    {
                        ParameterName = "@Size",
                        Value = myBannerPhoto.Size

                    };
                    cmd.Parameters.Add(paramSize);

                    SqlParameter paramImageData = new SqlParameter()
                    {
                        ParameterName = "@ImageData",
                        Value = bytes
                    };
                    cmd.Parameters.Add(paramImageData);
                    //cmd.Parameters.Add("@ImageData", SqlDbType.VarBinary).Value = bytes;


                    SqlParameter paramNewId = new SqlParameter()
                    {
                        ParameterName = "@NewId",
                        Value = -1,
                        Direction = ParameterDirection.Output,
                    };
                    cmd.Parameters.Add(paramNewId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                  
                    resultMessageLabel.Visible = true;

                    resultMessageLabel.Text = "Upload Complete";

                    resultMessageLabel.ForeColor = System.Drawing.Color.Green;

                    viewHyperLink.Visible = true;

                    viewHyperLink.NavigateUrl = "~/BannerPhotoEntryReview.aspx?Id=" + cmd.Parameters["@NewId"].Value.ToString();

                    return;

                }

            }

            else
            {

                resultMessageLabel.Visible = true;

                resultMessageLabel.Text = "Upload a valid photo";

                resultMessageLabel.ForeColor = System.Drawing.Color.Red;

                viewHyperLink.Visible = false;
            }



        }

        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");


        }



    }
}