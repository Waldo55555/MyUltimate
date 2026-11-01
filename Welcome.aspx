<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="The18th.Welcome" %>

<%@ OutputCache Duration="3600" VaryByParam="None" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=0"/>
<%--<meta name="viewport" content="width=400, initial-scale=1"/>--%>
<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Avatar Growers</title>
<link rel="shortcut icon" type="image/x-icon" href="https://the18thstorage.blob.core.windows.net/the18thcontainer/favicon.ico" />
<%--The only thing that stays--%>
<link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" /> 
            
<%: Styles.Render("~/bundles/mycss") %>
<%: Styles.Render("~/bundles/layout") %>

</head>
<body>
     <div class="navbar navbar-default navbar-fixed-top"> 
            <div class="container-fluid">
                <a href="#" class="navbar-brand">Avatar Growers(Beta)</a>
                <button class="navbar-toggle" data-toggle="collapse" data-target=".navHeaderCollapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                      <div class="collapse navbar-collapse navHeaderCollapse">
                           <ul class="nav navbar-nav navbar-right">
 
                               <li><a href="Growers/GrowersMarket/AllGrowers"><span class="glyphicon glyphicon-leaf"></span>Growers Market</a></li>

                               <li><a href="/Directory/Professionals/AllProfessionals"><span class="glyphicon glyphicon-search"></span>Professionals</a></li>
                                        
                               <li><a href="/Directory/ServicePartner/AllServices"><span class="glyphicon glyphicon-search"></span>Services</a></li>
                                    
                               <li><a href="/MemberShip/MemberDash/MembershipSignIn"><span class="glyphicon glyphicon-dashboard"></span>Member Sign-In</a></li>

                               <li><a href="Default.aspx"><span class="glyphicon glyphicon-log-out"></span>Log Out</a></li>
            
                          </ul>
                      </div>
            </div>
        </div>
        <form id="form1" runat="server">
                  <asp:ScriptManager ID="ScriptManager1" runat="server">
                  </asp:ScriptManager>
                  <div id="container" class="clear">
                         <div id="hpage_info" class="clear visible-lg">
                               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                  <ContentTemplate>
                                      <asp:Timer ID="Timer1" runat="server" Interval="9500" OnTick="Timer1_Tick"></asp:Timer>
                                      <center><asp:Image ID="Image1" Height="150px" Width="960px" alt="Picture" runat="server" /></center>
                                   </ContentTemplate>
                                </asp:UpdatePanel>
                                <ul>
                                   <li><a href="#"><img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/large2.jpg" alt="Picture" /><strong><em>Tech Services</em></strong></a></li>
                                   <li><a href="#"><img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/large1.jpg" alt="Picture" /><strong><em>Technical Support</em></strong></a></li>
                                   <li><a href="#"><img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/large3.jpg" alt="Picture" /><strong><em>Customer Service</em></strong></a></li>
                                   <li class="last"><a href="#"><img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/large4.jpg" alt="Picture" /><strong><em>Systems Maintenance</em></strong></a></li>
                                </ul>
                         </div>
                   </div>

             <div class="container">
                 <center>
                 <ul>
                     <div class="col-lg-3 col-lg-offset-1 col-md-4 col-sm-10 col-xs-10 col-xs-offset-1">
                        <center><img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/old.jpg" alt="Picture" class="center-block img-responsive" /></center><br />
                        <center><p>Changing The Future</p></center>
                        <center><p>In America there are a little more than 2.6 million black-owned businesses. 2.5 million of these businesses average only 1 employee. Sadly these businesses only generate approximately $50,000 in revenue.</p></center>
                    </div>
                    <div class="col-lg-3 col-lg-offset-1 col-md-4 col-sm-10 col-xs-10 col-xs-offset-1">
                        <center><img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/old3.jpg" alt="Picture" class="center-block img-responsive" /></center><br />
                        <center><p>Changing A Tragedy</p></center>
                        <center><p>In America there are less than 100 HBCU's left. There is less than 100 black-owned newspapers and periodicals. These numbers are shrinking as time goes on.</p></center>
                    </div>
                    <div class="col-lg-3 col-lg-offset-1 col-md-4 col-sm-10 col-xs-10 col-xs-offset-1">
                        <center><img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/old2.jpg" alt="Picture" class="center-block img-responsive" /></center><br />
                        <center><p>Changing The Playbook</p></center>
                        <center><p>Historical collaboration and patronage allowed for African Americans to become self-sufficient. By embracing innovative business practices this is ultimately still our destiny.</p></center>
                     </div>

                    <%--<div class="col-lg-3 col-lg-offset-1 col-md-4 col-sm-10 col-xs-10 col-xs-offset-1">
                        <center><img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/old.jpg" alt="Picture" class="center-block img-responsive" /></center><br />
                        <center><p>Changing The Future</p></center>
                        <center><p>In America there are a little more than 2.6 million black-owned businesses. 2.5 million of these businesses average only 1 employee. Sadly these businesses only generate approximately $50,000 in revenue.</p></center>
                    </div>
                    <div class="col-lg-3 col-lg-offset-1 col-md-4 col-sm-10 col-xs-10 col-xs-offset-1">
                        <center><img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/old3.jpg" alt="Picture" class="center-block img-responsive" /></center><br />
                        <center><p>Changing A Tragedy</p></center>
                        <center><p>In America there are less than 100 HBCU's left. There is less than 100 black-owned newspapers and periodicals. These numbers are shrinking as time goes on.</p></center>
                    </div>
                    <div class="col-lg-3 col-lg-offset-1 col-md-4 col-sm-10 col-xs-10 col-xs-offset-1">
                        <center><img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/old2.jpg" alt="Picture" class="center-block img-responsive" /></center><br />
                        <center><p>Changing The Playbook</p></center>
                        <center><p>Historical collaboration and patronage allowed for African Americans to become self-sufficient. By embracing innovative business practices this is ultimately still our destiny.</p></center>
                     </div>--%>
                </ul>
                 </center>
             </div>
    </form>
    <br /><br /><br /><br /><br />
    <!--Footer-->
    <div class="navbar navbar-default navbar-fixed-bottom">
        <div class="container">
         <br />
            <center><p><a href="Meek/RunUp/RunUpAdmin"><span class="glyphicon glyphicon-cloud"></span>&nbsp;Run Up</a></p></center>
            <%--<center><p>Ad World:&nbsp;&nbsp;<a href="AdvertisementEntry.aspx">Advertise</a>&nbsp;||&nbsp;Donations:&nbsp;&nbsp;<a href="/Donations/Donations/DonateFace">Pledge</a></p></center>--%>
            <center><p>Ad World:&nbsp;&nbsp;<a href="AdCompanyInfo.aspx">Advertise</a>&nbsp;||&nbsp;Donations:&nbsp;&nbsp;<a href="/Donations/Donations/DonateFace">Pledge</a></p></center>
            <center><p><a href="MembershipEntry.aspx">Become A Member</a>&nbsp;||&nbsp;<a href="Meek/MeekHome/AboutUs">About Us</a></p></center>
            <%--<center><p><a href="TrackDonation.aspx">Track My Donations</a>&nbsp;||&nbsp;<a href="Meek/MeekHome/AboutUs">About Us</a></p></center>--%>
            <h3><asp:Label ID="loginLabel" Visible="false" runat="server" Text=""></asp:Label></h3>
            <%-- <center><p class="fl_right">WW:<span><asp:Label ID="userCountLabel" runat="server" Text=""></asp:Label></span></p></center>--%>
        </div>
    </div>
     <%-- For Nav Pill--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <br /><br /><br />

    <%: Scripts.Render("~/bundles/myscripts") %>

</body>
</html>