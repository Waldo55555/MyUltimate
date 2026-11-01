using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class AdminGrowerEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //need admin cookie here
            HttpCookie adminCookie = Request.Cookies["AdminCookieInfo"];
            string myAdminNumber = adminCookie["adminNumber"];

            ViewState.Add("ExistingAdminNum", myAdminNumber);

            adminLabel.Text = myAdminNumber;


            if (!Page.IsPostBack)
            {
                ghanaTable.Visible = false;
                ghanaCountryLabel.Visible = false;
                myGhanaImage.Visible = false;
                streetNameTextBox.Visible = false;
                streetLabel.Visible = false;
                regionDropDownList.Visible = false;
                regionLabel.Visible = false;
                districtDropDownList.Visible = false;
                districtLabel.Visible = false;
                areaDropDownList.Visible = false;
                areaLabel.Visible = false;
                postalTextBox.Visible = false;
                postalLabel.Visible = false;
                //
                usTable.Visible = false;
                usCountryLabel.Visible = false;
                myUsImage.Visible = false;
                addressTextBox.Visible = false;
                addressLabel.Visible = false;
                countyDropDownList.Visible = false;
                countyLabel.Visible = false;
                zipTextBox.Visible = false;
                zipLabel.Visible = false;

            }


            if (!Page.IsPostBack)
            {

                string cs = ConfigurationManager.ConnectionStrings["OneFarmData"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd1 = new SqlCommand("Select CropAdminLookUpId, Crop, CropIndex From tblCropAdminLookUp", con);
                    con.Open();

                    greensCheckBoxList.DataSource = cmd1.ExecuteReader();
                    greensCheckBoxList.DataBind();

                }


            }


        }

        protected void submitButton_Click(object sender, EventArgs e)
        {

            adminLabel.Text = ViewState["ExistingAdminNum"].ToString();

            ///////Profile Section
            The18th.Areas.Growers.GrowersDTOs.GrowerProfileDto myGrower = new The18th.Areas.Growers.GrowersDTOs.GrowerProfileDto();
            myGrower.GrowerNumber = createGrowerNumber().Trim();
            myGrower.GrowerType = farmTypeDropDownList.SelectedValue;
            myGrower.GrowerName = screenNameTextBox.Text;
            myGrower.GrowerPhone = phoneTextBox.Text;
            myGrower.GrowerEmail = emailTextBox.Text;
            myGrower.Representative = representativeDropDownList.SelectedValue;

            ///////////Format Phone
            double phone = double.Parse(myGrower.GrowerPhone);
            var fullPhone = String.Format("{0: (000)-000-0000}", phone);
            myGrower.GrowerPhone = fullPhone.Trim();
            /////////////Format Phone End

            The18th.Areas.Meek.Data.RunUpAdminManager.AddGrowerProfile(myGrower);
            /////Profile Section End

            ///////Location Section
            The18th.Areas.Growers.GrowersDTOs.GrowerLocationInfoDto myLocation = new The18th.Areas.Growers.GrowersDTOs.GrowerLocationInfoDto();
            myLocation.GrowerNumber = myGrower.GrowerNumber;
            myLocation.GrowerName = screenNameTextBox.Text;
            myLocation.GrowerType = farmTypeDropDownList.SelectedValue;
            myLocation.Address = addressTextBox.Text;
            myLocation.Location = locationDropDownList.SelectedValue;
            myLocation.Zip = zipTextBox.Text;
            myLocation.County = countyDropDownList.SelectedValue;
            myLocation.StreetName = streetNameTextBox.Text;
            myLocation.Region = regionDropDownList.SelectedValue;
            myLocation.District = districtDropDownList.SelectedValue;
            myLocation.Area = areaDropDownList.SelectedValue;
            myLocation.PostalCode = postalTextBox.Text;
            myLocation.MapAddress = "Not Defined";
            myLocation.NavArea = "Growers";
            myLocation.Controller = "GrowersMarket";
            myLocation.Action = "GrowerMarketDash";
            myLocation.MapAddress = "";

            if (myLocation.Location == "U.S")
            {

                myLocation.DashType = "FarmPage";

                var sendAddress = formatAmericanMapAddress(myLocation);

                myLocation.MapAddress = sendAddress.MapAddress;

            }

            else if (myLocation.Location == "Ghana")
            {

                myLocation.DashType = "FarmPageGhana";

                var sendAddress = formatAfricaMapAddress(myLocation);

                myLocation.MapAddress = sendAddress.MapAddress;
                //To satisfy empty county
                myLocation.County = myLocation.Region;
            }

            The18th.Areas.Meek.Data.RunUpAdminRepository.AddGrowerLocation(myLocation);

            /////Location Section End


            ///////Market Section
            The18th.Areas.Growers.GrowersDTOs.GrowerMarketInfoDto myMarketInfo = new The18th.Areas.Growers.GrowersDTOs.GrowerMarketInfoDto();
            myMarketInfo.GrowerNumber = myGrower.GrowerNumber;
            myMarketInfo.CropTypes = cropTypeDropDownList.SelectedValue;
            myMarketInfo.StorageTypes = storageTypeDropDownList.SelectedValue;
            myMarketInfo.MarketHours = marketHoursDropDownList.SelectedValue;
            myMarketInfo.MarketDays = marketDaysDropDownList.SelectedValue;
            myMarketInfo.LandUtilizationPercentage = utilizationDropDownList.SelectedValue;
            myMarketInfo.YearsFarming = yearsDropDownList.SelectedValue;
            myMarketInfo.WebAddress = "Not Defined";
            myMarketInfo.NetworkStatus = "One Farm Networked";
            myMarketInfo.GrowerRating = "5";

            The18th.Areas.Meek.Data.RunUpAdminRepository.AddGrowerMarket(myMarketInfo);

            /////Market Section End

            ///////Photo Section

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

                    //To bring over and make available avatar photo from membership
                    The18th.Areas.MemberShip.MemberShipDTOs.ProfilePhotoDto currencyMembership = new The18th.Areas.MemberShip.MemberShipDTOs.ProfilePhotoDto();
                    currencyMembership.AccountNumber = myGrower.GrowerNumber;

                    //var pulledPhoto = The18th.Areas.MemberShip.Data.MembershipManager.GetProfilePhotoByAccountNumber(currencyMembership.AccountNumber);

                    The18th.Areas.Growers.GrowersDTOs.GrowerPhotoDto myFirstPhoto = new The18th.Areas.Growers.GrowersDTOs.GrowerPhotoDto();
                    myFirstPhoto.GrowerNumber = myGrower.GrowerNumber;
                    //myFirstPhoto.FullImagePath = pulledPhoto.MemberImageUrl;
                    //myFirstPhoto.PhotoData = new byte[0];

                    The18th.Areas.Growers.GrowersDTOs.GrowerPhotoDto myPhoto = new The18th.Areas.Growers.GrowersDTOs.GrowerPhotoDto();
                    myPhoto.GrowerNumber = myGrower.GrowerNumber;
                    //Truncates this column in database...need escape charactors
                    myPhoto.FullImagePath = "https://the18thstorage.blob.core.windows.net/the18thcontainer/avatar.gif";
                    //myPhoto.FullImagePath = "No Path";
                    myPhoto.PhotoData = bytes;

                    The18th.Areas.Meek.Data.RunUpAdminManager.AddGrowerPhoto(myPhoto);

                }


            }


            /////Photo Section End

            ///////Crop Section

            foreach (ListItem greensli in greensCheckBoxList.Items)
            {
                if (greensli.Selected)
                {

                    The18th.Areas.Growers.GrowersDTOs.GrowerCropDto myNewCrop = new The18th.Areas.Growers.GrowersDTOs.GrowerCropDto();
                    myNewCrop.GrowerCropID = Guid.NewGuid();
                    myNewCrop.GrowerNumber = myGrower.GrowerNumber;
                    myNewCrop.GrowerName = screenNameTextBox.Text;
                    myNewCrop.Crop = greensli.Text;
                    myNewCrop.CropIndex = greensli.Value;

                    switch (myNewCrop.CropIndex)
                    {

                        case "1":
                            myNewCrop.Crop = "https://the18thstorage.blob.core.windows.net/the18thcontainer/broc.png";
                            myNewCrop.CropName = "Broccoli";
                            myNewCrop.CropDescription = "Broccoli";
                            myNewCrop.Price = "$4.89";
                            myNewCrop.PricePerItem = 4.89;
                            break;

                        case "2":
                            myNewCrop.Crop = "https://the18thstorage.blob.core.windows.net/the18thcontainer/potatoes.png";
                            myNewCrop.CropName = "Potatoes";
                            myNewCrop.CropDescription = "Potatoes";
                            myNewCrop.Price = "$3.89";
                            myNewCrop.PricePerItem = 3.89;

                            break;

                        case "3":
                            myNewCrop.Crop = "https://the18thstorage.blob.core.windows.net/the18thcontainer/caul.png";
                            myNewCrop.CropName = "Cauliflower";
                            myNewCrop.CropDescription = "Cauliflower";
                            myNewCrop.Price = "$2.90";
                            myNewCrop.PricePerItem = 2.90;
                            break;

                        case "4":
                            myNewCrop.Crop = "https://the18thstorage.blob.core.windows.net/the18thcontainer/kale.png";
                            myNewCrop.CropName = "Kale";
                            myNewCrop.CropDescription = "Kale";
                            myNewCrop.Price = "$1.75";
                            myNewCrop.PricePerItem = 1.75;
                            break;

                        case "5":
                            myNewCrop.Crop = "https://the18thstorage.blob.core.windows.net/the18thcontainer/rads.jpg";
                            myNewCrop.CropName = "Raddish";
                            myNewCrop.CropDescription = "Raddish";
                            myNewCrop.Price = "$4.99";
                            myNewCrop.PricePerItem = 4.99;
                            break;


                    }


                    The18th.Areas.Farming.Data.CropManager.AddGrowerCrop(myNewCrop);

                    The18th.Areas.Farming.FarmingDTOs.CropOfferingDto myOffering1 = new The18th.Areas.Farming.FarmingDTOs.CropOfferingDto();
                    myOffering1.CropOfferingID = Guid.NewGuid();
                    myOffering1.FarmNumber = myGrower.GrowerNumber;
                    myOffering1.ServiceNumber = myOffering1.FarmNumber;
                    myOffering1.FarmName = screenNameTextBox.Text;
                    myOffering1.OfferType = "Crop";
                    myOffering1.OfferName = myNewCrop.CropName;
                    myOffering1.Description = myNewCrop.CropDescription;
                    myOffering1.Controller = "GrowersMarket";
                    myOffering1.Action = "CropGroup";
                    myOffering1.OfferPhoto = "https://the18thstorage.blob.core.windows.net/the18thcontainer/crop.jpg";
                    myOffering1.ImageData = new byte[0];

                    The18th.Areas.Farming.Data.CropManager.AddAOffering(myOffering1);

                }

            }

            /////Crop Section End

            //Response.Redirect("~/AdminGrowerCompletion.aspx");

            Response.Redirect("~/AdminGrowerCompletion.aspx?growerNumber=" + myGrower.GrowerNumber);




        }

        protected void locationDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (locationDropDownList.SelectedValue == "-1")
            {

                ghanaTable.Visible = false;
                ghanaCountryLabel.Visible = false;
                myGhanaImage.Visible = false;
                streetNameTextBox.Visible = false;
                streetLabel.Visible = false;
                regionDropDownList.Visible = false;
                regionLabel.Visible = false;
                districtDropDownList.Visible = false;
                districtLabel.Visible = false;
                areaDropDownList.Visible = false;
                areaLabel.Visible = false;
                postalTextBox.Visible = false;
                postalLabel.Visible = false;
                //
                usTable.Visible = false;
                usCountryLabel.Visible = false;
                myUsImage.Visible = false;
                addressTextBox.Visible = false;
                addressLabel.Visible = false;
                countyDropDownList.Visible = false;
                countyLabel.Visible = false;
                zipTextBox.Visible = false;
                zipLabel.Visible = false;

            }


            else if (locationDropDownList.SelectedValue == "Ghana")
            {

                ghanaTable.Visible = true;
                ghanaCountryLabel.Visible = true;
                myGhanaImage.Visible = true;
                streetNameTextBox.Visible = true;
                streetLabel.Visible = true;
                regionDropDownList.Visible = true;
                regionLabel.Visible = true;
                districtDropDownList.Visible = true;
                districtLabel.Visible = true;
                areaDropDownList.Visible = true;
                areaLabel.Visible = true;
                postalTextBox.Visible = true;
                postalLabel.Visible = true;
                //
                usTable.Visible = false;
                usCountryLabel.Visible = false;
                myUsImage.Visible = false;
                addressTextBox.Visible = false;
                addressLabel.Visible = false;
                countyDropDownList.Visible = false;
                countyLabel.Visible = false;
                zipTextBox.Visible = false;
                zipLabel.Visible = false;

            }

            else if (locationDropDownList.SelectedValue == "U.S")
            {

                usTable.Visible = true;
                usCountryLabel.Visible = true;
                myUsImage.Visible = true;
                addressTextBox.Visible = true;
                addressLabel.Visible = true;
                countyDropDownList.Visible = true;
                countyLabel.Visible = true;
                zipTextBox.Visible = true;
                zipLabel.Visible = true;
                //
                ghanaTable.Visible = false;
                ghanaCountryLabel.Visible = false;
                myGhanaImage.Visible = false;
                streetNameTextBox.Visible = false;
                streetLabel.Visible = false;
                regionDropDownList.Visible = false;
                regionLabel.Visible = false;
                districtDropDownList.Visible = false;
                districtLabel.Visible = false;
                areaDropDownList.Visible = false;
                areaLabel.Visible = false;
                postalTextBox.Visible = false;
                postalLabel.Visible = false;


            }

            else
                return;




        }


        public The18th.Areas.Growers.GrowersDTOs.GrowerProfileDto formatPhone(The18th.Areas.Growers.GrowersDTOs.GrowerProfileDto set)
        {

            The18th.Areas.Growers.GrowersDTOs.GrowerProfileDto createPhone = new The18th.Areas.Growers.GrowersDTOs.GrowerProfileDto();
            createPhone.GrowerPhone = set.GrowerPhone;

            var fullPhone = String.Format("{0: (000)-000-0000}", createPhone.GrowerPhone);

            The18th.Areas.Growers.GrowersDTOs.GrowerProfileDto completePhone = new The18th.Areas.Growers.GrowersDTOs.GrowerProfileDto();
            completePhone.GrowerPhone = fullPhone;

            return (completePhone);
        }

        public The18th.Areas.Growers.GrowersDTOs.GrowerLocationInfoDto formatAmericanMapAddress(The18th.Areas.Growers.GrowersDTOs.GrowerLocationInfoDto sent)
        {

            The18th.Areas.Growers.GrowersDTOs.GrowerLocationInfoDto createAddress = new The18th.Areas.Growers.GrowersDTOs.GrowerLocationInfoDto();
            createAddress.Address = sent.Address;
            createAddress.Location = sent.Location;
            createAddress.Zip = sent.Zip;

            var fullAddress = String.Format(createAddress.Address + " " + createAddress.Location + " " + createAddress.Zip);

            The18th.Areas.Growers.GrowersDTOs.GrowerLocationInfoDto completeAddress = new The18th.Areas.Growers.GrowersDTOs.GrowerLocationInfoDto();
            completeAddress.MapAddress = fullAddress;

            return (completeAddress);

        }

        public The18th.Areas.Growers.GrowersDTOs.GrowerLocationInfoDto formatAfricaMapAddress(The18th.Areas.Growers.GrowersDTOs.GrowerLocationInfoDto sent)
        {

            The18th.Areas.Growers.GrowersDTOs.GrowerLocationInfoDto createAddress = new The18th.Areas.Growers.GrowersDTOs.GrowerLocationInfoDto();
            createAddress.StreetName = sent.StreetName;
            createAddress.Region = sent.Region;
            createAddress.District = sent.District;
            createAddress.Area = sent.Area;
            createAddress.PostalCode = sent.PostalCode;

            var fullAddress = String.Format(createAddress.StreetName + " " + createAddress.Region + " " + createAddress.PostalCode);

            The18th.Areas.Growers.GrowersDTOs.GrowerLocationInfoDto completeAddress = new The18th.Areas.Growers.GrowersDTOs.GrowerLocationInfoDto();
            completeAddress.MapAddress = fullAddress;

            return (completeAddress);

        }

        private string createGrowerNumber()
        {

            Random random = new Random();
            random.Next(59864343, 87395235);

            int mySeed = random.Next();

            int farmSeed = int.Parse(mySeed.ToString());

            var myFarmNumber = String.Format("{0: 00000000}", farmSeed);

            ViewState.Add("FARMSeed", myFarmNumber);


            return (myFarmNumber);
        }

        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");


        }



    }
}