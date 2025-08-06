using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Mini_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- Railway Reservation System ---");
                Console.WriteLine("1. Register Customer");
                Console.WriteLine("2. Make Reservation");
                Console.WriteLine("3. Cancel Ticket");
                Console.WriteLine("4. Check Ticket Status");
                Console.WriteLine("5. Journey's Ahead");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: Registration.RegisterCustomer(); break;
                    case 2: Reservation.MakeReservation(); break;
                    case 3: Cancellation.CancelTicket(); break;
                    case 4: TicketStatus.CheckTicketStatus(); break;
                    case 5: UpcomingJourney_s.ShowUpcomingJourneysByCustomer(); break;
                    case 6: return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }
    }
}



