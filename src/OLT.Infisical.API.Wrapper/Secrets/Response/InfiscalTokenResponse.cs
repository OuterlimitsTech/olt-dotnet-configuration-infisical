namespace OLT.Infisical.API.Wrapper.Secrets.Response;

public sealed class InfiscalTokenResponse
{
    public string? AccessToken { get; init; }
    public long ExpiresIn { get; init; }
    public long AccessTokenMaxTTL { get; init; }
    public string? TokenType { get; init; }
    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.Now;

    public bool Expired
    {
        get
        {
            var val = GetExpiryTimestamp();
            return DateTimeOffset.Now >= val;
        }
    }

    public DateTimeOffset GetExpiryTimestamp()
    {
        try
        {
            //return DateTimeOffset.FromUnixTimeSeconds(ExpiresIn).AddSeconds(-30);
            return DateTimeOffset.Now.AddSeconds(ExpiresIn);
        }
        catch 
        { 
            return CreationTime.AddMinutes(3);
        }
      
    }

}
