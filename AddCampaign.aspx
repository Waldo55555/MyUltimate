<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCampaign.aspx.cs" Inherits="The18th.AddCampaign" %>


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

                            <li><a href="/Ads/Ad/AboutAdvertisements">About Advertisements</a></li>

                            <li><a href="https://www.bannersnacks.com" target="_blank">Create A Banner</a></li>
                          </ul>
                      </div>
            </div>
        </div>
        <form id="form1" runat="server">

          <div class="container">

           <div class="page-header">

             <h1>Add Campaign</h1>

            <p class="lead">Add The Clients Campaign</p>
             </div>
            <p class="lead">Please review the banner for this advertisement.</p>

            <hr />

           <p>Company Name:&nbsp;<asp:Label ID="companyLabel" ForeColor="Green" runat="server" Visible="true" Text=""></asp:Label></p>
 
           <p>Client Phone:&nbsp;<asp:Label ID="phoneLabel" ForeColor="Green" runat="server" Visible="true" Text=""></asp:Label></p>
        
           <p>Client Email:&nbsp;<asp:Label ID="emailLabel" ForeColor="Green" runat="server" Visible="true" Text=""></asp:Label></p>
           
            <p style="color:red">Inspect photo to ensure that there are no blemishes or that the banner does not appear stretched.</p>

            <p style="color:red">Please make sure that the banner meets the required specification of 100px height and 960px width.</p>

             <asp:Image ID="vendorImage" ImageUrl="https://the18thstorage.blob.core.windows.net/the18thcontainer/banner.jpg" Height="100px" Width="960px" runat="server" />
      
            <asp:Label ID="resultMessageLabel" Visible="true" runat="server"></asp:Label><br />
                 
            <br />

            <center><asp:Label ID="exceptionLabel" runat="server" Text=""></asp:Label></center>


          <div class="form-group">
                <label>Please select placement.&nbsp;<input type="image" height="15" width="15" src="https://the18thstorage.blob.core.windows.net/the18thcontainer/infoPic.png" value="Crop LookUp" onclick="window.open('http://localhost:49756/KnowledgeDocs/Location.docx', '_blank', 'height=400, width=400, top=400,left=400')" /></label>
                <asp:DropDownList ID="placementDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Placement Location..." Value="Select Placement Location..." Selected="True" Enabled="true" />
                <asp:ListItem Text="Welcome Page" Value="WelcomePage" />
                <asp:ListItem Text="Advertisements" Value="Advertisements" />
                <asp:ListItem Text="Booking" Value="Booking" />
                <asp:ListItem Text="Donation" Value="Donation" />
                <asp:ListItem Text="Growers" Value="Growers" />
                <asp:ListItem Text="Membership" Value="Membership" />
                <asp:ListItem Text="Professionals" Value="Professionals" />
                <asp:ListItem Text="Documents" Value="Documents" />
                <asp:ListItem Text="Orders" Value="Orders" />
                <asp:ListItem Text="Committee" Value="Committee" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="placementRequiredFieldValidator" ControlToValidate="placementDropDownList" InitialValue="Select Placement Location..." ForeColor="Red" runat="server" ErrorMessage="Please Complete Placement!">
                </asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label>Please select adType.&nbsp;<input type="image" height="15" width="15" src="https://the18thstorage.blob.core.windows.net/the18thcontainer/infoPic.png" value="Crop LookUp" onclick="window.open('http://localhost:49756/KnowledgeDocs/Location.docx', '_blank', 'height=400, width=400, top=400,left=400')" /></label>
                <asp:DropDownList ID="adTypeDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select AdType..." Value="Select AdType..." Selected="True" Enabled="true" />
                <asp:ListItem Text="Basic Advertising" Value="Basic" />
                <asp:ListItem Text="Medium Advertising" Value="Medium" />
                <asp:ListItem Text="Premium Advertising" Value="Premium" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="adTypeRequiredFieldValidator" ControlToValidate="adTypeDropDownList" InitialValue="Select AdType..." ForeColor="Red" runat="server" ErrorMessage="Please Complete AdType!">
                </asp:RequiredFieldValidator>
            </div>

           <div class="form-group">
                <label>Please select adRate.&nbsp;<input type="image" height="15" width="15" src="https://the18thstorage.blob.core.windows.net/the18thcontainer/infoPic.png" value="Crop LookUp" onclick="window.open('http://localhost:49756/KnowledgeDocs/Location.docx', '_blank', 'height=400, width=400, top=400,left=400')" /></label>
                <asp:DropDownList ID="adRateDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select AdRate..." Value="Select AdRate..." Selected="True" Enabled="true" />
                <asp:ListItem Text="1.0" Value="1.0" />
                <asp:ListItem Text="2.0" Value="2.0" />
                <asp:ListItem Text="3.0" Value="3.0" />
                <asp:ListItem Text="4.0" Value="4.0" />
                <asp:ListItem Text="5.0" Value="5.0" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="adRateRequiredFieldValidator" ControlToValidate="adRateDropDownList" InitialValue="Select AdRate..." ForeColor="Red" runat="server" ErrorMessage="Please Complete AdRate!">
                </asp:RequiredFieldValidator>
            </div>

         
           <div class="form-group">
                <label>Please select slot.&nbsp;<input type="image" height="15" width="15" src="https://the18thstorage.blob.core.windows.net/the18thcontainer/infoPic.png" value="Crop LookUp" onclick="window.open('http://localhost:49756/KnowledgeDocs/Location.docx', '_blank', 'height=400, width=400, top=400,left=400')" /></label>
                <asp:DropDownList ID="slotDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Slot..." Value="Select Slot..." Selected="True" Enabled="true" />
                <asp:ListItem Text="12am" Value="12am" />
                <asp:ListItem Text="12noon" Value="12noon" />
                <asp:ListItem Text="11pm" Value="11pm" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="slotRequiredFieldValidator" ControlToValidate="slotDropDownList" InitialValue="Select Slot..." ForeColor="Red" runat="server" ErrorMessage="Please Complete Slot!">
                </asp:RequiredFieldValidator>
            </div>

          <div class="form-group">
                <label>Please select status.&nbsp;<input type="image" height="15" width="15" src="https://the18thstorage.blob.core.windows.net/the18thcontainer/infoPic.png" value="Crop LookUp" onclick="window.open('http://localhost:49756/KnowledgeDocs/Location.docx', '_blank', 'height=400, width=400, top=400,left=400')" /></label>
                <asp:DropDownList ID="statusDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select AdStatus..." Value="Select AdStatus..." Selected="True" Enabled="true" />
                <asp:ListItem Text="Active" Value="Active" />
                <asp:ListItem Text="Need New Banner" Value="NeedNewBanner" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="statusRequiredFieldValidator" ControlToValidate="statusDropDownList" InitialValue="Select AdStatus..." ForeColor="Red" runat="server" ErrorMessage="Please Complete AdStatus!">
                </asp:RequiredFieldValidator>
            </div>

            <h4>This will be banner photo used for this advertisement.</h4>
            <asp:Button ID="startCampaignButton" runat="server" Text="Start Campaign" CssClass="btn btn-md btn-primary" OnClick="startCampaignButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/>

            <br /><br /><br />
                  
            <br /><br />

            <h3><asp:Label ID="resultLabel" Visible="false" runat="server" Text=""></asp:Label></h3>

            <h3><asp:Label ID="simplePhotoLabel" Visible="false" runat="server" Text=""></asp:Label></h3>

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
