public void MakeHttpClientRequest(string host)
{
    var client = new HttpClient
    {
        BaseAddress = new Uri("https://" + host) // Insecure: Uses HTTP instead of HTTPS
    };
    var response = client.GetAsync("/api/data").Result;
    Console.WriteLine("Response status: " + response.StatusCode);
}
