using Microsoft.Extensions.Configuration;

namespace OLT.Extensions.Configuration.Infisical;

public class InfisicalConfigurationSource : IConfigurationSource
{
    public bool Optional { get; set; }
    public TimeSpan? ReloadAfter { get; set; }
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(5);
    public InfisicalOptions InfisicalOptions { get; set; } = new InfisicalOptions();

    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        return new InfisicalConfigurationProvider(this);
    }
}