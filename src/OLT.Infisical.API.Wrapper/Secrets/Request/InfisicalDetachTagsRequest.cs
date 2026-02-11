using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets.Request;

public sealed class InfisicalDetachTagsRequest : InfisicalBaseSecretTypeRequest
{
    [JsonPropertyName("projectSlug")]
    public override string? WorkspaceSlug { get; init; }


    [JsonPropertyName("tagSlugs")]
    public IReadOnlyList<string> TagSlugs { get; init; } = new List<string>();
}

