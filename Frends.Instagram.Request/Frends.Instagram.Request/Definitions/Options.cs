namespace Frends.Instagram.Request.Definitions;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Options class usually contains parameters that are optional.
/// </summary>
public class Options
{
    /// <summary>
    /// Gets or sets a value indicating whether error should throw an exception (true) or stop the Task and return result object containing Result.Success = false and Result.Error = 'exception message' (false).
    /// </summary>
    /// <example>true</example>
    [DefaultValue(true)]
    public bool ThrowErrorOnFailure { get; set; } = true;

    /// <summary>
    /// Gets or sets the message that overrides the error message on failure.
    /// </summary>
    /// <example>Instagram request failed</example>
    [DisplayFormat(DataFormatString = "Text")]
    [DefaultValue("")]
    public string ErrorMessageOnFailure { get; set; } = string.Empty;
}
