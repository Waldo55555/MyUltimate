using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The18th.Exceptions;

namespace The18th
{
    public partial class AdminAdEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ////need admin cookie here

            HttpCookie adminCookie = Request.Cookies["AdminCookieInfo"];
            string myAdminNumber = adminCookie["adminNumber"];

            if (!Page.IsPostBack)
            {

                campaignMessageLabel.Visible = false;
                campaignTotalLabel.Visible = false;

            }

            //New
            //string cs = ConfigurationManager.ConnectionStrings["OneFarmData"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(cs))
            //{
            //    SqlCommand cmd = new SqlCommand("Select CountyLookUpId, CountyName, State, CountyImage From tblCountyLookUp", con);
            //    con.Open();

            //    targetLocationDropDownList.DataSource = cmd.ExecuteReader();
            //    targetLocationDropDownList.DataBind();

            //}

            //New End


        }

        protected void submitButton_Click(object sender, EventArgs e)
        {

            try
            {

                The18th.Areas.Ads.AdDTOs.AdvertisementDto adSpecs = new The18th.Areas.Ads.AdDTOs.AdvertisementDto();
                adSpecs.AdType = "";
                adSpecs.CampaignTotal = 0.0;

                if (adTypeDropDownList.SelectedValue == "Basic")
                {
                    adSpecs.AdType = "Basic";
                    adSpecs.CampaignTotal = 99.99;
                }

                if (adTypeDropDownList.SelectedValue == "Medium")
                {
                    adSpecs.AdType = "Medium";
                    adSpecs.CampaignTotal = 139.99;
                }

                if (adTypeDropDownList.SelectedValue == "Premium")
                {
                    adSpecs.AdType = "Premium";
                    adSpecs.CampaignTotal = 299.99;
                }


                The18th.Areas.Ads.AdDTOs.AdvertisementDto finalAd = new The18th.Areas.Ads.AdDTOs.AdvertisementDto();
                finalAd.AdvertisementID = Guid.NewGuid();
                finalAd.AccountNumber = createAccountNumber().Trim();
                finalAd.CompanyName = companyNameTextBox.Text;
                finalAd.Phone = companyPhoneTextBox.Text;
                finalAd.Email = companyEmailTextBox.Text;
                finalAd.CampaignType = campaignTypeDropDownList.SelectedValue;
                finalAd.CampaignSchedule = scheduleTypeDropDownList.SelectedValue;
                finalAd.AdType = adSpecs.AdType;
                //finalAd.TargetLocation = targetLocationDropDownList.SelectedValue;
                finalAd.BannerDesign = designCheckBox.Checked;
                finalAd.CampaignTotal = adSpecs.CampaignTotal;
                finalAd.AdStatus = "Pending";
                finalAd.Deposit = 0.00;
                finalAd.EstimatedTotal = adSpecs.CampaignTotal;
                finalAd.Tax = 8.25;

                //if (finalAd.Phone.Trim().Length == 0)
                //    throw new Exceptions.RequiredException("please complete all required fields");

                //if (finalAd.Email.Trim().Length == 0)
                //    throw new Exceptions.RequiredException("please complete all required fields");

                //if (finalAd.CampaignType == "Select Campaign...")
                //    throw new Exceptions.RequiredException("please complete all required fields");

                //if (finalAd.MarketType.Trim().Length == 0)
                //    throw new Exceptions.RequiredException("please complete all required fields");

                //if (finalAd.AdType.Trim().Length == 0)
                //    throw new Exceptions.RequiredException("please complete all required fields");

                //if (finalAd.TargetCustomer == "Select Target Market...")
                //    throw new Exceptions.RequiredException("please complete all required fields");

                //if (finalAd.TargetLocation == "Select Target Location...")
                //    throw new Exceptions.RequiredException("please complete all required fields");

                //Up For Deletion....moved to banner photo review
                The18th.Areas.Ads.Data.AdManager.InsertAdvertisement(finalAd);

                //////Cookie Start
                HttpCookie adCookie = new HttpCookie("AdminAdInfo");
                adCookie["accountNum"] = finalAd.AccountNumber;
                adCookie["company"] = finalAd.CompanyName;
                Response.Cookies.Add(adCookie);
                ///////Cookie End

                Response.Redirect("~/AdminBannerEntry.aspx?companyName=" + finalAd.CompanyName
               + "&phone=" + finalAd.Phone
               + "&email=" + finalAd.Email

              );


            }

            catch (RequiredException ex)
            {
                string message = ex.MessageError;

                return;
            }

            catch (NullReferenceException ex)
            {
                string message = ex.Message;
            }

            catch (Exception ex)
            {
                string message = "";

                message = ex.Message;

                //return;

            }

            //Response.Redirect("~/Default.aspx");


        }


        protected void adTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (adTypeDropDownList.SelectedValue == "-1")
            {
                campaignMessageLabel.Visible = false;
                campaignTotalLabel.Visible = false;
            }

            else if (adTypeDropDownList.SelectedValue == "Basic")
            {

                campaignMessageLabel.Visible = true;


                campaignTotalLabel.Visible = true;
                campaignTotalLabel.Text = "99.99";

            }

            else if (adTypeDropDownList.SelectedValue == "Medium")
            {

                campaignMessageLabel.Visible = true;

                campaignTotalLabel.Visible = true;
                campaignTotalLabel.Text = "139.99";
            }

            else if (adTypeDropDownList.SelectedValue == "Premium")
            {

                campaignMessageLabel.Visible = true;

                campaignTotalLabel.Visible = true;
                campaignTotalLabel.Text = "299.99";
            }

            else
                return;

        }

        private string createAccountNumber()
        {

            Random random = new Random();
            random.Next(59864343, 87395235);

            int mySeed = random.Next();

            int farmSeed = int.Parse(mySeed.ToString());

            var myAdAccountNumber = String.Format("{0: 00000000}", farmSeed);

            ViewState.Add("AdSeed", myAdAccountNumber);


            return (myAdAccountNumber);
        }


        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");


        }



    }
}