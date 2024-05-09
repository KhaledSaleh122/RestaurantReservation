using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db
{
    public class CustomerReservationsRestaurants
    {
        public String Customer_Name { get; set; }
        public DateTime Reservation_Date { get; set; }
        public int Party_Size { get; set; }
        public String Restaurent_Name { get; set; }
        public String Restaurent_Address { get; set; }

    }
}
