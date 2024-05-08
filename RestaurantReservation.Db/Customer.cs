using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Phone_number { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
