using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class GrowerCropEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie cookie = Request.Cookies["GrowerCookieInfo"];
            string growerNumberCookie = cookie["growerNumber"];
            string growerNameCookie = cookie["growerName"];

            var growNumber = growerNumberCookie.Trim();

            ViewState.Add("ExistingGrowNum", growNumber);

            var growName = growerNameCookie.Trim();

            ViewState.Add("ExistingGrowName", growName);

            growerNumberLabel.Text = growNumber;


            //New
            The18th.Areas.Growers.GrowersDTOs.GrowerLocationInfoDto currencyType = new The18th.Areas.Growers.GrowersDTOs.GrowerLocationInfoDto();
            currencyType.GrowerNumber = growNumber;

            var pulledCurrency = The18th.Areas.Growers.Data.GrowersMarketManager.GetGrowerLocation(currencyType.GrowerNumber);


            if (pulledCurrency.Location == "U.S")
            {

                if (!Page.IsPostBack)
                {

                    string cs = ConfigurationManager.ConnectionStrings["OneFarmData"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd1 = new SqlCommand("Select CropMobileLookUpId, Crop, CropIndex From tblCropMobileLookUp", con);
                        con.Open();

                        greensCheckBoxList.DataSource = cmd1.ExecuteReader();
                        //greensCheckBoxList.DataTextField = "CropName";
                        //greensCheckBoxList.DataValueField = "Price";
                        greensCheckBoxList.DataBind();

                    }


                }
                ViewState.Add("GrowersCountry", pulledCurrency.Location);
            }


            else if (pulledCurrency.Location == "Ghana")
            {

                if (!Page.IsPostBack)
                {

                    string cs = ConfigurationManager.ConnectionStrings["OneFarmData"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd1 = new SqlCommand("Select GhanaCropLookUpId, Crop, CropIndex From tblGhanaCropLookUp", con);
                        con.Open();

                        greensCheckBoxList.DataSource = cmd1.ExecuteReader();
                        //greensCheckBoxList.DataTextField = "CropName";
                        //greensCheckBoxList.DataValueField = "Price";
                        greensCheckBoxList.DataBind();

                    }


                }

                ViewState.Add("GrowersCountry", pulledCurrency.Location);
            }




        }

        protected void addCropsButton_Click(object sender, EventArgs e)
        {

            growerCountryLabel.Text = ViewState["GrowersCountry"].ToString();

            growerNumberLabel.Text = ViewState["ExistingGrowNum"].ToString();

            farmNameLabel.Text = ViewState["ExistingGrowName"].ToString();

            var fromExistingFarmName = farmNameLabel.Text;

            if (growerCountryLabel.Text == "U.S")
            {

                foreach (ListItem greensli in greensCheckBoxList.Items)
                {
                    if (greensli.Selected)
                    {
                        //myItems.Add(greensli.Value + "<br />");

                        The18th.Areas.Growers.GrowersDTOs.GrowerCropDto myNewCrop = new The18th.Areas.Growers.GrowersDTOs.GrowerCropDto();
                        myNewCrop.GrowerCropID = Guid.NewGuid();
                        myNewCrop.GrowerNumber = growerNumberLabel.Text;
                        myNewCrop.GrowerName = fromExistingFarmName;
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


                        //New Area 4-29-23
                        The18th.Areas.Farming.FarmingDTOs.CropOfferingDto myOffering1 = new The18th.Areas.Farming.FarmingDTOs.CropOfferingDto();
                        myOffering1.CropOfferingID = Guid.NewGuid();
                        myOffering1.FarmNumber = growerNumberLabel.Text;
                        myOffering1.ServiceNumber = myOffering1.FarmNumber;
                        myOffering1.FarmName = farmNameLabel.Text;
                        myOffering1.OfferType = "Crop";
                        myOffering1.OfferName = myNewCrop.CropName;
                        myOffering1.Description = myNewCrop.CropDescription;
                        //myOffering1.Controller = "BitePage";
                        myOffering1.Controller = "GrowersMarket";
                        myOffering1.Action = "CropGroup";
                        myOffering1.OfferPhoto = "https://the18thstorage.blob.core.windows.net/the18thcontainer/crop.jpg";
                        myOffering1.ImageData = new byte[0];


                        The18th.Areas.Farming.Data.CropManager.AddAOffering(myOffering1);

                    }


                }


                Response.Redirect("~/GrowerCompletion.aspx");

            }

            else if (growerCountryLabel.Text == "Ghana")
            {
                foreach (ListItem greensli in greensCheckBoxList.Items)
                {
                    if (greensli.Selected)
                    {
                        //myItems.Add(greensli.Value + "<br />");

                        The18th.Areas.Growers.GrowersDTOs.GrowerCropDto myNewCrop = new The18th.Areas.Growers.GrowersDTOs.GrowerCropDto();
                        myNewCrop.GrowerCropID = Guid.NewGuid();
                        myNewCrop.GrowerNumber = growerNumberLabel.Text;
                        myNewCrop.GrowerName = fromExistingFarmName;
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


                        //New Area 4-29-23
                        The18th.Areas.Farming.FarmingDTOs.CropOfferingDto myOffering1 = new The18th.Areas.Farming.FarmingDTOs.CropOfferingDto();
                        myOffering1.CropOfferingID = Guid.NewGuid();
                        myOffering1.FarmNumber = growerNumberLabel.Text;
                        myOffering1.ServiceNumber = myOffering1.FarmNumber;
                        myOffering1.FarmName = farmNameLabel.Text;
                        myOffering1.OfferType = "Crop";
                        myOffering1.OfferName = myNewCrop.CropName;
                        myOffering1.Description = myNewCrop.CropDescription;
                        //myOffering1.Controller = "BitePage";
                        myOffering1.Controller = "GrowersMarket";
                        myOffering1.Action = "GhanaCropGroup";
                        myOffering1.OfferPhoto = "https://the18thstorage.blob.core.windows.net/the18thcontainer/crop.jpg";
                        myOffering1.ImageData = new byte[0];


                        The18th.Areas.Farming.Data.CropManager.AddAOffering(myOffering1);

                    }

                }

                Response.Redirect("~/GrowerCompletion.aspx");
            }

            return;



        }


        protected void Page_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            Server.ClearError();
            Response.Redirect("~/SomethingsWrong.aspx");

        }


    }
}