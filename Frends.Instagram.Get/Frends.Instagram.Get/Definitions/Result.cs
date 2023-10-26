﻿#pragma warning disable SA1629 // Documentation text should end with a period
namespace Frends.Instagram.Get.Definitions;

/// <summary>
/// Result class usually contains properties of the return object.
/// </summary>
public class Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class.
    /// </summary>
    /// <param name="success">Indicates whether GET call was executed succesfully.</param>
    /// <param name="message">Returns the message from the interface.</param>
    internal Result(bool success, object message)
    {
        this.Success = success;
        this.Message = message;
    }

    /// <summary>
    /// Gets a value indicating whether GET call was executed successfully.
    /// </summary>
    /// <example>true</example>
    public bool Success { get; private set; }

    /// <summary>
    /// Gets message from the interface.
    /// </summary>
    /// <example>Example of the output.</example>
    public dynamic Message { get; private set; }
}