using Microsoft.AspNetCore.Http;

namespace Api.Common.Exceptions.ProblemDetails
{
    public class MissingResourceProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public MissingResourceProblemDetails(MissingResourceException ex)
        {
            Title = ex.Message;
            Status = StatusCodes.Status404NotFound;
            Detail = ex.Details;
            Type = "https://problem.api.liberohealth.com.au?type=notFoundError";
        }
    }
}
