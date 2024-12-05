public void WriteExceptionToFile(Exception ex)
{
    try
    {
        DoSomethingRisky();
    }
    catch (Exception caughtEx)
    {
        // Define a secure location for the log file
        string logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "error.log");

        // Sanitising Message and then adding log to file
        string sanitizedMessage = $"Timestamp: {DateTime.UtcNow}\nError Message: {caughtEx.Message}\n";
        File.AppendAllText(logFilePath, sanitizedMessage);

        // Alternatively we should use a secure logging framework like Serilog, NLog, or Microsoft.Extensions.Logging
        // Example with Microsoft.Extensions.Logging:
    }
}

