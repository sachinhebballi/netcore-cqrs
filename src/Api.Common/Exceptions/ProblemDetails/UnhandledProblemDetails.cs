using Microsoft.AspNetCore.Http;

namespace Api.Common.Exceptions.ProblemDetails
{
    public class UnhandledProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public UnhandledProblemDetails()
        {
            Title = "Error";
            Status = StatusCodes.Status500InternalServerError;
            Detail = "Exception occurred while processing the request";
        }
    }
}
