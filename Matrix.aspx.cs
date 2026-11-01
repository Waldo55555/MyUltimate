using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class Matrix : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //HttpCookie orderCookie = Request.Cookies["OrderCookieInfo"];
            //string ordNumber = orderCookie["orderNumber"].Trim();
            //string cart = orderCookie["cartNumber"].Trim();
            //string account = orderCookie["accountNumberCookie"].Trim();


            //ViewState.Add("ExistingOrderNum", ordNumber);

            //orderNumberLabel.Text = ViewState["ExistingOrderNum"].ToString();


            //ViewState.Add("ExistingAccountNum", account);

            //accountNumberLabel.Text = ViewState["ExistingAccountNum"].ToString();


            //ViewState.Add("ExistingCartNum", cart);

            //cartNumberLabel.Text = ViewState["ExistingCartNum"].ToString();


            //var pulledOrder = The18th.Areas.OneState.Data.OrderManager.GetAOrder(cart);

            //The18th.Areas.OneState.OneStateDTOs.OrderDto orderInfo = new The18th.Areas.OneState.OneStateDTOs.OrderDto();
            //orderInfo.OrderNumber = pulledOrder.OrderNumber;
            //orderInfo.AccountNumber = pulledOrder.AccountNumber;
            //orderInfo.CartNumber = pulledOrder.CartNumber;
            //orderInfo.OrderStatus = pulledOrder.OrderStatus;
            //orderInfo.SubTotal = pulledOrder.SubTotal;
            //orderInfo.Tax = pulledOrder.Tax;
            //orderInfo.CardStatus = pulledOrder.CardStatus;
            //orderInfo.ShipStatus = pulledOrder.ShipStatus;
            ////maybe have to persist from beginning
            //orderInfo.CartCount = pulledOrder.CartCount;
            //orderInfo.OrderDate = pulledOrder.OrderDate;
            //orderInfo.OrderItems = pulledOrder.OrderItems;


            //var pulledCart = The18th.Areas.OneState.Data.CartManager.GetACart(cart);

            //The18th.Areas.OneState.OneStateDTOs.CartDto walletType = new The18th.Areas.OneState.OneStateDTOs.CartDto();
            //walletType.Currency = pulledCart.Currency;

            //cartCountLabel.Text = String.Format("Current Products In Your Cart: {0}", orderInfo.CartCount);
            //currencyLabel.Text = walletType.Currency;
            //subtotalLabel.Text = orderInfo.SubTotal.ToString();
            //taxCurrencyLabel.Text = walletType.Currency;
            //taxLabel.Text = orderInfo.Tax.ToString();
            //orderDateLabel.Text = String.Format(" {0}", orderInfo.OrderDate.ToShortDateString());
            //orderStatusLabel.Text = orderInfo.OrderStatus;

            //var pulledCustomer = The18th.Areas.OneState.Data.CustomerManager.GetACustomer(cart);

            //firstNameLabel.Text = pulledCustomer.FirstName;
            //lastNameLabel.Text = pulledCustomer.LastName;
            //addressLabel.Text = pulledCustomer.Address;
            //locationLabel.Text = pulledCustomer.Location;
            //zipLabel.Text = pulledCustomer.Zip;
            //phoneLabel.Text = pulledCustomer.Phone;
            //emailLabel.Text = pulledCustomer.Email;



        }

        protected void cashAppImageButton_Click(object sender, ImageClickEventArgs e)
        {




        }

        protected void payPalImageButton_Click(object sender, ImageClickEventArgs e)
        {


            Response.Redirect("~/CheckOut.aspx");


        }



    }
}