using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project
{
    class UpcomingJourney_s
    {
        public static void ShowUpcomingJourneysByCustomer(int custid)
        {
            int customerId = custid;

            try
            {
                
               SqlConnection con =Connection.getconnection();

                string query = @"
                select p.PassengerId, p.Name, p.Gender, p.Berth, r.BookingId, r.TrainNo, r.TrainName, r.DateOfJourney, 
                r.Source, r.Destination, r.Class, tc.Cost_Per_Seat
                from Passenger p
                join Reservation r on p.BookingId = r.BookingId
                join TrainClasses tc ON r.TrainNo = tc.TrainNo and r.Class = tc.Class
                where r.CustomerId = @CustomerId 
                and r.DateOfJourney > GETDATE()
                and p.Status != 'Cancelled'";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);

                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine($"\nUpcoming Journeys for Customer ID: {customerId}");
                bool hasJourneys = false;

                List<int> ids = new List<int>();
                while (reader.Read())
                {
                    hasJourneys = true;
                    if (!ids.Contains(Convert.ToInt32(reader["BookingId"])))
                    {
                        Console.WriteLine($"\nBooking ID: {reader["BookingId"]}, Train: {reader["TrainName"]} ({reader["TrainNo"]}), " +
                                          $"Date: {Convert.ToDateTime(reader["DateOfJourney"]).ToShortDateString()}, " +
                                          $"From: {reader["Source"]} To: {reader["Destination"]}, Class: {reader["Class"]}");
                        ids.Add(Convert.ToInt32(reader["BookingId"]));
                    }

                    Console.WriteLine($"Passenger ID: {reader["PassengerId"]}, Name: {reader["Name"]}, Gender: {reader["Gender"]}, " +
                                      $"Berth: {reader["Berth"]}, Cost: {reader["Cost_Per_Seat"]}");


                }

                if (!hasJourneys)
                {
                    Console.WriteLine("No upcoming journeys found for this customer.");
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
