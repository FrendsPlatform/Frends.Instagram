﻿namespace Frends.Instagram.Get.Definitions;

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
    /// <example>Insights.</example>
    [DefaultValue(References.Insights)]
    public References Reference { get; set; }

    /// <summary>
    /// Gets or sets reference when reference is other. All reference types can be found from: https://developers.facebook.com/docs/instagram-api/reference.
    /// </summary>
    /// <example>Insights.</example>
    [UIHint(nameof(Reference), "", References.Other)]
    [DisplayFormat(DataFormatString = "Text")]
    [DefaultValue("Insight")]
    public string Other { get; set; }

    /// <summary>
    /// Gets or sets object id of the reference.
    /// </summary>
    /// <example>123456789.</example>
    [DisplayFormat(DataFormatString = "Text")]
    [DefaultValue("123456789")]
    public string ObjectId { get; set; }

    /// <summary>
    /// Gets or sets list of parameters.
    /// </summary>
    /// <example>[{ Name, Value }].</example>
    public Parameter[] Parameters { get; set; } = System.Array.Empty<Parameter>();

    /// <summary>
    /// Gets or sets authentication bearer token.
    /// </summary>
    /// <example>BearerToken1234.</example>
    [PasswordPropertyText]
    [DisplayFormat(DataFormatString = "Text")]
    [DefaultValue("BearerToken1234")]
    public string Token { get; set; }
}