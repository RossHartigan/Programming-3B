using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProgWinForm
{
    public partial class ReportIssues : Form
    {
        public event EventHandler<Issue> IssueReported;

        private TextBox txtLocation;
        private ComboBox cmbCategory;
        private RichTextBox rtbDescription;
        private Button btnAttachMedia;
        private Button btnSubmit;
        private Label lblEngagement;
        private Button btnBack;
        private Label lblLocation;
        private Label lblCategory;
        private List<Issue> issues;

        //file paths - these allow the program to quite easily persist data.
        private string issuesFilePath = @"C:\Users\rossh\OneDrive - ADvTECH Ltd\Varsity\Year 4\Programming\Sem 2\POE\App\Text File\Issues.txt"; // file path of where the text file is stored on my computer - this will need to be changed on your machine

        private void InitializeComponent()
        {
            this.txtLocation = new TextBox();
            this.cmbCategory = new ComboBox();
            this.rtbDescription = new RichTextBox();
            this.btnAttachMedia = new Button();
            this.btnSubmit = new Button();
            this.lblEngagement = new Label();
            this.btnBack = new Button();
            this.lblLocation = new Label();
            this.lblCategory = new Label();
            this.SuspendLayout();

            // txtLocation 
            this.txtLocation.Location = new Point(20, 80);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new Size(300, 31);
            this.txtLocation.TabIndex = 0;

            // cmbCategory
            this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] { "Sanitation", "Roads", "Utilities" });
            this.cmbCategory.Location = new Point(20, 150);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new Size(300, 33);
            this.cmbCategory.TabIndex = 1;

            // rtbDescription 
            this.rtbDescription.Location = new Point(20, 220);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new Size(300, 100);
            this.rtbDescription.TabIndex = 2;
            this.rtbDescription.Text = "";
            this.rtbDescription.Enter += new EventHandler(this.rtbDescription_Enter);
            this.rtbDescription.Leave += new EventHandler(this.rtbDescription_Leave);

            // btnAttachMedia 
            this.btnAttachMedia.Location = new Point(20, 340);
            this.btnAttachMedia.Name = "btnAttachMedia";
            this.btnAttachMedia.Size = new Size(150, 30);
            this.btnAttachMedia.TabIndex = 3;
            this.btnAttachMedia.Text = "Attach Media";
            this.btnAttachMedia.UseVisualStyleBackColor = true;
            this.btnAttachMedia.Click += new EventHandler(this.btnAttachMedia_Click);

            // btnSubmit 
            this.btnSubmit.Location = new Point(200, 340);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new Size(120, 30);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new EventHandler(this.btnSubmit_Click);

            // lblEngagement 
            this.lblEngagement.AutoSize = true;
            this.lblEngagement.Location = new Point(20, 380);
            this.lblEngagement.Name = "lblEngagement";
            this.lblEngagement.Size = new Size(245, 25);
            this.lblEngagement.TabIndex = 5;
            this.lblEngagement.Text = "Thank you for your feedback!";
            this.lblEngagement.Visible = false; // Initially hidden

            // btnBack 
            this.btnBack.Location = new Point(350, 340);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new Size(130, 30);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Main Menu";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new EventHandler(this.btnBack_Click);

            // lblLocation
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new Point(20, 50);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new Size(70, 25);
            this.lblLocation.TabIndex = 7;
            this.lblLocation.Text = "Location";

            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new Point(20, 120);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new Size(75, 25);
            this.lblCategory.TabIndex = 8;
            this.lblCategory.Text = "Category";

            // ReportIssues 
            this.AutoScaleDimensions = new SizeF(10F, 25F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(514, 423);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblEngagement);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnAttachMedia);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblLocation);
            this.Name = "ReportIssues";
            this.Text = "Report Issues";
            this.Load += new EventHandler(this.ReportIssues_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void ReportIssues_Load(object sender, EventArgs e)
        {
            // Load existing issues from file
            LoadIssues();
            SetPlaceholderText();
        }

        private void SetPlaceholderText()
        {
            rtbDescription.Text = "Enter detailed description";
            rtbDescription.ForeColor = Color.Gray;
        }

        private void rtbDescription_Enter(object sender, EventArgs e)
        {
            if (rtbDescription.Text == "Enter detailed description")
            {
                rtbDescription.Text = "";
                rtbDescription.ForeColor = Color.Black;
            }
        }

        private void rtbDescription_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                SetPlaceholderText();
            }
        }

        private void btnAttachMedia_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Store the media path 
                string mediaPath = openFileDialog.FileName;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Gather data from the form
            Issue newIssue = new Issue
            {
                Location = txtLocation.Text,
                Category = cmbCategory.SelectedItem?.ToString(),
                Description = rtbDescription.Text,
                MediaPath = "",
            };

            // Add the new issue to the list and save to the text file
            issues.Add(newIssue);
            FileHelper.SaveIssuesToFile(issues, issuesFilePath);

            // Trigger the IssueReported event
            IssueReported?.Invoke(this, newIssue);

            // Show engagement message and hide form
            lblEngagement.Visible = true;
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadIssues()// load issues from the text file
        {
            issues = FileHelper.LoadIssuesFromFile(issuesFilePath);

        }

        private void DisplayIssues(List<Issue> issues)
        {
            //can add functionality here if i would like to display the issues from the text file
        }
    }
}
