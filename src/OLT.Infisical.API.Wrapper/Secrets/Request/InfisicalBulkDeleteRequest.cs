using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets.Request;

public sealed class InfisicalBulkDeleteRequest : InfisicalBaseSecretPathRequest
{
    [JsonPropertyName("projectSlug")]
    public override string? WorkspaceSlug { get; init; }

    [JsonPropertyName("secrets")]
    public IReadOnlyList<InfisicalBulkSecretDeleteItem> Secrets { get; init; } = new List<InfisicalBulkSecretDeleteItem>();
}

