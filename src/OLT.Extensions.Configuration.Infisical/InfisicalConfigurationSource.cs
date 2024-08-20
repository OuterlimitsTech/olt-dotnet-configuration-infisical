using Microsoft.Extensions.Configuration;

namespace OLT.Extensions.Configuration.Infisical;

public class InfisicalConfigurationSource : IConfigurationSource
{
    public bool Optional { get; set; }
    public TimeSpan? ReloadAfter { get; set; }
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(5);
    public InfisicalOptions InfisicalOptions { get; set; } = new InfisicalOptions();

    private string? _connectionString;
    private string? _configKey;

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
    public InfisicalConfigurationSource UseConnectionString(string path, bool recursive, string? connectionString)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(path);
        ArgumentNullException.ThrowIfNullOrEmpty(connectionString);

        _connectionString = connectionString;
        InfisicalOptions.Recursive = recursive;
        InfisicalOptions.Path = path;
        return this;
    }

    /// <summary>
    /// Builds <seealso cref="InfisicalOptions"/> from a 
    /// </summary>
    /// <remarks>    
    /// <list type="table">
    ///     <item>
    ///     <term>ConnectionStrings:Infisical</term>
    ///     <description>Endpoint=https://app.infisical.com;ClientId=e2bcf5b2-0000-0000-0000-000000009876;Secret=**ClientSecret**;ProjectId=47c230b4-0000-0000-0000-000000001234;Environment=staging</description>
    ///     </item>
    /// </list>
    /// </remarks>   
    /// <param name="path"></param>
    /// <param name="recursive"></param>
    /// <param name="configKey"></param>
    /// <returns></returns>
    public InfisicalConfigurationSource UseConnectionStringKey(string path, bool recursive, string configKey)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(path);
        ArgumentNullException.ThrowIfNullOrEmpty(configKey);
        _configKey = configKey;
        InfisicalOptions.Recursive = recursive;
        InfisicalOptions.Path = path;
        return this;
    }

    /// <summary>
    /// Builds <seealso cref="InfisicalOptions"/> from a connection string
    /// </summary>
    /// <remarks>
    /// Endpoint=https://app.infisical.com;ClientId=e2bcf5b2-0000-0000-0000-000000009876;Secret=**ClientSecret**;ProjectId=47c230b4-0000-0000-0000-000000001234;Environment=staging
    /// </remarks>      
    /// <param name="path"></param>
    /// <param name="recursive"></param>
    /// <param name="connectionString">Endpoint=https://app.infisical.com;ClientId=e2bcf5b2-0000-0000-0000-000000009876;Secret=**ClientSecret**;ProjectId=47c230b4-0000-0000-0000-000000001234;Environment=staging</param>
    /// <returns></returns>
    public InfisicalConfigurationSource WithPath(string path, bool recursive)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(path);
        InfisicalOptions.Recursive = recursive;
        InfisicalOptions.Path = path;
        return this;
    }

    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {        
        if (!string.IsNullOrEmpty(_connectionString))
        {            
            UpdateOptionsFromConnectionString(builder, config => config.BuildInfisicalOptions(_connectionString, this.InfisicalOptions.Path, this.InfisicalOptions.Recursive));
        }
        else if (!string.IsNullOrEmpty(_configKey))
        {
            UpdateOptionsFromConnectionString(builder, config => config.BuildFromConfigKey(_configKey, this.InfisicalOptions.Path, this.InfisicalOptions.Recursive));
        }

        return new InfisicalConfigurationProvider(this);
    }
    
    private void UpdateOptionsFromConnectionString(IConfigurationBuilder builder, Func<IConfiguration, InfisicalOptions?> func)
    {
        var opts = func(builder.Build());
        this.InfisicalOptions.SiteUrl = opts?.SiteUrl ?? this.InfisicalOptions.SiteUrl;
        this.InfisicalOptions.ClientId = opts?.ClientId ?? this.InfisicalOptions.ClientId;
        this.InfisicalOptions.ClientSecret = opts?.ClientSecret ?? this.InfisicalOptions.ClientSecret;
        this.InfisicalOptions.Environment = opts?.ProjectId ?? this.InfisicalOptions.Environment;
        this.InfisicalOptions.ProjectId = opts?.ProjectId ?? this.InfisicalOptions.ProjectId;
    }
   
}