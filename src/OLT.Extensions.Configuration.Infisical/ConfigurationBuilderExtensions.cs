using Microsoft.Extensions.Configuration;

namespace OLT.Extensions.Configuration.Infisical;

public static class ConfigurationBuilderExtensions
{
    /// <summary>
    /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from Infisical
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="infisicalOptions"></param>
    /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
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
    /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
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
    /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
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
    /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
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
    /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IConfigurationBuilder AddInfisical(this IConfigurationBuilder builder, Action<InfisicalConfigurationSource> configureSource)
    {
        if (configureSource == null) throw new ArgumentNullException(nameof(configureSource));

        var source = new InfisicalConfigurationSource();
        configureSource(source);

        ArgumentException.ThrowIfNullOrEmpty(source.InfisicalOptions.Environment, "InfisicalOptions.Environment");
        ArgumentException.ThrowIfNullOrEmpty(source.InfisicalOptions.ClientId, "InfisicalOptions.ClientId");
        ArgumentException.ThrowIfNullOrEmpty(source.InfisicalOptions.ClientSecret, "InfisicalOptions.ClientSecret");
        ArgumentException.ThrowIfNullOrEmpty(source.InfisicalOptions.SiteUrl, "InfisicalOptions.SiteUrl");
        ArgumentException.ThrowIfNullOrEmpty(source.InfisicalOptions.ProjectId, "InfisicalOptions.ProjectId");

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
