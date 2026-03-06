namespace GovTaskManagement.Domain.Entities
{
    public class BehaviorWindow
    {
            public int Id { get; set; }
            public string SessionId { get; set; } = string.Empty;
            public string CurrentPage { get; set; } = string.Empty;
            public string UserId { get; set; } = string.Empty;
            public DateTime Timestamp { get; set; }

            public double AvgMouseSpeed { get; set; }
            public double StdMouseSpeed { get; set; }
            public int MouseMoveCount { get; set; }

            public double AvgMouseIdle { get; set; }
            public double StdMouseIdle { get; set; }

            public double AvgClickDuration { get; set; }
            public double StdClickDuration { get; set; }
            public int ClickCount { get; set; }

            public double AvgClickInterval { get; set; }
            public double StdClickInterval { get; set; }

            public double AvgDwell { get; set; }
            public double StdDwell { get; set; }
            public double AvgFlight { get; set; }
            public double StdFlight { get; set; }
            public int KeyEventCount { get; set; }

            public double TypingRate { get; set; }
            public string Context { get; set; } = string.Empty;
    }
}

