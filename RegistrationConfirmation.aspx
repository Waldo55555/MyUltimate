<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationConfirmation.aspx.cs" Inherits="The18th.RegistrationConfirmation" %>

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
    
<!--@*client side validation in order*@-->
<script src="~/Scripts/jquery-3.3.1.min.js"></script>
<script src="~/Scripts/jquery.validate.min.js"></script>
<script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>  
              
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
                              <%-- <li class="dropdown">
                                   <a href="#" class="dropdown-toggle" data-toggle="dropdown"><span class="glyphicon glyphicon-globe"></span>International</a>

                                   <ul class="dropdown-menu">

                                    <li><a href="https://www.mfdp.gov.lr/" target="_blank">Liberia</a></li>

                                    <li><a href="https://au.int/en/arbe" target="_blank">Ethiopia</a></li>

                                    <li><a href="https://www.ghana.gov.gh/" target="_blank">Ghana</a></li>
                    
                                   </ul>
                             
                               </li>--%>
                                                           
                                  <li><a href="https://www.ghana.gov.gh/" target="_blank"><span class="glyphicon glyphicon-globe"></span>Diaspora Connect</a></li>

                                  <li><a href="https://globalagriculture.org" target="_blank"><span class="glyphicon glyphicon-map-marker"></span>Diaspora News</a></li>
  
                                  <li><a href="Welcome.aspx"><span class="glyphicon glyphicon-home"></span>Welcome</a></li>
                             <%--  <li><a href="VisitorSignIn.aspx"><span class="glyphicon glyphicon-home"></span>Visitor Sign-In</a></li>--%>

                          </ul>
                      </div>
            </div>
        </div>
        <form id="form1" runat="server">

         <div class="container">

               <br /><br />
                 <div>

                    <br /><br /> <br /><br />
         
	                <center><h2><em><strong>Registration Confirmation <img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/greencheck.gif" alt="picture" /></strong></em></h2></center>

	                <center><h4><em><strong>Thank-You for registering with us.</strong></em></h4></center>

	                <center><h4><em><strong>Please check your email for furthur instructions and welcome information.</strong></em></h4></center><br />
            
                    <center><h4><em><strong>Please allow up to 30 minutes for your log-in information to complete.</strong></em></h4></center>

                    <asp:Label ID="resultLabel" runat="server" Text="" Visible="false"></asp:Label>

                    <center><asp:Button ID="returnButton" runat="server" Text="Return" CssClass="btn btn-md btn-primary" OnClick="returnButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/></center>

                   <br /><br /><br /><br />

              </div>

             <br /><br /><br />
             <br /><br /><br />
            </div>

         </form>
  
    <!--Footer-->
    <div class="navbar navbar-default navbar-fixed-bottom">
        <div class="container">
           <br />
            <center><p>Developed By: Meek Tech - Copyright &copy; 2023 - All Rights Reserved</p></center>
            <center><p>Ad World:&nbsp;&nbsp;<a href="/Ads/Ad/AboutAdvertisements">Advertise</a>&nbsp;|&nbsp;Donations:&nbsp;&nbsp;<a href="/Donations/Donations/DonateFace">Pledge</a></p></center>
            <center><p><a href="/MemberShip/MemberDash/MembershipSignIn"><span class="glyphicon glyphicon-home"></span>Member Sign-In</a>&nbsp;|&nbsp;<a href="Meek/MeekHome/AboutUs">About Us</a></p></center>
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
