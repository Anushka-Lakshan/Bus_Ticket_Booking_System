<%@ Page Title="" Language="C#" MasterPageFile="~/agency/agency_layout.Master" AutoEventWireup="true" CodeBehind="agency_DB_schedules.aspx.cs" Inherits="SLTB.agency.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="main_content" ContentPlaceHolderID="main_content" runat="server">
    <div class="dashboard-header">
        <h1 class="h2">Manage Schedules</h1>
        <p>Add, edit, delete Schedules.</p>
    </div>

    <div class="row">
        <div class="col-sm-6 p-2">

                <div class="row mb-2">
                    
                    <label class="">Schedules ID</label>
                    <div class="form-group">
                        <div class="input-group">
                            <asp:TextBox CssClass="form-control" ID="sche_id" runat="server" placeholder="ID" TextMode="Number"></asp:TextBox>
                            <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click"  />
                        </div>
                    </div>
                </div>
            
                <div class="row">
                    <div class="col-6">
                        <label>From</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:DropDownList ID="start_des" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="-- Select Destination --" Value=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-6">
                        <label>To</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:DropDownList ID="end_des" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="-- Select Destination --" Value=""></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-6">
                        <label>Start time</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox ID="time" TextMode="Time" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-6">
                        <label>Seats</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox ID="seats" TextMode="Number" runat="server" min="1"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    
                </div>
            
            <div class="row">
                <div class="col-4">
                    <asp:Button ID="Button2" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button2_Click"  />
                </div>
                <div class="col-4">
                    <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button3_Click"  />
                </div>
                <div class="col-4">
                    <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button4_Click"  />
                </div>
            </div>
        </div>
        <div class="col-sm-6">
            <h3 class="text-center mb-3">Schedules List</h3>
            <div class="row d-flex justify-content-center">
                <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered p-2 dataTable" runat="server"  AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="ID" />
                        <asp:BoundField DataField="start_destination" HeaderText="From" />
                        <asp:BoundField DataField="end_destination" HeaderText="To" />
                        <asp:BoundField DataField="start_time" HeaderText="time" />
                        <asp:BoundField DataField="agency_name" HeaderText="agecy name" />
                        <asp:BoundField DataField="seat" HeaderText="seats" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    
    

</asp:Content>
