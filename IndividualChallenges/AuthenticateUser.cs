using System;
using System.Security.Cryptography;
using System.Text;

public class AuthenticationHandler
{
    // Simulated hashed password for demonstration purposes (store securely in a database in real scenarios)
    private const string StoredHashedPassword = "202CB962AC59075B964B07152D234B70"; // MD5 hash of "123"

    public void AuthenticateUser(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Invalid password.");
            return;
        }

        // Hash the input password
        string hashedInput = ComputeMD5Hash(password);

        // Compare the hashed password with the stored hash
        if (string.Equals(hashedInput, StoredHashedPassword, StringComparison.OrdinalIgnoreCase))
        {
            GrantAccess();
        }
        else
        {
            Console.WriteLine("Access Denied.");
        }
    }

    private void GrantAccess()
    {
        Console.WriteLine("Access Granted!");
    }

    private string ComputeMD5Hash(string input)
    {
        using (var md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            foreach (var b in hashBytes)
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}