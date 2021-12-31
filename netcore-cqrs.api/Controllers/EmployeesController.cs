using Api.Application.Command.AddEmployee;
using Api.Application.Command.DeleteEmployee;
using Api.Application.Command.UpdateEmployee;
using Api.Application.Query.GetEmployees;
using Api.Models.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;

namespace netcore_cqrs.api.Controllers
{
    /// <summary>
    /// Api controller for employees
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="EmployeesController"/> class
        /// </summary>
        /// <param name="mediator">Mediator</param>
        /// <param name="logger">Serilog logger instance</param>
        public EmployeesController(
            IMediator mediator,
            ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #region Query

        /// <summary>
        /// Gets all the employees
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Returns the list of employees</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEmployees(int pageNumber = 1, int pageSize = 10)
        {
            _logger.Debug("Get employees: {PageNumber} - {PageSize}", pageNumber, pageSize);

            var query = new GetEmployeesQuery
            {
                Page = pageNumber,
                PageSize = pageSize
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Gets the employee by id
        /// </summary>
        /// <param name="id">Id of the employee</param>
        /// <returns>Returns employee</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEmployee(int id)
        {
            _logger.Debug("Get employee for the id: {id}", id);

            var query = new GetEmployeeQuery
            {
                EmployeeId = id
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        #endregion

        #region Command

        /// <summary>
        /// Adds a new employee
        /// </summary>
        /// <param name="employee">Employee model</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Updates the employee
        /// </summary>
        /// <param name="employee">Employee model</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            _logger.Debug("Update new employee");

            var command = new UpdateEmployeeCommand
            {
                Employee = employee
            };

            await _mediator.Send(command);

            return Ok();
        }

        /// <summary>
        /// Deletes the employee
        /// </summary>
        /// <param name="id">Id of employee</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            _logger.Debug("Delete employee with id", id);

            var command = new DeleteEmployeeCommand
            {
                EmployeeId = id
            };

            await _mediator.Send(command);

            return Ok();
        }

        #endregion
    }
}
