<%@ Page Title="" Language="C#" MasterPageFile="~/Risk.Master" AutoEventWireup="true" CodeBehind="ApproveSystemSettings.aspx.cs" Inherits="RiskProfilingApp.ApproveSystemSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <div class="form-group" style="align-content: center">
            <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="12pt"
                ForeColor="Red" Text="." CssClass="text-center"></asp:Label>
        </div>
       <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header"><i class="fa fa-file-text-o"></i>System Settings</h3>
                <ol class="breadcrumb">
                    <li><i class="fa fa-home"></i><a href="ApproveSystemSettings.aspx">Home</a></li>
                    <li><i class="icon_desktop"></i><a href="#">Approve System Settings</a></li>
                    <li><i class="fa fa-file-text-o"></i>Approve System Settings</li>
                </ol>
            </div>
        </div>
        <div class="row">
            <asp:Button ID="Button1" OnClick="downloadClicked" Text="Generate Report" runat="server" CssClass="btn btn-primary"></asp:Button>

        </div>

        <h2>Checker Verification</h2>
        <div class="table-responsive">
            <table class="table-primary table" id="gridTable">
            </table>
        </div>
    </div>
    <script type="text/javascript">
        function PopulateDataTable(data) {
            var resp = JSON.parse(data);
            console.log(resp);
            var columns = [];
            resp.DataTable.Columns.forEach(function (data) {
                columns.push({ title: data });
            })
            console.log(columns);
            $("#gridTable").DataTable({
                data: resp.DataTable.Data,

                columns: columns,
                destroy: true,

                "columnDefs": [{

                    "targets": -1,
                    "data": null,
                    "defaultContent": "<input type='button' value='Details' class='btn btn-info' style='z-index:999'/>"

                }],
              
            })

            $('#gridTable tbody').on('click', 'input', function () {
                //alert("");
                var data = $('#gridTable').DataTable().row($(this).parents('tr')).data();
                //var row = $('#' + gridTable).DataTable().row($(this).parents('tr'));
                var buttonSelected = $(this).val();
                //alert(buttonSelected);
                if (buttonSelected == "Details") {
                    //alert(JSON.stringify(data))

                    // console.log(data);
                    window.location = "CheckerVerification.aspx?Account=" + data[2];
                }
              
            });

        }
    </script>

</asp:Content>
