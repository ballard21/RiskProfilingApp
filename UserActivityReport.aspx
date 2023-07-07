<%@ Page Title="" Language="C#" MasterPageFile="~/Risk.Master" AutoEventWireup="true" CodeBehind="UserActivityReport.aspx.cs" Inherits="RiskProfilingApp.UserActivityReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="container">
        
        <div class="row">
            <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="12pt"
                ForeColor="Red" Text="." CssClass="text-center"></asp:Label>
        </div>
        <div class="row ">
            <div class="col-lg-12">
                <ol class="breadcrumb">
                    <li><i class="fa fa-home"></i><a href="Dashboard.aspx">Home</a></li>
                    <li><i class="icon_document_alt"></i><a href="#">Reports</a></li>
                    <li><i class="fa fa-mail-reply-o"></i>User Activity Report</li>
                </ol>
                <h2>User Activity Report</h2>
                <asp:Button ID="Button1" OnClick="downloadClicked" Text="Download Report" runat="server" CssClass="btn btn-primary" />
                <asp:GridView ID="GridView1" runat="server" CssClass="table">
                </asp:GridView>
            </div>
        </div>
    </div>


    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=GridView1.ClientID%>').DataTable({
                bLengthChange: true,
                lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                "paging": true,
                //bFilter: true,
                //bSort: true,
                //bPaginate: true
            });
            PageMethods.GetData("", OnSuccess, OnFailure);

        });

        function OnSuccess(result) {

            var columns = result.Columns;
            var dataRows = result.Data;

            var columnHeaders = [];
            $.each(columns, function (index, value) {
                columnHeaders.push({ title: value });
            });
            var table = $('#gridTable2').DataTable({
                data: dataRows,
                columns: columnHeaders,
                "paging": false
            });

        }
        function OnFailure(error) {
            console.log(result);
        }
        function populateTable(resp) {
            console.log('---------------')
            var table = JSON.parse(resp);
            console.log(table);

            var columns = table.Columns;
            var dataRows = table.Data;

            var columnHeaders = [];
            $.each(columns, function (index, value) {
                columnHeaders.push({ title: value });
            });
            var table = $('#gridTable').DataTable({
                data: dataRows,
                columns: columnHeaders,
                "paging": true,
            });
        }
    </script>
</asp:Content>


