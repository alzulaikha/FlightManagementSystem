using Microsoft.Win32;
using System.ComponentModel.Design;
using System.IO;
namespace TS_DS_CAP_01
{
    internal class Program
    {
        static List<string> passengerNames = new List<string>();
         
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


        static Queue<string> checkedInQueue = new Queue<string>(new string[] { "Ali", "Maryam", "Bader", "Omar", "Noor" });
        static Stack<string> boardingStack = new Stack<string>();
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
   static Queue<string> waitlistQueue = new Queue<string>();

        static void LoadPassengers()
        {
            if (File.Exists("Passengers.txt"))
            {
                string[] lines = File.ReadAllLines("Passengers.txt");

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');

                    passengerNames.Add(parts[0]);
                    ticketNumbers.Add(parts[1]);
                }
            }
        }

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

            File.AppendAllText("passengers.txt", name + "|" + Environment.NewLine);
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
        //Update a Booking function
        public static void updateBooking()
        {
            Console.Write("Enter Ticket ID: ");
            string ticketId = Console.ReadLine();


            if (!ticketNumbers.Contains(ticketId))
            {
                Console.WriteLine("Ticket not found.");
                return;
            }


            if (cancelledTickets.Contains(ticketId))
            {
                Console.WriteLine("This ticket has been cancelled.");
                return;
            }


            if (!bookingRecord.ContainsKey(ticketId))
            {
                Console.WriteLine("No booking found for this ticket.");
                return;
            }


            string booking = bookingRecord[ticketId];

            string[] parts = booking.Split('|');

            string flight = parts[0];
            string date = parts[1];

            Console.WriteLine("=== Current Booking: ===");
            Console.WriteLine("Flight: " + flight);
            Console.WriteLine("Date: " + date);


            Console.WriteLine("=== Update a Booking ===");
            Console.WriteLine("1. Change Flight");
            Console.WriteLine("2. Change Date");
            Console.WriteLine("3. Change Both");
            Console.WriteLine("0. Cancel Update");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            string newFlight = flight;
            string newDate = date;

            if (choice == 1) //Change flight only 
            {
                Console.WriteLine("== Available Flights: ==");

                foreach (string f in flightNumbers)
                {
                    Console.WriteLine(f);
                }

                Console.Write("Enter new flight: ");
                newFlight = Console.ReadLine();
            }
            else if (choice == 2) // Change date only 
            {
                Console.WriteLine("== Available Dates: ==");

                foreach (string d in availableDates)
                {
                    Console.WriteLine(d);
                }

                Console.Write("Enter new date: ");
                newDate = Console.ReadLine();
            }
            else if (choice == 3) // Change both 
            {
                Console.WriteLine("== Available Flights: ==");

                foreach (string f in flightNumbers)
                {
                    Console.WriteLine(f);
                }

                Console.Write("Enter new flight: ");
                newFlight = Console.ReadLine();

                Console.WriteLine("== Available Dates: ==");

                foreach (string d in availableDates)
                {
                    Console.WriteLine(d);
                }

                Console.Write("Enter new date: ");
                newDate = Console.ReadLine();
            }
            else if (choice == 0) //Cancel update
            {
                Console.WriteLine("Update cancelled.");
                return;
            }
            else
            {
                Console.WriteLine("Invalid choice");
                return;
            }


            bookingRecord[ticketId] = newFlight + "|" + newDate;

            Console.WriteLine("== Booking Updated Successfully ==");

            Console.WriteLine("== Old Booking: ==");
            Console.WriteLine("Flight: " + flight);
            Console.WriteLine("Date: " + date);

            Console.WriteLine("== New Booking: ==");
            Console.WriteLine("Flight: " + newFlight);
            Console.WriteLine("Date: " + newDate);
        }

