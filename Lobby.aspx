<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lobby.aspx.cs" Inherits="The18th.Lobby" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=0"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>One Farm</title>
<link rel="shortcut icon" type="image/x-icon" href="../favicon.ico" />
<link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" /> 
<link rel="stylesheet" href="../layout/styles/layout.css" type="text/css" />
<script type="text/javascript" src="../layout/scripts/jquery.min.js"></script>
<script type="text/javascript" src="../layout/scripts/jquery.ui.min.js"></script>
</head>
<body>
     <div class="navbar navbar-default navbar-fixed-top"> 
            <div class="container-fluid">
                <a href="Lobby.aspx" class="navbar-brand">One Farm(Beta)</a>
                <button class="navbar-toggle" data-toggle="collapse" data-target=".navHeaderCollapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                      <div class="collapse navbar-collapse navHeaderCollapse">
                           <ul class="nav navbar-nav navbar-right">
                          
                               <li><a href="Cooperatives/CooP/AvatarAg"><span class="glyphicon glyphicon-leaf"></span>Avatar Agriculture</a></li>

                               <li><a href="/MemberShip/MemberDash/DashHome"><span class="glyphicon glyphicon-dashboard"></span>My Dash</a></li>                             
                                
                                <%--Approval Start--%>

                                 <%--<li><a href="/Committee/Committee/Approvals">Approvals</a></li>

                                 <li><a href="/Committee/Committee/Votes">Votes</a></li>

                                 <li><a href="/Committee/Committee/SuggestedApprovals">Suggestions</a></li>

                                 <li><a href="/Committee/Committee/Committees">Committees</a></li>--%>

                                  <%--@*<li><a href="/Cooperatives/CooP/ChartFarmInventory">Analysis</a></li>
                                    <li><a href="/Cooperatives/CooP/Statistics">Statistics</a></li>
                                    <li><a href="/Cooperatives/CooP/Trends">Trends</a></li>
                                    <li><a href="/Cooperatives/CooP/Resources">Resources</a></li>
                                    <li><a href="/Cooperatives/CooP/News">News</a></li>*@--%>
                                      
                                 <%-- Approval End--%>

                                 <%-- Vendor Start--%>
                                 <%--  <li><a href="/MarketPlace/Market/AllVendors">Vendors Listing</a></li>
 
                                    <li><a href="/MarketPlace/Market/ProductGroup">Vendors Inventory</a></li>--%>

                                 <%-- Vendor End--%>

                                 <%-- Co-Op Start--%>
                                 <%--<li><a href="/Cooperatives/CooP/Cooperatives">Co-Ops</a></li>

                                 <li><a href="/Cooperatives/CooP/Boards">Boards</a></li>
                                       
                                 <li><a href="/MemberShip/Member/StakeHolderProjects">Projects</a></li>--%>
                                <%-- Co-Op End--%>

                                <%-- Consumer Start--%>
                                <%-- <li><a href="/MarketPlace/Market/MyMarketPlace">Market Place</a></li>--%>

                                <%-- @*<li><a href="/TribalCRM/Tribal/CRMFace">CRM Face</a></li>
                                <li><a href="/FarmersMarket/FarmMarket/AllFarms">Farmers Market</a></li>
                                Seems to be a double to Farmers Market
                                <li><a href="/FarmersMarket/FarmMarket/MyFarmMarketPlace">My Farm MarketPlace</a></li>
                                <li><a href="/MemberShip/MemberDash/Track">Track</a></li>*@--%>

                                <%-- Consumer End--%>


                               <%-- Farming Lobby start--%>
                                  <%--<li><a href="/Farming/Farming/AllFarms">All Farms</a></li>

                                <li><a href="/Farming/Farming/FarmAccounts">Farm Account</a></li>

                                <li><a href="/Farming/Farming/FarmDesignations">Farm Designations</a></li>

                                <li><a href="/Farming/Farming/FarmAssistances">Farm Assistances</a></li>

                                <li><a href="/FarmersMarket/FarmMarket/MyFarmMarketPlace">Farmers Market</a></li>--%>

                                <%-- @*<li><a href="/FarmersMarket/FarmMarket/FarmMarketDash">Farm Market Dash</a></li>*@--%>
 
                                <%--  @*You get here through all farms*@--%>
                                <%-- @*<li><a href="/Farming/Farming/FarmPage">Farm Page</a></li>*@--%>
 
                                <%--  @*Not Needed*@
                                @*<li><a href="/Farming/FarmDash/FarmDashHome">Farm Dash</a></li>*@--%>

                                <%--  @*Leave this until necessary*@
                                @*<li><a href="/SupplyChain/Chain/Logistics">Logistics</a></li>
                                <li><a href="/SupplyChain/Chain/Procurements">Procurements</a></li>
                                <li><a href="/SupplyChain/Chain/Sourcings">Sourcings</a></li>
                                <li><a href="/SupplyChain/Chain/SupplyChains">Supply Chain</a></li>*@--%>

                                <%-- Farming Lobby End--%>

                                <%--Member Lobby Start--%>
                               <%-- <li><a href="/MemberShip/Member/MemberProjectAccounts">Member Project Accounts</a></li>

                                <li><a href="/MemberShip/Member/MemberProjects">Member Projects</a></li>--%>
                               <%--Member Lobby End--%>

                          </ul>
                      </div>
            </div>
        </div>
        <form id="form1" runat="server">
                  <asp:ScriptManager ID="ScriptManager1" runat="server">
                  </asp:ScriptManager>
                  <div id="container" class="clear">
                         <div id="hpage_info" class="clear visible-lg">
                              <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                  <ContentTemplate>
                                      <asp:Timer ID="Timer1" runat="server" Interval="9500" OnTick="Timer1_Tick"></asp:Timer>
                                      <center><asp:Image ID="Image1" Height="150px" Width="960px" alt="Picture" runat="server" /></center>
                                   </ContentTemplate>
                                </asp:UpdatePanel>--%>
                               <%-- <ul>
                                   <li><a href="#"><img src="/Images/large2.jpg" alt="Picture" /><strong><em>Bruce Farms</em></strong></a></li>
                                   <li><a href="#"><img src="/Images/large1.jpg" alt="Picture" /><strong><em>Kuntry Kitchen</em></strong></a></li>
                                   <li><a href="#"><img src="/Images/large3.jpg" alt="Picture" /><strong><em>Back Land</em></strong></a></li>
                                   <li class="last"><a href="#"><img src="/Images/large4.jpg" alt="Picture" /><strong><em>Delicatsy</em></strong></a></li>
                                </ul>--%>
                         </div>
                   </div>
   
                <center><h2><strong><em>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Family of Products</em></strong></h2></center>
                            
                <div class="container">
                    <div class="row">
                        <div class="cell col-xs-2 col-xs-offset-6"><asp:ImageButton ID="oneFarmImageButton" runat="server" ImageUrl="~/Images/onefarmfam.png" OnClick="oneFarmImageButton_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OneFarm&nbsp;</div>
                    </div>
                    <br /><br /><br /><br />
                    <div class="row">
                        <div class="cell col-xs-2 col-xs-offset-3"><asp:ImageButton ID="oneStateImageButton" runat="server" ImageUrl="~/Images/onestatefam.png" OnClick="oneStateImageButton_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OneState<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Payments&nbsp;</div>&nbsp;<div class="cell col-xs-2 col-xs-offset-4"><asp:ImageButton ID="onyxImageButton" runat="server" ImageUrl="~/Images/directfam.png" OnClick="onyxImageButton_Click"/>&nbsp;&nbsp;OnyxDirectory&nbsp;</div>
                    </div>
                    <br /><br /><br />
                    <div class="row">
                        <div class="cell col-xs-2 col-xs-offset-6"><asp:ImageButton ID="tribalImageButton" runat="server" ImageUrl="~/Images/tribalfam.png" OnClick="tribalImageButton_Click"/>&nbsp;&nbsp;&nbsp;TribalCRM&nbsp;</div>
                    </div>
                </div>
       </form>

    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />

    <!--Footer-->
    <div class="navbar navbar-default navbar-fixed-bottom">
        <div class="container">
            <br />
         
            <center><p>Developer On Duty: Meek Technologies - Copyright &copy; 2011-2022 - All Rights Reserved</p></center>
                        
            <%--<center><p><a href="/Account/Account/AdminLogIn"><span class="glyphicon glyphicon-cloud"></span>&nbsp;Run Up</a></p></center>--%>
 
            <h3><asp:Label ID="loginLabel" Visible="false" runat="server" Text=""></asp:Label></h3>
                      
        </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <br /><br /><br />
</body>
</html>