<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompletedOrder.aspx.cs" Inherits="The18th.CompletedOrder" %>


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

                              <%-- <li><a href="https://onyxdirectory.net/Directory/OrderActivity?cityNumber=@assetNumber">My Orders</a></li>

                               <li><a href="https://onyxdirectory.net/Directory/ShippingActivity?cityNumber=@assetNumber">My Shipping</a></li>

                               <li><a href="https://onyxdirectory.net/Directory/PaymentActivity?cityNumber=@assetNumber">My Payments</a></li>--%>    
                                
                               <%--<li><a href="/AllGrowers">Growers Market</a></li>

                               <li><a href="#">Favorite Growers</a></li>--%>
                             <li><a href="/Growers/GrowersMarket/AllGrowers">Growers Market</a></li>
                             <li><a href="/OneState/OneState/AboutDiscounts">About Discounts</a></li>
                             <li><a href="/OneState/OneState/AboutPromotions">About Promotions</a></li>
                             <li><a href="/OneState/OneState/AboutFavorites">About Favorites</a></li>

                          </ul>
                      </div>
            </div>
        </div>
        <form id="form1" runat="server">

          <div class="container">

           <div class="page-header">

             <br /><br />

            <h1>One State Payments</h1>

            <p class="lead">"A different way to pay"</p>
                                                
            <h3>Order</h3>

            <h4>Review And Finalize Your Order</h4>

            </div>
            
            <%--  <hr />--%>
            
           <p>Customer Information</p>

            <p><Strong>First Name:</Strong>&nbsp;&nbsp;<asp:Label ID="firstNameLabel" runat="server" ForeColor="#009933"></asp:Label></p>

            <p><Strong>Last Name:</Strong>&nbsp;&nbsp;<asp:Label ID="lastNameLabel" runat="server" ForeColor="#009933"></asp:Label></p>
 
            <p><Strong>Address:</Strong>&nbsp;&nbsp;<asp:Label ID="addressLabel" runat="server" ForeColor="#009933"></asp:Label></p>

            <p><Strong>Location:</Strong>&nbsp;&nbsp;<asp:Label ID="locationLabel" runat="server" ForeColor="#009933"></asp:Label></p>
 
            <p><Strong>Zip:</Strong>&nbsp;&nbsp;<asp:Label ID="zipLabel" runat="server" ForeColor="#009933"></asp:Label></p>

            <p><Strong>Phone:</Strong>&nbsp;&nbsp;<asp:Label ID="phoneLabel" runat="server" ForeColor="#009933"></asp:Label></p>
 
            <p><Strong>Email:</Strong>&nbsp;&nbsp;<asp:Label ID="emailLabel" runat="server" ForeColor="#009933"></asp:Label></p>
 
            <br />
                                                        
            <!------------------------------------------------------------------------------------------------->
            <p>Order Information</p>

            <p><Strong>Order Date:</Strong>&nbsp;&nbsp;<asp:Label ID="orderDateLabel" runat="server" ForeColor="#009933"></asp:Label></p>

            <p><Strong>Order Status:</Strong>&nbsp;&nbsp;<asp:Label ID="orderStatusLabel" runat="server" ForeColor="#009933"></asp:Label></p>
 
            <br />

            <!------------------------------------------------------------------------------------------------->
            <p><img src ="https://the18thstorage.blob.core.windows.net/the18thcontainer/cart.jpg" width="60" height="60" alt="cart photo" /> Cart</p>
                    
            <p><Strong>Sub Total:</Strong>&nbsp;&nbsp;<asp:Label ID="subtotalLabel" runat="server" ForeColor="#009933"></asp:Label></p>
         
            <p><Strong>Tax:</Strong>&nbsp;&nbsp;<asp:Label ID="taxLabel" runat="server" ForeColor="#009933"></asp:Label></p>
    
            <asp:Label ID="cartCountLabel" runat="server" Font-Bold="true" Text="" ForeColor="RoyalBlue" Visible="true"></asp:Label><br /><br />
                 
            <p>&nbsp;</p>

            <!------------------------------------------------------------------------------------------------->
        
            <p>Shipping Information</p>

            <p><Strong>Shipping Number:</Strong>&nbsp;&nbsp;<asp:Label ID="shipNumberLabel" runat="server" ForeColor="#009933"></asp:Label></p>

            <p><Strong>Tracking Number:</Strong>&nbsp;&nbsp;<asp:Label ID="trackingNumberLabel" runat="server" ForeColor="#009933"></asp:Label></p>
 
            <p><Strong>Ship Name:</Strong>&nbsp;&nbsp;<asp:Label ID="shipNameLabel" runat="server" ForeColor="#009933"></asp:Label></p>

            <p><Strong>Ship Address:</Strong>&nbsp;&nbsp;<asp:Label ID="shipAddressLabel" runat="server" ForeColor="#009933"></asp:Label></p>
 
            <p><Strong>Ship Location:</Strong>&nbsp;&nbsp;<asp:Label ID="shipLocationLabel" runat="server" ForeColor="#009933"></asp:Label></p>

            <p><Strong>Ship Zip:</Strong>&nbsp;&nbsp;<asp:Label ID="shipZipLabel" runat="server" ForeColor="#009933"></asp:Label></p>
 
            <p><Strong>Carrier:</Strong>&nbsp;&nbsp;<asp:Label ID="carrierLabel" runat="server" ForeColor="#009933"></asp:Label></p>

            <p><Strong>Ship Speed:</Strong>&nbsp;&nbsp;<asp:Label ID="shipSpeedLabel" runat="server" ForeColor="#009933"></asp:Label></p>
 
            <br />

            <!------------------------------------------------------------------------------------------------->
      
            <p>Payment Information</p>

            <p><Strong>First Name:</Strong>&nbsp;&nbsp;<asp:Label ID="cardFirstNameLabel" runat="server" ForeColor="#009933"></asp:Label></p>

            <p><Strong>Last Name:</Strong>&nbsp;&nbsp;<asp:Label ID="cardLastNameLabel" runat="server" ForeColor="#009933"></asp:Label></p>
 
            <p><Strong>Card Address:</Strong>&nbsp;&nbsp;<asp:Label ID="cardAddressLabel" runat="server" ForeColor="#009933"></asp:Label></p>

            <p><Strong>Card Location:</Strong>&nbsp;&nbsp;<asp:Label ID="cardLocationLabel" runat="server" ForeColor="#009933"></asp:Label></p>
 
            <p><Strong>Card Zip:</Strong>&nbsp;&nbsp;<asp:Label ID="cardZipLabel" runat="server" ForeColor="#009933"></asp:Label></p>

            <p><Strong>Card Number:</Strong>&nbsp;&nbsp;<asp:Label ID="cardNumberLabel" runat="server" ForeColor="#009933"></asp:Label></p>
 
            <p><Strong>Csc:</Strong>&nbsp;&nbsp;<asp:Label ID="cscLabel" runat="server" ForeColor="#009933"></asp:Label></p>

            <p><Strong>Expiration On Card:</Strong>&nbsp;&nbsp;<asp:Label ID="expirationLabel" runat="server" ForeColor="#009933"></asp:Label></p>
 
            <p><Strong>Card Status:</Strong>&nbsp;&nbsp;<asp:Label ID="cardStatusLabel" runat="server" ForeColor="#009933"></asp:Label></p>
 
            <br />

            <!------------------------------------------------------------------------------------------------->
        
            <h2>Review Order</h2>

            <p>Please review your order information before submittal</p>          

           <%-- <div class="form-group">
                <label>Please enter your first name.</label>
                <asp:TextBox ID="firstNameTextBox" runat="server" CssClass="form-control"></asp:TextBox><br />

            </div>--%>


            <asp:Button ID="completeOrderButton" runat="server" Text="Complete Order" CssClass="btn btn-md btn-outline-primary" OnClick="completeOrderButton_Click"/>

        
            <br /><br />


            <h3><asp:Label ID="orderNumberLabel" runat="server" Text="" Visible="false"></asp:Label></h3>

            <h3><asp:Label ID="cartNumberLabel" runat="server" Text="" Visible="false"></asp:Label></h3>

            <h3><asp:Label ID="accountNumberLabel" runat="server" Text="" Visible="false"></asp:Label></h3>

            <br /><br /><br /><br /><br /><br /><br /><br /><br />

            <p>&nbsp;</p>
            <p>&nbsp;</p>

             <br /><br /><br />

          </div>

       </form>
  
    <!--Footer-->
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
