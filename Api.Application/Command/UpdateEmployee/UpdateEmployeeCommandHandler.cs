using Api.Models.Models;
using Api.Repository;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Application.Command.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<Employee> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeAsync(command.Employee.EmployeeId, cancellationToken);

            if (employee == null) throw new FluentValidation.ValidationException($"Employee not found for the id {command.Employee.EmployeeId}");

            employee.FirstName = command.Employee.FirstName;
            employee.LastName = command.Employee.LastName;
            employee.Age = command.Employee.Age;
            employee.Address.UnitNumber = command.Employee.Address.UnitNumber;
            employee.Address.StreetNumber = command.Employee.Address.StreetNumber;
            employee.Address.StreetName = command.Employee.Address.StreetName;
            employee.Address.Suburb = command.Employee.Address.Suburb;
            employee.Address.City = command.Employee.Address.City;
            employee.Address.Postcode = command.Employee.Address.Postcode;

            await _employeeRepository.UpdateAsync(employee, cancellationToken);

            return _mapper.Map<Employee>(employee);
        }
    }
}
