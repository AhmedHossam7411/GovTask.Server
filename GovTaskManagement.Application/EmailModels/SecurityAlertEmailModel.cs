namespace GovTaskManagement.Application.EmailModels
{
    public class SecurityAlertEmailModel
    {
        public string Type { get; set; } = string.Empty;
        public string Severity { get; set; } = string.Empty;
        public string UserId { get; set; } = "Unauthenticated";
        public string UserEmail { get; set; } = "Unknown";
        public string DetectedPattern { get; set; } = "Unknown";
        public string Url { get; set; } = string.Empty;
        public string Timestamp { get; set; } = string.Empty;
        public string Context { get; set; } = string.Empty;
        public string SessionId { get; set; } = string.Empty;
        public string Platform { get; set; } = "Unknown";
        public string UserAgent { get; set; } = "Unknown";
        public string Location { get; set; } = "Unknown";
    }
}
