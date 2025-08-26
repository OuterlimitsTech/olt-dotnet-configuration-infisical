using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets;

public sealed class InfiscalTag
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("slug")]
    public string Slug { get; init; } = string.Empty;

    [JsonPropertyName("color")]
    public string Color { get; init; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;
}
