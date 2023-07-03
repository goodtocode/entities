namespace Goodtocode.Common.Infrastructure.ApiClient;

public class ClientCredentialSetting
{
    public ClientCredentialSetting(string clientId, string clientSecret, string tokenUrl, string scope)
    {
        ClientId = clientId;
        ClientSecret = clientSecret;
        TokenUrl = tokenUrl;
        Scope = scope;
    }

    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string TokenUrl { get; set; }
    public string Scope { get; set; }
}