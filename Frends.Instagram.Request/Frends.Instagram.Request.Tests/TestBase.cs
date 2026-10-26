namespace Frends.Instagram.Request.Tests;

using Frends.Instagram.Request.Definitions;

internal abstract class TestBase
{
    protected static Input DefaultInput() => new()
    {
        Method = Methods.GET,
        Reference = "me",
        QueryParameters = "fields=id,name",
        AccessToken = "token",
        ApiVersion = "18.0",
    };

    protected static Options DefaultOptions() => new();

    protected static Input InvalidInput()
    {
        var input = DefaultInput();
        input.AccessToken = string.Empty;
        return input;
    }
}
