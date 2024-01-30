namespace Frends.Instagram.Request.Tests;

using Frends.Instagram.Request.Definitions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

[TestFixture]
public class UnitTests
{
    internal static readonly HttpClient Client = new HttpClient();
    private readonly string token = Environment.GetEnvironmentVariable("Facebook_token");

    private string objectId;

    [SetUp]
    public async Task SetUp()
    {
        // Fetch App Id
        var appUrl = @"https://graph.facebook.com/v18.0/me";
        var result = await GetAsync(appUrl, token);
        objectId = (string)result["id"];
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        Client.Dispose();
    }

    [Test]
    public void TestGetOther()
    {
        var input = new Input
        {
            Method = Methods.GET,
            Reference = "me",
            QueryParameters = "fields=id,name",
            AccessToken = token,
            ApiVersion = "18.0",
        };

        var ret = Instagram.Request(input, new Options { ThrowErrorOnFailure = true }, default);
        Assert.IsNotNull(ret);
        Assert.AreEqual(ret.Result.Statuscode, 200);
        Assert.IsTrue(ret.Result.Message.Contains(objectId));
    }

    [Test]
    public void TestThrowTokenEmptyError()
    {
        var input = new Input
        {
            Method = Methods.GET,
            Reference = "me",
            AccessToken = string.Empty,
            ApiVersion = "18.0",
        };

        var ret = Assert.ThrowsAsync<ArgumentNullException>(() => Instagram.Request(input, new Options(), default));
        Assert.IsNotNull(ret);
    }

    [Test]
    public void TestThrowErrorOnFailure()
    {
        var input = new Input
        {
            Method = Methods.GET,
            Reference = objectId + "/abcdefg",
            AccessToken = token,
            ApiVersion = "18.0",
        };

        var option = new Options { ThrowErrorOnFailure = true };

        var ret = Assert.ThrowsAsync<Exception>(() => Instagram.Request(input, option, default));
        Assert.IsNotNull(ret);
    }

    [Test]
    public void TestThrowMessageEmptyError()
    {
        var input = new Input
        {
            Method = Methods.POST,
            Reference = "me",
            AccessToken = token,
            ApiVersion = "18.0",
            Message = string.Empty,
        };

        var ret = Assert.ThrowsAsync<ArgumentNullException>(() => Instagram.Request(input, new Options(), default));
        Assert.IsNotNull(ret);
    }

    [Test]
    public void TestThrowApiVersionEmptyError()
    {
        var input = new Input
        {
            Method = Methods.POST,
            Reference = "me",
            AccessToken = token,
            ApiVersion = string.Empty,
            Message = "{ \"message\": \"This is a test.\" }",
        };

        var ret = Assert.ThrowsAsync<ArgumentNullException>(() => Instagram.Request(input, new Options(), default));
        Assert.IsNotNull(ret);
    }

    [Test]
    public void TestThrowReferenceEmptyError()
    {
        var input = new Input
        {
            Method = Methods.POST,
            Reference = string.Empty,
            AccessToken = token,
            ApiVersion = "18.0",
            Message = "{ \"message\": \"This is a test.\" }",
        };

        var ret = Assert.ThrowsAsync<ArgumentNullException>(() => Instagram.Request(input, new Options(), default));
        Assert.IsNotNull(ret);
    }

    [Test]
    public async Task Get_Me_Success()
    {
        var input = new Input
        {
            Reference = "me",
            QueryParameters = "fields=id,name,accounts,business_users",
            ApiVersion = "18.0",
            AccessToken = token,
        };

        var options = new Options() { ThrowErrorOnFailure = true };

        var result = await Instagram.Request(input, options, default);
        Assert.AreEqual(200, result.Statuscode);
        Assert.IsNotNull(result.Message);
    }

    [Test]
    public async Task Get_Reference_Success()
    {
        var input = new Input
        {
            Reference = "6727087737314510",
            QueryParameters = null,
            ApiVersion = "18.0",
            AccessToken = token,
        };

        var options = new Options() { ThrowErrorOnFailure = true };

        var result = await Instagram.Request(input, options, default);
        Assert.AreEqual(200, result.Statuscode);
        Assert.IsNotNull(result.Message);
    }

    [Test]
    public async Task Get_ThrowErrorOnFailure_False()
    {
        var input = new Input
        {
            Reference = "123",
            QueryParameters = "me?fields=id,name,accounts,business_users",
            ApiVersion = "18.0",
            AccessToken = token,
        };

        var options = new Options() { ThrowErrorOnFailure = false };

        var result = await Instagram.Request(input, options, default);
        Assert.AreEqual(400, result.Statuscode);
        Assert.IsNotNull(result.Message);
    }

    [Test]
    public void Get_ThrowErrorOnFailure_True()
    {
        var input = new Input
        {
            Reference = "123",
            QueryParameters = "me?fields=id,name,accounts,business_users",
            ApiVersion = "18.0",
            AccessToken = token,
        };

        var options = new Options() { ThrowErrorOnFailure = true };

        var result = Assert.ThrowsAsync<Exception>(() => Instagram.Request(input, options, default));
        Assert.IsNotNull(result.Message);
    }

    private static async Task<JObject> GetAsync(string url, string token)
    {
        using var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url),
        };
        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Add("Authorization", "Bearer " + token);
        }

        string responseString = null;

        try
        {
            var responseMessage = Client.Send(request, CancellationToken.None);
            responseMessage.EnsureSuccessStatusCode();
            responseString = await responseMessage.Content.ReadAsStringAsync(CancellationToken.None);
            request.Dispose();
        }
        catch (Exception)
        {
            request.Dispose();
        }

        return JObject.Parse(responseString);
    }
}
