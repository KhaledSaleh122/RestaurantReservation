using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    public partial class AddviewCustomerReservationsRestaurants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW  [CustomerReservationsRestaurants]
                  AS
                  SELECT [Customers].First_Name + ' '+ [Customers].Last_Name as Customer_Name,
						 [Reservations].Reservation_date as Reservation_Date,
						 [Reservations].Party_size as Party_Size,
                         [Restaurants].Name as Restaurent_Name,
						 [Restaurants].Address as Restaurent_Address

                  FROM Customers LEFT JOIN
                  Reservations ON Customers.CustomerId = Reservations.CustomerId LEFT JOIN
				  Restaurants ON Reservations.RestaurantId = Restaurants.RestaurantId;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW  CustomerReservationsRestaurants");
        }
    }
}
