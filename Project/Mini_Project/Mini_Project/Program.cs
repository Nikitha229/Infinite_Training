using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Welcome to Railway Reservation System ---");

            while (true)
            {
                Console.WriteLine("=====Main Menu=====");
                Console.WriteLine("1. Register User");
                Console.WriteLine("2. Login as Admin");
                Console.WriteLine("3. Login as User");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Login.RegisterUser();
                        break;
                    case 2:
                        Console.Write("Enter email: ");
                        string email = Console.ReadLine();

                        Console.Write("Enter password: ");
                        string password = Console.ReadLine();
                        int customerid = Login.Authenticate(email,password);
                        if (customerid != 0)
                        {
                            ShowMenuBasedOnRole(customerid);
                        }
                        break;
                    case 3:
                        Console.Write("Enter email: ");
                        string email1 = Console.ReadLine();

                        Console.Write("Enter password: ");
                        string password1 = Console.ReadLine();
                        int custid = Login.Authenticate(email1,password1);
                        if (custid!=0)
                        {
                            ShowMenuBasedOnRole(custid);
                        }
                        break;

                    case 4:
                        Console.WriteLine("Thank you for using the Railway Reservation System.");
                        Console.Read();
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void ShowMenuBasedOnRole(int custid)
        {
            while (true)
            {
                Console.WriteLine("\n--- Railway Reservation System ---");

                if (Login.CurrentRole == "user")
                {
                    Console.WriteLine("1. Search/View Trains");
                    Console.WriteLine("2. Make Reservation");
                    Console.WriteLine("3. Cancel Ticket");
                    Console.WriteLine("4. Check Ticket Status");
                    Console.WriteLine("5. Journey's Ahead");
                    Console.WriteLine("6. Logout");

                    Console.Write("Choose an option: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1: SearchOrView_Trains.SearchOrViewTrains(); break;
                        case 2: Reservation.MakeReservation(custid); break;
                        case 3: Cancellation.CancelTicket(custid); break;
                        case 4: TicketStatus.CheckTicketStatus(); break;
                        case 5: UpcomingJourney_s.ShowUpcomingJourneysByCustomer(custid); break;
                        case 6: return;
                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
                else if (Login.CurrentRole == "admin")
                {
                    
                    Console.WriteLine("1. Search/View Trains");
                    Console.WriteLine("2. Add New Train");
                    Console.WriteLine("3. Delete Train");
                    Console.WriteLine("4. Update Train");
                    Console.WriteLine("5. View All Bookings");
                    Console.WriteLine("6. View All Cancellations");
                    Console.WriteLine("7. Activate Train");
                    Console.WriteLine("8. Deactivate Train");
                    Console.WriteLine("9. Logout");

                    Console.Write("Choose an option: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1: SearchOrView_Trains.SearchOrViewTrains(); break;
                        case 2: Admin1.AddTrain.AddNewTrain(); break;
                        case 3: Admin1.DeleteTrain.fn_DeleteTrain(); break;
                        case 4: Admin1.UpdatingTrains.UpdateTrain();break;
                        case 5: Admin1.AllReservations.ViewAllReservations(); break;
                        case 6: Admin1.AllCancellations.ViewAllCancellations();break;
                        case 7: Admin1.ActivateAndDeactivate.ActivateTrain();break;
                        case 8: Admin1.ActivateAndDeactivate.DeactivateTrain();break;
                        case 9: return;
                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
            }
        }
    }
}




