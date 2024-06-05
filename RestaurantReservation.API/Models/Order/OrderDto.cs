using RestaurantReservation.Db;

namespace RestaurantReservation.API.Models.Order
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int ReservationId { get; set; }
        public int EmployeeId { get; set; }

        public DateTime Order_date { get; set; }
        public decimal Total_amount { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }
}
