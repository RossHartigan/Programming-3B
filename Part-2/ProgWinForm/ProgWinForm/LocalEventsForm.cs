using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProgWinForm
{
    public partial class LocalEventsForm : Form
    {
        public LocalEventsForm()
        {
            InitializeComponent();
            eventsDictionary = new SortedDictionary<DateTime, List<Event>>();

            // Load sample events and display them
            LoadSampleEvents();
            DisplayEventCards(eventsDictionary.SelectMany(pair => pair.Value).ToList(), flpAvailableEvents);
        }

        // sample events 
        private void LoadSampleEvents()
        {
            // Music Events
            AddEvent(new Event("Jazz Festival", "Music", DateTime.Now.AddDays(5)));
            AddEvent(new Event("Rock Concert", "Music", DateTime.Now.AddDays(10)));
            AddEvent(new Event("Classical Music Recital", "Music", DateTime.Now.AddDays(15)));
            AddEvent(new Event("Hip-Hop Battle", "Music", DateTime.Now.AddDays(20)));

            // Art Events
            AddEvent(new Event("Street Art Exhibition", "Art", DateTime.Now.AddDays(2)));
            AddEvent(new Event("Sculpture Showcase", "Art", DateTime.Now.AddDays(12)));
            AddEvent(new Event("Watercolor Painting Workshop", "Art", DateTime.Now.AddDays(22)));
            AddEvent(new Event("Digital Art Exhibition", "Art", DateTime.Now.AddDays(30)));

            // Food Events
            AddEvent(new Event("Local Farmers Market", "Food", DateTime.Now.AddDays(3)));
            AddEvent(new Event("Gourmet Food Festival", "Food", DateTime.Now.AddDays(7)));
            AddEvent(new Event("Vegan Cooking Class", "Food", DateTime.Now.AddDays(17)));
            AddEvent(new Event("Street Food Carnival", "Food", DateTime.Now.AddDays(23)));

            // Sports Events
            AddEvent(new Event("Charity Run", "Sports", DateTime.Now.AddDays(1)));
            AddEvent(new Event("Local Football Tournament", "Sports", DateTime.Now.AddDays(14)));
            AddEvent(new Event("Cycling Marathon", "Sports", DateTime.Now.AddDays(21)));
            AddEvent(new Event("Swimming Competition", "Sports", DateTime.Now.AddDays(29)));

            // Educational Events
            AddEvent(new Event("Science Fair", "Education", DateTime.Now.AddDays(4)));
            AddEvent(new Event("Public Speaking Workshop", "Education", DateTime.Now.AddDays(9)));
            AddEvent(new Event("Career Expo", "Education", DateTime.Now.AddDays(19)));
            AddEvent(new Event("Coding Bootcamp", "Education", DateTime.Now.AddDays(28)));

            // Cultural Events
            AddEvent(new Event("Traditional Dance Performance", "Culture", DateTime.Now.AddDays(8)));
            AddEvent(new Event("Historical Reenactment", "Culture", DateTime.Now.AddDays(18)));
            AddEvent(new Event("Indigenous Storytelling Festival", "Culture", DateTime.Now.AddDays(25)));
            AddEvent(new Event("Cultural Food Tasting", "Culture", DateTime.Now.AddDays(31)));

            // Community Events
            AddEvent(new Event("Community Cleanup", "Community", DateTime.Now.AddDays(2)));
            AddEvent(new Event("Charity Fundraiser", "Community", DateTime.Now.AddDays(6)));
            AddEvent(new Event("Neighborhood BBQ", "Community", DateTime.Now.AddDays(16)));
            AddEvent(new Event("Volunteer Appreciation Dinner", "Community", DateTime.Now.AddDays(26)));

            // Technology Events
            AddEvent(new Event("Tech Conference", "Technology", DateTime.Now.AddDays(11)));
            AddEvent(new Event("AI Workshop", "Technology", DateTime.Now.AddDays(21)));
            AddEvent(new Event("Startup Pitch Event", "Technology", DateTime.Now.AddDays(27)));
            AddEvent(new Event("Robotics Expo", "Technology", DateTime.Now.AddDays(33)));

            // Local Government Events
            AddEvent(new Event("Town Hall Meeting", "Government", DateTime.Now.AddDays(5)));
            AddEvent(new Event("City Planning Forum", "Government", DateTime.Now.AddDays(13)));
            AddEvent(new Event("Public Safety Seminar", "Government", DateTime.Now.AddDays(24)));
            AddEvent(new Event("Local Elections Debate", "Government", DateTime.Now.AddDays(32)));
        }


        // Helper method to add an event to the dictionary
        private void AddEvent(Event evt)
        {
            if (!eventsDictionary.ContainsKey(evt.Date))
            {
                eventsDictionary[evt.Date] = new List<Event>();
            }
            eventsDictionary[evt.Date].Add(evt);
        }
    }
}
