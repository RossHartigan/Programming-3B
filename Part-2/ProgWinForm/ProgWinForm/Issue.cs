namespace ProgWinForm
{
    public class Issue
    {
        public string? Location { get; set; } // Nullable property
        public string? Category { get; set; }
        public string? Description { get; set; }
        public string? MediaPath { get; set; }
    }

    public class Feedback
    {
        public string? FeedbackGiven { get; set; } // Nullable property
        public string? ChosenIssue { get; set; }
    }
}
