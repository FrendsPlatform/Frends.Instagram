namespace Frends.Instagram.Get.Tests;

using Frends.Instagram.Get.Definitions;
using NUnit.Framework;
using System;
using System.Net.Http;
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
    internal static readonly HttpClient Client = new();
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
    }

    [Test]
    public void TestGetUser()
    {
        var input = new Input
        {
            Reference = References.Fields,
            ObjectId = this.objectId,
            AccessToken = this.token,
            //Parameters = new Parameter[] { new Parameter { ObjectType = ObjectTypes.Field, Name = "foo", Value = "page_impressions_unique" }, new Parameter { Name = "metric", Value = "post_reactions_love_total" } },
        };

        var ret = Instagram.Get(input, default);
        Assert.IsNotNull(ret);
        /*
         Assert.IsTrue(ret.Result.Success);
         Test user has no permissions for this
        */
        Assert.IsFalse(ret.Result.Success);
    }
}
