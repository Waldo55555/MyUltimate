using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class AddCampaign : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie myAdmincookie = Request.Cookies["AdminInfo"];
            string campaignNumber = myAdmincookie["campaignNumber"];
            string companyName = myAdmincookie["companyName"];
            string phone = myAdmincookie["phone"];
            string email = myAdmincookie["email"];


            string notApplied = Request.QueryString["Id"];

            companyLabel.Text = companyName;
            phoneLabel.Text = phone;
            emailLabel.Text = email;


            string cs = ConfigurationManager.ConnectionStrings["OneStateData"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand("spGetBannerById", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter()
                {
                    ParameterName = "@PhotoId",
                    Value = Request.QueryString["Id"]
                };
                cmd.Parameters.Add(paramId);

                con.Open();
                byte[] bytes = (byte[])cmd.ExecuteScalar();
                //con.Close();

                string strBase64 = Convert.ToBase64String(bytes);

                vendorImage.ImageUrl = "data:Image/png;base64," + strBase64;


            }

        }

        protected void startCampaignButton_Click(object sender, EventArgs e)
        {

            HttpCookie myAdmincookie = Request.Cookies["AdminInfo"];
            string campaignNumber = myAdmincookie["campaignNumber"];
            string companyName = myAdmincookie["companyName"];
            string phone = myAdmincookie["phone"];
            string email = myAdmincookie["email"];

            //New.......working on
            var ban = The18th.Areas.Ads.Data.AdManager.GetABannerPhoto(campaignNumber);

            The18th.Areas.Ads.AdDTOs.CampaignDto myCamp = new The18th.Areas.Ads.AdDTOs.CampaignDto();
            myCamp.CampaignNumber = campaignNumber;
            myCamp.Placement = placementDropDownList.SelectedValue;
            myCamp.AdType = adTypeDropDownList.SelectedValue;
            myCamp.AdDuration = DateTime.Now.AddDays(30);
            myCamp.Frequency = ban.Frequency;
            myCamp.Name = ban.Name;
            myCamp.ImageUrl = ban.BannerExtention;
            myCamp.ImageData = ban.ImageData;
            myCamp.AdRate = double.Parse(adRateDropDownList.SelectedValue.ToString());
            //following throws exception
            //myCamp.Slot = DateTime.Parse(slotDropDownList.SelectedValue);
            myCamp.Slot = DateTime.Now;
            myCamp.AdStartDate = DateTime.Now;
            myCamp.AdEndDate = DateTime.Now.AddDays(30);
            myCamp.AdStatus = statusDropDownList.SelectedValue;
            //myCamp.ImageUrl = camp.ImageUrl;


            //New.......working on End

            The18th.Areas.Ads.AdDTOs.SlideDto mySlide = new The18th.Areas.Ads.AdDTOs.SlideDto();
            mySlide.SlideID = Guid.NewGuid();
            mySlide.FileName = "https://the18thstorage.blob.core.windows.net/slides/" + ban.ImageData;
            mySlide.ImageData = ban.ImageData;


            try
            {
                //if (clientAd.AccountNumber.Trim().Length == 0)
                //    throw new NotImplementedException("Sorry Something is missing");

                The18th.Areas.Ads.Data.AdManager.InsertCampaign(myCamp);

                The18th.Areas.Ads.Data.AdManager.InsertSlide(mySlide);


            }

            catch (Exception ex)
            {
                string message = "";

                message = ex.Message;

            }

            //All of these are meant for admin
            //There is no need to upload a banner because it 
            //is already being approved from pendingAds


            Response.Redirect("~/AdminAdConfirmation.aspx");


            Response.Redirect("~/AdminAdConfirmation.aspx?companyName=" + companyName
             + "&phone=" + phone
             + "&email=" + email
            );




        }




    }
}