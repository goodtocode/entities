using System.Net.Http.Headers;

namespace Goodtocode.Common.Infrastructure.ApiClient;

public class BearerTokenHandler : DelegatingHandler
{
    private readonly AccessToken _accessToken;

    public BearerTokenHandler(AccessToken bearerToken)
    {
        _accessToken = bearerToken;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var token = await _accessToken.GetAccessTokenAsync();
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        return await base.SendAsync(request, cancellationToken);
    }
}