using SLTB.Business_logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLTB
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Agency agency = new Agency();
            GridView2.DataSource = agency.GetAll();
            GridView2.DataBind();
        }

        protected void find_Click(object sender, EventArgs e)
        {
            String id = a_id.Text.Trim();

            if (id.Equals(""))
            {
                Response.Write("<script>alert('Please enter Agency ID');</script>");
                return;
            }

            Agency ag = new Agency();
            ag.id = Convert.ToInt32(id);
            Agency agency = ag.find();
            if (agency == null)
            {
                Response.Write("<script>alert('Agency not found!');</script>");
            }
            else
            {
                a_name.Text = agency.name;
                a_username.Text = agency.username;
                a_pass.Text = agency.password;
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            String name = a_name.Text.Trim();
            String username = a_username.Text.Trim();
            String password = a_pass.Text.Trim();

            if (name.Equals("") || username.Equals("") || password.Equals(""))
            {
                Response.Write("<script>alert('Please fill in all fields!');</script>");
                return;
            }

            Agency ag = new Agency();
            ag.name = name;
            ag.username = username;
            ag.password = password;

            if (ag.insert())
            {
                Response.Write("<script>alert('Agency added successfully!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Agency adding failed!');</script>");
            }
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            String id = a_id.Text.Trim();
            String name = a_name.Text.Trim();
            String username = a_username.Text.Trim();
            String password = a_pass.Text.Trim();

            if (name.Equals("") || username.Equals("") || password.Equals("") || id.Equals(""))
            {
                Response.Write("<script>alert('Please fill in all fields!');</script>");
                return;
            }

            Agency ag = new Agency();
            ag.id = Convert.ToInt32(id);
            ag.name = name;
            ag.username = username;
            ag.password = password;

            if (ag.update())
            {
                Response.Write("<script>alert('Agency updated successfully!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Agency updating failed!');</script>");
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            String id = a_id.Text.Trim();

            if (id.Equals(""))
            {
                Response.Write("<script>alert('Please enter Agency ID');</script>");
                return;
            }

            Agency ag = new Agency();
            ag.id = Convert.ToInt32(id);

            if (ag.delete())
            {
                Response.Write("<script>alert('Agency deleted successfully!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Agency deleting failed!');</script>");
            }
        }
    }
}