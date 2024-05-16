using SLTB.Business_logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLTB
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["to"] == null || Session["from"] == null || Session["date"] == null || Session["schedule_id"] == null || Session["schedule"] == null)
            {
                // Session data not set, redirect user to Book_step1.aspx
                Response.Redirect("/Book_step1.aspx");
            }
            else
            {
                Label1.Text = Session["from"].ToString();
                Label2.Text = Session["to"].ToString();
                Label3.Text = Session["date"].ToString();
                Label4.Text = Session["schedule"].ToString();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = b_name.Text.Trim();
            string nic = NIC.Text.Trim();
            string telephone = tel.Text.Trim();
            int seatsBooked;

            // Validate Name field
            if (string.IsNullOrEmpty(name))
            {
                // Handle error: Name field is empty
                Response.Write("<script> alert('Name field is empty!!');</script>");
                return;
            }

            // Validate NIC field
            if (string.IsNullOrEmpty(nic) || nic.Length < 10)
            {
                // Handle error: NIC field is empty or length is not valid
                Response.Write("<script> alert('NIC field is empty or length is not valid');</script>");
                return;
            }

            // Validate Telephone field
            if (string.IsNullOrEmpty(telephone) || !IsValidTelephone(telephone))
            {
                // Handle error: Telephone field is empty or not valid
                Response.Write("<script> alert('Telephone field is empty or not valid');</script>");
                return;
            }

            // Validate Number of Seats field
            if (!int.TryParse(seats.Text.Trim(), out seatsBooked) || seatsBooked < 1 || seatsBooked > 5)
            {
                // Handle error: Seats field is empty, not a number, or not within valid range
                Response.Write("<script> alert('Seats field is empty, not a number, or not within valid range');</script>");
                return;
            }

            Booking bk = new Booking();

            bk.B_name = name;
            bk.NIC = nic;
            bk.tel = telephone;
            bk.seat = seatsBooked;
            bk.schedule_id = Convert.ToInt32(Session["schedule_id"].ToString());
            bk.date = Session["date"].ToString();

            if (bk.insert())
            {
                Session.Clear();
                Response.Redirect("/successPage.aspx");
                
            }
            else
            {
                Response.Write("<script> alert('something is wrong , plz contact admins');</script>");
            }
        }

        private bool IsValidTelephone(string telephone)
        {
            // Implement your own logic to validate telephone number format
            // For example, you can use regular expressions
            // For simplicity, let's assume a valid telephone number has 10 digits
            return telephone.Length == 10 && telephone.All(char.IsDigit);
        }
    }
}