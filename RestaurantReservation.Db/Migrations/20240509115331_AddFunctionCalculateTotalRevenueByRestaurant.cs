using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    public partial class AddFunctionCalculateTotalRevenueByRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION CalculateTotalRevenueByRestaurant(@RestaurantId INT)
                                    RETURNS decimal(18, 2)
                                    AS
                                    BEGIN
                                    DECLARE @Total decimal(18, 2);

                                    SELECT @Total = SUM(ISNULL(Orders.Total_amount, 0))
                                    FROM Restaurants
                                    LEFT JOIN Employees ON Restaurants.RestaurantId = Employees.RestaurantId
                                    LEFT JOIN Orders ON Employees.EmployeeId = Orders.EmployeeId
                                    WHERE Restaurants.RestaurantId = @RestaurantId
	                                GROUP BY Restaurants.RestaurantId;
                                    RETURN @Total;
                                   END;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION CalculateTotalRevenueByRestaurant;");
        }
    }
}
