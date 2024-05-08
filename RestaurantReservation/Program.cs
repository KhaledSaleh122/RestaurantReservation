// See https://aka.ms/new-console-template for more information
using RestaurantReservation;
using RestaurantReservation.Db;

RestaurantReservationDbContext dbContext = new RestaurantReservationDbContext();

var customerRepository = new CustomerRepository(dbContext);
//await CreateCustomer();
async Task CreateCustomer()
{
    await customerRepository.CreateCustomerAsync(new Customer() { Email = "g", First_Name = "n", Last_Name = "m", Phone_number = "059" });
    Console.WriteLine("Customer add");
}
//await UpdateCustomer();
async Task UpdateCustomer()
{
    await customerRepository.UpdateCustomerAsync(new Customer() { CustomerId = 6, Email = "g@mail", First_Name = "Khaled", Last_Name = "Saleh", Phone_number = "059" });
    Console.WriteLine("Customer information updated");
}

//await DeleteCustomer();
async Task DeleteCustomer()
{
    await customerRepository.DeleteCustomerAsync(6);
    Console.WriteLine("Customer Deleted");
}

/////////////////

var restaurantRepository = new RestaurantRepository(dbContext);

//await CreateRestaurant();
async Task CreateRestaurant()
{
    await restaurantRepository.CreateRestaurantAsync(new Restaurant { Name = "Sunset Bistro", Address = "123 Sunset Blvd", Phone_Number = "555-1234", Opening_Hours = 10 });
    Console.WriteLine("Restaurant added");
}

//await UpdateRestaurant();
async Task UpdateRestaurant()
{
    await restaurantRepository.UpdateRestaurantAsync(new Restaurant { RestaurantId = 6, Name = "Sunset Bistro", Address = "123 Sunset Blvd Updated", Phone_Number = "555-1234", Opening_Hours = 11 });
    Console.WriteLine("Restaurant information updated");
}

//await DeleteRestaurant();
async Task DeleteRestaurant()
{
    await restaurantRepository.DeleteRestaurantAsync(6);
    Console.WriteLine("Restaurant Deleted");
}

/////////////////////

var employeeRepository = new EmployeeRepository(dbContext);

//await CreateEmployee();
async Task CreateEmployee()
{
    await employeeRepository.CreateEmployeeAsync(new Employee { First_Name = "John", Last_Name = "Doe", Position = 1, RestaurantId = 1 });
    Console.WriteLine("Employee added");
}

//await UpdateEmployee();
async Task UpdateEmployee()
{
    await employeeRepository.UpdateEmployeeAsync(new Employee { EmployeeId = 6, First_Name = "John", Last_Name = "Doe", Position = 2, RestaurantId = 2 });
    Console.WriteLine("Employee information updated");
}

//await DeleteEmployee();
async Task DeleteEmployee()
{
    await employeeRepository.DeleteEmployeeAsync(6);
    Console.WriteLine("Employee Deleted");
}

////////////////////

var tableRepository = new TableRepository(dbContext);

//await CreateTable();
async Task CreateTable()
{
    await tableRepository.CreateTableAsync(new Table { Capacity = 4, RestaurantId = 1 });
    Console.WriteLine("Table added");
}

//await UpdateTable();
async Task UpdateTable()
{
    await tableRepository.UpdateTableAsync(new Table { TableId = 6, Capacity = 6, RestaurantId = 5 });
    Console.WriteLine("Table information updated");
}

//await DeleteTable();
async Task DeleteTable()
{
    await tableRepository.DeleteTableAsync(1);
    Console.WriteLine("Table Deleted");
}

//////////////////////

var reservationRepository = new ReservationRepository(dbContext);

//await CreateReservation();
async Task CreateReservation()
{
    await reservationRepository.CreateReservationAsync(new Reservation { Reservation_date = DateTime.Now.AddDays(1), Party_size = 4, CustomerId = 1, TableId = 2, RestaurantId = 1 });
    Console.WriteLine("Reservation added");
}

//await UpdateReservation();
async Task UpdateReservation()
{
    await reservationRepository.UpdateReservationAsync(new Reservation { ReservationId = 8, Reservation_date = DateTime.Now.AddDays(1), Party_size = 2, CustomerId = 1, TableId = 3, RestaurantId = 1 });
    Console.WriteLine("Reservation information updated");
}

//await DeleteReservation();
async Task DeleteReservation()
{
    await reservationRepository.DeleteReservationAsync(8);
    Console.WriteLine("Reservation Deleted");
}

/////////////

var menuItemRepository = new MenuItemRepository(dbContext);

//await CreateMenuItem();
async Task CreateMenuItem()
{
    await menuItemRepository.CreateMenuItemAsync(new MenuItem { Name = "Cheeseburger", Description = "A classic cheeseburger with all-natural beef and cheddar cheese.", Price = 8.99, RestaurantId = 1 });
    Console.WriteLine("MenuItem added");
}

//await UpdateMenuItem();
async Task UpdateMenuItem()
{
    await menuItemRepository.UpdateMenuItemAsync(new MenuItem { ItemId = 6, Name = "Cheeseburger Deluxe", Description = "A classic cheeseburger with all-natural beef, cheddar cheese, and special sauce.", Price = 9.99, RestaurantId = 1 });
    Console.WriteLine("MenuItem information updated");
}

//await DeleteMenuItem();
async Task DeleteMenuItem()
{
    await menuItemRepository.DeleteMenuItemAsync(6);
    Console.WriteLine("MenuItem Deleted");
}

//////////////////////////

var orderRepository = new OrderRepository(dbContext);

//await CreateOrder();
async Task CreateOrder()
{
    await orderRepository.CreateOrderAsync(new Order { Order_date = DateTime.Now, Total_amount = 29.97, ReservationId = 4, EmployeeId = 1 });
    Console.WriteLine("Order added");
}

//await UpdateOrder();
async Task UpdateOrder()
{
    await orderRepository.UpdateOrderAsync(new Order { OrderId = 6, Order_date = DateTime.Now, Total_amount = 30.99, ReservationId = 2, EmployeeId = 1 });
    Console.WriteLine("Order information updated");
}

//await DeleteOrder();
async Task DeleteOrder()
{
    await orderRepository.DeleteOrderAsync(6);
    Console.WriteLine("Order Deleted");
}

///////////////////////

var orderItemRepository = new OrderItemRepository(dbContext);

//await CreateOrderItem();
async Task CreateOrderItem()
{
    await orderItemRepository.CreateOrderItemAsync(new OrderItem { Quantity = 2, OrderId = 2, ItemId = 1 });
    Console.WriteLine("OrderItem added");
}

//await UpdateOrderItem();
async Task UpdateOrderItem()
{
    await orderItemRepository.UpdateOrderItemAsync(new OrderItem { OrderItemId = 6, Quantity = 3, OrderId = 2, ItemId = 1 });
    Console.WriteLine("OrderItem information updated");
}

//await DeleteOrderItem();
async Task DeleteOrderItem()
{
    await orderItemRepository.DeleteOrderItemAsync(6);
    Console.WriteLine("OrderItem Deleted");
}


