using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The18th.Exceptions;

namespace The18th
{
    public partial class PaymentMethod : System.Web.UI.Page
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

            cartCountLabel.Text = String.Format("Current Products In Your Cart: {0}", orderInfo.CartCount);
            subtotalLabel.Text = String.Format(" {0:C}", orderInfo.SubTotal);
            taxLabel.Text = String.Format(" {0:C}", orderInfo.Tax);
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

            var pulledShipping = The18th.Areas.OneState.Data.ShippingManager.GetShipping(cart);

            shipNumberLabel.Text = pulledShipping.ShippingNumber;
            trackingNumberLabel.Text = pulledShipping.TrackingNumber;
            shipNameLabel.Text = pulledShipping.ShipName;
            shipAddressLabel.Text = pulledShipping.ShipAddress;
            shipZipLabel.Text = pulledShipping.ShipZip;
            shipLocationLabel.Text = pulledShipping.ShipLocation;
            carrierLabel.Text = pulledShipping.Carrier;
            shipSpeedLabel.Text = pulledShipping.ShipSpeed;

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {

            cartNumberLabel.Text = ViewState["ExistingCartNum"].ToString();

            accountNumberLabel.Text = ViewState["ExistingAccountNum"].ToString();


            var pulledOrder = The18th.Areas.OneState.Data.OrderManager.GetAOrder(cartNumberLabel.Text);

            The18th.Areas.OneState.OneStateDTOs.PaymentMethodDto payMeth = new The18th.Areas.OneState.OneStateDTOs.PaymentMethodDto();
            payMeth.PaymentMethID = Guid.NewGuid();
            payMeth.AccountNumber = pulledOrder.AccountNumber;
            payMeth.OrderNumber = pulledOrder.OrderNumber;
            payMeth.CartNumber = pulledOrder.CartNumber;
            payMeth.CardType = cardTypeDropDownList.SelectedValue;

            try
            {

                if (payMeth.CardType == "Select Card Type...")
                    throw new RequiredException("please complete all required fields");

                if (payMeth.CardType.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                //Go In...No Save
                The18th.Areas.OneState.Data.PaymentManager.AddPaymentMethod(payMeth);

            }

            catch (Exception ex)
            {

                string message = "";

                message = ex.Message;

            }


            //Response.Redirect("~/Payment.aspx?orderNumber=" + payMeth.OrderNumber + "&cartNumber=" + payMeth.CartNumber + "&accountNumber=" + payMeth.AccountNumber);

            Response.Redirect("~/Payment.aspx");




        }

        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");


        }


    }
}