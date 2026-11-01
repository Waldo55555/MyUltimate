<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Documents.aspx.cs" Inherits="The18th.Documents" %>


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

                             <li><a href="MemberSearch.aspx">Find A Member</a></li>

                            <li><a href="https://dynamics.microsoft.com">Conference</a></li>

                            <li><a href="/Discussion/Discussion/Discussion">Discussion</a></li>

                            <li><a href="Documents.aspx">Docs</a></li>

                          </ul>
                      </div>
            </div>
        </div>
        <form id="form1" runat="server">

          <div class="container">

           <div class="page-header">

            <br /><br />

              <h1>Documents</h1>

            </div>
                      
            <p class="lead">Share and Retrieve Documents.</p>

            <hr />
               
            <br /><br />
           	
        	<center><h4><em><strong>Documents are beneficial for advancing members knowledge of the platform.</strong></em></h4></center><br /><br />
         
            <center><asp:ImageButton ID="submitImageButton" ImageUrl="https://the18thstorage.blob.core.windows.net/the18thcontainer/submittal.jpg" Height="100px" Width="100px" runat="server" OnClick="submitImageButton_Click" /><br /><asp:Label ID="Label1" runat="server" Text="Submit A Document"></asp:Label></center>
   
             <br /><br /><br />

            <center><asp:ImageButton ID="retrieveImageButton" ImageUrl="https://the18thstorage.blob.core.windows.net/the18thcontainer/retrieval.jpg" Height="100px" Width="100px" runat="server" OnClick="retrieveImageButton_Click" /><br /><asp:Label ID="Label2" runat="server" Text="Retrieve Documents"></asp:Label></center>
   
            <asp:Label ID="resultLabel" runat="server" Text="" Visible="false"></asp:Label>
          
            <br />  

            <%-- <center><asp:Button ID="approvalButton" runat="server" Text="Create My Card" CssClass="btn btn-lg btn-outline-primary" OnClick="approvalButton_Click" /> 
              --%>  

            <%--  <center><asp:Button ID="homeButton" runat="server" Text="Back Home" CssClass="btn btn-lg btn-outline-primary" OnClick="homeButton_Click" /> --%>
                              
             <br /><br /><br />

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