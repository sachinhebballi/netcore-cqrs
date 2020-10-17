using Api.Models.Models;
using MediatR;

namespace Api.Application.Query.GetEmployees
{
    public class GetEmployeeQuery : IRequest<Employee>
    {
        public int EmployeeId { get; set; }
    }
}
