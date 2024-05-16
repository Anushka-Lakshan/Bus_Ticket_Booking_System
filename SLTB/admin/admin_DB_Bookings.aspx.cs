using SLTB.Business_logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLTB.admin
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Booking bk = new Booking();
                Schedule sh = new Schedule();
                Agency ag = new Agency();

                List<Booking> bookings = bk.GetAll();
                List<Schedule> schedules = sh.GetAll();
                List<Agency> agencies = ag.GetAll();

              //  Response.Write("<script>alert(' " + bookings.Count() + "  " + schedules.Count() + "');</script>");



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
                                schedule.start_time,
                                schedule.agency_id
                            };

                var result = from bs in query
                             join agency in agencies on bs.agency_id equals agency.id
                             select new 
                             {
                                 id = bs.id,
                                 date = bs.date,
                                 NIC = bs.NIC,
                                 B_name = bs.B_name,
                                 tel = bs.tel,
                                 seat = bs.seat,
                                 start_destination = bs.start_destination,
                                 end_destination = bs.end_destination,
                                 time = bs.start_time,
                                 AgencyName = agency.name,
                             };

                GridView1.DataSource = result.ToList();
                GridView1.DataBind();

            }
        }
    }
}