namespace RestaurantReservation.API.Models.Order
{
    public class OrderOnlyMenuItem
    {
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }
}
