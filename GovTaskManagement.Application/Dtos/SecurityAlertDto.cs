using System;

namespace GovTaskManagement.Application.Dtos
{
    public class SecurityAlertDto
    {
        public string Type { get; set; } = "BEHAVIORAL_ANOMALY";
        public string Severity { get; set; } = "CRITICAL";
        public string Url { get; set; } = string.Empty;
        public string Timestamp { get; set; } = DateTime.UtcNow.ToString("O");
        public string? UserId { get; set; }
        public string? UserEmail { get; set; }
        public string? DetectedPattern { get; set; }
        public BehaviorWindowDto Snapshot { get; set; } = new();
    }
}
