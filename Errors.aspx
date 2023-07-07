<%@ Page Title="" Language="C#" MasterPageFile="~/Risk.Master" AutoEventWireup="true" CodeBehind="Errors.aspx.cs" Inherits="RiskProfilingApp.Errors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="container">
    <div class="form-group" style="align-content: center">
        <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="12pt"
            ForeColor="Red" Text="." CssClass="text-center"></asp:Label>
    </div>
     <div class="row">
            <asp:Button ID="Button1" OnClick="downloadClicked" Text="Generate Report" runat="server" CssClass="btn btn-primary" />

        </div>
   
        <h2>ALL ERRORS</h2>
        <div class="table-responsive">
            <table class="table-primary table" id="gridTable">
            </table>
        </div>
    </div>
   <script>
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
           })

       }
   </script>
</asp:Content>

