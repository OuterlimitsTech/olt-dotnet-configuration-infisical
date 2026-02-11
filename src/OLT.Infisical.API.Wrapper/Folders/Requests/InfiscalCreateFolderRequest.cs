using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Folders.Requests;

public sealed class InfiscalCreateFolderRequest : InfisicalBaseFolderPathRequest
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }
}

