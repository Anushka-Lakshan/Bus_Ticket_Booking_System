<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin_layout.Master" AutoEventWireup="true" CodeBehind="admin_DB_Bookings.aspx.cs" Inherits="SLTB.admin.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- DataTables CSS -->
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/2.0.3/css/dataTables.bootstrap4.min.css">

    <!-- jQuery (required for DataTables) -->
    <script src="https://cdn.datatables.net/2.0.3/js/dataTables.min.js"></script>

    <!-- DataTables JavaScript -->
    <script src="https://cdn.datatables.net/2.0.3/js/dataTables.bootstrap4.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_content" runat="server">
    <div class="dashboard-header">
        <h1 class="h2 mb-3">All Bookings</h1>

    </div>
    <br />


    <div class="row d-flex justify-content-center w-100">
        <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered p-2 dataTable" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="date" HeaderText="Date" />
                <asp:BoundField DataField="NIC" HeaderText="NIC" />
                <asp:BoundField DataField="B_name" HeaderText="Name" />
                <asp:BoundField DataField="tel" HeaderText="Telephone" />
                <asp:BoundField DataField="seat" HeaderText="Seats" />
                <asp:BoundField DataField="start_destination" HeaderText="Start Destination" />
                <asp:BoundField DataField="end_destination" HeaderText="End Destination" />
                <asp:BoundField DataField="time" HeaderText="Time" />
                <asp:BoundField DataField="AgencyName" HeaderText="Agency Name" />

            </Columns>
        </asp:GridView>
    </div>



</asp:Content>
