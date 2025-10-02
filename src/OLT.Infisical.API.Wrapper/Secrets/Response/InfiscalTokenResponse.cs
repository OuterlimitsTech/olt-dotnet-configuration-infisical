namespace OLT.Infisical.API.Wrapper.Secrets.Response;

public sealed class InfiscalTokenResponse
{
    public string? AccessToken { get; init; }
    public int ExpiresIn { get; init; }
    public int AccessTokenMaxTTL { get; init; }
    public string? TokenType { get; init; }

    public bool Expired
    {
        get
        {
            return DateTimeOffset.Now >= GetExpiryTimestamp();
        }
    }

    public DateTimeOffset GetExpiryTimestamp()
    {
        try
        {
            return DateTimeOffset.FromUnixTimeSeconds(ExpiresIn).AddSeconds(-30);
        }
        catch 
        { 
            return DateTimeOffset.Now.AddMinutes(-10);
        }
      
    }

}
