<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin_layout.Master" AutoEventWireup="true" CodeBehind="admin_DB_destinations.aspx.cs" Inherits="SLTB.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_content" runat="server">
    <div class="dashboard-header">
        <h1 class="h2">Manage destinations</h1>
        <p>Add, edit, delete destinations.</p>
    </div>

    <div class="row">
        <div class="col-sm-6">
            <h3 class="text-center mb-2">Manage functions </h3>

            <div class="row">
                <div class="col-md-4">
                    <label>Destination ID</label>
                    <div class="form-group">
                        <div class="input-group">
                            <asp:TextBox CssClass="form-control" ID="des_id" runat="server" placeholder="ID" TextMode="Number"></asp:TextBox>
                            <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                        </div>
                    </div>
                </div>

                <div class="col-md-8">
                    <label>Destination name</label>
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="des_name" runat="server" placeholder="Destination Name"></asp:TextBox>

                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-4">
                    <asp:Button ID="Button2" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button2_Click" />
                </div>
                <div class="col-4">
                    <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button3_Click" />
                </div>
                <div class="col-4">
                    <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button4_Click" />
                </div>
            </div>
        </div>
        <div class="col-sm-6">
            <h3 class="text-center mb-3">Destination List</h3>
            <div class="row d-flex justify-content-center">
                <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered p-2 dataTable" runat="server"></asp:GridView>
            </div>
        </div>
    </div>
    
    


</asp:Content>
