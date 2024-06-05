namespace RestaurantReservation.API.Models.Restaurant
{
    public class RestaurantDto
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone_Number { get; set; }
        public int Opening_Hours { get; set; }
    }
}
