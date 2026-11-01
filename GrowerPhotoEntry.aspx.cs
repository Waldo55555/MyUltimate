using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class GrowerPhotoEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie cookie = Request.Cookies["GrowerCookieInfo"];
            string growerNumberCookie = cookie["growerNumber"];
            string growerNameCookie = cookie["growerName"];
            //Use Once
            string growerAccountCookie = cookie["accountNumber"];

            var growAccount = growerAccountCookie.Trim();

            ViewState.Add("ExistingAccountNumber", growAccount);

            var growNumber = growerNumberCookie.Trim();

            ViewState.Add("ExistingGrowNum", growNumber);

            var growName = growerNameCookie.Trim();

            ViewState.Add("ExistingGrowName", growName);

            growerNumberLabel.Text = growNumber;




        }

        protected void submitButton_Click(object sender, EventArgs e)
        {

            growerNumberLabel.Text = ViewState["ExistingGrowNum"].ToString();

            growerAccountNumberLabel.Text = ViewState["ExistingAccountNumber"].ToString();

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
                    ///////////////////////////////////New 5-23-2023

                    //To bring over and make available avatar photo from membership
                    The18th.Areas.MemberShip.MemberShipDTOs.ProfilePhotoDto currencyMembership = new The18th.Areas.MemberShip.MemberShipDTOs.ProfilePhotoDto();
                    currencyMembership.AccountNumber = growerAccountNumberLabel.Text;

                    var pulledPhoto = The18th.Areas.MemberShip.Data.MembershipManager.GetProfilePhotoByAccountNumber(currencyMembership.AccountNumber);

                    The18th.Areas.Growers.GrowersDTOs.GrowerPhotoDto myFirstPhoto = new The18th.Areas.Growers.GrowersDTOs.GrowerPhotoDto();
                    myFirstPhoto.GrowerNumber = growerNumberLabel.Text;
                    myFirstPhoto.FullImagePath = pulledPhoto.MemberImageUrl;
                    //myFirstPhoto.PhotoData = new byte[0];


                    ///////////////////Testing End


                    The18th.Areas.Growers.GrowersDTOs.GrowerPhotoDto myPhoto = new The18th.Areas.Growers.GrowersDTOs.GrowerPhotoDto();
                    myPhoto.GrowerNumber = growerNumberLabel.Text;
                    myPhoto.FullImagePath = pulledPhoto.MemberImageUrl;
                    myPhoto.PhotoData = bytes;

                    The18th.Areas.Meek.Data.RunUpAdminManager.AddGrowerPhoto(myPhoto);


                    Response.Redirect("~/GrowerCropEntry.aspx");
                }


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