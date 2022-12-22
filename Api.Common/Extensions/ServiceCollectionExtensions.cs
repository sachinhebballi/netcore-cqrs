using Api.Common.Exceptions;
using Api.Common.Exceptions.ProblemDetails;
using FluentValidation;
using Hellang.Middleware.ProblemDetails;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;

namespace Api.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomProblemDetails(this IServiceCollection services)
        {
            services.AddProblemDetails(d =>
            {
                d.Map<MissingResourceException>(ex => new MissingResourceProblemDetails(ex));
                d.Map<InvalidCommandException>(ex => new InvalidCommandProblemDetails(ex));
                d.Map<ValidationException>(ex => new ValidationErrorProblemDetails(ex));
                d.Map<System.ComponentModel.DataAnnotations.ValidationException>(_ => new Microsoft.AspNetCore.Mvc.ProblemDetails
                {
                    Title = "BadRequest",
                    Status = (int)HttpStatusCode.BadRequest,
                    Detail = _.Message
                });
                d.Map<Exception>(_ => new UnhandledProblemDetails());
                d.IncludeExceptionDetails = (ctx, ex) =>
                {
                    // Fetch services from HttpContext.RequestServices
                    var env = ctx.RequestServices.GetRequiredService<IHostEnvironment>();
                    return env.IsDevelopment();
                };
            });
        }
    }
}
