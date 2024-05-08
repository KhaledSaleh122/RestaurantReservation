using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "First_Name", "Last_Name", "Phone_number" },
                values: new object[,]
                {
                    { 1, "alice.johnson@example.com", "Alice", "Johnson", "123-456-7890" },
                    { 2, "bob.smith@example.com", "Bob", "Smith", "123-456-7891" },
                    { 3, "carol.williams@example.com", "Carol", "Williams", "123-456-7892" },
                    { 4, "david.jones@example.com", "David", "Jones", "123-456-7893" },
                    { 5, "eva.brown@example.com", "Eva", "Brown", "123-456-7894" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "Address", "Name", "Opening_Hours", "Phone_Number" },
                values: new object[,]
                {
                    { 1, "123 Main St", "The Gourmet Hut", 10, "987-654-3210" },
                    { 2, "456 Side St", "The Pizza Place", 12, "987-654-3211" },
                    { 3, "789 Leaf Ln", "The Coffee Corner", 8, "987-654-3212" },
                    { 4, "321 Water St", "The Taco Tower", 10, "987-654-3213" },
                    { 5, "654 Hill St", "The Noodle Nest", 9, "987-654-3214" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "First_Name", "Last_Name", "Position", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Olivia", "Miller", 1, 1 },
                    { 2, "Noah", "Davis", 2, 2 },
                    { 3, "Liam", "Garcia", 1, 3 },
                    { 4, "Sophia", "Rodriguez", 2, 4 },
                    { 5, "Mason", "Martinez", 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "ItemId", "Description", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Classic Italian pasta with creamy egg sauce and bacon bits.", "Spaghetti Carbonara", 12.0, 1 },
                    { 2, "Simple and classic pizza with tomatoes, fresh mozzarella, and basil.", "Margherita Pizza", 10.0, 1 },
                    { 3, "Crisp romaine lettuce with parmesan cheese, croutons, and Caesar dressing.", "Caesar Salad", 8.0, 1 },
                    { 4, "Juicy grilled beef patty with lettuce, tomato, and secret sauce.", "Beef Burger", 11.0, 2 },
                    { 5, "Traditional beer-battered fish served with crispy fries.", "Fish and Chips", 15.0, 2 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Capacity", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 2, 2 },
                    { 3, 6, 3 },
                    { 4, 4, 4 },
                    { 5, 8, 5 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CustomerId", "Party_size", "Reservation_date", "RestaurantId", "TableId" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(2024, 5, 9, 23, 56, 14, 889, DateTimeKind.Local).AddTicks(2073), 1, 1 },
                    { 2, 2, 4, new DateTime(2024, 5, 9, 23, 56, 14, 889, DateTimeKind.Local).AddTicks(2108), 2, 2 },
                    { 3, 3, 6, new DateTime(2024, 5, 9, 23, 56, 14, 889, DateTimeKind.Local).AddTicks(2111), 3, 3 },
                    { 4, 4, 3, new DateTime(2024, 5, 9, 23, 56, 14, 889, DateTimeKind.Local).AddTicks(2113), 4, 4 },
                    { 5, 5, 8, new DateTime(2024, 5, 9, 23, 56, 14, 889, DateTimeKind.Local).AddTicks(2115), 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "EmployeeId", "Order_date", "ReservationId", "Total_amount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 7, 23, 56, 14, 889, DateTimeKind.Local).AddTicks(2156), 1, 35.0 },
                    { 2, 2, new DateTime(2024, 5, 6, 23, 56, 14, 889, DateTimeKind.Local).AddTicks(2159), 2, 50.0 },
                    { 3, 3, new DateTime(2024, 5, 5, 23, 56, 14, 889, DateTimeKind.Local).AddTicks(2168), 3, 45.0 },
                    { 4, 4, new DateTime(2024, 5, 4, 23, 56, 14, 889, DateTimeKind.Local).AddTicks(2169), 4, 30.0 },
                    { 5, 5, new DateTime(2024, 5, 3, 23, 56, 14, 889, DateTimeKind.Local).AddTicks(2171), 5, 25.0 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "ItemId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 3, 1, 1 },
                    { 3, 2, 2, 3 },
                    { 4, 4, 2, 1 },
                    { 5, 5, 3, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 3);
        }
    }
}
