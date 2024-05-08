using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db
{
    internal class Customer
    {
        public int Customer_id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Phone_number { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
