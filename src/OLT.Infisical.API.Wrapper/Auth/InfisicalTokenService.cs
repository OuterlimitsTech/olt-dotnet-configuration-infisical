using Microsoft.Extensions.Options;
using OLT.Infisical.API.Wrapper.Secrets.Response;

namespace OLT.Infisical.API.Wrapper.Auth;

public sealed class InfisicalTokenService : IInfisicalTokenService
{
    private readonly IInfisicalApiUniversalAuth _authApi;
    private readonly InfisicalApiOptions _options;
    private InfiscalTokenResponse? _cachedToken;

    public InfisicalTokenService(IInfisicalApiUniversalAuth authApi, IOptions<InfisicalApiOptions> options)
    {
        _authApi = authApi;
        _options = options.Value;
    }

    public async Task<string?> GetTokenAsync()
    {
        if (_cachedToken == null || _cachedToken.Expired)
        {
            var formData = new Dictionary<string, string>
            {
                { "clientId", _options.ClientId },
                { "clientSecret", _options.ClientSecret }
            };
            _cachedToken = await _authApi.GetToken(formData);
        }

        
        return _cachedToken?.AccessToken;
    }
}
