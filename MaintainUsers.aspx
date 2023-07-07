<%@ Page Title="" Language="C#" MasterPageFile="~/Risk.Master" AutoEventWireup="true" CodeBehind="MaintainUsers.aspx.cs" Inherits="RiskProfilingApp.MaintainUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="container">
        <div>
            <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="12pt"
                ForeColor="Red" Text="." CssClass="text-center"></asp:Label>
        </div>
        <br />
 <table class="table">

            <tbody>
                <tr>
                    <td>
                        <asp:Label ID="acc" runat="server" Font-Bold="false" Font-Size="12pt">UserName</asp:Label></td>
                    <td>
                        <asp:Label ID="username" runat="server" Font-Bold="true" Font-Size="12pt"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="account" runat="server" Font-Bold="false" Font-Size="12pt">Full Name</asp:Label></td>
                    <td>
                        <asp:Label runat="server" Font-Size="12pt" Font-Bold="true" ID="fullname"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="cust" runat="server" Font-Bold="false" Font-Size="12pt">Current Role</asp:Label>
                    </td>
                    <td>
                        <asp:Label Enabled="true" Font-Bold="true" Font-Size="12pt" runat="server" ID="role"></asp:Label>
                    </td>

                </tr>

                <tr>

                    <td>
                        <asp:Label ID="branch" runat="server" Font-Bold="false" Font-Size="12pt">Phone Number</asp:Label>
                    </td>
                    <td>
                        <asp:Label Enabled="true" runat="server" Font-Bold="true" Font-Size="12pt" ID="phones"></asp:Label></td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="code" runat="server" Font-Bold="false" Font-Size="12pt">Current Status</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="status" runat="server" Font-Bold="true" Font-Size="12pt"></asp:Label></td>
                </tr>
                <tr>

                    <td>
                        <asp:Label ID="unit" runat="server" Font-Bold="false" Font-Size="12pt">Status</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="dd_choose" runat="server" Font-Bold="true" Font-Size="12pt">
                        </asp:DropDownList></td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="schm" runat="server" Font-Bold="false" Font-Size="12pt">Creation Date</asp:Label>

                    </td>
                    <td>
                        <asp:Label ID="creationdt" runat="server" Font-Bold="true" Font-Size="12pt"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="sanc" runat="server" Font-Bold="false" Font-Size="12pt">Last Login Date</asp:Label>

                    </td>
                    <td>
                        <asp:Label ID="lastlogindate" runat="server" Font-Bold="true" Font-Size="12pt"></asp:Label></td>

                </tr>

                <tr>
                    <td>
                        <asp:Label ID="days" runat="server" Font-Bold="false" Font-Size="12pt">Access Level</asp:Label></td>
                    <td>
                        <asp:Label Font-Bold="true" Font-Size="12pt" runat="server" ID="accessLevel"></asp:Label></td>
                </tr>

                <tr>

                    <td>
                        <asp:Button Text="Save" Font-Size="12pt" runat="server" OnClick="saveBtnOnclick" ID="saveBtn"></asp:Button></td>
                </tr>


            </tbody>
        </table>
        </div>
</asp:Content>


