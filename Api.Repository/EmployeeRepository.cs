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
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> FindAsync(string q, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }

        public Task UpdateAsync(Employee employee, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
