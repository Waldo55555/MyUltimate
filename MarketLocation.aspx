<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MarketLocation.aspx.cs" Inherits="The18th.MarketLocation" %>

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

                            <%-- <li><a href="VendorCenter.aspx">Enter Vendors</a></li>--%>


                          </ul>
                      </div>
            </div>
        </div>
        <form id="form1" runat="server">

         <div class="container">

           <div class="page-header">

               <br /><br />
                <br /><br />

            <h1>Member Location</h1>

            <p class="lead">Consumer Location Information</p>
                           
            </div>
            
            <Center><p>Please enter your location.</p></Center>
                        
            <hr />
        
           <p><asp:Label ID="errorLabel" runat="server" ForeColor="Red" Text=""></asp:Label></p>
         
             <%--Working--%>
            <iframe src="https://storage.googleapis.com/maps-solutions-e2f5vz1yn3/address-selection/6rkm/address-selection.html"
              width="1200" height="400"
              style="border:0;"
              loading="lazy">
            </iframe>

            <div class="form-group">
                <label>Please enter the grower location.</label>
                 <asp:TextBox ID="locationTextBox" placeholder="Location" runat="server" CssClass="form-control"></asp:TextBox><br />
            </div>
                          
             
            <h1><asp:Label runat="server" ID="lblIpAddress"></asp:Label></h1>


            <asp:GridView ID="gvLocation" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="IPAddress" HeaderText="IP Address" />
                    <asp:BoundField DataField="CountryName" HeaderText="Country" />
                    <asp:BoundField DataField="CityName" HeaderText="City" />
                    <asp:BoundField DataField="RegionName" HeaderText="Region" />
                    <asp:BoundField DataField="CountryCode" HeaderText="Country Code" />
                    <asp:BoundField DataField="Latitude" HeaderText="Latitude" />
                    <asp:BoundField DataField="Longitude" HeaderText="Latitude" />
                    <asp:BoundField DataField="Timezone" HeaderText="Timezone" />
                </Columns>
            </asp:GridView>

            <asp:Button ID="submitButton" runat="server" Text="Next" CssClass="btn btn-md btn-primary" OnClick="submitButton_Click" />

            <br /><br />

            <br /><br /><br /> <br /><br /><br /> <br /><br /><br />
                  
            <h3><asp:Label ID="resultLabel" Visible="false" runat="server" Text=""></asp:Label></h3>

            <p>&nbsp;</p>
            <p>&nbsp;</p>


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

