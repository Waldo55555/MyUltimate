using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The18th.Exceptions;

namespace The18th
{
    public partial class Customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie farmMarketCookie = Request.Cookies["FarmMarketCookieInfo"];
            string growerNumber = farmMarketCookie["growerNumber"];
            string memberAccountNumber = farmMarketCookie["memberAccountNumber"];

            HttpCookie checkOutCookie = Request.Cookies["CheckOutCookieInfo"];
            string ordNumber = checkOutCookie["orderNumber"].Trim();
            string cart = checkOutCookie["cartNumber"].Trim();
            string mySubTotal = checkOutCookie["subTotal"].Trim();
            string myTax = checkOutCookie["tax"].Trim();

            HttpCookie orderCookie = new HttpCookie("OrderCookieInfo");
            orderCookie["orderNumber"] = ordNumber;
            orderCookie["cartNumber"] = cart;
            orderCookie["accountNumberCookie"] = memberAccountNumber;
            Response.Cookies.Add(orderCookie);

            ViewState.Add("ExistingOrderNum", ordNumber);

            orderNumberLabel.Text = ViewState["ExistingOrderNum"].ToString();

            /////////////////////////////////////////////////////////////////////////////////////////////

            ViewState.Add("ExistingAccountNum", memberAccountNumber);

            accountNumberLabel.Text = ViewState["ExistingAccountNum"].ToString();

            /////////////////////////////////////////////////////////////////////////////////////////////

            //Note: We are sending over cart because user should never hit this page without having
            // a cart and plus we want to populate order information from start to finish.

            ViewState.Add("ExistingCartNum", cart);

            cartNumberLabel.Text = ViewState["ExistingCartNum"].ToString();

            /////////////////////////////////////////////////////////////////////////////////

            ViewState.Add("ExistingSubTotal", mySubTotal);

            ViewState.Add("ExistingTax", myTax);

            if (!Page.IsPostBack)
            {

                var existingCartItems = The18th.Areas.OneState.Data.CartManager.GetAllCartItems(cartNumberLabel.Text);

                The18th.Areas.OneState.OneStateDTOs.OrderDto orderInfo = new The18th.Areas.OneState.OneStateDTOs.OrderDto();
                orderInfo.OrderID = Guid.NewGuid();
                orderInfo.AccountNumber = accountNumberLabel.Text;
                orderInfo.OrderNumber = orderNumberLabel.Text;
                orderInfo.CartNumber = cartNumberLabel.Text;
                orderInfo.SubTotal = double.Parse(mySubTotal);
                orderInfo.Tax = double.Parse(myTax);
                orderInfo.StringTax = myTax;
                orderInfo.CardStatus = "Pending";
                orderInfo.ShipStatus = "Pending";
                orderInfo.OrderStatus = "Pending";
                orderInfo.CartCount = existingCartItems.Count;
                orderInfo.OrderDate = DateTime.Now;
                orderInfo.OrderItems = existingCartItems;

                //Getting a cart to get currency start

                var pulledCart = The18th.Areas.OneState.Data.CartManager.GetACart(cart);

                The18th.Areas.OneState.OneStateDTOs.CartDto walletType = new The18th.Areas.OneState.OneStateDTOs.CartDto();
                walletType.Currency = pulledCart.Currency;

                //new 9-28
                orderInfo.StringTax = string.Format("{0:0.00}", myTax);

                cartCountLabel.Text = String.Format("Current Products In Your Cart: {0}", orderInfo.CartCount);
                currencyLabel.Text = walletType.Currency;
                subtotalLabel.Text = orderInfo.SubTotal.ToString();
                taxCurrencyLabel.Text = walletType.Currency;
                taxLabel.Text = orderInfo.StringTax.ToString();
                orderDateLabel.Text = String.Format(" {0}", orderInfo.OrderDate.ToShortDateString());
                orderStatusLabel.Text = orderInfo.OrderStatus;

                //Getting a cart to get currency end

                The18th.Areas.OneState.Data.OrderManager.AddOrder(orderInfo);


            }





        }

        protected void submitButton_Click(object sender, EventArgs e)
        {

            orderNumberLabel.Text = ViewState["ExistingOrderNum"].ToString();

            cartNumberLabel.Text = ViewState["ExistingCartNum"].ToString();

            accountNumberLabel.Text = ViewState["ExistingAccountNum"].ToString();


            The18th.Areas.OneState.OneStateDTOs.CustomerDto currentCustomer = new The18th.Areas.OneState.OneStateDTOs.CustomerDto();
            currentCustomer.CustomerID = Guid.NewGuid();
            currentCustomer.AccountNumber = accountNumberLabel.Text.Trim();
            currentCustomer.OrderNumber = orderNumberLabel.Text.Trim();
            currentCustomer.CartNumber = cartNumberLabel.Text.Trim();
            currentCustomer.FirstName = firstNameTextBox.Text;
            currentCustomer.LastName = lastNameTextBox.Text;
            currentCustomer.Address = addressTextBox.Text;
            currentCustomer.Location = locationDropDownList.SelectedValue;
            currentCustomer.Zip = zipTextBox.Text;
            currentCustomer.Phone = phoneTextBox.Text;
            currentCustomer.Email = emailTextBox.Text;
            currentCustomer.CustomerCount = 1;


            try
            {

                if (currentCustomer.FirstName.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (currentCustomer.LastName.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (currentCustomer.Address.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (currentCustomer.Location == "Select Location...")
                    throw new RequiredException("please complete all required fields");

                if (currentCustomer.Location.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (currentCustomer.Zip.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (currentCustomer.Phone.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                if (currentCustomer.Email.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                The18th.Areas.OneState.Data.CustomerManager.AddCustomer(currentCustomer);

            }

            catch (Exception ex)
            {

                string message = "";

                message = ex.Message;

            }

            Response.Redirect("~/Shipping.aspx");




        }


        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");


        }

    }
}