using Azure;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ipAddress))
            {
                //ToString Added
                ipAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("https://api.ip2location.io/?key=F395891D860BA05EA67586164BC7440C&ip=");
            sb.Append(ipAddress);

            HttpCookie sessionCookie = new HttpCookie("travelCookie");
            sessionCookie["sessNumber"] = createSessionNumber().Trim();
            Response.Cookies.Add(sessionCookie);

            //////////////////////////////////////

            The18th.Areas.Visitor.VisitorDTOs.VisitorDto firstVisit = new The18th.Areas.Visitor.VisitorDTOs.VisitorDto();
            firstVisit.VisitorID = Guid.NewGuid();
            HttpCookie myCookie = Request.Cookies["travelCookie"];
            firstVisit.SessionNumber = myCookie["sessNumber"];
            firstVisit.IPAddress = sb.ToString();
            firstVisit.Ghost = "Yes";
            firstVisit.VisitDate = DateTime.Now;
            firstVisit.Date = firstVisit.VisitDate.ToShortDateString();
            firstVisit.Time = firstVisit.VisitDate.ToShortTimeString();

            if (firstVisit.IPAddress.Contains("::1"))
            {
                firstVisit.Ghost = "Lap";
            }

            if (firstVisit.IPAddress.Contains("64.130.69.244:"))
            {
                firstVisit.Ghost = "Lap";
            }

            if (firstVisit.IPAddress.Contains("172.59.194.31:"))
            {
                firstVisit.Ghost = "Cell";
            }

            if (firstVisit.IPAddress.Contains("172.59.194.177:"))
            {
                firstVisit.Ghost = "Cell";
            }
  
            Session["VisitSession"] = firstVisit.SessionNumber;
                    
            //The18th.Areas.Visitor.Data.VisitorManager.AddVisitor(firstVisit);


        }


        private string createSessionNumber()
        {

            Random random = new Random();
            random.Next(59864343, 87395235);

            int mySeed = random.Next();

            int sesSeed = int.Parse(mySeed.ToString());

            var mySessionNumber = String.Format("{0: 00000000}", sesSeed);

            ViewState.Add("SeSSeed", mySessionNumber);

            return (mySessionNumber);
        }


    }
}