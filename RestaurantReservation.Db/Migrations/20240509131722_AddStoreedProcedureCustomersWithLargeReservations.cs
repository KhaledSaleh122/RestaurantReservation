using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    public partial class AddStoreedProcedureCustomersWithLargeReservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE GetCustomersWithLargeReservations
                                    @PartySizeThreshold INT
                                AS
                                BEGIN
                                    SELECT DISTINCT c.CustomerId, c.First_Name, c.Last_Name, c.Email, c.Phone_number
                                    FROM Customers c
                                    JOIN Reservations r ON c.CustomerId = r.CustomerId
                                    WHERE r.Party_size > @PartySizeThreshold;
                                END;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE GetCustomersWithLargeReservations;");
        }
    }
}
