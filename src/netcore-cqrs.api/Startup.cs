using Api.Common.Models.Common;
using Api.Persistence;
using FluentValidation.AspNetCore;
using Hellang.Middleware.ProblemDetails;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using netcore_cqrs.api.Extensions;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace netcore_cqrs.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = new AppSettings();
            Configuration.Bind("appSettings", appSettings);
            services.TryAddSingleton(appSettings);

            services.AddDbContext<EmployeesContext>(options =>
            {
                options.UseInMemoryDatabase("Employees");
            });

            services
                .AddMvc()
                .AddJsonOptions(opts =>
                {
                    opts.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    opts.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                });

            services.AddControllers();

            var assembly = AppDomain.CurrentDomain.Load("Api.Application");
            services.AddFluentValidationAutoValidation()
                    .AddAppServices()
                    .AddSwaggerServices()
                    .AddCustomProblemDetails()
                    .AddAutoMapper(assembly)
                    .AddMediatR(assembly)
                    .RegisterRetryPolicies(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<EmployeesContext>();
                context.Database.EnsureCreated();

                // Enable this for non in memory providers
                //context.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseProblemDetails();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
