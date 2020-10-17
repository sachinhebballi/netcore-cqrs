using Api.Models.Models;
using MediatR;

namespace Api.Application.Command.AddEmployee
{
    public class AddEmployeeCommand : IRequest
    {
        public Employee Employee { get; set; }
    }
}
