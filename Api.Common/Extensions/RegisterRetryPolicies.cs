using System;
using Api.Common.Models.Policies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

namespace Api.Common.Extensions
{
    public static class RegisterPoliciesExtensions
    {
        public static IServiceCollection RegisterRetryPolicies(this IServiceCollection services, IConfiguration configuration)
        {
            var policySettings = new PolicySettings();
            configuration.Bind(PolicySettings.PoliciesConfigurationSectionName, policySettings);

            var policyRegistry = services.AddPolicyRegistry();

            TimeSpan SleepDurationProvider(int retryAttempt) =>
                TimeSpan.FromSeconds(Math.Pow(policySettings.HttpRetry.SleepDurationPower, retryAttempt));

            policyRegistry.Add(
                PolicyNames.HttpRetry,
                HttpPolicyExtensions
                    .HandleTransientHttpError()
                    .WaitAndRetryAsync(
                        retryCount: policySettings.HttpRetry.RetryCount,
                        sleepDurationProvider: SleepDurationProvider));

            policyRegistry.Add(
                PolicyNames.HttpCircuitBreaker,
                HttpPolicyExtensions
                    .HandleTransientHttpError()
                    .CircuitBreakerAsync(
                        handledEventsAllowedBeforeBreaking: policySettings.HttpCircuitBreaker.HandledEventsAllowedBeforeBreaking,
                        durationOfBreak: policySettings.HttpCircuitBreaker.DurationOfBreak));

            return services;
        }
    }
}
