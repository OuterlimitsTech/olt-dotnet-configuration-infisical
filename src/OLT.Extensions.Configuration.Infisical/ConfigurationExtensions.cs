using Microsoft.Extensions.Configuration;

namespace OLT.Extensions.Configuration.Infisical;

/// <summary>
/// This extension is an a different namespace to avoid misuse of this method which should only be called when being used from AWS Lambda.
/// </summary>
public static class ConfigurationExtensions
{

    public static IConfigurationBuilder AddInfisical(this IConfigurationBuilder builder, InfisicalOptions infisicalOptions, bool optional, TimeSpan reloadAfter)
    {
        ArgumentNullException.ThrowIfNull(infisicalOptions);
        return builder.AddInfisical(ConfigureSource(infisicalOptions, optional, reloadAfter));
    }

    //public static void AddInfisical(this IConfiguration configuration, Action<InfisicalOptions> configure, bool optional, TimeSpan reloadAfter)
    //{
    //    //if (configuration is ConfigurationRoot configRoot)
    //    //{
    //    //    foreach (var provider in configRoot.Providers)
    //    //    {
    //    //        if (provider is InfisicalConfigurationProvider ssmProvider)
    //    //        {
    //    //            //ssmProvider.WaitForReloadToComplete(timeout);
    //    //        }
    //    //    }
    //    //}
    //}

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
