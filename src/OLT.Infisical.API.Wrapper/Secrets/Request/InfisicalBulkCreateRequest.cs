using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets.Request;

public sealed class InfisicalBulkCreateRequest : InfisicalBaseSecretPathRequest
{
    [JsonPropertyName("projectSlug")]
    public override string? WorkspaceSlug { get; init; }

    [JsonPropertyName("secrets")]
    public IReadOnlyList<InfisicalCreateSecretRequest> Secrets { get; init; } = new List<InfisicalCreateSecretRequest>();
}

