<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePhoto.aspx.cs" Inherits="The18th.ProfilePhoto" %>


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

      <div class="container">

        <div class="page-header">
                                
             <br /><br />

            <h1>Member Profile</h1>

            <p class="lead">Please select a member profile photo that can be associated with your membership.</p>
 
            </div>
                      
            <p class="lead">Please select a vendor profile photo.</p>

            <hr />
               
            <asp:ImageButton ID="maleImageButton" ImageUrl="https://the18thstorage.blob.core.windows.net/the18thcontainer/member1.png" Height="100px" Width="100px" runat="server" OnClientClick="return confirm('You Are Selecting A Male Profile')" OnClick="maleImageButton_Click" />&nbsp;<asp:Label ID="maleLabel" runat="server" Text="Male Profile"></asp:Label><br /> <br />

            <asp:ImageButton ID="femaleImageButton" ImageUrl="https://the18thstorage.blob.core.windows.net/the18thcontainer/member2.png" runat="server" OnClientClick="return confirm('You Are Selecting A Female Profile')" OnClick="femaleImageButton_Click" />&nbsp;<asp:Label ID="femaleLabel" runat="server" Text="Female Profile"></asp:Label><br />

            <br /> <br /> <br />

            <asp:FileUpload ID="photoFileUpload" Visible="false" runat="server" />

            <br /><br /><br /><br /><br /><br /><br /><br /><br />

            <h3><asp:Label ID="resultLabel" runat="server" Text=""></asp:Label></h3>

            <h3><asp:Label ID="companyNameLabel" runat="server" Text=""></asp:Label></h3>
          
            <asp:Label ID="existingAccountLabel" runat="server" Text="" Visible="false"></asp:Label>
               
           <br /><br /><br />

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
