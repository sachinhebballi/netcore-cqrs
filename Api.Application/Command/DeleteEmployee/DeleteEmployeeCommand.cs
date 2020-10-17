using Api.Models.Models;
using MediatR;

namespace Api.Application.Command.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest<Employee>
    {
        public int EmployeeId { get; set; }
    }
}
