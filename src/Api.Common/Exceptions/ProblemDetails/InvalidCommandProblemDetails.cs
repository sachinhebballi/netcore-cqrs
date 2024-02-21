using Microsoft.AspNetCore.Http;

namespace Api.Common.Exceptions.ProblemDetails
{
    public class InvalidCommandProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public InvalidCommandProblemDetails(InvalidCommandException ex)
        {
            Title = "BadRequest";
            Status = StatusCodes.Status400BadRequest;
            Detail = ex.Details;
            Type = "https://problem.api.liberohealth.com.au?type=validationError";
        }
    }
}
