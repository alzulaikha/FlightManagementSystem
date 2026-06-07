namespace TS_DS_CAP_01
{
    internal class Program
    {
        List<string> passengerNames = new List<string>()
        {"Ali","Maryam","Bader","Omar","Noor"};
        List<string> ticketNumbers = new List<string>() { "TKT-100", "TKT-200", "TKT-300", "TKT-400", "TKT-500" };
        string[] flightNumbers = { "OA101", "OA102", "OA103", "OA104", "OA105", "OA106" };
        List<string> availableDates = new List<string>() { "06-03-2026", "28-04-2026", "19-05-2026", "02-06-2026" };
        Dictionary<string, string> bookingRecord = new Dictionary<string, string>()
        {
            { "TKT-100","OA101|06-03-2026" },
            { "TKT-200","OA102|28-04-2026" },
            { "TKT-300","OA103|19-05-2026" },
            { "TKT-400","OA104|02-06-2026" },
            { "TKT-500","OA105|02-06-2026" },
        };

        Queue<string> checkedInQueue = new Queue<string>(new string[] { "Ali", "Maryam", "Bader", "Omar", "Noor" });
        Stack<string> boardingStack = new Stack<string>();
        List<string> cancelledTickets = new List<string>();
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
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
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
