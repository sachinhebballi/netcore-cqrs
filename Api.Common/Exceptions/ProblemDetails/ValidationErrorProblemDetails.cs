using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Api.Common.Exceptions.ProblemDetails
{
    public class ValidationErrorProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public ValidationErrorProblemDetails(ValidationException ex)
        {
            Title = "BadRequest";
            Status = StatusCodes.Status400BadRequest;
            Detail = ex.Message;
            Type = "https://problem.api.liberohealth.com.au?type=validationError";
        }
    }
}
