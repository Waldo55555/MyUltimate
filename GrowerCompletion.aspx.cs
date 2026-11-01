using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class GrowerCompletion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie cookie = Request.Cookies["GrowerCookieInfo"];
            string growerNumberCookie = cookie["growerNumber"];
            string growerNameCookie = cookie["growerName"];

            var growNumber = growerNumberCookie.Trim();

            var growName = growerNameCookie.Trim();

            ViewState.Add("ExistingGrowName", growName);

            ////////////////////////////////////////////////////////////////////////////////

            var pulledProfile = The18th.Areas.Growers.Data.GrowersMarketManager.GetGrowerProfile(growNumber);

            var pulledLocation = The18th.Areas.Growers.Data.GrowersMarketManager.GetGrowerLocation(growNumber);

            var pulledMarketInfo = The18th.Areas.Growers.Data.GrowersMarketManager.GetMarketInfo(growNumber);

            var pulledPhoto = The18th.Areas.Growers.Data.GrowersMarketManager.GetGrowerPhoto(growNumber);

            The18th.Areas.Farming.FarmingDTOs.FarmSeoDto mySeo = new The18th.Areas.Farming.FarmingDTOs.FarmSeoDto();
            mySeo.FarmNumber = pulledProfile.GrowerNumber;
            mySeo.FarmName = pulledProfile.GrowerName;
            //mySeo.AboutUs = aboutTextBox.Text;
            mySeo.AboutUs = "Is a One Farm Co-Operative Member";
            mySeo.TagLine = "A One Farm Networked Farm";
            mySeo.PageDescription = "Farm Services";
            mySeo.Keyword1 = "Black Owned Farms";
            mySeo.Keyword2 = "Food Products";
            mySeo.Keyword3 = "Black Farm";
            mySeo.Map = "Set";
            mySeo.MapAddress = "Set";
            //Original     
            //mySeo.WebAddress = "https://avatargrowers/";
            //Working On
            mySeo.WebAddress = "https://avatargrowers/Growers/GrowersMarket/";

            var sendWeb = formatWeb(mySeo, pulledProfile.GrowerName.Replace(" ", ""));

            mySeo.WebAddress = sendWeb.WebAddress;

            ////////////////////////////////////////////////////////////////////////////Here!!!!!!
            //6-6-23....sixth window
            //Probably need a update to GrowerMarket Info here
            //Instead of relying on FarmSeo for webadress



            if (pulledLocation.Location == "U.S")
            {

                var sendAddress = formatAmericanMapAddress(pulledLocation);

                mySeo.MapAddress = sendAddress.MapAddress;

                The18th.Areas.Farming.FarmingDTOs.FarmPageSettlementDto mySettlement = new The18th.Areas.Farming.FarmingDTOs.FarmPageSettlementDto();
                mySettlement.FarmPageSettlementID = mySeo.FarmSeoID;
                mySettlement.FarmerNumber = pulledProfile.GrowerNumber;
                mySettlement.FarmName = pulledProfile.GrowerName;
                mySettlement.PageType = pulledLocation.DashType;
                mySettlement.FarmPageUrl = mySeo.WebAddress;
                mySettlement.Controller = "FarmPage";
                mySettlement.Action = pulledProfile.GrowerName.Replace(" ", "");

                //
                The18th.Areas.Farming.Data.FarmSeoManager.InsertBiteSeo(mySeo);

                The18th.Areas.Meek.MeekDTOs.FarmPageDto myFarmPage = new The18th.Areas.Meek.MeekDTOs.FarmPageDto();
                myFarmPage.FarmPageID = mySeo.FarmSeoID;
                myFarmPage.FarmNumber = pulledProfile.GrowerNumber;
                myFarmPage.CropNumber = "123";
                myFarmPage.ImageData = pulledPhoto.PhotoData;
                myFarmPage.FarmType = pulledProfile.GrowerType;
                myFarmPage.FarmName = pulledProfile.GrowerName;
                myFarmPage.FarmDescription = "No Data";
                myFarmPage.MarketAddress = pulledLocation.Address;
                myFarmPage.MapAddress = mySeo.MapAddress;
                myFarmPage.FarmStatus = "No Data";
                myFarmPage.FarmRating = pulledMarketInfo.GrowerRating;
                myFarmPage.State = pulledLocation.Location;
                myFarmPage.County = pulledLocation.County;

                The18th.Areas.Meek.Data.RunUpAdminRepository.AddFarmPage(myFarmPage);

            }

            else if (pulledLocation.Location == "Ghana")
            {

                var sendAddress = formatAfricaMapAddress(pulledLocation);

                mySeo.MapAddress = sendAddress.MapAddress;

                The18th.Areas.Farming.FarmingDTOs.FarmPageSettlementDto mySettlement = new The18th.Areas.Farming.FarmingDTOs.FarmPageSettlementDto();
                mySettlement.FarmPageSettlementID = mySeo.FarmSeoID;
                mySettlement.FarmerNumber = pulledProfile.GrowerNumber;
                mySettlement.FarmName = pulledProfile.GrowerName;
                mySettlement.PageType = pulledLocation.DashType;
                mySettlement.FarmPageUrl = mySeo.WebAddress;
                mySettlement.Controller = "FarmPageGhana";
                mySettlement.Action = pulledProfile.GrowerName.Replace(" ", "");

                //
                The18th.Areas.Farming.Data.FarmSeoManager.InsertBiteSeo(mySeo);

                The18th.Areas.Meek.MeekDTOs.FarmPageGhanaDto myFarmPage = new The18th.Areas.Meek.MeekDTOs.FarmPageGhanaDto();
                myFarmPage.FarmPageGhanaID = mySeo.FarmSeoID;
                myFarmPage.FarmNumber = pulledProfile.GrowerNumber;
                myFarmPage.CropNumber = "123";
                myFarmPage.ImageData = pulledPhoto.PhotoData;
                myFarmPage.FarmType = pulledProfile.GrowerType;
                myFarmPage.FarmName = pulledProfile.GrowerName;
                myFarmPage.FarmDescription = "No Data";
                myFarmPage.MarketAddress = pulledLocation.Address;
                myFarmPage.MapAddress = mySeo.MapAddress;
                myFarmPage.FarmStatus = "No Data";
                myFarmPage.FarmRating = pulledMarketInfo.GrowerRating;
                myFarmPage.StreetName = pulledLocation.StreetName;
                myFarmPage.Region = pulledLocation.Region;
                myFarmPage.District = pulledLocation.District;
                myFarmPage.Area = pulledLocation.Area;
                myFarmPage.PostalCode = pulledLocation.PostalCode;

                The18th.Areas.Meek.Data.RunUpAdminManager.AddFarmPageGhana(myFarmPage);

            }

            try
            {

                setUpSettlement(pulledProfile, pulledPhoto, pulledLocation);

            }

            catch (Exception ex)
            {

                string message = "";

                message = ex.Message;

            }


            //Completes
            Response.Redirect("~/GrowerCompleteConfirmation.aspx");
            //Response.Redirect("~/GrowerProfileEntry.aspx");
            ////Response.Redirect("/Meek/MeekAdmin/MeekAdmin");



        }


        //////////////////////////////////////////////////helpers

        public void setUpSettlement(The18th.Areas.Growers.GrowersDTOs.GrowerProfileDto grower, The18th.Areas.Growers.GrowersDTOs.GrowerPhotoDto pulledPhoto, The18th.Areas.Growers.GrowersDTOs.GrowerLocationInfoDto locationInfo)
        {

            if (locationInfo.NavArea == "Growers" && locationInfo.Location == "U.S")
            {

                The18th.Areas.Farming.FarmingDTOs.FarmSettlementDto myMeekSettle2 = new The18th.Areas.Farming.FarmingDTOs.FarmSettlementDto();
                myMeekSettle2.FarmSettlementID = Guid.NewGuid();
                myMeekSettle2.FarmNumber = grower.GrowerNumber;
                myMeekSettle2.SettlementType = "Meek";
                myMeekSettle2.FarmName = grower.GrowerName;
                myMeekSettle2.PlaceHolderName = "Customer Service";
                myMeekSettle2.PlaceHolderPhoto = "https://the18thstorage.blob.core.windows.net/the18thcontainer/servpicthree.png";
                myMeekSettle2.ImageData = pulledPhoto.PhotoData;
                myMeekSettle2.Description = "Mon-Fri 9-5";
                myMeekSettle2.Controller = "GrowersMarket";
                myMeekSettle2.Action = "GrowerCustomerSupport";

                The18th.Areas.Farming.Data.FarmSettlementManager.AddSettlement(myMeekSettle2);


                The18th.Areas.Farming.FarmingDTOs.FarmSettlementDto myMeekSettle4 = new The18th.Areas.Farming.FarmingDTOs.FarmSettlementDto();
                myMeekSettle4.FarmSettlementID = Guid.NewGuid();
                myMeekSettle4.FarmNumber = grower.GrowerNumber;
                myMeekSettle4.SettlementType = "Meek";
                myMeekSettle4.FarmName = grower.GrowerName;
                myMeekSettle4.PlaceHolderName = "Crops";
                myMeekSettle4.PlaceHolderPhoto = "https://the18thstorage.blob.core.windows.net/the18thcontainer/croppic.png";
                myMeekSettle4.ImageData = pulledPhoto.PhotoData;
                myMeekSettle4.Description = "View Farmers Market";
                myMeekSettle4.Controller = "GrowersMarket";
                myMeekSettle4.Action = "CropGroup";

                The18th.Areas.Farming.Data.FarmSettlementManager.AddSettlement(myMeekSettle4);

                The18th.Areas.Farming.FarmingDTOs.FarmSettlementDto myMeekSettle3 = new The18th.Areas.Farming.FarmingDTOs.FarmSettlementDto();
                myMeekSettle3.FarmSettlementID = Guid.NewGuid();
                myMeekSettle3.FarmNumber = grower.GrowerNumber;
                myMeekSettle3.SettlementType = "Meek";
                myMeekSettle3.FarmName = grower.GrowerName;
                myMeekSettle3.PlaceHolderName = "Support";
                myMeekSettle3.PlaceHolderPhoto = "https://the18thstorage.blob.core.windows.net/the18thcontainer/supportpic.png";
                myMeekSettle3.ImageData = pulledPhoto.PhotoData;
                myMeekSettle3.Description = "Technical Support";
                myMeekSettle3.Controller = "GrowersMarket";
                myMeekSettle3.Action = "GrowerTechnicalSupport";

                The18th.Areas.Farming.Data.FarmSettlementManager.AddSettlement(myMeekSettle3);

            }


            else if (locationInfo.NavArea == "Growers" && locationInfo.Location == "Ghana")
            {

                The18th.Areas.Farming.FarmingDTOs.FarmSettlementDto myMeekSettle2 = new The18th.Areas.Farming.FarmingDTOs.FarmSettlementDto();
                myMeekSettle2.FarmSettlementID = Guid.NewGuid();
                myMeekSettle2.FarmNumber = grower.GrowerNumber;
                myMeekSettle2.SettlementType = "Meek";
                myMeekSettle2.FarmName = grower.GrowerName;
                myMeekSettle2.PlaceHolderName = "Customer Service";
                myMeekSettle2.PlaceHolderPhoto = "https://the18thstorage.blob.core.windows.net/the18thcontainer/servpicthree.png";
                myMeekSettle2.ImageData = pulledPhoto.PhotoData;
                myMeekSettle2.Description = "Mon-Fri 9-5";
                myMeekSettle2.Controller = "GrowersMarket";
                myMeekSettle2.Action = "GrowerCustomerSupport";

                The18th.Areas.Farming.Data.FarmSettlementManager.AddSettlement(myMeekSettle2);


                The18th.Areas.Farming.FarmingDTOs.FarmSettlementDto myMeekSettle4 = new The18th.Areas.Farming.FarmingDTOs.FarmSettlementDto();
                myMeekSettle4.FarmSettlementID = Guid.NewGuid();
                myMeekSettle4.FarmNumber = grower.GrowerNumber;
                myMeekSettle4.SettlementType = "Meek";
                myMeekSettle4.FarmName = grower.GrowerName;
                myMeekSettle4.PlaceHolderName = "Crops";
                myMeekSettle4.PlaceHolderPhoto = "https://the18thstorage.blob.core.windows.net/the18thcontainer/croppic.png";
                myMeekSettle4.ImageData = pulledPhoto.PhotoData;
                myMeekSettle4.Description = "View Growers Market";
                myMeekSettle4.Controller = "GrowersMarket";
                myMeekSettle4.Action = "GhanaCropGroup";

                The18th.Areas.Farming.Data.FarmSettlementManager.AddSettlement(myMeekSettle4);

                The18th.Areas.Farming.FarmingDTOs.FarmSettlementDto myMeekSettle3 = new The18th.Areas.Farming.FarmingDTOs.FarmSettlementDto();
                myMeekSettle3.FarmSettlementID = Guid.NewGuid();
                myMeekSettle3.FarmNumber = grower.GrowerNumber;
                myMeekSettle3.SettlementType = "Meek";
                myMeekSettle3.FarmName = grower.GrowerName;
                myMeekSettle3.PlaceHolderName = "Support";
                myMeekSettle3.PlaceHolderPhoto = "https://the18thstorage.blob.core.windows.net/the18thcontainer/supportpic.png";
                myMeekSettle3.ImageData = pulledPhoto.PhotoData;
                myMeekSettle3.Description = "Technical Support";
                myMeekSettle3.Controller = "GrowersMarket";
                myMeekSettle3.Action = "GrowerTechnicalSupport";

                The18th.Areas.Farming.Data.FarmSettlementManager.AddSettlement(myMeekSettle3);

            }


            else if (locationInfo.NavArea == null)
            {

                //Should return all the way out

                return;

            }


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

        ////////////////////////////////////////////////////////////////////////////
        public The18th.Areas.Farming.FarmingDTOs.FarmSeoDto formatWeb(The18th.Areas.Farming.FarmingDTOs.FarmSeoDto seo, string businessName)
        {

            The18th.Areas.Farming.FarmingDTOs.FarmSeoDto myWeb = new The18th.Areas.Farming.FarmingDTOs.FarmSeoDto();
            myWeb.WebAddress = seo.WebAddress;

            //Original
            //if (myWeb.WebAddress == "https://avatargrowers/")
            //{

            //    StringBuilder sb = new StringBuilder();
            //    sb.Append("https://avatargrowers/");
            //    sb.Append("OneFarm/");
            //    sb.Append(businessName);

            //    The18th.Areas.Farming.FarmingDTOs.FarmSeoDto sepValue = new The18th.Areas.Farming.FarmingDTOs.FarmSeoDto();
            //    sepValue.WebAddress = sb.ToString();

            //    return sepValue;
            //}

            //Checking Here to see if appending happens
            if (myWeb.WebAddress == "https://avatargrowers/Growers/GrowersMarket/")
            {

                StringBuilder sb = new StringBuilder();
                sb.Append("https://avatargrowers/Growers/GrowersMarket/");
                //sb.Append("OneFarm/");
                sb.Append(businessName);

                The18th.Areas.Farming.FarmingDTOs.FarmSeoDto sepValue = new The18th.Areas.Farming.FarmingDTOs.FarmSeoDto();
                sepValue.WebAddress = sb.ToString();

                return sepValue;
            }


            return null;
        }


        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");


        }




    }
}