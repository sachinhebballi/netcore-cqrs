using FluentValidation;
using Request = Api.Models.Request;

namespace Api.Application.Command.AddEmployee
{
    public class AddEmployeeCommandValidator : AbstractValidator<Request.Employee>
    {
        public AddEmployeeCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required");
        }
    }
}
