<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProviderEntry.aspx.cs" Inherits="The18th.ProviderEntry" %>


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

                             <li><a href="#">Provider Entry</a></li>

                          </ul>
                      </div>
            </div>
        </div>
        <form id="form1" runat="server">

          <div class="container">

           <div class="page-header">

            <br /><br />

            <br /><br />

            <h1>Providers</h1>

            <p class="lead">Provider Information</p>
                           
            </div>
            
            <Center><p>Please enter a provider information.</p></Center>
         
            <hr />

            <center><asp:Label ID="exceptionLabel" runat="server" Text=""></asp:Label></center>


             <div class="form-group">
                <label>Please select a service type.</label>
                <asp:DropDownList ID="serviceTypeDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Service Type..." Value="Select Service Type..." Selected="True" Enabled="true" />
                <asp:ListItem Text="Packaging" Value="Packaging" />
                <asp:ListItem Text="Meat Processing" Value="MeatProcessing" />
                <asp:ListItem Text="Cold Storage" Value="ColdStorage" />
                <asp:ListItem Text="Farm Equipment" Value="FarmEquipment" />
                <asp:ListItem Text="Water" Value="Water" />
                </asp:DropDownList><br />
            </div>

            <br />

            <div class="form-group">
                <label>Please enter service description.</label>
                <asp:TextBox ID="descriptionTextBox" placeholder="Service Description" runat="server" CssClass="form-control"></asp:TextBox><br />
            </div>
                         
            <br />

            <div class="form-group">
                <label>Please enter company name.</label>
                <asp:TextBox ID="companyNameTextBox" placeholder="Company Name" runat="server" CssClass="form-control"></asp:TextBox><br />
            </div>

            <br />

            <div class="form-group">
                <label>Please enter representative name.</label>
                <asp:TextBox ID="representativeTextBox" placeholder="Representative Name" runat="server" CssClass="form-control"></asp:TextBox><br />
            </div>

            <br />

           <div class="form-group">
                <label>Please select a location.</label>
                <asp:DropDownList ID="locationDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Location..." Value="Select Location..." Selected="True" Enabled="true" />
                <asp:ListItem Text="East Africa" Value="East Africa" />
                <asp:ListItem Text="West Africa" Value="West Africa" />
                <asp:ListItem Text="South East U.S" Value="South East U.S" />
                <asp:ListItem Text="North East U.S" Value="North East U.S" />
                </asp:DropDownList><br />
            </div>

            <br />

           <div class="form-group">
                <label>Please enter your phone .</label>
                <asp:TextBox ID="phoneTextBox" placeholder="Phone Number" runat="server" CssClass="form-control"></asp:TextBox><br />
           </div>
              
           <br />

           <div class="form-group">
                <label>Please enter your personal email.</label>
                <asp:TextBox ID="emailTextBox" placeholder="youremail@email" runat="server" CssClass="form-control"></asp:TextBox><br />
           </div>

           <div class="form-group">
                <label>Please enter facebook url.</label>
                <asp:TextBox ID="facebookTextBox" placeholder="Facebook" runat="server" CssClass="form-control"></asp:TextBox><br />
           </div>
              
           <br />

           <div class="form-group">
                <label>Please enter twitter url.</label>
                <asp:TextBox ID="twitterTextBox" placeholder="Twitter" runat="server" CssClass="form-control"></asp:TextBox><br />
           </div>
              
           <br />

           <div class="form-group">
                <label>Please enter web url.</label>
                <asp:TextBox ID="webTextBox" placeholder="Website" runat="server" CssClass="form-control"></asp:TextBox><br />
           </div>
              
            <asp:Button ID="submitButton" runat="server" Text="Submit Information" CssClass="btn btn-md btn-primary" OnClick="submitButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/>

            <br /><br /><br /><br /><br /><br /><br /><br /><br />

            <h3>&nbsp;</h3>
            
            <p>
                <asp:Label ID="myLabel" runat="server" Visible="false"></asp:Label>
            </p>

            <h3><asp:Label ID="resultLabel" runat="server" Text="" Visible="false"></asp:Label></h3>


            <h3><asp:Label ID="adminNumberLabel" runat="server" Text="" Visible ="false"></asp:Label></h3>

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
