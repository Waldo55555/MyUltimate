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
    public partial class ProviderPhotoEntryReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            string cs = ConfigurationManager.ConnectionStrings["OneFarmData"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {


                SqlCommand cmd = new SqlCommand("spGetClientPhotoById", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = Request.QueryString["Id"]
                };
                cmd.Parameters.Add(paramId);

                con.Open();
                byte[] bytes = (byte[])cmd.ExecuteScalar();
                //con.Close();

                string strBase64 = Convert.ToBase64String(bytes);

                provImage.ImageUrl = "data:Image/png;base64," + strBase64;

            }

            //2
            HttpCookie cookie = Request.Cookies["AdminCookieInfo"];
            string adminNumberCookie = cookie["adminNumber"];

            ViewState.Add("ExistingAdminNum", adminNumberCookie);

            provNumberLabel.Text = adminNumberCookie.Trim();


            string simplePhotoNumber = Request.QueryString["Id"];

            ViewState.Add("ExistingSimpleId", simplePhotoNumber);

            simplePhotoLabel.Text = simplePhotoNumber;

        }

        protected void savePhotoButton_Click(object sender, EventArgs e)
        {

            resultLabel.Text = ViewState["ExistingAdminNum"].ToString();

            var fromExistingProvNumber = resultLabel.Text;

            //
            var pulledProv = The18th.Areas.Directory.Data.ServicePartnerManager.GetAProviderInfo(fromExistingProvNumber);

            //Not Implemented
            //var pulledPhoto = The18th.Areas.Directory.Data.ServicePartnerManager.GetAProviderPhoto(fromExistingProvNumber);


            The18th.Areas.Directory.DirectoryDTOs.ServicePartnerDto provListing = new The18th.Areas.Directory.DirectoryDTOs.ServicePartnerDto();
            provListing.ServicePartnerID = pulledProv.ServicePartnerID;
            provListing.ListNumber = pulledProv.ListNumber;
            provListing.ServiceImage = pulledProv.ServiceImage;
            provListing.ServiceType = pulledProv.ServiceType;
            provListing.ServiceDescription = pulledProv.ServiceDescription;
            provListing.CompanyName = pulledProv.CompanyName;
            provListing.RepresentativeName = pulledProv.RepresentativeName;
            provListing.Location = pulledProv.Location;
            provListing.Phone = pulledProv.Phone;
            provListing.Email = pulledProv.Email;
            provListing.Facebook = pulledProv.Facebook;
            provListing.Twitter = pulledProv.Twitter;
            provListing.WebAddress = pulledProv.WebAddress;


            try
            {


                if (provListing.ListNumber.Trim().Length == 0)
                    throw new NotImplementedException("please complete all required fields");

                //makes a double insert
                //The18th.Areas.Directory.Data.ServicePartnerManager.InsertAProvider(provListing);

            }

            catch (Exception ex)
            {

                string message = "";

                message = ex.Message;

            }


            Response.Redirect("~/ProviderConfirmation.aspx?firstName=" + provListing.CompanyName);


        }



    }
}