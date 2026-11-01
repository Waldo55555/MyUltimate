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
    public partial class ComPhotoEntryReview : System.Web.UI.Page
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

                comImage.ImageUrl = "data:Image/png;base64," + strBase64;

            }


            //2
            HttpCookie cookie = Request.Cookies["CommitteeCookieInfo"];
            string accountNumberCookie = cookie["comAcctNumber"];

            ViewState.Add("ExistingComNum", accountNumberCookie);

            comNumberLabel.Text = accountNumberCookie;


            string simplePhotoNumber = Request.QueryString["Id"];

            ViewState.Add("ExistingSimpleId", simplePhotoNumber);

            simplePhotoLabel.Text = simplePhotoNumber;





        }

        protected void savePhotoButton_Click(object sender, EventArgs e)
        {

            resultLabel.Text = ViewState["ExistingComNum"].ToString();

            var fromExistingComNumber = resultLabel.Text;


            Response.Redirect("~/CommitteeConfirmation.aspx");



        }



    }
}