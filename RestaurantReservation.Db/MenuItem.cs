using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db
{
    public class MenuItem
    {
        public int Item_id { get; set; }
        public int Restaurant_id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
