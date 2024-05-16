<%@ Page Title="" Language="C#" MasterPageFile="~/main_layout.Master" AutoEventWireup="true" CodeBehind="Book_step3.aspx.cs" Inherits="SLTB.WebForm9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_content" runat="server">
    <div class="row justify-content-center">
        <div class="col-md-6 p-3">

            <h2>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                >
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

            </h2>

            <p class="text-muted ">
                Date :
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            </p>
            <p class="text-muted ">
                Selected bus :
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            </p>
            <br />

            <div class="form-row">
                <div class="form-group col-md-6">
                    <label>Name</label>
                    <asp:TextBox ID="b_name" runat="server" class="form-control" placeholder="Enter your name"></asp:TextBox>
                    
                </div>
                <div class="form-group col-md-6">
                    <label>National Identity card Number (NIC)</label>
                    <asp:TextBox ID="NIC" runat="server" class="form-control" placeholder="Enter your NIC"></asp:TextBox>
                    
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-6">
                    <label>Telphone Number</label>
                    <asp:TextBox ID="tel" runat="server" class="form-control" placeholder="Enter your Telephone number"></asp:TextBox>
                    
                </div>
                <div class="form-group col-md-6">
                    <label>Number of seats you booking</label>
                    <asp:TextBox ID="seats" runat="server" class="form-control" placeholder="Enter number of seats" TextMode="Number" min="1" Max="5" value="1"></asp:TextBox>
                    
                    <small class="form-text text-muted">(Max 5 seats).</small>
                </div>
            </div>


            <br />
            <div class="form-row">
                <div class="col-md-12 text-center">

                    <asp:Button ID="Button1" runat="server" Text="Confirm Booking" class="btn btn-primary" OnClick="Button1_Click" />
                </div>
            </div>

        </div>
    </div>
</asp:Content>
