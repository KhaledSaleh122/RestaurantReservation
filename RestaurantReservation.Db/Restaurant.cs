using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone_Number { get; set; }
        public int Opening_Hours { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public List<Table> Tables { get; set; } = new List<Table>();
        public List<MenuItem> Menu { get; set; } = new List<MenuItem>();
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
