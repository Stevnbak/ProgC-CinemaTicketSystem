namespace CinemaTicketSystem
{
    public class Program
    {
        public static bool isProgramRunning = true;
        public static List<Movie> movies = new List<Movie>();
        public static Customer customer = new Customer("Test", 0);
        static void Main(string[] args)
        {  
            Console.WriteLine("Welcome to Cinema Ticket system...");
            //Create movies
            for(int i = 0; i < 10; i++)
            {
                movies.Add(new Movie("Test Movie " + i, i));
            }
            //Run program:
            while (isProgramRunning)
            {
                string[] options = { "Reserve a ticket", "Cancel ticket reservation", "See all your reservations", "Movie schedule", "Show seats", "Exit the program" };
                int input = userInput("You have the folllowing options:", options);
                Console.WriteLine(".........................");
                switch (input)
                {
                    case 0: //Reserve
                        Pages.Reservate();
                        break;
                    case 1: //Cancel
                        Pages.Cancel();
                        break;
                    case 2: //Reservation Overview
                        Pages.ReservationOverview();
                        break;
                    case 3: //Movie schedule
                        Pages.MovieSchedule();
                        break;
                    case 4: //Show seat overview
                        Pages.SeatOverview();
                        break;
                    case 5: //Exit
                        Console.WriteLine("Program is exiting, bye now");
                        isProgramRunning = false;
                        break;
                    default: //None
                        break;
                }
                Console.WriteLine(".........................");
            }
        }

        public static int userInput(string question, string[] options)
        {
            bool isInputCorrect = false;
            Console.WriteLine(question);
            for(int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"Press {i}: {options[i]}");
            }

            int numberInput = -1;
            isInputCorrect = false;

            while (!isInputCorrect)
            {
                string userInput = Console.ReadLine();
                try
                {
                    numberInput = int.Parse(userInput);
                    if (numberInput >= 0 && numberInput < options.Length)
                    {
                        isInputCorrect = true;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please enter a number for which menu item you want to use");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Please enter a number between 0 and {options.Length - 1}");
                }
            }
            return numberInput;
        }
    }
}