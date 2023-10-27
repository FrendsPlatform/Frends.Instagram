namespace Frends.Instagram.Get.Tests;

using Frends.Instagram.Get.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UnitTests
{
    private readonly string _token = Environment.GetEnvironmentVariable("Facebook_token");

    [TestMethod]
    public async Task GetFields_Success()
    {
        var input = new Input
        {
            Reference = References.Fields,
            ApiVersion = "18.0",
            ObjectId = "6727087737314510",
            AccessToken = _token,
        };

        var options = new Options() { ThrowErrorOnFailure = true };

        var result = await Instagram.Get(input, options, default);
        Assert.IsTrue(result.Success);
        Assert.IsNotNull(result.Data);
        Assert.IsNull(result.ErrorMessage);
    }

    [TestMethod]
    public async Task GetFields_InvalidObjectId()
    {
        var input = new Input
        {
            Reference = References.Fields,
            ApiVersion = "18.0",
            ObjectId = "672708773731451",
            AccessToken = _token,
        };

        var options = new Options() { ThrowErrorOnFailure = false };

        var result = await Instagram.Get(input, options, default);
        Assert.IsFalse(result.Success);
        Assert.IsNull(result.Data);
        Assert.IsNotNull(result.ErrorMessage);
        Assert.AreEqual("Response status code does not indicate success: 400 (Bad Request).", result.ErrorMessage);
    }
}