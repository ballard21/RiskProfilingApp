<%@ Page Title="" Language="C#" MasterPageFile="~/Risk.Master" AutoEventWireup="true" CodeBehind="RiskProfile.aspx.cs" Inherits="RiskProfilingApp.RiskProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <div>
            <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="12pt"
                ForeColor="Red" Text="." CssClass="text-center"></asp:Label>
        </div>

       <%-- <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header"><i class="fa fa-file-text-o"></i>Risk Profiling</h3>
                <ol class="breadcrumb">
                    <li><i class="fa fa-home"></i><a href="RiskProfile.aspx">Home</a></li>
                    <li><i class="fa fa-file-text-o"></i>Risk Profiling</li>
                </ol>
            </div>
        </div>--%>
        <div id="submitRequest" runat="server">
            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Label ID="scripTitle" runat="server" Font-Bold="true" Font-Size="12pt">Customer Name</asp:Label>
                        <asp:TextBox ID="_customerName" class="form-control" placeholder="Enter Customer Name" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Size="12pt">Customer Address</asp:Label>
                        <asp:TextBox ID="_address" class="form-control" placeholder="Enter Customer Address" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Font-Bold="true" Font-Size="12pt">Client Type</asp:Label>
                        <asp:DropDownList runat="server" CssClass="form-control fill-parent" ID="_clienttype"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Font-Bold="true" Font-Size="12pt">Country Of CitizenShip</asp:Label>
                        <asp:DropDownList runat="server" CssClass="form-control fill-parent" ID="_country"></asp:DropDownList>
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Font-Bold="true" Font-Size="12pt">Nature of Business Activities / Occupation</asp:Label>
                        <asp:DropDownList runat="server" CssClass="form-control " ID="_nature"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Label ID="Label5" runat="server" Font-Bold="true" Font-Size="12pt">Preferred Bank Product</asp:Label>
                        <asp:DropDownList runat="server" CssClass="form-control fill-parent" ID="_preferred"></asp:DropDownList>
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Label ID="Label6" runat="server" Font-Bold="true" Font-Size="12pt">Distribution Channel</asp:Label>
                        <asp:DropDownList runat="server" CssClass="form-control fill-parent" ID="_distributionChannel"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Label ID="Label7" runat="server" Font-Bold="true" Font-Size="12pt">Customer Income Range</asp:Label>
                        <asp:DropDownList runat="server" CssClass="form-control fill-parent" ID="DropDownList1"></asp:DropDownList>
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Label ID="Label8" runat="server" Font-Bold="true" Font-Size="12pt">Is Politically Exposed Person (PEP)?</asp:Label>
                        
                        <asp:DropDownList runat="server" ID="_ddpep" CssClass="form-control fill-parent" >
                            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Button ID="SearchBtn" OnClick="Searchtxn" Text="Submit" runat="server" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>

        <div id="submitResponse" visible="false" runat="server">
            <div class="row">
                <div class="col-lg-12">
                    <asp:Label ID="Label19" runat="server" Font-Bold="true" Font-Size="20pt"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:Label ID="Label20" Font-Bold="true" Font-Size="20pt" runat="server"></asp:Label>
                </div>
            </div>
           
            <div class="row">
                <div class="col-lg-12">
                    <asp:Label ID="Label9" runat="server" Font-Bold="true" Font-Size="12pt">Customer Name</asp:Label>
                </div>
            </div>
            <div class="row">

                <div class="col-lg-12">
                    <div class="form-group">
                    <asp:Label ID="TextBox1" runat="server"></asp:Label></div>
                </div>
            </div>
          
            <div class="row">
                <div class="col-lg-12">
                    <asp:Label ID="Label10" runat="server" Font-Bold="true" Font-Size="12pt">Customer Address</asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group">
                        <asp:Label ID="TextBox2" placeholder="Enter Customer Address" runat="server"></asp:Label>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <asp:Label ID="Label11" runat="server" Font-Bold="true" Font-Size="12pt">Client Type</asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group">
                        <asp:Label runat="server" ID="DropDownList2"></asp:Label>
                        <asp:Label runat="server" CssClass="badge badge-secondary" ID="Label21"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:Label ID="Label12" runat="server" Font-Bold="true" Font-Size="12pt">Country Of CitizenShip</asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group">
                    <asp:Label runat="server" ID="DropDownList3"></asp:Label>
                    <asp:Label runat="server" CssClass="badge badge-secondary" ID="Label22"></asp:Label></div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:Label ID="Label13" runat="server" Font-Bold="true" Font-Size="12pt">Nature of Business Activities / Occupation</asp:Label>

                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group">
                    <asp:Label runat="server" ID="DropDownList4"></asp:Label>
                    <asp:Label runat="server" CssClass="badge badge-secondary" ID="Label23"></asp:Label></div>
                </div>
            </div>
            <div class="row">

                <div class="col-lg-12">
                    <asp:Label ID="Label14" runat="server" Font-Bold="true" Font-Size="12pt">Preferred Bank Product</asp:Label>

                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group">
                        <asp:Label runat="server" ID="DropDownList5"></asp:Label>
                        <asp:Label runat="server" CssClass="badge badge-secondary" ID="Label24"></asp:Label>
                    </div>

                </div>
            </div>
            <div class="row">

                <div class="col-lg-12">
                        <asp:Label ID="Label15" runat="server" Font-Bold="true" Font-Size="12pt">Distribution Channel</asp:Label>
                    </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group">
                    <asp:Label runat="server" ID="DropDownList6"></asp:Label>
                    <asp:Label runat="server" CssClass="badge badge-secondary" ID="Label25"></asp:Label></div>

                </div>
            </div>
            <div class="row">


                <div class="col-lg-12">
                        <asp:Label ID="Label16" runat="server" Font-Bold="true" Font-Size="12pt">Customer Income Range</asp:Label>
                    </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group">
                    <asp:Label runat="server" ID="DropDownList7"></asp:Label>
                    <asp:Label runat="server" CssClass="badge badge-secondary" ID="Label26"></asp:Label></div>

                </div>
            </div>
            <div class="row">

                <div class="col-lg-12">
                        <asp:Label ID="Label17" runat="server" Font-Bold="true" Font-Size="12pt">Is Politically Exposed Person (PEP)?</asp:Label>
                    </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="form-group">
                    <asp:Label ID="Label18" runat="server" Font-Size="12pt"></asp:Label></div>
                </div>
            </div>
        </div>
    </div>


    <%--<script>
        $(document).ready(function () {
            $['input'].val('man');
            $['input'].attr('disabled', false)
        })
        document.addEventListener("DOMContentLoaded", function () {
            // code
            //alert("working");
            $('input').val('man');
            $('input').attr('disabled', false)
        });
    </script>--%>
</asp:Content>


