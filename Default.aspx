<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="The18th.Default" %>

<%--<%@ OutputCache Duration="3600" VaryByParam="None" %>--%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=0"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Avatar Growers</title>
<%--Seo Start--%>
<meta name="revisit-after" content="7 days" />
<meta name="ROBOTS" content="INDEX, FOLLOW" />
<meta name="description" content="African American Farming Cooperatives" />
<meta name="keywords" content="african american farmers, black farm cooperatives" />
<%--Seo End--%>
<link rel="shortcut icon" type="image/x-icon" href="https://the18thstorage.blob.core.windows.net/the18thcontainer/favicon.ico" />
<%--The only thing that stays--%>
<link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" /> 

<%: Styles.Render("~/bundles/mycss") %>
<%: Styles.Render("~/bundles/layout") %>
       
</head>
<body>
     <div class="navbar navbar-default navbar-fixed-top"> 
            <div class="container-fluid">
                <a href="#" class="navbar-brand">Avatar Growers(Beta)</a>
                <button class="navbar-toggle" data-toggle="collapse" data-target=".navHeaderCollapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                      <div class="collapse navbar-collapse navHeaderCollapse">
                            <ul class="nav navbar-nav navbar-right">
                                                         
                                <li><a href="Account/Account/MemberSignUp"><span class="glyphicon glyphicon-log-in"></span>Member Sign-Up</a></li>

                                <li><a href="Welcome.aspx"><span class="glyphicon glyphicon-home"></span>Welcome</a></li>

                             </ul>
                      </div>
            </div>
        </div>
        <form id="form1" runat="server">
                  <br /><br /><br />
                  <div class="container-fluid">
                      <center><a href="#"><img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/home.jpg" alt="Picture" /></a></center>
                  </div>
         </form>
    <br /><br /><br /><br /><br />
    <!--Footer-->
    <div class="navbar navbar-default navbar-fixed-bottom">
        <div class="container">
        <br />
        <center><p>Developer On Duty: Waldo - Copyright &copy; 2023 - All Rights Reserved</p></center>
       <%-- <center><p>Ad World:&nbsp;&nbsp;<a href="/Knowledge/Craddle/AboutAdvertisements">Advertise</a>&nbsp;|&nbsp;Donations:&nbsp;&nbsp;<a href="/Donations/Donations/DonateFace">Pledge</a></p></center>--%>
        <center><p>AG Newsletter:&nbsp;&nbsp;<a href="https://avatar-growers.com/newsletter/" target="_blank">Suscribe</a>&nbsp;|&nbsp;<a href="Meek/MeekHome/AboutUs" target="_blank">About Us</a></p></center>
      
        <h3><asp:Label ID="loginLabel" Visible="false" runat="server" Text=""></asp:Label></h3>
        </div>
    </div>
    <br /><br /><br />
   <%-- For Nav Pill--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="../bootstrap/js/bootstrap.min.js"></script>
    <br /><br /><br />
   <%: Scripts.Render("~/bundles/myscripts") %>

</body>
</html>
