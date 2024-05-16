using SLTB.Business_logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLTB.agency
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Booking bk = new Booking();
                Schedule sh = new Schedule();

                List<Booking> bookings = bk.GetAllfromAgency(Convert.ToInt32(Session["agency_id"].ToString()));
                List<Schedule> schedules = sh.GetAll();

            //    Response.Write("<script>alert(' "+ bookings.Count() + "  "+ schedules.Count() + "');</script>");



                var query = from booking in bookings
                            join schedule in schedules on booking.schedule_id equals schedule.id
                            select new
                            {
                                booking.id,
                                booking.date,
                                booking.NIC,
                                booking.B_name,
                                booking.tel,
                                booking.seat,
                                schedule.start_destination,
                                schedule.end_destination,
                                schedule.start_time
                            };

                GridView1.DataSource = query.ToList();
                GridView1.DataBind();

            }
        }
    }
}