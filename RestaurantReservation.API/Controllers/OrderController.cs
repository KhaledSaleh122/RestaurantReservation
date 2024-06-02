using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models.Order;
using RestaurantReservation.API.Models.Table;
using RestaurantReservation.Db;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;

namespace RestaurantReservation.API.Controllers
{
    [Route("api/restaurants/tables/{tableId}/reservations/{reservationId}/orders")]
    [Authorize(Policy = "Employee")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly OrderRepository _repository;
        private readonly RestaurantRepository restaurantRepository;
        private readonly TableRepository tableRepository;
        private readonly ReservationRepository reservationRepository;
        private readonly OrderItemRepository orderItemRepository;
        private readonly MenuItemRepository menuItemRepository;
        private readonly RestaurantReservationDbContext context;
        private readonly IMapper _mapper;

        public OrderController(OrderRepository repository, RestaurantRepository restaurantRepository,
            TableRepository tableRepository, ReservationRepository reservationRepository, OrderItemRepository orderItemRepository,
            MenuItemRepository menuItemRepository, RestaurantReservationDbContext context)
        {
            _repository = repository;
            this.restaurantRepository = restaurantRepository;
            this.tableRepository = tableRepository;
            this.reservationRepository = reservationRepository;
            this.orderItemRepository = orderItemRepository;
            this.menuItemRepository = menuItemRepository;
            this.context = context;
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDto>();
                cfg.CreateMap<Order, OrderWithoutItemsDto>();
                cfg.CreateMap<OrderCreateDto, Order>();
                cfg.CreateMap<OrderItem, OrderItemDto>();
            });
            _mapper = configuration.CreateMapper();
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderWithoutItemsDto>>> GetOrders(int tableId, int reservationId)
        {
            var restaurantId = int.Parse(User.Claims.First(c => c.Type == "RestaurentId").Value);
            var table = await tableRepository.GetTable(restaurantId, tableId);
            if (table is null)
            {
                return NotFound();
            }

            var reservation = await reservationRepository.GetReservation(restaurantId, tableId, reservationId);
            if (reservation is null)
            {
                return NotFound();
            }
            var employeeId = int.Parse(User.Claims.First(c => c.Type == "Id").Value);
            var orders = await _repository.GetAllOrders(reservationId, employeeId);
            return Ok(_mapper.Map<IEnumerable<OrderWithoutItemsDto>>(orders));
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int tableId, int reservationId, int orderId)
        {
            var restaurantId = int.Parse(User.Claims.First(c => c.Type == "RestaurentId").Value);
            var table = await tableRepository.GetTable(restaurantId, tableId);
            if (table is null)
            {
                return NotFound();
            }

            var reservation = await reservationRepository.GetReservation(restaurantId, tableId, reservationId);
            if (reservation is null)
            {
                return NotFound();
            }
            var employeeId = int.Parse(User.Claims.First(c => c.Type == "Id").Value);
            var order = await _repository.GetOrder(reservationId, employeeId, orderId);
            if (order is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OrderDto>(order));
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder(int tableId, int reservationId, OrderCreateDto orderCreate)
        {
            var restaurantId = int.Parse(User.Claims.First(c => c.Type == "RestaurentId").Value);
            var table = await tableRepository.GetTable(restaurantId, tableId);
            if (table is null)
            {
                return NotFound();
            }

            var reservation = await reservationRepository.GetReservation(restaurantId, tableId, reservationId);
            if (reservation is null)
            {
                return NotFound();
            }
            var employeeId = int.Parse(User.Claims.First(c => c.Type == "Id").Value);
            var items = new Dictionary<MenuItem, int>();
            foreach (var orderItem in orderCreate.OrderItems)
            {
                var item = await menuItemRepository.GetItem(restaurantId, orderItem.ItemId);
                if (item is null)
                {
                    return BadRequest($"Item With Id {orderItem.ItemId} doesn't exist");
                }
                items.Add(item, orderItem.Quantity);
            }

            using var transaction = context.Database.BeginTransaction();
            try
            {

                var orderInfo = new Order()
                {
                    EmployeeId = employeeId,
                    Order_date = orderCreate.Order_date,
                    ReservationId = reservationId,
                    Total_amount = (decimal)items.Sum(i => i.Key.Price * i.Value)
                };
                var order = await _repository.CreateOrderAsync(orderInfo);

                foreach (var item in items)
                {
                    var orderItem = new OrderItem() { ItemId = item.Key.ItemId, OrderId = order.OrderId, Quantity = item.Value };
                    await orderItemRepository.CreateOrderItemAsync(orderItem);
                }
                transaction.Commit();
                return Ok(_mapper.Map<OrderDto>(order));
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }


        [HttpPut("{orderId}")]
        public async Task<ActionResult<OrderDto>> UpdateOrder(int tableId, int reservationId, int orderId, OrderCreateDto orderCreate)
        {
            var restaurantId = int.Parse(User.Claims.First(c => c.Type == "RestaurentId").Value);
            var table = await tableRepository.GetTable(restaurantId, tableId);
            if (table is null)
            {
                return NotFound();
            }

            var reservation = await reservationRepository.GetReservation(restaurantId, tableId, reservationId);
            if (reservation is null)
            {
                return NotFound();
            }
            var employeeId = int.Parse(User.Claims.First(c => c.Type == "Id").Value);

            var order = await _repository.GetOrder(reservationId, employeeId, orderId);
            if (order is null)
            {
                return NotFound();
            }

            var items = new Dictionary<MenuItem, int>();
            foreach (var orderItem in orderCreate.OrderItems)
            {
                var item = await menuItemRepository.GetItem(restaurantId, orderItem.ItemId);
                if (item is null)
                {
                    return BadRequest($"Item With Id {orderItem.ItemId} doesn't exist");
                }
                items.Add(item, orderItem.Quantity);
            }
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Orders.First(p => p.OrderId == orderId).OrderItems.Clear();
                await context.SaveChangesAsync();
                order.Total_amount = (decimal)items.Sum(i => i.Key.Price * i.Value);
                foreach (var item in items)
                {
                    var orderItem = new OrderItem() { ItemId = item.Key.ItemId, OrderId = order.OrderId, Quantity = item.Value };
                    await orderItemRepository.CreateOrderItemAsync(orderItem);
                }
                transaction.Commit();
                return Ok(_mapper.Map<OrderDto>(order));
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        [HttpDelete("{orderId}")]
        public async Task<ActionResult> DeleteOrder(int tableId, int reservationId, int orderId)
        {
            var restaurantId = int.Parse(User.Claims.First(c => c.Type == "RestaurentId").Value);
            var table = await tableRepository.GetTable(restaurantId, tableId);
            if (table is null)
            {
                return NotFound();
            }

            var reservation = await reservationRepository.GetReservation(restaurantId, tableId, reservationId);
            if (reservation is null)
            {
                return NotFound();
            }
            var employeeId = int.Parse(User.Claims.First(c => c.Type == "Id").Value);

            var order = await _repository.GetOrder(reservationId, employeeId, orderId);
            if (order is null)
            {
                return NotFound();
            }
            await _repository.DeleteOrderAsync(orderId);
            return Ok();
        }


    }
}
