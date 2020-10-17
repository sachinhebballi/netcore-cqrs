using Api.Application.Validators;
using FluentValidation;
using Request = Api.Models.Models;

namespace Api.Application.Command.AddEmployee
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<Request.Employee>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(employee => employee)
                .SetValidator(new EmployeeValidator())
                .OverridePropertyName("");
        }
    }
}
