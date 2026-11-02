using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The18th.Exceptions;

namespace The18th
{
    public partial class MemberDrive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ////MemberCookie stops transition on live version

            //.....2Pac
            HttpCookie currentMemberCookie = Request.Cookies["MemberCookie"];
            var currentMemberNumber = currentMemberCookie["membershipNumber"];

            HttpCookie myCookie = Request.Cookies["travelCookie"];
            var pulledSession = myCookie["sessNumber"];


            //Original SessionNumber
            //string mySessionNumber = Request.QueryString["sessionNumber"];

            //Temporary session number
            The18th.Areas.Visitor.VisitorDTOs.VisitorDto mySessionNumber = new The18th.Areas.Visitor.VisitorDTOs.VisitorDto();
            mySessionNumber.SessionNumber = "1";


            var sess = mySessionNumber.SessionNumber.Trim();

            var pulledDriveCustomer = The18th.Areas.Market.Data.MarketEvaluationManager.GetAEvaluationDriveCustomerBySession(sess);

            var pulledFirstActive = The18th.Areas.Market.Data.MarketEvaluationManager.GetEvaluationFirstActiveOrder(sess);

            The18th.Areas.Market.MarketDTOs.FirstActiveOrderDto firstActive = new The18th.Areas.Market.MarketDTOs.FirstActiveOrderDto();
            firstActive.SessionNumber = pulledFirstActive.SessionNumber;
            firstActive.OrderNumber = pulledFirstActive.OrderNumber;
            firstActive.GrowerNumber = pulledFirstActive.GrowerNumber;
            firstActive.CartNumber = pulledFirstActive.CartNumber;
            firstActive.SubTotal = pulledFirstActive.SubTotal;
            firstActive.Tax = pulledFirstActive.Tax;

            subtotalLabel.Text = firstActive.SubTotal.ToString();
            taxLabel.Text = firstActive.Tax.ToString();

            var pulledDriveOrder = The18th.Areas.Market.Data.MarketEvaluationManager.GetAEvaluationDriveOrder(firstActive.CartNumber);

            cartCountLabel.Text = String.Format("Current Products loaded: {0}", pulledDriveOrder.CartCount);
            //currencyLabel.Text = walletType.Currency;
            //subtotalLabel.Text = orderInfo.SubTotal.ToString();
            //taxCurrencyLabel.Text = walletType.Currency;
            //taxLabel.Text = orderInfo.StringTax.ToString();
            orderDateLabel.Text = String.Format(" {0}", pulledDriveOrder.OrderDate.ToShortDateString());
            //orderStatusLabel.Text = orderInfo.OrderStatus;

            firstNameLabel.Text = pulledDriveCustomer.FirstName;
            addressLabel.Text = pulledDriveCustomer.CustAddress;

            /////////////Format Phone
            //double phone = double.Parse(pulledDriveCustomer.Phone);
            //var fullPhone = String.Format("{0: (000)-000-0000}", phone);
            //pulledDriveCustomer.Phone = fullPhone.Trim();
            ///////////////Format Phone End
            
            phoneLabel.Text = pulledDriveCustomer.Phone;

            var myDeliveryLocation = deliveryLocationTextBox.Text;

            ViewState.Add("ExistingDeliverLocation", myDeliveryLocation);

            var myAddress = txtAddress.Text;

            ViewState.Add("ExistingAddress", myAddress);

            var myLatitude = txtLatitude.Text;

            ViewState.Add("ExistingLatitude", myLatitude);

            var myLongitude = txtLongitude.Text;

            ViewState.Add("ExistingLongitude", myLongitude);

            var myOrderNumber = firstActive.OrderNumber;

            ViewState.Add("ExistingOrderNum", myOrderNumber);

            var myCartNumber = firstActive.CartNumber;

            ViewState.Add("ExistingCartNum", myCartNumber);


        }


        protected void submitButton_Click(object sender, EventArgs e)
        {


            ////MemberCookie stops transition on live version
            //.....2Pac
            HttpCookie currentMemberCookie = Request.Cookies["MemberCookie"];
            var currentMemberNumber = currentMemberCookie["membershipNumber"];

            HttpCookie myCookie = Request.Cookies["travelCookie"];
            var pulledSession = myCookie["sessNumber"];


            orderNumberLabel.Text = ViewState["ExistingOrderNum"].ToString();

            cartNumberLabel.Text = ViewState["ExistingCartNum"].ToString();

            deliveryLocationTextBox.Text = ViewState["ExistingDeliverLocation"].ToString();

            txtAddress.Text = ViewState["ExistingAddress"].ToString();

            txtLatitude.Text = ViewState["ExistingLatitude"].ToString();

            txtLongitude.Text = ViewState["ExistingLongitude"].ToString();

            var myLocation = deliveryLocationTextBox.Text;

            var myLatitude = txtLatitude.Text;

            var myLongitude = txtLongitude.Text;

          
            //Temporary session number
            The18th.Areas.Visitor.VisitorDTOs.VisitorDto mySessionNumber = new The18th.Areas.Visitor.VisitorDTOs.VisitorDto();
            mySessionNumber.SessionNumber = "1";
                       
            var pulledFirstActive = The18th.Areas.Market.Data.MarketEvaluationManager.GetEvaluationFirstActiveOrder(mySessionNumber.SessionNumber);

            The18th.Areas.Market.MarketDTOs.FirstActiveOrderDto firstActive = new The18th.Areas.Market.MarketDTOs.FirstActiveOrderDto();
            firstActive.SessionNumber = pulledFirstActive.SessionNumber;
            firstActive.OrderNumber = pulledFirstActive.OrderNumber;
            firstActive.GrowerNumber = pulledFirstActive.GrowerNumber;
            firstActive.CartNumber = pulledFirstActive.CartNumber;
            firstActive.SubTotal = pulledFirstActive.SubTotal;
            firstActive.Tax = pulledFirstActive.Tax;
            ////////////////////////////////////////////////////////////////

            var pulledDriveOrder = The18th.Areas.Market.Data.MarketEvaluationManager.GetAEvaluationDriveOrder(firstActive.CartNumber);

            The18th.Service.OrderService myTotal = new The18th.Service.OrderService();
            var calculatedTotal = myTotal.CalculateSubTotal(pulledDriveOrder);


            //Create grower number


            Response.Redirect("/Market/MyMarket/DriveTrack?growerNumber=" + firstActive.GrowerNumber
               + "&total=" + calculatedTotal
               + "&growNumber=" + firstActive.GrowerNumber
             );

        }


        private string createATrackingNumber()
        {

            Random random = new Random();
            random.Next(59864343, 87395235);

            int myOrderNum = random.Next();

            int orderNumber = int.Parse(myOrderNum.ToString());

            var myNumber = String.Format("{0: 00000000}", orderNumber);

            ViewState.Add("OrderNumber", myNumber);


            return (myNumber);
        }

        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");


        }



    }
}