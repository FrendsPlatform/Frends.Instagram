using System;

namespace Frends.Instagram.Request.Definitions;

/// <summary>
/// Error details.
/// </summary>
public class Error
{
    /// <summary>
    /// Gets or sets the error message.
    /// </summary>
    /// <example>Invalid OAuth access token.</example>
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets the exception that caused the error.
    /// </summary>
    /// <example>System.Exception: Invalid OAuth access token.</example>
    public Exception AdditionalInfo { get; set; }
}
