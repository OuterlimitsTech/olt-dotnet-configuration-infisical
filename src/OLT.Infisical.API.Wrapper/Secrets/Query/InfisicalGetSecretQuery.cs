using OLT.Infisical.API.Wrapper.Secrets.Request;
using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets.Query;

public sealed class InfisicalGetSecretQuery : InfisicalBaseSecretTypeRequest
{
    [JsonPropertyName("version")]
    public int? Version { get; init; }

    [JsonPropertyName("viewSecretValue")]
    public bool ViewSecretValue { get; init; } = true;

    [JsonPropertyName("expandSecretReferences")]
    public bool ExpandSecretReferences { get; init; } = false;

    [JsonPropertyName("includeImports")]
    public bool IncludeImports { get; init; } = false;
}
