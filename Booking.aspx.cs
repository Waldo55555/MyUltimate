using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The18th.Exceptions;

namespace The18th
{
    public partial class Booking1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ///////////////////////////Ads/User Count Start//////////////////////////////////////////////////

            string placement = "Booking";

            SlideAd(placement);

            try
            {

                if (Page.IsPostBack == false)
                {

                    userCountLabel.Text = Application.Get("userCount").ToString();

                }

            }

            catch (Exception ex)
            {

                string message = "Nothing Here";

                message = ex.Message;

            }

            ///////////////////////////Ads/User Count End//////////////////////////////////////////////////
            HttpCookie myBookcookie = Request.Cookies["BookingCookieInfo"];
            string profNumber = myBookcookie["profNumber"];
            //string memberAccountNumber = myBookcookie["memNumber"];

            //ViewState.Add("ExistingMemberNum", memberAccountNumber);

            //memberNumberLabel.Text = memberAccountNumber;

            ViewState.Add("ExistingProfNum", profNumber);

            professionalNumberLabel.Text = profNumber;


            try
            {

                //if (string.IsNullOrEmpty(memberNumberLabel.Text))
                //    throw new BadNavigationException("Sorry....You Are In The Wrong Place.");

            }

            catch (BadNavigationException ex)
            {

                string message = ex.Message;

                bookExceptionLabel.Text = message;

                Server.TransferRequest("/AllProfessionalsPaged");

                return;

            }




        }

        protected void bookButton_Click(object sender, EventArgs e)
        {

            //memberNumberLabel.Text = ViewState["ExistingMemberNum"].ToString();

            //var fromExistingMemberNumber = memberNumberLabel.Text;

            professionalNumberLabel.Text = ViewState["ExistingProfNum"].ToString();

            var fromExistingProfNumber = professionalNumberLabel.Text;

            ///////////////////////////////////////////////////////
            The18th.Areas.Directory.DirectoryDTOs.BookingDto bookSetUp = new The18th.Areas.Directory.DirectoryDTOs.BookingDto();

            //////////////////////////////////////////////////////
            The18th.Areas.Directory.DirectoryDTOs.BookingDto myBookNumber = createBookNumber(bookSetUp);
            myBookNumber.BookingNumber = myBookNumber.BookingNumber.Trim();


            try
            {

                //if (firstBooking.BookingNumber.Trim().Length == 0)
                //    throw new Exceptions.RequiredException("please complete all required fields");



            }

            catch (RequiredException ex)
            {

                string message = ex.MessageError;

                bookExceptionLabel.Text = message;

                return;

            }

            catch (FormatException ex)
            {

                string message = ex.Message;

                bookExceptionLabel.Text = "Please Correct Following Errors";

                phoneErrorLabel.Text = message;

                return;

            }

            catch (NullReferenceException ex)
            {

                string message = ex.Message;

                bookExceptionLabel.Text = message;

            }

            catch (Exception ex)
            {

                string message = "";

                message = ex.Message;

                bookExceptionLabel.Text = message;

                return;

            }

            string mySelection = string.Empty;

            if (consultationRadioButton.Checked)
            {

                mySelection = "Selection Made";

            }

            else if (estimateRadioButton.Checked)
            {

                mySelection = "Selection Made";

            }

            else

                throw new Exceptions.RequiredException("please select a booking.");


            if (consultationRadioButton.Checked == true)
            {

                The18th.Areas.Directory.DirectoryDTOs.BookingDto basic = new The18th.Areas.Directory.DirectoryDTOs.BookingDto();
                basic.ProfessionalNumber = fromExistingProfNumber;
                //basic.MemberNumber = fromExistingMemberNumber;
                basic.BookingNumber = myBookNumber.BookingNumber;
                basic.BookingType = "Zoom Meeting";
                basic.FirstName = firstNameTextBox.Text;
                basic.LastName = lastNameTextBox.Text;
                basic.Phone = phoneNumberTextBox.Text;
                basic.Email = emailTextBox.Text;
                basic.BookingStatus = "Pending";
                basic.ServiceName = "Booking";
                basic.ServiceDescription = "Basic Booking";
                basic.MyConsultation = "Selected";
                basic.MyEstimate = "Not Selected";
                basic.BookFee = "0.99";
                basic.BookingFee = 0.99;

                The18th.Areas.Directory.Data.DirectoryManager.AddBooking(basic);

                bookingStatusTextBox.Text = basic.BookingStatus;

                The18th.Areas.Directory.DirectoryDTOs.BookingFeeDto bookFee = new The18th.Areas.Directory.DirectoryDTOs.BookingFeeDto();
                bookFee.BookingFeeID = basic.BookingID;
                bookFee.ProfessionalNumber = basic.ProfessionalNumber;
                bookFee.BookingNumber = basic.BookingNumber;
                bookFee.MemberNumber = basic.MemberNumber;
                bookFee.Fee = 0.99;
                bookFee.BookingCount = 1;

                The18th.Areas.Directory.Data.DirectoryManager.AddBookingFee(bookFee);

                ViewState.Add("ViewStateItem", bookingStatusTextBox.Text);


                firstNameTextBox.Text = "";
                lastNameTextBox.Text = "";
                phoneNumberTextBox.Text = "";
                emailTextBox.Text = "";
                consultationRadioButton.Checked = false;
                estimateRadioButton.Checked = false;


                ////////Cookie Start
                HttpCookie cookie = new HttpCookie("BookInfo");
                cookie["profNumber"] = basic.ProfessionalNumber;
                cookie["bookNumber"] = basic.BookingNumber;
                //cookie["memNumber"] = basic.MemberNumber;
                Response.Cookies.Add(cookie);
                /////////Cookie End


                Response.Redirect("~/Appointment.aspx?bookType=" + basic.BookingType
                + "&firstName=" + basic.FirstName
                + "&fee=" + basic.BookFee
                + "&status=" + basic.BookingStatus
                + "&consult=" + basic.MyConsultation
                + "&email=" + basic.Email
                );


            }

            else if (estimateRadioButton.Checked == true)
            {


                The18th.Areas.Directory.DirectoryDTOs.BookingDto premium = new The18th.Areas.Directory.DirectoryDTOs.BookingDto();
                premium.ProfessionalNumber = fromExistingProfNumber;
                //premium.MemberNumber = fromExistingMemberNumber;
                premium.BookingNumber = myBookNumber.BookingNumber;
                premium.BookingType = "In-Person Consult";
                premium.FirstName = firstNameTextBox.Text;
                premium.LastName = lastNameTextBox.Text;
                premium.Phone = phoneNumberTextBox.Text;
                premium.Email = emailTextBox.Text;
                premium.BookingStatus = "Pending";
                premium.ServiceName = "Booking";
                premium.ServiceDescription = "Basic Booking";
                premium.MyConsultation = "Not Selected";
                premium.MyEstimate = "Selected";
                premium.BookFee = "0.99";
                premium.BookingFee = 0.99;


                The18th.Areas.Directory.Data.DirectoryManager.AddBooking(premium);

                bookingStatusTextBox.Text = premium.BookingStatus;

                The18th.Areas.Directory.DirectoryDTOs.BookingFeeDto bookFee = new The18th.Areas.Directory.DirectoryDTOs.BookingFeeDto();
                bookFee.BookingFeeID = premium.BookingID;
                bookFee.ProfessionalNumber = premium.ProfessionalNumber;
                bookFee.BookingNumber = premium.BookingNumber;
                bookFee.MemberNumber = premium.MemberNumber;
                bookFee.Fee = 0.99;
                bookFee.BookingCount = 1;

                The18th.Areas.Directory.Data.DirectoryManager.AddBookingFee(bookFee);


                ViewState.Add("ViewStateItem", bookingStatusTextBox.Text);

                firstNameTextBox.Text = "";
                lastNameTextBox.Text = "";
                phoneNumberTextBox.Text = "";
                emailTextBox.Text = "";
                consultationRadioButton.Checked = false;
                estimateRadioButton.Checked = false;

                ////////Cookie Start
                HttpCookie cookie = new HttpCookie("BookInfo");
                cookie["profNumber"] = premium.ProfessionalNumber;
                cookie["bookNumber"] = premium.BookingNumber;
                //cookie["memNumber"] = premium.MemberNumber;
                Response.Cookies.Add(cookie);
                /////////Cookie End

                Response.Redirect("~/Appointment.aspx?bookType=" + premium.BookingType
                 + "&firstName=" + premium.FirstName
                 + "&fee=" + premium.BookFee
                 + "&status=" + premium.BookingStatus
                 + "&consult=" + premium.MyConsultation
                 + "&email=" + premium.Email
                 );



            }



        }


        ///////////////////////////////////Helper Methods
        private The18th.Areas.Directory.DirectoryDTOs.BookingDto createBookNumber(The18th.Areas.Directory.DirectoryDTOs.BookingDto myBook)
        {

            The18th.Areas.Directory.DirectoryDTOs.BookingDto createNumber = new The18th.Areas.Directory.DirectoryDTOs.BookingDto();
            createNumber.BookingID = myBook.BookingID;
            createNumber.BookingNumber = myBook.BookingNumber;

            Random random = new Random();
            random.Next(59864, 87395);

            int myBookNumber = random.Next();

            int bookNum = int.Parse(myBookNumber.ToString());

            var myNumber = String.Format("{0: 00000}", bookNum);

            The18th.Areas.Directory.DirectoryDTOs.BookingDto createdBookingNumber = new The18th.Areas.Directory.DirectoryDTOs.BookingDto();
            createdBookingNumber.BookingNumber = myNumber;

            return (createdBookingNumber);

        }


        //ff////////////////////////////////////////////////////////////////////////////
        protected void Timer1_Tick(object sender, EventArgs e)
        {

            string placement = "Booking";

            SlideAd(placement);
        }

        ////Original....1, 6
        //private void SlideAd()
        //{
        //    Random _rand = new Random();
        //    int i = _rand.Next(1, 4);

        //    Image1.ImageUrl = "~/SlideAdsPics/" + i.ToString() + ".jpg";
        //}


        //New....
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



    }
}