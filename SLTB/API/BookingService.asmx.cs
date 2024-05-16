using SLTB.Business_logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SLTB
{
    /// <summary>
    /// Summary description for BookingService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BookingService : System.Web.Services.WebService
    {

        private SqlConnection conn = Database.connect();

        [WebMethod]
        public bool insert(string date, string NIC, string B_name, string tel, int schedule_id, int seat)
        {
            String query = "INSERT INTO booking (B_date,NIC,B_name,tel,schedule_id,seats) VALUES (@B_date,@NIC,@B_name,@tel,@schedule_id,@seats)";

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@B_date", date);
                cmd.Parameters.AddWithValue("@NIC", NIC);
                cmd.Parameters.AddWithValue("@B_name", B_name);
                cmd.Parameters.AddWithValue("@tel", tel);
                cmd.Parameters.AddWithValue("@schedule_id", schedule_id);
                cmd.Parameters.AddWithValue("@seats", seat);


                int i = cmd.ExecuteNonQuery();


                return i > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Inserting Booking failed: " + ex.Message);
                return false;
            }
        }

        [WebMethod]
        public List<Booking> GetAll()
        {
            List<Booking> schedules = new List<Booking>();

            string query = "SELECT * FROM booking";

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);


                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Booking foundBooking = new Booking();
                    foundBooking.id = dr.GetInt32(0);
                    foundBooking.date = dr.GetString(1);
                    foundBooking.NIC = dr.GetString(2);
                    foundBooking.B_name = dr.GetString(3);
                    foundBooking.tel = dr.GetString(4);
                    foundBooking.schedule_id = dr.GetInt32(5);
                    foundBooking.seat = dr.GetInt32(6);


                    schedules.Add(foundBooking);
                }

                dr.Close();
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Error retrieving Bookings: " + ex.Message);
            }

            return schedules;
        }

        [WebMethod]
        public List<Booking> GetAllfromAgency(int agecy_id)
        {
            List<Booking> schedules = new List<Booking>();

            string query = "SELECT * FROM booking WHERE schedule_id IN(SELECT id FROM schedule WHERE agency_id = @agency); ";

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@agency", agecy_id);


                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Booking foundBooking = new Booking();
                    foundBooking.id = dr.GetInt32(0);
                    foundBooking.date = dr.GetString(1);
                    foundBooking.NIC = dr.GetString(2);
                    foundBooking.B_name = dr.GetString(3);
                    foundBooking.tel = dr.GetString(4);
                    foundBooking.schedule_id = dr.GetInt32(5);
                    foundBooking.seat = dr.GetInt32(6);


                    schedules.Add(foundBooking);
                }

                dr.Close();
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Error retrieving Bookings: " + ex.Message);
            }

            return schedules;
        }
    }

}
