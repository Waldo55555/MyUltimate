<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GrowerLocationEntry.aspx.cs" Inherits="The18th.GrowerLocationEntry" %>


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
                <h1>Grower Location Entry</h1>

            <p class="lead">Location Information</p>
                           
            </div>
            
            <Center><p>Please enter the growers location information.</p></Center>
                        
            <hr />
        
           <p><asp:Label ID="errorLabel" runat="server" ForeColor="Red" Text=""></asp:Label></p>

           <asp:Label ID="growerNumberLabel" runat="server" Visible="false" Text=""></asp:Label>

           <asp:Label ID="growerNameLabel" runat="server" Visible="false" Text=""></asp:Label>

           <asp:Label ID="growerTypeLabel" runat="server" Visible="false" Text=""></asp:Label>

           <asp:Label ID="growerAccountNumberLabel" runat="server" Visible="false" Text=""></asp:Label>

 
          <div class="form-group">
                <label>Please select the growers location.</label>
                <asp:DropDownList ID="locationDropDownList" runat="server" CssClass="form-control" OnSelectedIndexChanged="locationDropDownList_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="Select Grower Location..." Value="Select Grower Location..." Selected="True" Enabled="true" />
                <asp:ListItem Text="U.S" Value="U.S" />
                <asp:ListItem Text="Ghana" Value="Ghana" />
                </asp:DropDownList><br />
            </div>


          <div class="table-responsive">
            <table ID="ghanaTable" class="table table-hover table-condensed table-responsive" CellPadding="0" CellSpacing="0" runat="server">
                 <tr>
                    <th>
                      <strong>&nbsp;</strong>
                    </th>
                    <th>
                        <strong><label ID="ghanaCountryLabel" runat="server">Ghana</label></strong>
                    </th>
                    <th></th>
                </tr>
                <tr>
                    <td CellPadding="0" CellSpacing="0" border="0">
                         <img ID="myGhanaImage" src="https://the18thstorage.blob.core.windows.net/the18thcontainer/ghana.jpg" height="60" width="60" alt="oops!" runat="server" />
                    </td>
                    <td>
                        <label ID="streetLabel" runat="server">Please enter street name.</label>
                        <asp:TextBox ID="streetNameTextBox" placeholder="Street Name" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                     <td>
                        <label ID="regionLabel" runat="server">Please select region.</label>
                          <div class="form-group">
                            <asp:DropDownList ID="regionDropDownList" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Select Region..." Value="Select Region..." Selected="True" Enabled="true" />
                            <asp:ListItem Text="Greater Accra" Value="Greater Accra" />
                            </asp:DropDownList><br />
                           </div>

                     </td>
                    <td>
                         <label ID="districtLabel" runat="server">Please enter district.</label>
                          <div class="form-group">
                            <asp:DropDownList ID="districtDropDownList" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Select District..." Value="Select District..." Selected="True" Enabled="true" />
                            <asp:ListItem Text="Okaikwei North" Value="Okaikwei North" />
                            </asp:DropDownList><br />
                           </div>
                    </td>
                     <td>
                          <label ID="areaLabel" runat="server">Please enter area.</label>
                            <asp:DropDownList ID="areaDropDownList" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Select Area..." Value="Select Area..." Selected="True" Enabled="true" />
                            <asp:ListItem Text="Tse Addo" Value="TseAddo" />
                            <asp:ListItem Text="Amasaman" Value="Amasaman" />
                            <asp:ListItem Text="Pokuase" Value="Pokuase" />
                            <asp:ListItem Text="Ofankor" Value="Ofankor" />
                            <asp:ListItem Text="Circle" Value="Circle" />
                            <asp:ListItem Text="Kaneshie" Value="Kaneshie" />
                            <asp:ListItem Text="Kasoa" Value="Kasoa" />
                            <asp:ListItem Text="Industrial Area" Value="Industrial Area" />
                            <asp:ListItem Text="Dzorwulu" Value="Dzorwulu" />
                            <asp:ListItem Text="Legon" Value="Legon" />
                            </asp:DropDownList><br />
                    </td>
                     <td>
                         <label ID="postalLabel" runat="server">Please enter postal code.</label>
                         <asp:TextBox ID="postalTextBox" placeholder="Postal Code" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>

             </table>
         </div>

         <%-----------------------------------------------------------------------------------%>

         <div class="table-responsive">
            <table ID="usTable" class="table table-hover table-condensed table-responsive" CellPadding="0" CellSpacing="0" runat="server">
                 <tr>
                    <th>
                      <strong>&nbsp;</strong>
                    </th>
                    <th>
                        <strong><label ID="usCountryLabel" runat="server">United States</label></strong>
                    </th>
                    <th></th>
                </tr>
                <tr>
                    <td CellPadding="0" CellSpacing="0" border="0">
                         <img ID="myUsImage" src="https://the18thstorage.blob.core.windows.net/the18thcontainer/us.png" height="60" width="60" alt="oops!" runat="server" />
                    </td>
                    <td>
                        <label ID="addressLabel" runat="server">Please enter the growers address.</label>
                        <asp:TextBox ID="addressTextBox" placeholder="Address" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                     <td>
                        <label ID="countyLabel" runat="server">Please select the growers region.</label>
                         <div class="form-group">
                            <asp:DropDownList ID="countyDropDownList" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Select County..." Value="Select County..." Selected="True" Enabled="true" />
                            <asp:ListItem Text="South East U.S" Value="South East U.S" />
                            <asp:ListItem Text="North East U.S" Value="North East U.S" />
                            </asp:DropDownList><br />
                         </div>

                     </td>
                     <td>
                         <label ID="zipLabel" runat="server">Please enter the growers zip code.</label>
                         <asp:TextBox ID="zipTextBox" placeholder="Zip Code" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>

             </table>
         </div>

         <%--//////////////////////////////////////////////////////////////////////////--%>
                     
            <asp:Button ID="submitButton" runat="server" Text="Next" CssClass="btn btn-md btn-outline-primary" OnClick="submitButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/>

            <br /><br />

            <br /><br /><br /> <br /><br /><br /> <br /><br /><br />
                  
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

