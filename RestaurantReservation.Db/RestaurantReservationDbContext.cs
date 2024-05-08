using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db
{
    public class RestaurantReservationDbContext : DbContext
    {
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Data Source=KHALEDSALEH;Initial Catalog=RestaurantReservationCore;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"
            );

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                .HasOne(p => p.MenuItem)
                .WithMany(p => p.Items)
                .HasForeignKey(p => p.ItemId);
            // Seed data for Customers

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, First_Name = "Alice", Last_Name = "Johnson", Email = "alice.johnson@example.com", Phone_number = "123-456-7890" },
                new Customer { CustomerId = 2, First_Name = "Bob", Last_Name = "Smith", Email = "bob.smith@example.com", Phone_number = "123-456-7891" },
                new Customer { CustomerId = 3, First_Name = "Carol", Last_Name = "Williams", Email = "carol.williams@example.com", Phone_number = "123-456-7892" },
                new Customer { CustomerId = 4, First_Name = "David", Last_Name = "Jones", Email = "david.jones@example.com", Phone_number = "123-456-7893" },
                new Customer { CustomerId = 5, First_Name = "Eva", Last_Name = "Brown", Email = "eva.brown@example.com", Phone_number = "123-456-7894" }
            );
            // Seed data for Restaurants
            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant { RestaurantId = 1, Name = "The Gourmet Hut", Address = "123 Main St", Phone_Number = "987-654-3210", Opening_Hours = 10 },
                new Restaurant { RestaurantId = 2, Name = "The Pizza Place", Address = "456 Side St", Phone_Number = "987-654-3211", Opening_Hours = 12 },
                new Restaurant { RestaurantId = 3, Name = "The Coffee Corner", Address = "789 Leaf Ln", Phone_Number = "987-654-3212", Opening_Hours = 8 },
                new Restaurant { RestaurantId = 4, Name = "The Taco Tower", Address = "321 Water St", Phone_Number = "987-654-3213", Opening_Hours = 10 },
                new Restaurant { RestaurantId = 5, Name = "The Noodle Nest", Address = "654 Hill St", Phone_Number = "987-654-3214", Opening_Hours = 9 }
            );

            // Seed data for Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, First_Name = "Olivia", Last_Name = "Miller", Position = 1, RestaurantId = 1 },
                new Employee { EmployeeId = 2, First_Name = "Noah", Last_Name = "Davis", Position = 2, RestaurantId = 2 },
                new Employee { EmployeeId = 3, First_Name = "Liam", Last_Name = "Garcia", Position = 1, RestaurantId = 3 },
                new Employee { EmployeeId = 4, First_Name = "Sophia", Last_Name = "Rodriguez", Position = 2, RestaurantId = 4 },
                new Employee { EmployeeId = 5, First_Name = "Mason", Last_Name = "Martinez", Position = 1, RestaurantId = 5 }
            );

            // Seed data for Tables
            modelBuilder.Entity<Table>().HasData(
                new Table { TableId = 1, Capacity = 4, RestaurantId = 1 },
                new Table { TableId = 2, Capacity = 2, RestaurantId = 2 },
                new Table { TableId = 3, Capacity = 6, RestaurantId = 3 },
                new Table { TableId = 4, Capacity = 4, RestaurantId = 4 },
                new Table { TableId = 5, Capacity = 8, RestaurantId = 5 }
            );

            // Seed data for Reservations
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { ReservationId = 1, Reservation_date = DateTime.Now.AddDays(1), Party_size = 2, CustomerId = 1, TableId = 1, RestaurantId = 1 },
                new Reservation { ReservationId = 2, Reservation_date = DateTime.Now.AddDays(1), Party_size = 4, CustomerId = 2, TableId = 2, RestaurantId = 2 },
                new Reservation { ReservationId = 3, Reservation_date = DateTime.Now.AddDays(1), Party_size = 6, CustomerId = 3, TableId = 3, RestaurantId = 3 },
                new Reservation { ReservationId = 4, Reservation_date = DateTime.Now.AddDays(1), Party_size = 3, CustomerId = 4, TableId = 4, RestaurantId = 4 },
                new Reservation { ReservationId = 5, Reservation_date = DateTime.Now.AddDays(1), Party_size = 8, CustomerId = 5, TableId = 5, RestaurantId = 5 }
            );

            // Seed data for MenuItems
            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { ItemId = 1, Name = "Spaghetti Carbonara", Description = "Classic Italian pasta with creamy egg sauce and bacon bits.", Price = 12.00, RestaurantId = 1 },
                new MenuItem { ItemId = 2, Name = "Margherita Pizza", Description = "Simple and classic pizza with tomatoes, fresh mozzarella, and basil.", Price = 10.00, RestaurantId = 1 },
                new MenuItem { ItemId = 3, Name = "Caesar Salad", Description = "Crisp romaine lettuce with parmesan cheese, croutons, and Caesar dressing.", Price = 8.00, RestaurantId = 1 },
                new MenuItem { ItemId = 4, Name = "Beef Burger", Description = "Juicy grilled beef patty with lettuce, tomato, and secret sauce.", Price = 11.00, RestaurantId = 2 },
                new MenuItem { ItemId = 5, Name = "Fish and Chips", Description = "Traditional beer-battered fish served with crispy fries.", Price = 15.00, RestaurantId = 2 }
            );

            // Seed data for OrderItems
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { OrderItemId = 1, Quantity = 2, OrderId = 1, ItemId = 1 },
                new OrderItem { OrderItemId = 2, Quantity = 1, OrderId = 1, ItemId = 3 },
                new OrderItem { OrderItemId = 3, Quantity = 3, OrderId = 2, ItemId = 2 },
                new OrderItem { OrderItemId = 4, Quantity = 1, OrderId = 2, ItemId = 4 },
                new OrderItem { OrderItemId = 5, Quantity = 2, OrderId = 3, ItemId = 5 }
            );

            // Seed data for Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, Order_date = DateTime.Now.AddDays(-1), Total_amount = 35.00, ReservationId = 1, EmployeeId = 1 },
                new Order { OrderId = 2, Order_date = DateTime.Now.AddDays(-2), Total_amount = 50.00, ReservationId = 2, EmployeeId = 2 },
                new Order { OrderId = 3, Order_date = DateTime.Now.AddDays(-3), Total_amount = 45.00, ReservationId = 3, EmployeeId = 3 },
                new Order { OrderId = 4, Order_date = DateTime.Now.AddDays(-4), Total_amount = 30.00, ReservationId = 4, EmployeeId = 4 },
                new Order { OrderId = 5, Order_date = DateTime.Now.AddDays(-5), Total_amount = 25.00, ReservationId = 5, EmployeeId = 5 }
            );

        }
    }
}
