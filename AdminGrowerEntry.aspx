<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminGrowerEntry.aspx.cs" Inherits="The18th.AdminGrowerEntry" %>


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
               
                <h1>Admin Grower Entry</h1>

                <p class="lead">Grower Information</p>
                           
                </div>
            
                <Center><p>Please enter the growers information.</p></Center>
                        
                <hr />
        
               <p><asp:Label ID="errorLabel" runat="server" ForeColor="Red" Text=""></asp:Label></p>
         


                   <div class="form-group">
                        <label>Please enter a screen name.</label>
                         <asp:TextBox ID="screenNameTextBox" placeholder="Screen Name" runat="server" CssClass="form-control"></asp:TextBox><br />
                    </div>


                     <div class="form-group">
                       <%-- <label>Please enter your phone.</label>--%>
                         <h3><asp:TextBox ID="phoneTextBox" placeholder="Phone Number" runat="server" CssClass="form-control"></asp:TextBox></h3><br />
                    </div>



                    <div class="form-group">
                        <label>Please enter your personal email.</label>
                         <asp:TextBox ID="emailTextBox" placeholder="youremail@email" runat="server" CssClass="form-control"></asp:TextBox><br />
                   </div>



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

                    <div class="form-group">
                        <label>Please select the growers representative if any.</label>
                        <asp:DropDownList ID="representativeDropDownList" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Select Representative..." Value="Select Representative..." Selected="True" Enabled="true" />
                        <asp:ListItem Text="Represent Self" Value="Represent Self" />
                        <asp:ListItem Text="Elected Representative" Value="Elected Representative" />
                        </asp:DropDownList><br />
                    </div>


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
                                        <asp:ListItem Text="SouthEast U.S" Value="SouthEast U.S" />
                                        <asp:ListItem Text="NorthEast U.S" Value="NorthEast U.S" />
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

                    <hr />
         
                    <div>
                        <asp:Label ID="growerNumberLabel" runat="server" Visible="false" Text=""></asp:Label>
                        <center><h2>What Are You Planting?</h2></center>
                        <center><p>Please present four crops to represent your farmers market.</p></center>
                        <center><p><em><strong>Crop Type Examples:</strong></em>&nbsp;<input type="image" height="20" width="20" src="https://the18thstorage.blob.core.windows.net/the18thcontainer/infoPic.png" value="Crop LookUp" onclick="window.open('https://localhost:44366/FarmersMarket/FarmMarket/CropLookUp', '_blank', 'height=400, width=400, top=400,left=400')" /></p></center>
                         <div style="font-family:Arial">
                            <fieldset style="width:350px">
                            <legend>Crops</legend>
                            <asp:CheckBoxList ID="greensCheckBoxList" runat="server" DataTextField="Crop" DataValueField="CropIndex" RepeatDirection="Horizontal" RepeatColumns="5" BorderStyle="None" RepeatLayout="Table">
                            </asp:CheckBoxList>
                            </fieldset>
                          </div>
                    </div>
                    <br /><br />

                    <p class="lead">Please submit the growers photo if available.</p>

                    <hr />
               
                    <div class="form-group">
                        <label>Please upload your farm photo.</label>
                         <P>please upload a image of 60 x 60</P>
                         <P>acceptable file types: JPG,GIF</P>
                       <asp:FileUpload ID="photoFileUpload" runat="server" CssClass="form-control" /><br />

                    </div>

                    <br />

                    <asp:Button ID="submitButton" runat="server" Text="Submit Grower" CssClass="btn btn-md btn-primary" OnClick="submitButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/>

                    <br /><br />

                    <br /><br /><br /> 
                  
                    <h3><asp:Label ID="adminLabel" runat="server" Text="" Visible="false"></asp:Label></h3>

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

