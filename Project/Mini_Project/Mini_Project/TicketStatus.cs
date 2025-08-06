using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project
{
    class TicketStatus
    {
        public static void CheckTicketStatus()
        {
            try
            { 
               Console.Write("Enter Passenger ID: ");
               int passengerId = int.Parse(Console.ReadLine());
               SqlConnection con = Connection.getconnection();
                SqlCommand cmd = new SqlCommand($"select p.PassengerId,p.Name, p.TrainName, p.TravelDate, p.status as TicketStatus from Passenger p where p.passengerid={passengerId}", con);
                cmd.Parameters.AddWithValue("@PassengerId", passengerId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Console.WriteLine($"\nPassenger ID: {reader["PassengerId"]}");
                    Console.WriteLine($"Name: {reader["Name"]}");
                    Console.WriteLine($"Train: {reader["TrainName"]}");
                    Console.WriteLine($"Travel Date: {Convert.ToDateTime(reader["TravelDate"]).ToShortDateString()}");
                    Console.WriteLine($"Ticket Status: {reader["TicketStatus"]}");
                }
                else
                {
                    Console.WriteLine("No ticket found for the given Passenger ID.");
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
