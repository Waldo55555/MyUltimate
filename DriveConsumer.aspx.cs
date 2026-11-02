using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class DriveConsumer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            //////New working on.....2-23-24
            //HttpCookie custLoc = Request.Cookies["CustomerLocationCookie"];
            //string customerLat = custLoc["custLat"];
            //string customerLong = custLoc["custLong"];
            //string visitDate = custLoc["date"];

            //.....2Pac
            HttpCookie currentMemberCookie = Request.Cookies["MemberCookie"];
            var currentMemberNumber = currentMemberCookie["membershipNumber"];

            HttpCookie myCookie = Request.Cookies["travelCookie"];
            var pulledSession = myCookie["sessNumber"];


            //Temporary session number
            The18th.Areas.Market.MarketDTOs.FirstActiveOrderDto tempSession = new The18th.Areas.Market.MarketDTOs.FirstActiveOrderDto();
            tempSession.SessionNumber = "1";

            var currentSession = The18th.Areas.Visitor.Data.VisitorEvaluationManager.GetEvaluationVisitor(tempSession.SessionNumber);

            ////////////////////////////////Wrap in Try block
            
            var pulledFirstActive = The18th.Areas.Market.Data.MarketEvaluationManager.GetEvaluationFirstActiveOrder(tempSession.SessionNumber);

            The18th.Areas.Market.MarketDTOs.FirstActiveOrderDto firstActive = new The18th.Areas.Market.MarketDTOs.FirstActiveOrderDto();
            firstActive.SessionNumber = pulledFirstActive.SessionNumber;
            firstActive.OrderNumber = pulledFirstActive.OrderNumber;
            firstActive.GrowerNumber = pulledFirstActive.GrowerNumber;
            firstActive.CartNumber = pulledFirstActive.CartNumber;
            firstActive.SubTotal = pulledFirstActive.SubTotal;
            firstActive.Tax = pulledFirstActive.Tax;

            ////////////////////////////////////////////////////////////////

            try
            {

                The18th.Areas.Visitor.VisitorDTOs.CustomerVisitorDto secondCustVisit = new The18th.Areas.Visitor.VisitorDTOs.CustomerVisitorDto();
                secondCustVisit.CustomerVisitorID = currentSession.VisitorID;
                secondCustVisit.SessionNumber = currentSession.SessionNumber;
                secondCustVisit.IPAddress = currentSession.IPAddress;
                secondCustVisit.Ghost = currentSession.Ghost;
                secondCustVisit.VisitDate = currentSession.VisitDate;

                string url = secondCustVisit.IPAddress;

                //Commented out because needs connection
                //using (WebClient client = new WebClient())
                //{
                //    string json = client.DownloadString(url);
                //    Location location = new JavaScriptSerializer().Deserialize<Location>(json);
                //    List<Location> locations = new List<Location>();
                //    locations.Add(location);

                //    The18th.Areas.Visitor.VisitorDTOs.CustomerLocationDto firstloc = new The18th.Areas.Visitor.VisitorDTOs.CustomerLocationDto();
                //    firstloc.SessionNumber = secondCustVisit.SessionNumber;
                //    firstloc.IPAddress = secondCustVisit.IPAddress;
                //    //dont match
                //    firstloc.Latitude = location.Latitude;
                //    firstloc.Longitude = location.Longitude;
                //    firstloc.LocationDate = DateTime.Now;


                //    if (string.IsNullOrEmpty(firstloc.Latitude))
                //    {
                //        firstloc.Latitude = "0";
                //    }

                //    if (string.IsNullOrEmpty(firstloc.Longitude))
                //    {
                //        firstloc.Longitude = "0";
                //    }

                //    if (!Page.IsPostBack)
                //    {

                //        //The18th.Areas.Visitor.Data.VisitorEvaluationManager.AddCustomerLocation(firstloc);

                //    }

                //}


                //Temporary because of commented out code

                var currentLocation = The18th.Areas.Visitor.Data.VisitorEvaluationManager.GetEvaluationConstomerLocation(tempSession.SessionNumber);

                The18th.Areas.Visitor.VisitorDTOs.CustomerLocationDto firstloc = new The18th.Areas.Visitor.VisitorDTOs.CustomerLocationDto();
                firstloc.SessionNumber = secondCustVisit.SessionNumber;
                firstloc.IPAddress = secondCustVisit.IPAddress;
                firstloc.Latitude = currentLocation.Latitude;
                firstloc.Longitude = currentLocation.Longitude;
                firstloc.LocationDate = DateTime.Now;

                //The18th.Areas.Visitor.Data.VisitorEvaluationManager.AddCustomerLocation(firstloc);

            }

            catch (System.NullReferenceException ex)
            {
                string message = ex.Message;
                //Response.Redirect("~/RequiredError.aspx");
                return;
            }

            catch (Exception ex)
            {
                string msg = ex.Message;
                return;
            }


            var myCustomerAddress = addressTextBox.Text;

            ViewState.Add("ExistingCustomerAddress", myCustomerAddress);

            var myAddress = txtAddress.Text;

            ViewState.Add("ExistingAddress", myAddress);

            var myLatitude = txtLatitude.Text;

            ViewState.Add("ExistingLatitude", myLatitude);

            var myLongitude = txtLongitude.Text;

            ViewState.Add("ExistingLongitude", myLongitude);

            //New Friday
            var myCartNumber = firstActive.CartNumber;

            ViewState.Add("ExistingCart", myCartNumber);

            //New Friday
            var myGrowerNumber = firstActive.GrowerNumber;

            ViewState.Add("ExistingGrowerNumber", myGrowerNumber);

            //user ip added
            HttpCookie driveCookie = new HttpCookie("MemberDriveCookie");
            driveCookie["customerAddress"] = addressTextBox.Text;
            driveCookie["myAddress"] = txtAddress.Text;
            driveCookie["myLatitude"] = txtLatitude.Text;
            driveCookie["myLongitude"] = txtLongitude.Text;
            driveCookie["userIp"] = currentSession.IPAddress;
            driveCookie["growerNumber"] = firstActive.GrowerNumber;
            Response.Cookies.Add(driveCookie);

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {

            //.....2Pac
            HttpCookie currentMemberCookie = Request.Cookies["MemberCookie"];
            var currentMemberNumber = currentMemberCookie["membershipNumber"];

            HttpCookie myCookie = Request.Cookies["travelCookie"];
            var pulledSession = myCookie["sessNumber"];

            The18th.Areas.Market.MarketDTOs.DriveCustomerDto currentCustomer = new The18th.Areas.Market.MarketDTOs.DriveCustomerDto();
            currentCustomer.DriveCustomerID = Guid.NewGuid();
            currentCustomer.SessionNumber = pulledSession;
            currentCustomer.CartNumber = "Pending";
            currentCustomer.OrderNumber = "Pending";
            currentCustomer.FirstName = firstNameTextBox.Text;
            currentCustomer.CustAddress = addressTextBox.Text;
            currentCustomer.Phone = phoneTextBox.Text;
            currentCustomer.IPAddress = "Pending";
            currentCustomer.Latitude = "Pending";
            currentCustomer.Longitude = "Pending";

            //The18th.Areas.Market.Data.MarketEvaluationManager.AddDriveCustomer(currentCustomer);

            Response.Redirect("~/MemberDrive.aspx?sessionNumber=" + pulledSession);

        }

        protected void Page_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            Server.ClearError();
            Response.Redirect("~/SomethingsWrong.aspx");

        }


    }
}