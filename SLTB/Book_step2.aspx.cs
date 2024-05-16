using SLTB.Business_logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLTB
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["to"] == null || Session["from"] == null || Session["date"] == null)
            {
                // Session data not set, redirect user to Book_step1.aspx
                Response.Redirect("/Book_step1.aspx");
            }
            else
            {
                Label1.Text = Session["from"].ToString();
                Label2.Text = Session["to"].ToString();
                Label3.Text = Session["date"].ToString();

            }

            if (!IsPostBack)
            {
                
                BindScheduleList();
            }
        }

        private void BindScheduleList()
        {
            busSchedules.Items.Clear();

            Schedule sh = new Schedule();
            List<Schedule> buses = sh.FindBus(Session["from"].ToString(), Session["to"].ToString(), Session["date"].ToString());

            foreach(Schedule bus in buses)
            {
                ListItem item = new ListItem();

                item.Text = $"{bus.start_destination} to {bus.end_destination} at  {bus.start_time} ({bus.seat} seats remaining)";
                item.Value = bus.id.ToString();

                busSchedules.Items.Add(item);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(busSchedules.SelectedItem != null)
            {
                string selectedValue = busSchedules.SelectedValue.ToString();
                string selectedText = busSchedules.SelectedItem.Text;
                Session["schedule_id"] = selectedValue;
                Session["schedule"] = selectedText;

                Response.Redirect("/Book_step3.aspx");
            }
            else
            {
                Response.Write("<script> alert('Please select bus schedule to proceed');</script> ");
                return;
            }
        }
    }
}