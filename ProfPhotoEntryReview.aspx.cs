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
    public partial class ProfPhotoEntryReview : System.Web.UI.Page
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

                profImage.ImageUrl = "data:Image/png;base64," + strBase64;

            }




            //2
            HttpCookie cookie = Request.Cookies["ProfessionalCookieInfo"];
            string profNumberCookie = cookie["profNumber"];
            string adminNumberCookie = cookie["adminEntryNumber"];


            ViewState.Add("ExistingProfNum", profNumberCookie);

            profNumberLabel.Text = profNumberCookie;


            string simplePhotoNumber = Request.QueryString["Id"];

            ViewState.Add("ExistingSimpleId", simplePhotoNumber);

            simplePhotoLabel.Text = simplePhotoNumber;



        }

        protected void savePhotoButton_Click(object sender, EventArgs e)
        {


            resultLabel.Text = ViewState["ExistingProfNum"].ToString();

            var fromExistingProfessionalNumber = resultLabel.Text;


            //
            var pulledProfessional = The18th.Areas.Meek.Data.RunUpAdminManager.GetAProfessionalInfo(fromExistingProfessionalNumber);

            //
            var pulledPhoto = The18th.Areas.Meek.Data.RunUpAdminManager.GetAProfessionalPhoto(fromExistingProfessionalNumber);


            The18th.Areas.Directory.DirectoryDTOs.ProfessionalListingDto profListing = new The18th.Areas.Directory.DirectoryDTOs.ProfessionalListingDto();
            profListing.ProfessionalListingID = pulledProfessional.ProfessionalID;
            profListing.MembershipNumber = pulledProfessional.MembershipNumber;
            profListing.ProfessionalNumber = pulledProfessional.ProfessionalNumber;
            profListing.ImageData = pulledPhoto.ImageData;
            profListing.ProfessionalType = pulledProfessional.ProfessionalType;
            profListing.FirstName = pulledProfessional.FirstName;
            profListing.LastName = pulledProfessional.LastName;
            profListing.Location = pulledProfessional.Location;
            profListing.Phone = pulledProfessional.Phone;
            profListing.Email = pulledProfessional.Email;

            try
            {


                if (profListing.ProfessionalNumber.Trim().Length == 0)
                    throw new NotImplementedException("please complete all required fields");


                //
                //The18th.Areas.Meek.Data.RunUpAdminManager.AddProfessionalListing(profListing);
            }

            catch (Exception ex)
            {

                string message = "";

                message = ex.Message;

            }


            //Still need to implement
            Response.Redirect("~/ProfessionalConfirmation.aspx?firstName=" + profListing.FirstName);




        }



    }
}