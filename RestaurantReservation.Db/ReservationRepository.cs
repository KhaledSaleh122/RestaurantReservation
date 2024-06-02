using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantReservation.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation
{
    public class ReservationRepository
    {
        private readonly RestaurantReservationDbContext _context;
        public ReservationRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reservation>> GetAllReservations()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task<Reservation?> GetReservation(int id)
        {
            return await _context.Reservations.FirstOrDefaultAsync(c => c.ReservationId == id);
        }
        public async Task<Reservation> CreateReservationAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            _context.Entry(reservation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReservationAsync(int reservationId)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Customer>> GetCustomersWithLargeReservations(int partySize)
        {
            var customers = await _context.Customers
                .FromSqlInterpolated($"EXEC dbo.GetCustomersWithLargeReservations {partySize}")
                .ToListAsync();

            return customers;
        }

        public async Task<Reservation?> GetReservation(int restaurantId, int tableId, int reservationId)
        {
            return await _context.Reservations.FirstOrDefaultAsync(c => c.ReservationId == reservationId && c.TableId == tableId && c.RestaurantId == restaurantId);
        }

        public async Task<List<Reservation>> GetAllReservations(int restaurantId, int tableId)
        {
            return await _context.Reservations.Where(c => c.RestaurantId == restaurantId && c.TableId == tableId).ToListAsync();
        }

        public async Task<List<Reservation>> GetAllReservationsCustomer(int restaurantId, int customerId)
        {
            return await _context.Reservations.Where(c => c.RestaurantId == restaurantId && c.CustomerId == customerId).ToListAsync();
        }

        public async Task<List<OrderItem>> GetReservationMenuItems(int reservationId)
        {
            var reservation = await _context.Reservations.Include(p=>p.Orders).ThenInclude(p=>p.OrderItems).FirstAsync(c => c.ReservationId == reservationId);
            var items = reservation.Orders.SelectMany(p => p.OrderItems).ToList();
            return items;
        }
    }
}
