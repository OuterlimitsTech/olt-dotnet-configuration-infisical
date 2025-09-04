using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets.Request;

public class InfisicalCreateSecretRequest : InfisicalBaseSecretTypeRequest
{
    [JsonPropertyName("projectSlug")]
    public override string? WorkspaceSlug { get; init; } = null;

    [JsonPropertyName("secretValue")]
    public required string SecretValue { get; init; }

    [JsonPropertyName("secretComment")]
    public string SecretComment { get; init; } = string.Empty;

    /// <summary>
    /// Skip multiline encoding for the secret value.
    /// </summary>
    [JsonPropertyName("skipMultilineEncoding")]
    public bool SkipMultilineEncoding { get; init; } = true;


    [JsonPropertyName("tagIds")]
    public IReadOnlyList<string> TagIds { get; init; } = new List<string>();

    [JsonPropertyName("secretMetadata")]
    public List<InfiscalMetadataItem> SecretMetadata { get; init; } = new List<InfiscalMetadataItem>();

    [JsonPropertyName("secretReminderNote")]
    public string? SecretReminderNote { get; init; }

    [JsonPropertyName("secretReminderRepeatDays")]
    public int? SecretReminderRepeatDays { get; init; }
}

