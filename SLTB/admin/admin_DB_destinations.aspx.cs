using SLTB.Business_logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLTB
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            refresh_table();
        }

        private void refresh_table()
        {
            Destination ds = new Destination();
            GridView1.DataSource = ds.GetAll();
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            String name = des_name.Text.Trim();

            if (name.Equals(""))
            {
                Response.Write("<script>alert('Please enter Destination name');</script>");
                return;
            }

            Destination ds = new Destination();
            ds.name = name;
            if (ds.Insert())
            {
                Response.Write("<script>alert('Destination added successfully!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Destination adding Failed!');</script>");
            }

            refresh_table();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String id = des_id.Text.Trim();

            if (id.Equals(""))
            {
                Response.Write("<script>alert('Please enter ID');</script>");
                return;
            }

            int int_id = Convert.ToInt32(id);

            Destination ds = new Destination();
            ds.id = int_id;

            Destination dss = ds.find();

            if(dss == null)
            {
                Response.Write("<script>alert('can't find the destination!');</script>");
                return;
            }

            des_name.Text = dss.name;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String id = des_id.Text.Trim();
            String name = des_name.Text.Trim();

            if (name.Equals("") || id.Equals(""))
            {
                Response.Write("<script>alert('Please enter Destination name and id');</script>");
                return;
            }

            int int_id = Convert.ToInt32(id);
            Destination ds = new Destination();
            ds.name = name;
            ds.id = int_id;

            if (ds.Edit())
            {
                Response.Write("<script>alert('Destination updated successfully!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Destination update Failed!');</script>");
            }

            refresh_table();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            String id = des_id.Text.Trim();

            if (id.Equals(""))
            {
                Response.Write("<script>alert('Please enter Destination id');</script>");
                return;
            }

            Destination ds = new Destination();
            ds.id = Convert.ToInt32(id);

            if (ds.Delete())
            {
                Response.Write("<script>alert('Destination deleted successfully!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Destination deleting Failed!');</script>");
            }

            refresh_table();
        }
    }
}