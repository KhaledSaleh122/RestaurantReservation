﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantReservation.Db;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    [DbContext(typeof(RestaurantReservationDbContext))]
    [Migration("20240509084907_createEntityTablesWithSeededData")]
    partial class createEntityTablesWithSeededData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RestaurantReservation.Db.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Email = "alice.johnson@example.com",
                            First_Name = "Alice",
                            Last_Name = "Johnson",
                            Phone_number = "123-456-7890"
                        },
                        new
                        {
                            CustomerId = 2,
                            Email = "bob.smith@example.com",
                            First_Name = "Bob",
                            Last_Name = "Smith",
                            Phone_number = "123-456-7891"
                        },
                        new
                        {
                            CustomerId = 3,
                            Email = "carol.williams@example.com",
                            First_Name = "Carol",
                            Last_Name = "Williams",
                            Phone_number = "123-456-7892"
                        },
                        new
                        {
                            CustomerId = 4,
                            Email = "david.jones@example.com",
                            First_Name = "David",
                            Last_Name = "Jones",
                            Phone_number = "123-456-7893"
                        },
                        new
                        {
                            CustomerId = 5,
                            Email = "eva.brown@example.com",
                            First_Name = "Eva",
                            Last_Name = "Brown",
                            Phone_number = "123-456-7894"
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            First_Name = "Olivia",
                            Last_Name = "Miller",
                            Position = 2,
                            RestaurantId = 1
                        },
                        new
                        {
                            EmployeeId = 2,
                            First_Name = "Noah",
                            Last_Name = "Davis",
                            Position = 1,
                            RestaurantId = 2
                        },
                        new
                        {
                            EmployeeId = 3,
                            First_Name = "Liam",
                            Last_Name = "Garcia",
                            Position = 2,
                            RestaurantId = 3
                        },
                        new
                        {
                            EmployeeId = 4,
                            First_Name = "Sophia",
                            Last_Name = "Rodriguez",
                            Position = 1,
                            RestaurantId = 4
                        },
                        new
                        {
                            EmployeeId = 5,
                            First_Name = "Mason",
                            Last_Name = "Martinez",
                            Position = 2,
                            RestaurantId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.MenuItem", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            Description = "Classic Italian pasta with creamy egg sauce and bacon bits.",
                            Name = "Spaghetti Carbonara",
                            Price = 12.0,
                            RestaurantId = 1
                        },
                        new
                        {
                            ItemId = 2,
                            Description = "Simple and classic pizza with tomatoes, fresh mozzarella, and basil.",
                            Name = "Margherita Pizza",
                            Price = 10.0,
                            RestaurantId = 1
                        },
                        new
                        {
                            ItemId = 3,
                            Description = "Crisp romaine lettuce with parmesan cheese, croutons, and Caesar dressing.",
                            Name = "Caesar Salad",
                            Price = 8.0,
                            RestaurantId = 1
                        },
                        new
                        {
                            ItemId = 4,
                            Description = "Juicy grilled beef patty with lettuce, tomato, and secret sauce.",
                            Name = "Beef Burger",
                            Price = 11.0,
                            RestaurantId = 2
                        },
                        new
                        {
                            ItemId = 5,
                            Description = "Traditional beer-battered fish served with crispy fries.",
                            Name = "Fish and Chips",
                            Price = 15.0,
                            RestaurantId = 2
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Order_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<double>("Total_amount")
                        .HasColumnType("float");

                    b.HasKey("OrderId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            EmployeeId = 1,
                            Order_date = new DateTime(2024, 5, 8, 11, 49, 7, 66, DateTimeKind.Local).AddTicks(4051),
                            ReservationId = 1,
                            Total_amount = 35.0
                        },
                        new
                        {
                            OrderId = 2,
                            EmployeeId = 2,
                            Order_date = new DateTime(2024, 5, 7, 11, 49, 7, 66, DateTimeKind.Local).AddTicks(4054),
                            ReservationId = 2,
                            Total_amount = 50.0
                        },
                        new
                        {
                            OrderId = 3,
                            EmployeeId = 3,
                            Order_date = new DateTime(2024, 5, 6, 11, 49, 7, 66, DateTimeKind.Local).AddTicks(4057),
                            ReservationId = 3,
                            Total_amount = 45.0
                        },
                        new
                        {
                            OrderId = 4,
                            EmployeeId = 4,
                            Order_date = new DateTime(2024, 5, 5, 11, 49, 7, 66, DateTimeKind.Local).AddTicks(4059),
                            ReservationId = 4,
                            Total_amount = 30.0
                        },
                        new
                        {
                            OrderId = 5,
                            EmployeeId = 5,
                            Order_date = new DateTime(2024, 5, 4, 11, 49, 7, 66, DateTimeKind.Local).AddTicks(4061),
                            ReservationId = 5,
                            Total_amount = 25.0
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"), 1L, 1);

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            OrderItemId = 1,
                            ItemId = 1,
                            OrderId = 1,
                            Quantity = 2
                        },
                        new
                        {
                            OrderItemId = 2,
                            ItemId = 3,
                            OrderId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            OrderItemId = 3,
                            ItemId = 2,
                            OrderId = 2,
                            Quantity = 3
                        },
                        new
                        {
                            OrderItemId = 4,
                            ItemId = 4,
                            OrderId = 2,
                            Quantity = 1
                        },
                        new
                        {
                            OrderItemId = 5,
                            ItemId = 5,
                            OrderId = 3,
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Party_size")
                        .HasColumnType("int");

                    b.Property<DateTime>("Reservation_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("TableId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ReservationId = 1,
                            CustomerId = 1,
                            Party_size = 2,
                            Reservation_date = new DateTime(2024, 5, 10, 11, 49, 7, 66, DateTimeKind.Local).AddTicks(3949),
                            RestaurantId = 1,
                            TableId = 1
                        },
                        new
                        {
                            ReservationId = 2,
                            CustomerId = 2,
                            Party_size = 4,
                            Reservation_date = new DateTime(2024, 5, 10, 11, 49, 7, 66, DateTimeKind.Local).AddTicks(3991),
                            RestaurantId = 2,
                            TableId = 2
                        },
                        new
                        {
                            ReservationId = 3,
                            CustomerId = 3,
                            Party_size = 6,
                            Reservation_date = new DateTime(2024, 5, 10, 11, 49, 7, 66, DateTimeKind.Local).AddTicks(3994),
                            RestaurantId = 3,
                            TableId = 3
                        },
                        new
                        {
                            ReservationId = 4,
                            CustomerId = 4,
                            Party_size = 3,
                            Reservation_date = new DateTime(2024, 5, 10, 11, 49, 7, 66, DateTimeKind.Local).AddTicks(4002),
                            RestaurantId = 4,
                            TableId = 4
                        },
                        new
                        {
                            ReservationId = 5,
                            CustomerId = 5,
                            Party_size = 8,
                            Reservation_date = new DateTime(2024, 5, 10, 11, 49, 7, 66, DateTimeKind.Local).AddTicks(4004),
                            RestaurantId = 5,
                            TableId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Opening_Hours")
                        .HasColumnType("int");

                    b.Property<string>("Phone_Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            RestaurantId = 1,
                            Address = "123 Main St",
                            Name = "The Gourmet Hut",
                            Opening_Hours = 10,
                            Phone_Number = "987-654-3210"
                        },
                        new
                        {
                            RestaurantId = 2,
                            Address = "456 Side St",
                            Name = "The Pizza Place",
                            Opening_Hours = 12,
                            Phone_Number = "987-654-3211"
                        },
                        new
                        {
                            RestaurantId = 3,
                            Address = "789 Leaf Ln",
                            Name = "The Coffee Corner",
                            Opening_Hours = 8,
                            Phone_Number = "987-654-3212"
                        },
                        new
                        {
                            RestaurantId = 4,
                            Address = "321 Water St",
                            Name = "The Taco Tower",
                            Opening_Hours = 10,
                            Phone_Number = "987-654-3213"
                        },
                        new
                        {
                            RestaurantId = 5,
                            Address = "654 Hill St",
                            Name = "The Noodle Nest",
                            Opening_Hours = 9,
                            Phone_Number = "987-654-3214"
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TableId"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("TableId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            TableId = 1,
                            Capacity = 4,
                            RestaurantId = 1
                        },
                        new
                        {
                            TableId = 2,
                            Capacity = 2,
                            RestaurantId = 2
                        },
                        new
                        {
                            TableId = 3,
                            Capacity = 6,
                            RestaurantId = 3
                        },
                        new
                        {
                            TableId = 4,
                            Capacity = 4,
                            RestaurantId = 4
                        },
                        new
                        {
                            TableId = 5,
                            Capacity = 8,
                            RestaurantId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Employee", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Restaurant", "Restaurant")
                        .WithMany("Employees")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.MenuItem", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Restaurant", null)
                        .WithMany("Menu")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestaurantReservation.Db.Order", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Reservation", "Reservation")
                        .WithMany("Orders")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("RestaurantReservation.Db.OrderItem", b =>
                {
                    b.HasOne("RestaurantReservation.Db.MenuItem", "MenuItem")
                        .WithMany("Items")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Reservation", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Restaurant", "Restaurant")
                        .WithMany("Reservations")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Restaurant");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Table", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Restaurant", "Restaurant")
                        .WithMany("Tables")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Db.MenuItem", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Reservation", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Restaurant", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Menu");

                    b.Navigation("Reservations");

                    b.Navigation("Tables");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Table", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
