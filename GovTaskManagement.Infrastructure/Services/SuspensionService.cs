using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using Microsoft.Extensions.Caching.Memory;

namespace GovTaskManagement.Infrastructure.Services
{
    public class SuspensionService : ISuspensionService
    {
        private readonly IMemoryCache _cache;

        public SuspensionService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void SuspendUser(string userId, int minutes = 30)
        {
            var expiry = DateTime.UtcNow.AddMinutes(minutes);
            _cache.Set($"suspended:{userId}", expiry, TimeSpan.FromMinutes(minutes));
        }

        public void RevokeUser(string userId)
        {
            // No expiry — admin revocation is permanent until service restart
            _cache.Set($"revoked:{userId}", true);
        }

        public bool IsSuspended(string userId, out TimeSpan remaining)
        {
            if (_cache.TryGetValue($"suspended:{userId}", out DateTime expiry))
            {
                remaining = expiry - DateTime.UtcNow;
                if (remaining > TimeSpan.Zero) return true;
            }
            remaining = TimeSpan.Zero;
            return false;
        }

        public bool IsRevoked(string userId)
        {
            return _cache.TryGetValue($"revoked:{userId}", out _);
        }
    }
}
