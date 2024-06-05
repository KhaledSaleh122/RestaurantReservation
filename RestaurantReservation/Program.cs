// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using RestaurantReservation;
using RestaurantReservation.Db;

RestaurantReservationDbContext dbContext = new RestaurantReservationDbContext();

//await ListManagers();
async Task ListManagers()
{
    var managers = await dbContext.Employees.Where(p => p.Position == Position.Manager).ToListAsync();
    foreach (var manager in managers)
    {
        Console.WriteLine($"id: {manager.EmployeeId}, Name: {manager.First_Name}_{manager.Last_Name}, RestaurantId: {manager.RestaurantId}");
    }
}

//await GetReservationsByCustomer(1);
async Task GetReservationsByCustomer(int CustomerId)
{
    var reservationsCustomer = await dbContext.Customers.Where(p => p.CustomerId == CustomerId).Include(p => p.Reservations).FirstOrDefaultAsync();
    if (reservationsCustomer is null)
    {
        Console.WriteLine("Unknown Customer");
        return;
    }
    Console.WriteLine($"CustomerInfo: {reservationsCustomer.CustomerId} {reservationsCustomer.First_Name}_{reservationsCustomer.Last_Name}");
    Console.WriteLine("Reservation:");
    foreach (var reservation in reservationsCustomer.Reservations)
    {
        Console.WriteLine($"id : {reservation.ReservationId} Party size: {reservation.Party_size} TableId: {reservation.TableId}");
    }

}

//await ListOrdersAndMenuItems(1);
async Task ListOrdersAndMenuItems(int ReservationId)
{
    var ordersMenuItems = await dbContext.Orders
        .Where(p => p.ReservationId == ReservationId)
        .Include(t => t.OrderItems)
        .ThenInclude(t => t.MenuItem)
        .ToListAsync();
    foreach (var order in ordersMenuItems)
    {
        Console.WriteLine($"OrderId: {order.OrderId}, Total_Amount: {order.Total_amount}, Order_Date: {order.Order_date}");
        Console.WriteLine("--ORDER_ITEMS");
        foreach (var item in order.OrderItems)
        {
            Console.WriteLine($"--ItemId: {item.ItemId},name: {item.MenuItem.Name}, Quantity: {item.Quantity}");
        }
    }
}

//await ListOrderedMenuItems(1);
async Task ListOrderedMenuItems(int ReservationId)
{
    var ordersMenuItems = await dbContext.Orders
    .Where(p => p.ReservationId == ReservationId)
    .Include(t => t.OrderItems)
    .ThenInclude(t => t.MenuItem)
    .ToListAsync();
    Console.WriteLine("ORDERS_ITEMS");
    foreach (var order in ordersMenuItems)
    {
        foreach (var item in order.OrderItems)
        {
            Console.WriteLine($"-ItemId: {item.ItemId},name: {item.MenuItem.Name}, Quantity: {item.Quantity}");
        }
    }
}

//await CalculateAverageOrderAmount(1);
async Task CalculateAverageOrderAmount(int EmployeeId)
{
    var averageOrderAmount = await dbContext.Orders.Where(p => p.EmployeeId == EmployeeId).AverageAsync(c => c.Total_amount);
    Console.WriteLine($"Average_Order_Amount: {averageOrderAmount}");
}

//await ListCustomersReservationsUsingView();
async Task ListCustomersReservationsUsingView()
{
    var customerReservationRestaurant = await dbContext.CustomerReservationsRestaurants.ToListAsync();
    foreach (var crr in customerReservationRestaurant)
    {
        Console.WriteLine($"Customer_Name: {crr.Restaurent_Name}, Reservation_Date: {crr.Reservation_Date}, Party_Size: {crr.Party_Size}, Restaurent_Name: {crr.Restaurent_Name}");
    }
}

//await ListEmployeesRestaurantUsingView();
async Task ListEmployeesRestaurantUsingView()
{
    var employeesRestaurant = await dbContext.EmployeesRestaurant.ToListAsync();
    foreach (var er in employeesRestaurant)
    {
        Console.WriteLine($"Employee_Name: {er.Employee_Name}, Position: {er.Position}, Restaurent_Name: {er.Restaurant_Name}, Restaurant_PhoneNumber: {er.Restaurant_PhoneNumber}");
    }
}


////
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

await CalculateTotalRevenueByRestaurant(1);
async Task CalculateTotalRevenueByRestaurant(int RestraurentId)
{
    var totalRevenue = await restaurantRepository.GetTotalRevenueByRestaurant(RestraurentId);
    Console.WriteLine(totalRevenue);
}

/////////////////////

var employeeRepository = new EmployeeRepository(dbContext);

//await CreateEmployee();
async Task CreateEmployee()
{
    await employeeRepository.CreateEmployeeAsync(new Employee { First_Name = "John", Last_Name = "Doe", Position = Position.Manager, RestaurantId = 1 });
    Console.WriteLine("Employee added");
}

//await UpdateEmployee();
async Task UpdateEmployee()
{
    await employeeRepository.UpdateEmployeeAsync(new Employee { EmployeeId = 6, First_Name = "John", Last_Name = "Doe", Position = Position.Normal, RestaurantId = 2 });
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

//await CustomersWithLargeReservations(4);
async Task CustomersWithLargeReservations(int partySizeThreshold)
{
    var customers = await reservationRepository.GetCustomersWithLargeReservations(partySizeThreshold);
    foreach (var customer in customers)
    {
        Console.WriteLine($"Id: {customer.CustomerId}, Name: {customer.First_Name} {customer.Last_Name}, Email: {customer.Email}");
    }
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
    await orderRepository.CreateOrderAsync(new Order { Order_date = DateTime.Now, Total_amount = 29.97m, ReservationId = 4, EmployeeId = 1 });
    Console.WriteLine("Order added");
}

//await UpdateOrder();
async Task UpdateOrder()
{
    await orderRepository.UpdateOrderAsync(new Order { OrderId = 6, Order_date = DateTime.Now, Total_amount = 30.99m, ReservationId = 2, EmployeeId = 1 });
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
