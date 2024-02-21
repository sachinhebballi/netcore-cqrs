using Api.Application.Validators;
using FluentValidation;
using Request = Api.Models.Models;

namespace Api.Application.Command.DeleteEmployee
{
    public class DeleteEmployeeCommandValidator : AbstractValidator<Request.Employee>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(employee => employee)
                .SetValidator(new EmployeeValidator())
                .OverridePropertyName("");
        }
    }
}
