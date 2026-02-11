using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets;

public sealed class InfiscalMetadataItem
{
    [JsonPropertyName("key")]
    public string Key { get; init; } = string.Empty;
    [JsonPropertyName("value")]
    public string Value { get; init; } = string.Empty;
}
