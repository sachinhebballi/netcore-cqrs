using FluentValidation;

namespace Api.Application.Query.GetEmployees
{
    public class GetEmployeesQueryValidator : AbstractValidator<GetEmployeesQuery>
    {
        public GetEmployeesQueryValidator()
        {
            RuleFor(x => x.Page)
                .Must(x => x > 0)
                .WithMessage("Page number should be greater than zero");

            RuleFor(x => x.PageSize)
                .Must(x => x > 0)
                .WithMessage("Page size should be greater than zero");
        }
    }
}
