using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets;

public sealed class InfiscalActor
{
    [JsonPropertyName("actorId")]
    public string ActorId { get; init; } = string.Empty;

    [JsonPropertyName("actorType")]
    public string ActorType { get; init; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("membershipId")]
    public string MembershipId { get; init; } = string.Empty;
}
