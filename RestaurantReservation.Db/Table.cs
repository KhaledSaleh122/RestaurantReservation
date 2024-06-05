using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db
{
    public class Table
    {
        public int TableId { get; set; }
        public int RestaurantId { get; set; }

        public int Capacity { get; set; }
        public Restaurant Restaurant { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
