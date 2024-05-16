using SLTB.Business_logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLTB
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Destination destination = new Destination();
                List<Destination> dsListStart = destination.GetAll();

                FromList.Items.Clear();
                ToList.Items.Clear();

                FromList.Items.Add(new ListItem("Select Location", ""));
                ToList.Items.Add(new ListItem("Select Location", ""));

                foreach (Destination ds in dsListStart)
                {
                    FromList.Items.Add(new ListItem(ds.name, ds.name));
                    ToList.Items.Add(new ListItem(ds.name, ds.name));
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String from = FromList.SelectedValue.ToString();
            String To = ToList.SelectedValue.ToString();

            if(from == "" || To == "")
            {
                Response.Write("<script> alert('Please Provide both To and From locations !!');</script> ");
                return;
            }

            if(from == To)
            {
                Response.Write("<script> alert('From location and To Locations must be defferent!!');</script> ");
                return;
            }


            DateTime selectedDate;
            if (DateTime.TryParse(dateBox.Text, out selectedDate))
            {
                if (selectedDate >= DateTime.Today)
                {
                    string date = dateBox.Text.Trim();
                    Session["to"] = To;
                    Session["from"] = from;
                    Session["date"] = date;

                    Response.Redirect("/Book_step2.aspx");
                }
                else
                {
                    Response.Write("<script> alert('Please select a date today or in the future.!!');</script> ");
                    return;
                    
                }
            }
            else
            {
                Response.Write("<script> alert('Invalid date format.Please enter a valid date.!!');</script> ");
                return;
                
            }
        }
    }
}