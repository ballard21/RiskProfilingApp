<%@ Page Title="" Language="C#" MasterPageFile="~/Risk.Master" AutoEventWireup="true" CodeBehind="UserReports.aspx.cs" Inherits="RiskProfilingApp.UserReports" %>
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
                    <asp:BoundField DataField="Username" HeaderText="Username" />

                    <asp:BoundField DataField="Fullname" HeaderText="Name" />

                    <asp:BoundField DataField="PhoneNubmer" HeaderText="Phone Number" />

                    <asp:BoundField DataField="Email" HeaderText="Email" />

                    <asp:BoundField DataField="Role" HeaderText="Role" />

                    <asp:BoundField DataField="Active" HeaderText="Active" />
                    <asp:BoundField DataField="LastLoginDate" HeaderText="Last Login Date" />

                    <asp:BoundField DataField="RecordDate" HeaderText="Creation Date" />

                </Columns>
            </asp:GridView>

        </div>
    </div>
</asp:Content>


