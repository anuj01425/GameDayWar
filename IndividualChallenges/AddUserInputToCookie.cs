using System;
using System.Web;

public class CookieHandler
{
    public void AddUserInputToCookie(string userInput)
    {
        // Validate and sanitize user input
        if (string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine("Invalid user input.");
            return;
        }

        // Example sanitization: Remove potentially dangerous characters
        string sanitizedInput = HttpUtility.HtmlEncode(userInput);

        // Create a secure cookie
        var cookie = new HttpCookie("SessionID", sanitizedInput)
        {
            HttpOnly = true, // Prevent JavaScript access to the cookie
            Secure = true,   // Ensure the cookie is sent only over HTTPS
            SameSite = SameSiteMode.Strict // Mitigate CSRF attacks
        };

        // Add cookie to the response
        Response.Cookies.Add(cookie);

        Console.WriteLine("Secure cookie added with sanitized input.");
    }
}