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
    public partial class GrowerCropEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie cookie = Request.Cookies["GrowerCookieInfo"];
            string growerNumberCookie = cookie["growerNumber"];

            var growNumber = growerNumberCookie.Trim();

            ViewState.Add("ExistingGrowNum", growNumber);


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

        protected void updateCropsButton_Click(object sender, EventArgs e)
        {

            growerCountryLabel.Text = ViewState["GrowersCountry"].ToString();

            growerNumberLabel.Text = ViewState["ExistingGrowNum"].ToString();


            var pulledGrower = The18th.Areas.Growers.Data.GrowerAdminManager.GetGrowerProfileByGrowerNumber(growerNumberLabel.Text);


            var pulledCrops = The18th.Areas.Growers.Data.GrowerAdminManager.GetGrowerCropsForAdmin(pulledGrower.GrowerNumber);

            foreach (var item in pulledCrops)
            {

                The18th.Areas.Growers.GrowersDTOs.GrowerCropDto upForEdit = new The18th.Areas.Growers.GrowersDTOs.GrowerCropDto();
                upForEdit.GrowerCropID = item.GrowerCropID;
                upForEdit.GrowerNumber = item.GrowerNumber;
                upForEdit.GrowerName = item.GrowerName;
                upForEdit.Crop = item.Crop;
                upForEdit.CropIndex = item.CropIndex;
                upForEdit.CropName = item.CropName;
                upForEdit.CropDescription = item.CropDescription;
                upForEdit.Price = item.Price;
                upForEdit.PricePerItem = item.PricePerItem;

                The18th.Areas.Growers.Data.GrowerAdminManager.ClearMyCrops(upForEdit);


            }


            if (growerCountryLabel.Text == "U.S")
            {


                //var myCropsList = new  List<The18th.Areas.Growers.GrowersDTOs.GrowerCropDto>();

                foreach (ListItem greensli in greensCheckBoxList.Items)
                {
                    if (greensli.Selected)
                    {
                        //myItems.Add(greensli.Value + "<br />");

                        The18th.Areas.Growers.GrowersDTOs.GrowerCropDto myNewCrop = new The18th.Areas.Growers.GrowersDTOs.GrowerCropDto();
                        myNewCrop.GrowerCropID = Guid.NewGuid();
                        myNewCrop.GrowerNumber = growerNumberLabel.Text;
                        myNewCrop.GrowerName = pulledGrower.GrowerName;
                        myNewCrop.Crop = greensli.Text;
                        myNewCrop.CropIndex = greensli.Value;

                        switch (myNewCrop.CropIndex)
                        {

                            case "1":
                                myNewCrop.Crop = "~/Images/Vegetables/v3.png";
                                myNewCrop.CropName = "Broccoli";
                                myNewCrop.CropDescription = "Broccoli";
                                myNewCrop.Price = "$4.89";
                                myNewCrop.PricePerItem = 4.89;
                                break;

                            case "2":
                                myNewCrop.Crop = "~/Images/Vegetables/v32.jpg";
                                myNewCrop.CropName = "Asperagus";
                                myNewCrop.CropDescription = "Asperagus";
                                myNewCrop.Price = "$3.89";
                                myNewCrop.PricePerItem = 3.89;

                                break;

                            case "3":
                                myNewCrop.Crop = "~/Images/Vegetables/v7.png";
                                myNewCrop.CropName = "Celery";
                                myNewCrop.CropDescription = "Celery";
                                myNewCrop.Price = "$2.90";
                                myNewCrop.PricePerItem = 2.90;
                                break;

                            case "4":
                                myNewCrop.Crop = "~/Images/Vegetables/v10.png";
                                myNewCrop.CropName = "Cucumber";
                                myNewCrop.CropDescription = "Cucumber";
                                myNewCrop.Price = "$1.75";
                                myNewCrop.PricePerItem = 1.75;
                                break;

                            case "5":
                                myNewCrop.Crop = "~/Images/Vegetables/v13.jpg";
                                myNewCrop.CropName = "Lettuce";
                                myNewCrop.CropDescription = "Lettuce";
                                myNewCrop.Price = "$4.99";
                                myNewCrop.PricePerItem = 4.99;
                                break;

                            case "6":
                                myNewCrop.Crop = "~/Images/Vegetables/v1.png";
                                myNewCrop.CropName = "Beans";
                                myNewCrop.CropDescription = "Beans";
                                myNewCrop.Price = "$4.99";
                                myNewCrop.PricePerItem = 4.99;
                                break;

                            case "7":
                                myNewCrop.Crop = "~/Images/Vegetables/v5.jpg";
                                myNewCrop.CropName = "Cabbage";
                                myNewCrop.CropDescription = "Cabbage";
                                myNewCrop.Price = "$4.99";
                                myNewCrop.PricePerItem = 4.99;
                                break;

                            case "8":
                                myNewCrop.Crop = "~/Images/Vegetables/v8.jpg";
                                myNewCrop.CropName = "Collards";
                                myNewCrop.CropDescription = "Collards";
                                myNewCrop.Price = "$1.75";
                                myNewCrop.PricePerItem = 1.75;
                                break;

                            case "9":
                                myNewCrop.Crop = "~/Images/Vegetables/v15.png";
                                myNewCrop.CropName = "Mustards";
                                myNewCrop.CropDescription = "Mustards";
                                myNewCrop.Price = "$1.75";
                                myNewCrop.PricePerItem = 1.75;
                                break;

                            case "10":
                                myNewCrop.Crop = "~/Images/Vegetables/v17.png";
                                myNewCrop.CropName = "Peas";
                                myNewCrop.CropDescription = "Peas";
                                myNewCrop.Price = "$2.44";
                                myNewCrop.PricePerItem = 2.44;
                                break;

                            case "11":
                                myNewCrop.Crop = "~/Images/Vegetables/v23.png";
                                myNewCrop.CropName = "Spinach";
                                myNewCrop.CropDescription = "Spinach";
                                myNewCrop.Price = "$3.89";
                                myNewCrop.PricePerItem = 3.89;
                                break;

                            case "12":
                                myNewCrop.Crop = "~/Images/Vegetables/v31.jpg";
                                myNewCrop.CropName = "Zucchini";
                                myNewCrop.CropDescription = "Zucchini";
                                myNewCrop.Price = "$2.44";
                                myNewCrop.PricePerItem = 2.44;
                                break;

                            case "13":
                                myNewCrop.Crop = "~/Images/Vegetables/v11.jpg";
                                myNewCrop.CropName = "Peppers";
                                myNewCrop.CropDescription = "Peppers";
                                myNewCrop.Price = "$4.99";
                                myNewCrop.PricePerItem = 4.99;
                                break;

                            case "14":
                                myNewCrop.Crop = "~/Images/Vegetables/v12.png";
                                myNewCrop.CropName = "Kale";
                                myNewCrop.CropDescription = "Kale";
                                myNewCrop.Price = "$4.99";
                                myNewCrop.PricePerItem = 4.89;
                                break;

                            case "15":
                                myNewCrop.Crop = "~/Images/Vegetables/v4.jpg";
                                myNewCrop.CropName = "Brussels";
                                myNewCrop.CropDescription = "Brussels";
                                myNewCrop.Price = "$2.44";
                                myNewCrop.PricePerItem = 2.44;
                                break;

                            case "16":
                                myNewCrop.Crop = "~/Images/Vegetables/v16.png";
                                myNewCrop.CropName = "Okra";
                                myNewCrop.CropDescription = "Okra";
                                myNewCrop.Price = "$4.99";
                                myNewCrop.PricePerItem = 4.89;
                                break;

                            case "17":
                                myNewCrop.Crop = "~/Images/Vegetables/v33.jpg";
                                myNewCrop.CropName = "Carrots";
                                myNewCrop.CropDescription = "Carrots";
                                myNewCrop.Price = "$2.44";
                                myNewCrop.PricePerItem = 2.44;
                                break;

                            case "18":
                                myNewCrop.Crop = "~/Images/Vegetables/v2.jpg";
                                myNewCrop.CropName = "Beets";
                                myNewCrop.CropDescription = "Beets";
                                myNewCrop.Price = "$2.80";
                                myNewCrop.PricePerItem = 2.80;
                                break;

                            case "19":
                                myNewCrop.Crop = "~/Images/Vegetables/v9.png";
                                myNewCrop.CropName = "Corn";
                                myNewCrop.CropDescription = "Corn";
                                myNewCrop.Price = "$1.89";
                                myNewCrop.PricePerItem = 1.89;
                                break;

                            case "20":
                                myNewCrop.Crop = "~/Images/Vegetables/v29.png";
                                myNewCrop.CropName = "Yams";
                                myNewCrop.CropDescription = "Yams";
                                myNewCrop.Price = "$1.89";
                                myNewCrop.PricePerItem = 1.89;
                                break;

                            case "21":
                                myNewCrop.Crop = "~/Images/Vegetables/v27.png";
                                myNewCrop.CropName = "Onions";
                                myNewCrop.CropDescription = "Onions";
                                myNewCrop.Price = "$2.90";
                                myNewCrop.PricePerItem = 2.90;
                                break;

                            case "22":
                                myNewCrop.Crop = "~/Images/Vegetables/v19.png";
                                myNewCrop.CropName = "Onions";
                                myNewCrop.CropDescription = "Onions";
                                myNewCrop.Price = "$2.90";
                                myNewCrop.PricePerItem = 2.90;
                                break;

                            case "23":
                                myNewCrop.Crop = "~/Images/Vegetables/v20.jpg";
                                myNewCrop.CropName = "Peppers";
                                myNewCrop.CropDescription = "Peppers";
                                myNewCrop.Price = "$4.99";
                                myNewCrop.PricePerItem = 4.89;
                                break;

                            case "24":
                                myNewCrop.Crop = "~/Images/Vegetables/v14.png";
                                myNewCrop.CropName = "Mushrooms";
                                myNewCrop.CropDescription = "Mushrooms";
                                myNewCrop.Price = "$4.99";
                                myNewCrop.PricePerItem = 4.89;
                                break;

                            case "25":
                                myNewCrop.Crop = "~/Images/Vegetables/v26.jpg";
                                myNewCrop.CropName = "Tomatoes";
                                myNewCrop.CropDescription = "Tomatoes";
                                myNewCrop.Price = "$2.44";
                                myNewCrop.PricePerItem = 2.44;
                                break;

                            case "26":
                                myNewCrop.Crop = "~/Images/Vegetables/v6.png";
                                myNewCrop.CropName = "Cauliflower";
                                myNewCrop.CropDescription = "Cauliflower";
                                myNewCrop.Price = "$1.75";
                                myNewCrop.PricePerItem = 1.75;
                                break;

                            case "27":
                                myNewCrop.Crop = "~/Images/Vegetables/v30.png";
                                myNewCrop.CropName = "Potatoes";
                                myNewCrop.CropDescription = "Potatoes";
                                myNewCrop.Price = "$5.99";
                                myNewCrop.PricePerItem = 5.99;
                                break;

                            case "28":
                                myNewCrop.Crop = "~/Images/Vegetables/v25.jpg";
                                myNewCrop.CropName = "Potatoes";
                                myNewCrop.CropDescription = "Potatoes";
                                myNewCrop.Price = "$5.99";
                                myNewCrop.PricePerItem = 5.99;
                                break;

                            case "29":
                                myNewCrop.Crop = "~/Images/Vegetables/v21.jpg";
                                myNewCrop.CropName = "Potatoes";
                                myNewCrop.CropDescription = "Potatoes";
                                myNewCrop.Price = "$5.99";
                                myNewCrop.PricePerItem = 5.99;
                                break;

                            case "30":
                                myNewCrop.Crop = "~/Images/Vegetables/v28.jpg";
                                myNewCrop.CropName = "Potatoes";
                                myNewCrop.CropDescription = "Potatoes";
                                myNewCrop.Price = "$5.99";
                                myNewCrop.PricePerItem = 5.99;
                                break;

                            case "31":
                                myNewCrop.Crop = "~/Images/Vegetables/v24.jpg";
                                myNewCrop.CropName = "Squash";
                                myNewCrop.CropDescription = "Squash";
                                myNewCrop.Price = "$4.99";
                                myNewCrop.PricePerItem = 4.99;
                                break;

                            case "32":
                                myNewCrop.Crop = "~/Images/Vegetables/v18.jpg";
                                myNewCrop.CropName = "Radish";
                                myNewCrop.CropDescription = "Radish";
                                myNewCrop.Price = "$1.75";
                                myNewCrop.PricePerItem = 1.75;
                                break;

                            case "33":
                                myNewCrop.Crop = "~/Images/Vegetables/v22.jpg";
                                myNewCrop.CropName = "Rutabaga";
                                myNewCrop.CropDescription = "Rutabaga";
                                myNewCrop.Price = "$1.75";
                                myNewCrop.PricePerItem = 1.75;
                                break;

                            case "34":
                                myNewCrop.Crop = "~/Images/Fruits/f1.png";
                                myNewCrop.CropName = "Apples";
                                myNewCrop.CropDescription = "Apples";
                                myNewCrop.Price = "$2.44";
                                myNewCrop.PricePerItem = 2.44;
                                break;

                            case "35":
                                myNewCrop.Crop = "~/Images/Fruits/f2.png";
                                myNewCrop.CropName = "Grapes";
                                myNewCrop.CropDescription = "Grapes";
                                myNewCrop.Price = "$2.80";
                                myNewCrop.PricePerItem = 2.80;
                                break;

                            case "36":
                                myNewCrop.Crop = "~/Images/Fruits/f5.jpg";
                                myNewCrop.CropName = "Peaches";
                                myNewCrop.CropDescription = "Peaches";
                                myNewCrop.Price = "$1.89";
                                myNewCrop.PricePerItem = 1.89;
                                break;

                            case "37":
                                myNewCrop.Crop = "~/Images/Fruits/f4.jpg";
                                myNewCrop.CropName = "Oranges";
                                myNewCrop.CropDescription = "Oranges";
                                myNewCrop.Price = "$1.89";
                                myNewCrop.PricePerItem = 1.89;
                                break;

                            case "38":
                                myNewCrop.Crop = "~/Images/Fruits/f6.jpg";
                                myNewCrop.CropName = "Pears";
                                myNewCrop.CropDescription = "Pears";
                                myNewCrop.Price = "$2.90";
                                myNewCrop.PricePerItem = 2.90;
                                break;

                            case "39":
                                myNewCrop.Crop = "~/Images/Fruits/f3.png";
                                myNewCrop.CropName = "Mangos";
                                myNewCrop.CropDescription = "Mangos";
                                myNewCrop.Price = "$2.90";
                                myNewCrop.PricePerItem = 2.90;
                                break;

                            case "40":
                                myNewCrop.Crop = "~/Images/Fruits/f7.jpg";
                                myNewCrop.CropName = "Watermelon";
                                myNewCrop.CropDescription = "Watermelon";
                                myNewCrop.Price = "$4.99";
                                myNewCrop.PricePerItem = 4.89;
                                break;

                            case "41":
                                myNewCrop.Crop = "~/Images/Spices/s1.jpg";
                                myNewCrop.CropName = "Chives";
                                myNewCrop.CropDescription = "Chives";
                                myNewCrop.Price = "$2.44";
                                myNewCrop.PricePerItem = 2.44;
                                break;

                            case "42":
                                myNewCrop.Crop = "~/Images/Spices/s2.png";
                                myNewCrop.CropName = "Garlic";
                                myNewCrop.CropDescription = "Garlic";
                                myNewCrop.Price = "$2.80";
                                myNewCrop.PricePerItem = 2.80;
                                break;

                            case "43":
                                myNewCrop.Crop = "~/Images/Spices/s3.png";
                                myNewCrop.CropName = "Ginger";
                                myNewCrop.CropDescription = "Ginger";
                                myNewCrop.Price = "$1.89";
                                myNewCrop.PricePerItem = 1.89;
                                break;

                            case "44":
                                myNewCrop.Crop = "~/Images/Spices/s6.jpg";
                                myNewCrop.CropName = "Rosemary";
                                myNewCrop.CropDescription = "Rosemary";
                                myNewCrop.Price = "$1.89";
                                myNewCrop.PricePerItem = 1.89;
                                break;

                            case "45":
                                myNewCrop.Crop = "~/Images/Spices/s4.jpg";
                                myNewCrop.CropName = "Oregano";
                                myNewCrop.CropDescription = "Oregano";
                                myNewCrop.Price = "$2.90";
                                myNewCrop.PricePerItem = 2.90;
                                break;

                            case "46":
                                myNewCrop.Crop = "~/Images/Spices/s7.jpg";
                                myNewCrop.CropName = "Thyme";
                                myNewCrop.CropDescription = "Thyme";
                                myNewCrop.Price = "$2.90";
                                myNewCrop.PricePerItem = 2.90;
                                break;

                            case "47":
                                myNewCrop.Crop = "~/Images/Spices/s5.jpg";
                                myNewCrop.CropName = "Parsley";
                                myNewCrop.CropDescription = "Parsley";
                                myNewCrop.Price = "$4.99";
                                myNewCrop.PricePerItem = 4.89;
                                break;

                        }


                        The18th.Areas.Farming.Data.CropManager.AddGrowerCrop(myNewCrop);


                    }



                }


                Response.Redirect("~/Growers/GrowerAdmin/GrowerPage");

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
                        myNewCrop.GrowerName = pulledGrower.GrowerName;
                        myNewCrop.Crop = greensli.Text;
                        myNewCrop.CropIndex = greensli.Value;

                        switch (myNewCrop.CropIndex)
                        {


                            case "2":
                                myNewCrop.Crop = "~/Images/GhanaVegetables/gv2.png";
                                myNewCrop.CropName = "African Baobab";
                                myNewCrop.CropDescription = "African Baobab";
                                myNewCrop.Price = "&#8373 1.29";
                                myNewCrop.PricePerItem = 1.29;
                                break;


                            case "5":
                                myNewCrop.Crop = "~/Images/GhanaVegetables/gv5.png";
                                myNewCrop.CropName = "African Cabbage";
                                myNewCrop.CropDescription = "African Cabbage";
                                myNewCrop.Price = "&#8373 2.99";
                                myNewCrop.PricePerItem = 2.99;
                                break;


                            case "7":
                                myNewCrop.Crop = "~/Images/GhanaVegetables/gv8.png";
                                myNewCrop.CropName = "African Cow Peas";
                                myNewCrop.CropDescription = "African Cow Peas";
                                myNewCrop.Price = "&#8373 1.55";
                                myNewCrop.PricePerItem = 1.55;
                                break;


                            case "8":
                                myNewCrop.Crop = "~/Images/GhanaVegetables/gv9.png";
                                myNewCrop.CropName = "African EggPlant";
                                myNewCrop.CropDescription = "African EggPlant";
                                myNewCrop.Price = "&#8373 3.99";
                                myNewCrop.PricePerItem = 3.99;
                                break;


                            case "15":
                                myNewCrop.Crop = "~/Images/GhanaVegetables/gv16.png";
                                myNewCrop.CropName = "Ethiopian Kale";
                                myNewCrop.CropDescription = "Ethiopian Kale";
                                myNewCrop.Price = "&#8373 2.99";
                                myNewCrop.PricePerItem = 2.99;
                                break;

                            ///////////////////////////////////////////////////////////////
                            case "16":
                                myNewCrop.Crop = "~/Images/GhanaFruits/gf1.jpg";
                                myNewCrop.CropName = "African Avacado";
                                myNewCrop.CropDescription = "African Avacado";
                                myNewCrop.Price = "&#8373 4.99";
                                myNewCrop.PricePerItem = 4.99;

                                break;


                            case "17":
                                myNewCrop.Crop = "~/Images/GhanaFruits/gf2.jpg";
                                myNewCrop.CropName = "African Bannana";
                                myNewCrop.CropDescription = "Matoke";
                                myNewCrop.Price = "&#8373 3.99";
                                myNewCrop.PricePerItem = 3.99;

                                break;


                            case "19":
                                myNewCrop.Crop = "~/Images/GhanaFruits/gf4.jpg";
                                myNewCrop.CropName = "African Ebony";
                                myNewCrop.CropDescription = "African Ebony";
                                myNewCrop.Price = "&#8373 1.99";
                                myNewCrop.PricePerItem = 1.99;

                                break;

                            case "20":
                                myNewCrop.Crop = "~/Images/GhanaFruits/gf5.jpg";
                                myNewCrop.CropName = "African Kei Apple";
                                myNewCrop.CropDescription = "African Kei Apple";
                                myNewCrop.Price = "&#8373 2.99";
                                myNewCrop.PricePerItem = 2.99;

                                break;


                            case "21":
                                myNewCrop.Crop = "~/Images/GhanaFruits/gf6.jpg";
                                myNewCrop.CropName = "African Miracle Fruit";
                                myNewCrop.CropDescription = "African Miracle Fruit";
                                myNewCrop.Price = "&#8373 5.99";
                                myNewCrop.PricePerItem = 5.99;

                                break;

                            case "22":
                                myNewCrop.Crop = "~/Images/GhanaFruits/gf7.jpg";
                                myNewCrop.CropName = "African Papaya";
                                myNewCrop.CropDescription = "African Papaya";
                                myNewCrop.Price = "&#8373 7.99";
                                myNewCrop.PricePerItem = 7.99;

                                break;


                            case "23":
                                myNewCrop.Crop = "~/Images/GhanaFruits/gf8.jpg";
                                myNewCrop.CropName = "African Passion Fruit";
                                myNewCrop.CropDescription = "African Passion Fruit";
                                myNewCrop.Price = "&#8373 3.99";
                                myNewCrop.PricePerItem = 3.99;

                                break;


                            case "24":
                                myNewCrop.Crop = "~/Images/GhanaFruits/gf9.jpg";
                                myNewCrop.CropName = "African Pineapple";
                                myNewCrop.CropDescription = "African Pineapple";
                                myNewCrop.Price = "&#8373 6.99";
                                myNewCrop.PricePerItem = 6.99;

                                break;
                                //////////////////////////////////////////////////////
                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaVegetables/gv1.png";
                                //    //    myNewCrop.CropName = "African Amaranth";
                                //    //    myNewCrop.CropDescription = "African Amaranth";
                                //    //    myNewCrop.Price = "&#8373 1.10";
                                //    //    myNewCrop.PricePerItem = 1.10;
                                //    //    break;


                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaVegetables/gv2.png";
                                //    //    myNewCrop.CropName = "African Baobab";
                                //    //    myNewCrop.CropDescription = "African Baobab";
                                //    //    myNewCrop.Price = "&#8373 1.29";
                                //    //    myNewCrop.PricePerItem = 1.29;
                                //    //    break;


                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaVegetables/gv3.png";
                                //    //    myNewCrop.CropName = "African Bitter Leaf";
                                //    //    myNewCrop.CropDescription = "African Bitter Leaf";
                                //    //    myNewCrop.Price = "&#8373 0.60";
                                //    //    myNewCrop.PricePerItem = 0.60;
                                //    //    break;


                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaVegetables/gv4.png";
                                //    //    myNewCrop.CropName = "Black Knightshade";
                                //    //    myNewCrop.CropDescription = "African Black Knightshade";
                                //    //    myNewCrop.Price = "&#8373 0.99";
                                //    //    myNewCrop.PricePerItem = 0.99;
                                //    //    break;


                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaVegetables/gv5.png";
                                //    //    myNewCrop.CropName = "African Cabbage";
                                //    //    myNewCrop.CropDescription = "African Cabbage";
                                //    //    myNewCrop.Price = "&#8373 2.99";
                                //    //    myNewCrop.PricePerItem = 2.99;
                                //    //    break;


                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaVegetables/gv7.png";
                                //    //    myNewCrop.CropName = "African Carrots";
                                //    //    myNewCrop.CropDescription = "African Carrots";
                                //    //    myNewCrop.Price = "&#8373 1.09";
                                //    //    myNewCrop.PricePerItem = 1.09;
                                //    //    break;


                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaVegetables/gv8.png";
                                //    //    myNewCrop.CropName = "African Cow Peas";
                                //    //    myNewCrop.CropDescription = "African Cow Peas";
                                //    //    myNewCrop.Price = "&#8373 1.55";
                                //    //    myNewCrop.PricePerItem = 1.55;
                                //    //    break;


                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaVegetables/gv9.png";
                                //    //    myNewCrop.CropName = "African EggPlant";
                                //    //    myNewCrop.CropDescription = "African EggPlant";
                                //    //    myNewCrop.Price = "&#8373 3.99";
                                //    //    myNewCrop.PricePerItem = 3.99;
                                //    //    break;


                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaVegetables/gv10.png";
                                //    //    myNewCrop.CropName = "African Jute Mallo";
                                //    //    myNewCrop.CropDescription = "African Jute Mallo";
                                //    //    myNewCrop.Price = "&#8373 1.44";
                                //    //    myNewCrop.PricePerItem = 1.44;
                                //    //    break;


                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaVegetables/gv11.png";
                                //    //    myNewCrop.CropName = "African Peppers";
                                //    //    myNewCrop.CropDescription = "African Peppers";
                                //    //    myNewCrop.Price = "&#8373 1.22";
                                //    //    myNewCrop.PricePerItem = 1.22;
                                //    //    break;


                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaVegetables/gv12.png";
                                //    //    myNewCrop.CropName = "African Shallot";
                                //    //    myNewCrop.CropDescription = "African Shallot";
                                //    //    myNewCrop.Price = "&#8373 0.89";
                                //    //    myNewCrop.PricePerItem = 0.89;
                                //    //    break;

                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaVegetables/gv13.png";
                                //    //    myNewCrop.CropName = "African Nettle";
                                //    //    myNewCrop.CropDescription = "African Stinging Nettle";
                                //    //    myNewCrop.Price = "&#8373 0.99";
                                //    //    myNewCrop.PricePerItem = 0.99;
                                //    //    break;


                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaVegetables/gv14.png";
                                //    //    myNewCrop.CropName = "African Sweet Potato";
                                //    //    myNewCrop.CropDescription = "African Sweet Potato";
                                //    //    myNewCrop.Price = "&#8373 1.99";
                                //    //    myNewCrop.PricePerItem = 1.99;
                                //    //    break;


                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaVegetables/gv15.png";
                                //    //    myNewCrop.CropName = "African Water Leaf";
                                //    //    myNewCrop.CropDescription = "African Water Leaf";
                                //    //    myNewCrop.Price = "&#8373 0.30";
                                //    //    myNewCrop.PricePerItem = 0.30;
                                //    //    break;


                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaVegetables/gv16.png";
                                //    //    myNewCrop.CropName = "Ethiopian Kale";
                                //    //    myNewCrop.CropDescription = "Ethiopian Kale";
                                //    //    myNewCrop.Price = "&#8373 2.99";
                                //    //    myNewCrop.PricePerItem = 2.99;
                                //    //    break;



                                //    /////////////////////////////////////////////////////////////////
                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaFruits/gf1.jpg";
                                //    //    myNewCrop.CropName = "African Avacado";
                                //    //    myNewCrop.CropDescription = "African Avacado";
                                //    //    myNewCrop.Price = "&#8373 4.99";
                                //    //    myNewCrop.PricePerItem = 4.99;

                                //    //    break;


                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaFruits/gf2.jpg";
                                //    //    myNewCrop.CropName = "African Bannana";
                                //    //    myNewCrop.CropDescription = "Matoke";
                                //    //    myNewCrop.Price = "&#8373 3.99";
                                //    //    myNewCrop.PricePerItem = 3.99;

                                //    //    break;

                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaFruits/gf3.jpg";
                                //    //    myNewCrop.CropName = "African Baobab";
                                //    //    myNewCrop.CropDescription = "African Baobab";
                                //    //    myNewCrop.Price = "&#8373 4.99";
                                //    //    myNewCrop.PricePerItem = 4.99;

                                //    //    break;


                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaFruits/gf4.jpg";
                                //    //    myNewCrop.CropName = "African Ebony";
                                //    //    myNewCrop.CropDescription = "African Ebony";
                                //    //    myNewCrop.Price = "&#8373 1.99";
                                //    //    myNewCrop.PricePerItem = 1.99;

                                //    //    break;

                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaFruits/gf5.jpg";
                                //    //    myNewCrop.CropName = "African Kei Apple";
                                //    //    myNewCrop.CropDescription = "African Kei Apple";
                                //    //    myNewCrop.Price = "&#8373 2.99";
                                //    //    myNewCrop.PricePerItem = 2.99;

                                //    //    break;


                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaFruits/gf6.jpg";
                                //    //    myNewCrop.CropName = "African Miracle Fruit";
                                //    //    myNewCrop.CropDescription = "African Miracle Fruit";
                                //    //    myNewCrop.Price = "&#8373 5.99";
                                //    //    myNewCrop.PricePerItem = 5.99;

                                //    //    break;

                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaFruits/gf7.jpg";
                                //    //    myNewCrop.CropName = "African Papaya";
                                //    //    myNewCrop.CropDescription = "African Papaya";
                                //    //    myNewCrop.Price = "&#8373 7.99";
                                //    //    myNewCrop.PricePerItem = 7.99;

                                //    //    break;


                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaFruits/gf8.jpg";
                                //    //    myNewCrop.CropName = "African Passion Fruit";
                                //    //    myNewCrop.CropDescription = "African Passion Fruit";
                                //    //    myNewCrop.Price = "&#8373 3.99";
                                //    //    myNewCrop.PricePerItem = 3.99;

                                //    //    break;

                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaFruits/gf9.jpg";
                                //    //    myNewCrop.CropName = "African Pineapple";
                                //    //    myNewCrop.CropDescription = "African Pineapple";
                                //    //    myNewCrop.Price = "&#8373 6.99";
                                //    //    myNewCrop.PricePerItem = 6.99;

                                //    //    break;

                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaFruits/gf10.jpg";
                                //    //    myNewCrop.CropName = "African Apple";
                                //    //    myNewCrop.CropDescription = "African White Star Apple";
                                //    //    myNewCrop.Price = "&#8373 3.99";
                                //    //    myNewCrop.PricePerItem = 3.99;

                                //    //    break;


                                //    //case "#":
                                //    //    myNewCrop.Crop = "~/Images/GhanaFruits/gf11.jpg";
                                //    //    myNewCrop.CropName = "Mellon";
                                //    //    myNewCrop.CropDescription = "Mellon";
                                //    //    myNewCrop.Price = "&#8373 11.99";
                                //    //    myNewCrop.PricePerItem = 11.99;

                                //    //    break;

                        }


                        The18th.Areas.Farming.Data.CropManager.AddGrowerCrop(myNewCrop);
                        //The18th.Areas.Growers.Data.GrowerAdminManager.UpdateAGrowerCrops(myNewCrop);

                    }

                }

                Response.Redirect("~/Growers/GrowerAdmin/GrowerPageGhana");

            }

            return;


        }



    }
}