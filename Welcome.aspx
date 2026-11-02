<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="The18th.Welcome" %>

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
                                     
                              <li><a href="Account/Account/MemberSignUp"><span class="glyphicon glyphicon-log-in"></span>Member Sign-Up</a></li>
                               <%--<li><a href="https://www.fanbase.app/@avatargrowers"><span class="glyphicon glyphicon-log-in"></span>Member Sign-Up</a></li>--%>
                              <li><a href="Account/Account/MembershipSignIn"><span class="glyphicon glyphicon-leaf"></span>Growers Market</a></li>
                               
                          </ul>
                      </div>
            </div>
        </div>
        <form id="form1" runat="server">
                    <div id="container" class="clear">
                         <div id="hpage_info" class="clear visible-lg">
                            
                             <%--  New Start--%>
                               <asp:ScriptManager ID="ScriptManager1" runat="server" />  
                                <asp:UpdatePanel ID="up1" runat="server">  
                                <Triggers>  
                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />  
                                </Triggers>  
                                <ContentTemplate>  
                                <asp:Timer ID="Timer1" Interval="4000" runat="server" />  
                                <asp:AdRotator ID="MyAdRotator" runat="server"  
                                AdvertisementFile="~/MyAdData.xml" Target="_blank" Height="150px" Width="960px" />  
                                </ContentTemplate>  
                                </asp:UpdatePanel>  
                              <%-- New End--%>
                                <ul>
                                   <li><a href="#"><img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/market.jpg" alt="Picture" /><strong><em>Grower Market</em></strong></a></li>
                                   <li><a href="#"><img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/family.jpg" alt="Picture" /><strong><em>Consumers</em></strong></a></li>
                                   <li><a href="#"><img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/large3.jpg" alt="Picture" /><strong><em>Customer Service</em></strong></a></li>
                                   <li class="last"><a href="#"><img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/large4.jpg" alt="Picture" /><strong><em>Systems Maintenance</em></strong></a></li>
                                </ul>
                         </div>
                   </div>

             <div class="container">
                 <center>
                 <ul>
                     <div class="col-lg-3 col-lg-offset-1 col-md-4 col-sm-10 col-xs-10 col-xs-offset-1">
                        <center><img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/1.png" alt="Picture" class="center-block img-responsive" /></center><br />
                        <center><p><strong>Preparing The Future</strong></p></center>
                        <center><p>Protecting against environmental changes. We look to leverage what we can control.</p></center>
                    </div>
                    <div class="col-lg-3 col-lg-offset-1 col-md-4 col-sm-10 col-xs-10 col-xs-offset-1">
                        <center><img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/3.png" alt="Picture" class="center-block img-responsive" /></center><br />
                        <center><p><strong>Control The Environment</strong></p></center>
                        <center><p>Planning and predicting crop yeilds for sustainability.</p></center>
                    </div>
                    <div class="col-lg-3 col-lg-offset-1 col-md-4 col-sm-10 col-xs-10 col-xs-offset-1">
                        <center><img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/2.png" alt="Picture" class="center-block img-responsive" /></center><br />
                        <center><p><strong>Changing The Playbook</strong></p></center>
                        <center><p>Reliable and scalable crop yeild side by side with traditional growing environments.</p></center>
                     </div>
                  </ul>
                 </center>
             </div>
    </form>
    <br /><br /><br /><br /><br />
    <!--Footer-->
    <div class="navbar navbar-default navbar-fixed-bottom">
        <div class="container">
         <br />
           <center><p>AG Newsletter:&nbsp;&nbsp;<a href="https://avatar-growers.com/newsletter/" target="_blank">Suscribe</a>&nbsp;|&nbsp;Contact Us Today!&nbsp;&nbsp;<a href="mailto:the18th_helpdesk@yahoo.com">Information</a></p></center>
            <center><p><a href="Meek/MeekHome/AboutUs">About Us</a></p></center>
            <center><p><a href="TrackDonation.aspx">Track My Support</a>&nbsp;||&nbsp;<a href="Affiliates/Support/SupportFace">Support This Platform</a></p></center>
            <h3><asp:Label ID="loginLabel" Visible="false" runat="server" Text=""></asp:Label></h3>
            <h3><asp:Label ID="sessionLabel" Visible="false" runat="server" Text=""></asp:Label></h3>
         </div>
    </div>
     <%-- For Nav Pill--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <br /><br /><br />

    <%: Scripts.Render("~/bundles/myscripts") %>

</body>
</html>