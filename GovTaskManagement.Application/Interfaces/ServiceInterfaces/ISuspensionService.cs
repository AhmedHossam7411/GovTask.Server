namespace GovTaskManagement.Application.Interfaces.ServiceInterfaces
{
    public interface ISuspensionService
    {
        void SuspendUser(string userId, int minutes = 30);
        void RevokeUser(string userId);
        bool IsSuspended(string userId, out TimeSpan remaining);
        bool IsRevoked(string userId);
    }
}
