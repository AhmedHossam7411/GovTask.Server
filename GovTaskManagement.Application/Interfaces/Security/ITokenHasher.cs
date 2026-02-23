namespace GovTaskManagement.Application.Interfaces.Security
{
    public interface ITokenHasher
    {
        string Hash(string token);
    }
}
