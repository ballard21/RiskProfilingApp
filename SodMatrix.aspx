<%@ Page Title="" Language="C#" MasterPageFile="~/Risk.Master" AutoEventWireup="true" CodeBehind="SodMatrix.aspx.cs" Inherits="RiskProfilingApp.SodMatrix" %>
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
        <div class="table-responsive">
            <asp:GridView ID="GridData" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="table table-bordered table-hover">
                <Columns>
                    <asp:BoundField DataField="RoleName" HeaderText="Role Name" />
                    <asp:BoundField DataField="RoleId" HeaderText="Role ID" />
                    <asp:BoundField DataField="Description" HeaderText="User Rights" />
                    <asp:BoundField DataField="Active" HeaderText="Active" />
                    <asp:BoundField DataField="RecordDate" HeaderText="Record Date" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
