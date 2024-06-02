namespace RestaurantReservation.API.Models.Restaurant
{
    public class RestaurantCreateDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone_Number { get; set; }
        public int Opening_Hours { get; set; }
    }
}
