using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProgWinForm
{
    public partial class FeedbackForm : Form
    {

        private ComboBox cmbIssues;
        private RichTextBox rtbFeedback;
        private Button btnSubmitFeedback;
        private Label lblIssue;
        private Label lblFeedback;
        private ListBox lstFeedbacks;
        private List<Issue> issues;
        private List<Feedback> feedbacks = new List<Feedback>();

        //file paths for text files to persist data - these will need to be changed for your run
        private string issuesFilePath = @"C:\Users\rossh\Desktop\Programmin-Part-2\Files\Issues.txt";
        private string feedbackFilePath = @"C:\Users\rossh\Desktop\Programmin-Part-2\Files\Feedback.txt";

        public FeedbackForm(List<Issue> issues)
        {
            InitializeComponent();
            this.issues = issues;
            PopulateIssueComboBox();
            LoadIssuesFromFile();
            LoadFeedbacksFromFile();
        }

        private void InitializeComponent()
        {
            this.cmbIssues = new ComboBox();
            this.rtbFeedback = new RichTextBox();
            this.btnSubmitFeedback = new Button();
            this.lblIssue = new Label();
            this.lblFeedback = new Label();
            this.lstFeedbacks = new ListBox();
            this.SuspendLayout();

            // cmbIssues
            this.cmbIssues.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbIssues.FormattingEnabled = true;
            this.cmbIssues.Location = new Point(20, 50);
            this.cmbIssues.Name = "cmbIssues";
            this.cmbIssues.Size = new Size(300, 33);
            this.cmbIssues.TabIndex = 0;

            // rtbFeedback 
            this.rtbFeedback.Location = new Point(20, 115);
            this.rtbFeedback.Name = "rtbFeedback";
            this.rtbFeedback.Size = new Size(300, 150);
            this.rtbFeedback.TabIndex = 1;
            this.rtbFeedback.Text = "";

            // btnSubmitFeedback
            this.btnSubmitFeedback.Location = new Point(20, 270);
            this.btnSubmitFeedback.Name = "btnSubmitFeedback";
            this.btnSubmitFeedback.Size = new Size(150, 30);
            this.btnSubmitFeedback.TabIndex = 2;
            this.btnSubmitFeedback.Text = "Submit Feedback";
            this.btnSubmitFeedback.UseVisualStyleBackColor = true;
            this.btnSubmitFeedback.Click += new EventHandler(this.btnSubmitFeedback_Click);

            // lblIssue
            this.lblIssue.AutoSize = true;
            this.lblIssue.Location = new Point(20, 20);
            this.lblIssue.Name = "lblIssue";
            this.lblIssue.Size = new Size(78, 25);
            this.lblIssue.TabIndex = 3;
            this.lblIssue.Text = "Select Issue:";

            // lblFeedback 
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.Location = new Point(20, 90);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new Size(79, 25);
            this.lblFeedback.TabIndex = 4;
            this.lblFeedback.Text = "Feedback:";

            // lstFeedbacks 
            this.lstFeedbacks.FormattingEnabled = true;
            this.lstFeedbacks.ItemHeight = 25;
            this.lstFeedbacks.Location = new Point(20, 310);
            this.lstFeedbacks.Name = "lstFeedbacks";
            this.lstFeedbacks.Size = new Size(500, 150);
            this.lstFeedbacks.TabIndex = 5;

            // FeedbackForm
            this.AutoScaleDimensions = new SizeF(10F, 25F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(750, 500);
            this.Controls.Add(this.lstFeedbacks);
            this.Controls.Add(this.lblFeedback);
            this.Controls.Add(this.lblIssue);
            this.Controls.Add(this.btnSubmitFeedback);
            this.Controls.Add(this.rtbFeedback);
            this.Controls.Add(this.cmbIssues);
            this.Name = "FeedbackForm";
            this.Text = "Provide Feedback";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void LoadIssuesFromFile()
        {
            if (File.Exists(issuesFilePath))
            {
                string[] lines = File.ReadAllLines(issuesFilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 4)
                    {
                        Issue issue = new Issue
                        {
                            Location = parts[0],
                            Category = parts[1],
                            Description = parts[2],
                            MediaPath = parts[3]
                        };
                        issues.Add(issue);
                        cmbIssues.Items.Add(issue.Description + " at " + issue.Location);
                    }
                }
            }
        }

        private void LoadFeedbacksFromFile()
        {
            if (File.Exists(feedbackFilePath))
            {
                string[] lines = File.ReadAllLines(feedbackFilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        Feedback feedback = new Feedback
                        {
                            ChosenIssue = parts[0],
                            FeedbackGiven = parts[1]
                        };
                        feedbacks.Add(feedback);
                    }
                }
                UpdateFeedbackList();
            }
        }


        private void PopulateIssueComboBox()
        {
            cmbIssues.Items.Clear();
            foreach (var issue in issues)
            {
                cmbIssues.Items.Add(issue.Description + " at " + issue.Location);
            }
        }

        private void btnSubmitFeedback_Click(object sender, EventArgs e)
        {
            if (cmbIssues.SelectedItem == null)
            {
                MessageBox.Show("Please select an issue.");
                return;
            }

            Feedback feedback = new Feedback
            {
                ChosenIssue = cmbIssues.SelectedItem.ToString(),
                FeedbackGiven = rtbFeedback.Text
            };

            feedbacks.Add(feedback);
            UpdateFeedbackList();
            SaveFeedbackToFile();

            MessageBox.Show("Feedback submitted successfully!");
        }

        private void SaveFeedbackToFile()
        {
            using (StreamWriter writer = new StreamWriter(feedbackFilePath))
            {
                foreach (var feedback in feedbacks)
                {
                    writer.WriteLine($"{feedback.ChosenIssue}|{feedback.FeedbackGiven}");
                }
            }
        }

        private void UpdateFeedbackList()
        {
            lstFeedbacks.Items.Clear();
            foreach (var feedback in feedbacks)
            {
                lstFeedbacks.Items.Add($"Issue: {feedback.ChosenIssue} - Feedback: {feedback.FeedbackGiven}");
            }
        }
    }
}