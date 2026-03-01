using GovTaskManagement.Application.Interfaces.Security;
using System.Security.Cryptography;
using System.Text;

namespace GovTaskManagement.Infrastructure.Security
{
    public class Sha256TokenHasher : ITokenHasher
    {
        public string Hash(string token)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(token);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
