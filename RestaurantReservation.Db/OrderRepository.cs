using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation
{
    public class OrderRepository
    {
        private readonly RestaurantReservationDbContext _context;
        public OrderRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
        public async Task UpdateOrderAsync(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Order>> GetAllOrders(int reservationId, int employeeId)
        {
            return await _context.Orders.Where(o => o.ReservationId == reservationId && o.EmployeeId == employeeId).ToListAsync();
        }

        public async Task<Order?> GetOrder(int reservationId, int employeeId, int orderId)
        {
            return await _context.Orders.Where(o => o.ReservationId == reservationId && o.EmployeeId == employeeId && o.OrderId == orderId).Include(c => c.OrderItems).FirstOrDefaultAsync();
        }

        public async Task<List<Order>> GetAllOrdersForEmployee(int employeeId)
        {
            return await _context.Orders.Where(o => o.EmployeeId == employeeId).ToListAsync();
        }
    }
}
