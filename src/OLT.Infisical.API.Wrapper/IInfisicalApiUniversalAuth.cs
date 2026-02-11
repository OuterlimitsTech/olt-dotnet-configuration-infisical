using OLT.Infisical.API.Wrapper.Secrets.Response;
using Refit;

namespace OLT.Infisical.API.Wrapper;

public interface IInfisicalApiUniversalAuth
{
    [Post("/api/v1/auth/universal-auth/login")]
    [Headers("Content-Type: application/x-www-form-urlencoded")]
    Task<InfiscalTokenResponse> GetToken([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, string> formData, CancellationToken ct = default);
}

