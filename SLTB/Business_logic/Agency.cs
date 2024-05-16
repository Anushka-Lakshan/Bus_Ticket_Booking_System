using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SLTB.Business_logic
{
    public class Agency
    {
        private SqlConnection conn = Database.connect();
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public bool insert()
        {
            string query = "INSERT INTO agency (a_name,a_username,password) VALUES (@name,@username,@pass)";

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@name", this.name);
                cmd.Parameters.AddWithValue("@username", this.username);

                string hashedPass = PasswordHasher.HashPassword(this.password);
                cmd.Parameters.AddWithValue("@pass", hashedPass);

                int i = cmd.ExecuteNonQuery();

                conn.Close();

                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Write("Inserting failed " + ex.Message);
                return false;
            }

           

        }

        public bool update()
        {
            string query = "UPDATE agency SET a_name = @name, a_username = @username, password = @pass WHERE id = @id";

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@name", this.name);
                cmd.Parameters.AddWithValue("@username", this.username);

                string hashedPass = PasswordHasher.HashPassword(this.password);
                cmd.Parameters.AddWithValue("@pass", hashedPass);

                cmd.Parameters.AddWithValue("@id", this.id);

                
                int i = cmd.ExecuteNonQuery();
                conn.Close(); // Close connection after executing the command

                return i > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Updating failed " + ex.Message);
                return false;
            }
        }

        public bool delete()
        {
            string query = "DELETE FROM agency WHERE id = @id";

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", this.id);

                
                int i = cmd.ExecuteNonQuery();
                conn.Close(); // Close connection after executing the command

                return i > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Deleting failed " + ex.Message);
                return false;
            }
        }

        public Agency find()
        {
            string query = "SELECT * FROM agency WHERE id = @id";
            Agency foundAgency = null;

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", this.id);

                
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    foundAgency = new Agency();
                    foundAgency.id = dr.GetInt32(0);
                    foundAgency.name = dr.GetString(1);
                    foundAgency.username = dr.GetString(2);
                    // You might not want to retrieve the password here for security reasons
                }

                dr.Close(); // Close data reader
                conn.Close(); // Close connection
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Finding agency failed: " + ex.Message);
            }

            return foundAgency;
        }

        public List<Agency> GetAll()
        {
            List<Agency> agencies = new List<Agency>();

            string query = "SELECT * FROM agency";

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
               

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Agency agency = new Agency();
                    agency.id = dr.GetInt32(0);
                    agency.name = dr.GetString(1);
                    agency.username = dr.GetString(2);
                    // You might not want to retrieve the password here for security reasons

                    agencies.Add(agency);
                }

                dr.Close(); // Close data reader
                conn.Close(); // Close connection
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Error retrieving agencies: " + ex.Message);
            }

            return agencies;
        }

        public Agency login_check()
        {

            string query = "SELECT * FROM agency WHERE a_username = @username AND password = @pass";

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@username", this.username);
                string hashedPass = PasswordHasher.HashPassword(this.password);
                cmd.Parameters.AddWithValue("@pass", hashedPass);

                SqlDataReader dr = cmd.ExecuteReader();

                
                Agency foundAgency = null;

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        
                            foundAgency = new Agency();
                            foundAgency.id = dr.GetInt32(0);
                            foundAgency.name = dr.GetString(1);
                            foundAgency.username = dr.GetString(2);
                            // You might not want to retrieve the password here for security reasons
                        
                    }
                }

                return foundAgency;

                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Agency Login check failed: " + ex.Message);
                return null;
            }
        }

    }
}