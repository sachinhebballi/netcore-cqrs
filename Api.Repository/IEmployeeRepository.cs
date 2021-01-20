using Api.Models.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync(int page, int pageSize, CancellationToken cancellationToken);

        Task<Employee> GetEmployeeAsync(int id, CancellationToken cancellationToken);

        Task<IEnumerable<Employee>> SearchAsync(string q, CancellationToken cancellationToken);

        Task AddAsync(Employee employee, CancellationToken cancellationToken);

        Task UpdateAsync(Employee employee, CancellationToken cancellationToken);

        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
