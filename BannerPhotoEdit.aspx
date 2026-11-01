<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BannerPhotoEdit.aspx.cs" Inherits="The18th.BannerPhotoEdit" %>


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

            <h1>Current Banner Photo</h1>

            <p class="lead">Current Banner</p>
          
            </div>
                      
            <p class="lead">Please review your current banner.</p>

            <hr />
       
            <asp:Image ID="bannerImage" Height="60px" Width="960px" runat="server" />
                    
            <asp:Label ID="campNumberLabel" runat="server" Visible="false" Text=""></asp:Label>

            <br />

            <p>Choose to keep this banner for my campaign.</p>
            <asp:Button ID="savePhotoButton" runat="server" Text="Keep Banner" CssClass="btn btn-lg btn-primary" OnClick="savePhotoButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/><br />

            <br /><br /><br />


            <p class="lead">Edit the banner photo.</p>

            <hr />
               
            <div class="form-group">
                <label>Please upload banner photo.</label>
                 <P>please upload a large image a minimum of 60 x 960</P>
                 <P>acceptable file types: JPG,GIF</P>
               <asp:FileUpload ID="photoFileUpload" runat="server" CssClass="form-control" /><br />

            </div>

          <br />

          <asp:Button ID="editPhotoButton" runat="server" Text="Edit Banner" CssClass="btn btn-md btn-primary" OnClick="editPhotoButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/>
         
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
