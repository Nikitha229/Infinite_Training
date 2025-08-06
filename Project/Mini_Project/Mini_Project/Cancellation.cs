using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project
{
    class Cancellation
    {
        public static void CancelTicket()
        {
            SqlConnection con =Connection.getconnection();
            Console.Write("Enter Booking ID(in range 1000 to 2000): ");
            int bookingId = int.Parse(Console.ReadLine());
            SqlCommand getpassenger = new SqlCommand($"select passengerid,name from passenger where bookingid={bookingId} and status='Confirmed'", con);
            SqlDataReader readgetpass = getpassenger.ExecuteReader();
            while (readgetpass.Read())
            {
                int passengerid = readgetpass.GetInt32(0);
                string passengername = readgetpass.GetString(1);
                Console.WriteLine($"PassengerID: {passengerid} PassengerName:{passengername}");
            }
            readgetpass.Close();
            Console.Write("Enter Passenger ID: ");
            int passengerId = int.Parse(Console.ReadLine());
            string getCostQuery = $"select Traveldate,cost from Passenger where passengerId = {passengerId}";
            SqlCommand getCmd = new SqlCommand(getCostQuery, con);
            getCmd.Parameters.AddWithValue("@BookingId", bookingId);

            SqlDataReader result = getCmd.ExecuteReader();
            if (result.Read())
            {
                double totalCost = result.GetDouble(1);
                DateTime doj = result.GetDateTime(0);
                string cancelQuery = @"insert into Cancellation (BookingId, PassengerID, RefundAmount, CancellationDate)
                                   values (@BookingId, @PassengerID, @Refund, GETDATE())";
                SqlCommand cancelCmd = new SqlCommand(cancelQuery, con);
                cancelCmd.Parameters.AddWithValue("@BookingId", bookingId);
                cancelCmd.Parameters.AddWithValue("@PassengerID", passengerId);
                int diff = (doj - DateTime.Now).Days;
                double refund = totalCost;
                if (diff <= 10)
                {
                    refund = totalCost * 0.5;
                }
                cancelCmd.Parameters.AddWithValue("@Refund", refund);
                result.Close();
                cancelCmd.ExecuteNonQuery();
                Console.WriteLine($"Cancellation successful. Refund initiated: ₹{refund}");
                SqlCommand updatestatus = new SqlCommand($"update Passenger set status='Cancelled' where passengerid={passengerId}", con);
                SqlDataReader updatereader = updatestatus.ExecuteReader();
                updatereader.Close();

            }
            else
            {
                Console.WriteLine("Booking ID not found.");
            }
        }
    }
}
