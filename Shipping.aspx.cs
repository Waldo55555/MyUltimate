using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The18th.Exceptions;

namespace The18th
{
    public partial class Shipping : System.Web.UI.Page
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
            orderInfo.OrderNumber = pulledOrder.OrderNumber;
            orderInfo.AccountNumber = pulledOrder.AccountNumber;
            orderInfo.CartNumber = pulledOrder.CartNumber;
            orderInfo.OrderStatus = pulledOrder.OrderStatus;
            orderInfo.SubTotal = pulledOrder.SubTotal;
            orderInfo.Tax = pulledOrder.Tax;
            orderInfo.CardStatus = pulledOrder.CardStatus;
            orderInfo.ShipStatus = pulledOrder.ShipStatus;
            //maybe have to persist from beginning
            orderInfo.CartCount = pulledOrder.CartCount;
            orderInfo.OrderDate = pulledOrder.OrderDate;
            orderInfo.OrderItems = pulledOrder.OrderItems;

            var pulledCart = The18th.Areas.OneState.Data.CartManager.GetACart(cart);

            The18th.Areas.OneState.OneStateDTOs.CartDto walletType = new The18th.Areas.OneState.OneStateDTOs.CartDto();
            walletType.Currency = pulledCart.Currency;


            //new 9-28
            orderInfo.StringTax = string.Format("{0:0.00}", orderInfo.Tax);


            cartCountLabel.Text = String.Format("Current Products In Your Cart: {0}", orderInfo.CartCount);
            //currencyLabel.Text = walletType.Currency;
            subtotalLabel.Text = orderInfo.SubTotal.ToString();
            //taxCurrencyLabel.Text = walletType.Currency;
            taxLabel.Text = orderInfo.StringTax.ToString();
            orderDateLabel.Text = String.Format(" {0}", orderInfo.OrderDate.ToShortDateString());
            orderStatusLabel.Text = orderInfo.OrderStatus;

            var pulledCustomer = The18th.Areas.OneState.Data.CustomerManager.GetACustomer(cart);

            firstNameLabel.Text = pulledCustomer.FirstName;
            lastNameLabel.Text = pulledCustomer.LastName;
            addressLabel.Text = pulledCustomer.Address;
            locationLabel.Text = pulledCustomer.Location;
            zipLabel.Text = pulledCustomer.Zip;
            phoneLabel.Text = pulledCustomer.Phone;
            emailLabel.Text = pulledCustomer.Email;


            shipToNameLabel.Text = String.Format("Ship To Name: {0}", pulledCustomer.FirstName + " " + pulledCustomer.LastName);


        }

        protected void submitButton_Click(object sender, EventArgs e)
        {

            orderNumberLabel.Text = ViewState["ExistingOrderNum"].ToString();

            cartNumberLabel.Text = ViewState["ExistingCartNum"].ToString();

            accountNumberLabel.Text = ViewState["ExistingAccountNum"].ToString();


            var pulledOrder = The18th.Areas.OneState.Data.OrderManager.GetAOrder(cartNumberLabel.Text);

            The18th.Areas.OneState.OneStateDTOs.OrderDto orderInfo = new The18th.Areas.OneState.OneStateDTOs.OrderDto();
            orderInfo.OrderNumber = pulledOrder.OrderNumber;
            orderInfo.AccountNumber = pulledOrder.AccountNumber;
            orderInfo.CartNumber = pulledOrder.CartNumber;
            orderInfo.OrderStatus = pulledOrder.OrderStatus;
            orderInfo.SubTotal = pulledOrder.SubTotal;
            orderInfo.Tax = pulledOrder.Tax;
            orderInfo.CardStatus = pulledOrder.CardStatus;
            orderInfo.ShipStatus = pulledOrder.ShipStatus;
            orderInfo.CartCount = pulledOrder.CartCount;
            orderInfo.OrderDate = pulledOrder.OrderDate;
            orderInfo.OrderItems = pulledOrder.OrderItems;

            var pulledCustomer = The18th.Areas.OneState.Data.CustomerManager.GetACustomer(cartNumberLabel.Text);

            The18th.Areas.OneState.OneStateDTOs.ShippingDto currentShip = new The18th.Areas.OneState.OneStateDTOs.ShippingDto();
            currentShip.ShippingID = Guid.NewGuid();
            currentShip.AccountNumber = pulledCustomer.AccountNumber;
            currentShip.OrderNumber = pulledCustomer.OrderNumber;
            currentShip.ShippingNumber = createAShippingNumber().Trim();
            currentShip.TrackingNumber = createATrackingNumber().Trim();
            currentShip.CartNumber = orderInfo.CartNumber.Trim();
            currentShip.ShipName = pulledCustomer.FirstName + pulledCustomer.LastName;
            currentShip.ShipAddress = addressTextBox.Text;
            currentShip.ShipLocation = locationDropDownList.SelectedValue;
            currentShip.ShipZip = zipTextBox.Text;
            currentShip.Carrier = carrierDropDownList.SelectedValue;
            currentShip.ShipSpeed = speedDropDownList.SelectedValue;
            currentShip.ShipTo = currentShip.ShipName;


            try
            {

                if (currentShip.ShipName.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (currentShip.ShipAddress.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (currentShip.ShipLocation == "Select Location...")
                    throw new RequiredException("please complete all required fields");

                if (currentShip.ShipLocation.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (currentShip.ShipZip.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (currentShip.Carrier == "Select Carrier...")
                    throw new RequiredException("please complete all required fields");

                if (currentShip.Carrier.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (currentShip.ShipSpeed == "Select Shipping Speed...")
                    throw new RequiredException("please complete all required fields");

                if (currentShip.ShipSpeed.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");


                //Go In...No Save to shipping info directly or by way of process
                The18th.Areas.OneState.Data.ShippingManager.AddShipping(currentShip);

            }

            catch (Exception ex)
            {

                string message = "";

                message = ex.Message;

            }

            //Our paths
            //Response.Redirect("~/PaymentMethod.aspx");

            //Response.Redirect("~/Matrix.aspx");

            The18th.Service.TotalService myTotal = new The18th.Service.TotalService();
            var calculatedTotal = myTotal.CalculateTotal(orderInfo.SubTotal, orderInfo.Tax);

            Response.Redirect("~/OneState/OneState/PayPalCheckOut?total=" + calculatedTotal);


        }


        //////Helpers
        private string createAShippingNumber()
        {

            Random random = new Random();
            random.Next(59864343, 87395235);

            int myOrderNum = random.Next();

            int orderNumber = int.Parse(myOrderNum.ToString());

            var myNumber = String.Format("{0: 00000000}", orderNumber);

            ViewState.Add("OrderNumber", myNumber);


            return (myNumber);
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