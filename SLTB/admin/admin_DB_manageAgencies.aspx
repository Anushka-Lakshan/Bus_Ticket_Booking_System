<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin_layout.Master" AutoEventWireup="true" CodeBehind="admin_DB_manageAgencies.aspx.cs" Inherits="SLTB.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_content" runat="server">
    <div class="dashboard-header">
        <h1 class="h2">Manage Agencies</h1>
        <p>Add, edit, delete Agencies.</p>
    </div>

    <div class="row">
        <div class="col-sm-5">

            <div class="card">
                <div class="card-header">Manage functions</div>
                <div class="card-body">
                        <div class="form-group">
                            <label for="name">ID</label>
                            <asp:TextBox ID="a_id" runat="server" class="form-control" placeholder="Id"></asp:TextBox>
                            
                        </div>
                    
                        <div class="form-group">
                            <label for="name">Name</label>
                            <asp:TextBox ID="a_name" runat="server" class="form-control" placeholder="Enter your name"></asp:TextBox>
                            
                        </div>
                        <div class="form-group">
                            <label for="username">Username</label>
                            
                            <asp:TextBox ID="a_username" runat="server" class="form-control" placeholder="Enter username"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="password">Password</label>
                            
                            <asp:TextBox ID="a_pass" runat="server" class="form-control" placeholder="Enter password" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="row">
                            <div class="col-3">
                                <asp:Button CssClass="btn btn-info btn-block" ID="find" runat="server" Text="Find" OnClick="find_Click" />
                            </div>
                            <div class="col-3">
                                <asp:Button ID="Button2" CssClass="btn btn-primary btn-block" runat="server" Text="Add" OnClick="Button2_Click" />
                            </div>
                            <div class="col-3">
                                <asp:Button ID="edit" CssClass="btn btn-success btn-block" runat="server" Text="Edit" OnClick="edit_Click" />
                            </div>
                            <div class="col-3">
                                <asp:Button ID="delete" CssClass="btn btn-danger btn-block" runat="server" Text="Delete" OnClick="delete_Click" />
                            </div>
                        </div>
                        
                        
                    
                </div>
            </div>
        </div>

        <div class="col-sm-7 ">
            <h3 class="text-center mb-3">Agency List</h3>
            <div class="row d-flex justify-content-center">

                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered p-2 mr-auto ml-auto dataTable">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="ID" />
                        <asp:BoundField DataField="name" HeaderText="Name" />
                        <asp:BoundField DataField="username" HeaderText="Username" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
