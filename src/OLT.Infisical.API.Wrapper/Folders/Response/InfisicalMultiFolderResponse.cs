using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Folders.Response;

public sealed class InfisicalMultiFolderResponse
{
    [JsonPropertyName("folder2")]
    public IReadOnlyList<InfiscalFolder> Folders { get; init; } = new List<InfiscalFolder>();
}
