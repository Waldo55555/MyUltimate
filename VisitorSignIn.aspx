<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisitorSignIn.aspx.cs" Inherits="The18th.VisitorSignIn" %>


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


 <script src="Scripts/jquery-3.3.1.min.js"></script>
 <script src="Scripts/bootstrap.min.js"></script>

              
<%: Styles.Render("~/bundles/mycss") %>
<%: Styles.Render("~/bundles/layout") %>

</head>
<body>
     <%--navBackgoundimg added--%>
            <div class="navbar navbar-default navbar-fixed-top">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navHeaderCollapse">
                            <span class="sr-only"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a href="Default.aspx" class="navbar-brand">Avatar Agriculture(beta)</a>
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav navbar-right">
                            <li class="dropdown">
                                   <a href="#" class="dropdown-toggle" data-toggle="dropdown"><span class="glyphicon glyphicon-globe"></span>International</a>
                                   <ul class="dropdown-menu">
                                    <li><a href="https://www.mfdp.gov.lr/" target="_blank">Liberia</a></li>
                                    <li><a href="https://au.int/en/arbe" target="_blank">Ethiopia</a></li>
                                    <li><a href="https://www.ghana.gov.gh/" target="_blank">Ghana</a></li>
                                   </ul>
                               </li>
                               <li><a href="https://globalagriculture.org" target="_blank"><span class="glyphicon glyphicon-map-marker"></span>Global News</a></li>
                               <li><a href="Account/Account/AnonymousLogIn"><span class="glyphicon glyphicon-home"></span>Visitor Sign-In</a></li>
                               <li><a href="Account/Account/AnonymousRegister"><span class="glyphicon glyphicon-book"></span>Visitor Register</a></li>
                           </ul>
                    </div>
                </div>
            </div>
            <br />
        <form id="form1" runat="server">

           <div class="container">
           
               <br /><br /><br />
  
               <div class="page-header">

               <h1>Register</h1>

               <p class="lead">Anonymous Register</p>

	
	            <p><Center>Please complete the following information.</Center></p>
                </div>
   
                <center><p><asp:Label ID="exceptionLabel" runat="server" ForeColor="Red" Text="" Font-Size="Medium"></asp:Label></p></center><br />
            
                <hr />
                 
	            <div class="form-group">
	            <label>Please enter a your first name:</label>
	            <asp:TextBox ID="firstNameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
	            <label>Please enter a your last name:</label>
	            <asp:TextBox ID="lastNameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
	            <label>Please enter your phone number:</label>
	            <asp:TextBox ID="phoneNumberTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="phoneErrorLabel" runat="server" ForeColor="Red" Text="" Font-Size="Medium"></asp:Label><br />
                </div>
  
	            <div class="form-group">
	            <label>Please enter a contact person email:</label>
	            <asp:TextBox ID="emailTextBox" runat="server" CssClass="form-control"></asp:TextBox>
 
                </div>
                 <div class="h-captcha" data-sitekey="a14043b2-3be8-4aa9-beee-30b4069accbc"></div>
                <center><asp:Button ID="registerButton" runat="server" Text="Register" CssClass="btn btn-md btn-primary" OnClick="registerButton_Click"/></center>
    
                <br />
                <script src="https://js.hcaptcha.com/1/api.js" async defer></script>
                <p>WW:<span><asp:Label ID="Label1" runat="server" Text=""></asp:Label></span></p><br />

                <br /><br /><br /><br />
     

                <p>&nbsp;</p>

			
              </div>
    
              <br /><br /><br /><br /><br />

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
