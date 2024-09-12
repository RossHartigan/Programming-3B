using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgWinForm
{
    public class Issue
    {
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string MediaPath { get; set; }
    }

    public class Feedback
    {
        public string FeedbackGiven { get; set; }
        public string ChosenIssue { get; set; }
    }
}
