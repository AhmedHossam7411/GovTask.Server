namespace GovTaskManagement.Application.Interfaces.ServiceInterfaces
{
    public interface ISuspensionService
    {
        void SuspendUser(string userId, int minutes = 30);
        bool IsSuspended(string userId, out TimeSpan remaining);
    }
}
