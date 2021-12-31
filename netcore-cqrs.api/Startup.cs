using Api.Common.Extensions.ServiceCollectionExtensions;
using Api.Common.Models.Common;
using Api.Persistence;
using Api.Repository;
using AutoMapper;
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
using System;
using System.Text.Json;

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

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddDbContext<EmployeesContext>(options =>
            {
                options.UseInMemoryDatabase("Employees");
            });
            
            var assembly = AppDomain.CurrentDomain.Load("Api.Application");

            services
                .AddMvc()
                .AddFluentValidation(v => v.RegisterValidatorsFromAssembly(assembly))
                .AddJsonOptions(opts =>
                {
                    opts.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    opts.JsonSerializerOptions.IgnoreNullValues = true;
                });

            services.AddSwaggerServices();
            services.AddProblemDetails();
            services.AddAutoMapper(assembly);
            services.AddMediatR(assembly);
            services.RegisterRetryPolicies(Configuration);

            services.AddControllers();
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
