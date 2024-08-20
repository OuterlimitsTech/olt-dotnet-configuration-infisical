namespace OLT.Extensions.Configuration.Infisical;

public class InfisicalOptions
{
    public InfisicalOptions()
    {
        
    }

    public InfisicalOptions(string clientId, string clientSecret, string projectId, string environment)
    {        
        ClientId = clientId;
        ClientSecret = clientSecret;
        ProjectId = projectId;
        Environment = environment;
    }

    public InfisicalOptions(string clientId, string clientSecret, string projectId, string environment, string path, bool recursive)
    {
        ClientId = clientId;
        ClientSecret = clientSecret;
        ProjectId = projectId;
        Environment = environment;
        Path = path;
        Recursive = recursive;
    }

    /// <summary>
    /// Infisical endpoint
    /// </summary>
    /// <remarks>
    /// Default is "https://app.infisical.com"
    /// </remarks>
    public string SiteUrl { get; set; } = "https://app.infisical.com";


    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
    public string ProjectId { get; set; } = string.Empty;

    /// <summary>
    /// Folder Path
    /// </summary>
    /// <remarks>
    /// Default is "/"
    /// </remarks>
    public string Path { get; set; } = "/";


    /// <summary>
    /// Load all keys and folders under <seealso cref="Path"/>
    /// </summary>
    public bool Recursive { get; set; }

    /// <summary>
    /// Infisical Environment
    /// </summary>
    /// <remarks>
    /// Default is "Development"
    /// </remarks>
    public string Environment { get; set; } = "Development";
    
}

