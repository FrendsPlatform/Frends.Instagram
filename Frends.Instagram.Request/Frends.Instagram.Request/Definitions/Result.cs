namespace Frends.Instagram.Request.Definitions;

/// <summary>
/// Result class usually contains properties of the return object.
/// </summary>
public class Result
{
    /// <summary>
    /// Gets or sets a value indicating whether the request was executed successfully.
    /// </summary>
    /// <example>true</example>
    public bool Success { get; set; }

    /// <summary>
    /// Gets or sets the HTTP status code of the response.
    /// </summary>
    /// <example>200</example>
    public int Statuscode { get; set; }

    /// <summary>
    /// Gets or sets message from the interface.
    /// </summary>
    /// <example>{ "id": 123456789, "name": "UserName" }</example>
    public dynamic Message { get; set; }

    /// <summary>
    /// Gets or sets the error that occurred during task execution.
    /// </summary>
    /// <example>object { string Message, Exception AdditionalInfo }</example>
    public Error Error { get; set; }
}
