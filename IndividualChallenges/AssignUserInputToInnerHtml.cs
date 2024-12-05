public void AssignUserInputToInnerHtml(string userInput)
{
    // Validate and sanitize user input
    if (string.IsNullOrWhiteSpace(userInput))
    {
        Console.WriteLine("Invalid user input.");
        return;
    }

    // Example sanitization: Encode input to prevent XSS
    string sanitizedInput = System.Web.HttpUtility.HtmlEncode(userInput);

    // Assign sanitized input to InnerHtml
    var res = new System.Web.UI.HtmlControls.HtmlGenericControl();
    res.InnerHtml = sanitizedInput;

    Console.WriteLine("Set sanitized InnerHtml to: " + sanitizedInput);
}