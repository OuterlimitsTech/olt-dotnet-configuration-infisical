using OLT.Infisical.API.Wrapper.Folders;
using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets.Response;

public sealed class InfiscalCreateFolderResponse
{
    [JsonPropertyName("folder")]
    public InfiscalFolder? Folder { get; init; }
}
