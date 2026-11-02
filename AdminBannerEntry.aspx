<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminBannerEntry.aspx.cs" Inherits="The18th.AdminBannerEntry" %>



<%--<%@ OutputCache Duration="3600" VaryByParam="None" %>--%>
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

                            <li><a href="/Ads/Ad/AboutAdvertisements">About Advertisements</a></li>

                            <li><a href="https://www.bannersnacks.com" target="_blank">Create A Banner</a></li>
                          </ul>
                      </div>
            </div>
        </div>
        <form id="form1" runat="server">
            <br /><br />
         <div class="container">

           <div class="page-header">

            <h1>Advertisement Banner</h1>

            <p class="lead">Submit A Banner For This Ad</p>
   
            </div>
          
            <hr />

           <p>Company Name:&nbsp;<asp:Label ID="companyLabel" ForeColor="Green" runat="server" Visible="true" Text=""></asp:Label></p>
 
           <p>Client Phone:&nbsp;<asp:Label ID="phoneLabel" ForeColor="Green" runat="server" Visible="true" Text=""></asp:Label></p>
        
           <p>Client Email:&nbsp;<asp:Label ID="emailLabel" ForeColor="Green" runat="server" Visible="true" Text=""></asp:Label></p>
                    
            <br />
               
            <center><h4 style="color:blue">If there is not a proper banner to upload from your device please use the "Create A Banner" resource on this page.</h4></center>
          
            <br /> <br /> 

            <div class="form-group">
                <label>Please upload your banner photo.</label>
                 <P>please upload a large image a minimum of 960 x 720</P>
                 <P>acceptable file types: JPG,GIF</P>
               <asp:FileUpload ID="photoFileUpload" runat="server" CssClass="form-control" /><br />

            </div>
   
            <asp:Label ID="resultMessageLabel" runat="server"></asp:Label>&nbsp;&nbsp;<asp:HyperLink ID="viewHyperLink" runat="server">View Photo</asp:HyperLink><br /><br />
                   
            <asp:Button ID="uploadButton" runat="server" Text="Submit Banner" CssClass="btn btn-md btn-primary" OnClick="uploadButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/>
                      
             <br /><br /><br />
             <br /><br /><br />
             <br /><br /><br />
             <br /><br /><br />

         </div>

      </form>
  
    <!--Footer-->
    <div class="navbar navbar-default navbar-fixed-bottom">
        <div class="container">
           <br />
             <center><p>Developed By: Meek Tech - Copyright &copy; 2023 - All Rights Reserved</p></center>
             <center><p>Ad World:&nbsp;&nbsp;<a href="/Ads/Ad/AboutAdvertisements">Advertise</a>&nbsp;|&nbsp;Donations:&nbsp;&nbsp;<a href="/Donations/Donations/DonateFace">Pledge</a></p></center>
             <center><p>AG Newsletter:&nbsp;&nbsp;<a href="https://avatar-growers.com/newsletter/" target="_blank">Suscribe</a>&nbsp;|&nbsp;<a href="Meek/MeekHome/AboutUs">About Us</a></p></center>
        </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <br /><br /><br />

    <%: Scripts.Render("~/bundles/myscripts") %>

</body>
</html>
