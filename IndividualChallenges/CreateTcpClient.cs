using System;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

public void CreateSecureTcpClient(string host)
{
    if (string.IsNullOrWhiteSpace(host))
    {
        Console.WriteLine("Invalid host.");
        return;
    }

    try
    {
        // Connect to the server using a secure SSL/TLS connection
        using (var tcpClient = new TcpClient(host, 443)) // Default port for HTTPS
        using (var sslStream = new SslStream(tcpClient.GetStream(), false, ValidateServerCertificate))
        {
            // Initiate the SSL handshake
            sslStream.AuthenticateAsClient(host);

            Console.WriteLine("Secure TCP client connected to: " + host);
            // Further communication logic can go here
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Failed to connect to the server: {ex.Message}");
    }
}

private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
{
    if (sslPolicyErrors == SslPolicyErrors.None)
        return true;

    Console.WriteLine("Certificate error: " + sslPolicyErrors);
    return false; // Reject invalid certificates
}