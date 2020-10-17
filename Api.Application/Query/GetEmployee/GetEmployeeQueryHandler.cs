using Api.Repository;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Request = Api.Models.Models;

namespace Api.Application.Query.GetEmployees
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, Request.Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<Request.Employee> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetEmployeeAsync(request.EmployeeId, cancellationToken);

            return _mapper.Map<Request.Employee>(employees);
        }
    }
}
