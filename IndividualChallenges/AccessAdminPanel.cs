
public void AccessAdminPanel(string username, string password)
{
    bool isAuthenticated = AuthenticateUser(username, password);

    if (isAuthenticated && IsAdmin(username))
    {
        Console.WriteLine("Access to Admin Panel Granted!");
    }
    else
    {
        Console.WriteLine("Access Denied.");
    }
}

private void AuthenticateUser(string username, string password)
{
    AuthenticateUser authenticateUser = new AuthenticateUser();
    authenticateUser.AuthenticateUser(password);
}

private bool IsAdmin(string username)
{
    return username == "admin";
}
