using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

        public async Task CreateReservationAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
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

    }
}
