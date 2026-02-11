namespace OLT.Infisical.API.Wrapper.Auth;

public interface IInfisicalTokenService
{
    Task<string?> GetTokenAsync();
}

