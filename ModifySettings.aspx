<%@ Page Title="" Language="C#" MasterPageFile="~/Risk.Master" AutoEventWireup="true" CodeBehind="ModifySettings.aspx.cs" Inherits="RiskProfilingApp.ModifySettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header"><i class="fa fa-file-text-o"></i>Modify Settings</h3>
                <ol class="breadcrumb">
                    <li><i class="fa fa-home"></i><a href="SystemSettings.aspx">Home</a></li>
                    <li><i class="icon_document_alt"></i><a href="#">Settings</a></li>
                    <li><i class="fa fa-file-text-o"></i>Modify Settings</li>
                </ol>
            </div>
        </div>

        <div>
            <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="12pt"
                ForeColor="Red" Text="." CssClass="text-center"></asp:Label>
        </div>
        <br />

        <table class="table">

            <tbody>
                <tr>
                    <td>
                        <asp:Label ID="acc" runat="server" Font-Bold="false" Font-Size="12pt">Code</asp:Label></td>
                    <td>
                        <asp:Label ID="codes" runat="server" Font-Bold="true" Font-Size="12pt"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="account" runat="server" Font-Bold="false" Font-Size="12pt">Description</asp:Label></td>
                    <td>
                        <asp:Label runat="server" Font-Size="12pt" Font-Bold="true" ID="_description"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="cust" runat="server" Font-Bold="false" Font-Size="12pt">Current Value</asp:Label>
                    </td>
                    <td>
                        <asp:Label Enabled="true" Font-Bold="true" Font-Size="12pt" runat="server" ID="_value"></asp:Label>
                    </td>

                </tr>

            
                <tr>

                    <td>
                        <asp:Label ID="unit" runat="server"  Font-Bold="false" Font-Size="12pt">Change Value</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="dd_chooses" runat="server" Enabled="false" Font-Bold="true" Font-Size="12pt">
                            <asp:ListItem Text="Select Option" Value="Select Option" />
                            <asp:ListItem Text="1" Value="1" />
                            <asp:ListItem Text="2" Value="2" />
                            <asp:ListItem Text="3" Value="3" />
                        </asp:DropDownList></td>
                    <td><asp:Button Text="EDIT" Font-Size="12pt" runat="server" CssClass="btn btn-primary" OnClick="editoptions_Click" ID="editoptions" ></asp:Button></td>
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
                        <asp:Label ID="sanc" runat="server" Font-Bold="false" Font-Size="12pt">Modified By</asp:Label>

                    </td>
                    <td>
                        <asp:Label ID="lastmodifiedBy" runat="server" Font-Bold="true" Font-Size="12pt"></asp:Label></td>

                </tr>

                <tr>
                    <td>
                        <asp:Label ID="days" runat="server" Font-Bold="false" Font-Size="12pt">Modified Date</asp:Label></td>
                    <td>
                        <asp:Label Font-Bold="true" Font-Size="12pt" runat="server" ID="_modified"></asp:Label></td>
                </tr>

                <tr>

                    <td>
                        <asp:Button Text="Save" Font-Size="12pt" CssClass="btn btn-success" OnClick="saveBtn_Click" runat="server"  ID="saveBtn"></asp:Button></td>
                </tr>

            </tbody>
        </table>

    </div>
</asp:Content>
