<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MembershipEntry.aspx.cs" Inherits="The18th.MembershipEntry" %>

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

            <h1>Membership</h1>

            <p class="lead">Membership Information</p>
                           
            </div>
            
            <Center><p>Please enter your personal information. The information that you enter here will not be shared or become public information.</p></Center>
         
            <hr />

            <center><asp:Label ID="exceptionLabel" runat="server" Text=""></asp:Label></center>

           <p>If your cooperative is listed please select otherwise you will be added to the main cooperative.</p>
           <p>You can always update your cooperative status.</p>
           <div class="form-group">
                <label>Please select a cooperative.</label>
                <asp:DropDownList ID="coopDropDownList" runat="server" DataTextField="CooperativeName" DataValueField="CooperativeNumber" CssClass="form-control">
                <asp:ListItem Text="Select Cooperative..." Value="Select Cooperative..." Selected="True" Enabled="true" />
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label>Please select your Country.</label>
                <asp:DropDownList ID="countryDropDownList" runat="server" CssClass="form-control" OnSelectedIndexChanged="countryDropDownList_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="Select Country..." Value="Select Country..." Selected="True" Enabled="true" />
                <asp:ListItem Text="Ghana" Value="Ghana" />
                <asp:ListItem Text="U.S" Value="U.S" />
                </asp:DropDownList><br />
            </div>

            <div class="form-group">
                <%--<label>Please enter your phone.</label>--%>
                 <asp:TextBox ID="americanPhoneTextBox" placeholder=" U.S Phone Number" runat="server" CssClass="form-control"></asp:TextBox><br />
            </div>
            
            
            <div class="form-group">
               <%-- <label>Please enter your phone.</label>--%>
                 <h3><asp:TextBox ID="ghanaPhoneTextBox" placeholder="Ghana Phone Number" runat="server" CssClass="form-control"></asp:TextBox></h3><br />
            </div>

            <div class="form-group">
                <label>Please enter a screen name.</label>
                 <asp:TextBox ID="screenNameTextBox" placeholder="Screen Name" runat="server" CssClass="form-control"></asp:TextBox><br />
            </div>
 
            <div class="form-group">
                <label>Please enter a member type.</label>
                <asp:DropDownList ID="memberTypeDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Member Type..." Value="Select Member Type..." Selected="True" Enabled="true" />
                <asp:ListItem Text="Active(Producing A Product)" Value="Active" />
                <asp:ListItem Text="Benefiting(Purchases Products)" Value="Benefiting" />
                </asp:DropDownList>
            </div>

         <%-- <div class="form-group">
                <label>Please enter your crop focus.</label>
                <asp:DropDownList ID="cropFocusDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Crop Focus..." Value="Select Crop Focus..." Selected="True" Enabled="true" />
                <asp:ListItem Text="Fruits and Vegetables" Value="FruitsandVegetables" />
                <asp:ListItem Text="Beverages" Value="Beverages" />
                <asp:ListItem Text="Poultry,Fish,Meats" Value="Poultry,Fish,Meats" />
                <asp:ListItem Text="Spices And Herbs" Value="SpicesAndHerbs" />
                <asp:ListItem Text="Specialty Foods" Value="SpecialtyFoods" />
                <asp:ListItem Text="All Foods" Value="AllFoods" />
                </asp:DropDownList>
            </div>--%>

           <%--<div class="form-group">
                <label>Please enter your member focus.</label>
                <asp:DropDownList ID="memberFocusDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Member Focus..." Value="Select Member Focus..." Selected="True" Enabled="true" />
                <asp:ListItem Text="Home Gardening" Value="Home Gardening" />
                <asp:ListItem Text="Community Gardening" Value="Community Gardening" />
                <asp:ListItem Text="Small Farming" Value="Small Farming" />
                <asp:ListItem Text="Large Farm Operation" Value="Large Farm Operation" />
                 </asp:DropDownList>
            </div>--%>
           
            <div class="form-group">
                <label>Please enter your Facebook page.</label>
                <asp:TextBox ID="facebookTextBox" placeholder="Facebook" runat="server" CssClass="form-control"></asp:TextBox><br />
            </div>
                                     
         <%--    <div class="form-group">
                <label>Please enter your Twitter.</label>
                <asp:TextBox ID="twitterTextBox" placeholder="Twitter" runat="server" CssClass="form-control"></asp:TextBox><br />
            </div>

             <div class="form-group">
                <label>Please enter your Instagram.</label>
                <asp:TextBox ID="instaTextBox" placeholder="Instagram" runat="server" CssClass="form-control"></asp:TextBox><br />
            </div>--%>


            <div class="form-group">
                <label>Please enter your first name.</label>
                <asp:TextBox ID="firstNameTextBox" placeholder="First Name" runat="server" CssClass="form-control"></asp:TextBox><br />
                <%-- <small class="text-muted">
                        Please enter your first name.
                 </small>--%>
            </div>
                                            
            <div class="form-group">
                <label>Please enter your last name.</label>
                 <asp:TextBox ID="lastNameTextBox" placeholder="Last Name" runat="server" CssClass="form-control"></asp:TextBox><br />
            </div>
                     
           <div class="form-group">
                <label>Please enter your personal email.</label>
                 <asp:TextBox ID="emailTextBox" placeholder="youremail@email" runat="server" CssClass="form-control"></asp:TextBox><br />
           </div>
        
            <p><asp:Button ID="submitButton" runat="server" Text="Submit Information" CssClass="btn btn-md btn-primary" OnClick="submitButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/>&nbsp; <a class="btn btn-md btn-primary" href="Welcome.aspx">Return</a></p>

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
