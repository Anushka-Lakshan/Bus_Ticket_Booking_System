using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SLTB.Business_logic
{
    public class Schedule
    {
        private SqlConnection conn = Database.connect();
        public int id { get; set; }
        public string start_destination { get; set; }
        public string end_destination { get; set; }
        public string start_time { get; set; }
        public int agency_id { get; set; }
        public string agency_name { get; set; }
        public int seat { get; set; }

        public bool insert()
        {
            String query = "INSERT INTO schedule (start_d,end_d,start_time,agency_id,agency_name ,seats) VALUES (@start_d,@end_d,@start_time,@agency_id,@agency_name,@seats)";

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@start_d", this.start_destination);
                cmd.Parameters.AddWithValue("@end_d", this.end_destination);
                cmd.Parameters.AddWithValue("@start_time", this.start_time);
                cmd.Parameters.AddWithValue("@agency_id", this.agency_id);
                cmd.Parameters.AddWithValue("@agency_name", this.agency_name);
                cmd.Parameters.AddWithValue("@seats", this.seat);


                int i = cmd.ExecuteNonQuery();
                conn.Close();

                return i > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Inserting schedule failed: " + ex.Message);
                return false;
            }
        }

        public bool Edit()
        {
            string query = "UPDATE schedule SET start_d = @start_d, end_d = @end_d, start_time = @start_time, agency_id = @agency_id, agency_name = @agency_name, seats = @seats WHERE id = @id";

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@start_d", this.start_destination);
                cmd.Parameters.AddWithValue("@end_d", this.end_destination);
                cmd.Parameters.AddWithValue("@start_time", this.start_time);
                cmd.Parameters.AddWithValue("@agency_id", this.agency_id);
                cmd.Parameters.AddWithValue("@agency_name", this.agency_name);
                cmd.Parameters.AddWithValue("@seats", this.seat);
                cmd.Parameters.AddWithValue("@id", this.id);


                int i = cmd.ExecuteNonQuery();
                conn.Close();

                return i > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Editing schedule failed: " + ex.Message);
                return false;
            }
        }


        public bool Delete()
        {
            string query = "DELETE FROM schedule WHERE id = @id";

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", this.id);


                int i = cmd.ExecuteNonQuery();
                conn.Close();

                return i > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Deleting schedule failed: " + ex.Message);
                return false;
            }
        }

        public Schedule find()
        {
            string query = "SELECT * FROM schedule WHERE id = @id";
            Schedule foundSchedule = null;

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", this.id);


                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    foundSchedule = new Schedule();
                    foundSchedule.id = dr.GetInt32(0);
                    foundSchedule.start_destination = dr.GetString(1);
                    foundSchedule.end_destination = dr.GetString(2);
                    foundSchedule.start_time = dr.GetString(3);
                    foundSchedule.agency_id = dr.GetInt32(4);
                    foundSchedule.agency_name = dr.GetString(5);
                    foundSchedule.seat = dr.GetInt32(6);


                }

                dr.Close(); // Close data reader
                conn.Close(); // Close connection
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Finding Schedule failed: " + ex.Message);
            }

            return foundSchedule;
        }

        public List<Schedule> GetAll()
        {
            List<Schedule> schedules = new List<Schedule>();

            string query = "SELECT * FROM schedule";

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);


                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Schedule foundSchedule = new Schedule();
                    foundSchedule.id = dr.GetInt32(0);
                    foundSchedule.start_destination = dr.GetString(1);
                    foundSchedule.end_destination = dr.GetString(2);
                    foundSchedule.start_time = dr.GetString(3);
                    foundSchedule.agency_id = dr.GetInt32(4);
                    foundSchedule.agency_name = dr.GetString(5);
                    foundSchedule.seat = dr.GetInt32(6);

                    schedules.Add(foundSchedule);
                }

                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Error retrieving schedules: " + ex.Message);
            }

            return schedules;
        }

        public List<Schedule> FindBus(String from, String to, String date)
        {
            List<Schedule> schedules = new List<Schedule>();

            string query = "SELECT s.id, s.start_d, s.end_d, s.start_time, s.seats - ISNULL(b.total_seats_booked, 0) " +
                "AS remaining_seats FROM schedule s LEFT JOIN (SELECT booking.schedule_id, SUM(seats) AS total_seats_booked FROM booking " +
                "WHERE B_date = @date GROUP BY schedule_id) b ON s.id = b.schedule_id WHERE " +
                "s.start_d = @from AND s.end_d = @to ";


            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@to", to);
                cmd.Parameters.AddWithValue("@date", date);


                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Schedule foundSchedule = new Schedule();
                    foundSchedule.id = dr.GetInt32(0);
                    foundSchedule.start_destination = dr.GetString(1);
                    foundSchedule.end_destination = dr.GetString(2);
                    foundSchedule.start_time = dr.GetString(3);
                    
                    foundSchedule.seat = dr.GetInt32(4);

                    schedules.Add(foundSchedule);
                }

                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Error retrieving schedules: " + ex.Message);
            }

            return schedules;
        }

    }
}