using RateLimiter;

namespace potg.RiotGames.Services;

public class RateLimitService
{
    public Dictionary<string, TimeLimiter> RateLimiters { get; } = new();

    public RateLimitService()
    {
        var region = new[] { "kr", "asia" };
        
        foreach (var s in region)
        {
            var limit = new CountByIntervalAwaitableConstraint(20, TimeSpan.FromSeconds(1));
            var limit2 = new CountByIntervalAwaitableConstraint(100, TimeSpan.FromMinutes(2));
            RateLimiters.Add(s, TimeLimiter.Compose(limit, limit2));
        }
    }
}