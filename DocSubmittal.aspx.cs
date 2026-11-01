using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class DocSubmittal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //string account = Request.QueryString["acctNumber"];

            //var customerAccountNumber = account.Trim();

            ////2
            //HttpCookie cookie = Request.Cookies["MemberCookieInfo"];
            //string accountNumberCookie = cookie["Number"];


            //ViewState.Add("ExistingAccountNum", accountNumberCookie);


        }

        protected void uploadButton_Click(object sender, EventArgs e)
        {

            //resultLabel.Text = ViewState["ExistingAccountNum"].ToString();

            //var fromExistingAccountNumber = resultLabel.Text;


            if (docFileUpload.HasFile)
            {

                string fileExtension = System.IO.Path.GetExtension(docFileUpload.FileName);

                if (fileExtension.ToLower() != ".doc" || fileExtension.ToLower() != ".docx" || fileExtension.ToLower() != ".txt" || fileExtension.ToLower() != ".pdf")
                {
                    resultMessageLabel.Text = "Please Upload A Valid File(.doc, .docx, .txt, or .pdf)";
                    resultMessageLabel.ForeColor = System.Drawing.Color.Red;
                }

                else
                {
                    int fileSize = docFileUpload.PostedFile.ContentLength;
                    if (fileSize > 2097152)
                    {
                        resultMessageLabel.Text = "Please Upload A File 2MB or Less";
                        resultMessageLabel.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {

                        docFileUpload.SaveAs(Server.MapPath("~/DocFiles/" + docFileUpload.FileName));
                        resultMessageLabel.Text = "Document Uploaded Successfully!";
                        resultMessageLabel.ForeColor = System.Drawing.Color.Green;

                    }


                    //The18th.Areas.Cooperatives.CooperativeDTOs.DocDto myDoc = new The18th.Areas.Cooperatives.CooperativeDTOs.DocDto();
                    //myDoc.DocID = myDoc.DocID;
                    //myDoc.AccountNumber = myDoc.AccountNumber;
                    //myDoc.SubmissionType = myDoc.SubmissionType;
                    //myDoc.DocPath = myDoc.DocPath;
                    //myDoc.Document = myDoc.Document;
                    //myDoc.DocSize = myDoc.DocSize;


                    //The18th.Areas.Cooperatives.Data.ContentManager.AddDocument(myDoc);

                }



            }

            else
            {

                resultMessageLabel.Text = "Please Upload A File";
                resultMessageLabel.ForeColor = System.Drawing.Color.Red;
            }



            Response.Redirect("~/Default.aspx");



        }



    }
}