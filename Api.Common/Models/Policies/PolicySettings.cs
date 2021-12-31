namespace Api.Common.Models.Policies
{
    public class PolicySettings
    {
        public const string PoliciesConfigurationSectionName = "Policies";

        public CircuitBreakerPolicySettings HttpCircuitBreaker { get; set; }
        public RetryPolicySettings HttpRetry { get; set; }
    }
}
