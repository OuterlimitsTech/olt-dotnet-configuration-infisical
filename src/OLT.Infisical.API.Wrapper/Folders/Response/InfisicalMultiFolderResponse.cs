using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Folders.Response;

public sealed class InfisicalMultiFolderResponse
{
    [JsonPropertyName("folders")]
    public IReadOnlyList<InfiscalFolderList> Folders { get; init; } = new List<InfiscalFolder>();
}
