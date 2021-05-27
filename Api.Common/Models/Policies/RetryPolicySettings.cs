namespace Api.Common.Models.Policies
{
    public class RetryPolicySettings
    {
        public int RetryCount { get; set; } = 3;
        public int SleepDurationPower { get; set; } = 2;
    }
}