        public static void cancelTicket(){
              Console.Write("Enter Ticket ID: ");
              string ticketId = Console.ReadLine();

  
             if (!ticketNumbers.Contains(ticketId))
              {
                    Console.WriteLine("Ticket not found!");
                return;
               }

             if (cancelledTickets.Contains(ticketId))
              {
                 Console.WriteLine("Ticket already cancelled!");
                return;
               }


              int index = ticketNumbers.IndexOf(ticketId);
              string passengerName = passengerNames[index];


            if (bookingRecord.ContainsKey(ticketId))
              {
              bookingRecord.Remove(ticketId);
              Console.WriteLine("Booking was removed.");
              }


             cancelledTickets.Add(ticketId);


           Queue<string> tempQueue = new Queue<string>();

           while (checkedInQueue.Count > 0)
           {
              string passenger = checkedInQueue.Dequeue();

              if (passenger != passengerName)
             {
                tempQueue.Enqueue(passenger);
             }
               }

            checkedInQueue = tempQueue;


          Stack<string> tempStack = new Stack<string>();

               while (boardingStack.Count > 0)
              {
               string passenger = boardingStack.Pop();

                 if (passenger != passengerName)
                {
                 tempStack.Push(passenger);
                 }
                 }

          Stack<string> finalStack = new Stack<string>();

           while (tempStack.Count > 0)
           {
             finalStack.Push(tempStack.Pop());
           }

          boardingStack = finalStack;


           Console.WriteLine("===== Cancellation Summary =====");
           Console.WriteLine("Passenger Name: " + passengerName);
           Console.WriteLine("Ticket ID: " + ticketId);
           Console.WriteLine("Status: Cancelled Successfully");
            }
        public static void passengerCheckIn()
        {
            Console.WriteLine("1. Check in a passenger ");
            Console.WriteLine("2. View check-in queue");
            Console.WriteLine("3. Process next passenger ");
            Console.WriteLine("0. Back");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("== Check in a passenger == ");
                Console.Write("Enter Ticket ID: ");
                string ticketId = Console.ReadLine();

                if (!ticketNumbers.Contains(ticketId))
                {
                    Console.WriteLine("Ticket not found.");
                    return;
                }

                if (cancelledTickets.Contains(ticketId))
                {
                    Console.WriteLine("Ticket is cancelled.");
                    return;
                }

                if (!bookingRecord.ContainsKey(ticketId))
                {
                    Console.WriteLine("No booking found.");
                    return;
                }

                int index = ticketNumbers.IndexOf(ticketId);
                string passengerName = passengerNames[index];

                if (checkedInQueue.Contains(passengerName))
                {
                    Console.WriteLine("Passenger already checked in queue");
                    return;
                }

                if (checkedInQueue.Count < 10)
                {
                    checkedInQueue.Enqueue(passengerName);

                    Console.WriteLine(passengerName);
                }
                else
                {
                    waitlistQueue.Enqueue(passengerName);

                    Console.WriteLine(passengerName + " added to waitlist.");
                }
            }

            else if (choice == 2)
            {
                Console.WriteLine("== Current Check-In Queue: ==");

                int position = 1;

                foreach (string passenger in checkedInQueue)
                {
                    Console.WriteLine(position + ". " + passenger);
                    position++;
                }

                Console.WriteLine("Waitlist Count: " + waitlistQueue.Count);
            }

            else if (choice == 3)
            {
                if (checkedInQueue.Count == 0)
                {
                    Console.WriteLine("No passengers in queue.");
                    return;
                }

                string processedPassenger = checkedInQueue.Dequeue();

                Console.WriteLine("Processed: " + processedPassenger);

                if (waitlistQueue.Count == 0)
                {
                    string waitPassenger = waitlistQueue.Dequeue();

                    checkedInQueue.Enqueue(waitPassenger);

                    Console.WriteLine(waitPassenger + " moved from waitlist to check-in queue.");
                }
            }

            else if (choice == 0)
            {
                return;
            }

            else
            {
                Console.WriteLine("Invalid choice.");
            }

        }
        static void Main(string[] args)
        {
            LoadPassengers();

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
                        updateBooking(); //Case 05 Update a Booking
                        break;
                    case 6:
                        cancelTicket(); 
                        break;
                    case 7:
                        passengerCheckIn();
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
