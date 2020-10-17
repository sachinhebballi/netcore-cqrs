using Api.Models.Models;
using Api.Repository;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Application.Command.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<Employee> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeAsync(command.EmployeeId, cancellationToken);

            if (employee == null) return null;

            employee.Active = false;

            await _employeeRepository.UpdateAsync(employee, cancellationToken);

            return _mapper.Map<Employee>(employee);
        }
    }
}
