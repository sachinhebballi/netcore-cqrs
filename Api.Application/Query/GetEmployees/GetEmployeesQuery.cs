using Api.Models.Request;
using MediatR;
using System.Collections.Generic;

namespace Api.Application.Query.GetEmployees
{
    public class GetEmployeesQuery : IRequest<IEnumerable<Employee>>
    {
        public int Page { get; set; }
        
        public int PageSize { get; set; }
    }
}
