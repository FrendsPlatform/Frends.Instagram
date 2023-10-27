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
    /// <param name="options">Optional parameters.</param>
    /// <param name="cancellationToken">Cancellation token given by Frends.</param>
    /// <returns>Object { bool Success, dynamic Message }.</returns>
    public static async Task<Result> Get([PropertyTab] Input input, [PropertyTab] Options options, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(input.AccessToken))
            throw new ArgumentNullException(nameof(input.AccessToken) + " cannot be empty.");

        try
        {
            var url = !string.IsNullOrWhiteSpace(input.References)
            ? $@"https://graph.facebook.com/v{input.ApiVersion}/{input.ObjectId}{input.References}&access_token={input.AccessToken}"
            : $@"https://graph.facebook.com/v{input.ApiVersion}/{input.ObjectId}?access_token={input.AccessToken}";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
            };

            var responseMessage = await Client.SendAsync(request, cancellationToken);
            responseMessage.EnsureSuccessStatusCode();
            var responseString = await responseMessage.Content.ReadAsStringAsync();

            return new Result(true, responseString, null);
        }
        catch (Exception ex)
        {
            if (options.ThrowErrorOnFailure)
                throw new Exception(ex.Message, ex.InnerException);
            return new Result(false, null, ex.Message);
        }
    }
}
