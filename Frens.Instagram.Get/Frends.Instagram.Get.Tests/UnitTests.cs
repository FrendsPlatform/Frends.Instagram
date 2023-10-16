namespace Frends.Instagram.Get.Tests;

using Frends.Instagram.Get.Definitions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// UnitTests.
/// </summary>
[TestFixture]
public class UnitTests
{
    /// <summary>
    /// Client.
    /// </summary>
    internal static readonly HttpClient Client = new ();
    private readonly string token = Environment.GetEnvironmentVariable("Facebook_token");
    private string objectId;

    /*
        private readonly string _clientId = "clientId";
        private readonly string _clientSecret = "clientSecret";
        privare readonly string _facebookId = "facebookId";
    */

    /// <summary>
    /// Todo: Create Page Access Token.
    /// </summary>
    /// <returns>TODO.</returns>
    [SetUp]
    public async Task SetUp()
    {
        // Fetch token
        /*try
        {

            var appTokenUrl = @"https://graph.facebook.com/v18.0/oauth/access_token?" +
                "client_id=" + _clientId +
                "&client_secret=" + _clientSecret +
                "&grant_type=client_credentials";
            var appToken = await GetAsync(appTokenUrl);

            var pageAccessUrl = @"https://graph.facebook.com/" + _facebookId +
                "/accounts?access_token=" + (string)appToken["access_token"];
            var pageToken = await GetAsync(pageAccessUrl);

            token = (string)pageToken["data"][0]["access_token"].ToString();
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }*/

        // Fetch App Id
        try
        {
            var appUrl = @"https://graph.facebook.com/v18.0/me";
            var result = await GetAsync(appUrl, this.token);
            this.objectId = (string)result["id"];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    /// <summary>
    /// Test Insights ref.
    /// </summary>
    [Test]
    public void TestGetInsights()
    {
        var input = new Input
        {
            Reference = References.Insights,
            ObjectId = this.objectId,
            Token = this.token,
            Parameters = new Parameter[] { new Parameter { Name = "metric", Value = "page_impressions_unique" }, new Parameter { Name = "metric", Value = "post_reactions_love_total" } },
        };

        var ret = Instagram.Get(input, default);
        Assert.IsNotNull(ret);
        /*
         Assert.IsTrue(ret.Result.Success);
         Test user has no permissions for this
        */
        Assert.IsFalse(ret.Result.Success);
    }

    /// <summary>
    /// Test Stories ref.
    /// </summary>
    [Test]
    public void TestGetStories()
    {
        var input = new Input
        {
            Reference = References.Stories,
            ObjectId = this.objectId,
            Token = this.token,
            Parameters = null,
        };

        var ret = Instagram.Get(input, default);
        Assert.IsNotNull(ret);
        /*
         Assert.IsTrue(ret.Result.Success);
         Test user has no permissions for this
        */
        Assert.IsFalse(ret.Result.Success);
    }

    /// <summary>
    /// Test Other ref.
    /// </summary>
    [Test]
    public void TestGetOther()
    {
        var input = new Input
        {
            Reference = References.Other,
            Other = "me",
            Token = this.token,
            Parameters = new Parameter[] { new Parameter { Name = "fields", Value = "id,name" } },
        };

        var ret = Instagram.Get(input, default);
        Assert.IsNotNull(ret);
        Assert.IsTrue(ret.Result.Success);
        Assert.IsTrue(ret.Result.Message.Contains(this.objectId));
    }

    /// <summary>
    /// Param test.
    /// </summary>
    [Test]
    public void TestGetOtherWithDuplicateParameters()
    {
        var input = new Input
        {
            Reference = References.Other,
            Other = "me",
            Token = this.token,
            Parameters = new Parameter[] { new Parameter { Name = "fields", Value = "id" }, new Parameter { Name = "fields", Value = "name" } },
        };

        var ret = Instagram.Get(input, default);
        Assert.IsNotNull(ret);
        Assert.IsTrue(ret.Result.Success);
        Assert.IsTrue(ret.Result.Message.Contains(this.objectId));
    }

    /// <summary>
    /// Test throw.
    /// </summary>
    [Test]
    public void TestThrowTokenEmptyError()
    {
        var input = new Input
        {
            Reference = References.Other,
            Other = "me",
            Token = string.Empty,
        };

        var ret = Assert.ThrowsAsync<ArgumentNullException>(() => Instagram.Get(input, default));
        Assert.IsNotNull(ret);
    }

    private static async Task<JObject> GetAsync(string url, string token)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url),
        };
        if (!string.IsNullOrEmpty(token)) request.Headers.Add("Authorization", "Bearer " + token);

        var responseMessage = Client.Send(request, CancellationToken.None);
        responseMessage.EnsureSuccessStatusCode();
        var responseString = await responseMessage.Content.ReadAsStringAsync(CancellationToken.None);

        return JObject.Parse(responseString);
    }
}
