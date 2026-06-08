using Microsoft.Win32;
using System.ComponentModel.Design;

namespace TS_DS_CAP_01
{
    internal class Program
    {
      static List<string> passengerNames = new List<string>()
         {"Ali","Maryam","Bader","Omar","Noor"};
      static List<string> ticketNumbers = new List<string>() 
         { "TKT-001", "TKT-002", "TKT-003", "TKT-004", "TKT-005" };
      static string[] flightNumbers = { "OA101", "OA102", "OA103", "OA104", "OA105", "OA106" };
      static List<string> availableDates = new List<string>()  
         { "06-03-2026", "28-04-2026", "19-05-2026", "02-06-2026" };
        static Dictionary<string, string> bookingRecord = new Dictionary<string, string>();
        //       {
        //    { "TKT-001","OA101|06-03-2026" },
        //    { "TKT-002","OA102|28-04-2026" },
        //    { "TKT-003","OA103|19-05-2026" },
        //    //{ "TKT-004","OA104|02-06-2026" },
        //    { "TKT-005","OA105|02-06-2026" },
        //};


        Queue<string> checkedInQueue = new Queue<string>(new string[] { "Ali", "Maryam", "Bader", "Omar", "Noor" });
        Stack<string> boardingStack = new Stack<string>();
        static List<string> cancelledTickets = new List<string>()
        { "TKT-005"};
        Dictionary<string, string> passengerSeatMap = new Dictionary<string, string>()
            {
            {"Ali","14A"},
            {"Maryam","15A"},
            { "Bader","16A"},
            { "Omar","17A"},
            { "Noor","18A"}
        };
    Queue<string> waitlistQueue = new Queue<string>();




        public static void mainMenu()
        {
            Console.WriteLine("SKY WINGS FLIGHT MANAGEMENT SYSTEM");
            Console.WriteLine("1. Register New Passenger");
            Console.WriteLine("2. View All Passengers");
            Console.WriteLine("3. Book a Flight Ticket");
            Console.WriteLine("4. View Booking Details");
            Console.WriteLine("5. Update a Booking");
            Console.WriteLine("6. Cancel a Ticket");
            Console.WriteLine("7. Passenger Check-In");
            Console.WriteLine("8. Board Passengers (Boarding Stack)");
            Console.WriteLine("9. Generate Flight Manifest");
            Console.WriteLine("10. Manage Waitlist & Seat Assignment");
            Console.WriteLine("0. Exit");
        }
        //Register New Passenger fuction
        public static void registerNewPassenger()
        {
            Console.WriteLine("Enter Passenger Full Name:");
            string name = Console.ReadLine();

            if (name == "")
            {
                Console.WriteLine("Name is empty");
                return;
            }
            if (passengerNames.Contains(name))
            {
                Console.WriteLine("name already exist");
                return;
            }

            passengerNames.Add(name);
            string ticketId = "TKT-00" + passengerNames.Count;

            ticketNumbers.Add(ticketId);
            Console.WriteLine("New passenger name:" + name);
            Console.WriteLine("New ticket ID:" + ticketId);
            
            
        
        }
        //View All Passengers function
        public static void viewAllPassengers()
        {
            if (passengerNames.Count == 0)
            {
                Console.WriteLine("No passengers registered yet");
                return;
            }
            Console.WriteLine("No. | Passenger Name | Ticket ID | Status");

           
            for (int i = 0; i < passengerNames.Count; i++)
                if (cancelledTickets.Contains(ticketNumbers[i]))
                {
                    Console.WriteLine(i + "      "  + passengerNames[i] + "       " + ticketNumbers[i] + "       " + "CANCELLED");
                }
            else
                {
                    Console.WriteLine(i + "       " + passengerNames[i] + "        " + ticketNumbers[i] + "      " + "Active");
                }
            Console.WriteLine("total of passenger:" +passengerNames.Count);
        }
        // Book a Flight Ticket function
        public static void bookFlightTicket()
        {
            Console.WriteLine("Enter Ticket ID:");
            string ticketId = Console.ReadLine();
            if (!ticketNumbers.Contains(ticketId))
            {

                Console.WriteLine("invalid ticket. ");
                return;
            }
            if (cancelledTickets.Contains(ticketId))
            {
                Console.WriteLine("Ticket is cancelled. ");
                return;
            }
            if (bookingRecord.ContainsKey(ticketId))
            {
                Console.WriteLine(" ticket already has a booking. ");
                return;
            }
            ///Display all available flight numbers
            Console.WriteLine("== all available flight numbers: ==");

            for (int i = 0; i < flightNumbers.Length; i++)
            {
                Console.WriteLine(i + "-" + flightNumbers[i]);
            }

            Console.WriteLine("Select a fligh number: ");
            int flightIndex = int.Parse(Console.ReadLine());
            if (flightIndex < 0 || flightIndex >= flightNumbers.Length)
            {
                Console.WriteLine("Invalid choice. ");
            }

            ///Display all available dates
            Console.WriteLine("==  all available dates ==");
            for (int i = 0; i < availableDates.Count; i++)
            {
                Console.WriteLine(i + "-" + availableDates[i]);
            }
            Console.WriteLine("Select a date: ");
            int dateIndex = int.Parse(Console.ReadLine());
            if (dateIndex < 0 || dateIndex >= availableDates.Count)
            {
                Console.WriteLine("Invalid choice. ");
            }

            bookingRecord.Add(ticketId, flightNumbers[flightIndex] + "|" + availableDates[dateIndex]);

        
            int index=ticketNumbers.IndexOf(ticketId);
            string passengerName = passengerNames[index];

            Console.WriteLine("Ticket ID:  " + ticketId);
            Console.WriteLine("Passenger Name:  " + passengerName);
            Console.WriteLine("Flight Number:  " + flightNumbers[flightIndex]);
            Console.WriteLine("Date:  " + availableDates[dateIndex]);

            
        }
        


        public static void  viewBookingDetails()
 
        {
            Console.Write("Enter ticket id: ");
            string ticketId= Console.ReadLine();

           
            if (!ticketNumbers.Contains(ticketId))
            {
                Console.WriteLine("Ticket not found");
                return;
            }




            if (cancelledTickets.Contains(ticketId))
            {
                Console.WriteLine("This ticket has been cancelled");
                return;
            }


            if (!bookingRecord.ContainsKey(ticketId))
            {
                Console.WriteLine("No booking found for this ticket");
                return;
            }


            string booking = bookingRecord[ticketId];

   

            int index = ticketNumbers.IndexOf(ticketId);
            string passengerName = passengerNames[index];

            Console.WriteLine("=== Booking Details ===");
            Console.WriteLine("Passenger: " + passengerName);
            Console.WriteLine("Ticket ID: " + ticketId);
            Console.WriteLine("Booking: " + booking);
         

        }



        static void Main(string[] args)
        {
            
            bool exit = false;
            while (exit == false)

            {
                mainMenu();
                Console.WriteLine("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        registerNewPassenger();//Case 01 Register New Passenger
                        break;
                    case 2:
                        viewAllPassengers(); //Case 02 View All Passengers
                        break;
                    case 3:
                      bookFlightTicket(); //Case 03 Book a Flight Ticket 
                        break;
                    case 4:
                        viewBookingDetails(); //Case 04 View Booking Details
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("invalid option please try again");
                        break;



                }
                Console.WriteLine("press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
                }
    }
}
