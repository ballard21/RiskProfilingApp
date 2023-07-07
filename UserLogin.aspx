<%@ Page Title="" Language="C#" MasterPageFile="~/Cover.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="RiskProfilingApp.UserLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="login-form">
            <input name="__RequestVerificationToken" type="hidden" value="6fGBtLZmVBZ59oUad1Fr33BuPxANKY9q3Srr5y[...]" />
                <h2 class="text-center" style="font-family: 'Century Gothic'; color: darkblue;">Risk Profiling Portal</h2>
                <asp:Label ID="lblmsg" runat="server" Font-Names="Century Gothic" Font-Size="12pt"
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
                    <asp:Button ID="Login" CssClass="btn btn-primary" Text="Login" OnClick="LoginButtons" runat="server" Style="width: 100%" />
                </div>
                <div class="clearfix">
                    <p style="font-family: 'Century Gothic'; color: #044780; align-content: center;">Please use your domain credentials</p>
                </div>
        </div>
    </div>
</asp:Content>
