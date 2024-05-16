<%@ Page Title="" Language="C#" MasterPageFile="~/main_layout.Master" AutoEventWireup="true" CodeBehind="successPage.aspx.cs" Inherits="SLTB.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet"/>
  <!-- Font Awesome CSS -->
  <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet"/>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
  <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/js/all.min.js"></script>
</head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_content" runat="server">
    <div class="container mt-5">
    <div class="card text-center">
      <div class="card-body">
        <h5 class="card-title">Booking Successful!</h5>
        <p class="card-text">Your booking has been successfully created.</p>
        <i class="fas fa-check-circle fa-5x text-success mb-3"></i>
        <a href="/Index.aspx" class="btn btn-primary">Go to Home</a>
      </div>
    </div>
  </div>
</asp:Content>
