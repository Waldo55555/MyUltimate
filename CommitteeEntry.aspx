<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommitteeEntry.aspx.cs" Inherits="The18th.CommitteeEntry" %>


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
    
<script src="/jquery-1.11.2.js"></script>
<script src="jquery-ui.js"></script>
<link href="jquery-ui.css" rel="stylesheet" />
<script type="text/javascript">
    $(document).ready(function () {
        $('#txtStartDate').datepicker({
               
        });

        $('#txtEndDate').datepicker({

        });


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

                              <li><a href="CommitteeEntry">Committee Entry</a></li>

                          </ul>
                      </div>
            </div>
        </div>
        <form id="form1" runat="server">

          <div class="container">

           <div class="page-header">

            <br /><br />

           <h1>Committees</h1>

            <p class="lead">Committee Information</p>
                           
            </div>
            
            <Center><p>Please enter Committee information.</p></Center>
         
            <hr />

            <center><asp:Label ID="exceptionLabel" runat="server" Text=""></asp:Label></center>


             <div class="form-group">
                <label>Please select a committee.</label>
                <asp:DropDownList ID="comDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Committee Type..." Value="Select Committee Type..." Selected="True" Enabled="true" />
                <asp:ListItem Text="Finance" Value="Finance" />
                <asp:ListItem Text="Farming" Value="Farming" />
                <asp:ListItem Text="Steering" Value="Steering" />
                <asp:ListItem Text="Economics" Value="Economics" />
                <asp:ListItem Text="Producer" Value="Producer" />
                <asp:ListItem Text="Tech" Value="Tech" />
                <asp:ListItem Text="Co-Op" Value="Co-Op" />
                <asp:ListItem Text="Vendor" Value="Vendor" />
                </asp:DropDownList><br />
            </div>

            <br />

            <div class="form-group">
                <label>Please select a admin type.</label>
                <asp:DropDownList ID="publicDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Public Admin Type..." Value="Select Public Admin Type..." Selected="True" Enabled="true" />
                <asp:ListItem Text="Statesman" Value="Statesman" />
                <asp:ListItem Text="CPA" Value="CPA" />
                </asp:DropDownList><br />
            </div>

            <br />


            <div class="form-group">
                <label>Please select a alma matter.</label>
                <asp:DropDownList ID="educationDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Alma Matter..." Value="Select Alma Matter..." Selected="True" Enabled="true" />
                <asp:ListItem Text="Morehouse College" Value="Morehouse" />
                <asp:ListItem Text="Tuskegee College" Value="Tuskegee" />
                <asp:ListItem Text="Howard University" Value="Howard" />
                <asp:ListItem Text="Unorthodox" Value="Unorthodox" />
                </asp:DropDownList><br />
            </div>

            <div class="form-group">
                <label>Please enter your first name.</label>
                <asp:TextBox ID="firstNameTextBox" placeholder="First Name" runat="server" CssClass="form-control"></asp:TextBox><br />
                <%-- <small class="text-muted">
                        Please enter your first name.
                 </small>--%>
            </div>
                         
            <br />

            <div class="form-group">
                <label>Please enter your last name.</label>
                <asp:TextBox ID="lastNameTextBox" placeholder="Last Name" runat="server" CssClass="form-control"></asp:TextBox><br />
            </div>

            <br />

             <div class="form-group">
                    <label>Please enter your ScreenName .</label>
                    <asp:TextBox ID="screenNameTextBox" placeholder="Screen Name" runat="server" CssClass="form-control"></asp:TextBox><br />
             </div>

            <div class="form-group">
                <label>Please select a country.</label>
                <asp:DropDownList ID="countryDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Country..." Value="Select Country..." Selected="True" Enabled="true" />
                <asp:ListItem Text="Ghana" Value="Ghana" />
                <asp:ListItem Text="U.S" Value="U.S" />
                </asp:DropDownList><br />
            </div>

            <div class="form-group">
                <label>Please select a Location.</label>
                <asp:DropDownList ID="locationDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Location..." Value="Select Location..." Selected="True" Enabled="true" />
                <asp:ListItem Text="East Africa" Value="East Africa" />
                <asp:ListItem Text="West Africa" Value="West Africa" />
                <asp:ListItem Text="South East U.S" Value="South East U.S" />
                <asp:ListItem Text="North East U.S" Value="North East U.S" />
                </asp:DropDownList><br />
            </div>

            <br />
 
           <div class="form-group">
                <label>Please enter your personal email.</label>
                <asp:TextBox ID="emailTextBox" placeholder="youremail@email" runat="server" CssClass="form-control"></asp:TextBox><br />
           </div>
                   

           <div class="form-group">
                <label>Please enter Committee Start Date.</label>
                <asp:TextBox ID="txtStartDate" placeholder="Start Date" runat="server" CssClass="form-control"></asp:TextBox><br />
           </div>


           <div class="form-group">
                <label>Please enter Commission Expiration.</label>
                <asp:TextBox ID="txtEndDate" placeholder="End Date" runat="server" CssClass="form-control"></asp:TextBox><br />
           </div>


            <asp:Button ID="submitButton" runat="server" Text="Submit Information" CssClass="btn btn-md btn-primary" OnClick="submitButton_Click" UseSubmitBehavior="false" OnClientClick="this.disable= 'true'; this.value= 'Working...';"/>

            <br /><br /><br /><br /><br /><br /><br /><br /><br />

            <h3>&nbsp;</h3>
            
            <p>
                <asp:Label ID="myLabel" runat="server" Visible="false"></asp:Label>
            </p>

            <h3><asp:Label ID="resultLabel" runat="server" Text="" Visible="false"></asp:Label></h3>


            <h3><asp:Label ID="memberNumberLabel" runat="server" Text="" Visible ="false"></asp:Label></h3>

            <p>&nbsp;</p>

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
