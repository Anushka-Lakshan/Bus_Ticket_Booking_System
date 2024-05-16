<%@ Page Title="" Language="C#" MasterPageFile="~/main_layout.Master" AutoEventWireup="true" CodeBehind="Book_step2.aspx.cs" Inherits="SLTB.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_content" runat="server">
    <div class="row justify-content-center">
      <div class="col-md-6 p-3">

          <h2>
              <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> > <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

          </h2>

          <p class="text-muted ">Date : <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></p>
          <br />

          <p>Please select bus to proceed ></p>
          <br />

          <div class="form-row">
              <asp:RadioButtonList ID="busSchedules" runat="server" CssClass="select_bus ml-auto mr-auto"></asp:RadioButtonList>
          </div>
          <br />
          <div class="form-row">
            <div class="col-md-12 text-center">
              
                <asp:Button ID="Button1" runat="server" Text="Book Ticket" class="btn btn-primary" OnClick="Button1_Click" />
            </div>
          </div>
        
      </div>
    </div>

    <style>
        .select_bus tr{
            padding: 10px;
            
            border-radius: 5px;
        }

        .select_bus td > input{
            display: inline-block;
            margin-right: 10px;
        }
    </style>
</asp:Content>
