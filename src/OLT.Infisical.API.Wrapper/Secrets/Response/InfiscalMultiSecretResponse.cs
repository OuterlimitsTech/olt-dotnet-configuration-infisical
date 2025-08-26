using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets.Response;

public sealed class InfiscalMultiSecretResponse
{
    [JsonPropertyName("secrets")]
    public IReadOnlyList<InfiscalSecret> Secrets { get; init; } = new List<InfiscalSecret>();
}
