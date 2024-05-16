using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SLTB.Business_logic
{
    public class Booking
    {
        private SqlConnection conn = Database.connect();
        public int id { get; set; }
        public string date { get; set; }
        public string NIC { get; set; }
        public string B_name { get; set; }
        public int schedule_id { get; set; }
        public string tel { get; set; }
        public int seat { get; set; }

        public bool insert()
        {
            
            webAPI.BookingService bs = new webAPI.BookingService();

            return bs.insert(date, NIC, B_name, tel, schedule_id, seat);

            
        }


        public List<Booking> GetAll()
        {
            

            webAPI.BookingService bs = new webAPI.BookingService();

            List<webAPI.Booking> data = bs.GetAll().ToList();

            List<Booking> bookings = new List<Booking>();

            foreach (var webAPIBooking in data)
            {
                Booking booking = new Booking
                {
                    // Assign properties from webAPIBooking to Booking
                    id = webAPIBooking.id,
                    date = webAPIBooking.date,
                    NIC = webAPIBooking.NIC,
                    B_name = webAPIBooking.B_name,
                    tel = webAPIBooking.tel,
                    schedule_id = webAPIBooking.schedule_id,
                    seat = webAPIBooking.seat
                };

                bookings.Add(booking);
            }

            return bookings;
        }

        public List<Booking> GetAllfromAgency(int agecy_id)
        {
            //  List<Booking> schedules = new List<Booking>();

            //  string query = "SELECT * FROM booking WHERE schedule_id IN(SELECT id FROM schedule WHERE agency_id = @agency); ";

            //  try
            //  {
            //     SqlCommand cmd = new SqlCommand(query, conn);
            //
            //     cmd.Parameters.AddWithValue("@agency", agecy_id);


            //     SqlDataReader dr = cmd.ExecuteReader();

            //     while (dr.Read())
            //     {
            //         Booking foundBooking = new Booking();
            //         foundBooking.id = dr.GetInt32(0);
            //         foundBooking.date = dr.GetString(1);
            //         foundBooking.NIC = dr.GetString(2);
            //         foundBooking.B_name = dr.GetString(3);
            //          foundBooking.tel = dr.GetString(4);
            //         foundBooking.schedule_id = dr.GetInt32(5);
            //         foundBooking.seat = dr.GetInt32(6);


            //       schedules.Add(foundBooking);
            //    }

            //    dr.Close();
            //    conn.Close();
            //   }
            //    catch (Exception ex)
            //    {
            //        System.Diagnostics.Debug.Write("Error retrieving Bookings: " + ex.Message);
            //    }

            //    return schedules;

            webAPI.BookingService bs = new webAPI.BookingService();

            List<webAPI.Booking> data = bs.GetAllfromAgency(agecy_id).ToList();

            List<Booking> bookings = new List<Booking>();

            foreach (var webAPIBooking in data)
            {
                Booking booking = new Booking
                {
                    // Assign properties from webAPIBooking to Booking
                    id = webAPIBooking.id,
                    date = webAPIBooking.date,
                    NIC = webAPIBooking.NIC,
                    B_name = webAPIBooking.B_name,
                    tel = webAPIBooking.tel,
                    schedule_id = webAPIBooking.schedule_id,
                    seat = webAPIBooking.seat
                };

                bookings.Add(booking);
            }

            return bookings;
        }
    }
}