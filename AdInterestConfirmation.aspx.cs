using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class AdInterestConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string myAcctNumber = Request.QueryString["accountNumber"];

            var accountNumber = myAcctNumber.Trim();

            ViewState.Add("ExistingAccountNum", accountNumber);

            string myCompanyName = Request.QueryString["companyName"];

            ViewState.Add("ExistingCompanyName", myCompanyName);

            string myPhone = Request.QueryString["phone"];

            ViewState.Add("ExistingPhone", myPhone);

            string myEmail = Request.QueryString["email"];

            ViewState.Add("ExistingEmail", myEmail);

            string myDesignBanner = Request.QueryString["designBanner"];

            ViewState.Add("ExistingDesignBanner", myDesignBanner);

        }

        protected void homeButton_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Default.aspx");

        }


    }
}