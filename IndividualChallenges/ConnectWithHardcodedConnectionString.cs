using System;

public class AuthenticationHandler
{
    private const string StoredHashedPassword = "CFB4B4D292C99861F9FC08D5E8A34009"; // SHA256 hash of "P@ssword!" (for demonstration)

    public void AuthenticateUser(string userInput)
    {
        if (string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        // Hash user input
        string hashedInput = ComputeSHA256Hash(userInput);

        // Compare hashed input with stored hash
        if (string.Equals(hashedInput, StoredHashedPassword, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Authentication successful.");
        }
        else
        {
            Console.WriteLine("Authentication failed.");
        }
    }

    private string ComputeSHA256Hash(string input)
    {
        using (var sha256 = System.Security.Cryptography.SHA256.Create())
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] hash = sha256.ComputeHash(bytes);

            return Convert.ToHexString(hash); // Convert byte array to hex string
        }
    }
}