#pragma warning disable SA1503 // Braces should not be omitted
namespace Frends.Instagram.Get;

using Frends.Instagram.Get.Definitions;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Instagram class.
/// </summary>
public static class Instagram
{
    /// <summary>
    /// HTTP client.
    /// </summary>
    internal static readonly HttpClient Client = new();

    /// <summary>
    /// This is Task for reading data from Instagram API.
    /// [Documentation](https://tasks.frends.com/tasks/frends-tasks/Frends.Instagram.Get).
    /// </summary>
    /// <param name="input">Set reference type, parameters and token.</param>
    /// <param name="cancellationToken">Cancellation token given by Frends.</param>
    /// <returns>Object { bool Success, dynamic Message }.</returns>
    public static async Task<Result> Get([PropertyTab] Input input, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(input.AccessToken))
            throw new ArgumentNullException(nameof(input.AccessToken) + " cannot be empty.");

        try
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(GetUrl(input)),
            };

            var responseMessage = await Client.SendAsync(request, cancellationToken);
            responseMessage.EnsureSuccessStatusCode();
            var responseString = await responseMessage.Content.ReadAsStringAsync();

            return new Result(true, responseString);
        }
        catch (Exception ex)
        {
            return new Result(false, ex.Message);
        }
    }

    private static string GetUrl(Input input)
    {
        var url = @$"https://graph.facebook.com/{input.ApiVersion}/";

        // Set url base
        switch (input.Reference)
        {
            case References.Fields:
                url += $"{input.ObjectId}";
                break;
            case References.MediaChildren:
                url += $"{input.ObjectId}/children";
                break;
            case References.UserMedia:
                url += $"{input.ObjectId}/media";
                break;
            case References.Other:
                url = input.ObjectId != null ? url += $"{input.ObjectId}/{input.Other}" : url += $"{input.Other}";
                break;
        }

        if (input.Parameters != null)
        {
            url += "?";
            var metric = "metric=";
            var field = "fields=";

            foreach (var parameter in input.Parameters)
            {
                var objectName = parameter.ObjectName.Equals(ObjectNames.Other) ? parameter.Other : parameter.ObjectName.ToString();

                if (parameter.ObjectType.Equals(ObjectTypes.Metric))
                    metric += $"{objectName}={parameter.ObjectValue}";

                if (parameter.ObjectType.Equals(ObjectTypes.Field))
                    field += $"{objectName}={parameter.ObjectValue}";
            }

            if (metric.Length > "metric=".Length)
            {
                url += metric;

                if (field.Length > "fields=".Length)
                    url += $"&{field}";
            }

            if (metric.Length == "metric=".Length && field.Length > "fields=".Length)
                url += field;
        }

        url += $"&access_token={input.AccessToken}";
        return url;
    }
}
