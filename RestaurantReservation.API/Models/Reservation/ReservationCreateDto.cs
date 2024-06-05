namespace RestaurantReservation.API.Models.Reservation
{
    public class ReservationCreateDto
    {

        public DateTime Reservation_date { get; set; }
        public int Party_size { get; set; }
    }
}
