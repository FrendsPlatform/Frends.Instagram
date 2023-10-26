#pragma warning disable SA1629 // Documentation text should end with a period
namespace Frends.Instagram.Get.Definitions;

/// <summary>
/// Parameter class.
/// </summary>
public class Parameter
{
    /// <summary>
    /// Gets or sets parameter type.
    /// </summary>
    /// <example>ObjectTypes.Field.</example>
    public ObjectTypes ObjectType { get; set; }

    /// <summary>
    /// Gets or sets object's name.
    /// </summary>
    /// <example>Names.IsSharedToFeed.</example>
    public ObjectNames ObjectName { get; set; }

    /// <summary>
    /// Gets or sets manually set object name.
    /// </summary>
    /// <example>otherobject</example>
    public string Other { get; set; }

    /// <summary>
    /// Gets or sets value.
    /// Can be empty.
    /// </summary>
    /// <example>1698206594</example>
    public string ObjectValue { get; set; }
}
