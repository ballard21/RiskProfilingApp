<%@ Page Title="" Language="C#" MasterPageFile="~/Risk.Master" AutoEventWireup="true" CodeBehind="Configurations.aspx.cs" Inherits="RiskProfilingApp.Configurations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="form-group" style="align-content: center">
        <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="12pt"
            ForeColor="Red" Text="." CssClass="text-center"></asp:Label>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header"><i class="fa fa-file-text-o"></i>Configurations</h3>
                <ol class="breadcrumb">
                    <li><i class="fa fa-home"></i><a href="Dashboard.aspx">Home</a></li>
                    <li><i class="icon_desktop"></i><a href="#">Settings</a></li>
                    <li><i class="fa fa-file-text-o"></i>System Configurations</li>
                </ol>
            </div>
        </div>
        <section class="panel">
            <header class="panel-heading tab-bg-primary ">
                <ul class="nav nav-tabs">
                    <li class="active">

                    <li class="">
                        <a data-toggle="tab" href="#defaultreason">Countries</a>
                    </li>
                    <li class="">
                        <a data-toggle="tab" href="#letters">Countries List</a>
                    </li>
                    <li class="">
                        <a data-toggle="tab" href="#demandnotice">Products</a>
                    </li>
                    <li class="">
                        <a data-toggle="tab" href="#nextactions">Products List</a>
                    </li>
                    <li class="">
                        <a data-toggle="tab" href="#edcs">Client Type</a>
                    </li>
                </ul>
            </header>
            <div class="panel-body">
                <div class="tab-content">
                    <div id="defaultreason" class="tab-pane">
                        Countries
                         <div class="container">
                             <div class="row">
                                 <div class="col-lg">
                                     <div class="row">
                                         <div class="panel-body">
                                             <div class="d-inline">
                                                 <div class="col-lg-6">
                                                     <div class="form-group">
                                                         <asp:DropDownList ID="_countries" runat="server" CssClass="form-control"></asp:DropDownList>
                                                         <asp:Button ID="_countriesBT" runat="server" CssClass="btn btn-primary" Text="Check" OnClick="_countriesBT_Click" />
                                                     </div>
                                                 </div>
                                             </div>

                                             <br />
                                             <div runat="server" id="_countryVw" visible="false">
                                                 <table class="table">

                                                     <tbody>
                                                         <tr>
                                                             <td>
                                                                 <asp:Label ID="acc" runat="server" Font-Bold="false" Font-Size="12pt">ID</asp:Label></td>
                                                             <td>
                                                                 <asp:Label ID="ids" runat="server" Font-Bold="true" Font-Size="12pt"></asp:Label></td>
                                                         </tr>
                                                         <tr>
                                                             <td>
                                                                 <asp:Label ID="account" runat="server" Font-Bold="false" Font-Size="12pt">Code</asp:Label></td>
                                                             <td>
                                                                 <asp:Label runat="server" Font-Size="12pt" Font-Bold="true" ID="codes"></asp:Label></td>
                                                         </tr>
                                                         <tr>
                                                             <td>
                                                                 <asp:Label ID="cust" runat="server" Font-Bold="false" Font-Size="12pt">Description</asp:Label>
                                                             </td>
                                                             <td>
                                                                 <asp:Label Enabled="true" Font-Bold="true" Font-Size="12pt" runat="server" ID="descriptions"></asp:Label>
                                                             </td>

                                                         </tr>

                                                         <tr>

                                                             <td>
                                                                 <asp:Label ID="branch" runat="server" Font-Bold="false" Font-Size="12pt">Value</asp:Label>
                                                             </td>
                                                             <td>
                                                                 <asp:Label Enabled="true" runat="server" Font-Bold="true" Font-Size="12pt" ID="values"></asp:Label></td>


                                                         </tr>
                                                         <tr>

                                                             <td>
                                                                 <asp:Label ID="unit" runat="server" Font-Bold="false" Font-Size="12pt">Change Value</asp:Label>
                                                             </td>
                                                             <td>
                                                                 <asp:DropDownList ID="dd_values" runat="server" Font-Bold="true" Font-Size="12pt">
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
                                                                 <asp:Button Text="Save" Font-Size="12pt" CssClass="btn btn-success" runat="server" OnClick="saveBtnOnclick" ID="saveBtn"></asp:Button></td>
                                                         </tr>
                                                     </tbody>
                                                 </table>
                                             </div>

                                             <asp:Label ID="lblUserCode" runat="server" Text="Label" Visible="False"></asp:Label>
                                         </div>
                                     </div>
                                 </div>
                             </div>
                         </div>
                    </div>
                    <div id="letters" class="tab-pane">
                        Countries List
                        <div class="container">
                            <div class="row">
                                <div class="table-responsive">
                                    <table class="table-primary table" id="gridTable">
                                    </table>
                                </div>
                                <div class="col-lg">
                                    <div class="row">
                                        <div class="panel-body">
                                            <div class="table-responsive">
                                                <asp:GridView ID="GridData" runat="server" CssClass="table table-bordered table-hover"
                                                    HorizontalAlign="Center" OnRowCommand="GridData_RowCommand" GridLines="None"
                                                    DataKeyNames="ID" OnRowDataBound="GridData_RowDataBound" AutoGenerateColumns="false">
                                                    <Columns>

                                                        <asp:BoundField DataField="ID" HeaderText="ID" />
                                                        <asp:BoundField DataField="Code" HeaderText="Code" />
                                                        <asp:BoundField DataField="Description" HeaderText="Description" />
                                                        <asp:BoundField DataField="Value" HeaderText="Rating Score" />
                                                        <asp:BoundField DataField="Modified" HeaderText="Record Date" />

                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <asp:Label ID="Label10" runat="server" Text="Label" Visible="False"></asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg">
                                    <div class="row">
                                        <div class="col-lg-6">

                                            <%--                                        <div class="form-group">
                                            <asp:Label ID="Label11" runat="server" Font-Bold="true" Font-Size="12pt">Default Letter Code</asp:Label>
                                            <asp:TextBox ID="letterCode" class="form-control" placeholder="Enter default reason code" runat="server"></asp:TextBox>
                                        </div>--%>

                                            <div class="form-group">
                                                <asp:Label ID="Label12" runat="server" Font-Bold="true" Font-Size="12pt">Letter Title</asp:Label>
                                                <asp:TextBox ID="letterTitle" class="form-control" placeholder="Enter default reason name" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <asp:Label ID="Label13" runat="server" Font-Bold="true" Font-Size="12pt">Upload Letter</asp:Label>
                                                <asp:FileUpload ID="letterUploadFile" runat="server" CssClass="form-control-file" />
                                            </div>

                                            <asp:Button ID="Button6" class="btn btn-primary" Text="ADD Letter" OnClick="LetterUploadBtn" runat="server"></asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="demandnotice" class="tab-pane">
                        Products
                        <div class="container">
                            <div class="row">
                                <div class="col-lg">
                                    <div class="row">
                                        <div class="panel-body">
                                            <div class="table-responsive">
                                                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover"
                                                    HorizontalAlign="Center" OnRowCommand="GridData_RowCommand" GridLines="None"
                                                    DataKeyNames="ID" OnRowDataBound="GridData_RowDataBound" AutoGenerateColumns="false">
                                                    <Columns>

                                                        <asp:BoundField DataField="ID" HeaderText="ID" />

                                                        <asp:BoundField DataField="Code" HeaderText="Code" />

                                                        <asp:BoundField DataField="Description" HeaderText="Description" />

                                                        <asp:BoundField DataField="Created" HeaderText="Record Date" />

                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <asp:Label ID="Label9" runat="server" Text="Label" Visible="False"></asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg">
                                    <div class="form-group ">
                                        <asp:Label ID="Label4" runat="server" Font-Bold="true" Font-Size="12pt">Demand Notice Title</asp:Label>
                                        <asp:TextBox ID="ddNotice" class="form-control" placeholder="Enter Demand Notice Title" runat="server"></asp:TextBox>

                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="Label8" runat="server" Font-Bold="true" Font-Size="12pt">Upload Demand Notice</asp:Label>
                                        <asp:FileUpload ID="FileUpload2" runat="server" CssClass="form-control-file" />
                                    </div>
                                    <asp:Button ID="Button5" class="btn btn-primary" Text="Add Demand Notice" OnClick="ddAddition" runat="server"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="nextactions" class="tab-pane">
                        Products List
                         <div class="container">
                             <div class="row">

                                 <div class="col-lg">
                                     <div class="row">
                                         <div class="panel-body">
                                             <div class="table-responsive">
                                                 <asp:GridView ID="GridView3" runat="server" CssClass="table table-bordered table-hover"
                                                     HorizontalAlign="Center" OnRowCommand="GridData_RowCommand" GridLines="None"
                                                     DataKeyNames="ID" OnRowDataBound="GridData_RowDataBound" AutoGenerateColumns="false">
                                                     <Columns>

                                                         <asp:BoundField DataField="Code" HeaderText="Code" />

                                                         <asp:BoundField DataField="Description" HeaderText="Description" />

                                                         <asp:BoundField DataField="Created" HeaderText="Record Date" />

                                                     </Columns>
                                                 </asp:GridView>
                                             </div>
                                             <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
                                         </div>
                                     </div>
                                 </div>

                                 <div class="col-lg">
                                     <div class="row">
                                         <div class="col-lg-6">
                                             <div class="form-group">
                                                 <asp:Label ID="Label7" runat="server" Font-Bold="true" Font-Size="12pt">Action Name</asp:Label>
                                                 <asp:TextBox ID="actionNames" class="form-control" placeholder="Enter Next Action Name" runat="server"></asp:TextBox>
                                             </div>

                                             <asp:Button ID="actionsName" class="btn btn-primary" Text="Add Action Name" OnClick="ActionButton_Click" runat="server"></asp:Button>
                                         </div>
                                     </div>
                                 </div>
                             </div>
                         </div>
                    </div>
                    <div id="edcs" class="tab-pane">Client Types</div>
                </div>
            </div>
        </section>
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
                    "defaultContent": "<input type='button' value='Action' class='btn btn-info' style='z-index:999'/>"

                }],


            })

            $('#gridTable tbody').on('click', 'input', function () {
                //alert("");
                var data = $('#gridTable').DataTable().row($(this).parents('tr')).data();
                //var row = $('#' + gridTable).DataTable().row($(this).parents('tr'));
                var buttonSelected = $(this).val();
                //alert(buttonSelected);
                if (buttonSelected == "Action") {
                    //alert(JSON.stringify(data))

                    // console.log(data);
                    window.location = "MaintainUsers.aspx?Account=" + data[1];
                }
            });

        }
    </script>
</asp:Content>


