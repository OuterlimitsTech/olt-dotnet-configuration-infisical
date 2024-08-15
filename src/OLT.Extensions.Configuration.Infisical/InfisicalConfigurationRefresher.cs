////using Microsoft.Extensions.Logging;

////namespace OLT.Extensions.Configuration.Infisical;

////internal sealed class InfisicalConfigurationRefresher : IConfigurationRefresher
////{
////    private InfisicalConfigurationProvider _provider = default!;

////    public ILoggerFactory LoggerFactory
////    {
////        get
////        {
////            this.ThrowIfNullProvider(nameof(LoggerFactory));
////            return this._provider.LoggerFactory;
////        }
////        set
////        {
////            this.ThrowIfNullProvider(nameof(LoggerFactory));
////            this._provider.LoggerFactory = value;
////        }
////    }

////    public void SetProvider(InfisicalConfigurationProvider provider)
////    {
////        this._provider = provider ?? throw new ArgumentNullException(nameof(provider));
////    }

////    public void Refresh()
////    {
////        this.ThrowIfNullProvider(nameof(Refresh));
////        this._provider.Refresh();
////    }

////    public bool TryRefresh()
////    {
////        this.ThrowIfNullProvider(nameof(TryRefresh));
////        return this._provider.TryRefresh();
////    }


////    public void SetDirty(TimeSpan? maxDelay)
////    {
////        this.ThrowIfNullProvider(nameof(SetDirty));
////        // this._provider.SetDirty(maxDelay);
////    }

////    private void ThrowIfNullProvider(string operation)
////    {
////        if (this._provider == null)
////            throw new InvalidOperationException($"ConfigurationBuilder.Build() must be called before {operation} can be accessed.");
////    }
////}
