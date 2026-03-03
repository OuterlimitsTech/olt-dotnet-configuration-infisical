using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OLT.Infisical.API.Wrapper.Auth;
using Polly;
using Refit;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper;

public static class BuilderExtensions
{
    public static IServiceCollection AddInfisicalHttpClient(this IServiceCollection services, Action<InfisicalApiOptions> action)
    {

        services.Configure<InfisicalApiOptions>(options => action(options));
        services.AddScoped<IInfisicalTokenService, InfisicalTokenService>();
        services.AddMemoryCache();

        var settings = new RefitSettings
        {
            UrlParameterFormatter = new InfisicalCustomUrlParameterFormatter(),
            ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            })
        };


        services
            .AddRefitClient<IInfisicalApiUniversalAuth>(settings)
            .ConfigureHttpClient((services, client) =>
            {
                var opts = services.GetRequiredService<IOptions<InfisicalApiOptions>>().Value;
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.BaseAddress = new Uri(opts.SiteUrl);
            })
            .AddPolicyHandler(Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode).RetryAsync(3));

        services
            .AddRefitClient<IInfisicalApiSecrets>(settings)
            .ConfigureHttpClient((services, client) =>
            {
                var opts = services.GetRequiredService<IOptions<InfisicalApiOptions>>().Value;
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.BaseAddress = new Uri(opts.SiteUrl);
            })
            .AddHttpMessageHandler(services => new InfisicalBearerTokenHandler(services.GetRequiredService<IInfisicalTokenService>()))
            .AddPolicyHandler(Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode).RetryAsync(3));

        services
            .AddRefitClient<IInfisicalApiFolders>(settings)
            .ConfigureHttpClient((services, client) =>
            {
                var opts = services.GetRequiredService<IOptions<InfisicalApiOptions>>().Value;
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.BaseAddress = new Uri(opts.SiteUrl);
            })
            .AddHttpMessageHandler(services => new InfisicalBearerTokenHandler(services.GetRequiredService<IInfisicalTokenService>()))
            .AddPolicyHandler(Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode).RetryAsync(3));

        return services;
    }
}

