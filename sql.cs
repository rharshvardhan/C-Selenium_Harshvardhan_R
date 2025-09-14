using System;
//using MySql.Data.MySqlClient;  // Uncomment when DB is installed

namespace TestAutomation.Helpers
{
    public class SQLHelper
    {
        // this is dummy connection string
        private static string connectionString = "server=localhost;database=employeeDB;user=root;password=yourpassword;";

        // Dummy Fetch Example
        public static void FetchEmployee(string employeeName)
        {
            Console.WriteLine($"-- Dummy SQL Command --");
            Console.WriteLine($"SELECT * FROM employees WHERE name = '{employeeName}';");
            
            // Real code (enable when MySQL available):
            /*
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = $"SELECT * FROM employees WHERE name='{employeeName}'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["name"].ToString());
                }
            }
            */
        }

        public static void FetchURL(string url)
        {
            Console.WriteLine($"-- Dummy SQL Command --");
            Console.WriteLine($"SELECT * FROM application_urls WHERE url = '{url}';");
        }

        public static void FetchInputData(string inputField, string value)
        {
            Console.WriteLine($"-- Dummy SQL Command --");
            Console.WriteLine($"SELECT * FROM test_inputs WHERE {inputField} = '{value}';");
        }
    }
}
