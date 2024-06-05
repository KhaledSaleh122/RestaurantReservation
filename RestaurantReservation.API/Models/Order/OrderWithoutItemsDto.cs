namespace RestaurantReservation.API.Models.Order
{
    public class OrderWithoutItemsDto
    {
        public int OrderId { get; set; }
        public int ReservationId { get; set; }
        public int EmployeeId { get; set; }

        public DateTime Order_date { get; set; }
        public decimal Total_amount { get; set; }
    }
}
