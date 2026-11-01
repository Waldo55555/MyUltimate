using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class CommitteeConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void completeButton_Click(object sender, EventArgs e)
        {


            Response.Redirect("~/Default.aspx");


        }


        //protected void Page_Error(object sender, EventArgs e)
        //{

        //    Exception ex = Server.GetLastError();

        //    Server.ClearError();

        //    Response.Redirect("~/SomethingsWrong.aspx");

        //}





    }
}