using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation
{
    public class RestaurantRepository
    {
        private readonly RestaurantReservationDbContext _context;
        public RestaurantRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }
        public async Task CreateRestaurantAsync(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRestaurantAsync(Restaurant restaurant)
        {
            _context.Entry(restaurant).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRestaurantAsync(int restaurantId)
        {
            var restaurant = await _context.Restaurants.FindAsync(restaurantId);
            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
                await _context.SaveChangesAsync();
            }
        }
    }
}
