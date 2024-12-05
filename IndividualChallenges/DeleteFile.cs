public void DeleteFile(string userInput)
{
    try
    {
        string fullPath = @"D:\Somebasepath";
        string fullPath = Path.GetFullPath(Path.Combine(fullPath, userInput));

        if (!fullPath.StartsWith(allowedDirectory, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Error: Unauthorized access attempt.");
            return;
        }

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
            Console.WriteLine($"Deleted file: {fullPath}");
        }
        else
        {
            Console.WriteLine("Error: File not found.");
        }
    }
    catch (Exception ex)
    {
        // Handle exceptions gracefully
        Console.WriteLine($"Error: Could not delete the file. Details: {ex.Message}");
    }
}
