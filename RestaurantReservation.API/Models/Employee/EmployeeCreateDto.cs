using RestaurantReservation.Db;

namespace RestaurantReservation.API.Models.Employee
{
    public class EmployeeCreateDto
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public Position Position { get; set; }
    }
}
