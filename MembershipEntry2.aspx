<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MembershipEntry2.aspx.cs" Inherits="The18th.MembershipEntry2" %>

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
        
<!--@*client side validation in order*@-->
<script src="~/Scripts/jquery-3.3.1.min.js"></script>
<script src="~/Scripts/jquery.validate.min.js"></script>
<script src="~/Scripts/jquery.validate.unobtrusive.min.js"></script>  

            
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

            <h1>Membership</h1>

            <p class="lead">Membership Information</p>
                           
            </div>
            
            <Center><h4>Please enter your personal information.</h4></Center>
            <hr />

            <center><asp:Label ID="exceptionLabel" runat="server" Text=""></asp:Label></center>


          <asp:MultiView ID="MembershipMultiView" runat="server">

              <asp:View ID="phoneView" runat="server">
                    <div class="form-group">
                        <%--<label>Please enter your phone.</label>--%>
                        <asp:TextBox ID="americanPhoneTextBox" placeholder=" U.S Phone Number" runat="server" CssClass="form-control"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="phoneValidator" runat="server" ForeColor="Red" ControlToValidate="americanPhoneTextBox" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>

                   <asp:Button ID="phoneButton" runat="server" Text="Next" CssClass="btn btn-md btn-primary" OnClick="phoneButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';" />

              </asp:View>

              <asp:View ID="screenNameView" runat="server">
                   <div class="form-group">
                        <label>Please enter a screen name.</label>
                        <asp:TextBox ID="screenNameTextBox" placeholder="Screen Name" runat="server" CssClass="form-control"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="screenValidator" runat="server" ForeColor="Red" ControlToValidate="screenNameTextBox" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </div>

                   <asp:Button ID="screenNameButton" runat="server" Text="Next" CssClass="btn btn-md btn-primary" OnClick="screenNameButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';" />

              </asp:View>


              <asp:View ID="memberTypeView" runat="server">

                   <div class="form-group">
                      <label>Please enter a member type.</label>
                      <asp:DropDownList ID="memberTypeDropDownList" runat="server" CssClass="form-control">
                      <asp:ListItem Text="Select Member Type..." Value="Select Member Type..." Selected="True" Enabled="true" />
                      <asp:ListItem Text="Active(Producing A Product)" Value="Active" />
                      <asp:ListItem Text="Benefiting(Purchases Products)" Value="Benefiting" />
                      </asp:DropDownList>
                  </div>

                   <asp:Button ID="memberTypeButton" runat="server" Text="Next" CssClass="btn btn-md btn-primary" OnClick="memberTypeButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';" />


              </asp:View>

              <asp:View ID="faceView" runat="server">

                   <Center><h3>Please enter fanbase information.</h3></Center>

                   <%--<Center><h4>Connect to your fanbase content.Locate your url link on the fanbase app and enter it here. Simply go to your settings in the app.</h4></Center>

                   <Center><h4>Click on Import from Instagram to find your url and copy it here.</h4></Center>--%>

                   <div class="form-group">
                         <div class="input-group"> <%--#myInputGroup--%>
                              <span class="input-group-addon" id="basic-addon">https://www.fanbase.app/@ &nbsp;</span>
                              <asp:TextBox ID="fanbaseTextBox" runat="server"></asp:TextBox>
                         </div>
                   </div>
                   <asp:Button ID="faceButton" runat="server" Text="Next" CssClass="btn btn-md btn-primary" OnClick="faceButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';" />

              </asp:View>

              <asp:View ID="firstNameView" runat="server">
                   <div class="form-group">
                      <label>Please enter your first name.</label>
                      <asp:TextBox ID="firstNameTextBox" placeholder="First Name" runat="server" CssClass="form-control"></asp:TextBox><br />
                      <asp:RequiredFieldValidator ID="firstNameValidator" runat="server" ForeColor="Red" ControlToValidate="firstNameTextBox" ErrorMessage="Required"></asp:RequiredFieldValidator>
                  </div>

                   <asp:Button ID="firstNameButton" runat="server" Text="Next" CssClass="btn btn-md btn-primary" OnClick="firstNameButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';" />

              </asp:View>

              <asp:View ID="lastNameView" runat="server">

                   <div class="form-group">
                      <label>Please enter your last name.</label>
                      <asp:TextBox ID="lastNameTextBox" placeholder="Last Name" runat="server" CssClass="form-control"></asp:TextBox><br />
                      <asp:RequiredFieldValidator ID="lastNameValidator" runat="server" ForeColor="Red" ControlToValidate="lastNameTextBox" ErrorMessage="Required"></asp:RequiredFieldValidator>
                  </div>

                   <asp:Button ID="lastNameButton" runat="server" Text="Next" CssClass="btn btn-md btn-primary" OnClick="lastNameButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';" />

              </asp:View>

              <asp:View ID="emailView" runat="server">

                   <div class="form-group">
                      <label>Please enter your personal email.</label>
                      <asp:TextBox ID="emailTextBox" placeholder="youremail@email" runat="server" CssClass="form-control"></asp:TextBox><br />
                      <asp:RequiredFieldValidator ID="emailValidator" runat="server" ForeColor="Red" ControlToValidate="emailTextBox" ErrorMessage="Required"></asp:RequiredFieldValidator>
                  </div>
        
                  <div class="form-group">
                  <label>Please verify email.</label>
                  <asp:TextBox ID="verifyEmailTextBox" placeholder="Verify Your Email"  runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox><br />
                  <asp:RequiredFieldValidator ID="emailFieldValidator" runat="server" ForeColor="Red" ControlToValidate="verifyEmailTextBox" ErrorMessage="Required"></asp:RequiredFieldValidator>
                  <asp:CompareValidator ID="verifyEmail" runat="server" ErrorMessage="Emails Do Not Match" ControlToValidate="verifyEmailTextBox" ControlToCompare="emailTextBox" Operator="Equal" Type="String" ForeColor="Red"></asp:CompareValidator>
                  </div>

                  <asp:Button ID="emailButton" runat="server" Text="Next" CssClass="btn btn-md btn-primary" OnClick="emailButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';" />

              </asp:View>

              <asp:View ID="submitView" runat="server">

                   <center><p><asp:Button ID="submitButton" runat="server" Text="Submit Information" CssClass="btn btn-md btn-primary" OnClick="submitButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/>&nbsp; <a class="btn btn-md btn-primary" href="Welcome.aspx">Return</a></p></center>

              </asp:View>

          </asp:MultiView> <%--Real--%>
                   
            <h3>&nbsp;</h3>
            
            <p>
                <asp:Label ID="myLabel" runat="server"></asp:Label>
            </p>

            <h3><asp:Label ID="resultLabel" runat="server" Text=""></asp:Label></h3>

            <p>&nbsp;</p>

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

