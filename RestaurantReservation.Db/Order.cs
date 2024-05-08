using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db
{
    public class Order
    {
        public int Order_id { get; set; }
        public int Reservation_id { get; set; }
        public int Employee_id { get; set; }
        public DateTime Order_date { get; set; }
        public double Total_amount { get; set; }
        public Reservation Reservation { get; set; }
        public Employee Employee { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
