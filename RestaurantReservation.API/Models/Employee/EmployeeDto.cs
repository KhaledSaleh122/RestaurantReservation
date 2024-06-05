using RestaurantReservation.Db;

namespace RestaurantReservation.API.Models.Employee
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public int RestaurantId { get; set; }

        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public Position Position { get; set; }
    }
}
