<%@ Page Title="" Language="C#" MasterPageFile="~/agency/agency_layout.Master" AutoEventWireup="true" CodeBehind="agency_DB_Bookings.aspx.cs" Inherits="SLTB.agency.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_content" runat="server">
    <div class="dashboard-header">
        <h1 class="h2 mb-3">Bookings for your Agency</h1>

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
                <asp:BoundField DataField="start_time" HeaderText="Start Time" />
               
                
            </Columns>
        </asp:GridView>
    </div>


</asp:Content>
