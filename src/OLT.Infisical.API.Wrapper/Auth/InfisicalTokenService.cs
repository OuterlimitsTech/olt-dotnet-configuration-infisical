using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OLT.Infisical.API.Wrapper.Secrets.Response;

namespace OLT.Infisical.API.Wrapper.Auth;

public sealed class InfisicalTokenService : IInfisicalTokenService
{
    private readonly IInfisicalApiUniversalAuth _authApi;
    private readonly InfisicalApiOptions _options;
    private readonly ILogger<InfisicalTokenService> _logger;
    private readonly IMemoryCache _memoryCache;

    private readonly string _cacheKey;

    //private InfiscalTokenResponse? _cachedToken;

    public InfisicalTokenService(ILogger<InfisicalTokenService> logger, IMemoryCache memoryCache, IInfisicalApiUniversalAuth authApi, IOptions<InfisicalApiOptions> options)
    {
        _cacheKey = $"OLT:Infisical:API:Wrapper:Auth:{nameof(InfisicalTokenService)}:token";
        _authApi = authApi;
        _options = options.Value;
        _logger = logger;
        _memoryCache = memoryCache;
    }

    public async Task<string?> GetTokenAsync()
    {
        
        var cachedToken = _memoryCache.Get<InfiscalTokenResponse>(_cacheKey);
        
        if (cachedToken == null || cachedToken.Expired)
        {
            var formData = new Dictionary<string, string>
            {
                { "clientId", _options.ClientId },
                { "clientSecret", _options.ClientSecret }
            };

            _logger.LogDebug("OLT.Infisical.API.Wrapper.Auth.{InfisicalTokenService} - get new token", nameof(InfisicalTokenService));

            try
            {
                cachedToken = await _authApi.GetToken(formData);
                _memoryCache.Set(_cacheKey, cachedToken);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "OLT.Infisical.API.Wrapper.Auth.{InfisicalTokenService} - error retrieving new token", nameof(InfisicalTokenService));
            }

        }
        else
        {
            _logger.LogDebug("OLT.Infisical.API.Wrapper.Auth.{InfisicalTokenService} - using cached token", nameof(InfisicalTokenService));
        }


        return cachedToken?.AccessToken;
    }
}
