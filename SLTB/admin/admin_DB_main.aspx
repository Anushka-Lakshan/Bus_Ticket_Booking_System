<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin_layout.Master" AutoEventWireup="true" CodeBehind="admin_DB_main.aspx.cs" Inherits="SLTB.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.1/css/all.min.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_content" runat="server">
    
    
    <style>
        .card {
            height: 200px;
        }

        .card-link {
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100%;
            text-decoration: none;
        }
    </style>
<main role="main" class="col-9 ml-sm-auto col-lg-10 px-md-4">
    <div class="dashboard-header">
        <h1 class="h2">Dashboard</h1>
        <p>SLTB Administrator dashboard.</p>
    </div>
    <div class="row">
            <div class="col-md-4 mb-4">
                <div class="card bg-primary">
                    <a href="/admin/admin_DB_destinations.aspx" class="card-link text-light">
                        <i class="fas fa-map-marker fa-3x mr-3"></i>
                        Destinations
                    </a>
                </div>
            </div>
            <div class="col-md-4 mb-4">
                <div class="card bg-secondary">
                    <a href="/admin/admin_DB_manageAgencies.aspx" class="card-link text-light">
                        <i class="fas fa-users fa-3x mr-3"></i>
                        Agencies
                    </a>
                </div>
            </div>
            
            <div class="col-md-4 mb-4">
                <div class="card bg-info">
                    <a href="/admin/admin_DB_manageAdmins.aspx" class="card-link text-light">
                        <!-- <i class="fas fa-cogs fa-3x mr-3"></i> -->
                        <i class="fas fa-crown fa-3x mr-3"></i>
                        Admins
                    </a>
                </div>
            </div>
            <div class="col-md-4 mb-4">
                <div class="card bg-success">
                    <a href="/admin/admin_DB_Bookings.aspx" class="card-link text-light">
                        <!-- <i class="fas fa-cogs fa-3x mr-3"></i> -->
                        <i class="fas fa-bookmark fa-3x mr-3"></i>
                        Bookings
                    </a>
                </div>
            </div>
            <!-- Add more cards for other admin functions -->
        </div>
</main>
</asp:Content>
