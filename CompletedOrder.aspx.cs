using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class CompletedOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie orderCookie = Request.Cookies["OrderCookieInfo"];
            string ordNumber = orderCookie["orderNumber"].Trim();
            string cart = orderCookie["cartNumber"].Trim();
            string account = orderCookie["accountNumberCookie"].Trim();


            ViewState.Add("ExistingOrderNum", ordNumber);

            orderNumberLabel.Text = ViewState["ExistingOrderNum"].ToString();


            ViewState.Add("ExistingAccountNum", account);

            accountNumberLabel.Text = ViewState["ExistingAccountNum"].ToString();


            ViewState.Add("ExistingCartNum", cart);

            cartNumberLabel.Text = ViewState["ExistingCartNum"].ToString();


            var pulledOrder = The18th.Areas.OneState.Data.OrderManager.GetAOrder(cart);

            The18th.Areas.OneState.OneStateDTOs.OrderDto orderInfo = new The18th.Areas.OneState.OneStateDTOs.OrderDto();
            orderInfo.AccountNumber = pulledOrder.AccountNumber;
            orderInfo.OrderNumber = pulledOrder.OrderNumber;
            orderInfo.CartNumber = pulledOrder.CartNumber;
            orderInfo.OrderStatus = pulledOrder.OrderStatus;
            orderInfo.SubTotal = pulledOrder.SubTotal;
            orderInfo.Tax = pulledOrder.Tax;
            orderInfo.CardStatus = pulledOrder.CardStatus;
            orderInfo.ShipStatus = pulledOrder.ShipStatus;
            orderInfo.CartCount = pulledOrder.CartCount;
            orderInfo.OrderDate = pulledOrder.OrderDate;
            orderInfo.OrderItems = pulledOrder.OrderItems;

            cartCountLabel.Text = String.Format("Current Products In Your Cart: {0}", orderInfo.CartCount);
            subtotalLabel.Text = String.Format(" {0:C}", orderInfo.SubTotal);
            taxLabel.Text = String.Format(" {0:C}", orderInfo.Tax);
            orderDateLabel.Text = String.Format(" {0}", orderInfo.OrderDate);
            orderStatusLabel.Text = orderInfo.OrderStatus;

            var pulledCustomer = The18th.Areas.OneState.Data.CustomerManager.GetACustomer(cart);

            firstNameLabel.Text = pulledCustomer.FirstName;
            lastNameLabel.Text = pulledCustomer.LastName;
            addressLabel.Text = pulledCustomer.Address;
            locationLabel.Text = pulledCustomer.Location;
            zipLabel.Text = pulledCustomer.Zip;
            phoneLabel.Text = pulledCustomer.Phone;
            emailLabel.Text = pulledCustomer.Email;

            var pulledShipping = The18th.Areas.OneState.Data.ShippingManager.GetShipping(cart);

            shipNumberLabel.Text = pulledShipping.ShippingNumber;
            trackingNumberLabel.Text = pulledShipping.TrackingNumber;
            shipNameLabel.Text = pulledShipping.ShipName;
            shipAddressLabel.Text = pulledShipping.ShipAddress;
            shipZipLabel.Text = pulledShipping.ShipZip;
            shipLocationLabel.Text = pulledShipping.ShipLocation;
            carrierLabel.Text = pulledShipping.Carrier;
            shipSpeedLabel.Text = pulledShipping.ShipSpeed;

            var pulledPayment = The18th.Areas.OneState.Data.PaymentManager.GetAPayment(cart);

            cardFirstNameLabel.Text = pulledPayment.FirstName;
            cardLastNameLabel.Text = pulledPayment.LastName;
            cardAddressLabel.Text = pulledPayment.CardAddress;
            cardLocationLabel.Text = pulledPayment.CardLocation;
            cardZipLabel.Text = pulledPayment.CardZip;
            cardNumberLabel.Text = pulledPayment.CartNumber;
            cscLabel.Text = pulledPayment.Csc;
            expirationLabel.Text = pulledPayment.ExpirationOnCard.ToShortDateString();
            cardStatusLabel.Text = pulledPayment.CardStatus;


            The18th.Areas.OneState.OneStateDTOs.CompleteOrderDto completedOrder = new The18th.Areas.OneState.OneStateDTOs.CompleteOrderDto();
            completedOrder.CompleteOrderID = completedOrder.CompleteOrderID;
            completedOrder.AccountNumber = completedOrder.AccountNumber;
            completedOrder.CardNumber = completedOrder.CardNumber;
            completedOrder.OrderDate = completedOrder.OrderDate;
            completedOrder.OrderTotal = completedOrder.OrderTotal;
            completedOrder.Tax = completedOrder.Tax;
            completedOrder.OrderStatus = completedOrder.OrderStatus;
            //hover over
            //commented out because of properties being commented out on class level
            //completedOrder.FavoriteVendors = completedOrder.FavoriteVendors;
            completedOrder.OrderItems = completedOrder.OrderItems;


            //testing...2-12-22 Def breakdown
            //Go In...No Save
            The18th.Areas.OneState.Data.OrderManager.AddCompletedOrder(completedOrder);


            //Dynasty1.DTO.OrderDto pendingOrder = new Dynasty1.DTO.OrderDto();
            //pendingOrder.OrderNumber = "";
            //pendingOrder.CartNumber = "";


            ////eventually move into its own project
            ////Service.OrderService os = new Service.OrderService();
            ////currentOrder.SubTotal = os.CalculateTotal(currentOrder);
            ////currentOrder.Tax = os.CalculateTax(currentOrder);




        }

        protected void completeOrderButton_Click(object sender, EventArgs e)
        {

            cartNumberLabel.Text = ViewState["ExistingCartNum"].ToString();

            accountNumberLabel.Text = ViewState["ExistingAccountNum"].ToString();

            var pulledOrder = The18th.Areas.OneState.Data.OrderManager.GetAOrder(cartNumberLabel.Text);

            //
            //Response.Redirect("~/OrderConfirmation.aspx?orderNumber=" + orderNumberLabel.Text + "&cartNumber=" + pulledOrder.CartNumber + "&accountNumber=" + pulledOrder.AccountNumber);

            Response.Redirect("~/OrderConfirmation.aspx");



        }

        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");


        }

    }
}