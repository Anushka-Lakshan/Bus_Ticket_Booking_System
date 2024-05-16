using SLTB.Business_logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLTB.agency
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                refresh_table();

                Destination destination = new Destination();
                List<Destination> dsListStart = destination.GetAll();

                start_des.Items.Clear();
                end_des.Items.Clear();

                start_des.Items.Add(new ListItem("Select Destination", "0"));
                end_des.Items.Add(new ListItem("Select Destination", "0"));

                foreach (Destination ds in dsListStart)
                {
                    start_des.Items.Add(new ListItem(ds.name, ds.name));
                    end_des.Items.Add(new ListItem(ds.name, ds.name));
                }


            }

            

           // start_des.DataSource = dsListStart;
           // start_des.DataTextField = "name";
           // start_des.DataValueField = "name";
           // start_des.DataBind();

           // end_des.DataSource = dsListEnd;
           // end_des.DataTextField = "name";
           // end_des.DataValueField = "name";
           // end_des.DataBind();
        }

        private void refresh_table()
        {
            Schedule sc = new Schedule();
            List<Schedule> scList = sc.GetAll();

            GridView1.DataSource = scList;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            string start_d = start_des.SelectedValue;
            string end_d = end_des.SelectedValue;
            string s_time = time.Text.Trim();
            string poples = seats.Text.Trim();
            

            if(poples == "")
            {
                Response.Write("<script>alert('please enter valid seats');</script>");
                return;
            }

            int people = Convert.ToInt32(poples);

            if (start_d.Equals(end_d))
            {
                Response.Write("<script>alert('Start destination and end destination must be deferent');</script>");
                Response.Write("<script>alert('Start destination " + start_d + " and end destination " + end_d + " must be deferent');</script>");
                return;
            }

            
            DateTime timeValid;
            if (!DateTime.TryParseExact(s_time, "HH:mm", null, System.Globalization.DateTimeStyles.None, out timeValid))
            {
                Response.Write("<script>alert('please enter valid time');</script>");
                return;
            }
            
            if(people < 1)
            {
                Response.Write("<script>alert('please enter seat count!');</script>");
                return;
            }

            Schedule ch = new Schedule();
            ch.start_destination = start_d;
            ch.end_destination = end_d;
            ch.start_time = s_time;
            ch.seat = people;
            ch.agency_id = Convert.ToInt32(Session["agency_id"].ToString());
            ch.agency_name = Session["agency_name"].ToString();

            if (ch.insert())
            {
                Response.Write("<script>alert('Schedule added successfully!');</script>");
                refresh_table();
            }
            else
            {
                Response.Write("<script>alert('Schedule adding failed!');</script>");
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string start_d = start_des.SelectedValue;
            string end_d = end_des.SelectedValue;
            string s_time = time.Text.Trim();
            int people = Convert.ToInt32(seats.Text.Trim());
            int id = Convert.ToInt32(sche_id.Text.Trim());

            if (start_d == end_d)
            {
                Response.Write("<script>alert('Start destination and end destination must be deferent');</script>");
                return;
            }

            if (id == 0)
            {
                Response.Write("<script>alert('Please enter Schedule ID');</script>");
                return;
            }


            DateTime timeValid;
            if (!DateTime.TryParseExact(s_time, "HH:mm", null, System.Globalization.DateTimeStyles.None, out timeValid))
            {
                Response.Write("<script>alert('please enter valid time');</script>");
                return;
            }

            if (people < 1)
            {
                Response.Write("<script>alert('please enter seat count!');</script>");
                return;
            }

            if (!this.check_auth(id))
            {
                Response.Write("<script>alert(\"you can't change other agencies schedules!!\");</script>");
                return;
            }

            Schedule ch = new Schedule();
            ch.id = id;
            ch.start_destination = start_d;
            ch.end_destination = end_d;
            ch.start_time = s_time;
            ch.seat = people;
            ch.agency_id = Convert.ToInt32(Session["agency_id"].ToString());
            ch.agency_name = Session["agency_name"].ToString();

            if (ch.Edit())
            {
                Response.Write("<script>alert('Schedule Edited successfully!');</script>");
                refresh_table();
            }
            else
            {
                Response.Write("<script>alert('Schedule Edited failed!');</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(sche_id.Text.Trim());

            if (id == 0)
            {
                Response.Write("<script>alert('Please enter Schedule ID');</script>");
                return;
            }

            if (!this.check_auth(id))
            {
                Response.Write("<script>alert(\"you can't change other agencies schedules!!\");</script>");
                return;
            }

            Schedule ch = new Schedule();
            ch.id = id;

            if (ch.Delete())
            {
                Response.Write("<script>alert('Schedule deleted successfully!');</script>");
                refresh_table();
            }
            else
            {
                Response.Write("<script>alert('Schedule deleted failed!');</script>");
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(sche_id.Text.Trim());

            if (id == 0)
            {
                Response.Write("<script>alert('Please enter Schedule ID');</script>");
                return;
            }

            Schedule ch = new Schedule();
            ch.id = id;

            Schedule foundSch = ch.find();

            if (foundSch == null)
            {
                Response.Write("<script>alert('Schedule not found!');</script>");
                return;
            }

            start_des.SelectedValue = foundSch.start_destination;
            end_des.SelectedValue = foundSch.end_destination;
            time.Text = foundSch.start_time;
            seats.Text = Convert.ToString(foundSch.seat);
            
        }

        private bool check_auth(int id)
        {
            Schedule ch = new Schedule();
            ch.id = id;

            Schedule foundSch = ch.find();

            if (foundSch != null && foundSch.agency_id == Convert.ToInt32(Session["agency_id"].ToString()))
            {
                return true;
            }

            return false;
        }
    }
}