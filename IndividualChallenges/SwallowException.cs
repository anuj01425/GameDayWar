public void SwallowException()
{
    try
    {
        DoSomething(); // This method might throw an exception
    }
    catch (Exception ex)
    {
        // Silently swallow the exception
         Console.WriteLine($"Exception caught: {ex.Message}");
    }
}

private void DoSomething()
{
    throw new InvalidOperationException("An error occurred in DoSomething.");
}
