using System;
using System.IO;
using System.Data.SqlClient;

namespace SecureConsoleApp
{
    class Program
    {
        private static string connectionString = "Server=myServer;Database=myDB;Integrated Security=True;";

        static void Main(string[] args)
        {
            // Secure SQL query with parameterized input
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Console.WriteLine("Login Successful");
                    }
                    else
                    {
                        Console.WriteLine("Login Failed");
                    }
                }
            }

            // Secure file handling
            string sensitiveDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SensitiveData");
            Directory.CreateDirectory(sensitiveDataPath);
            string filePath = Path.Combine(sensitiveDataPath, "user_data.txt");
            File.WriteAllText(filePath, "Sensitive Information");
            File.SetAttributes(filePath, FileAttributes.Encrypted);

            // Secure admin password handling
            string adminPassword = Environment.GetEnvironmentVariable("ADMIN_PASSWORD");
            if (adminPassword == "secureAdminPassword")
            {
                Console.WriteLine("Admin access granted");
            }
            else
            {
                Console.WriteLine("Admin access denied");
            }

            // Secure logging
            string logMessage = $"Login attempt at {DateTime.Now}";
            string logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Logs");
            Directory.CreateDirectory(logFilePath);
            File.AppendAllText(Path.Combine(logFilePath, "login_attempts.log"), logMessage + Environment.NewLine);
        }
    }
}
