using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project
{
    class Registration
    {
        
        public static void RegisterCustomer()
        {
            SqlConnection con =Connection.getconnection();
            Console.Write("Enter Customer Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            string query = "insert into Customer (CustomerName, Phone, Email) VALUES (@Name, @Phone, @Email)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Email", email);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Customer registered successfully.");
        }
    }
}
