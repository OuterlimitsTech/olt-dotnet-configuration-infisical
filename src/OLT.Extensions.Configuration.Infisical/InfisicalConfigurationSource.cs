using Microsoft.Extensions.Configuration;

namespace OLT.Extensions.Configuration.Infisical;

public class InfisicalConfigurationSource : IConfigurationSource
{
    public bool Optional { get; set; }
    public TimeSpan? ReloadAfter { get; set; }
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(5);
    public InfisicalOptions InfisicalOptions { get; set; } = new InfisicalOptions();


    //private InfisicalConfigurationRefresher? _refresher = null;

    //internal InfisicalConfigurationRefresher Refresher => _refresher ??= _refresher = new InfisicalConfigurationRefresher();

    //internal IConfigurationRefresher GetRefresher() => this.Refresher;

    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        return new InfisicalConfigurationProvider(this);
    }
}