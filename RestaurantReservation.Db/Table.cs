using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db
{
    public class Table
    {
        public int Table_id { get; set; }
        public int Restaurant_id { get; set; }
        public int Capacity { get; set; }
        public Restaurant Restaurant { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
