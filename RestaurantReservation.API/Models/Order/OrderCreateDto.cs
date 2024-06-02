

namespace RestaurantReservation.API.Models.Order
{
    public class OrderCreateDto
    {
        public DateTime Order_date { get; set; }

        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }
}
