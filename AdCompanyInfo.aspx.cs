using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The18th.Exceptions;

namespace The18th
{
    public partial class AdCompanyInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string placement = "Advertisements";

            SlideAd(placement);

            try
            {

                if (Page.IsPostBack == false)
                {

                    //userCountLabel.Text = Application.Get("userCount").ToString();

                }

            }

            catch (Exception ex)
            {

                string message = "Nothing Here";

                message = ex.Message;

            }


            //if (!Page.IsPostBack)
            //{

            //    campaignMessageLabel.Visible = false;
            //    campaignTotalLabel.Visible = false;

            //}


        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
                       

                try
                {

                    The18th.Areas.Ads.AdDTOs.AdCompanyInfoDto companyInfo = new The18th.Areas.Ads.AdDTOs.AdCompanyInfoDto();
                    companyInfo.AdCompanyInfoID = Guid.NewGuid();
                    companyInfo.AccountNumber = createAdNumber();
                    companyInfo.CompanyName = companyNameTextBox.Text;
                    companyInfo.Phone = companyPhoneTextBox.Text;
                    companyInfo.Email = companyEmailTextBox.Text;

                    if (companyInfo.CompanyName.Trim().Length == 0)
                        throw new Exceptions.RequiredException("please complete all required fields");

                    if (companyInfo.Phone.Trim().Length == 0)
                        throw new Exceptions.RequiredException("please complete all required fields");

                    if (companyInfo.Email.Trim().Length == 0)
                        throw new Exceptions.RequiredException("please complete all required fields");


                    if (Page.IsValid)
                    {
                                               
                            ////////Cookie Start
                            HttpCookie genCookie = new HttpCookie("GeneralAdInfo");
                            genCookie["companyName"] = companyInfo.CompanyName;
                            genCookie["phone"] = companyInfo.Phone;
                            genCookie["email"] = companyInfo.Email;
                            genCookie["account"] = companyInfo.AccountNumber;
                            Response.Cookies.Add(genCookie);
                            /////////Cookie End

                            The18th.Areas.Ads.Data.AdManager.InsertAdCompany(companyInfo);

                            Response.Redirect("~/TargetLocationEntry.aspx?companyName=" + companyInfo.CompanyName
                               + "&phone=" + companyInfo.Phone
                               + "&email=" + companyInfo.Email
                               + "&account=" + companyInfo.AccountNumber
                              );

                    }


                    else
                    {

                        //exceptionLabel.Text = "Please Correct Problems!";
                        //exceptionLabel.ForeColor = System.Drawing.Color.Red;


                    }



                 }


                catch (RequiredException ex)
                {

                    string message = ex.MessageError;

                    exceptionLabel.Text = message;

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

                    return;

                }
                           

        }


        private string createAdNumber()
        {

            Random random = new Random();
            random.Next(59864343, 87395235);

            int myAd = random.Next();

            int adSeed = int.Parse(myAd.ToString());

            var myAdNumber = String.Format("{0: 00000000}", adSeed);

            ViewState.Add("ADSeed", myAdNumber);

            return (myAdNumber);
        }


        ////////////////////////////////////////////////////////////////////////////
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            string placement = "Advertisements";

            SlideAd(placement);
        }

        //Original....1, 6
        //private void SlideAd()
        //{
        //    Random _rand = new Random();
        //    int i = _rand.Next(1, 4);

        //    Image1.ImageUrl = "~/SlideAdsPics/" + i.ToString() + ".jpg";
        //}

        private void SlideAd(string placement)
        {
            Random rnd = new Random();
            string[] banners = new string[5];
            banners[0] = "1.jpg";
            banners[1] = "2.jpg";
            banners[2] = "3.jpg";
            banners[3] = "4.jpg";
            banners[4] = "5.jpg";
            // Generate random indexes for banners.
            int mIndex = rnd.Next(banners.Length);

            Image1.ImageUrl = "https://the18thstorage.blob.core.windows.net/slides/" + banners[mIndex].ToString();

        }

        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");


        }


    }

}