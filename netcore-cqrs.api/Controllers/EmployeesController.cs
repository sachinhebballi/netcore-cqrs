using Api.Application.Command.AddEmployee;
using Api.Application.Query.GetEmployees;
using Api.Models.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;

namespace netcore_cqrs.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public EmployeesController(
            IMediator mediator,
            ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees(int pageNumber = 1, int pageSize = 10)
        {
            _logger.Debug("Get employees: {PageNumber} - {PageSize}", pageNumber, pageSize);

            var query = new GetEmployeesQuery
            {
                Page = pageNumber,
                PageSize = pageSize
            };

            var result =  await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            _logger.Debug("Add new employee");

            var command = new AddEmployeeCommand
            {
                Employee = employee
            };

            await _mediator.Send(command);

            return Ok();
        }
    }
}
