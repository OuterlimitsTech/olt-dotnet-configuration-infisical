using Microsoft.Extensions.Configuration;
using System.Data.Common;

namespace OLT.Extensions.Configuration.Infisical;

public static class ConfigurationExtensions
{

    /// <summary>
    /// Builds <seealso cref="InfisicalOptions"/> from a connection string
    /// </summary>
    /// <remarks>
    /// <list type="table">
    ///     <item>
    ///     <term>ConnectionStrings:Infisical</term>
    ///     <description>Endpoint=https://app.infisical.com;ClientId=e2bcf5b2-0000-0000-0000-000000009876;Secret=**ClientSecret**;ProjectId=47c230b4-0000-0000-0000-000000001234;Environment=staging</description>
    ///     </item>
    /// </list>
    /// </remarks>
    /// <param name="configuration"></param>
    /// <param name="path"></param>
    /// <param name="recursive"></param>
    /// <param name="configKey"></param>
    /// <returns><seealso cref="InfisicalOptions"/></returns>
    /// <exception cref="ArgumentNullException"></exception>    
    internal static InfisicalOptions? BuildFromConfigKey(this IConfiguration configuration, string configKey, string path, bool recursive)
    {
        var connectionString =
                configuration.GetConnectionString(configKey) ??
                configuration.GetValue<string>(configKey) ??
                Environment.GetEnvironmentVariable(configKey) ??
                throw new Exception($"Invalid Configuration Key {configKey}");

        return BuildInfisicalOptions(configuration, connectionString, path, recursive);
    }

    /// <summary>
    /// Builds <seealso cref="InfisicalOptions"/> from a connection string
    /// </summary>
    /// <remarks>
    /// <list type="table">
    ///     <item>
    ///     <term>ConnectionStrings:Infisical</term>
    ///     <description>Endpoint=https://app.infisical.com;ClientId=e2bcf5b2-0000-0000-0000-000000009876;Secret=**ClientSecret**;ProjectId=47c230b4-0000-0000-0000-000000001234;Environment=staging</description>
    ///     </item>
    /// </list>
    /// </remarks>  
    /// <param name="configuration"></param>
    /// <param name="connectionString"></param>
    /// <param name="path"></param>
    /// <param name="recursive"></param>
    /// <returns><seealso cref="InfisicalOptions"/></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static InfisicalOptions? BuildInfisicalOptions(this IConfiguration configuration, string? connectionString, string path, bool recursive)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            return null;
        }

        DbConnectionStringBuilder connectionStringBuilder = new DbConnectionStringBuilder
        {
            ConnectionString = connectionString
        };

        var siteUrl = connectionStringBuilder["Endpoint"]?.ToString() ?? throw new ArgumentNullException("Infisical Endpoint (SiteUrl)");
        var clientId = connectionStringBuilder["ClientId"]?.ToString() ?? throw new ArgumentNullException("Infisical ClientId");
        var clientSecret = connectionStringBuilder["Secret"]?.ToString() ?? throw new ArgumentNullException("Infisical Secret");
        var projectId = connectionStringBuilder["ProjectId"]?.ToString() ?? throw new ArgumentNullException("Infisical ProjectId");
        var env = connectionStringBuilder["Environment"]?.ToString() ?? throw new ArgumentNullException("Infisical Environment");

        return new InfisicalOptions(clientId, clientSecret, projectId, env, path, recursive)
        {
            SiteUrl = siteUrl,
        };
    }
}
