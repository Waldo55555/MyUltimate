<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GrowerMarketEntry.aspx.cs" Inherits="The18th.GrowerMarketEntry" %>


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
                 <h1>Growers Market Information</h1>

            <p class="lead">Market Information</p>

             <!--Not Visable-->
            <asp:Label ID="exceptionLabel" runat="server" Text=""></asp:Label>

           <asp:Label ID="growerNumberLabel" runat="server" Visible="false" Text=""></asp:Label>

           <asp:Label ID="growerAccountNumberLabel" runat="server" Visible="false" Text=""></asp:Label>
                           
            </div>
            
            <Center><p>Please enter growers market information.</p></Center>
                        
            <hr />
        
           <p><asp:Label ID="errorLabel" runat="server" ForeColor="Red" Text=""></asp:Label></p>
      

            <div class="form-group">
                <label>Please select your crop type.</label>
                <asp:DropDownList ID="cropTypeDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Crop Type..." Value="Select Crop Type..." Selected="True" Enabled="true" />
                <asp:ListItem Text="Poultry,Fish,Meats" Value="Poultry,Fish,Meats" />
                <asp:ListItem Text="SpicesAndHerbs" Value="SpicesAndHerbs" />
                <asp:ListItem Text="FruitsandVegetables" Value="FruitsandVegetables" />
                </asp:DropDownList><br />
            </div>
                 
           <div class="form-group">
                <label>Please select your storage type.</label>
                <asp:DropDownList ID="storageTypeDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Storage Type..." Value="Select Storage Type..." Selected="True" Enabled="true" />
                <asp:ListItem Text="Silo" Value="Silo" />
                <asp:ListItem Text="Cold Storage" Value="ColdStorage" />
                <asp:ListItem Text="Dry Storage" Value="DryStorage" />
                <asp:ListItem Text="Warehousing" Value="Warehousing" />
                </asp:DropDownList><br />
            </div>



            <div class="form-group">
                <label>Please enter your market hours.</label>
                <asp:DropDownList ID="marketHoursDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Market Hours..." Value="Select Market Hours..." Selected="True" Enabled="true" />
                <asp:ListItem Text="6am-2pm" Value="6am-2pm" />
                <asp:ListItem Text="6am-3pm" Value="6am-3pm" />
                <asp:ListItem Text="6am-4pm" Value="6am-4pm" />
                <asp:ListItem Text="7am-4pm" Value="7am-4pm" />
                <asp:ListItem Text="8am-4pm" Value="8am-4pm" />
                <asp:ListItem Text="8am-5pm" Value="8am-5pm" />
                <asp:ListItem Text="9am-5pm" Value="9am-5pm" />
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label>Please enter the days your farm is open.</label>
                <asp:DropDownList ID="marketDaysDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Market Days..." Value="Select Market Days..." Selected="True" Enabled="true" />
                <asp:ListItem Text="Mon-Fri" Value="Mon-Fri" />
                <asp:ListItem Text="Mon-Sun" Value="Mon-Sun" />
                <asp:ListItem Text="Fri-Sun" Value="Fri-Sun" />
                <asp:ListItem Text="Sat-Sun" Value="Sat-Sun" />
                </asp:DropDownList>
            </div>
 
          <%-- Bar Graph--%>
         
          <div class="form-group">
                <label>Please select your land utilixation.</label>
                <asp:DropDownList ID="utilizationDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Land Utilization..." Value="Select Land Utilization..." Selected="True" Enabled="true" />
                <asp:ListItem Text="10%" Value="10" />
                <asp:ListItem Text="20%" Value="20" />
                <asp:ListItem Text="30%" Value="30" />
                <asp:ListItem Text="40%" Value="40" />
                <asp:ListItem Text="50%" Value="50" />
                <asp:ListItem Text="60%" Value="60" />
                <asp:ListItem Text="70%" Value="70" />
                <asp:ListItem Text="80%" Value="80" />
                <asp:ListItem Text="90%" Value="90" />
                <asp:ListItem Text="100%" Value="100" />
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label>Please enter years farming.</label>
                <asp:DropDownList ID="yearsDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Years Farming..." Value="Select Years Farming..." Selected="True" Enabled="true" />
                <asp:ListItem Text="1-2 years" Value="1-2 years" />
                <asp:ListItem Text="2-5" Value="2-5" />
                <asp:ListItem Text="5-10" Value="5-10" />
                <asp:ListItem Text="10+" Value="10+" />
                </asp:DropDownList>
            </div>
                            
          <%--  <div class="form-group">
                <label>Please enter growers web address</label>
                <asp:TextBox ID="webTextBox" placeholder="Web Address" runat="server" CssClass="form-control"></asp:TextBox><br />
            </div>--%>

                         
            <asp:Button ID="submitButton" runat="server" Text="Submit Information" CssClass="btn btn-md btn-outline-primary" OnClick="submitButton_Click"  UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/><br /><br /><br /><br />
                                                  
            <br /><br />

            <br /><br /><br /> <br /><br /><br /> <br /><br /><br />

            <h3><asp:Label ID="resultLabel" Visible="false" runat="server" Text=""></asp:Label></h3>

           <h3><asp:Label ID="adminResultLabel" Visible="false" runat="server" Text=""></asp:Label></h3>

            <h3><asp:Label ID="farNameLabel" Visible="false" runat="server" Text=""></asp:Label></h3>

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


