#pragma warning disable SA1629 // Documentation text should end with a period
namespace Frends.Instagram.Get.Definitions;

/// <summary>
/// Result class usually contains properties of the return object.
/// </summary>
public class Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class.
    /// </summary>
    /// <param name="success">Indicates whether GET request was executed succesfully.</param>
    /// <param name="data">GET request data.</param>
    /// <param name="errorMessage">Error message.</param>
    internal Result(bool success, object data, string errorMessage)
    {
        this.Success = success;
        this.Data = data;
        this.ErrorMessage = errorMessage;
    }

    /// <summary>
    /// Gets a value indicating whether GET call was executed successfully.
    /// </summary>
    /// <example>true</example>
    public bool Success { get; private set; }

    /// <summary>
    /// Gets GET request data.
    /// </summary>
    /// <example>Example of the output.</example>
    public dynamic Data { get; private set; }

    /// <summary>
    /// Gets error message.
    /// </summary>
    /// <example>An error occured...</example>
    public string ErrorMessage { get; private set; }
}