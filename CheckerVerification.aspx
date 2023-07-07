<%@ Page Title="" Language="C#" MasterPageFile="~/Risk.Master" AutoEventWireup="true" CodeBehind="CheckerVerification.aspx.cs" Inherits="RiskProfilingApp.CheckerVerification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="container">
        <div>
            <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="12pt"
                ForeColor="Red" Text="." CssClass="text-center"></asp:Label>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header"><i class="fa fa-file-text-o"></i>Checker Verification</h3>
                <ol class="breadcrumb">
                    <li><i class="fa fa-home"></i><a href="ApproveSystemSettings.aspx">Home</a></li>
                    <li><i class="icon_document_alt"></i><a href="#">Check Verification</a></li>
                    <%--<li><i class="fa fa-file-text-o"></i>Risk Profiling</li>--%>
                </ol>
            </div>
        </div>
        <br />
        <table class="table">

            <tbody>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Font-Bold="false" Font-Size="12pt">Option</asp:Label></td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Font-Bold="true" Font-Size="12pt"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="acc" runat="server" Font-Bold="false" Font-Size="12pt">Category</asp:Label></td>
                    <td>
                        <asp:Label ID="username" runat="server" Font-Bold="true" Font-Size="12pt"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="account" runat="server" Font-Bold="false" Font-Size="12pt">Category 2</asp:Label></td>
                    <td>
                        <asp:Label runat="server" Font-Size="12pt" Font-Bold="true" ID="fullname"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="cust" runat="server" Font-Bold="false" Font-Size="12pt">Code</asp:Label>
                    </td>
                    <td>
                        <asp:Label Enabled="true" Font-Bold="true" Font-Size="12pt" runat="server" ID="role"></asp:Label>
                    </td>

                </tr>

                <tr>

                    <td>
                        <asp:Label ID="branch" runat="server" Font-Bold="false" Font-Size="12pt">Description</asp:Label>
                    </td>
                    <td>
                        <asp:Label Enabled="true" runat="server" Font-Bold="true" Font-Size="12pt" ID="phones"></asp:Label></td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="code" runat="server" Font-Bold="false" Font-Size="12pt">Value</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="status" runat="server" Font-Bold="true" Font-Size="12pt"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Font-Bold="false" Font-Size="12pt">Modified</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Font-Bold="true" Font-Size="12pt"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Font-Bold="false" Font-Size="12pt">Modified By</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Font-Bold="true" Font-Size="12pt"></asp:Label></td>
                </tr>
                <tr>

                    <td>
                        <asp:Label ID="unit" runat="server" Font-Bold="false" Font-Size="12pt">Approval Status</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="dd_choose" OnSelectedIndexChanged="dd_choose_SelectedIndexChanged" AutoPostBack="true" runat="server" Font-Bold="true" Font-Size="12pt">
                           <asp:ListItem Text="Select Option" Value="Options"></asp:ListItem>
                            <asp:ListItem Text="Reject" Value="Reject"></asp:ListItem>
                            <asp:ListItem Text="Approve" Value="Approve"></asp:ListItem>
                        </asp:DropDownList></td>
                </tr>

                <tr id="rejec" runat="server">

                    <td>
                        <asp:Label ID="Label7" runat="server" Font-Bold="false" Font-Size="12pt">Rejection Reason</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="rejctreason" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>

                    <td>
                        <asp:Button Text="Submit" Font-Size="12pt" runat="server" OnClick="saveBtnOnclick" ID="saveBtn"></asp:Button></td>
                </tr>


            </tbody>
        </table>
    </div>
</asp:Content>
