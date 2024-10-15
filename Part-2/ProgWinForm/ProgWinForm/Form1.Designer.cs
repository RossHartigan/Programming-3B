using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProgWinForm
{
    public partial class Form1 : Form
    {
        private Button btnReportIssues;
        private Button btnLocalEvents;
        private Button btnServiceStatus;
        private Button btnFeedback;
        private Label lblTitle;

        private List<Issue> issues = new List<Issue>();

        private void InitializeComponent()
        {
            this.btnReportIssues = new Button();
            this.btnLocalEvents = new Button();
            this.btnServiceStatus = new Button();
            this.btnFeedback = new Button();
            this.lblTitle = new Label();
            this.SuspendLayout();

            // lblTitle 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitle.Location = new Point(350, 50);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(420, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Municipality Service Portal";

            // btnReportIssues 
            this.btnReportIssues.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnReportIssues.Location = new Point(350, 150);
            this.btnReportIssues.Name = "btnReportIssues";
            this.btnReportIssues.Size = new Size(300, 50);
            this.btnReportIssues.TabIndex = 1;
            this.btnReportIssues.Text = "Report Issues";
            this.btnReportIssues.UseVisualStyleBackColor = true;
            this.btnReportIssues.Click += new EventHandler(this.btnReportIssues_Click);

            // btnLocalEvents 
            this.btnLocalEvents.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnLocalEvents.Location = new Point(350, 230);
            this.btnLocalEvents.Name = "btnLocalEvents";
            this.btnLocalEvents.Size = new Size(300, 75);
            this.btnLocalEvents.TabIndex = 2;
            this.btnLocalEvents.Text = "Local Events and Announcements";
            this.btnLocalEvents.UseVisualStyleBackColor = true;
            this.btnLocalEvents.Click += new EventHandler(this.btnLocalEvents_Click);

            // btnServiceStatus 
            this.btnServiceStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnServiceStatus.Location = new Point(350, 325);
            this.btnServiceStatus.Name = "btnServiceStatus";
            this.btnServiceStatus.Size = new Size(300, 50);
            this.btnServiceStatus.TabIndex = 3;
            this.btnServiceStatus.Text = "Service Request Status";
            this.btnServiceStatus.UseVisualStyleBackColor = true;
            this.btnServiceStatus.Enabled = false; //hidden for now

            // btnFeedback 
            this.btnFeedback.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.btnFeedback.Location = new Point(350, 390);
            this.btnFeedback.Name = "btnServiceStatus";
            this.btnFeedback.Size = new Size(300, 50);
            this.btnFeedback.TabIndex = 3;
            this.btnFeedback.Text = "Feedback";
            this.btnFeedback.UseVisualStyleBackColor = true;
            this.btnFeedback.Click += new EventHandler(this.btnFeedback_Click);

            // HomeForm 
            this.AutoScaleDimensions = new SizeF(10F, 25F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1000, 600);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnReportIssues);
            this.Controls.Add(this.btnLocalEvents);
            this.Controls.Add(this.btnServiceStatus);
            this.Controls.Add(this.btnFeedback);
            this.Name = "Form1";
            this.Text = "Main Menu";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            ReportIssues reportIssuesForm = new ReportIssues();
            reportIssuesForm.IssueReported += ReportIssuesForm_IssueReported;
            reportIssuesForm.Show();
        }

        private void ReportIssuesForm_IssueReported(object sender, Issue e)
        {
            issues.Add(e);
            MessageBox.Show("Issue reported successfully!");
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            FeedbackForm feedbackForm = new FeedbackForm(issues);
            feedbackForm.Show();
        }

        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            LocalEventsForm localEventsForm = new LocalEventsForm();
            localEventsForm.Show();
        }
    }
}