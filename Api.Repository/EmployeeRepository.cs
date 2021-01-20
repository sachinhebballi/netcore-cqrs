using Api.Models.Domain;
using Api.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeesContext _context;

        public EmployeeRepository(EmployeesContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Employee employee, CancellationToken cancellationToken)
        {
            await _context.AddAsync(employee, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(_ => _.EmployeeId == id, cancellationToken);

            if (employee == null) throw new Exception("Employee not found");

            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Employee>> SearchAsync(string q, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .Include(_ => _.Address)
                .AsNoTracking()
                .Where(_ => _.FirstName.Contains(q) || _.LastName.Contains(q))
                .ToListAsync(cancellationToken);
        }

        public async Task<Employee> GetEmployeeAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .Include(_ => _.Address)
                .FirstOrDefaultAsync(_ => _.EmployeeId == id, cancellationToken);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .Include(_ => _.Address)
                .AsNoTracking()
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(Employee employee, CancellationToken cancellationToken)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
