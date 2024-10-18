using Infisical.Sdk;
using System.Collections.Frozen;
using System.Diagnostics;

namespace OLT.Extensions.Configuration.Infisical;


public class InfisicalConfigurationProvider : Microsoft.Extensions.Configuration.ConfigurationProvider, IDisposable
{
    private readonly Lazy<InfisicalClient> _infisicalClient;
    private readonly Timer? _refreshTimer;


    private static readonly TimeSpan MinDelayForUnhandledFailure = TimeSpan.FromSeconds(5);
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

        _infisicalClient = new Lazy<InfisicalClient>(() =>
        {
            ClientSettings settings = new ClientSettings
            {
                SiteUrl = source.InfisicalOptions.SiteUrl,                
                Auth = new AuthenticationOptions
                {
                    UniversalAuth = new UniversalAuthMethod
                    {
                        ClientId = source.InfisicalOptions.ClientId,
                        ClientSecret = source.InfisicalOptions.ClientSecret
                    }                    
                }                
            };

            return new InfisicalClient(settings);
        });

        if (source.ReloadAfter != null)
        {
            _refreshTimer = new Timer(OnTimerElapsed, null, TimeSpan.Zero, source.ReloadAfter.Value);           
        }

    }

    public virtual InfisicalConfigurationSource Source { get; }

    public override void Load()
    {

        var stopwatch = Stopwatch.StartNew();
        try
        {
            Load(false);            
        }
        catch  
        {
            var delay = MinDelayForUnhandledFailure.Subtract(stopwatch.Elapsed);
            if (delay.Ticks > 0L)
                Task.Delay(delay).ConfigureAwait(false).GetAwaiter().GetResult();

            if (!Source.Optional)
                throw;
        }
        finally
        {
            this._isInitialLoadComplete = true;
        }
    }

    private void Load(bool reload)
    {
        Load(secrets =>
        {
            var data = new Dictionary<string, string>();
            foreach (var (key, value) in secrets)
            {
                data.Add(key, value.SecretValue);
            }
            Data = data!;

            if (reload)
            {
                OnReload();
            }
        });
    }


    private void Load(Action<IDictionary<string, SecretElement>> callback)
    {
        var task = Task.Run(() => callback(LoadSecrets()));
        if (!task.Wait(Source.Timeout))
            throw new Exception("Timeout while loading secrets.");
    }

    private FrozenDictionary<string, SecretElement> LoadSecrets()
    {
        var request = new ListSecretsOptions
        {
            Environment = Source.InfisicalOptions.Environment,
            ProjectId = Source.InfisicalOptions.ProjectId,
            Path = Source.InfisicalOptions.Path,
            Recursive = Source.InfisicalOptions.Recursive
        };

        return _infisicalClient.Value.ListSecrets(request).ToFrozenDictionary(s => s.SecretKey);
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
            Load(true);
        }
        catch
        {
            if (!Source.Optional)
            {
                throw;
            }                
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

        _infisicalClient.Value.Dispose();
    }

    /// <summary>
    /// Generates a string representing this provider name and relevant details.
    /// </summary>
    /// <returns>The configuration name.</returns>
    public override string ToString()
        => $"{GetType().Name} for '{Source.InfisicalOptions.SiteUrl} -> path: {Source.InfisicalOptions.Path} -> env: {Source.InfisicalOptions.Environment}' ({(Source.Optional ? "Optional" : "Required")})";


}
