<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GrowerCropEdit.aspx.cs" Inherits="The18th.GrowerCropEdit" %>


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


    <script src="Scripts22/jquery-1.11.2.min.js"></script>
    <script src="Scripts22/jquery-ui.js"></script>
    <link href="Scripts22/jquery-ui.css" rel="stylesheet" />
     <style>
        li{
            display:inline-block;
            padding:20px;
            border:1px solid black;
            cursor:pointer
          }
          .ui-selected{
              background-color:darkgreen;
              color:white
          }
          .ui-selecting{
              background-color:gray;
              color:white
          }
    </style>
<link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
<link href="../CustomStyles.css" rel="stylesheet">
<link href="../Navigation.css" rel="stylesheet">
              
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
            <Center><h1>Crop Updates</h1></Center>
            <Center><p class="lead">Place crops in the farmers market</p></Center>
            </div>
            <asp:Label ID="growerNumberLabel" runat="server" Visible="false" Text=""></asp:Label>
            <center><h2> Rearrange what you are growing</h2></center>
            <center><p>Please present four crops to represent your growers market.</p></center>
            <center><p><em><strong>Crop Type Examples:</strong></em>&nbsp;<input type="image" height="20" width="20" src="https://the18thstorage.blob.core.windows.net/the18thcontainer/infoPic.png" value="Crop LookUp" onclick="window.open('https://localhost:44366/FarmersMarket/FarmMarket/CropLookUp', '_blank', 'height=400, width=400, top=400,left=400')" /></p></center>
             <div style="font-family:Arial">
                <fieldset style="width:350px">
                <legend>Crops</legend>
                <asp:CheckBoxList ID="greensCheckBoxList" runat="server" DataTextField="Crop" DataValueField="CropIndex" RepeatDirection="Horizontal" RepeatColumns="13" BorderStyle="None" RepeatLayout="Table">
                </asp:CheckBoxList>
                </fieldset>
            </div>
            <br /><br />
            <asp:Button ID="updateCropsButton" runat="server" Text="Update Crops" CssClass="btn btn-md btn-primary" OnClick="updateCropsButton_Click"  UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/>
            <br /><br /><br /><br /><br />
            <h3><asp:Label ID="farmNumberLabel" runat="server" Text=""></asp:Label></h3> 
            <h3><asp:Label ID="farmNameLabel" runat="server" Text=""></asp:Label></h3>
            <h3><asp:Label ID="growerCountryLabel" runat="server" Text=""></asp:Label></h3>
            <br /><br /><br />
       
            <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
            <script src="../bootstrap/js/bootstrap.min.js"></script>
    

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

