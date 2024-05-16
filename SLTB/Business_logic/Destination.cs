using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SLTB.Business_logic
{
    public class Destination
    {
        private SqlConnection conn = Database.connect();
        public int id { get; set; }
        public string name { get; set; }

        public bool Insert()
        {
            string query = "INSERT INTO destination (d_name) VALUES (@name)";

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", this.name);

                 
                int i = cmd.ExecuteNonQuery();
                conn.Close();

                return i > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Inserting destination failed: " + ex.Message);
                return false;
            }
        }

        public bool Edit()
        {
            string query = "UPDATE destination SET d_name = @name WHERE id = @id";

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", this.name);
                cmd.Parameters.AddWithValue("@id", this.id);

                 
                int i = cmd.ExecuteNonQuery();
                conn.Close();

                return i > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Editing destination failed: " + ex.Message);
                return false;
            }
        }

        public bool Delete()
        {
            string query = "DELETE FROM destination WHERE id = @id";

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
                System.Diagnostics.Debug.Write("Deleting destination failed: " + ex.Message);
                return false;
            }
        }

        public Destination find()
        {
            string query = "SELECT * FROM destination WHERE id = @id";
            Destination foundDestination = null;

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", this.id);


                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    foundDestination = new Destination();
                    foundDestination.id = dr.GetInt32(0);
                    foundDestination.name = dr.GetString(1);

                    
                }

                dr.Close(); // Close data reader
                conn.Close(); // Close connection
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Finding admin failed: " + ex.Message);
            }

            return foundDestination;
        }

        public List<Destination> GetAll()
        {
            List<Destination> destinations = new List<Destination>();

            string query = "SELECT * FROM destination";

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                 
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Destination destination = new Destination();
                    destination.id = dr.GetInt32(0);
                    destination.name = dr.GetString(1);

                    destinations.Add(destination);
                }

                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Error retrieving destinations: " + ex.Message);
            }

            return destinations;
        }
    }
}