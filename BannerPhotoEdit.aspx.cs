using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class BannerPhotoEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie myAdcookie = Request.Cookies["AdvertisementInfo"];
            string adType = myAdcookie["adType"];
            string bannerElection = myAdcookie["bannerElection"];
            string schedule = myAdcookie["schedule"];
            string campTotal = myAdcookie["campTotal"];
            string account = myAdcookie["account"];

            string cs = ConfigurationManager.ConnectionStrings["OneStateData"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand("spEditBannerPhoto", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramCampaignNumber = new SqlParameter()
                {
                    ParameterName = "@CampaignNumber",
                    Value = account
                    //Value = Request.QueryString["farmNumber"]

                };
                cmd.Parameters.Add(paramCampaignNumber);

                con.Open();
                byte[] bytes = (byte[])cmd.ExecuteScalar();
                //con.Close();

                string strBase64 = Convert.ToBase64String(bytes);

                bannerImage.ImageUrl = "data:Image/png;base64," + strBase64;

            }


            ViewState.Add("ExistingCampNum", account);

            campNumberLabel.Text = account;




        }

        protected void editPhotoButton_Click(object sender, EventArgs e)
        {

            campNumberLabel.Text = ViewState["ExistingCampNum"].ToString();

            var fromExistingCampNumber = campNumberLabel.Text;

            var pulledGrowerPhoto = The18th.Areas.Ads.Data.AdManager.GetABannerPhoto(fromExistingCampNumber);

            //////////////////////////////////////////////////////////////////////////////////////
            HttpPostedFile postedFile = photoFileUpload.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);
            int fileSize = postedFile.ContentLength;

            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".jpeg" || fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".heic" || fileExtension.ToLower() == ".heif" || fileExtension.ToLower() == ".bmp")
            {

                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                ///////////////////////////////////////////Here begin

                WebImage photo = null;
                var newFileName = "";
                var imagePath = "";
                var imageThumbPath = "";

                photo = WebImage.GetImageFromRequest();
                if (photo != null)
                {


                    HttpCookie myAdcookie = Request.Cookies["AdvertisementInfo"];
                    string adType = myAdcookie["adType"];
                    string bannerElection = myAdcookie["bannerElection"];
                    string schedule = myAdcookie["schedule"];
                    string campTotal = myAdcookie["campTotal"];
                    string account = myAdcookie["account"];

                    HttpCookie mygeneralAdcookie = Request.Cookies["GeneralAdInfo"];
                    string companyName = mygeneralAdcookie["companyName"];
                    string phone = mygeneralAdcookie["phone"];
                    string email = mygeneralAdcookie["email"];


                    The18th.Areas.Ads.AdDTOs.BannerPhotoSubmissionDto updatedPhoto = new The18th.Areas.Ads.AdDTOs.BannerPhotoSubmissionDto();
                    //updatedPhoto.PhotoID = pulledGrowerPhoto.PhotoID;
                    updatedPhoto.CampaignNumber = account;
                    updatedPhoto.BannerExtention = fileName;
                    updatedPhoto.Frequency = schedule;
                    updatedPhoto.CompanyName = companyName;
                    updatedPhoto.Name = companyName;
                    updatedPhoto.BannerName = "Client Banner";
                    updatedPhoto.Size = fileSize;
                    updatedPhoto.ImageData = bytes;

                    The18th.Areas.Ads.Data.AdManager.UpdateABannerPhoto(updatedPhoto);

                    //New Area
                    The18th.Areas.Ads.AdDTOs.AdvertisementDto clientAd = new The18th.Areas.Ads.AdDTOs.AdvertisementDto();
                    clientAd.AdvertisementID = Guid.NewGuid();
                    clientAd.AccountNumber = account;
                    clientAd.CompanyName = companyName;
                    clientAd.Phone = phone;
                    clientAd.Email = email;
                    clientAd.CampaignType = "Not Sent In";
                    clientAd.CampaignSchedule = schedule;
                    clientAd.AdType = adType;
                    clientAd.TargetLocation = "Not Sent In";
                    //clientAd.BannerDesign = true;
                    clientAd.DesignBanner = bannerElection;
                    clientAd.CampaignTotal = double.Parse(campTotal);
                    clientAd.AdStatus = "Pending";
                    clientAd.Deposit = 0.00;
                    //check
                    clientAd.EstimatedTotal = double.Parse(campTotal);
                    clientAd.Tax = 8.25;

                    if (bannerElection == "Yes")
                    {
                        clientAd.BannerDesign = true;
                    }

                    if (bannerElection == "No")
                    {
                        clientAd.BannerDesign = false;
                    }

                    The18th.Areas.Ads.Data.AdManager.InsertAdvertisement(clientAd);
                    //New Area End

                }

            }

            Response.Redirect("~/BannerEditConfirmation.aspx");

        }

        protected void savePhotoButton_Click(object sender, EventArgs e)
        {

            campNumberLabel.Text = ViewState["ExistingCampNum"].ToString();

            var banner = The18th.Areas.Ads.Data.AdManager.GetABannerPhoto(campNumberLabel.Text);

            HttpCookie myAdcookie = Request.Cookies["AdvertisementInfo"];
            string adType = myAdcookie["adType"];
            string bannerElection = myAdcookie["bannerElection"];
            string schedule = myAdcookie["schedule"];
            string campTotal = myAdcookie["campTotal"];
            string account = myAdcookie["account"];

            Response.Redirect("~/BannerEditConfirmation.aspx");


        }




    }
}