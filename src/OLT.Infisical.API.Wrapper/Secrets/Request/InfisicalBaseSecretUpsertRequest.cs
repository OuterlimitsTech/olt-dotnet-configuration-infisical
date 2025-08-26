using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets.Request;


/// <summary>
/// For Create and Update Requests
/// </summary>
public abstract class InfisicalBaseSecretUpsertRequest : InfisicalBaseSecretKeyRequest
{

    [JsonPropertyName("secretValue")]
    public required string SecretValue { get; init; }

    [JsonPropertyName("secretComment")]
    public string? SecretComment { get; init; }

    /// <summary>
    /// Skip multiline encoding for the secret value.
    /// </summary>
    [JsonPropertyName("skipMultilineEncoding")]
    public bool SkipMultilineEncoding { get; init; }


    [JsonPropertyName("tagIds")]
    public IReadOnlyList<string> TagIds { get; init; } = new List<string>();

    [JsonPropertyName("secretMetadata")]
    public List<InfiscalMetadataItem> SecretMetadata { get; init; } = new List<InfiscalMetadataItem>();

    [JsonPropertyName("secretReminderNote")]
    public string? SecretReminderNote { get; init; }

    [JsonPropertyName("secretReminderRepeatDays")]
    public int? SecretReminderRepeatDays { get; init; }

}

