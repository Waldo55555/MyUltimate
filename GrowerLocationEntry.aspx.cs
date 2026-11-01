using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class GrowerLocationEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie cookie = Request.Cookies["GrowerCookieInfo"];
            string growerNumberCookie = cookie["growerNumber"];
            string growerNameCookie = cookie["growerName"];
            string growerTypeCookie = cookie["growerType"];
            //Use Once
            string growerAccountCookie = cookie["accountNumber"];

            var growNumber = growerNumberCookie.Trim();

            ViewState.Add("ExistingGrowNum", growNumber);

            var growName = growerNameCookie.Trim();

            ViewState.Add("ExistingGrowName", growName);

            var growType = growerTypeCookie.Trim();

            ViewState.Add("ExistingGrowType", growType);

            var growAccount = growerAccountCookie.Trim();

            ViewState.Add("ExistingAccountNumber", growAccount);

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






        }

        protected void submitButton_Click(object sender, EventArgs e)
        {

            growerNumberLabel.Text = ViewState["ExistingGrowNum"].ToString();

            growerNameLabel.Text = ViewState["ExistingGrowName"].ToString();

            growerTypeLabel.Text = ViewState["ExistingGrowType"].ToString();

            //Not Used
            growerAccountNumberLabel.Text = ViewState["ExistingAccountNumber"].ToString();


            The18th.Areas.Growers.GrowersDTOs.GrowerLocationInfoDto myLocation = new The18th.Areas.Growers.GrowersDTOs.GrowerLocationInfoDto();
            myLocation.GrowerNumber = growerNumberLabel.Text;
            myLocation.GrowerName = growerNameLabel.Text;
            myLocation.GrowerType = growerTypeLabel.Text;
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

                //New....Working On
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


            Response.Redirect("~/GrowerMarketEntry.aspx");




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


        //Working On
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

        //Working On
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




        protected void Page_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");

        }


    }
}