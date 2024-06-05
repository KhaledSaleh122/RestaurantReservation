using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int TableId { get; set; }
        public int RestaurantId { get; set; }

        public DateTime Reservation_date { get; set; }
        public int Party_size { get; set; }
        public Customer Customer { get; set; }

        public Table Table { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
        public Restaurant Restaurant { get; set; }

    }
}
