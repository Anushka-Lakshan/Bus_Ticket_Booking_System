using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLTB
{
    public partial class Admin_layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["admin_id"].Equals(null))
                {
                    Response.Redirect("/admin_login.aspx");
                }
            }
            catch(Exception ex)
            {
                Response.Redirect("/admin_login.aspx");
            }
            
        }
    }
}