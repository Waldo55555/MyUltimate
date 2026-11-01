<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CampaignTypeEntry.aspx.cs" Inherits="The18th.CampaignTypeEntry" %>


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

                            <li><a href="/Ads/Ad/AboutAdvertisements">About Advertisements</a></li>

                            <li><a href="https://www.bannersnacks.com" target="_blank">Create A Banner</a></li>
                          </ul>
                      </div>
            </div>
        </div>
        <form id="form1" runat="server">

         <div class="container">

           <div class="page-header">

               <br /><br />

               <asp:ScriptManager ID="ScriptManager1" runat="server">
         
              </asp:ScriptManager>

              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                       <asp:Timer ID="Timer1" runat="server" Interval="9500" OnTick="Timer1_Tick"></asp:Timer>
                       <center><asp:Image ID="Image1" Height="60px" Width="468px" runat="server" /></center>
                    </ContentTemplate>
              </asp:UpdatePanel>

                          
            <h1>Advertisement</h1>
            <p class="lead">"QuickAds"</p>
            </div>
            <Center><h4>Start interacting with your intended customers.</h4></Center>
            <hr />
            <center><asp:Label ID="exceptionLabel" ForeColor="Red" Font-Size="Large" runat="server" Text=""></asp:Label></center>

            <Center><h3><Strong>Campaign Type Selection.</Strong></h3></Center>
          
           
             <div class="form-group">
                <label>Please select your Campaign Type.&nbsp;<input type="image" height="15" width="15" src="https://the18thstorage.blob.core.windows.net/the18thcontainer/infoPic.png" value="Crop LookUp" onclick="window.open('https://avatargrowers.com/KnowledgeDocs/CampaignType.docx', '_blank', 'height=400, width=400, top=400,left=400')" /></label>
                <asp:DropDownList ID="campaignTypeDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Campaign..." Value="Select Campaign..." Selected="True" Enabled="true" />
                <asp:ListItem Text="Light" Value="Light" />
                <asp:ListItem Text="Aggressive" Value="Aggressive" />
                </asp:DropDownList><br />
            </div>

           <div class="form-group">
                <label>Please select your campaigns schedule.&nbsp;<input type="image" height="15" width="15" src="https://the18thstorage.blob.core.windows.net/the18thcontainer/infoPic.png" value="Crop LookUp" onclick="window.open('https://avatargrowers.com/KnowledgeDocs/Schedule.docx', '_blank', 'height=400, width=400, top=400,left=400')" /></label>
                <asp:DropDownList ID="scheduleTypeDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Campaign Schedule..." Value="Select Campaign Schedule..." Selected="True" Enabled="true" />
                <asp:ListItem Text="Daily" Value="Daily" />
                <asp:ListItem Text="Weekly" Value="Weekly" />
                </asp:DropDownList><br />
            </div>
           
         
                                      
            <p><asp:Button ID="submitButton" runat="server" Text="Submit Information" CssClass="btn btn-md btn-primary" OnClick="submitButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/> &nbsp; <a class="btn btn-md btn-primary" href="Welcome.aspx">Return</a></p>

            <br /><br /><br />

            <h3>&nbsp;</h3>

            <asp:Label ID="resultLabel" runat="server" Text="" Visible="false"></asp:Label>

            <p>&nbsp;</p>
  
             <br /><br /><br />
           </div>
         </form>
  
    <!--Footer-->
    <div class="navbar navbar-default navbar-fixed-bottom">
        <div class="container">
           <br />
            <center><p><a href="Meek/RunUp/RunUpAdmin"><span class="glyphicon glyphicon-cloud"></span>&nbsp;Run Up</a></p></center>
            <center><p>Developer On Duty: Meek Technologies - Copyright &copy; 2011-2022 - All Rights Reserved</p></center>
            <center><p>Ad World:&nbsp;&nbsp;<a href="AdCompanyInfo.aspx">Advertise With Us</a>&nbsp;||&nbsp;Donations:&nbsp;&nbsp;<a href="/Donations/Donations/DonateFace">Make A Pledge</a></p></center>
            <center><p><a href="MembershipEntry.aspx">Become A Member</a>&nbsp;||&nbsp;<a href="Meek/MeekHome/AboutUs">About Us</a></p></center>
            <%-- <center><p><a href="TrackDonation.aspx">Track My Donations</a>&nbsp;||&nbsp;<a href="Meek/MeekHome/AboutUs">About Us</a></p></center>--%>
            <%--<center><p>Advertise:&nbsp;&nbsp;<a href="mailto:onefarmads@gmail.com">Advertise With Us</a></p></center>--%>
            <h3><asp:Label ID="loginLabel" Visible="false" runat="server" Text=""></asp:Label></h3>
            <center><p class="fl_right">WW:<span><asp:Label ID="userCountLabel" runat="server" Text=""></asp:Label></span></p></center>
        </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <br /><br /><br />

    <%: Scripts.Render("~/bundles/myscripts") %>

</body>
</html>