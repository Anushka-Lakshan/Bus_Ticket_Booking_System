using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLTB.agency
{
    public partial class agency_layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["agency_id"].Equals(null))
                {
                    Response.Redirect("/agency_login.aspx");
                }
            }
            catch (Exception ex)
            {
                 Response.Redirect("/agency_login.aspx");
            }
        }
    }
}