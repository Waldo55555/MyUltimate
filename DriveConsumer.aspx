<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DriveConsumer.aspx.cs" Inherits="The18th.DriveConsumer" %>



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
                             <li><a href="/Knowledge/Craddle/AboutOrders" target="_blank">Orders</a></li>

                             <li><a href="/Knowledge/Craddle/PurchaseInfo" target="_blank">Products</a></li>

                             <li><a href="/Knowledge/Craddle/VendorInfo" target="_blank">Vendors</a></li>

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
                                                          
            <!------------------------------------------------------------------------------------------------->
            <h2>Customer Information</h2>
                   
            <Center><p>Please enter your information.</p></Center>
         
            <center><asp:Label ID="exceptionLabel" runat="server" Text=""></asp:Label></center>

            <div class="form-group">
                <label>Please enter your first name.</label>
                <asp:TextBox ID="firstNameTextBox" placeholder="First Name" runat="server" CssClass="form-control"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="firstNameValidator" runat="server" ForeColor="Red" ControlToValidate="firstNameTextBox" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </div>
                                   
          <div class="form-group">
                <label>Please enter address.</label>
                <asp:TextBox ID="addressTextBox" placeholder="Your Address" runat="server" CssClass="form-control"></asp:TextBox><br />
              <asp:RequiredFieldValidator ID="addressValidator" runat="server" ForeColor="Red" ControlToValidate="addressTextBox" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </div>
       
            <div class="form-group">
                <label>Please enter your primary phone.</label>
                 <asp:TextBox ID="phoneTextBox" placeholder="Your Phone" runat="server" CssClass="form-control"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="phoneValidator" runat="server" ForeColor="Red" ControlToValidate="phoneTextBox" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </div>
 
            <br />

            <asp:Button ID="submitButton" runat="server" Text="Submit Information" CssClass="btn btn-md btn-primary" OnClick="submitButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/>

            <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false&libraries=places&key=AIzaSyAbhKI_vU2_cA06d_NKe8KYSk-bIzozcwo"></script>
            <script type="text/javascript">
                google.maps.event.addDomListener(window, 'load', function () {
                    var places = new google.maps.places.Autocomplete(document.getElementById('<%=addressTextBox.ClientID %>'));
                    google.maps.event.addListener(places, 'place_changed', function () {
                        var place = places.getPlace();
                       /* New*/
                        document.getElementById('<%=txtAddress.ClientID %>').value = place.formatted_address;
                        document.getElementById('<%=txtLatitude.ClientID %>').value = place.geometry.location.lat();
                        document.getElementById('<%=txtLongitude.ClientID %>').value = place.geometry.location.lng();
                                         
                    });
                });
            </script>
         
            <%--<h3><asp:Label ID="orderNumberLabel" runat="server" Text="" Visible="false"></asp:Label></h3>--%>

            <h3><asp:Label ID="cartNumberLabel" runat="server" Text="" Visible="false"></asp:Label></h3>

            <h3><asp:Label ID="growerNumberLabel" runat="server" Text="" Visible="false"></asp:Label></h3>
         
            <%--<h3><asp:Label ID="accountNumberLabel" runat="server" Text="" Visible="false"></asp:Label></h3>

            <h3><asp:Label ID="sessionLabel" Visible="false" runat="server" Text=""></asp:Label></h3>--%>

            <br /> <br /> <br /> <br />

            <h3>&nbsp;</h3>
            
            <p>
                <asp:Label ID="myLabel" runat="server"></asp:Label>
            </p>
            <p>&nbsp;</p>

             <br /><br /><br />

         </div>

             <%--new--%>
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
         </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <br /><br /><br />

    <%: Scripts.Render("~/bundles/myscripts") %>

</body>
</html>

