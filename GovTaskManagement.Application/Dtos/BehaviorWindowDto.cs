namespace GovTaskManagement.Application.Dtos
{
    public class BehaviorWindowDto
    {
        public string Context { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string SessionId { get; set; } = string.Empty;
        public string CurrentPage { get; set; } = string.Empty;
        // Mouse
        public double AvgMouseSpeed { get; set; }
        public double StdMouseSpeed { get; set; }
        public int MouseMoveCount { get; set; }
        public double? MouseMoveRate { get; set; }

        public double AvgMouseIdle { get; set; }
        public double StdMouseIdle { get; set; }

        // Clicks
        public double? StdPreClickSpeed { get; set; }
        public double? AvgPreClickSpeed { get; set; }
        public double? ClickRate { get; set; }
        public double AvgClickDuration { get; set; }
        public double StdClickDuration { get; set; }
        public int ClickCount { get; set; }

        public double AvgClickInterval { get; set; }
        public double StdClickInterval { get; set; }

        // Keystrokes
        public double AvgDwell { get; set; }
        public double StdDwell { get; set; }
        public double AvgFlight { get; set; }
        public double StdFlight { get; set; }
        public int KeyEventCount { get; set; }

        public double TypingRate { get; set; }
        
        // Forensic Fingerprinting
        public string? UserAgent { get; set; }
        public string? Language { get; set; }
        public string? ScreenResolution { get; set; }
        public string? TimeZone { get; set; }
        public string? Platform { get; set; }
        public int? HardwareConcurrency { get; set; }

        // Scroll Dynamics
        public double? AvgScrollSpeed { get; set; }
        public int? ScrollEventCount { get; set; }
        
        public string? Location { get; set; }

        // Attack string detection — populated by the Angular tracker
        public bool HackingStringDetected { get; set; } = false;
        public string? DetectedPatterns { get; set; }
    }
}
