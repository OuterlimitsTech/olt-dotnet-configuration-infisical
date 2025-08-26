namespace OLT.Infisical.API.Wrapper.Auth;

public sealed class InfisicalBearerTokenHandler : DelegatingHandler
{
    private readonly IInfisicalTokenService _tokenService;

    public InfisicalBearerTokenHandler(IInfisicalTokenService tokenService)
    {
        _tokenService = tokenService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Get the token from the token service
        string? token = await _tokenService.GetTokenAsync();

        // Add the Authorization header if the token is available
        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        // Proceed with the request
        return await base.SendAsync(request, cancellationToken);
    }
}

