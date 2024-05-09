using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    public partial class AddViewEmployeesRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW  [EmployeesRestaurant]
                  AS
                  SELECT [Employees].First_Name + ' '+ [Employees].Last_Name as Employee_Name,
						 [Employees].Position as Position,
                         [Restaurants].Name as Restaurant_Name,
						 [Restaurants].Phone_Number as Restaurant_PhoneNumber

                  FROM [Restaurants] LEFT JOIN
                  [Employees] ON [Restaurants].RestaurantId = Employees.RestaurantId ;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW  EmployeesRestaurant");
        }
    }
}
