<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TribalCRM.aspx.cs" Inherits="The18th.TribalCRM" %>


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
                <a href="#" class="navbar-brand">One Farm(Beta)</a>
                <button class="navbar-toggle" data-toggle="collapse" data-target=".navHeaderCollapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                      <div class="collapse navbar-collapse navHeaderCollapse">
                           <ul class="nav navbar-nav navbar-right">
                                                            
                                 <li><a href="/MemberShip/MemberDash/DashHome"><span class="glyphicon glyphicon-dashboard"></span>Member Dash</a></li>
                          
                                 <li><a href="Default.aspx"><span class="glyphicon glyphicon-log-out"></span>Log Out</a></li>

                          </ul>
                      </div>
            </div>
        </div>
        <form id="form1" runat="server">

            <div class="container">

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
   
                 <center>
                <div>
                    <center><img src="https://the18thstorage.blob.core.windows.net/the18thcontainer/tribalfam.png" alt="Picture" /></center><br />
                    <center><h4>Relationships Done Right!</h4></center>
                </div>

                    <hr />

                    <h4>Tribal is our members only customer relationship program created to empower our members and fuel our own endevours.</h4>

                </center>

            </div>

       </form>

    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />


    <!--Footer-->
    <div class="navbar navbar-default navbar-fixed-bottom">
        <div class="container">
            <br />
           <%-- <center><p>Contact Us Today!&nbsp;&nbsp;|&nbsp;&nbsp;<a href="mailto:the18th_helpdesk@yahoo.com">Member Service</a></p></center>--%>

           <%-- <center><p>Developed By: The18th - Copyright &copy; 2022 - All Rights Reserved</p></center>--%>
                        
            <center><p>Ad World:&nbsp;&nbsp;<a href="AdCompanyInfo.aspx">Advertise With Us</a>&nbsp;||&nbsp;Donations:&nbsp;&nbsp;<a href="/Donations/Donations/DonateFace">Make A Pledge</a></p></center>

           <center><p><a href="TrackDonation.aspx">Track My Donations</a>&nbsp;||&nbsp;<a href="Meek/MeekHome/AboutUs">About Us</a></p></center>

            <center><p>Developer On Duty: Meek Technologies - Copyright &copy; 2011-2022 - All Rights Reserved</p></center>
                       
            <h3><asp:Label ID="loginLabel" Visible="false" runat="server" Text=""></asp:Label></h3>

            <center><p class="fl_right">WW:<span><asp:Label ID="userCountLabel" runat="server" Text=""></asp:Label></span></p></center>
        </div>
    </div>
  <%--  <script src="https://code.jquery.com/jquery-1.12.4.min.js" integrity="sha384-nvAa0+6Qg9clwYCGGPpDQLVpLNn0fRaROjHqs13t4Ggj3Ez50XnGQqc/r8MhnRDZ" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js" integrity="sha384-aJ21OjlMXNL5UyIl/XNwTMqvzeRMZH2w8c5cRVpzpU8Y5bApTppSuUkhZXN0VxHd" crossorigin="anonymous"></script>--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <br /><br /><br />
</body>
</html>
