<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberDrive.aspx.cs" Inherits="The18th.MemberDrive" %>

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

                              <%-- <li><a href="https://onyxdirectory.net/Directory/OrderActivity?cityNumber=@assetNumber">My Orders</a></li>

                               <li><a href="https://onyxdirectory.net/Directory/ShippingActivity?cityNumber=@assetNumber">My Shipping</a></li>

                               <li><a href="https://onyxdirectory.net/Directory/PaymentActivity?cityNumber=@assetNumber">My Payments</a></li>--%>    
                                
                               <%--<li><a href="/AllGrowers">Growers Market</a></li>

                               <li><a href="#">Favorite Growers</a></li>--%>
                             <li><a href="/Knowledge/Craddle/AboutOrders" target="_blank">About Orders</a></li>

                             <li><a href="/Knowledge/Craddle/AboutShipping" target="_blank">About Shipping</a></li>

                             <li><a href="/Knowledge/Craddle/AboutVendors" target="_blank">About Vendors</a></li>

                          </ul>
                      </div>
            </div>
        </div>
        <form id="form1" runat="server">

            <div class="container">

               <div class="page-header">

                 <br /><br />

                <h1>Member Drive</h1>

                <p class="lead">"Lets get going"</p>
                           
                </div>
                       
            <%--<hr />--%>

            <h3><Strong>Customer Information</Strong></h3>
  
            <p><Strong>First Name:</Strong>&nbsp;&nbsp;<asp:Label ID="firstNameLabel" runat="server" ForeColor="#009933"></asp:Label></p>
                         
            <p><Strong>Address:</Strong>&nbsp;&nbsp;<asp:Label ID="addressLabel" runat="server" ForeColor="#009933"></asp:Label></p>

            <p><Strong>Phone:</Strong>&nbsp;&nbsp;<asp:Label ID="phoneLabel" runat="server" ForeColor="#009933"></asp:Label></p>
 
            <br />

            <!------------------------------------------------------------------------------------------------->
            <%--<p><Strong>Order Date:</Strong>&nbsp;&nbsp;<asp:Label ID="orderDateLabel" runat="server" ForeColor="#009933"></asp:Label></p>

            <p><Strong>Order Status:</Strong>&nbsp;&nbsp;<asp:Label ID="orderStatusLabel" runat="server" ForeColor="#009933"></asp:Label></p>
 
            <br />--%>
            <!------------------------------------------------------------------------------------------------->
            <p><img src="/Images/cargovan.jpg" width="100" height="100" alt="cargo" /> Loading...<asp:Label ID="cartCountLabel" runat="server" Font-Bold="true" Text="" ForeColor="RoyalBlue" Visible="true"></asp:Label></p>
                     
            <p><Strong>Sub Total:</Strong><asp:Label ID="currencyLabel" runat="server" Text=""></asp:Label><asp:Label ID="subtotalLabel" runat="server" ForeColor="#009933"></asp:Label></p>
         
            <p><Strong>Tax:</Strong><asp:Label ID="taxCurrencyLabel" runat="server" Text=""></asp:Label><asp:Label ID="taxLabel" runat="server" ForeColor="#009933"></asp:Label></p>
    
            <p><Strong>Order Date:</Strong>&nbsp;&nbsp;<asp:Label ID="orderDateLabel" runat="server" ForeColor="#009933"></asp:Label></p>

            <%--<asp:Label ID="cartCountLabel" runat="server" Font-Bold="true" Text="" ForeColor="RoyalBlue" Visible="true"></asp:Label><br /><br />
                 
            <p>&nbsp;</p>--%>
                             
            <!------------------------------------------------------------------------------------------------->
            <h2>Delivery Location</h2>
                   
            <Center><p>Please enter your delivery information.</p></Center>
         
            <center><asp:Label ID="exceptionLabel" runat="server" Text=""></asp:Label></center>
                         
          <%--  <asp:TextBox ID="memberLocationTextBox" runat="server"></asp:TextBox>--%>

            <div class="form-group">
               <label>Please enter delivery location.</label>
               <asp:TextBox ID="deliveryLocationTextBox" placeholder="Your Location" runat="server" CssClass="form-control"></asp:TextBox><br />
              <%--<asp:RequiredFieldValidator ID="addressValidator" runat="server" ForeColor="Red" ControlToValidate="addressTextBox" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
            </div>
                           
            <br /><br />

            <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false&libraries=places&key=AIzaSyAbhKI_vU2_cA06d_NKe8KYSk-bIzozcwo"></script>
            <script type="text/javascript">
                google.maps.event.addDomListener(window, 'load', function () {
                    var places = new google.maps.places.Autocomplete(document.getElementById('<%=deliveryLocationTextBox.ClientID %>'));
                    google.maps.event.addListener(places, 'place_changed', function () {
                        var place = places.getPlace();
                          document.getElementById('<%=txtAddress.ClientID %>').value = place.formatted_address;
                          document.getElementById('<%=txtLatitude.ClientID %>').value = place.geometry.location.lat();
                          document.getElementById('<%=txtLongitude.ClientID %>').value = place.geometry.location.lng();
      
                    });
                });
            </script>

            <asp:Button ID="submitButton" runat="server" Text="Submit Information" CssClass="btn btn-md btn-primary" OnClick="submitButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/>

            <h3><asp:Label ID="orderNumberLabel" runat="server" Text="" Visible="false"></asp:Label></h3>

            <h3><asp:Label ID="cartNumberLabel" runat="server" Text="" Visible="false"></asp:Label></h3>
         
            <br /> <br /> <br /> <br />

            <h3>&nbsp;</h3>
            
            <p>
                <asp:Label ID="myLabel" runat="server"></asp:Label>
            </p>
            <p>&nbsp;</p>

             <br /><br /><br />

         </div>

             <asp:TextBox ID="txtAddress" runat="server" Width="1" />

             <asp:TextBox ID="txtLatitude" runat="server" Width="1" />

             <asp:TextBox ID="txtLongitude" runat="server" Width="1" />

       </form>
  
    <!--Footer-->
    <div class="navbar navbar-default navbar-fixed-bottom">
        <div class="container">
            <br />
            <center><p>Contact Us Today!&nbsp;&nbsp;|&nbsp;&nbsp;<a href="mailto:the18th_helpdesk@yahoo.com">Member Service</a></p></center>
            <center><p>Developed By: Meek Tech - Copyright &copy; 2023 - All Rights Reserved</p></center>
          <%--  <center><p><asp:TextBox ID="TextBox1" runat="server" Width="0" />|<asp:TextBox ID="TextBox2" runat="server" Width="0" />|<asp:TextBox ID="TextBox3" runat="server" Width="0" /></p></center>--%>
         </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <br /><br /><br />

    <%: Scripts.Render("~/bundles/myscripts") %>

</body>
</html>
