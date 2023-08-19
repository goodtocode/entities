using Microsoft.IdentityModel.Tokens;
using RestSharp;
using System.Text.Json;

namespace Goodtocode.Common.Infrastructure.ApiClient;

public class AccessToken
{
    private readonly ClientCredentialSetting _accessTokenSetting;

    public AccessToken(ClientCredentialSetting accessTokenSetting)
    {
        _accessTokenSetting = accessTokenSetting;
    }

    private string Token { get; set; } = string.Empty;

    private DateTime ExpirationDateUtc { get; set; }

    private bool TokenIsExpired
    {
        get
        {
            if (string.IsNullOrWhiteSpace(Token))
                return true;

            var tokenExpiresIn = DateTime.UtcNow.Subtract(ExpirationDateUtc.AddMinutes(-1));

            return tokenExpiresIn.Minutes < 0;
        }
    }

    public async Task<string> GetAccessTokenAsync()
    {
        if (TokenIsExpired)
            return await GetNewAccessToken();

        return Token;
    }

    private async Task<string> GetNewAccessToken()
    {
        var clientId = _accessTokenSetting.ClientId;
        var clientSecret = _accessTokenSetting.ClientSecret;
        var tokenUrl = _accessTokenSetting.TokenUrl;
        var scope = _accessTokenSetting.Scope;

        var request = new RestRequest(tokenUrl, Method.Post);
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        request.AddParameter("scope", $"{scope}");
        request.AddParameter("client_id", clientId);
        request.AddParameter("client_secret", clientSecret);
        request.AddParameter("grant_type", "client_credentials");

        var restClient = new RestClient(tokenUrl);
        var response = await restClient.ExecuteAsync(request, CancellationToken.None);
        if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content)) return string.Empty;
        var tokenResponse = JsonSerializer.Deserialize<BearerToken>(response.Content);
        if (tokenResponse == null) return string.Empty;
        ExpirationDateUtc = DateTime.UtcNow.AddSeconds(tokenResponse.expires_in);
        return tokenResponse.access_token;
    }
}