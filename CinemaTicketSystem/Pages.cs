namespace CinemaTicketSystem
{
    internal class Pages
    {
        public static void Reservate()
        {
            //Select movie
            Movie movie = SelectMovie();
            //Show seatOverview
            SeatOverview(movie);
            //Select seat
            bool foundSeat = false;
            while (!foundSeat) {
                try
                {
                    Console.WriteLine("Select seat:");
                    string input = Console.ReadLine();
                    int seatChoice = int.Parse(input);
                    Seat selectedSeat = movie.seats[seatChoice];
                    if (selectedSeat.isAvailable)
                    {
                        //Seat available
                        foundSeat = true;
                        movie.seats[seatChoice].isAvailable = false;
                        int confirmInput = Program.userInput("This seat is available. Confirm that you want to reservate it:", new List<string> { "Yes", "No" }.ToArray());
                        if (confirmInput == 0)
                        {
                            //Seat reservation confirmed
                            Program.customer.reservations.Add(movie.seats[seatChoice]);
                            Console.WriteLine("Seat has been reserved");
                            //Send to payment...
                        }
                        else
                        {
                            //Seat reservation cancelled
                            movie.seats[seatChoice].isAvailable = true;
                        }
                    }
                    else
                    {
                        //Seat not available
                        Console.WriteLine("This seat is not available. Pick another seat...");
                    }
                } 
                catch
                {
                    throw;
                }
            }
        }
        public static void Cancel()
        {
            //Check if there is any reservations
            if(Program.customer.reservations.Count == 0)
            {
                Console.WriteLine("You have no seat reservations to cancel");
                return;
            }
            string[] options = new string[Program.customer.reservations.Count + 1];
            for (int i = 0; i < Program.customer.reservations.Count; i++)
            {
                options[i] = "Seat " + Program.customer.reservations[i].id + " for Movie " + Program.customer.reservations[i].movieID;
            }
            options[Program.customer.reservations.Count] = "Back to menu";
            int seatChoice = Program.userInput("Select a seat to cancel", options);
            if (seatChoice == Program.customer.reservations.Count) return;
            Seat selectedSeat = Program.customer.reservations[seatChoice];
            int confirmInput = Program.userInput($"Are you sure that you want to cancel the reservation for seat {selectedSeat.id}?", new List<string> { "Yes", "No" }.ToArray());
            if (confirmInput == 0)
            {
                //Seat cancelletation confirmed
                Program.customer.reservations.Remove(selectedSeat);
                selectedSeat.isAvailable = true;
                Console.WriteLine("Seat has been cancelled");
            }
            else
            {
                //Cancelled seat cancelletation
                Console.WriteLine("No seat was cancelled");
            }
        }
        public static void ReservationOverview()
        {
            if (Program.customer.reservations.Count == 0)
            {
                Console.WriteLine("You have no seat reservations");
            }
            else
            {
                Console.WriteLine("Reserved seats: ");
                Program.customer.reservations.ForEach((seat) =>
                {
                    Console.WriteLine(" - Seat " + seat.id + " for Movie " + seat.movieID);
                });
            }
        }
        public static void MovieSchedule()
        {
            Console.WriteLine("Movie Schedule");
            DateTime today = DateTime.Today;
            for (int i = 0; i < Program.movies.Count; i++)
            {
                Console.WriteLine($"{(today.AddDays(i).ToShortDateString())} - {Program.movies[i].title}");
            }
        }
        public static void SeatOverview(Movie movie = null)
        {
            if (movie == null) { 
                movie = SelectMovie(); 
            }
            Console.WriteLine(movie.title + ":");
            Console.WriteLine("-----------------------------");
            for(int r = 0; r < 5; r++)
            {
                for(int s = 0; s < 5; s++)
                {
                    int seatNumber = r * 5 + s;
                    if(movie.seats[seatNumber].isAvailable) Console.ForegroundColor = ConsoleColor.Green;
                    else Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"|{(seatNumber < 10 ? seatNumber.ToString() + " " : seatNumber)}|");
                }
                Console.WriteLine("");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------");
        }
        public static Movie SelectMovie()
        {
            //Check if there is any movies
            if (Program.movies.Count == 0)
            {
                Console.WriteLine("There are no available movies");
                return null;
            }
            string[] options = new string[Program.movies.Count];
            for (int i = 0; i < options.Length; i++)
            {
                options[i] = Program.movies[i].title;
            }
            int choice = Program.userInput("Select a movie", options);
            Movie selected = Program.movies[choice];
            Console.WriteLine(selected.title + " has been selected");
            return selected;
        }
    }
}