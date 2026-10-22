namespace Frends.Instagram.Request.Tests;

using System;
using System.Threading;
using System.Threading.Tasks;
using Frends.Instagram.Request.Definitions;
using NUnit.Framework;

[TestFixture]
internal class ErrorHandlerTest
{
    private const string CustomErrorMessage = "CustomErrorMessage";

    [Test]
    public void Should_Throw_Error_When_ThrowErrorOnFailure_Is_True()
    {
        var ex = Assert.ThrowsAsync<ArgumentNullException>(() => Execute(new Options()));
        Assert.That(ex, Is.Not.Null);
    }

    [Test]
    public async Task Should_Return_Failed_Result_When_ThrowErrorOnFailure_Is_False()
    {
        var result = await Execute(new Options { ThrowErrorOnFailure = false });
        Assert.That(result.Success, Is.False);
        Assert.That(result.Error, Is.Not.Null);
    }

    [Test]
    public void Should_Use_Custom_ErrorMessageOnFailure()
    {
        var ex = Assert.ThrowsAsync<Exception>(() => Execute(new Options { ErrorMessageOnFailure = CustomErrorMessage }));
        Assert.That(ex.Message, Contains.Substring(CustomErrorMessage));
    }

    private static Task<Result> Execute(Options options)
    {
        var input = new Input
        {
            Method = Methods.GET,
            Reference = "me",
            ApiVersion = "18.0",
            AccessToken = string.Empty,
        };

        return Instagram.Request(input, options, CancellationToken.None);
    }
}
