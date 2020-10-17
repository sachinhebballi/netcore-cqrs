using Api.Models.Models;
using MediatR;

namespace Api.Application.Command.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest<Employee>
    {
        public Employee Employee { get; set; }
    }
}
