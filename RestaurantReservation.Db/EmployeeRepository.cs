﻿using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation
{
    public class EmployeeRepository
    {
        private readonly RestaurantReservationDbContext _context;
        public EmployeeRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<List<Employee>> GetAllEmployees(int resturentId)
        {
            return await _context.Employees.Where(r => r.RestaurantId == resturentId).ToListAsync();
        }

        public async Task<Employee?> GetEmployee(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(c => c.EmployeeId == id);
        }

        public async Task<Employee?> GetEmployee(int resId, int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(c => c.EmployeeId == id && c.RestaurantId == resId);
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Employee?> GetEmployee(string firstName, string lastName, int restaurantId)
        {
            return await _context.Employees.FirstOrDefaultAsync(c => c.First_Name == firstName && c.RestaurantId == restaurantId && c.Last_Name == lastName);
        }

        public async Task<List<Employee>> GetAllManagers()
        {
            return await _context.Employees.Where(c => c.Position == Position.Manager).ToListAsync();
        }
    }
}
