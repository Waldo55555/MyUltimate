using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class DocRetrieval : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ////string account = Request.QueryString["acctNumber"];

            ////ViewState.Add("ExistingAccountNum", account);


            ////2
            //HttpCookie cookie = Request.Cookies["MemberCookieInfo"];
            //string accountNumberCookie = cookie["Number"];

            //var accountNumber = accountNumberCookie.Trim();

            //ViewState.Add("ExistingAccountNum", accountNumber);


            ////Temporary
            string account = "55555";

            ViewState.Add("ExistingAccountNum", account);


            if (!Page.IsPostBack)
            {

                //string cs = ConfigurationManager.ConnectionStrings["OneFarmData"].ConnectionString;
                //using (SqlConnection con = new SqlConnection(cs))
                //{
                //    SqlCommand cmd = new SqlCommand("Select DocId, AccountNumber, SubmissionType, DocPath, Doc, DocSize, SubmittedBy From tblDocs", con);
                //    con.Open();

                //    docDropDownList.DataSource = cmd.ExecuteReader();
                //    docDropDownList.DataTextField = "Doc";
                //    docDropDownList.DataValueField = "DocPath";
                //    docDropDownList.DataBind();

                //}


            }


        }

        protected void searchButton_Click(object sender, EventArgs e)
        {

            resultLabel.Text = ViewState["ExistingAccountNum"].ToString();

            var fromExistingAccountNumber = resultLabel.Text;


            //var pulledDoc = The18th.Areas.Cooperatives.Data.ContentManager.GetDocs(fromExistingAccountNumber);

            The18th.Areas.Cooperatives.CooperativeDTOs.DocDto doc = new The18th.Areas.Cooperatives.CooperativeDTOs.DocDto();
            doc.DocID = doc.DocID;
            doc.AccountNumber = fromExistingAccountNumber;
            doc.SubmissionType = doc.SubmissionType;
            doc.DocPath = doc.DocPath;
            doc.Doc = docDropDownList.SelectedValue;
            doc.DocSize = doc.DocSize;
            doc.SubmittedBy = doc.SubmittedBy;


            Response.Redirect("~/DocDisplay.aspx?accountNumber=" + doc.AccountNumber);


        }



    }
}