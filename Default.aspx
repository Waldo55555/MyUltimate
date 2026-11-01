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
                <a href="#" class="navbar-brand">Avatar Growers</a>
                <button class="navbar-toggle" data-toggle="collapse" data-target=".navHeaderCollapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                      <div class="collapse navbar-collapse navHeaderCollapse">
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

                             <%--  <li><a href="VisitorSignIn.aspx"><span class="glyphicon glyphicon-home"></span>Visitor Sign-In</a></li>--%>

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
        <center><p>Developed By: Meek Tech - Copyright &copy; 2023 - All Rights Reserved</p></center>
        <center><p>Contact Us Today!&nbsp;&nbsp;|&nbsp;&nbsp;<a href="mailto:the18th_helpdesk@yahoo.com">Information</a></p></center>
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
