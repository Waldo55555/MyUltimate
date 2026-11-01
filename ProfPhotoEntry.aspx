<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfPhotoEntry.aspx.cs" Inherits="The18th.ProfPhotoEntry" %>


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

                             <li><a href="ProfessionalEntry">Professional Entry</a></li>

                          </ul>
                      </div>
            </div>
        </div>
        <form id="form1" runat="server">

         <div class="container">

           <div class="page-header">

            <br /><br />
               
            <h1>Professional Photo</h1>

            <p class="lead">Professional Photo</p>

            <!--Not Visable-->
            <asp:Label ID="exceptionLabel" runat="server" Text=""></asp:Label>

            <asp:Label ID="profNumberLabel" runat="server" Visible="false" Text=""></asp:Label>
                
            <asp:Label ID="firstNameLabel" runat="server" Visible="false" Text=""></asp:Label>

            <asp:Label ID="lastNameLabel" runat="server" Visible="false" Text=""></asp:Label>

            <asp:Label ID="emailLabel" runat="server" Visible="false" Text=""></asp:Label>

            <asp:Label ID="locationLabel" runat="server" Visible="false" Text=""></asp:Label>

            <asp:Label ID="phoneLabel" runat="server" Visible="false" Text=""></asp:Label>

            <!--Visable-->
            <p>Professional Type:&nbsp;<asp:Label ID="profTypeLabel" ForeColor="Green" runat="server" Text=""></asp:Label></p>
 
           <%-- <p>Vendor Name:&nbsp;<asp:Label ID="vendorNameLabel" ForeColor="Green" runat="server" Text=""></asp:Label></p>
              --%>                           

            </div>
                      
            <p class="lead">Please submit your company photo.</p>

            <hr />
               
            <div class="form-group">
                <label>Please upload a photo.</label>
                 <P>please upload a small image a minimum of 60 x 60</P>
                 <P>acceptable file types: JPG,GIF</P>
               <asp:FileUpload ID="photoFileUpload" runat="server" CssClass="form-control" /><br />

            </div>
   

            <asp:Label ID="resultMessageLabel" runat="server"></asp:Label><br /><br />

            <asp:HyperLink ID="viewHyperLink" runat="server">View Photo</asp:HyperLink><br /><br />


            <br />

            <asp:Button ID="uploadButton" runat="server" Text="Submit Photo" CssClass="btn btn-md btn-primary" OnClick="uploadButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/>

            <br /><br /><br /><br /><br /><br /><br /><br /><br />


             <h3><asp:Label ID="resultLabel" Visible="false" runat="server" Text=""></asp:Label></h3>

             <h3><asp:Label ID="vendorPassLabel" Visible="false" runat="server" Text=""></asp:Label></h3>

             <h3><asp:Label ID="membershipResultLabel" Visible="false" runat="server" Text=""></asp:Label></h3>

             <h3><asp:Label ID="companyNameLabel" Visible="false" runat="server" Text=""></asp:Label></h3>

             <asp:Label ID="existingAccountLabel" Visible="false" runat="server" Text=""></asp:Label>

             <br /><br />
           
                   
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