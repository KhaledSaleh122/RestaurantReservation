namespace RestaurantReservation.API.Models.Reservation
{
    public class OrderItemsDto
    {
        public int OrderItemId { get; set; }
        public int ItemId { get; set; }
        public int OrderId { get; set; }

        public int Quantity { get; set; }
    }
}
