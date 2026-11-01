<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="The18th.Customer" %>

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
                           
                </div>
                       
            <%--<hr />--%>
            <!------------------------------------------------------------------------------------------------->
            <p><Strong>Order Date:</Strong>&nbsp;&nbsp;<asp:Label ID="orderDateLabel" runat="server" ForeColor="#009933"></asp:Label></p>

            <p><Strong>Order Status:</Strong>&nbsp;&nbsp;<asp:Label ID="orderStatusLabel" runat="server" ForeColor="#009933"></asp:Label></p>
 
            <br />

            <!------------------------------------------------------------------------------------------------->
            <p><img src ="https://the18thstorage.blob.core.windows.net/the18thcontainer/cart.jpg" width="60" height="60" alt="cart photo" /> Cart</p>
                     
            <p><Strong>Sub Total:</Strong><asp:Label ID="currencyLabel" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;<asp:Label ID="subtotalLabel" runat="server" ForeColor="#009933"></asp:Label></p>
         
            <p><Strong>Tax:</Strong><asp:Label ID="taxCurrencyLabel" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;<asp:Label ID="taxLabel" runat="server" ForeColor="#009933"></asp:Label></p>
    
            <asp:Label ID="cartCountLabel" runat="server" Font-Bold="true" Text="" ForeColor="RoyalBlue" Visible="true"></asp:Label><br /><br />
                 
            <p>&nbsp;</p>
                             
            <!------------------------------------------------------------------------------------------------->
            <h2>Customer Information</h2>
                   
            <Center><p>Please enter your information.</p></Center>
         
            <center><asp:Label ID="exceptionLabel" runat="server" Text=""></asp:Label></center>

            <div class="form-group">
                <label>Please enter your first name.</label>
                <asp:TextBox ID="firstNameTextBox" runat="server" CssClass="form-control"></asp:TextBox><br />

            </div>
                                        
                                         
            <div class="form-group">
                <label>Please enter your last name.</label>
                 <asp:TextBox ID="lastNameTextBox" runat="server" CssClass="form-control"></asp:TextBox><br />

            </div>

                 
          <div class="form-group">
                <label>Please enter address.</label>
                <asp:TextBox ID="addressTextBox" runat="server" CssClass="form-control"></asp:TextBox><br />

            </div>
                

            <div class="form-group">
                <label>Please select your location.</label>
                <asp:DropDownList ID="locationDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Location..." Value="Select Location..." Selected="True" Enabled="true" />
                <asp:ListItem Text="East Africa" Value="EastAfrica" />
                <asp:ListItem Text="West Africa" Value="WestAfrica" />
                <asp:ListItem Text="South East U.S" Value="South East U.S" />
                <asp:ListItem Text="North East U.S" Value="North East U.S" />
                </asp:DropDownList><br />
            </div>


             <div class="form-group">
                <label>Please enter your zip code.</label>
                 <asp:TextBox ID="zipTextBox" runat="server" CssClass="form-control"></asp:TextBox><br />

            </div>


            <div class="form-group">
                <label>Please enter your primary phone.</label>
                 <asp:TextBox ID="phoneTextBox" runat="server" CssClass="form-control"></asp:TextBox><br />

            </div>
                     

           <div class="form-group">
                <label>Please enter email address.</label>
                <asp:TextBox ID="emailTextBox" runat="server" CssClass="form-control"></asp:TextBox><br />

            </div>


            <br />

            <asp:Button ID="submitButton" runat="server" Text="Submit Information" CssClass="btn btn-md btn-primary" OnClick="submitButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/>


            <h3><asp:Label ID="orderNumberLabel" runat="server" Text="" Visible="false"></asp:Label></h3>

            <h3><asp:Label ID="cartNumberLabel" runat="server" Text="" Visible="false"></asp:Label></h3>
         
            <h3><asp:Label ID="accountNumberLabel" runat="server" Text="" Visible="false"></asp:Label></h3>


            <br /> <br /> <br /> <br />

            <h3>&nbsp;</h3>
            
            <p>
                <asp:Label ID="myLabel" runat="server"></asp:Label>
            </p>
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
