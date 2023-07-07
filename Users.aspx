<%@ Page Title="" Language="C#" MasterPageFile="~/Risk.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="RiskProfilingApp.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <div>
            <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="12pt"
                ForeColor="Red" Text="." CssClass="text-center"></asp:Label>
        </div>
        <div class="row">
            <asp:Button ID="Button1" OnClick="downloadClicked" Text="Generate Report" runat="server" CssClass="btn btn-primary" />

        </div>
        <br />
    <%--    <div class="row">
            <div class="col-lg-2">
                <asp:DropDownList ID="dd_facilities" runat="server" CssClass="form-control fill-parent" Enabled="false">
                    <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                  
                </asp:DropDownList>
            </div>
            <div class="col-lg-2">
                <asp:DropDownList ID="dd_username" Enabled="false" runat="server" CssClass="form-control fill-parent">
                    <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="col-lg-2">
                <asp:TextBox ID="from_date" runat="server" Enabled="false" PlaceHolder="FROM" CssClass="form-control _datepicker"></asp:TextBox>
            </div>
            <div class="col-lg-2">
                <asp:TextBox ID="to_date" runat="server" Placeholder="TO" Enabled="false" CssClass="form-control _datepicker"></asp:TextBox>
            </div>
            <div class="col-lg-2">
                <asp:Button ID="SearchBtn" OnClick="Searchtxn" Text="Search" runat="server" CssClass="btn btn-primary" />
            </div>
            <div class="col-lg-2">
                <span class="glyphicon glyphicon-save"></span>
            </div>
        </div>--%>
        <br />
        <div class="table-responsive">
            <table class="table-primary table" id="gridTable">
            </table>
        </div>

        <%-- <script type="text/javascript" src="js/sb-admin-2.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui.js"></script>
        <script type="text/javascript" src="js/jquery.js"></script>--%>
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
