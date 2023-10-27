#pragma warning disable SA1629 // Documentation text should end with a period.
namespace Frends.Instagram.Get.Definitions;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Input class usually contains parameters that are required.
/// </summary>
public class Input
{
    /// <summary>
    /// Gets or sets object ID of the reference.
    /// </summary>
    /// <example>123456789</example>
    [DisplayFormat(DataFormatString = "Text")]
    public string ObjectId { get; set; }

    /// <summary>
    /// Gets or sets references.
    /// All reference types can be found from: https://developers.facebook.com/docs/instagram-api/reference
    /// </summary>
    /// <example>
    ///     /accounts
    ///     ?fields=foo&amp;metric=bar
    ///     /ig_hashtag_search?user_id={user-id}&amp;q={q}
    /// </example>
    public string References { get; set; }

    /// <summary>
    /// Gets or sets API version.
    /// </summary>
    /// <example>18.0</example>
    [DisplayFormat(DataFormatString = "Text")]
    [DefaultValue("18.0")]
    public string ApiVersion { get; set; }

    /// <summary>
    /// Gets or sets access token.
    /// </summary>
    /// <example>abc123</example>
    [PasswordPropertyText]
    [DisplayFormat(DataFormatString = "Text")]
    public string AccessToken { get; set; }
}