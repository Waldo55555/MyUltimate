<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="The18th.Booking1" %>


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

                            <li><a href="Directory/Professionals/AllProfessionalsPaged">All Professionals</a></li>

                           <li><a href="Directory/Professionals/ProfessionalSearch">Professional Search</a></li>


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

           <h1>Bookings</h1>

           <p class="lead">Book an Appointment</p>

	        <%--<h1><Center>Bookings</Center></h1>--%>
	        <p><Center>Please complete the following booking information.</Center></p>
            </div>
   
            <center><p><asp:Label ID="bookExceptionLabel" runat="server" ForeColor="Red" Text="" Font-Size="Medium"></asp:Label></p></center><br />
 
            <Center><h3><Strong>Booking Type Selection.</Strong></h3></Center>

            <p>Please select your accommodations.</p>

            <div class="radio"><label><asp:RadioButton ID="consultationRadioButton" runat="server" GroupName="BookTypeName"/>Consultation(Zoom,In-Person)</label></div>

            <div class="radio"><label><asp:RadioButton ID="estimateRadioButton" runat="server" GroupName="BookTypeName"/>Estimate</label></div>
       
            <br />
         
            <hr />
                 
	        <div class="form-group">
	        <label>Please enter a your first name:</label>
	        <asp:TextBox ID="firstNameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
	        <label>Please enter a your last name:</label>
	        <asp:TextBox ID="lastNameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
	        <label>Please enter your phone number:</label>
	        <asp:TextBox ID="phoneNumberTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="phoneErrorLabel" runat="server" ForeColor="Red" Text="" Font-Size="Medium"></asp:Label><br />
            </div>
  
	        <div class="form-group">
	        <label>Please enter a contact person email:</label>
	        <asp:TextBox ID="emailTextBox" runat="server" CssClass="form-control"></asp:TextBox>
           <%-- <asp:RegularExpressionValidator ID="EmailValidator" runat="server"
            ErrorMessage="Please Use A Valid Email"
            ForeColor="Red"
            ControlToValidate="emailTextBox" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">s
            </asp:RegularExpressionValidator>--%>
            </div>
    
            <p><asp:Button ID="bookButton" runat="server" Text="Book Appointment" CssClass="btn btn-md btn-primary" OnClick="bookButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/> &nbsp; <a class="btn btn-md btn-primary" href="Welcome.aspx">Return</a></p>

            <br />

            <p>WW:<span><asp:Label ID="userCountLabel" runat="server" Text=""></asp:Label></span></p><br />

            <br /><br /><br /><br />
    
            &nbsp;<p>&nbsp;</p>
	        <p>
		        <asp:TextBox ID="bookingStatusTextBox" runat="server" Visible="False"></asp:TextBox>
	        </p>
  
            <asp:Label ID="memberNumberLabel" runat="server" Text="" Visible="false"></asp:Label>

            <asp:Label ID="myBookingLabel" runat="server" Text="" Visible="false"></asp:Label>
  
            <asp:Label ID="professionalNumberLabel" runat="server" Text="" Visible="false"></asp:Label>

            <p>&nbsp;</p>
			
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


