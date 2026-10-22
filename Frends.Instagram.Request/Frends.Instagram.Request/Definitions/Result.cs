namespace Frends.Instagram.Request.Definitions;

/// <summary>
/// Result class usually contains properties of the return object.
/// </summary>
public class Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class.
    /// </summary>
    /// <param name="success">Indicates whether the request completed successfully.</param>
    /// <param name="statuscode">HTTP status code of the response.</param>
    /// <param name="message">Returns the message from the interface.</param>
    /// <param name="error">Error details. Null when success is true.</param>
    internal Result(bool success, int statuscode, object message, Error error = null)
    {
        this.Success = success;
        this.Error = error;
        this.Statuscode = statuscode;
        this.Message = message;
    }

    /// <summary>
    /// Gets a value indicating whether the request completed successfully.
    /// </summary>
    /// <example>true</example>
    public bool Success { get; private set; }

    /// <summary>
    /// Gets the HTTP status code of the response.
    /// </summary>
    /// <example>200</example>
    public int Statuscode { get; private set; }

    /// <summary>
    /// Gets message from the interface.
    /// </summary>
    /// <example>{ "id": 123456789, "name": "UserName" }</example>
    public dynamic Message { get; private set; }

    /// <summary>
    /// Gets error details. Null when Success is true.
    /// </summary>
    /// <example>null</example>
    public Error Error { get; private set; }
}
