using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets.Request;

/// <summary>
/// For Requests all requests
/// </summary>
public abstract class InfisicalBaseSecretRequest
{
    [JsonPropertyName("workspaceId")]
    public string? WorkspaceId { get; init; }

    [JsonPropertyName("workspaceSlug")]
    public virtual string? WorkspaceSlug { get; init; }

    /// <summary>
    /// examples: dev, prod, staging
    /// </summary>
    [JsonPropertyName("environment")]
    public required string Environment { get; init; }

}

