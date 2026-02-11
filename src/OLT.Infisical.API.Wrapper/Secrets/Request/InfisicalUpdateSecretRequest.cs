using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets.Request;

public class InfisicalUpdateSecretRequest : InfisicalCreateSecretRequest
{

    [JsonPropertyName("secretReminderRecipients")]
    public IReadOnlyList<string> SecretReminderRecipients { get; init; } = new List<string>();

    [JsonPropertyName("newSecretName")]
    public string? NewSecretName { get; init; } = null;


}

