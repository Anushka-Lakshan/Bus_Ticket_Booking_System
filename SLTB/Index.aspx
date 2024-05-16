<%@ Page Title="" Language="C#" MasterPageFile="~/main_layout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SLTB.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_content" runat="server">
    <h1 class="text-center">Welcome to SLTB Online Ticket Booking Portal</h1>
    <div class="row mt-4">
        <div class="col-lg-6 mb-4">
            <div class="card">
                <div class="card-body main-cards">
                    <asp:Image ImageUrl="./Images/image1.jpg" runat="server" />
                    <p>Book bus Tickets (For Passangers)</p>
                    <a href="/Book_step1.aspx" class="btn-block btn-success text-center btn">Book Ticket Now</a>
                </div>
            </div>
        </div>
        <div class="col-lg-6 mb-4">
            <div class="card">
                <div class="card-body main-cards">
                    <asp:Image ImageUrl="./Images/image2.jpg" runat="server" />
                    <p>Manage bus schedules (For Agencies)</p>
                    <a href="/agency_login.aspx" class="btn-block btn-info text-center btn">Log in</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
