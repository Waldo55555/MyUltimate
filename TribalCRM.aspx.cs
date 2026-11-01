using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class TribalCRM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //2
            HttpCookie cookie = Request.Cookies["MemberCookieInfo"];
            string accountNumberCookie = cookie["Number"];

            ViewState.Add("ExistingMemberNum", accountNumberCookie);
            loginLabel.Text = accountNumberCookie;

            var myNumber = loginLabel.Text;
        }


    }
}