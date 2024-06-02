namespace RestaurantReservation.API.Models.Reservation
{
    public class ReservationDto
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int TableId { get; set; }
        public int RestaurantId { get; set; }

        public DateTime Reservation_date { get; set; }
        public int Party_size { get; set; }
    }
}
