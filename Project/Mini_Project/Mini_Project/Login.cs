using System;
using System.Data.SqlClient;

namespace Mini_Project
{
    public static class Login
    {
        public static string CurrentRole = "";
        public static string CurrentUsername = "";
        public static int CurrentCustomerId = 0;

        public static void RegisterUser()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter phone number: ");
            decimal phone = Convert.ToInt64(Console.ReadLine());
            while (Convert.ToString(phone).Length != 10)
            {
                Console.Write("Entered Invalid phone no,Enter valid Phone no: ");
                phone = Convert.ToInt64(Console.ReadLine());
            }
            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Create a password: ");
            string password = Console.ReadLine();

            using (SqlConnection conn = Connection.getconnection())
            {
                string query = @"INSERT INTO Customer (CustomerName, phone, Email, Password)
                                 VALUES (@Name, @Phone, @Email, @Password)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Registration successful.");
            }
        }

        public static int Authenticate(string email,string password)
        {
           

            using (SqlConnection conn = Connection.getconnection())
            {
                string query = @"SELECT CustomerId, CustomerName FROM Customer 
                                 WHERE Email = @Email AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);


                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    CurrentCustomerId = Convert.ToInt32(reader["CustomerId"]);
                    CurrentUsername = reader["CustomerName"].ToString();

                    CurrentRole = email.ToLower() == "admin@railway.com" ? "admin" : "user";

                    Console.WriteLine($"\nLogin successful as {CurrentRole}.");
                    Console.WriteLine();
                    Console.WriteLine($"Welcome, {CurrentUsername}");
                    reader.Close();
                    return CurrentCustomerId;
                }
                else
                {
                    Console.WriteLine("Invalid credentials.");
                    CurrentCustomerId = 0;
                    return CurrentCustomerId;
                }
            }
        }
    }
}
