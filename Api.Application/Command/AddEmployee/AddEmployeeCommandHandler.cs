using Api.Repository;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain = Api.Models.Domain;

namespace Api.Application.Command.AddEmployee
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public AddEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddEmployeeCommand command, CancellationToken cancellationToken)
        {
            await _employeeRepository.AddAsync(_mapper.Map<Domain.Employee>(command.Employee), cancellationToken);

            return Unit.Value;
        }
    }
}
