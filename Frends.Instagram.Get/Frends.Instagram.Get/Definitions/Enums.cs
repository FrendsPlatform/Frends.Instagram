namespace Frends.Instagram.Get.Definitions;

/// <summary>
/// References.
/// </summary>
public enum References
{
    /// <summary>
    /// Get fields and edges of the object.
    /// Parameters should be empty.
    /// </summary>
    Fields,

    /// <summary>
    /// GET /{media-id}/children
    /// </summary>
    MediaChildren,

    /// <summary>
    /// GET /{user-id}/media
    /// </summary>
    UserMedia,

    /// <summary>
    /// Get with other reference.
    /// </summary>
    Other,
}

/// <summary>
/// ObjectTypes.
/// </summary>
public enum ObjectTypes
{
    /// <summary>
    /// Field.
    /// </summary>
    Field,

    /// <summary>
    /// Metric.
    /// </summary>
    Metric,
}

/// <summary>
/// Object names.
/// </summary>
public enum ObjectNames
{
    /// <summary>
    /// Other.
    /// </summary>
    Other,

    /// <summary>
    /// Account type.
    /// </summary>
    AccountType,

    /// <summary>
    /// Caption.
    /// Excludes album children.
    /// The @ symbol is excluded, unless the app user can perform admin-equivalent tasks on the Facebook Page connected to the Instagram account used to create the caption.
    /// </summary>
    Caption,

    /// <summary>
    /// Count of comments on the media.
    /// Excludes comments on album child media and the media's caption.
    /// Includes replies on comments.
    /// </summary>
    CommentsCount,

    /// <summary>
    /// ID.
    /// </summary>
    Id,

    /// <summary>
    /// For Reels only.
    /// When true, indicates that the reel can appear in both the Feed and Reels tabs.
    /// When false, indicates the reel can only appear in the Reels tab.
    /// </summary>
    IsSharedToFeed,

    /// <summary>
    /// The Media's type.
    /// </summary>
    MediaType,

    /// <summary>
    /// The number of Media on the User.
    /// </summary>
    MediaCount,

    /// <summary>
    /// The Media's URL.
    /// </summary>
    MediaUrl,

    /// <summary>
    /// The Media's permanent URL. Will be omitted if the Media contains copyrighted material, or has been flagged for a copyright violation.
    /// </summary>
    PermaLink,

    /// <summary>
    /// The Media's thumbnail image URL. Only available on VIDEO Media.
    /// </summary>
    ThumbnailUrl,

    /// <summary>
    /// The Media's publish date in ISO 8601 format.
    /// </summary>
    Timestamp,

    /// <summary>
    /// The Media owner's username.
    /// </summary>
    Username,
}