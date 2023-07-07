<%@ Page Title="" Language="C#" MasterPageFile="~/Cover.Master" AutoEventWireup="true" CodeBehind="UserSignUp.aspx.cs" Inherits="RiskProfilingApp.UserSignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="login-form">
            <input name="__RequestVerificationToken" type="hidden" value="6fGBtLZmVBZ59oUad1Fr33BuPxANKY9q3Srr5y[...]" />
            <h2 class="text-center" style="font-family: 'Century Gothic'; color: darkblue;">Risk Profiling SignUp</h2>
            <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="12pt"
                ForeColor="Red" Text="." CssClass="text-center"></asp:Label>
            <div class="form-group">
                <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-user"></i></span>
                    <asp:TextBox ID="txtUserName" name="user" CssClass="form-control" placeholder="Enter User ID" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                    <asp:TextBox ID="txtPassword" name="pass" CssClass="form-control" placeholder="Enter Your Password" runat="server" TextMode="Password"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-address-book"></i></span>
                    <asp:TextBox ID="phone" name="user" CssClass="form-control" placeholder="2567*******" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-navicon"></i></span>

                    <asp:DropDownList ID="dd_role" runat="server" CssClass="form-control fill-parent"></asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <asp:Button ID="Logins" CssClass="btn btn-primary" Text="Sign Up" OnClick="LoginButtons" runat="server" Style="width: 100%" />
            </div>

            <div class="clearfix">
                <p style="font-family: 'Century Gothic'; color: darkblue; align-content: center;">Please use your domain credentials</p>
            </div>
        </div>
    </div>
</asp:Content>
