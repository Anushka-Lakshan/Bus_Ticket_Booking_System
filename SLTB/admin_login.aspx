<%@ Page Title="" Language="C#" MasterPageFile="~/main_layout.Master" AutoEventWireup="true" CodeBehind="admin_login.aspx.cs" Inherits="SLTB.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_content" runat="server">
    <div class="row justify-content-center">
        <div class="col-md-6">
            <h4 class="text-center mb-3">Admin Login</h4>

            <asp:Label ID="error_log" runat="server" CssClass="error_log" Text="Label" Visible="false"></asp:Label>


            <div class="loginBody">
                <div class="form-group">
                    <div class="input-group mb-3">

                        <asp:TextBox ID="username" CssClass="form-control form-control-lg" placeholder="Username..." runat="server"></asp:TextBox>

                        <div class="input-group-append">
                            <span class="input-group-text p-3"><i class="fa fa-user"></i></span>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="input-group mb-3">

                        <asp:TextBox ID="password" CssClass="form-control form-control-lg" placeholder="Password..." TextMode="Password" runat="server"></asp:TextBox>

                        <div class="input-group-append">
                            <span class="input-group-text p-3"><i class="fa fa-lock"></i></span>
                        </div>
                    </div>
                </div>

                <div class="form-group">

                    <asp:Button ID="Button" runat="server" CssClass="btn btn-block btn-lg btn-success" Text="Login" OnClick="Button_Click" />

                </div>
            </div>
        </div>
    </div>
</asp:Content>
