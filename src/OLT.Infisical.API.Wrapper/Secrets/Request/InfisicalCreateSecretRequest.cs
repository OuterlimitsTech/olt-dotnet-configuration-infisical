using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets.Request;

public sealed class InfisicalCreateSecretRequest : InfisicalBaseSecretUpsertRequest
{
    [JsonPropertyName("projectSlug")]
    public override string? WorkspaceSlug { get; init; }
}

