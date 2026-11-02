using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Web.Script.Serialization;
//using The18th.Areas.Market.MarketDTOs;
using System.Net.Http;
using System.Activities;


namespace The18th
{
    public partial class MarketLocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Original

            string ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ipAddress))
            {

                ipAddress = Request.ServerVariables["REMOTE_ADDR"];

            }

            //string APIKey = "<Your API Key>";
            //without brackets
            string APIKey = "F395891D860BA05EA67586164BC7440C";
            string url = string.Format("http://api.ipinfodb.com/v3/ip-city/?key={0}&ip={1}&format=json", APIKey, ipAddress);
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                Location location = new JavaScriptSerializer().Deserialize<Location>(json);
                List<Location> locations = new List<Location>();
                locations.Add(location);
                gvLocation.DataSource = locations;
                gvLocation.DataBind();
            }


            //Working on 12-23-23

            if ("Texas" == ipAddress)

            {

                //Response.Redirect("Market/MyMarket/Browse?donorNumber=" + myDonation.DonorNumber);

                Response.Redirect("Market/MyMarket/Browse");

            }
            //Working on end 12-23-23


        }

        protected void submitButton_Click(object sender, EventArgs e)
        {


        }


    }


    public class Location
    {
        public string IPAddress { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public string ZipCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string TimeZone { get; set; }
    }





}
