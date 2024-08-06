using System;
using System.IO;
using System.Text.Json;

public static class GoogleCredentialsHelper
{
    public static string GetProjectId()
    {
        string credentialsPath = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");

        if (string.IsNullOrEmpty(credentialsPath))
        {
            throw new InvalidOperationException("GOOGLE_APPLICATION_CREDENTIALS environment variable is not set.");
        }

        try
        {
            string jsonContent = File.ReadAllText(credentialsPath);
            using JsonDocument doc = JsonDocument.Parse(jsonContent);
            return doc.RootElement.GetProperty("project_id").GetString()
                ?? throw new InvalidOperationException("project_id not found in credentials file.");
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error reading Google credentials file.", ex);
        }
    }
}
