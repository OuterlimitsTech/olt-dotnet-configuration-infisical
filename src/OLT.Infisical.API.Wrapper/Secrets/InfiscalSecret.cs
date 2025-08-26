using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets;

public sealed class InfiscalSecret
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("workspace")]
    public string? Workspace { get; init; }

    [JsonPropertyName("environment")]
    public string? Environment { get; init; }

    [JsonPropertyName("version")]
    public int? Version { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("secretKey")]
    public string? SecretKey { get; init; }

    [JsonPropertyName("secretValue")]
    public string? SecretValue { get; init; }

    [JsonPropertyName("secretComment")]
    public string? SecretComment { get; init; }

    [JsonPropertyName("secretReminderNote")]
    public string? SecretReminderNote { get; init; }

    [JsonPropertyName("secretReminderRepeatDays")]
    public string? SecretReminderRepeatDays { get; init; }

    [JsonPropertyName("skipMultilineEncoding")]
    public bool? SkipMultilineEncoding { get; init; }

    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; init; }

    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; init; }

    [JsonPropertyName("actor")]
    public InfiscalActor? Actor { get; init; }

    [JsonPropertyName("isRotatedSecret")]
    public bool IsRotatedSecret { get; init; }

    [JsonPropertyName("rotationId")]
    public string RotationId { get; init; } = string.Empty;

    [JsonPropertyName("secretValueHidden")]
    public bool? SecretValueHidden { get; init; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; init; }

    [JsonPropertyName("secretMetadata")]
    public List<InfiscalMetadataItem> SecretMetadata { get; init; } = new List<InfiscalMetadataItem>();

    [JsonPropertyName("secretPath")]
    public string? SecretPath { get; init; }

}
