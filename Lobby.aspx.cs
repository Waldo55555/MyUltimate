using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class Lobby : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
            //2
            HttpCookie memberCookie = Request.Cookies["MemberCookieInfo"];
            string memberAccountNumber = memberCookie["memberNumber"];

            ViewState.Add("ExistingMemberNum", memberAccountNumber);
            loginLabel.Text = memberAccountNumber;

            var myNumber = loginLabel.Text;
        }

        protected void oneFarmImageButton_Click(object sender, ImageClickEventArgs e)
        {
 
            Response.Redirect("~/OneFarm.aspx");
        }

        protected void oneStateImageButton_Click(object sender, ImageClickEventArgs e)
        {
          
            Response.Redirect("~/OneState.aspx");
        }

        protected void tribalImageButton_Click(object sender, ImageClickEventArgs e)
        {
   
            Response.Redirect("~/TribalCRM.aspx");
        }

        protected void onyxImageButton_Click(object sender, ImageClickEventArgs e)
        {
           
            Response.Redirect("~/OnyxDirectory.aspx");
        }
    }
}