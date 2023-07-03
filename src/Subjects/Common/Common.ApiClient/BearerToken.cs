namespace Goodtocode.Common.Infrastructure.ApiClient;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "RFC6749")]
public class BearerToken
{
    public string token_type { get; set; } = string.Empty;

    public int expires_in { get; set; }

    public int ext_expires_in { get; set; }

    public string access_token { get; set; } = string.Empty;
}