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
    /// This is Task for reading data from Instagram API.
    /// [Documentation](https://tasks.frends.com/tasks/frends-tasks/Frends.Instagram.Get).
    /// </summary>
    /// <param name="input">Set reference type, parameters and token.</param>
    /// <param name="options">Optional parameters.</param>
    /// <param name="cancellationToken">Cancellation token given by Frends.</param>
    /// <returns>Object { bool Success, dynamic Data, string ErrorMessage }.</returns>
    public static async Task<Result> Get([PropertyTab] Input input, [PropertyTab] Options options, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(input.AccessToken))
            throw new ArgumentNullException(nameof(input.AccessToken) + " cannot be empty.");
        if (string.IsNullOrEmpty(input.ApiVersion))
            throw new ArgumentNullException(nameof(input.ApiVersion) + " cannot be empty.");
        if (!string.IsNullOrEmpty(input.QueryParameters) && string.IsNullOrEmpty(input.Reference))
            throw new Exception(@$"{nameof(input.Reference)} cannot be empty when {nameof(input.QueryParameters)} is set.");

        try
        {
            var url = !string.IsNullOrWhiteSpace(input.QueryParameters)
            ? $@"https://graph.facebook.com/v{input.ApiVersion}/{input.Reference}?{input.QueryParameters}&access_token={input.AccessToken}"
            : $@"https://graph.facebook.com/v{input.ApiVersion}/{input.Reference}?access_token={input.AccessToken}";

            using var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
            };

            var responseMessage = await client.SendAsync(request, cancellationToken);
            responseMessage.EnsureSuccessStatusCode();
            var responseString = string.Empty;
#if NET471
            responseString = await responseMessage.Content.ReadAsStringAsync();
#elif NET6_0_OR_GREATER
            responseString = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
#endif

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
