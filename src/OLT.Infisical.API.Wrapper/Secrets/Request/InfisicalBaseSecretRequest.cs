using Refit;
using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets.Request;

/// <summary>
/// For Requests all requests
/// </summary>
public abstract class InfisicalBaseSecretRequest
{
    [JsonPropertyName("workspaceId")]
    [AliasAs("workspaceId")]
    public virtual string? WorkspaceId { get; init; }

    [JsonPropertyName("workspaceSlug")]
    [AliasAs("workspaceSlug")]
    public virtual string? WorkspaceSlug { get; init; }

    /// <summary>
    /// examples: dev, prod, staging
    /// </summary>
    [JsonPropertyName("environment")]
    [AliasAs("environment")]
    public required string Environment { get; init; }

}

