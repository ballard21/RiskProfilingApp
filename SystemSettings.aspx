<%@ Page Title="" Language="C#" MasterPageFile="~/Risk.Master" AutoEventWireup="true" CodeBehind="SystemSettings.aspx.cs" Inherits="RiskProfilingApp.SystemSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="form-group" style="align-content: center">
        <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="12pt"
            ForeColor="Red" Text="." CssClass="text-center"></asp:Label>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header"><i class="fa fa-file-text-o"></i>System Settings</h3>
                <ol class="breadcrumb">
                    <li><i class="fa fa-home"></i><a href="SystemSettings.aspx">Home</a></li>
                    <li><i class="icon_desktop"></i><a href="#">Settings</a></li>
                    <li><i class="fa fa-file-text-o"></i>System Settings</li>
                </ol>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <asp:DropDownList runat="server" placeholder="ITEM" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="_ddItems_SelectedIndexChanged" ID="_ddItems">
                    <asp:ListItem Text="Countries" Value="Countries"></asp:ListItem>
                    <asp:ListItem Text="Distribution Channels" Value="Channels"></asp:ListItem>
                    <asp:ListItem Text="Income Bands" Value="Income"></asp:ListItem>
                    <asp:ListItem Text="Products" Value="Products"></asp:ListItem>
                    <asp:ListItem Text="Client Types" Value="Clients"></asp:ListItem>
                    <asp:ListItem Text="Businesses / Profession" Value="Business"></asp:ListItem>
                </asp:DropDownList>
            </div>            
             <div class="col-lg-2">
                <asp:Button ID="Button1" OnClick="Button1_Click" Text="ADD NEW" runat="server" CssClass="btn btn-success" />
            </div>
           
        </div>
         <div class="table-responsive">
            <table class="table-primary table" id="gridTable">
            </table>
        </div>
        <div id="_addnewdiv" runat="server" visible="false">
         <table class="table">

            <tbody>
                <tr>
                    <td>
                        <asp:Label ID="acc" runat="server" Font-Bold="false" Font-Size="12pt">Code</asp:Label></td>
                    <td>
                        <asp:TextBox ID="codes" runat="server" Font-Bold="true" CssClass="form-control" Font-Size="12pt"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="account" runat="server" Font-Bold="false" Font-Size="12pt">Description</asp:Label></td>
                    <td>
                        <asp:TextBox runat="server" CssClass="form-control" Font-Size="12pt" Font-Bold="true" ID="_description"></asp:TextBox></td>
                </tr>

                
                <tr>

                    <td>
                        <asp:Label ID="Label1" runat="server"  Font-Bold="false" Font-Size="12pt">Category</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="_category" runat="server" CssClass="form-control" Font-Bold="true" Font-Size="12pt">
                           
                        </asp:DropDownList></td>
                  </tr>
            
                <tr>

                    <td>
                        <asp:Label ID="unit" runat="server"  Font-Bold="false" Font-Size="12pt">Value</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="dd_chooses" runat="server" CssClass="form-control" Font-Bold="true" Font-Size="12pt">
                            <asp:ListItem Text="Select Option" Value="Select Option" />
                            <asp:ListItem Text="1" Value="1" />
                            <asp:ListItem Text="2" Value="2" />
                            <asp:ListItem Text="3" Value="3" />
                        </asp:DropDownList></td>
                  </tr>

                <tr>

                    <td>
                        <asp:Button Text="Save" Font-Size="12pt" CssClass="btn btn-success" OnClick="saveBtn_Click" runat="server"  ID="saveBtn"></asp:Button></td>
                </tr>

            </tbody>
        </table></div>
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
                      "defaultContent": "<input type='button' value='Modify' class='btn btn-info' style='z-index:999'/>"

                  }],

              })

              $('#gridTable tbody').on('click', 'input', function () {
                  //alert("");
                  var data = $('#gridTable').DataTable().row($(this).parents('tr')).data();
                  //var row = $('#' + gridTable).DataTable().row($(this).parents('tr'));
                  var buttonSelected = $(this).val();
                  //alert(buttonSelected);
                  if (buttonSelected == "Modify") {
                      //alert(JSON.stringify(data))

                      // console.log(data);
                      window.location = "ModifySettings.aspx?Code=" + data[1];
                  }
              });

          }
      </script>
</asp:Content>
