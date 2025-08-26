using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

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

    public DateTime GetExpiryTimestamp()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(AccessToken))
                return DateTime.MinValue;
            if (!AccessToken.Contains("."))
                return DateTime.MinValue;

            string[] parts = AccessToken.Split('.');
            InfisicalJwtToken? payload = JsonSerializer.Deserialize<InfisicalJwtToken>(Base64UrlEncoder.Decode(parts[1]));

            if (payload == null) return DateTime.MinValue;

            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(payload.Exp);
            return dateTimeOffset.LocalDateTime;
        }
        catch (Exception)
        {
            return DateTime.MinValue;
        }
    }

}
