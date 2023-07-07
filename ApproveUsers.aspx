<%@ Page Title="" Language="C#" MasterPageFile="~/Risk.Master" AutoEventWireup="true" CodeBehind="ApproveUsers.aspx.cs" Inherits="RiskProfilingApp.ApproveUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div>
        <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="12pt"
            ForeColor="Red" Text="." CssClass="text-center"></asp:Label>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <h3 class="page-header"><i class="fa fa-file-text-o"></i>Approve Users</h3>
            <ol class="breadcrumb">
                <li><i class="fa fa-home"></i><a href="#">User Settings</a></li>
                <li><i class="icon_document_alt"></i><a href="ApproveUsers.aspx">Approve Users</a></li>
             
            </ol>
        </div>
    </div>
    <div class="table-responsive">

        <asp:GridView ID="GridData" runat="server" Width="100%" CssClass="table table-bordered table-hover" OnRowCommand="grid_RowCommand">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnApprove" CommandName="ApproveUser" Text="Approve" runat="server" CssClass="btn btn-primary" Style="margin-top: 10px" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%-- <asp:DropDownList ID="dd_profile" CommandName="dd_profile" runat="server" CssClass="form-control fill-parent"></asp:DropDownList> 
                        --%>
                        <asp:Button ID="btnDeny" CommandName="DenyUser" Text="Reject" runat="server" CssClass="btn btn-danger" Style="margin-top: 10px" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>


        <div class="table-responsive">
            <asp:GridView ID="GridView1" runat="server" PageSize="15" CssClass="table table-bordered table-hover">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnApvTxn" Text="Approve Transaction" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

    </div>
    <asp:MultiView ID="Multiview1" runat="server" Visible="false">
        <asp:View ID="View1" runat="server">
            <div class="col-lg-6 form-group">
                <label class="help-block">
                    Enter Rejection Reason</label>
                <asp:TextBox ID="rejectReason" runat="server" CssClass="form-control fill-parent"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:Button ID="ButtonClicks" runat="server" Text="Submit" Style="margin-top: 10px"
                        CssClass="btn btn-primary" BorderColor="BurlyWood" />

            </div>
        </asp:View>
    </asp:MultiView>

</asp:Content>

