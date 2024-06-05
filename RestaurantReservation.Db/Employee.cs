using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db
{
    public enum Position
    {
        Normal = 1,
        Manager = 2

    }
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int RestaurantId { get; set; }

        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public Position Position { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public Restaurant Restaurant { get; set; }
    }
}
