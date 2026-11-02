<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdInterest.aspx.cs" Inherits="The18th.AdInterest" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=0"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Advertisements</title>
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
               
                <h1>Advertisement Interest</h1>

                <p class="lead">Get Started With Ads</p>
                           
                </div>
            
                <Center><h3>Please enter company information.</h3></Center>
                        
                <hr />
                             
                 <div class="container">
                  <div class="row">
                      <div class="col-xs-12 cell">
                          <center>
                              <asp:MultiView ID="AdMultiView" runat="server">

                                  <asp:View ID="View1" runat="server">


                                    <h4>As a grower you can showcase your crops and operation to show other members what you offer</h4>


                                    <div class="card">
                                        <div class="card-block">
                                            <h4 class="card-title"><a href="/Knowledge/Craddle/AboutAdvertisements" target="_blank">About Advertisements</a></h4>
                                            <h4 class="card-subtitle">Please enter company name.</h4>
                                            <%--<p class="card-text"><small class="text-muted">Please enter company name.</small></p>--%>
                                           <asp:TextBox ID="companyNameTextBox" placeholder="Company Name" runat="server" CssClass="form-control"></asp:TextBox><br /><br /><br />
                                        </div>
                                        <br />
                                        <asp:Button ID="companyNameButton" runat="server" Text="Next" CssClass="btn btn-md btn-primary" OnClick="companyNameButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';" />
                                    </div>

                                  </asp:View>

                                  <asp:View ID="View2" runat="server">

                                   <div class="card">
                                        <div class="card-block">
                                            <h4 class="card-title"><a href="/Knowledge/Craddle/AboutAdvertisements" target="_blank">About Advertisements</a></h4>
                                            <h4 class="card-subtitle">Please enter contact phone.</h4>
                                          <%--  <p class="card-text"><small class="text-muted">Please enter contact phone.</small></p>--%>
                                           <asp:TextBox ID="contactPhoneTextBox" placeholder="Company Phone" runat="server" CssClass="form-control"></asp:TextBox><br /><br /><br /><br />
                                        </div>
                                        <br />
                                       <asp:Button ID="contactPhoneButton" runat="server" Text="Next" CssClass="btn btn-md btn-primary" OnClick="contactPhoneButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';" />
                                    </div>

                                  </asp:View>

                                  <asp:View ID="View3" runat="server">
                                                                       
                                      <div class="card">
                                          <div class="card-block">
                                              <h4 class="card-title"><a href="/Knowledge/Craddle/AboutAdvertisements" target="_blank">About Advertisements</a></h4>
                                              <h4 class="card-subtitle">Please enter contact email.</h4>
                                             <%-- <p class="card-text"><small class="text-muted">Please enter contact email.</small></p>--%>
                                             <asp:TextBox ID="contactEmailTextBox" placeholder="Company Email" runat="server" CssClass="form-control"></asp:TextBox><br /><br /><br /><br />
                                          </div>
                                          <br />
                                         <asp:Button ID="contactEmailButton" runat="server" Text="Next" CssClass="btn btn-md btn-primary" OnClick="contactEmailButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';" />
                                      </div>

                                  </asp:View>

                                  <asp:View ID="View4" runat="server">
  
                                        <div class="card">
                                            <div class="card-block">
                                                <h4 class="card-title"><a href="/Knowledge/Craddle/AboutAdvertisements" target="_blank">About Advertisements</a></h4>
                                                <h4 class="card-subtitle">Will You Require Banner Design?</h4>
                                               <%-- <p class="card-text"><small class="text-muted">Will You Require Banner Design.</small></p>--%>
                                                <asp:RadioButton ID="selectRadioButton" Text="Yes Create A Banner For Me" Font-Size="Medium" runat="server" /><br /><br />
                                            </div>
                                            <br />
                                            <asp:Button ID="buttonFinishButton" runat="server" Text="Continue" CssClass="btn btn-md btn-primary" OnClick="buttonFinishButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/>
                                            <br />
                                        </div>
                                      <br /><br />
                                      <asp:Button ID="completeButton" runat="server" Text="Create My Ad Campaign" CssClass="btn btn-md btn-primary" OnClick="completeButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';" />

                                   </asp:View>
                                 
                              </asp:MultiView>

                         </center>

                      </div><%-- cell end--%>
    
                  </div><%-- row end--%>

                </div><%-- container end--%>
                             

             <h3><asp:Label ID="selectedDesignLabel" runat="server" Text="" Visible="false"></asp:Label></h3>

          </div>
              
       </form>
    <!--Footer-->
    <div class="container">
            <br />
            <center><p>Contact Us Today!&nbsp;&nbsp;|&nbsp;&nbsp;<a href="mailto:the18th_helpdesk@yahoo.com">Member Service</a></p></center>
            <center><p>Developed On Duty: Waldo - Copyright &copy; 2023 - All Rights Reserved</p></center>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <br /><br /><br />

    <%: Scripts.Render("~/bundles/myscripts") %>

</body>
</html>



