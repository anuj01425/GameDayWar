public void CreateAuthCookie(string userInput)
{
    if (string.IsNullOrWhiteSpace(userInput))
    {
        Console.WriteLine("Invalid input. Cookie not created.");
        return;
    }

    // Example: Encrypt the user input before storing in the cookie
    string encryptedInput = EncryptData(userInput);

    HttpCookie authCookie = new HttpCookie("auth", encryptedInput)
    {
        HttpOnly = true, // Prevents access from JavaScript
        Secure = true,   // Ensures the cookie is sent only over HTTPS
        SameSite = SameSiteMode.Strict // Protects against CSRF
    };

    HttpContext.Current.Response.Cookies.Add(authCookie);
    Console.WriteLine("Secure cookie has been set.");
}

private string EncryptData(string data)
{
    // Simulated encryption: Replace with robust encryption logic (e.g., AES)
    byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(data);
    return Convert.ToBase64String(dataBytes); // Base64 encoding for demonstration
}