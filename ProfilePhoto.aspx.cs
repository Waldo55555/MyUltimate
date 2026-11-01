using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The18th.Exceptions;

namespace The18th
{
    public partial class ProfilePhoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //////2
            HttpCookie memberCookie = Request.Cookies["MemberCookieInfo"];
            string membershipNumber = memberCookie["memberNumber"];
            string accountNumber = memberCookie["accountNumber"];

            var acctNumber = accountNumber.Trim();

            ViewState.Add("ExistingAccountNum", acctNumber);

            var memNumber = membershipNumber.Trim();

            ViewState.Add("ExistingMembershipNum", memNumber);



        }

        protected void maleImageButton_Click(object sender, ImageClickEventArgs e)
        {


            resultLabel.Text = ViewState["ExistingMembershipNum"].ToString();

            var fromExistingMemberNumber = resultLabel.Text;

            var pulledMember = The18th.Areas.MemberShip.Data.MembershipManager.GetAMembership(fromExistingMemberNumber);

            The18th.Areas.MemberShip.MemberShipDTOs.ProfilePhotoDto myProfilePhoto = new The18th.Areas.MemberShip.MemberShipDTOs.ProfilePhotoDto();
            myProfilePhoto.ProfilePhotoID = Guid.NewGuid();
            myProfilePhoto.AccountNumber = pulledMember.AccountNumber.Trim();
            myProfilePhoto.ScreenName = pulledMember.ScreenName;
            myProfilePhoto.Gendor = "Male";
            myProfilePhoto.MemberImageUrl = "https://the18thstorage.blob.core.windows.net/the18thcontainer/member1.png";


            ////////////////////////////////////////////////Development
            try
            {

                if (myProfilePhoto.ScreenName.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                The18th.Areas.MemberShip.Data.MembershipManager.InsertAMemberPhoto(myProfilePhoto);
            }


            catch (Exception ex)
            {

                string message = "";

                message = ex.Message;

            }


            string myVendorName = companyNameLabel.Text;

            Response.Redirect("~/Confirmation.aspx");






        }

        protected void femaleImageButton_Click(object sender, ImageClickEventArgs e)
        {

            resultLabel.Text = ViewState["ExistingMembershipNum"].ToString();

            var fromExistingMemberNumber = resultLabel.Text;

            var pulledMember = The18th.Areas.MemberShip.Data.MembershipManager.GetAMembership(fromExistingMemberNumber);

            The18th.Areas.MemberShip.MemberShipDTOs.ProfilePhotoDto myProfilePhoto = new The18th.Areas.MemberShip.MemberShipDTOs.ProfilePhotoDto();
            myProfilePhoto.ProfilePhotoID = Guid.NewGuid();
            myProfilePhoto.AccountNumber = pulledMember.AccountNumber.Trim();
            myProfilePhoto.ScreenName = pulledMember.ScreenName;
            myProfilePhoto.Gendor = "Female";
            myProfilePhoto.MemberImageUrl = "https://the18thstorage.blob.core.windows.net/the18thcontainer/member2.png";

            try
            {

                if (myProfilePhoto.ScreenName.Trim().Length == 0)
                    throw new RequiredException("please complete all required fields");

                The18th.Areas.MemberShip.Data.MembershipManager.InsertAMemberPhoto(myProfilePhoto);

            }


            catch (Exception ex)
            {

                string message = "";

                message = ex.Message;

            }

            string myVendorName = companyNameLabel.Text;

            Response.Redirect("~/Confirmation.aspx");



        }


        protected void Page_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            Server.ClearError();

            Response.Redirect("~/SomethingsWrong.aspx");

        }



    }
}