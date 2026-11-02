using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace The18th
{
    public partial class Confirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string myInvitationNumber = Request.QueryString["accountNumber"];

            var inviteNumber = myInvitationNumber.Trim();


            ViewState.Add("ExistingAccountNum", inviteNumber);


        }

        protected void homeButton_Click(object sender, EventArgs e)
        {


            Response.Redirect("~/Default.aspx");

        }

        protected void oneImageButton_Click(object sender, ImageClickEventArgs e)
        {

            resultLabel.Text = ViewState["ExistingAccountNum"].ToString();

            var fromExistingAccountNumber = resultLabel.Text;


            var ourMembership = The18th.Areas.MemberShip.Data.MembershipManager.GetMembershipByAccountNumber(fromExistingAccountNumber);


            //New
            var nameBack = formatCardName(ourMembership);

            The18th.Areas.MemberShip.MemberShipDTOs.TribalCardDto cardFeatures = new The18th.Areas.MemberShip.MemberShipDTOs.TribalCardDto();
            cardFeatures.TribalCardID = Guid.NewGuid();
            cardFeatures.MembershipNumber = ourMembership.MembershipNumber;
            cardFeatures.AccountNumber = ourMembership.AccountNumber;
            cardFeatures.PromotionCode = "OneFarm";
            cardFeatures.CardImage = "~/Images/onecard.png";
            cardFeatures.FirstName = ourMembership.FirstName;
            cardFeatures.LastName = ourMembership.LastName;
            cardFeatures.Phone = ourMembership.Phone;
            cardFeatures.Email = ourMembership.Email;
            cardFeatures.CardVendor = "One United";
            cardFeatures.CardType = "Visa";
            cardFeatures.NameOnCard = nameBack.ValueHolder;
            cardFeatures.CardNumber = createCardNumber();
            cardFeatures.Csc = "444";
            cardFeatures.Points = 0;
            cardFeatures.Balance = 0.0;
            cardFeatures.PurchaseAmount = 0.0;
            cardFeatures.ExpirationOnCard = DateTime.Now.AddYears(2);


            try
            {


                //if (cardFeatures.Points <= 0)
                //    throw new RequiredException("Must Be A New Card");

                //if (cardFeatures.Balance <= 0.0)
                //    throw new RequiredException("Must Be A New Card");

                //if (cardFeatures.PurchaseAmount <= 0.0)
                //    throw new RequiredException("Must Be A New Card");


                //
                //The18th.Areas.TribalCRM.Data.TribalCardManager.AddCard(cardFeatures);
            }


            catch (Exception ex)
            {

                string message = "";

                message = ex.Message;

            }

            //Start here to finish automated membership
            Response.Redirect("/TribalCRM/Tribal/CRMConfirmation?trueBill38=" + cardFeatures.AccountNumber);


        }

        protected void greenImageButton_Click(object sender, ImageClickEventArgs e)
        {

            resultLabel.Text = ViewState["ExistingAccountNum"].ToString();

            var fromExistingAccountNumber = resultLabel.Text;


            var ourMembership = The18th.Areas.MemberShip.Data.MembershipManager.GetMembershipByAccountNumber(fromExistingAccountNumber);

            //New
            var nameBack = formatCardName(ourMembership);

            The18th.Areas.MemberShip.MemberShipDTOs.TribalCardDto cardFeatures = new The18th.Areas.MemberShip.MemberShipDTOs.TribalCardDto();
            cardFeatures.TribalCardID = Guid.NewGuid();
            cardFeatures.MembershipNumber = ourMembership.MembershipNumber;
            cardFeatures.AccountNumber = ourMembership.AccountNumber;
            cardFeatures.PromotionCode = "OneFarm";
            cardFeatures.CardImage = "~/Images/greencard.png";
            cardFeatures.FirstName = ourMembership.FirstName;
            cardFeatures.LastName = ourMembership.LastName;
            cardFeatures.Phone = ourMembership.Phone;
            cardFeatures.Email = ourMembership.Email;
            cardFeatures.CardVendor = "GreenWood";
            cardFeatures.CardType = "Visa";
            cardFeatures.NameOnCard = nameBack.ValueHolder;
            cardFeatures.CardNumber = createCardNumber();
            cardFeatures.Csc = "444";
            cardFeatures.Points = 0;
            cardFeatures.Balance = 0.0;
            cardFeatures.PurchaseAmount = 0.0;
            cardFeatures.ExpirationOnCard = DateTime.Now.AddYears(2);


            try
            {

                //if (cardFeatures.Points <= 0)
                //    throw new RequiredException("Must Be A New Card");

                //if (cardFeatures.Balance <= 0.0)
                //    throw new RequiredException("Must Be A New Card");

                //if (cardFeatures.PurchaseAmount <= 0.0)
                //    throw new RequiredException("Must Be A New Card");


                //
                //The18th.Areas.TribalCRM.Data.TribalCardManager.AddCard(cardFeatures);
            }


            catch (Exception ex)
            {

                string message = "";

                message = ex.Message;

            }

            //Start here to finish automated membership
            Response.Redirect("/TribalCRM/Tribal/CRMConfirmation?trueBill38=" + cardFeatures.AccountNumber);


        }

        /////////////////////////////////////////////Helpers

        public The18th.Areas.MemberShip.MemberShipDTOs.MembershipDto formatCardName(The18th.Areas.MemberShip.MemberShipDTOs.MembershipDto sent)
        {

            The18th.Areas.MemberShip.MemberShipDTOs.MembershipDto createName = new The18th.Areas.MemberShip.MemberShipDTOs.MembershipDto();
            createName.FirstName = sent.FirstName;
            createName.LastName = sent.LastName;

            var fullName = String.Format(createName.FirstName + " " + createName.LastName);

            The18th.Areas.MemberShip.MemberShipDTOs.MembershipDto createdName = new The18th.Areas.MemberShip.MemberShipDTOs.MembershipDto();
            createdName.ValueHolder = fullName;

            return (createdName);


        }

        //Up For Deletion
        //private string createCsc()
        //{

        //    Random random = new Random();

        //    random.Next(343, 235);

        //    int myTrackNum = random.Next();

        //    int trackingNumber = int.Parse(myTrackNum.ToString());

        //    var myNumber = String.Format("{0: 000}", trackingNumber);

        //    //ViewState.Add("TicketNumber", myNumber);


        //    return (myNumber);
        //}


        //Convert to 64-bit/Long
        private string createCardNumber()
        {

            Random random = new Random();

            random.Next(59864343, 87395235);

            int myCardNum = random.Next();

            int cardNumber = int.Parse(myCardNum.ToString());

            var myNumber = String.Format("{0: 00000000}", cardNumber);

            return (myNumber);
        }

        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");


        }


    }
}