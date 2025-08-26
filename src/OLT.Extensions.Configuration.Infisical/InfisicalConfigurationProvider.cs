using Infisical.Sdk;
using Infisical.Sdk.Model;

namespace OLT.Extensions.Configuration.Infisical;


public class InfisicalConfigurationProvider : Microsoft.Extensions.Configuration.ConfigurationProvider, IDisposable
{
    private readonly Timer? _refreshTimer;
    private readonly Lazy<InfisicalClient> _infisicalClient;

    private bool _isInitialLoadComplete;
    private int _networkOperationsInProgress;
    

    public InfisicalConfigurationProvider(InfisicalConfigurationSource source)
    {
        Source = source ?? throw new ArgumentNullException(nameof(source));

        ArgumentNullException.ThrowIfNullOrEmpty(source.InfisicalOptions.SiteUrl, "InfisicalOptions.SiteUrl");
        ArgumentNullException.ThrowIfNullOrEmpty(source.InfisicalOptions.ClientId, "InfisicalOptions.ClientId");
        ArgumentNullException.ThrowIfNullOrEmpty(source.InfisicalOptions.ClientSecret, "InfisicalOptions.ClientSecret");        
        ArgumentNullException.ThrowIfNullOrEmpty(source.InfisicalOptions.Environment, "InfisicalOptions.Environment");
        ArgumentNullException.ThrowIfNullOrEmpty(source.InfisicalOptions.ProjectId, "InfisicalOptions.ProjectId");

        var settings = new InfisicalSdkSettingsBuilder()
                     .WithHostUri(Source.InfisicalOptions.SiteUrl)
                     .Build();

        _infisicalClient = new Lazy<InfisicalClient>(() =>
        {
            var infisicalClient = new InfisicalClient(settings);
            return infisicalClient;
        });

        if (source.ReloadAfter != null)
        {
            _refreshTimer = new Timer(OnTimerElapsed, null, TimeSpan.Zero, source.ReloadAfter.Value);           
        }

    }

    public virtual InfisicalConfigurationSource Source { get; }

    public override void Load()
    {
        try
        {
            LoadAsync(false).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        catch
        {
            throw;
        }
        finally
        {
            _isInitialLoadComplete = true;
        }
    }

    private async Task LoadAsync(bool reload)
    {

        try
        {            
            _ = await _infisicalClient.Value.Auth().UniversalAuth().LoginAsync(Source.InfisicalOptions.ClientId, Source.InfisicalOptions.ClientSecret).ConfigureAwait(false);


            var request = new ListSecretsOptions
            {
                SetSecretsAsEnvironmentVariables = false,
                EnvironmentSlug = Source.InfisicalOptions.Environment,
                ProjectId = Source.InfisicalOptions.ProjectId,
                SecretPath = Source.InfisicalOptions.Path,
                Recursive = Source.InfisicalOptions.Recursive
            };

            var secrets = await _infisicalClient.Value.Secrets().ListAsync(request).ConfigureAwait(false);
            var newData = secrets.ToDictionary(s => s.SecretKey, s => s.SecretValue);
            
            if (Data != null && !Data!.EquivalentTo(newData))
            {
                Data = newData!;

                if (reload)
                {
                    OnReload();
                }
            }

        }
        catch
        {
            if (Source.Optional) return;

            if (!reload) throw;
        }


    }


    private void OnTimerElapsed(object? state)
    {
        if (!_isInitialLoadComplete)
        {
            return;
        }

        if (Interlocked.Exchange(ref this._networkOperationsInProgress, 1) != 0) return;

        try
        {
            LoadAsync(true).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        catch
        {
            throw;
        }
        finally
        {
            Interlocked.Exchange(ref this._networkOperationsInProgress, 0);
        }

      
    }


    public void Dispose()
    {
        _refreshTimer?.Dispose();

        if (!_infisicalClient.IsValueCreated)
            return;

        //_infisicalClient.Value.Dispose();

    }

    /// <summary>
    /// Generates a string representing this provider name and relevant details.
    /// </summary>
    /// <returns>The configuration name.</returns>
    public override string ToString()
        => $"{GetType().Name} for '{Source.InfisicalOptions.SiteUrl} -> path: {Source.InfisicalOptions.Path} -> env: {Source.InfisicalOptions.Environment}' ({(Source.Optional ? "Optional" : "Required")})";


}
