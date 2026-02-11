using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Folders.Response;

public sealed class InfisicalSingleFolderResponse
{
    [JsonPropertyName("folder")]
    public InfiscalFolder? Folder { get; init; }
}
