using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db
{
    internal class Reservation
    {
        public int Reservation_id { get; set; }
        public int Customer_id { get; set; }
        public int Restaurant_id { get; set; }
        public int Table_id { get; set; }
        public DateTime Reservation_date { get; set; }
        public int Party_size { get; set; }
        public Customer Customer { get; set; }

        public Table Table { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
        public Restaurant Restaurant { get; set; }

    }
}
