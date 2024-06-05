using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db
{
    public class MenuItem
    {
        [Key]
        public int ItemId { get; set; }
        public int RestaurantId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
