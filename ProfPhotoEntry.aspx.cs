using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class ProfPhotoEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                resultMessageLabel.Visible = false;

                viewHyperLink.Visible = false;

            }


            //2
            HttpCookie cookie = Request.Cookies["ProfessionalCookieInfo"];
            string profNumberCookie = cookie["profNumber"];
            string adminNumberCookie = cookie["adminEntryNumber"];

            ViewState.Add("ExistingProfNum", profNumberCookie);


            string _profType = Request.QueryString["profType"];

            string _firstName = Request.QueryString["firstName"];

            string _lastName = Request.QueryString["lastName"];

            string _location = Request.QueryString["location"];

            string _phone = Request.QueryString["phone"];

            string _email = Request.QueryString["email"];



            ViewState.Add("ExistingProfNum", profNumberCookie);

            ViewState.Add("ExistingProfType", _profType);

            ViewState.Add("ExistingFirst", _firstName);

            ViewState.Add("ExistingLast", _lastName);

            ViewState.Add("ExistingLocation", _location);

            ViewState.Add("ExistingPhone", _phone);

            ViewState.Add("ExistingEmail", _email);

            //not visable
            profNumberLabel.Text = profNumberCookie;
            //visable
            profTypeLabel.Text = _profType;

            firstNameLabel.Text = _firstName;

            lastNameLabel.Text = _lastName;

            locationLabel.Text = _location;

            phoneLabel.Text = _phone;

            emailLabel.Text = _email;



        }

        protected void uploadButton_Click(object sender, EventArgs e)
        {

            resultLabel.Text = ViewState["ExistingProfNum"].ToString();

            var fromExistingProfNumber = resultLabel.Text;


            firstNameLabel.Text = ViewState["ExistingFirst"].ToString();

            var fromExistingFirstName = firstNameLabel.Text;


            HttpPostedFile postedFile = photoFileUpload.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);
            int fileSize = postedFile.ContentLength;

            //Need resizing here!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".jpeg" || fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".heic" || fileExtension.ToLower() == ".heif" || fileExtension.ToLower() == ".bmp")
            {

                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                byte[] bytes = binaryReader.ReadBytes((int)stream.Length);


                //Check bytes if problem exist
                The18th.Areas.MemberShip.MemberShipDTOs.ClientPhotoDto myProfPhoto = new The18th.Areas.MemberShip.MemberShipDTOs.ClientPhotoDto();
                myProfPhoto.SubmissionType = "Professional";
                myProfPhoto.ClientNumber = fromExistingProfNumber;
                myProfPhoto.ClientName = fromExistingFirstName;
                myProfPhoto.Name = fileName;
                myProfPhoto.Size = fileSize;
                myProfPhoto.ImageData = bytes;

                string cs = ConfigurationManager.ConnectionStrings["OneFarmData"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {

                    //SqlCommand cmd = new SqlCommand("spInsertSimplePhoto", con);
                    SqlCommand cmd = new SqlCommand("spInsertClientPhoto", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramSubmissionType = new SqlParameter()
                    {
                        ParameterName = "@SubmissionType",
                        Value = myProfPhoto.SubmissionType
                    };
                    cmd.Parameters.Add(paramSubmissionType);

                    SqlParameter paramClientNumber = new SqlParameter()
                    {
                        ParameterName = "@ClientNumber",
                        Value = myProfPhoto.ClientNumber
                    };
                    cmd.Parameters.Add(paramClientNumber);

                    SqlParameter paramClientName = new SqlParameter()
                    {
                        ParameterName = "@ClientName",
                        Value = myProfPhoto.ClientName
                    };
                    cmd.Parameters.Add(paramClientName);

                    SqlParameter paramName = new SqlParameter()
                    {
                        ParameterName = "@Name",
                        Value = myProfPhoto.Name
                    };
                    cmd.Parameters.Add(paramName);

                    SqlParameter paramSize = new SqlParameter()
                    {
                        ParameterName = "@Size",
                        Value = myProfPhoto.Size

                    };
                    cmd.Parameters.Add(paramSize);

                    SqlParameter paramImageData = new SqlParameter()
                    {
                        ParameterName = "@ImageData",
                        Value = bytes
                    };
                    cmd.Parameters.Add(paramImageData);
                    //cmd.Parameters.Add("@ImageData", SqlDbType.VarBinary).Value = bytes;


                    SqlParameter paramNewId = new SqlParameter()
                    {
                        ParameterName = "@NewId",
                        Value = -1,
                        Direction = ParameterDirection.Output,
                    };
                    cmd.Parameters.Add(paramNewId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    resultMessageLabel.Visible = true;

                    resultMessageLabel.Text = "Upload Complete";

                    resultMessageLabel.ForeColor = System.Drawing.Color.Green;

                    viewHyperLink.Visible = true;

                    viewHyperLink.NavigateUrl = "~/ProfPhotoEntryReview.aspx?Id=" + cmd.Parameters["@NewId"].Value.ToString();

                    return;

                }

            }
            else
            {

                resultMessageLabel.Visible = true;

                resultMessageLabel.Text = "Upload a valid photo";

                resultMessageLabel.ForeColor = System.Drawing.Color.Red;

                viewHyperLink.Visible = false;
            }

        }

        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");


        }

    }
}