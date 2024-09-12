using ProgWinForm;
using System.Collections.Generic;
using System.IO;

public static class FileHelper
{
    public static void SaveIssuesToFile(List<Issue> issues, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var issue in issues)
            {
                writer.WriteLine($"{issue.Location}|{issue.Category}|{issue.Description}|{issue.MediaPath}");
            }
        }
    }

    public static List<Issue> LoadIssuesFromFile(string filePath)
    {
        List<Issue> issues = new List<Issue>();

        if (!File.Exists(filePath))
        {
            return issues;
        }

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 4)
                {
                    issues.Add(new Issue
                    {
                        Location = parts[0],
                        Category = parts[1],
                        Description = parts[2],
                        MediaPath = parts[3]
                    });
                }
            }
        }
        return issues;
    }
}
