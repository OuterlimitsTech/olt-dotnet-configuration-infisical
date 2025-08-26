using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets.Request;


public sealed class InfisicalBulkUpdateRequest : InfisicalBaseSecretPathRequest
{
    [JsonPropertyName("projectSlug")]
    public override string? WorkspaceSlug { get; init; }

    /// <summary>
    /// ignore, upsert, failOnNotFound
    /// </summary>
    /// <remarks>
    /// default: failOnNotFound
    /// </remarks>
    [JsonPropertyName("mode")]
    public string Mode { get; init; } = "failOnNotFound";

    [JsonPropertyName("secrets")]
    public List<InfisicalUpdateSecretRequest> Secrets { get; init; } = new List<InfisicalUpdateSecretRequest>();
}

