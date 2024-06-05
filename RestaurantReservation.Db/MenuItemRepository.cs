using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation
{
    public class MenuItemRepository
    {
        private readonly RestaurantReservationDbContext _context;
        public MenuItemRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<MenuItem> CreateMenuItemAsync(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();
            return menuItem;
        }

        public async Task UpdateMenuItemAsync(MenuItem menuItem)
        {
            _context.Entry(menuItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuItemAsync(int itemId)
        {
            var menuItem = await _context.MenuItems.FindAsync(itemId);
            if (menuItem != null)
            {
                _context.MenuItems.Remove(menuItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<MenuItem?> GetItem(int restaurantId, int itemId)
        {
            return await _context.MenuItems.Where(p => p.RestaurantId == restaurantId && p.ItemId == itemId).FirstOrDefaultAsync();
        }

        public async Task<List<MenuItem>> GetAllMenuItems(int restaurantId)
        {
            return await _context.MenuItems.Where(p => p.RestaurantId == restaurantId).ToListAsync();
        }
    }
}
