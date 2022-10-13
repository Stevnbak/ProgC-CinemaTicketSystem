using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSystem
{
    public class Movie
    {
        public int id;
        public string title;
        public Seat[] seats = new Seat[25];

        public Movie(string name, int id)
        {
            this.id = id;
            title = name;
            for(int i = 0; i < seats.Length; i++)
            {
                seats[i] = new Seat(i, id, true);
            }
        }
    }
}
