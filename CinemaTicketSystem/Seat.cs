using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSystem
{
    public class Seat
    {
        public bool isAvailable;
        public int id;
        public int movieID;

        public Seat(int id, int movieID, bool available)
        {
            this.id = id;
            this.movieID = movieID;
            this.isAvailable = available;
        }
    }
}
