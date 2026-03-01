namespace GovTaskManagement.Domain.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; set; }

        public string Token { get; set; } = null!;

        public DateTime ExpiresAt { get; set; }

        public bool IsRevoked { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string UserId { get; set; } = null!;
        public ApiUser User { get; set; }
    }
}
