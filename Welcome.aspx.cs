using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media.Imaging;

namespace The18th
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie myCookie = Request.Cookies["travelCookie"];
            var pulledSession = myCookie["sessNumber"];

            MyAdRotator.KeywordFilter = "Paid";

            //try
            //{

            //    if (Page.IsPostBack == false)
            //    {
            //        //userCountLabel.Text = Application.Get("userCount").ToString();
            //    }

            //}
            //catch (Exception ex)
            //{
            //    string message = "Nothing Here";

            //    message = ex.Message;
            //}

        }
              
    }
}