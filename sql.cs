using System;
// using MySql.Data.MySqlClient;  // Uncomment when DB is installed

namespace TestAutomation.Helpers
{
    public class SQLHelper
    {
        // Dummy connection string (replace when DB available)
        private static string connectionString = "server=localhost;database=employeeDB;user=root;password=yourpassword;";

        // --- Fetch URL ---
        public static string GetURL()
        {
            Console.WriteLine("-- Dummy SQL Command --");
            Console.WriteLine("SELECT url FROM application_urls WHERE id = 1;");

            // Return dummy value for now
            return "https://opensource-demo.orangehrmlive.com/";

            /*
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT url FROM application_urls WHERE id = 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                object result = cmd.ExecuteScalar();
                return result?.ToString();
            }
            */
        }

        // --- Fetch Username ---
        public static string GetUsername()
        {
            Console.WriteLine("-- Dummy SQL Command --");
            Console.WriteLine("SELECT username FROM users WHERE id = 1;");

            return "Admin"; // dummy

            /*
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT username FROM users WHERE id = 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                object result = cmd.ExecuteScalar();
                return result?.ToString();
            }
            */
        }

        // --- Fetch Password ---
        public static string GetPassword()
        {
            Console.WriteLine("-- Dummy SQL Command --");
            Console.WriteLine("SELECT password FROM users WHERE id = 1;");

            return "admin123"; // dummy

            /*
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT password FROM users WHERE id = 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                object result = cmd.ExecuteScalar();
                return result?.ToString();
            }
            */
        }
    }
}
