<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdInterestConfirmation.aspx.cs" Inherits="The18th.AdInterestConfirmation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Avatar Growers</title>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=0">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<link rel="shortcut icon" type="image/x-icon" href="https://the18thstorage.blob.core.windows.net/the18thcontainer/favicon.ico" />
<%--The only thing that stays--%>
<link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" /> 

            
<%: Styles.Render("~/bundles/mycss") %>
<%: Styles.Render("~/bundles/layout") %>

       <script src="jquery-1.11.2.js"></script>
            <script type="text/javascript">
                $(document).ready(function () {

                    $('+233').before('<h3>')

                });
            </script>
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
                              <li><a href="Account/Account/MembershipSignIn"><span class="glyphicon glyphicon-log-in"></span>Member Sign-In</a></li>

                              <li><a href="Account/Account/MemberSignUp"><span class="glyphicon glyphicon-log-in"></span>Member Sign-Up</a></li>

                              <li><a href="Account/Account/AnonymousLogIn"><span class="glyphicon glyphicon-leaf"></span>Growers Market</a></li>
                                       
                          </ul>
                      </div>
            </div>
        </div>
           
    <form id="form1" runat="server">

      <div class="container">

        <div class="page-header">
             
            <br /><br />
 
            <div>

                <br /><br />
           	
	               <center><h2><em><strong>Advertisement Interest Confirmation <img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/greencheck.gif" alt="picture" /></strong></em></h2></center>

                   <center><h4><em><strong>Your Advertisement Request Was Successfully Recieved.</strong></em></h4></center>
   
                   <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>

                    <asp:Label ID="resultLabel" runat="server" Text="" Visible="false"></asp:Label>
          
                <br />  
 
                <br /><br /><br />

                <center><asp:Button ID="homeButton" runat="server" Text="Back Home" CssClass="btn btn-md btn-primary" OnClick="homeButton_Click" /></center>
               
                <br /><br />

           </div>

           <br /><br /><br /><br /><br />

         </div>
        <br />
      </div>

    </form>
        
    <!---------Footer----->
    <div class="navbar navbar-default navbar-fixed-bottom">
        <div class="container">
            <br />
            <center><p>Contact Us Today!&nbsp;&nbsp;|&nbsp;&nbsp;<a href="mailto:the18th_helpdesk@yahoo.com">Member Service</a></p></center>
            <center><p>Developed By: Meek Tech - Copyright &copy; 2023 - All Rights Reserved</p></center>
        </div>
    </div>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <br /><br /><br />

    <%: Scripts.Render("~/bundles/myscripts") %>


</body>
</html>
