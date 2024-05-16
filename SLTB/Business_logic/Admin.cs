using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SLTB.Business_logic
{
    public class Admin
    {
        private SqlConnection conn = Database.connect();
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public bool insert()
        {
            string query = "INSERT INTO admins (ad_name,ad_username,password) VALUES (@name,@username,@pass)";

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
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Inserting failed " + ex.Message);
                return false;
            }

        }


        public bool update()
        {
            string query = "UPDATE admins SET ad_name = @name, ad_username = @username, password = @pass WHERE id = @id";

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
            string query = "DELETE FROM admins WHERE id = @id";

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

        public Admin find()
        {
            string query = "SELECT * FROM admins WHERE id = @id";
            Admin foundAdmin = null;

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", this.id);


                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    foundAdmin = new Admin();
                    foundAdmin.id = dr.GetInt32(0);
                    foundAdmin.name = dr.GetString(1);
                    foundAdmin.username = dr.GetString(2);
                    // You might not want to retrieve the password here for security reasons
                }

                dr.Close(); // Close data reader
                conn.Close(); // Close connection
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Finding admin failed: " + ex.Message);
            }

            return foundAdmin;
        }


        public List<Admin> GetAll()
        {
            List<Admin> admins = new List<Admin>();

            string query = "SELECT * FROM Admins";

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Admin admi = new Admin();
                    admi.id = dr.GetInt32(0);
                    admi.name = dr.GetString(1);
                    admi.username = dr.GetString(2);
                    // You might not want to retrieve the password here for security reasons

                    admins.Add(admi);
                }

                dr.Close(); // Close data reader
                conn.Close(); // Close connection
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Error retrieving agencies: " + ex.Message);
            }

            return admins;
        }


        public int login_check()
        {

            string query = "SELECT * FROM admins WHERE ad_username = @username AND password = @pass";

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@username", this.username);
                string hashedPass = PasswordHasher.HashPassword(this.password);
                cmd.Parameters.AddWithValue("@pass", hashedPass);

                SqlDataReader dr = cmd.ExecuteReader();

                int admin_id = -1;

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        admin_id = dr.GetInt32(0);
                    }
                }

                return admin_id;


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Agency Login check failed: " + ex.Message);
                return -1;
            }
        }
    }
}