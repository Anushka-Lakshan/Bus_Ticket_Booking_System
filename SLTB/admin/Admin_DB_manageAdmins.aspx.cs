using SLTB.Business_logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLTB.admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            refresh_table();
        }

        private void refresh_table()
        {
            Admin ad = new Admin();
            GridView2.DataSource = ad.GetAll();
            GridView2.DataBind();
        }

        protected void find_Click(object sender, EventArgs e)
        {
            String id = a_id.Text.Trim();

            if (id.Equals(""))
            {
                Response.Write("<script>alert('Please enter Admin ID');</script>");
                return;
            }

            Admin ag = new Admin();
            ag.id = Convert.ToInt32(id);
            Admin Admin = ag.find();
            if (Admin == null)
            {
                Response.Write("<script>alert('Admin not found!');</script>");
            }
            else
            {
                a_name.Text = Admin.name;
                a_username.Text = Admin.username;
                a_pass.Text = Admin.password;
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

            Admin ag = new Admin();
            ag.name = name;
            ag.username = username;
            ag.password = password;

            if (ag.insert())
            {
                Response.Write("<script>alert('Admin added successfully!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Admin adding failed!');</script>");
            }

            refresh_table();
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

            Admin ag = new Admin();
            ag.id = Convert.ToInt32(id);
            ag.name = name;
            ag.username = username;
            ag.password = password;

            if (ag.update())
            {
                Response.Write("<script>alert('Admin updated successfully!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Admin updating failed!');</script>");
            }

            refresh_table();
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            String id = a_id.Text.Trim();

            if (id.Equals(""))
            {
                Response.Write("<script>alert('Please enter Admin ID');</script>");
                return;
            }

            Admin ag = new Admin();
            ag.id = Convert.ToInt32(id);

            if (ag.delete())
            {
                Response.Write("<script>alert('Admin deleted successfully!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Admin deleting failed!');</script>");
            }

            refresh_table();
        }
    }
}