<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TRManager_new_client_web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        function getProducts() {

            $.ajax({
                url: "http://localhost:8080/trmanager/student?callback=?",
                dataType: 'jsonp',
                success: function (json) {
                    $('#s_body').empty(); // Clear the table body.

                    // Loop through the list of products.
                    $.each(json, function (key, val) {
                        // Add a table row for the product.
                        var r = '<tr><td>' + val.surname + '</td><td>' + val.givenname + '</td></tr>';
                        $('#s_body').append(r);
                    })},
                error: function () {
                    alert("Error");
                }

            });
        }

        $(document).ready(getProducts);
</script>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Students<asp:Button ID="Button1" runat="server" Height="33px" OnClick="Button1_Click" Text="Get Data" Width="155px" />
    </h2>
        <table id="students" style="width:25%;">
            <thead>
                <tr><td>Givenname</td><td>Surname</td></tr>
            </thead>
            <tbody id="s_body">
                <tr><td>test</td><td>test</td></tr>
            </tbody>
        </table>
</asp:Content>