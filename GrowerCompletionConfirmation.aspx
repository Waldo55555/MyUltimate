<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GrowerCompletionConfirmation.aspx.cs" Inherits="The18th.GrowerCompletionConfirmation" %>


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

                            <%-- <li><a href="VendorCenter.aspx">Enter Vendors</a></li>--%>


                          </ul>
                      </div>
            </div>
        </div>
        <form id="form1" runat="server">
           <div class="container">

               <br /><br />
               <center><h2><em><strong>Completed!<img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/greencheck.gif" alt="picture" /></strong></em></h2></center>

	            <center><h4><em><strong>Thank you for becoming a grower!</strong></em></h4></center>

                <center><h4><em><strong>Please make note of your grower number.</strong></em></h4></center>

                <center><h4><em><strong>Use your grower number to sign-in to your grower dash.</strong></em></h4></center>

                <center><h4><em><strong>Grower Number: <asp:Label ID="growerNumberLabel" runat="server" Text="" Visible="true"></asp:Label></strong></em></h4></center>
                       
                <br />  

                <br /><br /><br />

                <center><asp:Button ID="growerDashButton" runat="server" Text="Go To Grower Dash" CssClass="btn btn-md btn-outline-primary" OnClick="growerDashButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/> </center>
     
             <br /><br /><br />

            </div>

         </form>
  
    <!--Footer-->
    <div class="container">

            <br />

            <center><p>Contact Us Today!&nbsp;&nbsp;|&nbsp;&nbsp;<a href="mailto:the18th_helpdesk@yahoo.com">Member Service</a></p></center>

            <center><p>Developed By: Meek Tech - Copyright &copy; 2023 - All Rights Reserved</p></center>

    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <br /><br /><br />

    <%: Scripts.Render("~/bundles/myscripts") %>

</body>
</html>


