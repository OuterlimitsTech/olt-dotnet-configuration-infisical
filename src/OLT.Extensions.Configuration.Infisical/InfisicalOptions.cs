using System.Data.Common;

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
    /// Default is "dev"
    /// </remarks>
    public string Environment { get; set; } = "dev";


    /// <summary>
    /// Builds <seealso cref="InfisicalOptions"/> from a connection string
    /// </summary>
    /// <remarks>
    /// Endpoint=https://app.infisical.com;ClientId=e2bcf5b2-0000-0000-0000-000000009876;Secret=**ClientSecret**;ProjectId=47c230b4-0000-0000-0000-000000001234;Environment=staging
    /// </remarks>      
    /// <param name="path"></param>
    /// <param name="recursive"></param>
    /// <param name="connectionString"></param>
    /// <returns></returns>
    public void LoadFromConnectionString(string path, bool recursive, string connectionString)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(path);
        ArgumentNullException.ThrowIfNullOrEmpty(connectionString);

        DbConnectionStringBuilder connectionStringBuilder = new DbConnectionStringBuilder
        {
            ConnectionString = connectionString
        };

        var siteUrl = connectionStringBuilder["Endpoint"]?.ToString() ?? throw new ArgumentNullException("Infisical Endpoint (SiteUrl)");
        var clientId = connectionStringBuilder["ClientId"]?.ToString() ?? throw new ArgumentNullException("Infisical ClientId");
        var clientSecret = connectionStringBuilder["Secret"]?.ToString() ?? throw new ArgumentNullException("Infisical Secret");
        var projectId = connectionStringBuilder["ProjectId"]?.ToString() ?? throw new ArgumentNullException("Infisical ProjectId");
        var env = connectionStringBuilder["Environment"]?.ToString() ?? throw new ArgumentNullException("Infisical Environment");

        //_connectionString = connectionString;
        Recursive = recursive;
        Path = path;
    }

}

