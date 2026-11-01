<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Donate.aspx.cs" Inherits="The18th.Donate" %>


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

<script src="jquery-1.11.2.js"></script>
<link href="jquery-ui.css" rel="stylesheet" />
<script src="jquery-ui.js"></script>

    <script type="text/javascript" >
        $(document).ready(function () {
            $('#selectMenu').selectmenu();

        });
    </script>

              
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

                             <%-- <li><a href="MemberInfoEntry">Become a Member</a></li>--%>

                            <li><a href="TrackDonation.aspx">Track My Donations</a></li>

                            <li><a href="TrackDonation.aspx">Reclaim My Donations</a></li>

                          </ul>
                      </div>
            </div>
        </div>
        <form id="form1" runat="server">

         <div class="container">

          <script src="Scripts/jquery-3.3.1.min.js"></script>
          <script src="Scripts/bootstrap.min.js"></script>
     
              <br /><br /><br />

              <asp:ScriptManager ID="ScriptManager1" runat="server">
         
              </asp:ScriptManager>

              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                       <asp:Timer ID="Timer1" runat="server" Interval="9500" OnTick="Timer1_Tick"></asp:Timer>
                       <center><asp:Image ID="Image1" Height="60px" Width="468px" runat="server" /></center>
                    </ContentTemplate>
              </asp:UpdatePanel>


            <div class="page-header">

            <br /><br />

            <h1>AG Donations</h1>

            <p class="lead">"Make Worry Free Donations"</p>

            </div>

            <Center><p>Our donation platform is the most transparent platform to date.</p></Center>
         
            <hr />

            <center><asp:Label ID="exceptionLabel" runat="server" Text=""></asp:Label></center>

           <%------------------------------------------%>
            <script type="text/javascript" >

                function setAmount() {

                    //working
                    //document.cookie = "amount=100.00";

                    var cookieString = "amount=" + document.getElementById("donAmount").value;

                    document.cookie = cookieString;

                }

                function getAmount() {

                    if (document.cookie.length != 0) {

                        var nameValueArray = document.cookie.split("=");
                        alert("Name = " + nameValueArray[0] + "Value =" + nameValueArray[1]);

                    }

                    else
                                              

                }

            </script>

            <%-----------------------------------------%>

            <div class="form-group">
                <label>Please enter your first name.</label>
                <asp:TextBox ID="firstNameTextBox" placeholder="First Name" runat="server" CssClass="form-control"></asp:TextBox><br />
            </div>
           
            <div class="form-group">
                <label>Please enter your phone .</label>
                 <asp:TextBox ID="phoneTextBox" placeholder="Phone" runat="server" CssClass="form-control"></asp:TextBox><br />

            </div>
 
           <div class="form-group">
                <label>Please enter your email.</label>
                 <asp:TextBox ID="emailTextBox" placeholder="example@email" runat="server" CssClass="form-control"></asp:TextBox><br />

            </div>

            <div class="form-group">
                <label>Please select your Donation Type.</label>
                <asp:DropDownList ID="donationTypeDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Donation Type..." Value="Select Donation Type..." Selected="True" Enabled="true" />
                <asp:ListItem Text="Administration" Value="Administration" />
                <asp:ListItem Text="Marketing" Value="Marketing" />
                <asp:ListItem Text="InformationTechnology" Value="InformationTechnology" />
                </asp:DropDownList><br />
            </div>
  
            <div class="form-group">
                <label>Please select your Donation Amount.</label>
                <asp:DropDownList ID="donAmountDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Donation Amount..." Value="Select Donation Amount..." Selected="True" Enabled="true" />
                <asp:ListItem Text="$5.00" Value="5.00" />
                <asp:ListItem Text="$10.00" Value="10.00" />
                <asp:ListItem Text="$15.00" Value="15.00" />
                <asp:ListItem Text="$20.00" Value="20.00" />
                <asp:ListItem Text="$25.00" Value="25.00" />
                <asp:ListItem Text="$50.00" Value="50.00" />
                <asp:ListItem Text="$100.00" Value="100.00" />
                </asp:DropDownList><br />
            </div>
  
            <br />

           <p><asp:Button ID="donateButton" runat="server" Text="Make Donation" CssClass="btn btn-md btn-primary" OnClick="donateButton_Click"  UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/>&nbsp; <a class="btn btn-md btn-primary" href="Welcome.aspx">Return</a></p>

            <br /><br /><br /><br /><br /><br /><br /><br /><br />

            <h3>&nbsp;</h3>

           <asp:Label ID="myDonLabel" runat="server" Text="" Visible="false"></asp:Label>

            <p>&nbsp;</p>

         </div>

        <br /><br /><br />

      </form>
  
    <!--Footer-->
    <div class="navbar navbar-default navbar-fixed-bottom">
        <div class="container">
           <br />
            <center><p><a href="Meek/RunUp/RunUpAdmin"><span class="glyphicon glyphicon-cloud"></span>&nbsp;Run Up</a></p></center>
            <center><p>Developer On Duty: Meek Technologies - Copyright &copy; 2011-2022 - All Rights Reserved</p></center>
            <center><p>Ad World:&nbsp;&nbsp;<a href="AdCompanyInfo.aspx">Advertise</a>&nbsp;||&nbsp;Donations:&nbsp;&nbsp;<a href="/Donations/Donations/DonateFace">Pledge</a></p></center>
            <center><p><a href="MembershipEntry.aspx">Become A Member</a>&nbsp;||&nbsp;<a href="Meek/MeekHome/AboutUs">About Us</a></p></center>
            <%-- <center><p><a href="TrackDonation.aspx">Track My Donations</a>&nbsp;||&nbsp;<a href="Meek/MeekHome/AboutUs">About Us</a></p></center>--%>
            <%--<center><p>Advertise:&nbsp;&nbsp;<a href="mailto:onefarmads@gmail.com">Advertise With Us</a></p></center>--%>
            <h3><asp:Label ID="loginLabel" Visible="false" runat="server" Text=""></asp:Label></h3>
           <%-- <center><p class="fl_right">WW:<span><asp:Label ID="userCountLabel" runat="server" Text=""></asp:Label></span></p></center>--%>
        </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <br /><br /><br />

    <%: Scripts.Render("~/bundles/myscripts") %>

</body>
</html>

