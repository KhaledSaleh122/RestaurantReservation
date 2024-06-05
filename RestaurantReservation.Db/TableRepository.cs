using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation
{
    public class TableRepository
    {
        private readonly RestaurantReservationDbContext _context;
        public TableRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<Table> CreateTableAsync(Table table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();
            return table;
        }

        public async Task UpdateTableAsync(Table table)
        {
            _context.Entry(table).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTableAsync(int tableId)
        {
            var table = await _context.Tables.FindAsync(tableId);
            if (table != null)
            {
                _context.Tables.Remove(table);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Table?> GetTable(int restaurantId, int tableId)
        {
            var table = await _context.Tables.Where(t => t.TableId == tableId && t.RestaurantId == restaurantId).FirstOrDefaultAsync();
            return table;
        }

        public async Task<List<Table>> GetAllTables()
        {
            return await _context.Tables.ToListAsync();
        }

        public async Task<Table?> GetTable(int tableId)
        {
            return await _context.Tables.Where(t => t.TableId == tableId).FirstOrDefaultAsync();
        }

        public async Task<List<Table>> GetAllTables(int restaurantId)
        {
            return await _context.Tables.Where(t => t.RestaurantId == restaurantId).ToListAsync();
        }
    }
}
