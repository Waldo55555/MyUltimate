<%@ Page Title="" Language="C#" MasterPageFile="~/Avatar.Master" AutoEventWireup="true" CodeBehind="MemberSearch.aspx.cs" Inherits="The18th.MemberSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
<%--............Added--%>
<script src="jquery-1.11.2.js"></script>
<script src="jquery-ui.js"></script>
<link href="jquery-ui.css" rel="stylesheet" />
<script type="text/javascript">
    $(document).ready(function () {
        $('#memberLoc').autocomplete({
            minLength: 1,
            focus: function (event, ui) {
                $(this).val(ui.item.MemberName);
                return false;
            },
            select: function (event, ui) {
                $(this).val(ui.item.MemberName);
                return false;
            },
            source: function (request, response) {
                $.ajax({
                    url: 'MemberSearchService.asmx/GetMembers',
                    method: 'post',
                    data: { term: request.term },
                    dataType: 'json',
                    success: function (data) {
                        response(data);
                    }
                });
            }
        })
            .autocomplete('instance')._renderItem = function (ul, item) {
                return $('<li>')
                    .append('<img class="imageClass" src=' + item.MemberImage + ' alt=' + item.MemberName + '/>')
                    .append('<a>' + item.MemberName + '</a>')
                    .appendTo(ul);
            }
    });
</script>
 <style>
     .imageClass{
         width:60px;
         height:60px;
         padding-right:3px;
     }
 </style>


        <div class="container">

                <div class="page-header">

                    <br /><br />

                    <h1>Locate A Member</h1>

                    <p class="lead">Current Members</p>
                           
               </div>
            
               <Center><p>Search for a current member.</p></Center>
     
                Member Locator : <input id="memberLoc" type="text" height="40" width="40" size="40"/>

            <br /><br />

         </div>



</asp:Content>
