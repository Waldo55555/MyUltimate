using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The18th.Exceptions;

namespace The18th
{
    public partial class Appointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ///////////////////////////Ads/User Count Start//////////////////////////////////////////////////

            //SlideAd();

            try
            {

                if (Page.IsPostBack == false)
                {

                    userCountLabel.Text = Application.Get("userCount").ToString();

                }


                if (!Page.IsPostBack)
                {

                    dateBookedPrefixLabel.Visible = false;


                }



            }

            catch (Exception ex)
            {

                string message = "Nothing Here";

                message = ex.Message;

            }

            ///////////////////////////Ads/User Count End//////////////////////////////////////////////////

            HttpCookie myBookcookie = Request.Cookies["BookInfo"];
            string profNumber = myBookcookie["profNumber"];
            string bookingNumber = myBookcookie["bookNumber"];
            //string memberAccountNumber = myBookcookie["memNumber"];

            //ViewState.Add("ExistingMemberNum", memberAccountNumber);

            //memberNumberLabel.Text = memberAccountNumber;


            ViewState.Add("ExistingProfNum", profNumber);

            professionalNumberLabel.Text = profNumber;


            ViewState.Add("ExistingBookingNum", bookingNumber);

            bookingNumberLabel.Text = bookingNumber;


            string _bookType = Request.QueryString["bookType"];

            string _firstName = Request.QueryString["firstName"];

            string _fee = Request.QueryString["fee"];

            string _status = Request.QueryString["status"];

            string _consult = Request.QueryString["consult"];

            string _email = Request.QueryString["email"];

            ViewState.Add("ExistingBookType", _bookType);

            ViewState.Add("ExistingFirst", _firstName);

            ViewState.Add("ExistingFee", _fee);

            ViewState.Add("ExistingStatus", _status);

            ViewState.Add("ExistingConsult", _consult);

            ViewState.Add("ExistingEmail", _email);

            //not visable
            //feeLabel.Text = _fee;
            //visable
            bookTypeLabel.Text = _bookType;

            firstNameLabel.Text = _firstName;

            statusLabel.Text = _status;

            consultLabel.Text = _consult;

            emailLabel.Text = _email;


            try
            {

                //if (string.IsNullOrEmpty(memberNumberLabel.Text))
                //    throw new BadNavigationException("Sorry....You Are In The Wrong Place.");

            }

