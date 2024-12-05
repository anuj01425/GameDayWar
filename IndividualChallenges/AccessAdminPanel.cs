using System;

public class AdminAccess
{
    // Simulated method to check user roles from a secure source like a database or identity provider
    private bool IsUserAdmin(string username)
    {
        // In a real application, check user roles from a database or an identity provider
        // Simulated example: return true if username is "admin"
        return GetUserRole(username) == "Admin";
    }

    // Simulated method to get user role (Replace with secure data retrieval logic)
    private string GetUserRole(string username)
    {
        // Example: Replace with a database call or API request
        return username == "admin" ? "Admin" : "User";
    }

    public void AccessAdminPanel(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            Console.WriteLine("Invalid username.");
            return;
        }

        try
        {
            if (IsUserAdmin(username))
            {
                Console.WriteLine("Access to Admin Panel Granted!");
                // Additional admin logic goes here
            }
            else
            {
                Console.WriteLine("Access Denied.");
                LogUnauthorizedAccess(username); // Log unauthorized access
            }
        }
        catch (Exception ex)
        {
            // Log exception details securely (not displayed to the user)
            Console.WriteLine("An error occurred while processing the request.");
            LogError(ex);
        }
    }

    // Simulated logging methods
    private void LogUnauthorizedAccess(string username)
    {
        Console.WriteLine($"Unauthorized access attempt by user: {username}"); // Replace with secure logging
    }

    private void LogError(Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}"); // Replace with secure logging
    }
}