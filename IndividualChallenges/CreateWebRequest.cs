using System;
using System.Net;

public void CreateSecureWebRequest(string url)
{
    if (string.IsNullOrWhiteSpace(url))
    {
        Console.WriteLine("Invalid URL.");
        return;
    }

    try
    {
        // Ensure the URL starts with HTTPS
        if (!url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            url = "https://" + url;
        }

        // Create a secure web request
        var request = WebRequest.Create(url);
        request.Method = "GET"; // Specify the HTTP method (GET, POST, etc.)
        
        // Use a timeout for better reliability
        request.Timeout = 10000; // Timeout in milliseconds

        // Get and handle the response
        using (var response = request.GetResponse())
        {
            Console.WriteLine("Response received from: " + url);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Failed to create or process the web request: {ex.Message}");
    }
}