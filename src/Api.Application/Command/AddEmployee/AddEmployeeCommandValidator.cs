using Api.Application.Validators;
using FluentValidation;
using Request = Api.Models.Models;

namespace Api.Application.Command.AddEmployee
{
    public class AddEmployeeCommandValidator : AbstractValidator<Request.Employee>
    {
        public AddEmployeeCommandValidator()
        {
            RuleFor(employee => employee)
                .SetValidator(new EmployeeValidator())
                .OverridePropertyName("");
        }
    }
}
