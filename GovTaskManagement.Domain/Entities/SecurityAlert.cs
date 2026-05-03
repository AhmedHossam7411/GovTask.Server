using System;

namespace GovTaskManagement.Domain.Entities
{
    public class SecurityAlert
    {
        public int Id { get; set; }
        public string Type { get; set; } = "BEHAVIORAL_ANOMALY";
        public string Severity { get; set; } = "MEDIUM"; // LOW, MEDIUM, HIGH, CRITICAL
        public string Url { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string? UserId { get; set; }
        public bool IsResolved { get; set; } = false;
        
        // Relationship to the behavior snapshot that triggered the alert
        public int? BehaviorWindowId { get; set; }
        public BehaviorWindow? Snapshot { get; set; }
    }
}
