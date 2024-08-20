using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace OLT.Extensions.Configuration.Infisical;

public static class ConfigurationBuilderExtensions
{ 





    /// <summary>
    /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from Infisical
    /// </summary>
    /// <param name="builder"></param>    
    /// <param name="clientId"></param>
    /// <param name="clientSecret"></param>
    /// <param name="projectId"></param>
    /// <param name="environment"></param>
    /// <param name="reloadAfter"></param>
    /// <returns>The <see cref="IConfigurationBuilder"/></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IConfigurationBuilder AddInfisical(this IConfigurationBuilder builder, string clientId, string clientSecret, string projectId, string environment, TimeSpan? reloadAfter = null)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(environment);
        ArgumentNullException.ThrowIfNullOrEmpty(clientId);
        ArgumentNullException.ThrowIfNullOrEmpty(clientSecret);
        ArgumentNullException.ThrowIfNullOrEmpty(projectId);
        return builder.AddInfisical(ConfigureSource(new InfisicalOptions(environment, clientId, clientSecret, projectId), false, reloadAfter));
    }

    /// <summary>
    /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from Infisical
    /// </summary>
    /// <param name="builder"></param>    
    /// <param name="clientId"></param>
    /// <param name="clientSecret"></param>
    /// <param name="projectId"></param>
    /// <param name="environment"></param>
    /// <param name="optional"></param> 
    /// <param name="reloadAfter"></param>
    /// <returns>The <see cref="IConfigurationBuilder"/></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IConfigurationBuilder AddInfisical(this IConfigurationBuilder builder, string clientId, string clientSecret, string projectId, bool optional, string environment, TimeSpan? reloadAfter = null)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(environment);
        ArgumentNullException.ThrowIfNullOrEmpty(clientId);
        ArgumentNullException.ThrowIfNullOrEmpty(clientSecret);
        ArgumentNullException.ThrowIfNullOrEmpty(projectId);
        return builder.AddInfisical(ConfigureSource(new InfisicalOptions(environment, clientId, clientSecret, projectId), optional, reloadAfter));
    }

    /// <summary>
    /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from Infisical
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="infisicalOptions"></param>
    /// <returns>The <see cref="IConfigurationBuilder"/></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IConfigurationBuilder AddInfisical(this IConfigurationBuilder builder, InfisicalOptions infisicalOptions)
    {
        ArgumentNullException.ThrowIfNull(infisicalOptions);
        return builder.AddInfisical(ConfigureSource(infisicalOptions, false, null));
    }

    /// <summary>
    /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from Infisical
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="infisicalOptions"></param>
    /// <param name="optional"></param>
    /// <returns>The <see cref="IConfigurationBuilder"/></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IConfigurationBuilder AddInfisical(this IConfigurationBuilder builder, InfisicalOptions infisicalOptions, bool optional)
    {
        ArgumentNullException.ThrowIfNull(infisicalOptions);
        return builder.AddInfisical(ConfigureSource(infisicalOptions, optional, null));
    }

    /// <summary>
    /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from Infisical
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="infisicalOptions"></param>
    /// <param name="reloadAfter"></param>
    /// <returns>The <see cref="IConfigurationBuilder"/></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IConfigurationBuilder AddInfisical(this IConfigurationBuilder builder, InfisicalOptions infisicalOptions, TimeSpan reloadAfter)
    {
        ArgumentNullException.ThrowIfNull(infisicalOptions);
        return builder.AddInfisical(ConfigureSource(infisicalOptions, false, reloadAfter));
    }


    /// <summary>
    /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from Infisical
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="infisicalOptions"></param>
    /// <param name="optional"></param>
    /// <param name="reloadAfter"></param>
    /// <returns>The <see cref="IConfigurationBuilder"/></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IConfigurationBuilder AddInfisical(this IConfigurationBuilder builder, InfisicalOptions infisicalOptions, bool optional, TimeSpan reloadAfter)
    {
        ArgumentNullException.ThrowIfNull(infisicalOptions);
        return builder.AddInfisical(ConfigureSource(infisicalOptions, optional, reloadAfter));
    }



    /// <summary>
    /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from Infisical
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="configureSource"></param>
    /// <param name="optional"></param>
    /// <param name="reloadAfter"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IConfigurationBuilder AddInfisical(this IConfigurationBuilder builder, Action<InfisicalConfigurationSource> configureSource, bool optional, TimeSpan? reloadAfter = null)
    {
        if (configureSource == null) throw new ArgumentNullException(nameof(configureSource));

        var source = new InfisicalConfigurationSource();
        source.Optional = optional;
        source.ReloadAfter = reloadAfter;

        configureSource(source);

        return builder.Add(source);
    }

    /// <summary>
    /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from Infisical
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="configureSource"></param>
    /// <returns>The <see cref="IConfigurationBuilder"/></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IConfigurationBuilder AddInfisical(this IConfigurationBuilder builder, Action<InfisicalConfigurationSource> configureSource)
    {
        if (configureSource == null) throw new ArgumentNullException(nameof(configureSource));

        var source = new InfisicalConfigurationSource();
        configureSource(source);
        return builder.Add(source);
    }

    private static Action<InfisicalConfigurationSource> ConfigureSource(InfisicalOptions infisicalOptions, bool optional = false, TimeSpan? reloadAfter = null)
    {
        return configurationSource =>
        {
            configurationSource.InfisicalOptions = infisicalOptions ?? new InfisicalOptions();
            configurationSource.Optional = optional;
            configurationSource.ReloadAfter = reloadAfter;
        };
    }

}
