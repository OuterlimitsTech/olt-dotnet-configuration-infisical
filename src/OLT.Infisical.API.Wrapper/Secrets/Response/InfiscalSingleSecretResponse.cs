using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets.Response;

public sealed class InfiscalSingleSecretResponse
{
    [JsonPropertyName("secret")]
    public InfiscalSecret? Secret { get; init; }
}
