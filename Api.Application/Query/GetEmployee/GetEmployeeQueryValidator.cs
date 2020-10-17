using FluentValidation;

namespace Api.Application.Query.GetEmployees
{
    public class GetEmployeeQueryValidator : AbstractValidator<GetEmployeeQuery>
    {
        public GetEmployeeQueryValidator()
        {
            RuleFor(x => x.EmployeeId)
                .Must(x => x > 0)
                .WithMessage("Employee id is invalid");
        }
    }
}
