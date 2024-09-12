Compilation
Open the Solution:

Launch Visual Studio.
Open the solution file (ProgWinForm.sln) for the project.
Restore NuGet Packages if needed - I used Newtonsoft.JSON:

Files:
I wanted the data to persist between runs and not just be once off so I made the decision to create two text files called : 
Issues.txt: Stores all reported issues.
Feedback.txt: Stores all feedback provided by users.

You will need to create these text files somewhere on your machine and name them correctly:

Inside of the source code you will then need to change the path of where these files are store in 2 forms:

In the ReportIssues form rename the variable issuesFilePath to the path of your Issues.txt - for example mine is - private string issuesFilePath = @"C:\Users\rossh\OneDrive - ADvTECH Ltd\Varsity\Year 4\Programming\Sem 2\POE\App\Text File\Issues.txt"

I made the decision to instead persist data but I did do it firt by having an internal class called Issues.cs that had get and set methods to get and set the data but I decided it would be better to have the data persist between runs so I went the method of saving the data to a text file.

In the FeedbackForm you will need to replace both the issuesFilePath and feedbackFilePath with your respective file paths: as an example these are my variables
private string issuesFilePath = @"C:\Users\rossh\OneDrive - ADvTECH Ltd\Varsity\Year 4\Programming\Sem 2\POE\App\Text File\Issues.txt";
private string feedbackFilePath = @"C:\Users\rossh\OneDrive - ADvTECH Ltd\Varsity\Year 4\Programming\Sem 2\POE\App\Text File\Feedback.txt";

Select Build > Build Solution from the top menu.
Ensure there are no build errors.
Running the Application
Start the Application:

Press F5 or go to Debug > Start Debugging in Visual Studio.
The application will launch, and you will see the main form.

Report Issues:

Use the Report Issues form to submit issues.
Enter details like location, category, description, and attach media if needed.
Click Submit to save the issue to Issues.txt.

Provide Feedback:

Open the Feedback Form from the main menu.
Select an issue from the issues drop-down.
Enter feedback in the text box.
Click Submit Feedback to save feedback to Feedback.txt.

View Feedback:

Feedback submitted will be displayed in the List box at the bottom of the form.


