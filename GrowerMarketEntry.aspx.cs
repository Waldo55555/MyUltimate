using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The18th.Exceptions;

namespace The18th
{
    public partial class GrowerMarketEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie cookie = Request.Cookies["GrowerCookieInfo"];
            string growerNumberCookie = cookie["growerNumber"];
            string growerNameCookie = cookie["growerName"];
            //Use Once
            string growerAccountCookie = cookie["accountNumber"];

            var growNumber = growerNumberCookie.Trim();

            ViewState.Add("ExistingGrowNum", growNumber);

            var growName = growerNameCookie.Trim();

            ViewState.Add("ExistingGrowName", growName);

            growerNumberLabel.Text = growNumber;


            var growAccount = growerAccountCookie.Trim();

            ViewState.Add("ExistingAccountNumber", growAccount);





        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            growerNumberLabel.Text = ViewState["ExistingGrowNum"].ToString();

            growerAccountNumberLabel.Text = ViewState["ExistingAccountNumber"].ToString();


            The18th.Areas.Growers.GrowersDTOs.GrowerMarketInfoDto myMarketInfo = new The18th.Areas.Growers.GrowersDTOs.GrowerMarketInfoDto();
            myMarketInfo.GrowerNumber = growerNumberLabel.Text;
            myMarketInfo.CropTypes = cropTypeDropDownList.SelectedValue;
            myMarketInfo.StorageTypes = storageTypeDropDownList.SelectedValue;
            myMarketInfo.MarketHours = marketHoursDropDownList.SelectedValue;
            myMarketInfo.MarketDays = marketDaysDropDownList.SelectedValue;
            myMarketInfo.LandUtilizationPercentage = utilizationDropDownList.SelectedValue;
            myMarketInfo.YearsFarming = yearsDropDownList.SelectedValue;
            //Check to see if adding here or later
            myMarketInfo.WebAddress = "Not Defined";
            myMarketInfo.NetworkStatus = "One Farm Networked";
            myMarketInfo.GrowerRating = "5";
            //myMarketInfo.WebAddress = webTextBox.Text;


            try
            {

                if (myMarketInfo.GrowerNumber.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (myMarketInfo.CropTypes == "Select Crop Type...")
                    throw new RequiredException("please complete all required fields");

                if (myMarketInfo.CropTypes.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (myMarketInfo.StorageTypes == "Select Storage Type...")
                    throw new RequiredException("please complete all required fields");

                if (myMarketInfo.StorageTypes.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (myMarketInfo.MarketHours == "Select Market Hours...")
                    throw new RequiredException("please complete all required fields");

                if (myMarketInfo.MarketHours.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (myMarketInfo.MarketDays == "Select Market Days...")
                    throw new RequiredException("please complete all required fields");

                if (myMarketInfo.MarketDays.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (myMarketInfo.LandUtilizationPercentage == "Select Land Utilization...")
                    throw new RequiredException("please complete all required fields");

                if (myMarketInfo.LandUtilizationPercentage.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (myMarketInfo.YearsFarming == "Select Years Farming...")
                    throw new RequiredException("please complete all required fields");

                if (myMarketInfo.YearsFarming.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");



                The18th.Areas.Meek.Data.RunUpAdminRepository.AddGrowerMarket(myMarketInfo);

            }

            catch (RequiredException ex)
            {
                string message = ex.MessageError;
                return;
            }

            catch (Exception ex)
            {
                string message = "";
                message = ex.Message;
            }

            //Start Checking
            Response.Redirect("~/GrowerPhotoEntry.aspx");


            ////////////////////////////////////////////////Duplicate

            ////Do Not Delete...This is a full photosubmission option
            ////We are bypassing this and autopopulating profile photo from membership
            ////Member will be able to edit avatar on their dash to put in real profile photo
            ////Response.Redirect("~/GrowerPhotoEntry.aspx");

            ////To Auto Populate photo
            //The18th.Areas.MemberShip.MemberShipDTOs.ProfilePhotoDto currencyMembership = new The18th.Areas.MemberShip.MemberShipDTOs.ProfilePhotoDto();
            //currencyMembership.AccountNumber = growerAccountNumberLabel.Text;

            //var pulledPhoto = The18th.Areas.MemberShip.Data.MembershipManager.GetProfilePhotoByAccountNumber(currencyMembership.AccountNumber);

            //The18th.Areas.Growers.GrowersDTOs.GrowerPhotoDto myPhoto = new The18th.Areas.Growers.GrowersDTOs.GrowerPhotoDto();
            //myPhoto.GrowerNumber = growerNumberLabel.Text;
            //myPhoto.FullImagePath = pulledPhoto.MemberImageUrl;
            //myPhoto.PhotoData = new byte[0];

            //The18th.Areas.Meek.Data.OneFarmAdminManager.AddGrowerPhoto(myPhoto);

            //Response.Redirect("~/GrowerCropEntry.aspx");

        }

        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");

        }


    }
}