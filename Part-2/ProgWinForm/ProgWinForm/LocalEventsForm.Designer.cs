namespace ProgWinForm
{
    partial class LocalEventsForm : Form
    {
        private Label lblTitle;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label lblRecommendation;
        private ComboBox cmbCategories;
        private FlowLayoutPanel flpAvailableEvents;
        private FlowLayoutPanel flpRecommendedEvents;

        // Data structure to store events with date and category
        private SortedDictionary<DateTime, List<Event>> eventsDictionary;
        private List<Event> searchHistory = new List<Event>();

        private void InitializeComponent()
        {
            lblTitle = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            lblRecommendation = new Label();
            cmbCategories = new ComboBox();
            flpAvailableEvents = new FlowLayoutPanel();
            flpRecommendedEvents = new FlowLayoutPanel();
            Label lblSearchByName = new Label();
            Label lblCategoryFilter = new Label();

            SuspendLayout();

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.DarkSlateBlue;
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(650, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Local Events and Announcements";

            // flpAvailableEvents
            flpAvailableEvents.AutoScroll = true;
            flpAvailableEvents.Location = new Point(30, 100);
            flpAvailableEvents.Name = "flpAvailableEvents";
            flpAvailableEvents.Size = new Size(800, 400);
            flpAvailableEvents.WrapContents = false;
            flpAvailableEvents.FlowDirection = FlowDirection.TopDown;

            // lblSearchByName
            lblSearchByName.AutoSize = true;
            lblSearchByName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSearchByName.Location = new Point(30, 510);
            lblSearchByName.Name = "lblSearchByName";
            lblSearchByName.Size = new Size(180, 25);
            lblSearchByName.Text = "Search by Name or Date:";

            // txtSearch
            txtSearch.Location = new Point(30, 550);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Enter event name or date";
            txtSearch.Size = new Size(400, 35);
            txtSearch.TabIndex = 2;

            // lblCategoryFilter
            lblCategoryFilter.AutoSize = true;
            lblCategoryFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCategoryFilter.Location = new Point(475, 510);
            lblCategoryFilter.Name = "lblCategoryFilter";
            lblCategoryFilter.Size = new Size(150, 25);
            lblCategoryFilter.Text = "Filter by Category:";

            // cmbCategories
            cmbCategories.Location = new Point(475, 550);
            cmbCategories.Name = "cmbCategories";
            cmbCategories.Size = new Size(250, 35);
            cmbCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategories.TabIndex = 6;
            cmbCategories.Items.AddRange(new string[] { "All", "Music", "Art", "Food", "Sports", "Education", "Culture", "Community", "Technology", "Government" });

            // btnSearch
            btnSearch.Location = new Point(740, 550);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 40);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.BackColor = Color.MediumSeaGreen;
            btnSearch.ForeColor = Color.White;
            btnSearch.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSearch.Click += btnSearch_Click;

            // lblRecommendation
            lblRecommendation.AutoSize = true;
            lblRecommendation.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblRecommendation.Location = new Point(30, 590);
            lblRecommendation.Name = "lblRecommendation";
            lblRecommendation.Size = new Size(350, 40);
            lblRecommendation.TabIndex = 4;
            lblRecommendation.Text = "Recommended Events for You";

            // flpRecommendedEvents
            flpRecommendedEvents.AutoScroll = true;
            flpRecommendedEvents.Location = new Point(30, 650);
            flpRecommendedEvents.Name = "flpRecommendedEvents";
            flpRecommendedEvents.Size = new Size(800, 300);
            flpRecommendedEvents.WrapContents = false;
            flpRecommendedEvents.FlowDirection = FlowDirection.TopDown;

            // LocalEventsForm 
            ClientSize = new Size(1000, 1000); 
            Controls.Add(lblTitle);
            Controls.Add(lblSearchByName); 
            Controls.Add(txtSearch);
            Controls.Add(lblCategoryFilter); 
            Controls.Add(cmbCategories);
            Controls.Add(btnSearch);
            Controls.Add(flpAvailableEvents);
            Controls.Add(lblRecommendation);
            Controls.Add(flpRecommendedEvents);
            Name = "LocalEventsForm";
            Text = "Local Events and Announcements";
            ResumeLayout(false);
            PerformLayout();
        }


        // Method to dynamically add event cards to the FlowLayoutPanel
        private void DisplayEventCards(List<Event> events, FlowLayoutPanel panel)
        {
            panel.Controls.Clear();  // Clear previous event cards

            foreach (var evt in events)
            {
                // Create a panel to represent the event card
                Panel card = new Panel();
                card.BorderStyle = BorderStyle.FixedSingle;
                card.BackColor = Color.LightGray;
                card.Size = new Size(750, 100);
                card.Padding = new Padding(10);

                // Event name label
                Label lblEventName = new Label();
                lblEventName.Text = evt.Name;
                lblEventName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                lblEventName.AutoSize = true;

                // Event category label
                Label lblCategory = new Label();
                lblCategory.Text = "Category: " + evt.Category;
                lblCategory.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
                lblCategory.AutoSize = true;

                // Event date label
                Label lblDate = new Label();
                lblDate.Text = "Date: " + evt.Date.ToShortDateString();
                lblDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
                lblDate.AutoSize = true;

                // Add labels to the card
                card.Controls.Add(lblEventName);
                card.Controls.Add(lblCategory);
                card.Controls.Add(lblDate);

                // Arrange labels vertically in the card
                lblEventName.Location = new Point(10, 10);
                lblCategory.Location = new Point(10, 40);
                lblDate.Location = new Point(10, 70);

                // Add the card to the panel
                panel.Controls.Add(card);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.ToLower();
            string selectedCategory = cmbCategories.SelectedItem?.ToString().ToLower();  // Get selected category

            // If "All" is selected or nothing is selected, search across all categories
            bool searchAllCategories = selectedCategory == "all" || string.IsNullOrEmpty(selectedCategory);

            // Find events where the search query matches the event's name, category, or date
            var results = from date in eventsDictionary.Keys
                          from evt in eventsDictionary[date]
                          where (evt.Name.ToLower().Contains(searchQuery) ||
                                 evt.Category.ToLower().Contains(searchQuery) ||
                                 evt.Date.ToShortDateString().Contains(searchQuery)) &&
                                 (searchAllCategories || evt.Category.ToLower() == selectedCategory)
                          select evt;

            // Add new relevant events to search history, avoid duplicates
            foreach (var evt in results)
            {
                if (!searchHistory.Contains(evt))  // Check if the event is already in the search history
                {
                    searchHistory.Add(evt);  // Add new event to search history
                }
            }

            // Display search results as event cards
            DisplayEventCards(results.ToList(), flpAvailableEvents);

            // Update recommendations based on search history
            GenerateRecommendations();
        }


        private void GenerateRecommendations()
        {
            // Clear previous recommendations
            flpRecommendedEvents.Controls.Clear();

            // Ensure there's some search history to generate recommendations from
            if (searchHistory.Count == 0)
            {
                Panel noRecommendationsCard = new Panel();
                noRecommendationsCard.BorderStyle = BorderStyle.FixedSingle;
                noRecommendationsCard.BackColor = Color.LightGray;
                noRecommendationsCard.Size = new Size(750, 100);
                noRecommendationsCard.Padding = new Padding(10);

                Label lblNoRecommendations = new Label();
                lblNoRecommendations.Text = "No recommendations available.";
                lblNoRecommendations.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                lblNoRecommendations.AutoSize = true;

                noRecommendationsCard.Controls.Add(lblNoRecommendations);
                lblNoRecommendations.Location = new Point(10, 30);

                flpRecommendedEvents.Controls.Add(noRecommendationsCard);
                return;
            }

            // Get keywords from search history (event names)
            var keywords = new HashSet<string>();
            foreach (var evt in searchHistory)
            {
                var eventKeywords = evt.Name.ToLower().Split(' ', '-', '_');
                foreach (var keyword in eventKeywords)
                {
                    keywords.Add(keyword);  // Add unique keywords to the set
                }
            }

            // Build a list of recommended events based on matching keywords
            var recommendedEvents = new List<Event>();

            foreach (var date in eventsDictionary.Keys)
            {
                foreach (var evt in eventsDictionary[date])
                {
                    // Get keywords for the current event
                    var currentEventKeywords = evt.Name.ToLower().Split(' ', '-', '_');

                    // Check if there are shared keywords with the search history
                    bool hasMatchingKeyword = currentEventKeywords.Intersect(keywords).Any();

                    // Recommend events with matching keywords or same category as in search history
                    if (hasMatchingKeyword || searchHistory.Any(sh => sh.Category == evt.Category))
                    {
                        // Add event to recommendations if it matches keywords or category
                        if (!recommendedEvents.Contains(evt) && !searchHistory.Contains(evt))  // Don't recommend events already in search history
                        {
                            recommendedEvents.Add(evt);
                        }
                    }
                }
            }

            // Display recommended events as event cards
            DisplayEventCards(recommendedEvents, flpRecommendedEvents);

            // If no recommendations, show a message
            if (!recommendedEvents.Any())
            {
                Panel noRecommendationsCard = new Panel();
                noRecommendationsCard.BorderStyle = BorderStyle.FixedSingle;
                noRecommendationsCard.BackColor = Color.LightGray;
                noRecommendationsCard.Size = new Size(750, 100);
                noRecommendationsCard.Padding = new Padding(10);

                Label lblNoRecommendations = new Label();
                lblNoRecommendations.Text = "No recommendations available.";
                lblNoRecommendations.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                lblNoRecommendations.AutoSize = true;

                noRecommendationsCard.Controls.Add(lblNoRecommendations);
                lblNoRecommendations.Location = new Point(10, 30);

                flpRecommendedEvents.Controls.Add(noRecommendationsCard);
            }
        }

    }

    // Simple class to store event details
    public class Event
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }

        public Event(string name, string category, DateTime date)
        {
            Name = name;
            Category = category;
            Date = date;
        }
    }
}
