using System;

namespace Api.Common.Models.Policies
{
    public class CircuitBreakerPolicySettings
    {
        public TimeSpan DurationOfBreak { get; set; } = TimeSpan.FromSeconds(10);
        
        public int HandledEventsAllowedBeforeBreaking { get; set; } = 10;
    }
}
