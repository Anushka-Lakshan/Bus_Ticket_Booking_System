using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SLTB.Business_logic;

namespace SLTB
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Click(object sender, EventArgs e)
        {
            String un = username.Text.Trim();
            String pass = password.Text.Trim();

            if(un == "" || pass == "")
            {
                Response.Write("<script> alert('Username and password requiered!')</script>");
                error_log.Visible = true;
                error_log.Text = "Username and password requiered!";
                return;
            }

            Admin ad = new Admin();
            ad.username = un;
            ad.password = pass;

            int id = ad.login_check();

            if(id > 0)
            {
                Session["admin_id"] = id;
                Response.Redirect("admin/admin_DB_main.aspx");
                Response.Write("<script>alert('Login successful!')</script>");
                return;
            }
            else
            {
                Response.Write("<script> alert('User not found!!')</script>");
                error_log.Visible = true;
                error_log.Text = "User not found!!";
            }
        }
    }
}