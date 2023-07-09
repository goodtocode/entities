namespace Goodtocode.Common.Persistence.Cache;

/// <summary>
///   "CacheConfiguration": {
///     "AbsoluteExpirationInHours": 1,
///     "SlidingExpirationInMinutes": 30 
///    }
/// </summary>
public class CacheConfiguration
{
    public int AbsoluteExpirationInHours { get; set; }
    public int SlidingExpirationInMinutes { get; set; }
}
