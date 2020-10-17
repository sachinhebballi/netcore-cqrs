using Api.Models.Models;
using FluentValidation;

namespace Api.Application.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required");

            RuleFor(x => x.Age)
                .NotEmpty()
                .WithMessage("Age is required")
                .Must(x => x > 0)
                .WithMessage("Age is invalid.");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Address is required");
        }
    }
}
