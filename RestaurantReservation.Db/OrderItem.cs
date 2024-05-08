using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db
{
    internal class OrderItem
    {
        public int Order_item_id { get; set; }
        public int Order_id { get; set; }
        public int Item_id { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
