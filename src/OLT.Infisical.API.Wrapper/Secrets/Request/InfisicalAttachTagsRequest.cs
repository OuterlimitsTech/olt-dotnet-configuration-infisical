using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets.Request;

public sealed class InfisicalAttachTagsRequest : InfisicalBaseSecretTypeRequest
{
    [JsonPropertyName("tagSlugs")]
    public IReadOnlyList<string> TagSlugs { get; init; } = new List<string>();
}

