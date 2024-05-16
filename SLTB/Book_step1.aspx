<%@ Page Title="" Language="C#" MasterPageFile="~/main_layout.Master" AutoEventWireup="true" CodeBehind="Book_step1.aspx.cs" Inherits="SLTB.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_content" runat="server">
    <div class="row justify-content-center">
      <div class="col-md-6">
        
          <div class="form-row">
            <div class="col-md-6 mb-3">
              <label for="FromList">From:</label>
              
                <asp:DropDownList ID="FromList" CssClass="form-control FromList" runat="server" required="true" onchange="disableSelectedOption('FromList','ToList')">

                </asp:DropDownList> 
            </div>
            <div class="col-md-6 mb-3">
              <label for="ToList">To:</label>
              <asp:DropDownList ID="ToList" CssClass="form-control ToList" runat="server" required="true" onchange="disableSelectedOption('ToList', 'FromList')">

                </asp:DropDownList> 
            </div>
          </div>
          <div class="form-row">
            <div class="col-md-12 mb-3">
              <label for="travelDate">Travel Date</label>
              
                <asp:TextBox ID="dateBox" runat="server" TextMode="Date" CssClass="form-control datepicker"></asp:TextBox>
            </div>
          </div>
          <div class="form-row">
            <div class="col-md-12 text-center">
              
                <asp:Button ID="Button1" runat="server" Text="Search" class="btn btn-primary" OnClick="Button1_Click" />
            </div>
          </div>
        
      </div>
    </div>
<script>
    // Get today's date
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    today = yyyy + '-' + mm + '-' + dd;

    // Set the min attribute of the date picker textbox
    document.getElementById('<%= dateBox.ClientID %>').setAttribute('min', today);

    function disableSelectedOption(triggerId, targetId) {
        var trigger = document.getElementsByClassName(triggerId)[0];
        var target = document.getElementsByClassName(targetId)[0];

        // Ensure both trigger and target elements exist before proceeding
        if (!trigger || !target) {
            console.error('Trigger or target element not found');
            console.log(trigger);
            console.log(target);
            return;
        }

        // Enable all options in the target dropdown list
        for (var i = 0; i < target.options.length; i++) {
            target.options[i].disabled = false;
        }

        // Find the selected option in the trigger dropdown list
        var selectedValue = trigger.value;
        var selectedOption = target.querySelector('option[value="' + selectedValue + '"]');

        // Disable the selected option in the target dropdown list
        if (selectedOption) {
            selectedOption.disabled = true;
        }
    }

    // Attach onchange event handlers to dropdown lists
    var fromList = document.getElementById('FromList');
    var toList = document.getElementById('ToList');
    if (fromList) {
        fromList.addEventListener('change', function() {
            disableSelectedOption('FromList', 'ToList');
        });
    }
    if (toList) {
        toList.addEventListener('change', function() {
            disableSelectedOption('ToList', 'FromList');
        });
    }
</script>




</asp:Content>
