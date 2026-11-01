<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdConfirmation.aspx.cs" Inherits="The18th.AdConfirmation" %>

<%@ OutputCache Duration="3600" VaryByParam="None" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=0"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Avatar Growers</title>
<link rel="shortcut icon" type="image/x-icon" href="https://the18thstorage.blob.core.windows.net/the18thcontainer/favicon.ico" />
<link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" /> 
<%--<link rel="stylesheet" href="../layout/styles/layout.css" type="text/css" />
<script type="text/javascript" src="../layout/scripts/jquery.min.js"></script>
<script type="text/javascript" src="../layout/scripts/jquery.ui.min.js"></script>--%>
              
<%: Styles.Render("~/bundles/mycss") %>
<%: Styles.Render("~/bundles/layout") %>

</head>
<body>
     <div class="navbar navbar-default navbar-fixed-top"> 
            <div class="container-fluid">
                <a href="Default.aspx" class="navbar-brand">Avatar Growers(Beta)</a>
                <button class="navbar-toggle" data-toggle="collapse" data-target=".navHeaderCollapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                      <div class="collapse navbar-collapse navHeaderCollapse">
                           <ul class="nav navbar-nav navbar-right">

                            <li><a href="/Ads/Ad/AboutAdvertisements">About Advertisements</a></li>

                            <li><a href="https://www.bannersnacks.com" target="_blank">Create A Banner</a></li>
                          </ul>
                      </div>
            </div>
        </div>
        <form id="form1" runat="server">

         <div class="container">

           <div class="page-header">
             <br /><br />

                 <br /><br /> <br /><br />

                <asp:Label ID="noLabel" runat="server" Visible="true" Text=""></asp:Label>

                <asp:Label ID="nonoLabel" runat="server" Visible="true" Text=""></asp:Label>

                <asp:Label ID="nononoLabel" runat="server" Visible="true" Text=""></asp:Label>

	            <center><h2><em><strong>Advertisement Confirmation <img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/greencheck.gif" alt="picture" /></strong></em></h2></center>

	            <center><h4><em><strong>Thank-You for trusting us with your ads.</strong></em></h4></center>

	            <center><h4><em><strong>Please check your email for your ad approval.</strong></em></h4></center><br />
            
                <center><h4><em><strong>Once you approve your ad thats all you need to complete.</strong></em></h4></center>

                <center><h4><em><strong>You will be notified once your ad is approved, and your ad is live.</strong></em></h4></center><br /><br />
   
                <asp:Label ID="resultLabel" runat="server" Text="" Visible="false"></asp:Label>

                <asp:Label ID="adTotalLabel" runat="server" Text="" Visible="false"></asp:Label>

                <asp:Label ID="adTypeLabel" runat="server" Text="" Visible="false"></asp:Label>

                <center><asp:Button ID="saveButton" runat="server" Text="Save Information" CssClass="btn btn-md btn-primary" OnClick="saveButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/></center>

              <br /><br />

           </div>
          <br /><br /><br />
          <br /><br /><br />
         </div>

       </form>
  
    <!--Footer-->
    <div class="navbar navbar-default navbar-fixed-bottom">
        <div class="container">
           <br />
            <center><p><a href="Meek/RunUp/RunUpAdmin"><span class="glyphicon glyphicon-cloud"></span>&nbsp;Run Up</a></p></center>
            <center><p>Developer On Duty: Meek Technologies - Copyright &copy; 2011-2022 - All Rights Reserved</p></center>
            <center><p>Ad World:&nbsp;&nbsp;<a href="AdCompanyInfo.aspx">Advertise With Us</a>&nbsp;||&nbsp;Donations:&nbsp;&nbsp;<a href="/Donations/Donations/DonateFace">Make A Pledge</a></p></center>
            <center><p><a href="MembershipEntry.aspx">Become A Member</a>&nbsp;||&nbsp;<a href="Meek/MeekHome/AboutUs">About Us</a></p></center>
            <%-- <center><p><a href="TrackDonation.aspx">Track My Donations</a>&nbsp;||&nbsp;<a href="Meek/MeekHome/AboutUs">About Us</a></p></center>--%>
            <%--<center><p>Advertise:&nbsp;&nbsp;<a href="mailto:onefarmads@gmail.com">Advertise With Us</a></p></center>--%>
            <h3><asp:Label ID="loginLabel" Visible="false" runat="server" Text=""></asp:Label></h3>
            <center><p class="fl_right">WW:<span><asp:Label ID="userCountLabel" runat="server" Text=""></asp:Label></span></p></center>
        </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <br /><br /><br />

    <%: Scripts.Render("~/bundles/myscripts") %>

</body>
</html>
