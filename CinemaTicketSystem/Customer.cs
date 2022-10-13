using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSystem
{
    public class Customer
    {
        public string name { get; set; }
        public int id { get; set; }
        public List<Seat> reservations = new List<Seat>();

        public Customer(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

    }
}
