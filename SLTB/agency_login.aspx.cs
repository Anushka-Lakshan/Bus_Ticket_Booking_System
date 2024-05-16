using SLTB.Business_logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLTB
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void Button_Click(object sender, EventArgs e)
        {
            String un = username.Text.Trim();
            String pass = password.Text.Trim();

            Agency ag = new Agency();

            ag.username = un;
            ag.password = pass;

            

            Agency lg = ag.login_check();

            

            if(lg != null)
            {
               
                Session["agency_id"] = lg.id;
                Session["agency_name"] = lg.name;
                Response.Redirect("/agency/agency_DB_main.aspx");

                
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