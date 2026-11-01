<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GrowerProfileEntry.aspx.cs" Inherits="The18th.GrowerProfileEntry" %>


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

                            <%-- <li><a href="VendorCenter.aspx">Enter Vendors</a></li>--%>


                          </ul>
                      </div>
            </div>
        </div>
        <form id="form1" runat="server">

         <div class="container">

           <div class="page-header">

               <br /><br />
                <br /><br />

            <h1>Grower Profile Entry</h1>

            <p class="lead">Profile Information</p>
                           
            </div>
            
            <Center><p>Please enter the growers information.</p></Center>
                        
            <hr />
        
           <p><asp:Label ID="errorLabel" runat="server" ForeColor="Red" Text=""></asp:Label></p>
         

           <div class="form-group">
                <label>Please select the grower type.</label>
                <asp:DropDownList ID="farmTypeDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Grower Type..." Value="Select Grower Type..." Selected="True" Enabled="true" />
                <asp:ListItem Text="Back Yard Garden" Value="BackYardGarden" />
                <asp:ListItem Text="Neighborhood Garden" Value="NeighborhoodGarden" />
                <asp:ListItem Text="Homestead(1-5 Acres)" Value="Homestead" />
                <asp:ListItem Text="Small Farm(5-10 Acres)" Value="SmallFarm" />
                <asp:ListItem Text="Large Farm(10+ Acres)" Value="LargeFarm" />
                <asp:ListItem Text="Controlled Environment" Value="ControlledEnvironment" />
                </asp:DropDownList><br />
            </div>

        <%--    <div class="form-group">
                <label>Please enter the grower name.</label>
                 <asp:TextBox ID="farmNameTextBox" placeholder="Grower Name" runat="server" CssClass="form-control"></asp:TextBox><br />
            </div>--%>

           <%-- <div class="form-group">
                <h4><asp:Label ID="phoneErrorLabel" ForeColor="#ff0000" Font-Italic Font-Bold="true" runat="server" Text=""></asp:Label></h4>
                <label>Please enter the growers phone number.</label>
                <asp:TextBox ID="phoneTextBox" placeholder="Phone" runat="server" CssClass="form-control"></asp:TextBox><br />
            </div>--%>

           <%-- <div class="form-group">
                <label>Please enter the growers email.</label>
                 <asp:TextBox ID="emailTextBox" placeholder="Email" runat="server" CssClass="form-control"></asp:TextBox><br />
            </div>--%>

           <%-- <div class="form-group">
                <label>Please enter the growers representative if any.</label>
                 <asp:TextBox ID="representativeTextBox" placeholder="Representative" runat="server" CssClass="form-control"></asp:TextBox><br />
            </div>--%>


            <div class="form-group">
                <label>Please select the growers representative if any.</label>
                <asp:DropDownList ID="representativeDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Representative..." Value="Select Representative..." Selected="True" Enabled="true" />
                <asp:ListItem Text="Represent Self" Value="Represent Self" />
                <asp:ListItem Text="Elected Representative" Value="Elected Representative" />
                </asp:DropDownList><br />
            </div>


            <asp:Button ID="submitButton" runat="server" Text="Next" CssClass="btn btn-md btn-outline-primary" OnClick="submitButton_Click" />

            <br /><br />

            <br /><br /><br /> <br /><br /><br /> <br /><br /><br />
                  
            <h3><asp:Label ID="resultLabel" runat="server" Text=""></asp:Label></h3>

            <p>&nbsp;</p>
            <p>&nbsp;</p>


             <br /><br /><br />

          </div>

       </form>
  
    <!--Footer-->
    <div class="container">

            <br />

            <center><p>Contact Us Today!&nbsp;&nbsp;|&nbsp;&nbsp;<a href="mailto:the18th_helpdesk@yahoo.com">Member Service</a></p></center>

            <center><p>Developed By: Meek Tech - Copyright &copy; 2023 - All Rights Reserved</p></center>

    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <br /><br /><br />

    <%: Scripts.Render("~/bundles/myscripts") %>

</body>
</html>

