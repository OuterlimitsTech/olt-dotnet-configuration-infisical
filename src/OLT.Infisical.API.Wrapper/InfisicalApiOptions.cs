namespace OLT.Infisical.API.Wrapper;

public sealed class InfisicalApiOptions
{
    /// <summary>
    /// Site URL, default is <see cref="LibConstants.SiteUrl"/>
    /// </summary>
    public string SiteUrl { get; set; } = LibConstants.SiteUrl;
    public string ClientId { get; set; } = default!;
    public string ClientSecret { get; set; } = default!;
}
