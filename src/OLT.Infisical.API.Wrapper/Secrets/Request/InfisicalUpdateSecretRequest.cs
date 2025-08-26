using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets.Request;

public sealed class InfisicalUpdateSecretRequest : InfisicalBaseSecretUpsertRequest
{
    [JsonPropertyName("projectSlug")]
    public override string? WorkspaceSlug { get; init; }

    [JsonPropertyName("secretReminderRecipients")]
    public IReadOnlyList<string> SecretReminderRecipients { get; init; } = new  List<string>();

    [JsonPropertyName("newSecretName")]
    public required string NewSecretName { get; init; }
    
}

