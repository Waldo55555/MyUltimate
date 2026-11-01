<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Appointment.aspx.cs" Inherits="The18th.Appointment" %>


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
     
            <%--added--%>
            <script src="Scripts/jquery-1.11.2.js"></script>
            <script src="Scripts2/jquery-ui.js"></script>
            <link href="Scripts2/jquery-ui.css" rel="stylesheet" />
            <%--shortversion--%>
            <link href="Scripts3/jquery.timepicker.min.css" rel="stylesheet" />
            <script src="Scripts3/jquery.timepicker.min.js"></script>

            <script type="text/javascript">

                $(document).ready(function () {
                    $('input.timepicker').timepicker({

                    timeFormat: 'h:mm p',
                    interval: 30,
                    minTime: '10',
                    maxTime: '9:00pm',
                    defaultTime: '9',
                    startTime: '10:00',
                    dynamic: false,
                    dropdown: true,
                    scrollbar: true

                    });

                });

            </script>
             <%--added End--%>

            <script src="Scripts/jquery-3.3.1.min.js"></script>
            <script src="Scripts/bootstrap.min.js"></script>
      
            <br /><br /><br />

            <%--  <asp:ScriptManager ID="ScriptManager1" runat="server">
         
                      </asp:ScriptManager>

                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                               <asp:Timer ID="Timer1" runat="server" Interval="9500" OnTick="Timer1_Tick"></asp:Timer>
                               <center><asp:Image ID="Image1" Height="60px" Width="468px" runat="server" /></center>
                            </ContentTemplate>
                      </asp:UpdatePanel>--%>

               <div class="page-header">

                <h1>Appointments</h1>

                <p class="lead">Make an Appointment</p>

               </div>
 
              <%--<h1><Center>Appointments</Center></h1>--%>
	            <p><Center>Please complete the following appointment information.</Center></p>

                <h3><center><asp:Label ID="resultLabel" runat="server" Text="" ForeColor="Green"></asp:Label></center></h3>

	            <h3><center><asp:Label ID="errorLabel" runat="server" Text="" ForeColor="Red"></asp:Label></center></h3>
   
               <%--working on start--%>

               <p>Booking Type:&nbsp;<asp:Label ID="bookTypeLabel" ForeColor="Green" runat="server" Visible="true" Text=""></asp:Label></p>
 
               <p>Client Name:&nbsp;<asp:Label ID="firstNameLabel" ForeColor="Green" runat="server" Visible="true" Text=""></asp:Label></p>
        
               <p>Booking Status:&nbsp;<asp:Label ID="statusLabel" ForeColor="Green" runat="server" Visible="true" Text=""></asp:Label></p>

               <p>Booking:&nbsp;<asp:Label ID="consultLabel" ForeColor="Green" runat="server" Visible="true" Text=""></asp:Label></p>
 
               <p>Client Email:&nbsp;<asp:Label ID="emailLabel" ForeColor="Green" runat="server" Visible="true" Text=""></asp:Label></p>
 
               <%--<p>Booking Fee:&nbsp;<asp:Label ID="feeLabel" ForeColor="Green" runat="server" Visible="false" Text=""></asp:Label></p><br />--%>

         
              <%--working on end--%>


                <center>
               <div class="form-group">
    	            <label>Please select a appointment Time:</label>
                    <asp:Calendar ID="apptCalendar" runat="server" ShowNextPrevMonth="False" TitleFormat="Month" OnSelectionChanged="apptCalendar_SelectionChanged" OnDayRender="apptCalendar_DayRender" ShowGridLines="false"></asp:Calendar>
	            </div>
 
                <center><p><asp:Label ID="apptExceptionLabel" runat="server" ForeColor="Red" Text="" Font-Size="Medium"></asp:Label></p></center><br />


               <%-- <asp:Label ID="dateBookedPrefixLabel" runat="server" Text="Date Booked:" Font-Size="Medium"></asp:Label>--%>


                <center><p><em> <asp:Label ID="dateBookedPrefixLabel" runat="server" Text="Date Booked:" Font-Size="Medium"></asp:Label></em><asp:Label ID="selectedDateLabel" runat="server" ForeColor="Green" Text="" Font-Size="Medium"></asp:Label></p></center><br />

                </center>

                 <%--<center>Book Time:<input type="text" name="myTime" id="myTime" class="timepicker"></center>--%>
              
                 <%--<center><asp:TextBox ID="timeTextBox" runat="server" class="timepicker"></asp:TextBox></center>--%> <%--CssClass="form-control"--%>

                <hr />

                <%--Appointment Area end--%>


                <center><asp:Button ID="apptButton" runat="server" Text="Book Appointment" CssClass="btn btn-md btn-primary" OnClick="apptButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/></center>

                <br />

                <p>WW:<span><asp:Label ID="userCountLabel" runat="server" Text=""></asp:Label></span></p><br />

                <br /><br /><br /><br />
    
                &nbsp;<p>&nbsp;</p>
	            <p>
		            <asp:TextBox ID="apptStatusTextBox" runat="server" Visible="False"></asp:TextBox>
	            </p>
  
                <asp:Label ID="memberNumberLabel" runat="server" Text="" Visible="false"></asp:Label>

                <asp:Label ID="myApptLabel" runat="server" Text="" Visible="false"></asp:Label>
  
                 <p>
		            <asp:TextBox ID="passTextBox" runat="server" Visible="False"></asp:TextBox>
	            </p>
     	
                <asp:Label ID="professionalNumberLabel" runat="server" Text="" Visible="false"></asp:Label>

                <asp:Label ID="bookingNumberLabel" runat="server" Text="" Visible="false"></asp:Label>
        
                <asp:Label ID="timeLabel" runat="server" Text="" Visible="false"></asp:Label>
            
                <asp:Label ID="dateLabel" runat="server" Text="" Visible="false"></asp:Label>

                <p>&nbsp;</p>
	
                <script src="Scripts/jquery-3.6.0.min.js"></script>
                <script src="Scripts/jquery.validate.min.js"></script>
                <script src="Scripts/jquery.validate.unobtrusive.min.js"></script>

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


