using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.Admin1
{
    class AllReservations
    {
        public static void ViewAllReservations()
        {

            using (SqlConnection conn = Connection.getconnection())
            {
                string query = "SELECT * FROM Reservation";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine("\n--- All Reservations ---\n");
                    Console.WriteLine(
                        $"{ "BookingId",-8}| { "CustomerId",-10} | { "TrainNo",-6} |{ "TrainName",-17} | { "DOJ",-9}| { "Source",-10}| { "Dest",-10}| { "Class",-8}| { "BookingDate",-13}| { "Passengers",-8}| { "NetCost",-8}");

                    Console.WriteLine(new string('-', 130));
                    while (reader.Read())
                    {
                        Console.WriteLine(
                            $"{reader["BookingId"],-9}| {reader["CustomerId"],-11}| {reader["TrainNo"],-8}| {reader["TrainName"],-15}| {Convert.ToDateTime(reader["DateOfJourney"]).ToString("yyyy-MM-dd"),-11}| {reader["Source"],-10}| {reader["Destination"],-10}| {reader["Class"],-8}| {Convert.ToDateTime(reader["BookingDate"]).ToString("yyyy-MM-dd"),-13}| {reader["No_of_Passengers"],-6}| {reader["TotalCost"],-8}");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving reservations: " + ex.Message);
                }
            }
        }

    }
}