            catch (BadNavigationException ex)
            {

                string message = ex.Message;

                apptExceptionLabel.Text = message;

                Server.TransferRequest("/AllProfessionalsPaged");

                return;

            }





        }

        protected void apptButton_Click(object sender, EventArgs e)
        {

            //memberNumberLabel.Text = ViewState["ExistingMemberNum"].ToString();

            //var fromExistingMemberNumber = memberNumberLabel.Text;

            professionalNumberLabel.Text = ViewState["ExistingProfNum"].ToString();

            var fromExistingProfNumber = professionalNumberLabel.Text;


            //New
            bookTypeLabel.Text = ViewState["ExistingBookType"].ToString();

            var fromExistingBookType = bookTypeLabel.Text;


            firstNameLabel.Text = ViewState["ExistingFirst"].ToString();

            var fromExistingFirstName = firstNameLabel.Text;


            consultLabel.Text = ViewState["ExistingConsult"].ToString();

            var fromExistingConsult = consultLabel.Text;


            emailLabel.Text = ViewState["ExistingEmail"].ToString();

            var fromExistingEmail = emailLabel.Text;


            statusLabel.Text = ViewState["ExistingStatus"].ToString();

            var fromExistingStatus = statusLabel.Text;

            ///////////////////////////////////////////////////////
            The18th.Areas.Directory.DirectoryDTOs.BookingDto myAppt = new The18th.Areas.Directory.DirectoryDTOs.BookingDto();
            myAppt.ProfessionalNumber = professionalNumberLabel.Text;
            myAppt.BookingNumber = bookingNumberLabel.Text;
            myAppt.AppointmentDate = apptCalendar.SelectedDate;
            selectedDateLabel.Text = myAppt.AppointmentDate.ToLongDateString();
            myAppt.ApptDate = selectedDateLabel.Text;
            //myAppt.ApptTime = timeTextBox.Text;
            dateLabel.Text = myAppt.AppointmentTime.ToShortTimeString();
            myAppt.ApptTime = dateLabel.Text;
            myAppt.AppointmentStatus = "Booked";
            myAppt.AppointmentTime = DateTime.Now;
            //////////////////////////////////////////////////////
            //Newly added
            myAppt.BookingType = fromExistingBookType;
            myAppt.MyConsultation = fromExistingConsult;
            myAppt.FirstName = fromExistingFirstName;
            myAppt.LastName = "NotSent";
            myAppt.Phone = "NotSent";
            myAppt.Email = fromExistingEmail;
            myAppt.BookingStatus = fromExistingStatus;
            myAppt.BookingFee = 0.99;
            myAppt.BookingStatus = "Booked";
            myAppt.ServiceName = "Undefined";
            myAppt.ServiceDescription = "Undefined";
            myAppt.MyConsultation = "Undefined";
            myAppt.MyEstimate = "Undefined";




            try
            {

                if (myAppt.ProfessionalNumber.Trim().Length == 0)
                    throw new Exceptions.NotCompleteException("Sorry...There is a problem");

                if (myAppt.BookingNumber.Trim().Length == 0)
                    throw new Exceptions.NotCompleteException("Sorry...There is a problem");

                if (string.IsNullOrEmpty(myAppt.ApptDate))
                    throw new Exceptions.RequiredException("please complete all required fields");

                if (string.IsNullOrEmpty(myAppt.ApptTime))
                    throw new Exceptions.RequiredException("please complete all required fields");

                if (myAppt.BookingNumber.Trim().Length == 0)
                    throw new Exceptions.RequiredException("please complete all required fields");

                //if (firstAppoint.AccountNumber.Trim().Length == 0)
                //    throw new Exceptions.RequiredException("please complete all required fields");

                if (myAppt.AppointmentStatus.Trim().Length == 0)
                    throw new Exceptions.RequiredException("please complete all required fields");



                //need to clean up all things pointing to appointment...repository, tables, etc
                //The18th.Areas.Directory.Data.DirectoryManager.AddAppointment(finalAppt);

            }

            catch (RequiredException ex)
            {

                string message = ex.MessageError;

                apptExceptionLabel.Text = message;

                return;

            }

            catch (FormatException ex)
            {

                string message = ex.Message;

                //exceptionLabel.Text = message;

                apptExceptionLabel.Text = "Please Correct Following Errors";

                return;

            }

            catch (DateNullException ex)
            {

                string message = ex.MessageError;

                apptExceptionLabel.Text = message;

                return;

            }

            catch (NullReferenceException ex)
            {

                string message = ex.Message;

                apptExceptionLabel.Text = message;

            }

            catch (Exception ex)
            {

                string message = "";

                message = ex.Message;

                apptExceptionLabel.Text = message;

                return;

            }


            passTextBox.Text = myAppt.AppointmentStatus;

            ViewState.Add("ViewStateItem", passTextBox.Text);


            errorLabel.Text = "";

            resultLabel.Text = "Your booking was submitted successfully";

            //////////////////////////////////////////////////////



            ////..Tower need to fix.............................here
            ////sendYahooMessageEmail(myAppt);

            //Response.Redirect("BookingConfirmation.aspx?customer=" + finalEveryThing.FirstName + "&bookNumber=" + finalEveryThing.BookingNumber + "&accountNumber=" + finalEveryThing.AccountNumber);

            //Response.Redirect("BookingConfirmation.aspx?bookNumber=" + finalEveryThing.BookingNumber + "&accountNumber=" + finalEveryThing.AccountNumber + "&customer=" + finalEveryThing.FirstName);



            Response.Redirect("~/BookCheckOut.aspx");

            //Not Implemented
            //Response.Redirect("BookingConfirmation.aspx");



        }



        //ff////////////////////////////////////////////////////////////////////////////
        //protected void Timer1_Tick(object sender, EventArgs e)
        //{

        //    SlideAd();
        //}

        ////Original....1, 6
        //private void SlideAd()
        //{
        //    Random _rand = new Random();
        //    int i = _rand.Next(1, 4);

        //    Image1.ImageUrl = "~/SlideAdsPics/" + i.ToString() + ".jpg";
        //}


        protected void apptCalendar_SelectionChanged(object sender, EventArgs e)
        {

            apptExceptionLabel.Text = "";

            dateBookedPrefixLabel.Visible = true;

            selectedDateLabel.Text = apptCalendar.SelectedDate.ToLongDateString();

        }

        protected void apptCalendar_DayRender(object sender, DayRenderEventArgs e)
        {

            DateTime offdate = DateTime.Now.AddDays(-8);

            if (e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;
                //e.Cell.Visible = false;
                e.Cell.BackColor = System.Drawing.Color.Red;

            }

            //working on...try custom validation

            //if(Convert.ToDateTime(e.Day.Date) > DateTime.Now == true)
            //{

            //    e.Day.IsSelectable = false;

            //}

        }


        //new 8-1-23
        public static void sendYahooMessageEmail(The18th.Areas.Directory.DirectoryDTOs.BookingDto myBook)
        {


            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;


            string ourCompanyInfo = "\n \n Booking info is... \n";

            string firstName = myBook.FirstName;

            string phone = myBook.Phone;

            string email = myBook.Email;

            string bookingNumber = myBook.BookingNumber;

            string bookedDate = myBook.AppointmentDate.ToShortDateString();

            //new
            string bookedTime = myBook.ApptTime;

            //////////////////////////our email

            string body = String.Format("\n \n A new booking has just been created.");

            string information = String.Format("A booking has been created with OneFarm");

            string signature = String.Format(" \n \n OneFarm Admin Team,\n Bookings,\n the18th.org, \n bookthe18th@yahoo.com, \n \n Problems with booking please call 806-805-4249");


            //jhjihiohjoi

            //MailMessage ms = new MailMessage("your yahoomail id", txtEmailId.Text);
            //ms.Subject = "Testing Sending Mail through Yahoo";
            //ms.Body = txt_msg.Text;
            //ms.IsBodyHtml = true;
            //SmtpClient smtp = new SmtpClient("smtp.mail.yahoo.com", 587);
            //smtp.Credentials = new System.Net.NetworkCredential("your yahoomail id ", "your password");
            //smtp.EnableSsl = true;
            //smtp.Send(ms);


            MailMessage ms = new MailMessage("bookthe18th@yahoo.com", "bookthe18th@yahoo.com");
            ms.Subject = "Testing Sending Mail through Yahoo";
            ms.Body = "Test";
            ms.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.mail.yahoo.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential("bookthe18th@yahoo.com", "getSomethingBooked");
            smtp.EnableSsl = true;
            smtp.Send(ms);

            //jghiuhgiuhoiuh

            //MailMessage myMessage = new MailMessage("bookthe18th@yahoo.com", "bookthe18th@yahoo.com");

            //myMessage.Subject = information;
            //myMessage.Body = body + " \n " + ourCompanyInfo + " \n " +
            //                            "Client Name :" + firstName + "\n \n" +
            //                            "Phone :" + phone + " \n \n" +
            //                            "Booking Email :" + email + " \n \n" +
            //                            "Booking Number :" + bookingNumber + " \n \n" +
            //                            "Booking Date :" + DateTime.Now + " \n " +
            //                            signature;


            /////////////////////////Customer Email

            //string customerAccountInfo = "\n Your booking has been created.";

            //var customerEmail = "";

            //customerEmail = email;

            //string customerbody = String.Format("\n \n \n Thank you for booking with us! \n");

            //string customerinformation = String.Format("Booking with OneFarm");

            //string customerSignature = String.Format(" \n \n OneFarm Admin Team,\n Bookings,\n the18th.org, \n bookthe18th@yahoo.com, \n \n Problems with booking please call 806-805-4249");



            //MailMessage customerMessage = new MailMessage(customerEmail, customerEmail);

            //customerMessage.Subject = customerinformation;
            //customerMessage.Body = customerbody + " \n " + customerAccountInfo + " \n " +
            //                            "Please make note of your booking number :" + bookingNumber + " \n \n" +
            //                            "Booking Date :" + DateTime.Now + " \n " +
            //                            customerSignature;


            //////////////////////////Customer Email End


            //SmtpClient smptClient = new SmtpClient("smtp.mail.yahoo.com", 25);
            ////SmtpClient smptClient = new SmtpClient("smtp.mail.yahoo.com", 465);
            ////SmtpClient smptClient = new SmtpClient("smtp.mail.yahoo.com", 587);


            //smptClient.Credentials = new System.Net.NetworkCredential()
            //{

            //    UserName = "bookthe18th@yahoo.com",
            //    Password = "getSomethingBooked"

            //};

            //smptClient.EnableSsl = true;
            //smptClient.Send(myMessage);


            //try
            //{

            //    smptClient.Send(myMessage);

            //    smptClient.Send(customerMessage);
            //}


            //catch (Exception ex)
            //{

            //    string message = ex.Message;

            //}


        }


    }
}