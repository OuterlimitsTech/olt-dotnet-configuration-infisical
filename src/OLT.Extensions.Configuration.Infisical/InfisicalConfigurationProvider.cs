using Infisical.Sdk;
using Microsoft.Extensions.Logging;
using System.Collections.Frozen;
using System.Diagnostics;

namespace OLT.Extensions.Configuration.Infisical;


public class InfisicalConfigurationProvider : Microsoft.Extensions.Configuration.ConfigurationProvider, IDisposable
{
    private readonly Lazy<InfisicalClient> _infisicalClient;
    private readonly InfisicalConfigurationSource _source;
    private readonly Timer? _refreshTimer;


    private static readonly TimeSpan MinDelayForUnhandledFailure = TimeSpan.FromSeconds(5.0);
    private bool _isInitialLoadComplete;
    private int _networkOperationsInProgress;
    

    private ILogger? _logger;
    private ILoggerFactory _loggerFactory = default!;


    public InfisicalConfigurationProvider(InfisicalConfigurationSource source)
    {
        _source = source ?? throw new ArgumentNullException(nameof(source));
        

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

    public ILoggerFactory LoggerFactory
    {
        get => this._loggerFactory;
        set
        {
            this._loggerFactory = value;
            this._logger = this._loggerFactory.CreateLogger("OLT.Extensions.Configuration.Infisical.Provider");
        }
    }

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

            if (!_source.Optional)
                throw;
        }
        finally
        {
            //_source.Refresher.SetProvider(this);
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
        if (!task.Wait(_source.Timeout))
            throw new Exception("Timeout while loading secrets.");
    }

    private FrozenDictionary<string, SecretElement> LoadSecrets()
    {
        var request = new ListSecretsOptions
        {
            Environment = _source.InfisicalOptions.Environment,
            ProjectId = _source.InfisicalOptions.ProjectId,
        };
        try
        {
            return _infisicalClient.Value.ListSecrets(request).ToFrozenDictionary(s => s.SecretKey);
        }
        catch (InfisicalException ex)
        {
            _logger?.LogWarning(ex, "Failed to Load Secrets");
            throw;
        }
        catch(Exception ex)
        {
            _logger?.LogWarning(ex, "A refresh operation failed");
            throw;
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
            Load(true);
        }
        catch (InfisicalException ex)
        {
            _logger?.LogWarning(ex, "A refresh operation failed");
        }
        catch(Exception ex)
        {
            _logger?.LogWarning(ex, "A refresh operation failed");
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

}
