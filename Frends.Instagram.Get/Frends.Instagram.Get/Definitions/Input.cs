#pragma warning disable SA1629 // Documentation text should end with a period.
namespace Frends.Instagram.Get.Definitions;

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Input class usually contains parameters that are required.
/// </summary>
public class Input
{
    /// <summary>
    /// Gets or sets reference type.
    /// </summary>
    /// <example>References.UserMedia</example>
    [DefaultValue(References.UserMedia)]
    public References Reference { get; set; }

    /// <summary>
    /// Gets or sets reference when reference is other.
    /// All reference types can be found from: https://developers.facebook.com/docs/instagram-api/reference.
    /// </summary>
    /// <example>{otherreference}</example>
    [UIHint(nameof(Reference), "", References.Other)]
    [DisplayFormat(DataFormatString = "Text")]
    public string Other { get; set; }

    /// <summary>
    /// Gets or sets API version.
    /// </summary>
    /// <example>18.0</example>
    [DisplayFormat(DataFormatString = "Text")]
    [DefaultValue("18.0")]
    public string ApiVersion { get; set; }

    /// <summary>
    /// Gets or sets object ID of the reference.
    /// </summary>
    /// <example>123456789</example>
    [DisplayFormat(DataFormatString = "Text")]
    public string ObjectId { get; set; }

    /// <summary>
    /// Gets or sets list of parameters.
    /// </summary>
    /// <example>[{ ObjectType, Name, Value }].</example>
    public Parameter[] Parameters { get; set; } = Array.Empty<Parameter>();

    /// <summary>
    /// Gets or sets access token.
    /// </summary>
    /// <example>abc123</example>
    [PasswordPropertyText]
    [DisplayFormat(DataFormatString = "Text")]
    public string AccessToken { get; set; }
}