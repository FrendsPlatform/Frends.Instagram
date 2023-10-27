namespace Frends.Instagram.Get.Tests;

using Frends.Instagram.Get.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UnitTests
{
    private readonly string _token = Environment.GetEnvironmentVariable("Facebook_token") ?? "";

    [TestMethod]
    public async Task Get_Me_Success()
    {
        var input = new Input
        {
            ObjectId = null,
            References = "me?fields=id,name,accounts,business_users",
            ApiVersion = "18.0",
            AccessToken = _token,
        };

        var options = new Options() { ThrowErrorOnFailure = true };

        var result = await Instagram.Get(input, options, default);
        Assert.IsTrue(result.Success);
        Assert.IsNotNull(result.Data);
        Assert.IsNull(result.ErrorMessage);
    }

    [TestMethod]
    public async Task Get_ObjectId_Success()
    {
        var input = new Input
        {
            ObjectId = "6727087737314510",
            References = null,
            ApiVersion = "18.0",
            AccessToken = _token,
        };

        var options = new Options() { ThrowErrorOnFailure = true };

        var result = await Instagram.Get(input, options, default);
        Assert.IsTrue(result.Success);
        Assert.IsNotNull(result.Data);
        Assert.IsNull(result.ErrorMessage);
    }

    [TestMethod]
    public async Task Get_ThrowErrorOnFailure_False()
    {
        var input = new Input
        {
            ObjectId = "123",
            References = "me?fields=id,name,accounts,business_users",
            ApiVersion = "18.0",
            AccessToken = _token,
        };

        var options = new Options() { ThrowErrorOnFailure = false };

        var result = await Instagram.Get(input, options, default);
        Assert.IsFalse(result.Success);
        Assert.IsNull(result.Data);
        Assert.IsNotNull(result.ErrorMessage);
        Assert.AreEqual("Response status code does not indicate success: 400 (Bad Request).", result.ErrorMessage);
    }

    [TestMethod]
    public async Task Get_ThrowErrorOnFailure_True()
    {
        var input = new Input
        {
            ObjectId = "123",
            References = "me?fields=id,name,accounts,business_users",
            ApiVersion = "18.0",
            AccessToken = _token,
        };

        var options = new Options() { ThrowErrorOnFailure = true };

        var result = await Assert.ThrowsExceptionAsync<Exception>(() => Instagram.Get(input, options, default));
        Assert.IsNotNull(result);
    }
}